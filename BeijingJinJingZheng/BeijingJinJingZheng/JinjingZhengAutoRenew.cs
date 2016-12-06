using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JinjingZheng;
using Newtonsoft.Json;
using System.Drawing;
using Newtonsoft.Json.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.IO;

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
            WaitingNet,
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
            LogWrapper.LogInfo("启动服务...");
            mWorkerThread = new Thread(_workerhread);
            mWorkerThread.Start();
            State = RunState.EnterCarList;
            
        }

        public void Stop()
        {
            if (mWorkerThread == null) return;
            mWorkerThread.Abort();
            mWorkerThread = null;
            LogWrapper.LogInfo("停止服务...");
        }

        //上一次检查时的进京证到期时间
        DateTime lastCarEndTime = DateTime.MinValue;

        void _workerhread()
        {


            //启动
            //1.获取列表
            //2.1 输出列表
            //2.2 检查是否需要申请
            //2.3 检查是否有申请成功的
            //3.等待N秒,跳到1
            //退出

            while (true) {

                switch (State) {
                    case RunState.EnterCarList:
                    {

                        // 获取进京证列表
                        State = RunState.WaitingNet;
                        LogWrapper.LogInfo("正在获取进京证列表...");
                        JinJingZhengAPI.GetEnterCarList(mConfig.UserID, (result, ex) => {
                            if (ex == null) {
                                HandlCheckEnterCar(result);
                            }else{
                                HandleError("获取进京证列表失败", ex);
                            }
                        });
                    }
                    break;

                    case RunState.WaitingNet:
                    Thread.Sleep(1000);
                    break;
                    case RunState.Waiting:
                    LogWrapper.LogInfo("正在等待下次检查...");
                    Thread.Sleep(1000*mConfig.Interval);
                    State = RunState.EnterCarList;
                    break;
                }



            }
        }


        void HandleError(string prefix,System.Net.WebException ex)
        {
            LogWrapper.LogError(prefix+":" + ex.Message);
            State = RunState.Waiting;
        }

        void HandlCheckEnterCar(JObject result)
        {
            try
            {
                EnterCartListResponse rep = JsonConvert.DeserializeObject<EnterCartListResponse>(result.ToString());
                if (rep.rescode == "200") {

                    // 1.获取当前所有进京证信息
                    List<Carapplyarr> enterCarInfolist = new List<Carapplyarr>();
                    if (rep.datalist != null) {
                        foreach (var carInfo in rep.datalist) {
                            if (carInfo.carapplyarr != null) {
                                foreach (var entercar in carInfo.carapplyarr) {
                                    enterCarInfolist.Add(entercar);
                                }
                            }
                        }
                    }

                    if (enterCarInfolist.Count <= 0) {
                        LogWrapper.LogInfo("当前没有进京证信息,无法为您申请新的进京证!");
                        State = RunState.Waiting;
                        return;
                    }

                    // 2.检查是否需要申请新的进京证


                    // 计算当前进京证有效期
                    DateTime carStartTime = DateTime.MaxValue;
                    DateTime carEndTime = DateTime.MinValue;
                    DateTime carReadlEndTime = DateTime.MinValue;//进京证实际到期时间,不包过审核中的进京证
                    LogWrapper.LogInfoFormat("您现在共有 {0} 个进京证", enterCarInfolist.Count);
                    foreach (var entercar in enterCarInfolist) {
                        var enterbjstart = DateTime.Parse(entercar.enterbjstart);
                        var enterbjend = DateTime.Parse(entercar.enterbjend);
                        if (enterbjstart < carStartTime) carStartTime = enterbjstart;
                        if (enterbjend > carEndTime) carEndTime = enterbjend;

                        string statusStr = "状态:未知";
                        if (entercar.status == "0") {
                            statusStr = " 状态:审核失败";
                        } else if (entercar.status == "1") {
                            statusStr = "状态:审核成功";
                            if (enterbjend > carReadlEndTime) carReadlEndTime = enterbjend;
                        } else if (entercar.status == "2") {
                            statusStr = "状态:审核中";
                        }

                        LogWrapper.LogInfoFormat("进京证 {0} {1} 至 {2} {3}", entercar.licenseno, enterbjstart.ToString("yyyy-MM-dd"),
                        enterbjend.ToString("yyyy-MM-dd"), statusStr);
                    }




                    LogWrapper.LogInfoFormat("您当前进京证的有效期是 {0} 至 {1}", carStartTime.ToString("yyyy-MM-dd"),
                        carEndTime.ToString("yyyy-MM-dd"));


                    //如果进京证有效期的截止时间是今天,则申请新的进京证
                    var now = DateTime.Now;
                    if (carEndTime.Year == now.Year && carEndTime.Month == now.Month && carEndTime.Day == now.Day) {
                        // 申请新进京证
                        LogWrapper.LogInfo("您的进京证即将到期,正在为您申请新的进京证");

                        HandleSubmitpaper(enterCarInfolist[0]);
                        State = RunState.Waiting;
                        return;
                    }

                    // 3.检查是否有新进京证申请成功
                    if (carReadlEndTime > lastCarEndTime) {
                        string str = string.Format("进京证审核成功 {0} {1} 至 {2}", enterCarInfolist[0].licenseno, carStartTime.ToString("yyyy-MM-dd"),
                        carReadlEndTime.ToString("yyyy-MM-dd"));
                        LogWrapper.LogInfo(str);
                        if (mConfig.EnableMail) {
                            string time = carStartTime.ToString("yyyy-MM-dd") + "-" + carReadlEndTime.ToString("yyyy-MM-dd");
                            if (SendMail("进京证审核成功:" + enterCarInfolist[0].licenseno, time)) {
                                LogWrapper.LogInfo("提醒邮件发送成功...");
                            } else {
                                LogWrapper.LogInfo("提醒邮件发送失败...");
                            }
                        }
                    }
                    lastCarEndTime = carReadlEndTime;


                    State = RunState.Waiting;


                } else {
                    LogWrapper.LogErrorFormat("获取进京证列表失败 {0}:{1}", rep.rescode, rep.resdes);
                }
                State = RunState.Waiting;

            } catch (Exception e)
            {
                LogWrapper.LogErrorFormat("获取进京证列表失败 {0}",e.Message);
            }
            

        }


        void HandleSubmitpaper(Carapplyarr carinfo)
        {
            var enterBjStart = DateTime.Now.AddDays(1);
            LogWrapper.LogInfoFormat("正在申请进京证 进京日期 {0} 进京时间 {1} 天", enterBjStart.ToString("yyyy-MM-dd"), mConfig.InbjDuration);
            State = RunState.WaitingNet;
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
                            if (SendMail("进京证申请成功,正在审核" + carinfo.licenseno, enterBjStart.ToString("yyyy-MM-dd")+" " + mConfig.InbjDuration+"天")) {
                                LogWrapper.LogInfo("提醒邮件发送成功...");
                            } else {
                                LogWrapper.LogInfo("提醒邮件发送失败...");
                            }
                        } else {
                            LogWrapper.LogError(string.Format("申请进京证失败.错误码:{0} 错误信息:{1}", rescode, resdes));
                            SendMail("进京证申请失败:" + rescode, resdes);
                        }

                    } else {
                        HandleError("申请进京证失败,网络异常", ex);
                    }

                    State = RunState.Waiting;

                });


        }

        public bool SendMail(string title, string content)
        {

            string useremail = mConfig.UserMailID;
            string password = mConfig.UserMailPassword;
            string to = mConfig.ToMail;
            MailMessage msg = new MailMessage(useremail, to);

            msg.Subject = title;
            msg.Body = content;
            msg.IsBodyHtml = false;
            msg.BodyEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            msg.SubjectEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            msg.Priority = MailPriority.Normal;
            SmtpClient client = new SmtpClient();

            string[] usernameAndHost = useremail.Split('@');
            string host = "smtp." + usernameAndHost[1];
            string uname = usernameAndHost[0];
            client.Host = host;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(uname, password);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            try {
                client.Send(msg);
                LogWrapper.LogError("邮件发送成功:");
                return true;
            } catch (Exception e) {
                LogWrapper.LogError("邮件发送失败:" + e.Message);
            }

            return false;
        }




    }
}
