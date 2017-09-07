using System.Threading.Tasks;
using PicoService.CQRS.Contracts;

namespace PicoService.CQRS.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand: class, ICommand
    {
         Task HandleAsync(TCommand command);
    }
}