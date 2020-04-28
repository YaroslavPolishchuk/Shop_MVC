using Autofac;
using ObjectRepository;
using Shop.BLL.BizModels;
using Shop.BLL.Services;
using Shop.DAL.DbLayer;
using Shop.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Modules
{
    public class ServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(CategoryService)).As(typeof(IGenericService<CategoryDTO, int>));
            builder.RegisterType(typeof(CategoryRepository)).As(typeof(ICommonRepository<Category, int>));

            builder.RegisterType(typeof(ProductService)).As(typeof(IGenericService<ProductDTO, int>));
            builder.RegisterType(typeof(ProductRepository)).As(typeof(ICommonRepository<Product, int>));

            builder.RegisterType(typeof(ManufacturerService)).As(typeof(IGenericService<ManufacturerDTO, int>));
            builder.RegisterType(typeof(ManufacturerRepository)).As(typeof(ICommonRepository<Manufacturer, int>));

            builder.RegisterType(typeof(PhotoService)).As(typeof(IGenericService<PhotoDTO, int>));
            builder.RegisterType(typeof(PhotoRepository)).As(typeof(ICommonRepository<Photo, int>));

            builder.RegisterType(typeof(SaleService)).As(typeof(IGenericService<SaleDTO, int>));
            builder.RegisterType(typeof(SaleRepository)).As(typeof(ICommonRepository<Sale, int>));

            builder.RegisterType(typeof(SalePosService)).As(typeof(IGenericService<SalePosDTO, int>));
            builder.RegisterType(typeof(SalePosRepository)).As(typeof(ICommonRepository<SalePos, int>));

            builder.RegisterType(typeof(UnitOfWorkSale)).As(typeof(IUnitOfWorkSale));

            builder.RegisterType(typeof(ShopContext)).As(typeof(DbContext));
        }
    }
}
