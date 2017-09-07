namespace PicoService.DependencyInjection
{
    public interface IDependencyResolver
    {
         TDependency GetDependency<TDependency>();
    }
}