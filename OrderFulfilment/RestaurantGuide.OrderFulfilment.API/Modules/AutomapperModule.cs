using System;
using Autofac;
using AutoMapper;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using RestaurantGuide.Infrastructure;

namespace RestaurantGuide.OrderFulfilment.Modules
{
    public class AutomapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
                    
                builder.RegisterAutoMapper(config => {

                    foreach (var assembly in Assemblies.SolutionAsseblies)
                    {
                        config.AddMaps(assembly);
                        config.ShouldMapField = fieldInfo => true;
                        config.ShouldMapProperty = propetyInfo => true;                   
                    }

                }, Assemblies.Infrastructure);
            }
                                      
    }
}
