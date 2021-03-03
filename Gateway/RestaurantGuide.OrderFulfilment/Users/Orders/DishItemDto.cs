using System;
namespace RestaurantGuide.OrderFulfilment.Users.Orders
{
    public class DishItemDto
    {
        public string DishName { get; set; }

        public int Count { get; set; }

        public int Id { get; set; }

        public DishItemDto()
        {
        }
    }
}
