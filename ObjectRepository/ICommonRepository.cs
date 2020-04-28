using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ObjectRepository
{
    public interface ICommonRepository<T, Tkey> where T :class, new()
    {
        IEnumerable<T> GetAllData();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T GetObjInstance(Tkey id);
        void AddOrUpdate(T obj);
        void Delete(Tkey id);
        void Save();
    }
}
