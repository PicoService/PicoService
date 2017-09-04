using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PicoService.Configuration
{
    internal class PicoServiceConfigurator : IPicoServiceConfigurator
    {
        private readonly List<IPicoServiceConfigurationStep> _steps;

        public PicoServiceConfigurator()
        {
            _steps = new List<IPicoServiceConfigurationStep>();
        }

        public void AddStep(IPicoServiceConfigurationStep step)
            => _steps.Add(step);

        public IEnumerable<IPicoServiceConfigurationStep> GetAllSteps()
            => _steps;

        public IEnumerable<Action<IServiceCollection>> GetConfigureServicesActions()
            => _steps
                .Where(s => s.ConfigureServicesAction != null)
                .Select(s => s.ConfigureServicesAction)
                .ToList();

        public IEnumerable<Action<IApplicationBuilder>> GetConfigureActions()
            => _steps
                .Where(s => s.ConfigureAction != null)
                .Select(s => s.ConfigureAction)
                .ToList();
    }
}