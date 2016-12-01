using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace JinjingZheng
{
    public class Utils
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
            b64 = b64.Replace("+", "%252B");
            b64 = b64.Replace("=", "%253D");
            return b64;
        }


        /// <summary>
        /// Serialize an array of Key-Value pairs into a URL encoded query string
        /// </summary>
        /// <param name="Parameters">The key-value pair array</param>
        /// <returns>The URL encoded query string</returns>
        public static string SerializeQueryString(object Parameters)
        {
            string querystring = "";
            int i = 0;
            try {

                PropertyInfo[] properties;
#if NETFX_CORE
                properties = Parameters.GetType().GetTypeInfo().DeclaredProperties.ToArray();
#else
                properties = Parameters.GetType().GetProperties();
#endif



                foreach (var property in properties) {
                    querystring += property.Name + "=" + System.Uri.EscapeDataString(property.GetValue(Parameters, null).ToString());

                    if (++i < properties.Length) {
                        querystring += "&";
                    }
                }



            } catch (NullReferenceException e) {
                throw new ArgumentNullException("Paramters cannot be a null object", e);
            }

            return querystring;
        }
    }
}
