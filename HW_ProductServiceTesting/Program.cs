using Shop.BLL.Services;
using Shop.DAL.DbLayer;
using Shop.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_ProductServiceTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService service = new ProductService(new ProductRepository(new ShopContext()));
            var collection = service.GetAllData();

            foreach (var item in collection)
            {
                Console.WriteLine(item.ProductName);
                Console.WriteLine(item.ManufacturerName);
            }
            
        }
    }
}
