using AutoMapper;
using Shop.BLL.BizModels;
using ShopWebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.BLL.Services.ViewModelsServices
{

    public class ProductWithPhotoViewModelService : IProductWithPhotoViewModelService
    {
        private IGenericService<ProductDTO, int> serviceProducts;
        private IGenericService<PhotoDTO, int> servicePhotos;
        IMapper _mapper;

        public ProductWithPhotoViewModelService(IGenericService<ProductDTO, int> serviceProducts, IGenericService<PhotoDTO, int> servicePhotos)
        {
            this.serviceProducts = serviceProducts;
            this.servicePhotos = servicePhotos;
            _mapper = GetMapper();
        }
        public IEnumerable<ViewModelProductWithPhoto> GetAllProducts()
        {
            List<ViewModelProductWithPhoto> collection = serviceProducts.GetAllData().Select(e => _mapper.Map<ViewModelProductWithPhoto>(e)).ToList();
            List<PhotoDTO> pics = servicePhotos.GetAllData().ToList();
            foreach (var item in collection)
            {
                item.photos = from p in pics
                              where p.ProductId == item.ProductId
                              select p;
            }
            return collection;

        }
        private IMapper GetMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, ViewModelProductWithPhoto>();                
            }).CreateMapper();
        }
    }
}
