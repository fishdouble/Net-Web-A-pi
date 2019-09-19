using QWZE.JF.BLL;
using QWZE.JF.Extention;
using QWZE.JF.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace QWZE.JF.DAL
{
    public class BaseDal : IBaseBll
    {
        protected string _tableName;

        public BaseDal(TableEnum tableName)
        {
            this._tableName = tableName.ToString();
        }

        public bool AddData<T>(T TData) where T : class
        {
            //这里用反射来实现添加数据
            if (TData == null) return false;
            string url = string.Empty, para = string.Empty, values = string.Empty;

            PropertyInfo[] properties = TData.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            if (properties.Length <= 0) return false;
            List<SqlParameter> sqlParas = new List<SqlParameter>();
            foreach (PropertyInfo item in properties)
            {
                string name = item.Name;
                object value = item.GetValue(TData, null);
                object[] Attributes = item.GetCustomAttributes(typeof(IgnoreFieldAttribute),false);
                if (Attributes.Length > 0) continue;
                para += name + ",";
                values += string.Format("@{0},", name);
                sqlParas.Add(new SqlParameter(string.Format("@{0}", name), value));
            }

            url = string.Format("insert into {0} ({1}) values ({2})", _tableName, para.TrimEnd(','), values.TrimEnd(','));
            return SqlHelper.ExcuteNonQuery(url, sqlParas.ToArray()) > 0;
        }

        public bool DelData(int id)
        {
            throw new NotImplementedException();
        }

        public bool EditData<T>(T TData) where T : class
        {
            throw new NotImplementedException();
        }

        public T GetData<T>() where T : class
        {
            throw new NotImplementedException();
        }
    }
}