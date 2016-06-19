using AlmostSurely.Filters.Interfaces;
using AlmostSurely.Models.Interfaces;
using AlmostSurely.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostSurely.Filters
{
	public abstract class BaseFilter: IFilter
	{
		protected Random _random = RandomProvider.GetThreadRandom();
		protected int _randInt => _random.Next();
		protected double _randDouble => _random.NextDouble();

		public virtual Task RunAsync(IProcessContainer processContainer)
		{
			throw new NotImplementedException(AlmostSurely.Resources.Properties.Resources.Error_BaseFilterOverrideNotImplemented);
		}
	}
}
