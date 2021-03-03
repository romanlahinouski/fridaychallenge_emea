using Autofac;
using RestaurantGuide.Domain.Restaurants;
using RestaurantGuide.Domain.Restaurants.Dishes;
using RestaurantGuide.Domain.Guests;
using RestaurantGuide.OrderFulfilment.Domain.Guests.Orders;
using RestaurantGuide.OrderFulfilment.Infrastructure;
using RestaurantGuide.OrderFulfilment.Infrastructure.Orders;
using RestaurantGuide.OrderFulfilment.Infrastructure.Restaurants;
using RestaurantGuide.OrderFulfilment.Infrastructure.Restaurants.Dishes;
using RestaurantGuide.OrderFulfilment.Infrastructure.Guests;

namespace RestaurantGuide.OrderFulfilment.Modules
{
    public class InfrastructureModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
          
            builder.RegisterType<DishRepository>()
                .As<IDishRepository>()
                .SingleInstance();


            builder.RegisterType<GuestRepository>()
                .As<IGuestRepository>()
                .SingleInstance();

            builder.RegisterType<RestaurantRepository>()
                .As<IRestaurantRepository>();

            builder.RegisterType<OrderRepository>()
                .As<IOrderRepository>();

                
        }
    }
}
