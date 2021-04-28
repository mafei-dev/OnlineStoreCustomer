using Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Customer.Controllers
{

    [RoutePrefix("api/customer")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CustomerController : ApiController
    {
        DB_Entities _dbEntities = new DB_Entities();
         
        [HttpGet]
        [Route("all")]
        public IEnumerable<string> Get()
        {
            string id = Guid.NewGuid().ToString();
            ItemCategory item = new ItemCategory();
            item.categoryId = id;
            item.name = "name";
            _dbEntities.ItemCategories.Add(item);
            _dbEntities.SaveChanges();
            return new string[] { "value1", "value2" };
        }
    }
}
