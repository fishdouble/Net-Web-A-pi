using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWZE.JF.Models
{
    public class TokenResponse
    {
        public int errorCode { get; set; }
        public bool success { get; set; }
        public TokenContent data { get; set; }
    }

    public class TokenContent
    {
        //[JsonProperty("access_token")]
        public string accessToken { get; set; }
        public int expireIn { get; set; }
        public string refreshToken { get; set; }
        public DateTime expireDate { get; set; }
    }
}