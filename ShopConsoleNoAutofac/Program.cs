using Shop.BLL.Services;
using Shop.DAL.DbLayer;
using Shop.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopConsoleNoAutofac
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryService service = new CategoryService(new CategoryRepository(new ShopContext()));
            CategoryRepository repo = new CategoryRepository(new ShopContext());
            var collect = repo.GetAllData();
            var collection = service.GetAllData();
            foreach (var item in collect)
            {
                Console.WriteLine(item.CategoryName);
            }
        }
    }
}
