using AutoMapper;

namespace RestaurantGuide.OrderFulfilment.Infrastructure.Orders.Mappings
{
    public class DishProtoDomainDishProfile : Profile
    {

        public DishProtoDomainDishProfile()
        {
            CreateMap<RestaurantGuide.Domain.Restaurants.Dishes.Dish,
                RestaurantGuide.OrderFulfilment.Infrastructure.Orders.Protos.Dish>();
        }
    }
  
}
