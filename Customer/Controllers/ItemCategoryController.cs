using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Customer.Dto;
using Customer.Service;

namespace Customer.Controllers
{
    [RoutePrefix("api/category")]
    [EnableCors(origins: "http://localhost:4200", headers: "accept,content-type,origin,x-my-header", methods: "*")]
    public class ItemCategoryController : ApiController
    {
        ItemCategoryService ItemCategoryService = new ItemCategoryService();

        [HttpGet]
        [Route("list")]
        public List<ItemCategoryDTO> GetOrderDetails()
        {
            return ItemCategoryService.GetAllCategories();
        }
    }
}