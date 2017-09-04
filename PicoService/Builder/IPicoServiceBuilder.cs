using Microsoft.AspNetCore.Hosting;
using PicoService.Configuration;

namespace PicoService.Builder
{
    public interface IPicoServiceBuilder
    {
         IWebHostBuilder WebHostBuilder { get; }
         IPicoServiceConfigurator Configurator { get; }
    }
}