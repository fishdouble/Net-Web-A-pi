using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace QWZE.JF.Extention
{
    public static class ExtMethodHelper
    {
        public static string ToMD5(this string _key)
        {
            if (string.IsNullOrEmpty(_key)) return _key;

            MD5 md5 = MD5.Create();

            byte[] bufstr = Encoding.GetEncoding("GBK").GetBytes(_key);

            byte[] hashstr = md5.ComputeHash(bufstr);

            string md5Str = string.Empty;

            for (int i = 0; i < hashstr.Length; i++)
            {
                md5Str += hashstr[i].ToString("X");
            }

            return md5Str;
        }
        public static string Config(this string _key)
        {
            return ConfigurationManager.AppSettings[_key].ToString();
        }
        public static string DbConfig(this string _key)
        {
            return ConfigurationManager.ConnectionStrings[_key].ConnectionString;
        }
        public static string To24hStr(this DateTime _key)
        {
            return _key.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public static int ToInt(this string str)
        {
            try
            {
                return Convert.ToInt32(str);

            }
            catch (Exception ex)
            {
                Log.GetStackInfoAndSave(ex);
                return 0;

            }
        }
    }
}