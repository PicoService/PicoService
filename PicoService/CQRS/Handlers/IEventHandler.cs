using System.Threading.Tasks;
using PicoService.CQRS.Contracts;

namespace PicoService.CQRS.Handlers
{
    public interface IEventHandler<in TEvent> where TEvent : class, IEvent
    {
         Task HandleAsync(TEvent @event);
    }
}