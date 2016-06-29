using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostSurely.Extensions
{
    public static class ImageExtensions
    {
		public static Bitmap ToBitmap(this IEnumerable<byte> obj)
		{
			var newImage = obj.ToArray();

			using (var ms = new MemoryStream())
			{
				ms.Write(newImage, 0, newImage.Length);

				return new Bitmap(ms);
			}
		}
    }
}
