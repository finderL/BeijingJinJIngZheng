using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        public static string Image2Base64(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);     
            byte[] data = ms.GetBuffer();
            string b64 = Convert.ToBase64String(data);
            b64 = b64.Replace("/", "%252F");
            b64 = b64.Replace("+", "%%52B");
            b64 = b64.Replace("=", "%253D");
            return b64;
        }
    }
}
