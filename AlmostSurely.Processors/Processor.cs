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
	public class Processor : ProcessorBase
	{
		public Processor(IEnumerable<Func<IFilter>> filters)
			:base(filters)
		{
		}

		public override async Task Process(IProcessContainer container)
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

					var rect = new Rectangle(0, 0, container.Dimensions.Width, container.Dimensions.Height);

					foreach(var img in container.Images)
					{
						using (var bmp = img.Data.ToBitmap())
						{
							canvas.DrawImage(bmp, rect, rect, GraphicsUnit.Pixel);
						}
					}

					canvas.Save();
				}

				ImageProcessed(new ImageProcessedEventArgs(bitmap));
			//}
		}

		public override event ImageProcessedEventHandler ImageProcessed;
	}
}
