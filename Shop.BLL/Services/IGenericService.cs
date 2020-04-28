using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public interface IGenericService<T, Tkey> where T:class,new()
    {
        IEnumerable<T> GetAllData();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T GetObjInstance(Tkey id);
        T Add(T obj);
        T Update(T obj);
        T Delete(Tkey id);        
    }
}
