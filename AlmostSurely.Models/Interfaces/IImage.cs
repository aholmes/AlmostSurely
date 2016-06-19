using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostSurely.Models.Interfaces
{
	public interface IImage
	{
		string Name { get; }
		IEnumerable<byte> Data { get; set; }
	}
}
