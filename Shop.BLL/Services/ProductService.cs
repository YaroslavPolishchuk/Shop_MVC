using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using ObjectRepository;
using Shop.BLL.BizModels;
using Shop.DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public class ProductService : GenericService<Product, ProductDTO, int>
    {
        public ProductService(ICommonRepository<Product,int> repository):base(repository)
        {

        }
        public override IMapper GetMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Product, ProductDTO>()
                                        .ForMember("CategoryName", opt => opt.MapFrom(p => p.Category.CategoryName))
                                        .ForMember("ManufacturerName", opt => opt.MapFrom(p => p.Manufacturer.ManufacturerName));
                cfg.CreateMap<ProductDTO, Product>();
            }).CreateMapper();
        }
    }
    //    ICommonRepository<Product, int> repository;
    //    private readonly IMapper _mapper;
    //    public ProductService(ICommonRepository<Product, int> repository)
    //    {
    //        this.repository = repository;
    //        _mapper = new MapperConfiguration(cfg =>
    //        {
    //            //cfg.AddExpressionMapping();
    //            cfg.CreateMap<Product, ProductDTO>()
    //            .ForMember("CategoryName", opt => opt.MapFrom(p => p.Category.CategoryName))
    //            .ForMember("ManufactirerName", opt => opt.MapFrom(m => m.Manufacturer.ManufacturerName));
    //            cfg.CreateMap<ManufacturerDTO, Product>();
    //        }).CreateMapper();
    //    }
    //    public ProductDTO Add(ProductDTO obj)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public ProductDTO Delete(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<ProductDTO> FindBy(Expression<Func<ProductDTO, bool>> predicate)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<ProductDTO> GetAllData()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public ProductDTO GetObjInstance(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public ProductDTO Update(ProductDTO obj)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
