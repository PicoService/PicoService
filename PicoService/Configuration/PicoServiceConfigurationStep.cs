using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PicoService.Configuration
{
    internal class PicoServiceConfigurationStep : IPicoServiceConfigurationStep
    {
        public Action<IServiceCollection> ConfigureServicesAction { get; }
        public Action<IApplicationBuilder> ConfigureAction { get; }

        public PicoServiceConfigurationStep(Action<IServiceCollection> configureServicesAction)
        {
            ConfigureServicesAction = configureServicesAction;
        }

		public PicoServiceConfigurationStep(Action<IServiceCollection> configureServicesAction, Action<IApplicationBuilder> configureAction)
            :this(configureServicesAction)
		{
            ConfigureAction = configureAction;
		}
    }
}