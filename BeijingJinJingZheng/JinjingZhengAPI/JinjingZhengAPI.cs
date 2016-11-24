using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JumpKick.HttpLib;
using JumpKick.HttpLib.Provider;
namespace JinjingZheng
{
    public class JinJingZhengAPI
    {
        public static void SendVerifyCode(string phone,string regist = "1")
        {
            var req = Http.Post("https://bjjj.zhongchebaolian.com/common_api/mobile/standard/verification");
            //req.Headers(HeaderProvider.)
            req.Body("{\"phone\":\"13621210918\",\"regist\":\"1\"}").OnSuccess((str) => {
                System.Diagnostics.Debug.WriteLine(str);
            }).OnFail((ex) => {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }).Go();
        }


    }
}
