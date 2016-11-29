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
        public static void SendVerifyCode(string phone,string regist,APICallBack cb)
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
    }
}
