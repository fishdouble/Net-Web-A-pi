using QWZE.JF.Extention;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace QWZE.JF.Extention
{
    public static class Log
    {
        private static object lockObj = new object();

        #region 保存日志
        public static void saveLog(this string emsg)
        {
            if (!string.IsNullOrEmpty(emsg))
            {
                writestr(KingdeeConfig.logPath, getyyyyMMdd(), emsg);
                // writeHelper.writestr(CsParam._serviceLogPath, writeHelper.getyyyyMMdd(), "不在执行时间区间; 可执行区间:" + SendAreaTimeList);
            }
        }
        /// <summary>
        /// 保存到自定义文件中
        /// </summary>
        /// <param name="emsg"></param>
        /// <param name="nameFlag"></param>
        public static void saveLogOther(this string emsg, string nameFlag = "")
        {
            if (!string.IsNullOrEmpty(emsg))
            {
                writestr(KingdeeConfig.logPath, getyyyyMMdd(nameFlag), emsg);
                // writeHelper.writestr(CsParam._serviceLogPath, writeHelper.getyyyyMMdd(), "不在执行时间区间; 可执行区间:" + SendAreaTimeList);
            }
        }

        public static void saveErrorLog(this string emsg)
        {
            if (!string.IsNullOrEmpty(emsg))
            {
                writestr(KingdeeConfig.logPath, getyyyyMMdd("_error"), emsg);
            }
        }


        public static void writestr(string path, string fileName, string content, bool append = true)
        {
            lock (lockObj)
            {
                string dir = (path + @"\" + fileName).GetDirPath();
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                string fileFullPath = path + "\\" + fileName;

                StreamWriter sw = new StreamWriter(fileFullPath, append);
                sw.Write("date:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " event:" + content);
                sw.WriteLine();
                sw.Close();

            }


        }

        public static string getyyyyMMdd(string nameAppStr = "")
        {
            return DateTime.Now.ToString("yyyyMMdd") + nameAppStr + ".txt";
        }

        public static string GetDirPath(this string dirPath)
        {
            int pos = dirPath.LastIndexOf('\\');
            return dirPath.Substring(0, pos);
        }
        /// <summary>
        /// 保存错误信息到日志文件中
        /// </summary>
        /// <returns></returns>
        public static string GetStackInfoAndSave(Exception ex, string appendError = "")
        {
            if (!string.IsNullOrEmpty(appendError))
            {
                appendError = " Error2=" + appendError;
            }

            lock (lockObj)
            {
                string tempStackTrace = ex.StackTrace;
                int pos = tempStackTrace.IndexOf("位置");
                if (pos > 1)
                {
                    tempStackTrace = tempStackTrace.Substring(pos);
                }

                string stackIndent = string.Format(" 1) 原因->{0} \r\n 2) 出错代码->{1} \r\n", ex.Message, tempStackTrace);
                WriteErrorLog(stackIndent + appendError);

                return stackIndent;
            }
        }
        /// <summary>
        /// 打印错误日志
        /// </summary>
        /// <param name="errorInfo"></param>
        public static void WriteErrorLog(string errorInfo)
        {
            string newErrorInfo = string.Format("{0} | {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"), errorInfo);
            string logFileName = DateTime.Now.ToString("yyyyMMdd") + "_error.log";
            if (!Directory.Exists(KingdeeConfig.logPath)) Directory.CreateDirectory(KingdeeConfig.logPath);

            WriteLog(KingdeeConfig.logPath + "\\" + logFileName, newErrorInfo);
        }
        private static void WriteLog(string logFilePath, string ErrorInfo, bool append = true)
        {
            lock (lockObj)
            {
                StreamWriter sw = new StreamWriter(logFilePath, append);
                sw.Write(ErrorInfo);
                sw.WriteLine();
                sw.Close();
            }
        }
        #endregion 保存日志
    }
}