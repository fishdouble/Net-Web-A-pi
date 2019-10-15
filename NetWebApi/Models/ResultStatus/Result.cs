using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWZE.JF.Models
{
    public class Result
    {
        ResultStatus _status = ResultStatus.OK;
        public Result()
        {
        }
        public Result(ResultStatus status)
        {
            this._status = status;
        }

        public Result(ResultStatus status, string msg)
        {
            this.Status = status;
            this.Msg = msg;
        }

        [JsonProperty("errorCode")]
        public ResultStatus Status { get { return this._status; } set { this._status = value; } }
        [JsonProperty("error")]
        public string Msg { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }

        public static Result CreateResult(string msg = null)
        {
            Result result = CreateResult(ResultStatus.OK, msg);
            return result;
        }
        public static Result CreateResult(ResultStatus status, string msg = null)
        {
            Result result = new Result(status);
            result.Msg = msg;
            return result;
        }

        public static Result<T> CreateResult<T>(T data)
        {
            Result<T> result = CreateResult<T>(ResultStatus.OK, data);
            return result;
        }
        public static Result<T> CreateResult<T>(ResultStatus status)
        {
            Result<T> result = CreateResult<T>(status, default(T));
            return result;
        }
        public static Result<T> CreateResult<T>(ResultStatus status, T data)
        {
            Result<T> result = new Result<T>(status);
            result.Data = data;
            return result;
        }

    }


    public class Result<T> : Result
    {
        public Result()
        {
        }
        public Result(ResultStatus status)
            : base(status)
        {
        }
        public Result(ResultStatus status, T data)
            : base(status)
        {
            this.Data = data;
        }
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}