using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PicoService.Configuration;

namespace PicoService.Extensions.Configuration
{
    public static class PicoServiceConfigurationExtensions
    {
        public static void AddPicoService(this IServiceCollection services)
        {
            var configurator = services
				.Where(s => s.ServiceType == typeof(PicoServiceConfigurator))
				.Select(s => (PicoServiceConfigurator)s.ImplementationInstance)
				.Single();

            var actions = configurator.GetConfigureServicesActions();

            foreach(var action in actions)
                action(services);
        }

        public static void UsePicoService(this IApplicationBuilder app)
        {
            var configurator = app.ApplicationServices.GetService<PicoServiceConfigurator>();
            var actions = configurator.GetConfigureActions();

            foreach(var action in actions)
                action(app);
        }
    }
}