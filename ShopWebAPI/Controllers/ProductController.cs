using Shop.BLL.BizModels;
using Shop.BLL.Services;
using Shop.BLL.Services.ViewModelsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ShopWebAPI.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class ProductController : ApiController
    {
        IProductWithPhotoViewModelService service;

        public ProductController(IProductWithPhotoViewModelService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(service.GetAllProducts());
        }
    }
}
