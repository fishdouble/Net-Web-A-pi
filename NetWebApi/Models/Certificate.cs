using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWZE.JF.Models
{

    public class Certificate
    {
        /// <summary>
        /// 轻应用id
        /// </summary>
        public string appId { get; set; }
        /// <summary>
        /// 团队id
        /// </summary>
        public string eid { get; set; }

        /// <summary>
        /// Unix格式13位时间戳
        /// </summary>
        public long timestamp { get; set; }
        /// <summary>
        /// 授权级别：team
        /// </summary>
        public string scope { get; set; }

        /// <summary>
        /// 轻应用secret，即appsecret
        /// </summary>
        public string secret { get; set; }

        /// <summary>
        /// token刷新令牌
        /// </summary>
        public string refreshToken { get; set; }
    }
}