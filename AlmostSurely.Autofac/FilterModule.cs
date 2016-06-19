using AlmostSurely.Filters;
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
	public class FilterModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			var filters = AppDomain.CurrentDomain.GetAssemblies().SelectMany(o => o.GetTypes().Where(t =>
				t != typeof(BaseFilter)
				&& t.GetInterfaces().Contains(typeof(IFilter)))
			).ToArray();
			builder.RegisterTypes(filters).As<IFilter>();
		}
	}
}