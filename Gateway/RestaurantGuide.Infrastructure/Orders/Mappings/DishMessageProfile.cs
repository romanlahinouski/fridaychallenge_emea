using AutoMapper;
using RestaurantGuide.Application.Orders.Commands;
using RestaurantGuide.Infrastructure.Orders.Protos;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.Infrastructure.Orders.Mappings
{
    public class DishMessageProfile : Profile
    {

        public DishMessageProfile()
        {
            CreateMap<Domain.Restaurants.Dishes.Dish, Dish>();
        }
    }
}
