using AutoMapper;
using RestaurantGuide.OrderFulfilment.Application.Users.Orders;

namespace RestaurantGuide.OrderFulfilment.Infrastructure.Restaurants.Dishes.Mappings
{
    public class OrderItemDtoProtoOrderItemProfile : Profile
    {

        public OrderItemDtoProtoOrderItemProfile()
        {
            CreateMap<Infrastructure.Orders.Protos.OrderItemDto, 
             Domain.Users.Orders.OrderItem>()
                .ReverseMap();          
        }

    }
}
