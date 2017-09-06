using System.Threading.Tasks;
using PicoService.CQRS.Handlers;
using PicoService.DependencyInjection;
using RawRabbit;

namespace PicoService.Bus
{
	internal sealed class ServiceBus : IPublishBus, ISubscribeBus
	{
        private readonly IDependencyResolver _dependencyResolver;
        private readonly IBusClient _busClient;  
		private readonly ServiceBusConfiguration _serviceBusConfig;

        public ServiceBus(IDependencyResolver dependencyResolver, IBusClient busClient, ServiceBusConfiguration serviceBusConfig)
        {
            _dependencyResolver = dependencyResolver;
            _busClient = busClient;
			_serviceBusConfig = serviceBusConfig;
        }   

		async Task IPublishBus.PublishCommandAsync<TCommand>(TCommand command)
			=> await _busClient.PublishAsync(command);
		

		async Task IPublishBus.PublishEventAsync<TEvent>(TEvent @event)
			=> await _busClient.PublishAsync(@event);

		void ISubscribeBus.SubscribeToCommand<TCommand>()
		{
			_busClient.SubscribeAsync<TCommand>(async (command, context) => 
			{
				var commandHandler = _dependencyResolver.GetDependency<ICommandHandler<TCommand>>();
				await commandHandler.HandleAsync(command);
			}, cfg => cfg.WithQueue(q => q.WithName(_serviceBusConfig.QueueName)));
		}

		void ISubscribeBus.SubscribeToEvent<TEvent>()
		{
			_busClient.SubscribeAsync<TEvent>(async (@event, context) => 
			{
				var eventHandler = _dependencyResolver.GetDependency<IEventHandler<TEvent>>();
				await eventHandler.HandleAsync(@event);
			}, cfg => cfg.WithQueue(q => q.WithName(_serviceBusConfig.QueueName)));
		}
	}
}