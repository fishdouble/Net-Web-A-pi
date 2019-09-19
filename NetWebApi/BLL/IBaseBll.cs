using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWZE.JF.BLL
{
    interface IBaseBll : IDependency
    {
        T GetData<T>() where T : class;

        bool EditData<T>(T TData) where T : class;

        bool AddData<T>(T TData) where T : class;

        bool DelData(int id);
    }
}
