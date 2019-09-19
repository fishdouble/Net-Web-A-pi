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
    }
}