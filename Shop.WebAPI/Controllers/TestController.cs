using Shop.BLL.BizModels;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.WebAPI.Controllers
{
    public class TestController : ApiController
    {
        IGenericService<CategoryDTO, int> categoryService;
        public TestController(IGenericService<CategoryDTO, int> categoryService)
        {
            this.categoryService = categoryService;
        }
        public HttpResponseMessage GetData(int id)
        {
            try
            {
                CategoryDTO category = categoryService.GetObjInstance(id);
                return (category != null) ? Request.CreateResponse(HttpStatusCode.OK, category) :
                    Request.CreateResponse(HttpStatusCode.NotFound, $"No found category with id {id}");
            }
            catch(Exception e)
            {
               return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }   
            
        }
    }
}
