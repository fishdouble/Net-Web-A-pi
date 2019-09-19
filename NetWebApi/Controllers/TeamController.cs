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
    }
}
