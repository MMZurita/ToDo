using System.Web.Http.Dependencies;
using Ninject;

namespace Qt.Crm.Api.DepdendecyResolution
{
	public class DependencyResolver : DependencyScope, IDependencyResolver
	{
		private readonly IKernel _kernel;

		public DependencyResolver(IKernel kernel)
			: base(kernel)
		{
			_kernel = kernel;
		}

		public IDependencyScope BeginScope()
		{
			return new DependencyScope(_kernel.BeginBlock());
		}
	}
}