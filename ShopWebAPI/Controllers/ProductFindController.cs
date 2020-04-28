using Shop.BLL.BizModels;
using Shop.BLL.Services;
using ShopWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopWebAPI.Controllers
{
    public class ProductFindController : ApiController
    {
        IGenericService<ProductDTO, int> productService;
        public ProductFindController(IGenericService<ProductDTO, int> productService)
        {
            this.productService = productService;
        }
        public IEnumerable<ProductDTO> GetAll() // для тестирования
        {
            return productService.GetAllData();
        }
        [HttpPost]
        public HttpResponseMessage FindBy([FromBody]ViewModelFilter filter)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, productService.FindBy(filter.predicate));
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
