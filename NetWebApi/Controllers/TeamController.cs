using QWZE.JF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QWZE.JF.Controllers
{
    [RoutePrefix("api/Team")]
    public class TeamController : BaseController
    {
        public TeamController() : base(ScopeEnum.team)
        {

        }

        [HttpGet]
        [Route("PersonIofo")]
        public TotalInfo GetPersonInfo()
        {
            TotalInfo total = new TotalInfo();
            total.MyWk = new WorkOrder() { Wk_Closed = 5, Wk_NotPay = 4, Wk_Processing = 17, Wk_Totoal = 22 };
            total.PersonInfo = new PersonInfo() { id = 1, HasTeam = true };
            total.TeamWk = new WorkOrder() { Wk_Closed = 10, Wk_Totoal = 30, Wk_Processing = 20, Wk_NotPay = 7 };
            total.OrgList = new List<Organization>() {
                new Organization(){ OrgId="0", OrgName="神龙教"},
                new Organization(){ OrgId="1", OrgName="玉女教"},
                new Organization(){ OrgId="2", OrgName="佛教"},
                new Organization(){ OrgId="3", OrgName="光明顶"}
            };
            return total;
        }
    }
}
