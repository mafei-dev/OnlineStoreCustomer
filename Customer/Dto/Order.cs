using System;
using System.Collections.Generic;

namespace Customer.Dto
{
    public class OrderItem
    {
        public String itemCode { get; set; }
        public int qty { get; set; }
        public decimal price { get; set; }
    }

    public class PlaceOrderDTO
    {
        public String customerId { get; set; }
        public List<OrderItem> orderItemList { get; set; }
    }

    public class OrderHistory
    {
        public string orderId { get; set; }
        public string paymentStatus { get; set; }
        public string orderStatus { get; set; }
        public Nullable<DateTime> date { get; set; }
        public string paymentId { get; set; }
        public Nullable<decimal> amount { get; set; }
    }

    public class OrderDetailDTO
    {
        public string itemCode { get; set; }
        public string name { get; set; }
        public string detailId { get; set; }
        public Nullable<int> qty { get; set; }
        public Nullable<decimal> price { get; set; }
    }

    public class OrderDetailFullDTO : OrderHistory
    {
        public List<OrderDetailDTO> detailList { get; set; }
    }
}