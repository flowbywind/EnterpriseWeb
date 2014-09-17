using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace IDAL
{
    public interface InterfaceBaseRepository<T> 
    {
        T Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        int Count(Expression<Func<T, bool>> predicate);
        T Find(Expression<Func<T,bool>> whereLambda);
        IQueryable<T> FindList<S>(Expression<Func<T,bool>> whereLambda,bool isAsc,Expression<Func<T,S>> orderLambda);
        IQueryable<T> FindPageList<S>(int pageIndex,int pageSize,out int total,Expression<Func<T,bool>> whereLambda,bool isAsc,Expression<Func<T,S>> orderLambda );

    }
}
