using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWZE.JF.Models
{
    /// <summary>
    /// 工单
    /// </summary>
    public class WorkOrder
    {
        /// <summary>
        /// 工单总数
        /// </summary>
        public int Wk_Totoal { get; set; }

        /// <summary>
        /// 工单已关闭
        /// </summary>
        public int Wk_Closed { get; set; }

        /// <summary>
        /// 工单进行中
        /// </summary>
        public int Wk_Processing { get; set; }

        /// <summary>
        /// 工单未报销
        /// </summary>
        public int Wk_NotPay { get; set; }
    }
}