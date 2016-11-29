using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JumpKick.HttpLib;
using JumpKick.HttpLib.Provider;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace JinjingZheng
{

    public delegate void APICallBack(JObject result,System.Net.WebException ex=null);


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
            var req = Http.Post("https://bjjj.zhongchebaolian.com/common_api/mobile/standard/verification");
            JObject o = new JObject();
            o["phone"] = phone;
            o["regist"] = regist;
            req.Body(o.ToString()).OnSuccess((str) => {
                cb?.Invoke(JObject.Parse(str));
            }).OnFail((ex) => {
                cb?.Invoke(null, ex);
            }).Go();
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

            var req = Http.Post("https://api.accident.zhongchebaolian.com/industryguild_mobile_standard_self2.1.2/mobile/standard/login");
            JObject o = new JObject();
            o["devicetype"] = "0";
            o["lon"] = "116.437342";
            o["phone"] = phone;
            o["timestamp"] = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            o["source"] = "0";
            o["lat"] = "39.942857";
            o["token"] = JinjingZhengAPIUtil.CalcToken();
            o["deviceid"] = "eac96257058bbe516a14g58434459d25";
            o["citycode"] = "1101";
            o["appkey"] = "0791682354";
            o["valicode"] = valicode;
            o["vertype"] = "1";
            req.Body(o.ToString()).OnSuccess((str) => {
                cb?.Invoke(JObject.Parse(str));
            }).OnFail((ex) => {
                cb?.Invoke(null, ex);
            }).Go();
        }


        public static void GetEnterCarList(string userid,APICallBack cb)
        {

          var req = Http.Post("https://api.jinjingzheng.zhongchebaolian.com/enterbj/platform/enterbj/entercarlist");
          req.Form(new {userid=userid,appkey="kkk",deviceid="ddd",
              timestamp =JinjingZhengAPIUtil.GetTimestamp(),
              token =JinjingZhengAPIUtil.CalcToken(),
              appsource = ""}).OnSuccess((str) => {
                cb?.Invoke(JObject.Parse(str));
            }).OnFail((ex) => {
                cb?.Invoke(null, ex);
            }).Go();
        }

    }
}
