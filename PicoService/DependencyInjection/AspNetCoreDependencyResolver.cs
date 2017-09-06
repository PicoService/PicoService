using System;

namespace PicoService.DependencyInjection
{
	public class AspNetCoreDependencyResolver : IDependencyResolver
	{
        private readonly IServiceProvider _serviceProvider;

        public AspNetCoreDependencyResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

		public TDependency GetDependency<TDependency>()
            => (TDependency) _serviceProvider.GetService(typeof(TDependency));
	}
}