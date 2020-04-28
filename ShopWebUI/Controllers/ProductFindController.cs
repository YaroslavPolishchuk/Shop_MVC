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
    public class ProductFindController : Controller
    {
        IGenericService<CategoryDTO, int> categoryService;
        IGenericService<ManufacturerDTO, int> manufacturerService;
        IGenericService<ProductDTO, int> productService;
        IGenericService<PhotoDTO, int> photoService;


        public ProductFindController(IGenericService<CategoryDTO, int> categoryService,
                  IGenericService<ManufacturerDTO, int> manufacturerService,
                  IGenericService<ProductDTO, int> productService,
                  IGenericService<PhotoDTO, int> photoService)
        {
            this.categoryService = categoryService;
            this.manufacturerService = manufacturerService;
            this.productService = productService;
            this.photoService = photoService;
        }
        // GET: ProductFind
        public ActionResult Index()
        {
            ViewModelProductFind model = new ViewModelProductFind(categoryService, manufacturerService);            
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(ViewModelProductFind viewModel)
        {
            TempData["dataModel"] = viewModel;
            return Json("OK");
            //ViewModelProductFind model = new ViewModelProductFind(categoryService, manufacturerService);
            
        }
        public ActionResult ProductByFilter()
        {
            ViewModelProductFind filter = null;
            if(TempData["dataModel"]!=null)
            {
                filter = (ViewModelProductFind)TempData["dataModel"];
            }
            ViewModelProductByFilter model = new ViewModelProductByFilter(productService, photoService, filter);
            return PartialView(model);
        }
        public ActionResult ProductDefault()
        {
            var model = new ViewModelProductDefault(productService, photoService);
            return PartialView(model);
        }
    }
}