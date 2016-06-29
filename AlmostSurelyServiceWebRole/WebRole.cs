using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Autofac;
using Autofac.Integration.Wcf;
using AlmostSurely.Autofac;

namespace AlmostSurelyServiceWebRole
{
	public class WebRole : RoleEntryPoint
	{
		public override bool OnStart()
		{
			// For information on handling configuration changes
			// see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

			var builder = new ContainerBuilder();

			builder.RegisterModule(new ProcessorModule());
			builder.RegisterModule(new FilterModule());

			AutofacHostFactory.Container = builder.Build();

			return base.OnStart();
		}
	}
}
