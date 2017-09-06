using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PicoService.Builder;

namespace PicoService.Extensions
{
    public static class PicoServiceBuilderExtensions
    {
        public static IPicoServiceBuilder UseStartup<TStartup>(this IPicoServiceBuilder builder) where TStartup : class
		{
			builder.WebHostBuilder.UseStartup<TStartup>();
            return builder;
		}

		public static IWebHost Build(this IPicoServiceBuilder builder)
        { 
            builder.WebHostBuilder.ConfigureServices(serviceCollection =>
            {
                serviceCollection.Add(ServiceDescriptor.Singleton(builder.Configurator));
            });
            
            var webHost = builder.Build();
            return webHost;
        }
    }
}