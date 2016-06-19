using AlmostSurely.Processors.Interfaces;
using System;
using System.Collections.Generic;
using AlmostSurely.Filters.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlmostSurely.Models.Interfaces;

namespace AlmostSurely.Processors
{
	public class Processor : IProcessor
	{
		private IEnumerable<IFilter> _filters;

		public Processor(IEnumerable<Func<IFilter>> filters)
		{
			_filters = filters.Select(o => o());
		}

		public async Task Process(IProcessContainer container)
		{
			foreach(var filter in _filters)
			{
				await filter.RunAsync(container);
			}
		}
	}
}
