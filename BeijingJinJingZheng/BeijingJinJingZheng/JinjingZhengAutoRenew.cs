using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JinjingZheng;
using Newtonsoft.Json;
using System.Drawing;

namespace BeijingJinJingZheng
{

    public class Carapplyarr
    {
        public string applyid;
        public string carid;
        public string cartype;
        public string engineno;
        public string enterbjend;
        public string enterbjstart;
        public string existpaper;
        public string licenseno;
        public string loadpapermethod;
        public string remark;
        public string status;
        public string syscode;
        public string syscodedesc;
        public string userid;
    }

    public class EnterCarInfo
    {
        public string carid;
        public string userid;
        public string licenseno;
        public string applyflag;
        public string applyid;
        public Carapplyarr[] carapplyarr;
    }

    public class EnterCartListResponse
    {
        public EnterCarInfo[] datalist;
        public string rescode;
        public string resdes;
    }



    public class JinjingZhengAutoRenew
    {

        public enum RunState
        {
            EnterCarList,
            WaitingEnterCarList,
            Submitpaper,
            WaitingSubmitpaper,
            Waiting,
        }

        



        UserConfig mConfig;
        Thread mWorkerThread;
        public RunState State = RunState.EnterCarList;

        public bool IsRun
        {
            get
            {
                return mWorkerThread != null;
            }
        }


        public void Run(UserConfig config)
        {
            if (mWorkerThread != null) return;
            mConfig = config;
            mWorkerThread = new Thread(_workerhread);
            mWorkerThread.Start();
            State = RunState.EnterCarList;
        }

        public void Stop()
        {
            if (mWorkerThread == null) return;
            mWorkerThread.Abort();
            mWorkerThread = null;
        }


        void _workerhread()
        {
            Carapplyarr lastInfo = null;
            while (true) {

                
                switch (State) {
                    case RunState.EnterCarList:
                    LogWrapper.LogInfo("正在获取进京证列表...");
                    State = RunState.WaitingEnterCarList;
                    JinJingZhengAPI.GetEnterCarList(mConfig.UserID, (result, ex) => {
                        if (ex == null) {
                            string rescode = result["rescode"].ToString();
                            string resdes = result["resdes"].ToString();
                            if (rescode == "200") {
                                EnterCartListResponse rep = JsonConvert.DeserializeObject<EnterCartListResponse>(result.ToString());
                                var carlist = rep.datalist;
                                if (carlist != null) {
                                    foreach (var carinfo in carlist) {

                                        if (carinfo.carapplyarr != null) {
                                            foreach (var carapplyarr in carinfo.carapplyarr)
                                            {
                                                string status = "";
                                                if (carapplyarr.status == "1") {
                                                    status = "有效期内";
                                                } else if (carapplyarr.status == "0") {
                                                    status = "审核失败";
                                                } else if (carapplyarr.status == "2") {
                                                    status = "审核中";
                                                }

                                                string str = string.Format("进京证 {0} {1}-{2} {3}", carapplyarr.licenseno,
                                                    carapplyarr.enterbjstart,carapplyarr.enterbjend,status);
                                                LogWrapper.LogInfo(str);
                                            }
                                        }


                                        if (carinfo.carapplyarr != null && carinfo.carapplyarr.Length == 1) {
                                            var carapplyarr = carinfo.carapplyarr[0];
                                            if (carapplyarr.status == "1") {
                                                LogWrapper.LogInfo(string.Format("{0}  到期时间:{1}", carapplyarr.licenseno, carapplyarr.enterbjend));
                                                var endterbjend = DateTime.Parse(carapplyarr.enterbjend);
                                                if (endterbjend.Month == DateTime.Now.Month && endterbjend.Day == DateTime.Now.Day) {
                                                    LogWrapper.LogInfo("您的进京证即将到期..");
                                                    lastInfo = carapplyarr;
                                                    State = RunState.Submitpaper;
                                                    return;
                                                }
                                            } else if (carapplyarr.status == "0") {
                                                LogWrapper.LogInfo("您的进京证审核失败..");
                                            } else if (carapplyarr.status == "2") {
                                                LogWrapper.LogInfo("您的进京证正在审核中..");
                                            }
                                        }
                                    }

                                }
                            } else {
                                LogWrapper.LogError(string.Format("获取进京证列表失败.错误码:{0} 错误信息:{1}",rescode,resdes));
                            }


                        } else {
                            LogWrapper.LogError("网络异常<获取进京证列表>:" + ex.Message);
                        }
                        State = RunState.Waiting;
                    });
                    break;
                    case RunState.WaitingEnterCarList:
                    LogWrapper.LogInfo("WaitingEnterCarList...");
                    Thread.Sleep(1000);
                    break;
                    case RunState.Submitpaper:
                    if (lastInfo != null) {
                        HandleSubmitpaper(lastInfo);
                    }
                    break;    
                    case RunState.WaitingSubmitpaper:
                    LogWrapper.LogInfo("WaitingSubmitpaper...");
                    Thread.Sleep(1000);
                    break;
                    case RunState.Waiting:
                    LogWrapper.LogInfo("Waiting...");
                    Thread.Sleep(mConfig.Interval * 1000);
                    State = RunState.EnterCarList;
                    break;
                }
                
            }
        }


        void HandleSubmitpaper(Carapplyarr carinfo)
        {
            var enterBjStart = DateTime.Now.AddDays(1);
            LogWrapper.LogInfo(string.Format("正在申请进京证 进京日期 {0} 进京时间 {1} 天", enterBjStart.ToString("yyyy-MM-dd"), mConfig.InbjDuration));
            State = RunState.WaitingSubmitpaper;

            JinJingZhengAPI.Submitpaper(mConfig.UserID, mConfig.InbjDuration, enterBjStart, carinfo.licenseno, carinfo.engineno, mConfig.CarTypeCode,
                mConfig.VehicleType, Image.FromFile(mConfig.DrivingPhoto),
                Image.FromFile(mConfig.CarPhoto),
                mConfig.DriverName,
                mConfig.DriverLicenseno,
                Image.FromFile(mConfig.DriverPhoto),
                Image.FromFile(mConfig.PersonPhoto),
                carinfo.carid,
                (result, ex) => {

                    if (ex == null) {
                        string rescode = result["rescode"].ToString();
                        string resdes = result["resdes"].ToString();
                        if (rescode == "200") {
                            LogWrapper.LogInfo("进京证申请成功,正在审核中.");
                        } else {
                            LogWrapper.LogError(string.Format("申请进京证失败.错误码:{0} 错误信息:{1}", rescode, resdes));
                        }

                    } else {
                        LogWrapper.LogError("网络异常<获取进京证列表>:" + ex.Message);
                    }

                    State = RunState.Waiting;

                });


        }
    }
}
