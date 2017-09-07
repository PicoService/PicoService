using PicoService.CQRS.Contracts;

namespace PicoService.Bus
{
    public interface ISubscribeBus
    {
         void SubscribeToCommand<TCommand>() where TCommand: class, ICommand;
         void SubscribeToEvent<TEvent>() where TEvent : class, IEvent;
    }
}