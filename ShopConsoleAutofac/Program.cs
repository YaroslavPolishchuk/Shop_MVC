using Autofac;
using Shop.BLL.BizModels;
using Shop.BLL.Modules;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopConsoleAutofac
{
    class Program
    {
        static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ServiceModule>();
            return builder.Build();
        }
        static void Main(string[] args)
        {
            IGenericService<CategoryDTO,int> service = null;
            
            var container = BuildContainer();
            service = container.Resolve<IGenericService<CategoryDTO, int>>();
            var collection = service.GetAllData();
            foreach (var item in collection)
            {
                Console.WriteLine(item.CategoryName);
            }
        }
    }
}
