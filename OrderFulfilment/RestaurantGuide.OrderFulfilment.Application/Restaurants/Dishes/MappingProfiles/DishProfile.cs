using AutoMapper;
using RestaurantGuide.Domain.Restaurants.Dishes;
using RestaurantGuide.OrderFulfilment.Application.Restaurants.Dishes.Queries;

namespace RestaurantGuide.OrderFulfilment.Application.Restaurants.Dishes.MappingProfiles
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<Dish, DishDto>();
        }
    }
}
