using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public class InterfaceBaseService<T> where T:class
    {
        T Add(T entity);
        bool Update(T entity);
        bool Delte(T entity);
    }
}
