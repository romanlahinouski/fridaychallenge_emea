using AutoMapper;
using RestaurantGuide.Domain.Guests.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantGuide.Infrastructure.Orders.Mappings
{
   public class OrderItemMessageProfile : Profile
    {
        public OrderItemMessageProfile()
        {
            CreateMap<Application.Orders.Commands.OrderItemDto, 
                Protos.OrderItemDto>()
                .ReverseMap();
        }
    }
}
