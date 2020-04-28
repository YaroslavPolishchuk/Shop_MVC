using Shop.BLL.BizModels;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopWebUI.Models
{
    public class ViewModelProductDefault
    {
        IGenericService<ProductDTO, int> productService;
        IGenericService<PhotoDTO, int> photoService;
        public List<ProductInfo> ListProductInfo { get; private set; }
        public ViewModelProductDefault(IGenericService<ProductDTO, int> productService,IGenericService<PhotoDTO, int> photoService)
        {
            this.productService = productService;
            this.photoService = photoService;
            IEnumerable<ProductDTO> products = productService.GetAllData();
            ListProductInfo = new List<ProductInfo>();
            foreach (var item in products)
            {
                PhotoDTO photo = photoService.FindBy(p => p.ProductId == item.ProductId).FirstOrDefault();
                ProductInfo info = new ProductInfo
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    PhotoPath = (photo == null) ? "/img/noPhoto.png" : photo.PhotoPath
                };
                ListProductInfo.Add(info);
            }
        }
       
    }
}