using Shop.BLL.BizModels;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopWebUI.Models
{
    public class ViewModelProductView
    {
        IGenericService<ProductDTO, int> serviceProduct;
        IGenericService<PhotoDTO, int> servicePhoto;
        public List<ProductView> productViews { get; private set; }
        public ViewModelProductView(IGenericService<ProductDTO, int> serviceProduct,
        IGenericService<PhotoDTO, int> servicePhoto)
        {
            this.serviceProduct = serviceProduct;
            this.servicePhoto = servicePhoto;
            productViews = new List<ProductView>();
            var products = serviceProduct.GetAllData();
            foreach (var p in products)
            {
                var photo = servicePhoto.FindBy(pr => pr.ProductId == p.ProductId).FirstOrDefault();
                string path = photo == null ? "/img/nophoto.png" : photo.PhotoPath;
                ProductView productView = new ProductView()
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    PhotoPath = path
                };
                productViews.Add(productView);
            }
        }

    }
}