using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class test<T> where T:class
    {
        public test()
        {
            UserService n = new UserService();
            n.Add(T);
        }
    }
}
