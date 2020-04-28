using Shop.BLL.BizModels;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopWebUI.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        IGenericService<CategoryDTO, int> serviceCategory;
        public CategoryController(IGenericService<CategoryDTO, int> service)
        {
            serviceCategory = service;
        }
        public ActionResult Index()
        {
            var model = serviceCategory.GetAllData();
            return View(model);
        }
        public ActionResult Edit(int _id = 0)
        {
            var model = _id == 0 ? new CategoryDTO
            {
                CategoryId = 0,
                CategoryName = "New category"
            } : serviceCategory.GetObjInstance(_id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(CategoryDTO _category)
        {
            if (ModelState.IsValid)
            {
                serviceCategory.Update(_category);
                return RedirectToAction("Index");
            }
            return View(_category);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                serviceCategory.Delete(id);
                return Json("Ok");
            }
            catch
            {
                return Json("Bad");
            }
        }
        public ActionResult TestApi()
        {
            return View();
        }
    }
}
