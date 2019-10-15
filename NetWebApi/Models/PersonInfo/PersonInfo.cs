using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWZE.JF.Models
{
    public class PersonInfo
    {
        [IgnoreField]
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string phone { get; set; }
        public DateTime insertTime { get; set; }

        /// <summary>
        /// 是否拥有团队
        /// </summary>
        public bool HasTeam { get; set; }
    }


    /// <summary>
    /// 所有信息
    /// </summary>
    public class TotalInfo
    {
        /// <summary>
        /// 个人信息
        /// </summary>
        public PersonInfo PersonInfo { get; set; }

        /// <summary>
        /// 我的工单
        /// </summary>
        public WorkOrder MyWk { get; set; }

        /// <summary>
        /// 组织列表
        /// </summary>
        public List<Organization> OrgList { get; set; }

        /// <summary>
        /// 团队工单
        /// </summary>
        public WorkOrder TeamWk { get; set; }
    }
}