using Autofac;
using RestaurantGuide.Application.Orders;
using RestaurantGuide.Application.Payments;
using RestaurantGuide.Infrastructure.Orders;
using RestaurantGuide.Infrastructure.Payments;

namespace RestaurantGuide.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderFulfilmentGrpcService>().As<IOrderFulfilmentService>();

            builder.RegisterType<PaymentCreationService>().As<IPaymentCreationService>();
        }

    }
}
