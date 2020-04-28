using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ObjectRepository
{
    public abstract class CommonRepository<T,Tkey>: ICommonRepository<T, Tkey> where T : class, new()
    {
        DbContext context;
        IDbSet<T> dbSet;
        public CommonRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public void AddOrUpdate(T obj)
        {
            dbSet.AddOrUpdate(obj);
        }

        public void Delete(Tkey id)
        {
            T obj = GetObjInstance(id);
            dbSet.Remove(obj);
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public IEnumerable<T> GetAllData()
        {
            return dbSet;
        }

        public T GetObjInstance(Tkey id)
        {
            return dbSet.Find(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
