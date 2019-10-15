using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWZE.JF.Models
{
    /// <summary>
    /// 组织类
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// 组织ID
        /// </summary>
        [JsonProperty("value")]
        public string OrgId { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>
        [JsonProperty("text")]
        public string OrgName { get; set; }
    }
}