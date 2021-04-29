using Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Customer.Dto;
using Customer.Service;

namespace Customer.Controllers
{
    [RoutePrefix("api/customer")]
    [EnableCors(origins: "http://localhost:4200", headers: "accept,content-type,origin,x-my-header", methods: "*")]
    public class CustomerController : ApiController
    {
        CustomerService _customerService = new CustomerService();

        [HttpGet]
        [Route("detail")]
        public CustomerView GetDetails(String customerId)
        {
            return _customerService.GetDetails(customerId);
        }

        [HttpPost]
        [Route("reg")]
        public Boolean Register(CustomerRegDTO customerRegDto)
        {
            return _customerService.Register(customerRegDto);
        }
        
        [HttpPost]
        [Route("login")]
        public CustomerBasicDetail Login(CustomerLoginDTO customerRegDto)
        {
            return _customerService.Login(customerRegDto);
        }
        
        
    }
}