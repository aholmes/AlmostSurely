using AlmostSurely.Processors.Interfaces;
using System;
using System.Collections.Generic;
using AlmostSurely.Filters.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlmostSurely.Models.Interfaces;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using AlmostSurely.Extensions;
using AlmostSurely.Processors.Event;

namespace AlmostSurely.Processors
{
	public abstract class ProcessorBase : IProcessor
	{
		protected IEnumerable<IFilter> _filters;

		public ProcessorBase(IEnumerable<Func<IFilter>> filters)
		{
			_filters = filters.Select(o => o());
		}

		public abstract Task Process(IProcessContainer container);

		public abstract event ImageProcessedEventHandler ImageProcessed;
	}
}
