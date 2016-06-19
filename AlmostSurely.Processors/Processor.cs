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
	public class Processor : IProcessor
	{
		private IEnumerable<IFilter> _filters;

		public Processor(IEnumerable<Func<IFilter>> filters)
		{
			_filters = filters.Select(o => o());
		}

		public async Task Process(IProcessContainer container)
		{
			foreach (var filter in _filters)
			{
				await filter.RunAsync(container);
			}

			var bitmap = new Bitmap(container.Dimensions.Width, container.Dimensions.Height);//)
			//{
				using (var canvas = Graphics.FromImage(bitmap))
				{
					canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;

					foreach(var img in container.Images)
					{
						canvas.DrawImage(img.Data.ToBitmap(), 0, 0);
					}

					canvas.Save();
				}

				ImageProcessed(new ImageProcessedEventArgs(bitmap));
			//}
		}

		public event ImageProcessedEventHandler ImageProcessed;
	}
}
