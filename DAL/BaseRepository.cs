using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using System.Linq.Expressions;

namespace DAL
{
    public class BaseRepository<T>: InterfaceBaseRepository<T> where T:class
    {
        public EnterpriseDbContent dbContext = ContextFactory.GetCurrentContext();
        public T Add(T entity)
        {
            dbContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Added;
            dbContext.SaveChanges();
            return entity;

        }
        public bool Update(T entity)
        {
            dbContext.Set<T>().Attach(entity);
            dbContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return dbContext.SaveChanges()>0;
        }
        public bool Delete(T entity)
        {
            dbContext.Set<T>().Attach(entity);
            dbContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            return dbContext.SaveChanges() > 0;
        }
        public int Count(Expression<Func<T,bool>> predicate)
        {
           return   dbContext.Set<T>().Count(predicate);
        }
        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            return dbContext.Set<T>().Any(anyLambda);
        }
        public T Find(Expression<Func<T,bool>> whereLambda)
        {
            T _entity=dbContext.Set<T>().FirstOrDefault<T>(whereLambda);
            return _entity;
        }
        public IQueryable<T> FindList<S>(Expression<Func<T,bool>> whereLambda,bool isAsc,Expression<Func<T,S>> orderLambda)
        
        {
            var _list = dbContext.Set<T>().Where<T>(whereLambda);
            if (isAsc) _list = _list.OrderBy<T, S>(orderLambda);
            else _list = _list.OrderByDescending<T, S>(orderLambda);
            return _list;
        }

        public IQueryable<T> FindPageList<S>(int pageIndex,int pageSize,out int total,Expression<Func<T,bool>> whereLambda,bool isAsc,Expression<Func<T,S>> orderLambda) {
            var _list = dbContext.Set<T>().Where<T>(whereLambda);
            total = _list.Count();
            if (isAsc) _list = _list.OrderBy<T, S>(orderLambda).Skip<T>((pageIndex-1)*pageSize).Take<T>(pageSize);
            else _list = _list.OrderByDescending<T, S>(orderLambda).Skip<T>((pageIndex-1)*pageSize).Take<T>(pageSize);
            return _list;
        }

    }
}
