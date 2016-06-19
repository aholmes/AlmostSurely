using AlmostSurely.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostSurely.Processors.Interfaces
{
	public interface IProcessor
	{
		Task Process(IProcessContainer container);
	}
}
