using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO;

namespace JinjingZheng
{

    public delegate void APICallBack(JObject result,System.Net.WebException ex=null);
    public delegate void HTTPCallback(string result, System.Net.WebException ex = null);

    public class JinJingZhengAPI
    {
        /// <summary>
        /// send: {"phone":"xxxxxxx","regist"1"}
        /// rep:{"verification":"","resdes":"短信发送成功","rescode":"200"}
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="regist"></param>
        /// <param name="cb"></param>
        public static void SendVerifyCode(string phone, string regist, APICallBack cb)
        {

            JObject o = new JObject();
            o["phone"] = phone;
            o["regist"] = regist;
            string url = "https://bjjj.zhongchebaolian.com/common_api/mobile/standard/verification";
            HttpPost(url, o.ToString(), "application/json", (result, ex) => {
                if (ex == null) {
                    cb?.Invoke(JObject.Parse(result));
                } else {
                    cb?.Invoke(null,ex);
                }
            });
        }


        public static void Login(string phone,string valicode,APICallBack cb)
        {

            //request 
            /* {
                 "devicetype": "0",
                 "lon": "116.437342",
                 "phone": "11111111111",
                 "timestamp": "2016-11-29 12:53:09",
                 "source": "0",
                 "lat": "39.942857",
                 "token": "13165ffa4e0890ac09f",
                 "deviceid": "2803058bbc2bc19155c37b6b332eb893",
                 "citycode": "1101",
                 "appkey": "0791682354",
                 "valicode": "523901",
                 "vertype": "1"
             }*/

            JObject o = new JObject();
            o["devicetype"] = "0";
            o["lon"] = "116.437342";
            o["phone"] = phone;
            o["timestamp"] = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            o["source"] = "0";
            o["lat"] = "39.942857";
            o["token"] = Utils.CalcToken();
            o["deviceid"] = "eac96257058bbe516a14g58434459d25";
            o["citycode"] = "1101";
            o["appkey"] = "0791682354";
            o["valicode"] = valicode;
            o["vertype"] = "1";



            string url = "https://api.accident.zhongchebaolian.com/industryguild_mobile_standard_self2.1.2/mobile/standard/login";
            HttpPost(url, o.ToString(), "application/json", (result, ex) => {
                if (ex == null) {
                    cb?.Invoke(JObject.Parse(result));
                } else {
                    cb?.Invoke(null, ex);
                }
            });

        }


        public static void GetEnterCarList(string userid,APICallBack cb)
        {

            //var req = Http.Post("https://api.jinjingzheng.zhongchebaolian.com/enterbj/platform/enterbj/entercarlist");
            //req.Form(new {
            //    userid = userid,
            //    appkey ="kkk",
            //    deviceid ="ddd",
            //    timestamp =JinjingZhengAPIUtil.GetTimestamp(),
            //    token =JinjingZhengAPIUtil.CalcToken(),
            //    appsource = ""
            //}).OnSuccess((str) => {
            //      cb?.Invoke(JObject.Parse(str));
            //}).OnFail((ex) => {
            //      cb?.Invoke(null, ex);
            //}).Go();


            string url = "https://api.jinjingzheng.zhongchebaolian.com/enterbj/platform/enterbj/entercarlist";
            string data = Utils.SerializeQueryString(new {
                userid = userid,
                appkey = "kkk",
                deviceid = "ddd",
                timestamp = Utils.GetTimestamp(),
                token = Utils.CalcToken(),
                appsource = ""
            });
            HttpPost(url, data, "application/x-www-form-urlencoded; charset=UTF-8",(result, ex) => {
                if (ex == null) {
                    cb?.Invoke(JObject.Parse(result));
                } else {
                    cb?.Invoke(null, ex);
                }
            });
        }


