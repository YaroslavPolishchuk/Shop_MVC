using Autofac;
using Shop.BLL.BizModels;
using Shop.BLL.Modules;
using Shop.BLL.Services;
using Shop.TestUnitOfWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Shop.TestUnitOfWork
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
            var container = BuildContainer();
            IUnitOfWorkSale unitOfWork = container.Resolve<IUnitOfWorkSale>();
            List<Cart> carts = new List<Cart>()
            {
                new Cart{ProductId=2,ProductCount=1},
                new Cart{ProductId=4,ProductCount=2},
                new Cart{ProductId=10,ProductCount=1},
            };

            using(unitOfWork.Transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    SaleDTO sale = new SaleDTO
                    {
                        UserId = 1,
                        SaleDate = DateTime.Now
                    };
                    var s = unitOfWork.saleService.Add(sale);
                    foreach (var item in carts)
                    {
                        ProductDTO product = unitOfWork.productService.GetObjInstance(item.ProductId);
                        product.ProductCount -= item.ProductCount;
                        unitOfWork.productService.Update(product);
                        unitOfWork.salePosService.Add(new SalePosDTO
                        {
                            SaleId = s.SaleId,
                            ProductId = item.ProductId,
                            ProductCount = (int)item.ProductCount,
                            UnitPrice = product.Price
                        });
                    }
                    unitOfWork.Save();
                    Console.WriteLine("OK");
                    Console.ReadKey();
                }
                catch
                {

                }
            }
        }
    }
}
