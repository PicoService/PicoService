using System.Threading.Tasks;
using PicoService.CQRS.Contracts;

namespace PicoService.Bus
{
    public interface IPublishBus
    {
         Task PublishCommandAsync<TCommand>(TCommand command) where TCommand: class, ICommand;
         Task PublishEventAsync<TEvent>(TEvent @event) where TEvent: class, IEvent;
    }
}