        /// <summary>
        /// 申请进京证
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="inbjduration">进京时长(天)</param>
        /// <param name="inbjtime">进京时间</param>
        /// <param name="licenseno">车牌号</param>
        /// <param name="engineno">引擎号码</param>
        /// <param name="cartypecode">号牌类型 02:小型汽车</param>
        /// <param name="vehicletype">机动车类型 12:小型客车</param>
        /// <param name="drivingphoto">行驶证正面照片</param>
        /// <param name="carphoto">车辆正面照片</param>
        /// <param name="drivername">驾驶员姓名</param>
        /// <param name="driverlicenseno">驾驶证号</param>
        /// <param name="driverphoto">驾驶证照片</param>
        /// <param name="personphoto">本人持身份证照</param>
        /// <param name="carid"></param>
        /// <param name="cb"></param>
        public static void Submitpaper(string userid,int inbjduration,DateTime inbjtime,
            string licenseno,string engineno,string cartypecode,string vehicletype, Image drivingphoto,
            Image carphoto,string drivername,string driverlicenseno, Image driverphoto, Image personphoto,string carid, APICallBack cb)
        {
            //var req = Http.Post("https://api.jinjingzheng.zhongchebaolian.com/enterbj/platform/enterbj/submitpaper");

            ////req.Body(BodyProvider)

            //req.Form(new {
            //    appsource = "bjjj",
            //    inbjentrancecode1 = "05",
            //    inbjentrancecode = "19",
            //    inbjduration = inbjduration.ToString(),
            //    inbjtime = inbjtime.ToString("yyyy-MM-dd"),
            //    appkey = "",
            //    deviceid = "",
            //    token = "",
            //    timestamp = "",
            //    userid = userid,
            //    licenseno = licenseno,
            //    engineno = engineno,
            //    cartypecode = cartypecode,
            //    vehicletype = vehicletype,
            //    drivingphoto = JinjingZhengAPIUtil.Image2Base64(drivingphoto),
            //    carphoto = JinjingZhengAPIUtil.Image2Base64(carphoto),
            //    drivername = drivername,
            //    driverlicenseno = driverlicenseno,
            //    driverphoto = JinjingZhengAPIUtil.Image2Base64(driverphoto),
            //    personphoto = JinjingZhengAPIUtil.Image2Base64(personphoto),
            //    gpslon = "",
            //    gpslat = "",
            //    phoneno = "",
            //    imei = "",
            //    imsi = "",
            //    carid = carid,
            //}).OnSuccess((str) => {
            //    cb?.Invoke(JObject.Parse(str));
            //}).OnFail((ex) => {
            //    cb?.Invoke(null, ex);
            //}).Go();


            string url = "https://api.jinjingzheng.zhongchebaolian.com/enterbj/platform/enterbj/submitpaper";
            string data = Utils.SerializeQueryString(new {
                appsource = "bjjj",
                inbjentrancecode1 = "05",
                inbjentrancecode = "19",
                inbjduration = inbjduration.ToString(),
                inbjtime = inbjtime.ToString("yyyy-MM-dd"),
                appkey = "",
                deviceid = "",
                token = "",
                timestamp = "",
                userid = userid,
                licenseno = licenseno,
                engineno = engineno,
                cartypecode = cartypecode,
                vehicletype = vehicletype,
                drivingphoto = "IMGDRIVINGPHOTO",
                carphoto = "IMGCARPHOTO",
                drivername = drivername,
                driverlicenseno = driverlicenseno,
                driverphoto = "IMGDRIVERPHOTO",
                personphoto = "IMGPERSONPHOTO",
                gpslon = "",
                gpslat = "",
                phoneno = "",
                imei = "",
                imsi = "",
                carid = carid,
            });

            data = data.Replace("IMGDRIVINGPHOTO", Utils.Image2Base64(drivingphoto));
            data = data.Replace("IMGCARPHOTO", Utils.Image2Base64(carphoto));
            data = data.Replace("IMGDRIVERPHOTO", Utils.Image2Base64(driverphoto));
            data = data.Replace("IMGPERSONPHOTO", Utils.Image2Base64(personphoto));


            //drivingphoto = Utils.Image2Base64(drivingphoto),
            //    carphoto = Utils.Image2Base64(carphoto),
            //    drivername = drivername,
            //    driverlicenseno = driverlicenseno,
            //    driverphoto = Utils.Image2Base64(driverphoto),
            //    personphoto = Utils.Image2Base64(personphoto),


            HttpPost(url, data, "application/x-www-form-urlencoded; charset=UTF-8", (result, ex) => {
                if (ex == null) {
                    cb?.Invoke(JObject.Parse(result));
                } else {
                    cb?.Invoke(null, ex);
                }
            });

        }


        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            //直接确认，否则打不开    
            return true;
        }

        private static void HttpPost(string url, string body,string contenttype,HTTPCallback cb)
        {
            byte[] request_body = Encoding.UTF8.GetBytes(body);
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
                //request.Proxy = new WebProxy("127.0.0.1", 8888);

                request.Method = "POST";
                request.ProtocolVersion = new Version(1, 1);
                request.UserAgent = "BeiJingJiaoJing/1.1.1 (iPhone; iOS 10.1.1; Scale/2.00)";
                request.Accept = "application/json";
                request.ContentType = contenttype;
                request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                request.Headers.Add("Accept-Language", "zh-Hans-CN;q=1");
                request.KeepAlive = true;

                request.ContentLength = request_body.Length;
                request.GetRequestStream().Write(request_body, 0, request_body.Length);
                request.BeginGetResponse((result) => {
                    var response = request.EndGetResponse(result);
                    var response_stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(response_stream, System.Text.Encoding.UTF8);
                    string str = reader.ReadToEnd();
                    response.Close();
                    cb?.Invoke(str,null);

                }, request);
            }
            catch (WebException ex)
            {
                cb?.Invoke("", ex);
            }

        }

    }




}
