using AlmostSurely.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostSurely.Processors
{
	public class ProcessContainer : IProcessContainer
	{
		public IDictionary<string, IEnumerable<byte>> Images { get; set; }
	}
}
