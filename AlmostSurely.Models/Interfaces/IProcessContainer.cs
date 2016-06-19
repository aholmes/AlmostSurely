using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostSurely.Models.Interfaces
{
	public interface IProcessContainer
	{
		IDictionary<string, IEnumerable<byte>> Images { get; set; }
	}
}
