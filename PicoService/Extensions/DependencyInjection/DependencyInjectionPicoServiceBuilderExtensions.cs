using System;
using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using PicoService.Builder;
using PicoService.Configuration;
using PicoService.DependencyInjection;

namespace PicoService.Extensions.DependencyInjection
{
    public static class DependencyInjectionPicoServiceBuilderExtensions
    {
        public static IBusPicoServiceBuilder UseAspNetCoreDI(this IDependencyInjectionPicoServiceBuilder builder, Action<IServiceCollection> registrations)
        {
            var registrationStep = new PicoServiceConfigurationStep(registrations);
            var aspNetCoreDependencyResolverBuilningStep = CreateAspNetCoreDependencyResolverBuilningStep();
            builder.Configurator.AddStep(registrationStep);
            builder.Configurator.AddStep(aspNetCoreDependencyResolverBuilningStep);
            return (IBusPicoServiceBuilder) builder;
        }

        private static PicoServiceConfigurationStep CreateAspNetCoreDependencyResolverBuilningStep()
        {
            Action<IServiceCollection> configureAction = services => 
            {
                services.AddTransient<IDependencyResolver, AspNetCoreDependencyResolver>();                
            };
            return new PicoServiceConfigurationStep(configureAction);
        }
    }
}