using AlmostSurely.Autofac;
using Autofac;
using Autofac.Integration.Wcf;
using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmostSurelyServiceWebRole
{
	public class ApplicationEntryPoint //: RoleEntryPoint
	{
		public static void AppInitialize()
		{
			ConfigureDependencyInjection();
		}

		private static void ConfigureDependencyInjection()
		{
			// For information on handling configuration changes
			// see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
			var builder = new ContainerBuilder();

			builder.RegisterModule(new ProcessorModule());
			builder.RegisterModule(new FilterModule());

			builder.RegisterType<AlmostSurelyService>()
				.AsImplementedInterfaces()
				.AsSelf();

			var container = builder.Build();
			AutofacHostFactory.Container = container;
		}
	}
}