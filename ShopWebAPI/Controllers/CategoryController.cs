using Shop.BLL.BizModels;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ShopWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoryController : ApiController
    {
        IGenericService<CategoryDTO, int> serviceCategory;
        public CategoryController(IGenericService<CategoryDTO, int> serviceCategory)
        {
            this.serviceCategory = serviceCategory;
        }
        public string GetData(string id)
        {
            return $"Test {id}";
        }

        public HttpResponseMessage GetData()
        {
            try
            {
                var category = serviceCategory.GetAllData();
                return (category != null) ? Request.CreateResponse(HttpStatusCode.OK, category) :
                    Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
