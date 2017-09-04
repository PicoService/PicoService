using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PicoService.Configuration
{
    public interface IPicoServiceConfigurator
    {
        void AddStep(IPicoServiceConfigurationStep step);
        IEnumerable<IPicoServiceConfigurationStep> GetAllSteps();
        IEnumerable<Action<IServiceCollection>> GetConfigureServicesActions();
        IEnumerable<Action<IApplicationBuilder>> GetConfigureActions();
    }
}