//using Shop.BLL.BizModels;
//using Shop.BLL.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace ShopWebUI.Models
//{
//    public class CartExt
//    {
//        public Cart cart { get; set; }
//        public string ProductName { get; set; }
//        public decimal Price { get; set; }
//        public decimal Sum { get; set; }
//    }
//    public class ViewModelCart
//    {
//        UserCart userCart;
//        IGenericService<ProductDTO, int> productService;
//        public List<CartExt> MyCartExt { get; set; }
//        public ViewModelCart(IGenericService<ProductDTO, int> productService,UserCart userCart)
//        {
//            this.userCart = userCart;
//            this.productService = productService;
//            MyCartExt = new List<CartExt>();
//            foreach (var cart in userCart.Carts)
//            {
//                ProductDTO good = productService.GetObjInstance(cart.ProductId);
//                CartExt cartExt = new CartExt
//                {
//                    cart = cart,
//                    ProductName = good.ProductName,
//                    Price = good.Price,
//                    Sum = good.Price * cart.ProductCount
//                };
//                MyCartExt.Add(cartExt);
//            }
//        }
//    }
//}