﻿using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Customer.Dto;
using Customer.Models;
using Customer.Service;

namespace Customer.Controllers
{
    [RoutePrefix("api/item")]
    [EnableCors(origins: "http://localhost:4200", headers: "accept,content-type,origin,x-my-header", methods: "*")]
    public class ItemController : ApiController
    {
        ItemService itemService = new ItemService();

        [HttpGet]
        [Route("view")]
        public List<ItemViewDTO> GetItemsView(string categoryId)
        {
            return itemService.GetItemForView(categoryId);
        }
    }
}