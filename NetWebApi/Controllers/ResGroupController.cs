using QWZE.JF.Extention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QWZE.JF.Models;

namespace QWZE.JF.Controllers
{
    [RoutePrefix("api/ResGroup")]
    public class ResGroupController : BaseController
    {
        public ResGroupController() : base(ScopeEnum.resGroupSecret)
        {

        }
    }
}
