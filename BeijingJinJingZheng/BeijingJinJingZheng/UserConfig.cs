using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;

namespace BeijingJinJingZheng
{
    public class UserConfig
    {
        public string UserID;
        public string DriverName;
        public string PersonPhoto;
        public string DriverPhoto;
        public string CarPhoto;
        public string DrivingPhoto;
        public string VehicleType;
        public string CarTypeCode;
        public int InbjDuration;
        public string DriverLicenseno;
        public int Interval;
        // 开机自动启动
        public bool RunOnSystemStartup;
        // 启动时自动运行
        public bool ActAsStartup;
        //启动时自动最小化到托盘
        public bool AutoHide;

        // 开启邮件通知
        public bool EnableMail;
        public string UserMailID;
        public string UserMailPassword;
        public string ToMail;
        public string CarModel;
        public string CarRegTime;

        public static UserConfig FormFile(string path)
        {
            try {
                string json = File.ReadAllText(path);
                var config = JsonConvert.DeserializeObject<UserConfig>(json);
                if (!string.IsNullOrEmpty(config.UserMailPassword)) {
                    config.UserMailPassword = Decrypt(config.UserMailPassword);
                }
                
                return config;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                
            }

            return new UserConfig();
        }

        public void Save(string path)
        {
            try {
                if (!string.IsNullOrEmpty(this.UserMailPassword)) {
                    this.UserMailPassword = Encrypt(this.UserMailPassword);
                }
                
                string json = JsonConvert.SerializeObject(this);
                File.WriteAllText(path, json);
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
            }

        }


        static string encryptKey = "Oyea";    //定义密钥  

        #region 加密字符串  
        /// <summary> /// 加密字符串   
        /// </summary>  
        /// <param name="str">要加密的字符串</param>  
        /// <returns>加密后的字符串</returns>  
        static string Encrypt(string str)
        {

            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象   

            byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥    

            byte[] data = Encoding.Unicode.GetBytes(str);//定义字节数组，用来存储要加密的字符串  

            MemoryStream MStream = new MemoryStream(); //实例化内存流对象      

            //使用内存流实例化加密流对象   
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);

            CStream.Write(data, 0, data.Length);  //向加密流中写入数据      

            CStream.FlushFinalBlock();              //释放加密流      

            return Convert.ToBase64String(MStream.ToArray());//返回加密后的字符串  
        }
        #endregion

        #region 解密字符串   
        /// <summary>  
        /// 解密字符串   
        /// </summary>  
        /// <param name="str">要解密的字符串</param>  
        /// <returns>解密后的字符串</returns>  
        static string Decrypt(string str)
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象    

            byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥    

            byte[] data = Convert.FromBase64String(str);//定义字节数组，用来存储要解密的字符串  

            MemoryStream MStream = new MemoryStream(); //实例化内存流对象      

            //使用内存流实例化解密流对象       
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);

            CStream.Write(data, 0, data.Length);      //向解密流中写入数据     

            CStream.FlushFinalBlock();               //释放解密流      

            return Encoding.Unicode.GetString(MStream.ToArray());       //返回解密后的字符串  
        }
        #endregion

    }
}
