using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Customer.Dto;
using Customer.Models;
using Customer.Service;

namespace Customer.Controllers
{
    [RoutePrefix("api/item")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ItemController : ApiController
    {
        ItemService itemService = new ItemService();

        [HttpGet]
        [Route("view")]
        public List<ItemViewDTO> GetItemsView()
        {
            return itemService.GetItemForView();
        }
    }
}