using System;
using System.Collections.Generic;
using System.Linq;
using Customer.Dto;
using Customer.Models;

namespace Customer.Service
{
    public class OrdersService
    {
        DB_Entities db = new DB_Entities();

        public Boolean SaveOrder(PlaceOrderDTO placeOrderDto)
        {
            //payment
            String paymentId = Guid.NewGuid().ToString();
            Payment payment = new Payment();
            payment.paymentId = paymentId;
            //todo: add payment status initially 
            payment.status = "NOT";
            db.Payments.Add(payment);
            db.SaveChanges();

            string orderId = Guid.NewGuid().ToString();
            Order order = new Order();
            order.orderId = orderId;
            //todo: set status 
            order.status = "INIT";
            order.customerId = placeOrderDto.customerId;
            order.paymentId = paymentId;
            db.Orders.Add(order);
            db.SaveChanges();

            foreach (OrderItem orderItem in placeOrderDto.orderItemList)
            {
                OrderDetail orderDetail = new OrderDetail();
                string detailId = Guid.NewGuid().ToString();
                orderDetail.detailId = detailId;
                orderDetail.orderId = orderId;
                orderDetail.price = orderItem.price;
                orderDetail.qty = orderItem.qty;
                orderDetail.itemCode = orderItem.itemCode;
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
            }

            return true;
        }

        public Object GetHistory(string customerId, int currentPage)
        {
            int limitVal = 10;
            int skipVal = 0;
            if (currentPage != 1)
            {
                skipVal = currentPage * limitVal;
            }

            List<OrderHistory> orderHistories = db.Orders.Join(
                    db.Customers,
                    order => order.customerId,
                    customer => customer.customerId,
                    (order, customer) => new
                    {
                        order,
                        customer
                    }
                )
                .Where(arg => arg.order.customerId == customerId)
                .Join(
                    db.Payments,
                    arg => arg.order.paymentId,
                    payments => payments.paymentId,
                    (arg, payment) => new OrderHistory
                    {
                        orderId = arg.order.orderId,
                        date = arg.order.date,
                        paymentId = payment.paymentId,
                        orderStatus = arg.order.status,
                        paymentStatus = payment.status,
                        amount = payment.amount,
                    }
                )
                .OrderBy(history => history.date)
                .Skip(skipVal)
                .Take(limitVal)
                .ToList();
            return orderHistories;
        }

        public OrderDetailFullDTO GetOrderDetails(string orderId)
        {
            OrderDetailFullDTO dto = db.Orders
                .Join(db.Payments,
                    order => order.paymentId,
                    payment => payment.paymentId,
                    (order, payment) => new OrderDetailFullDTO
                    {
                        amount = payment.amount,
                        date = payment.date,
                        orderStatus = order.status,
                        paymentStatus = payment.status,
                        orderId = order.orderId,
                        paymentId = payment.paymentId,
                    }).First(arg => arg.orderId == orderId);

            List<OrderDetailDTO> orderDetailDtos = db.Orders
                .Join(db.OrderDetails,
                    order => order.orderId,
                    detail => detail.orderId,
                    (order, detail) => new
                    {
                        order,
                        detail
                    }
                )
                .Where(arg => arg.order.orderId == orderId)
                .Join(
                    db.Items,
                    arg => arg.detail.itemCode,
                    item => item.itemCode,
                    (arg, item) => new OrderDetailDTO
                    {
                        detailId = arg.detail.detailId,
                        price = arg.detail.price,
                        qty = arg.detail.qty,
                        itemCode = item.itemCode,
                        name = item.name,
                    }
                )
                .ToList();
            dto.detailList = orderDetailDtos;
            dto.orderId = orderId;
            return dto;
        }
    }
}