using Autofac;
using RestaurantGuide.Domain.Base;
using RestaurantGuide.Infrastructure;
using RestaurantGuide.OrderFulfilment.Application;
using RestaurantGuide.OrderFulfilment.Guests.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantGuide.OrderFulfilment.Modules
{
    public class OrderFulfilmentModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assemblies.Application)
                .AsClosedTypesOf(typeof(IBaseRole<>))
                .AsImplementedInterfaces();

            builder.RegisterType<PutOrderContext>().As<IPutOrderContext>();
            builder.RegisterType<GuestRegistrationContext>().As<IGuestRegistrationContext>();
        }
    }
}
