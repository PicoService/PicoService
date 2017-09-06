using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PicoService.Builder;
using PicoService.Bus;
using PicoService.Configuration;

namespace PicoService.Extensions.Bus
{
    public static class BusPicoServiceExtensions
    {
        public static IPicoServiceBuilder UseServiceBus(this IBusPicoServiceBuilder builder, ServiceBusConfiguration configuration, Action<ISubscribeBus> registrations)
        {
            Action<IServiceCollection> configureServicesAction = services => 
            {
                services.AddSingleton(typeof(ServiceBusConfiguration), configuration);
                services.AddTransient<IPublishBus, ServiceBus>();
                services.AddTransient<ISubscribeBus, ServiceBus>();
            };

            Action<IApplicationBuilder> configureAction = app => 
            {
                var subscribeBus = app.ApplicationServices.GetService<ISubscribeBus>();
                registrations(subscribeBus);
            };

            var busStep = new PicoServiceConfigurationStep(configureServicesAction, configureAction);
            builder.Configurator.AddStep(busStep);
            return builder;
        } 
    }
}