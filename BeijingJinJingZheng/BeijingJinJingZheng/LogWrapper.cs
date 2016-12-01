using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BeijingJinJingZheng
{


    public enum LogLevel
    {
        Info,
        Warning,
        Error
    }

    public class LogWrapper
    {

        public static Action<LogLevel, string> OnRecvLog;


        

        public static void LogInfo(string info)
        {
            WriteLog(LogLevel.Info, info);
        }
        public static void LogError(string info)
        {
            WriteLog(LogLevel.Error, info);
        }

        public static void LogWarning(string info)
        {
            WriteLog(LogLevel.Warning, info);
        }



        private static BinaryWriter logFileWriter = null;

        private static void WriteLog(LogLevel lv,string info)
        {
            string log = string.Format("{0} [{1}]:{2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                lv.ToString(),info);
            System.Diagnostics.Debug.WriteLine(log);

            if (logFileWriter == null) {
                string logPath = "./" +DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".log";
                FileStream fs = File.Open(logPath, FileMode.OpenOrCreate);
                logFileWriter = new BinaryWriter(fs);
            }
            logFileWriter.Write(log+"\r\n");
            logFileWriter.Flush();
            OnRecvLog?.Invoke(lv,info);
        }
    }
}
