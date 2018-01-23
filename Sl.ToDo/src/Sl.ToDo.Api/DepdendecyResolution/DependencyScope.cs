using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;

namespace Qt.Crm.Api.DepdendecyResolution
{
	public class DependencyScope : IDependencyScope
	{
		private readonly IResolutionRoot _resolver;

		public DependencyScope(IResolutionRoot resolver)
		{
			_resolver = resolver;
		}

		public void Dispose()
		{
			var disposable = _resolver as IDisposable;
			disposable?.Dispose();
		}

		public object GetService(Type serviceType)
		{
			return _resolver.TryGet(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return _resolver.GetAll(serviceType);
		}
	}
}