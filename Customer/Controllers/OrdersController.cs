using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Customer.Dto;
using Customer.Service;

namespace Customer.Controllers
{
    [RoutePrefix("api/orders")]
    [EnableCors(origins: "http://localhost:4200", headers: "accept,content-type,origin,x-my-header", methods: "*")]
    public class OrdersController : ApiController
    {
        OrdersService _ordersService = new OrdersService();

        [HttpPost]
        [Route("place")]
        public Boolean PlaceOrder(PlaceOrderDTO placeOrderDto)
        {
            try
            {
                return _ordersService.SaveOrder(placeOrderDto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        [HttpGet]
        [Route("history")]
        public Object GetOrderHistory(string customerId, int currentPage)
        {
            // todo: get customer id from token
            return _ordersService.GetHistory(customerId, currentPage);
        }

        [HttpGet]
        [Route("history/details")]
        public OrderDetailFullDTO GetOrderDetails(string orderId)
        {
            // todo: get customer id from token
            return _ordersService.GetOrderDetails(orderId);
        }
    }
}