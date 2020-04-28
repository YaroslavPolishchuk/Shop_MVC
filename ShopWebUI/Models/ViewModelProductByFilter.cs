using Shop.BLL.BizModels;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopWebUI.Models
{
    public class ProductInfo
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string PhotoPath { get; set; }        
    }
    public class ViewModelProductByFilter
    {
        IGenericService<ProductDTO, int> productService;
        IGenericService<PhotoDTO, int> photoService;
        ViewModelProductFind modelProductFind;
        public List<ProductInfo> ListProductInfo { get; private set; }
        public ViewModelProductByFilter(IGenericService<ProductDTO, int> productService,
            IGenericService<PhotoDTO, int> photoService,
            ViewModelProductFind modelProductFind)
        {
            this.productService = productService;
            this.photoService = photoService;
            this.modelProductFind = modelProductFind;
            ListProductInfo = new List<ProductInfo>();

            IEnumerable<ProductDTO> collection = productService.FindBy(modelProductFind.Predicate);

            foreach (var product in collection)
            {
                PhotoDTO photo = photoService.FindBy(p => p.ProductId == product.ProductId).FirstOrDefault();
                ProductInfo productInfo = new ProductInfo
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,                    
                    PhotoPath = (photo == null) ? "/img/noPhoto.png" : photo.PhotoPath
                };
                ListProductInfo.Add(productInfo);
            }
        }
    }
}