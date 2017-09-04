using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using PicoService.Configuration;

namespace PicoService.Builder
{
	public class PicoServiceBuilder : 
        IPicoServiceBuilder, 
        IHostPicoServiceBuilder, 
        IDependencyInjectionPicoServiceBuilder, 
        IBusPicoServiceBuilder
	{
        IWebHostBuilder IPicoServiceBuilder.WebHostBuilder => _webHostBuilder;

		IPicoServiceConfigurator IPicoServiceBuilder.Configurator => _configurator;

        private readonly IWebHostBuilder _webHostBuilder;

        private readonly IPicoServiceConfigurator _configurator;		


		private PicoServiceBuilder(IWebHostBuilder webHostBuilder, IPicoServiceConfigurator configurator)
        {
            _webHostBuilder = webHostBuilder;
            _configurator = configurator;
        }

        public static IHostPicoServiceBuilder Create()
        {
            var webHostBuilder = WebHost.CreateDefaultBuilder();
            var configurator = new PicoServiceConfigurator();

            return new PicoServiceBuilder(webHostBuilder, configurator);
        }
	}
}