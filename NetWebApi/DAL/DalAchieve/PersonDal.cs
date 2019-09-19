using QWZE.JF.BLL;
using QWZE.JF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWZE.JF.DAL
{
    public class PersonDal : BaseDal, ITest
    {
        public PersonDal() : base(TableEnum.PersonInfo)
        {

        }

        public T GetData<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }
    }
}