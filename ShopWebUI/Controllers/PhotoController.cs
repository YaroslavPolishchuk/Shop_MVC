using Shop.BLL.BizModels;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopWebUI.Controllers
{
    public class PhotoController : Controller
    {
        // GET: Photo        
        IGenericService<PhotoDTO, int> servicePhoto;
        IGenericService<ProductDTO, int> serviceProduct;
        public PhotoController(IGenericService<PhotoDTO, int> servicePhoto,
            IGenericService<ProductDTO, int> serviceProduct)
        {
            this.servicePhoto = servicePhoto;
            this.serviceProduct = serviceProduct;
        }
        public ActionResult Index(int id = 1)
        {
            var product = serviceProduct.GetObjInstance(id);
            ViewBag.Product = product;// $"{product.ProductName}; Price-{product.Price}";
            var model = servicePhoto.FindBy(p => p.ProductId == id);
            return View(model);
        }
        public ActionResult Upload(int id = 1)
        {
            var model = id;
            return View(model);
        }
        [HttpPost]
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> fileUploadMulti)//fileUploadMulti обязательно совпадет с input
        {
            string idstr = Request.Params["id"];
            int id = Convert.ToInt32(idstr);
            foreach (var file in fileUploadMulti)
            {
                if (file == null) continue;
                string path = AppDomain.CurrentDomain.BaseDirectory + "img/";
                string filename = Path.GetFileName(file.FileName);
                string newfilename = Guid.NewGuid().ToString() + Path.GetExtension(filename);
                if (filename != null)
                {
                    file.SaveAs(Path.Combine(path, newfilename));
                    PhotoDTO photo = new PhotoDTO
                    {
                        ProductId = id,
                        PhotoPath = "/img/" + newfilename
                    };
                    servicePhoto.Add(photo);
                }
            }
            return RedirectToAction("Index", new { id = id });
        }
        public ActionResult Delete(int id = 1)
        {
            servicePhoto.Delete(id);
            return Json("OK");
        }
    }
}