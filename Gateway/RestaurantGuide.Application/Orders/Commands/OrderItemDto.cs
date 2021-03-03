namespace RestaurantGuide.Application.Orders.Commands
{
    public class OrderItemDto
    {      
        public int Count { get; set; }

        public int DishId { get; set; }

        public OrderItemDto()
        {
        }
    }
}