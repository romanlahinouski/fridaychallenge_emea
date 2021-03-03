using AutoMapper;
using RestaurantGuide.OrderFulfilment.Application.Guests.Orders;

namespace RestaurantGuide.OrderFulfilment.Infrastructure.Restaurants.Dishes.Mappings
{
    public class OrderItemDtoProtoOrderItemProfile : Profile
    {

        public OrderItemDtoProtoOrderItemProfile()
        {
            CreateMap<Infrastructure.Orders.Protos.OrderItemDto, 
             Domain.Guests.Orders.OrderItem>()
                .ReverseMap();          
        }

    }
}
