using QWZE.JF.DAL;
using QWZE.JF.Extention;
using QWZE.JF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace QWZE.JF.Controllers
{
    [RoutePrefix("api/App")]
    public class AppController : BaseController
    {
        private PersonDal _personDal;
        public AppController(PersonDal _personDal) : base(ScopeEnum.app)
        {
            this._personDal = _personDal;
        }

        /// <summary>
        /// 获取全部人员
        /// </summary>
        /// <returns>人员列表</returns>
        [HttpGet]
        [Route("Allpersons")]
        public async Task<List<PersonInfo>> getallpersons()
        {
            //string url = "/gateway/opendata-control/data/getallpersons?accessToken=" + await _Authentication.GetCorrectToken();
            //var parameters = new Dictionary<string, string>();
            //parameters.Add("eid", KingdeeConfig.Eid);
            //parameters.Add("time", DateTime.Now.To24hStr());
            //return await _Authentication.CallHttpPost<YunModel<object>>(url, parameters);
            PersonInfo data = new PersonInfo()
            {
                age = 100,
                insertTime = DateTime.Now,
                name = "我爱你傻瓜",
                phone = "520"
            };
            _personDal.AddData(data);
            return null;
        }
    }
}
