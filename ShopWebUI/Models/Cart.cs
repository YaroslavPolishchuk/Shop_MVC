using Shop.BLL.BizModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopWebUI.Models
{
    public class CartEntity
    {
        public ProductDTO Product { get; set; }
        public int Qty { get; set; }
    }
    public class Cart
    {
        public List<CartEntity> productList = new List<CartEntity>();
        public void AddItem(ProductDTO product)
        {
            CartEntity entity = productList.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();
            if (entity == null)
            {
                productList.Add(new CartEntity { Product = product, Qty = 1 });
            }
            else
            {
                entity.Qty += 1;
            }
        }
        public void DeleteEntity(int id)
        {
            productList.RemoveAll(item => item.Product.ProductId == id);
        }
        public void ClearAll()
        {
            productList.Clear();
        }
        public decimal TotalSumPerEntity()
        {
            return productList.Sum(e => e.Product.Price * e.Qty);
        }

    }
}