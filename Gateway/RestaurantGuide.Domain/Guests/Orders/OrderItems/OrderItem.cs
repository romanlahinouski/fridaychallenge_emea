using RestaurantGuide.Domain.Restaurants.Dishes;

namespace RestaurantGuide.Domain.Guests.Orders
{
    public class OrderItem
    {
      

        public Dish Dish { get; set; }

        public int Count { get; set; }

        public decimal Amount { get; set; }

        public OrderItem(Dish dish, int count)
        {
            Dish = dish;
            Count = count;
        }

        public decimal GetOrderItemAmount()
        {
            return Dish.GetPrice() * Count;
        }
    
    }
}
