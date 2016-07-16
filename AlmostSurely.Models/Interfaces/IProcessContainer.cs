using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AlmostSurely.Models.Interfaces
{
	public interface IProcessContainer
	{
		Size Dimensions { get; }
		ICollection<IImage> Images { get; }
	}
}
