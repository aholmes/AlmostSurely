using AlmostSurely.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostSurely.Filters.Interfaces
{
	public interface IFilter
	{
		Task RunAsync(IProcessContainer processContainer);
	}
}
