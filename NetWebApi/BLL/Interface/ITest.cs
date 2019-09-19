using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWZE.JF.BLL
{
    interface ITest : IBaseBll
    {
        T GetData<T>(int id) where T : class;
    }
}
