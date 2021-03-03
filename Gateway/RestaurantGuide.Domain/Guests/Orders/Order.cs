using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantGuide.Domain.Guests.Orders
{
    public class Order
    {

        private int id;

        private OrderStatus orderStatus;

        private List<OrderItem> orderItems = new List<OrderItem>();


        private Order()
        {
            orderStatus = OrderStatus.Received;
        }

        private Order(List<OrderItem> orderItems) 
            : this ()
        {
            this.orderItems = orderItems;
        }

        private Order(int id)
        {
            this.id = id;
            orderStatus = OrderStatus.Received;
        }

        public static Order CreateOrder(List<OrderItem> orderItems)
        {
            return new Order(orderItems);
        }


        public decimal GetOrderAmount()
        {
            return orderItems.Sum(x => x.GetOrderItemAmount());
        }


        public OrderStatus GetOrderStatus()
        {
            return orderStatus;
        }


        public void AddOrderItems(OrderItem [] orderItems)
        {
            this.orderItems.AddRange(orderItems);
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            this.orderItems.Add(orderItem);
        }


        public IReadOnlyCollection<OrderItem> GetOrderItems()
        {
            return orderItems.AsReadOnly();
        }

        public int GetOrderId()
        {
            return id;
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
