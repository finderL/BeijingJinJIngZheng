using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinjingZheng
{
    public class JinjingZhengAPIUtil
    {

        public static string CalcToken(string userid="",string timestamp="", string appkey= "kkk", string deviceid="ddd")
        {
            return "13165ffa4e0890ac09f";
        }

        public static string GetTimestamp()
        {
            return ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();
        }
    }
}
