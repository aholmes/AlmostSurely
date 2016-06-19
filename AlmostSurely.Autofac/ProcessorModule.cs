using AlmostSurely.Filters.Interfaces;
using AlmostSurely.Processors;
using AlmostSurely.Processors.Interfaces;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostSurely.Autofac
{
	public class ProcessorModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			var processors = AppDomain.CurrentDomain.GetAssemblies().SelectMany(o => o.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IProcessor)))).ToArray();
			builder.RegisterTypes(processors).As<IProcessor>();
		}
	}
}