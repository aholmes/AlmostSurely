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
	public class AutofacRoleEntryPoint : RoleEntryPoint
	{
		private IContainer _container;

		public override void Run()
		{
		}

		public override bool OnStart()
		{
			ConfigureDependencyInjection();

			return base.OnStart();
		}

		public override void OnStop()
		{
			base.OnStop();
		}

		private void ConfigureDependencyInjection()
		{
			// For information on handling configuration changes
			// see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
			var builder = new ContainerBuilder();

			builder.RegisterModule(new ProcessorModule());
			builder.RegisterModule(new FilterModule());

			_container = builder.Build();
			AutofacHostFactory.Container = _container;
		}
	}
}