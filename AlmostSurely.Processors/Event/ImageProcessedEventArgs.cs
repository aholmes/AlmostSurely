using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostSurely.Processors.Event
{
	public class ImageProcessedEventArgs
	{
		public Bitmap Image { get; }

		public ImageProcessedEventArgs(Bitmap image)
		{
			Image = image;
		}
	}
}
