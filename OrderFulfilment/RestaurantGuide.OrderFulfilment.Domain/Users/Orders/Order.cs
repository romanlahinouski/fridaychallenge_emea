using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantGuide.OrderFulfilment.Domain.Guests.Orders
{
    public class Order
    {

        public int OrderId { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        private Order()
        {
            OrderStatus = OrderStatus.Received;
        }

        private Order(List<OrderItem> orderItems)
            : this()
        {
            OrderItems = orderItems;
        }

        private Order(int id)
        {
            OrderId = id;
            OrderStatus = OrderStatus.Received;
        }

        public static Order CreateOrder(List<OrderItem> orderItems)
        {
            return new Order(orderItems);
        }


        public decimal GetOrderAmount()
        {
            return OrderItems.Sum(x => x.GetOrderItemAmount());
        }



        public void AddOrderItems(OrderItem[] orderItems)
        {
            this.OrderItems.AddRange(orderItems);
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            this.OrderItems.Add(orderItem);
        }




    }

    public enum OrderStatus
    {
        Received,       
        Preparing,
        Served,
        WaitingForPayment,
        Payed
    }
}
