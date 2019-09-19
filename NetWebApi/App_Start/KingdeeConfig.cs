using MultiBank.Extention;
using QWZE.JF.Extention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWZE.JF
{
    public class KingdeeConfig
    {
        public static string Eid { private set; get; }
        public static string AppID { private set; get; }
        public static string Secret { private set; get; }
        public static string Host { private set; get; }
        public static string logPath { private set; get; }
        public static string connStr { private set; get; }

        public static void Register()
        {
            Eid = DESEncrypt.Decrypt("Eid".Config());
            AppID = DESEncrypt.Decrypt("AppID".Config());
            Secret = DESEncrypt.Decrypt("Secret".Config());
            Host = "Host".Config();
            logPath = Environment.CurrentDirectory + "/log";
            connStr = "connStr".DbConfig();
        }
    }
}