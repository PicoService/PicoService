using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PicoService.Builder;
using PicoService.Configuration;

namespace PicoService.Extensions.Host
{
    public static class HostPicoServiceBuilderExtensions
    {
        public static IHostPicoServiceBuilder UsePort(this IHostPicoServiceBuilder builder, int port)
        {
            builder.WebHostBuilder.UseUrls($"http://*:{port}");
            return builder;
        }

        public static IHostPicoServiceBuilder UseCors(this IHostPicoServiceBuilder builder, string policyName, CorsPolicy policy)
        {
            builder.Configurator.AddCorsStep(policyName, options => options.AddPolicy(policyName, policy));
            return builder;
        }

        public static IHostPicoServiceBuilder UseCors(this IHostPicoServiceBuilder builder, string policyName, Action<CorsPolicyBuilder> buildingOptions)
        {
            builder.Configurator.AddCorsStep(policyName, options => options.AddPolicy(policyName, buildingOptions));
            return builder;
        }

        public static IDependencyInjectionPicoServiceBuilder ContinueConfiguration(this IHostPicoServiceBuilder builder)
        {
            return (IDependencyInjectionPicoServiceBuilder) builder;
        }

        private static void AddCorsStep(this IPicoServiceConfigurator configurator, string policyName, Action<CorsOptions> options)
        {           
            Action<IServiceCollection> configureServicesAction =  services => services.AddCors(options);
            Action<IApplicationBuilder> configureAction = app => app.UseCors(policyName);

            var corsStep = new PicoServiceConfigurationStep(configureServicesAction, configureAction);
            configurator.AddStep(corsStep);
        }
    }
}