using System.Collections.Generic;

namespace PicoService.Bus
{
    public class ServiceBusConfiguration
    {
        public string QueueName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int Port { get; set; }

        public List<string> Hostnames { get; set; }
    }
}