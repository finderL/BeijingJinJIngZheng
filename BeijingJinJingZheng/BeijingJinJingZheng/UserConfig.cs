using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
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


        public static UserConfig FormFile(string path)
        {
            try
            {
                string json = File.ReadAllText(path);
                var config = JsonConvert.DeserializeObject<UserConfig>(json);
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
            try
            {
                string json = JsonConvert.SerializeObject(this);
                File.WriteAllText(path, json);
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
            }

        }

    }
}
