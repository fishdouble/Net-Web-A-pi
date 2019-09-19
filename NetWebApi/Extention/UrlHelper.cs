using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWZE.JF.Extention
{
    public class UrlHelper
    {
        public static string SpliceUrl(string url, Dictionary<string, string> dic)
        {
            bool hasChar = url.Contains("?");
            string parameterStr = string.Empty;
            foreach (var item in dic)
            {
                parameterStr += (item.Key + "=" + item.Value + "&");
            }

            return string.Format("{0}{1}{2}", url, hasChar ? "" : "?", parameterStr);
        }
    }
}