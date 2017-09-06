using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PicoService.Builder;
using PicoService.Bus;
using PicoService.Extensions;
using PicoService.Extensions.Bus;
using PicoService.Extensions.DependencyInjection;
using PicoService.Extensions.Host;

namespace PicoService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();

            PicoServiceBuilder
                .Create()
                .UseCors("MyPolicy",options => options.AllowAnyHeader())
                .UsePort(5000)
                .ContinueConfiguration()
                .UseAspNetCoreDI(services => 
                {
                    //services.AddTransient()
                }).UseServiceBus(new ServiceBusConfiguration() , subscribeBus => 
                {
                    // subscribeBus.SubscribeToCommand<>();
                    // subscribeBus.SubscribeToEvent<>();
                })
                .UseStartup<Startup>()
                .Build();
                

        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
