using Autofac;
using Microsoft.Extensions.Configuration;
using RestaurantGuide.Application.Guests;
using RestaurantGuide.Domain.Guests;
using RestaurantGuide.Guests;
using RestaurantGuide.Infrastructure;
using RestaurantGuide.Infrastructure.Base;
using RestaurantGuide.Infrastructure.Guests;
using System;

namespace RestaurantGuide.Modules
{
    public class InfrastructureModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
           
            builder.RegisterType<GuestRepository>()
                .As<IGuestRepository>()
                .SingleInstance();
            
            builder.RegisterType<GuestGrpcService>().As<IGuestGrpcService>();

            builder.Register<SkipCertValidationHttpHandler>(x => new SkipCertValidationHttpHandler(x.Resolve<IConfiguration>()));


            builder.Register<HttpClient>(x =>
            {
                return new HttpClient(httpClient =>
                {

                    httpClient.BaseAddress = new Uri("https://localhost:5001/api/");
                    //httpClient.DefaultRequestHeaders.Accept.Add(
                    //    new MediaTypeWithQualityHeaderValue("application/json"));

                });
            }).SingleInstance();

        
             
        }
    }
}
