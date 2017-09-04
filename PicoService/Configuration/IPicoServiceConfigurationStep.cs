using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PicoService.Configuration
{
    public interface IPicoServiceConfigurationStep
    {
         Action<IServiceCollection> ConfigureServicesAction { get; }
         Action<IApplicationBuilder> ConfigureAction { get; }
    }
}