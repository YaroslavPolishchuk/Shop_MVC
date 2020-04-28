using Shop.BLL.BizModels;
using Shop.BLL.Services;
using ShopWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopWebUI.Controllers
{
    public class CartController : Controller
    {
        IGenericService<ProductDTO, int> serviceProduct;
        public CartController(IGenericService<ProductDTO, int> serviceProduct)
        {
            this.serviceProduct = serviceProduct;
        }
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public RedirectToRouteResult AddToCart(int id, string returnUrl)
        {
            ProductDTO _product = serviceProduct.GetObjInstance(id);
            if (_product != null)
            {
                GetCart().AddItem(_product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        [HttpPost]
        public ActionResult RemoveFromCart(int id, string returnUrl)
        {
            try
            {
                GetCart().DeleteEntity(id);
                return Json("Ok");
            }
            catch
            {
                return Json("Bad");
            }
            
        }
        public ActionResult ShowCart()
        {
            Cart cart = GetCart();
            IEnumerable<CartEntity> products = cart.productList;
            return View(cart);
        }
        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}