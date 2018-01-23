using Ninject;
using Ninject.Syntax;

namespace Qt.Crm.Api.DepdendecyResolution
{
	public static class IoC
	{
		public static IResolutionRoot Initialize()
		{
			return new StandardKernel();
		}
	}
}