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
    public class UserPageControllerController : Controller
    {
        IGenericService<ProductDTO, int> serviceProduct;
        IGenericService<PhotoDTO, int> servicePhoto;
        // GET: UserPageController
        public UserPageControllerController(IGenericService<ProductDTO, int> serviceProduct, IGenericService<PhotoDTO, int> servicePhoto)
        {
            this.serviceProduct = serviceProduct;
            this.servicePhoto = servicePhoto;
        }
        public ActionResult Index()
        {
            var model = new ViewModelProductView(serviceProduct,servicePhoto);
            return View(model);
        }
    }
}