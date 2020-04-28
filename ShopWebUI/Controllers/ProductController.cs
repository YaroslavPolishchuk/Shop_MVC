using Shop.BLL.BizModels;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace ShopWebUI.Controllers
{
    public class ProductController : Controller
    {
        IGenericService<ProductDTO, int> service;
        IGenericService<ManufacturerDTO, int> serviceManufacturer;
        IGenericService<CategoryDTO, int> serviceCategory;
        public ProductController(IGenericService<ProductDTO, int> service,
            IGenericService<ManufacturerDTO, int> serviceManufacturer,
            IGenericService<CategoryDTO, int> serviceCategory)
        {
            this.service = service;
            this.serviceManufacturer = serviceManufacturer;
            this.serviceCategory = serviceCategory;
        }        
        // GET: Product
        public ActionResult Index()
        {
            var model = service.GetAllData();
            return View(model);
        }
        
        public ActionResult Create()
        {
            ProductDTO product = new ProductDTO
            {
                ProductId = 0,
                ProductName = "ProductName",
                Price = 0,
                ProductCount = 0,
                CategoryId = 0,
                CategoryName = "",
                ManufacturerId = 0,
                ManufacturerName = ""
            };
            ViewBag.ManufacturerId = new SelectList(serviceManufacturer.GetAllData(), "ManufacturerId", "ManufacturerName",product.ManufacturerId);
            ViewBag.CategoryId = new SelectList(serviceCategory.GetAllData(), "CategoryId", "CategoryName",product.CategoryId);
            return View(product);
        }
        [HttpPost]
        public ActionResult Create([FromBody]ProductDTO prod)
        {
            if (ModelState.IsValid)
            {
                service.Add(prod);
                return RedirectToAction("Index");                
            }
            return View(prod);
        }
        public ActionResult Edit(int id)
        {
            var model = service.GetObjInstance(id);
            ViewBag.ManufacturerId = new SelectList(GetManufacturers(), "ManufacturerId", "ManufacturerName", model.ManufacturerId);
            ViewBag.CategoryId = new SelectList(serviceCategory.GetAllData(), "CategoryId", "CategoryName", model.CategoryId);

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ProductDTO prod)
        {
            if (ModelState.IsValid)
            {
                service.Update(prod);
                return RedirectToAction("Index");
            }
            return View(prod);
            
        }
        private IEnumerable<ManufacturerDTO> GetManufacturers()
        {
            List<ManufacturerDTO> dTOs = new List<ManufacturerDTO>() { new ManufacturerDTO { ManufacturerId = 0, ManufacturerName = "SelectManufacturer" } };
            return dTOs.Union(serviceManufacturer.GetAllData());
        }

    }
}