using QWZE.JF.Extention;
using QWZE.JF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace QWZE.JF.Controllers
{
    public class BaseController : ApiController
    {
        protected Authentication _Authentication;

        public BaseController(ScopeEnum scope)
        {
            _Authentication = new Authentication(scope);
        }

        #region 返回值方法
        private Result SuccessMsg(object data, string msg = null)
        {
            if (data == null)
            {
                Result result = new Result(ResultStatus.OK, msg);
                return result;
            }
            Result<object> resultObject = Result.CreateResult<object>(ResultStatus.OK, data);
            resultObject.Msg = msg;
            return resultObject;
        }
        protected Result AddSuccessData(object data = null, string msg = "添加成功")
        {
            return this.SuccessMsg(data, msg);
        }
        protected Result AddSuccessMsg(object data = null, string msg = "添加成功")
        {
            return this.SuccessMsg(data, msg);
        }
        protected Result UpdateSuccessMsg(object data = null, string msg = "更新成功")
        {
            return this.SuccessMsg(data, msg);
        }
        protected Result DeleteSuccessMsg(object data = null, string msg = "删除成功")
        {
            return this.SuccessMsg(data, msg);
        }
        protected Result FailedMsg(string msg = null)
        {
            Result retResult = new Result(ResultStatus.Failed, msg);
            return retResult;
        }
        #endregion
    }
}