using AlmostSurely.Filters.Interfaces;
using AlmostSurely.Models.Interfaces;
using ImageMagick;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostSurely.Filters
{
    public class FirstFilter : BaseFilter
    {
		public override Task RunAsync(IProcessContainer processContainer)
		{
			var layers = processContainer.Images;
			for (var i = 0; i < layers.Count; i++)
			{
				var layer = layers.ElementAt(i);
				var magickImage = new MagickImage(layer.Value.ToArray());

				var rand = _randDouble;

				if (rand <= .1)              magickImage.Colorize(MagickColor.FromRgb(255, 0, 0), new Percentage(75));
				if (rand > .1 && rand <= .2) magickImage.Colorize(MagickColor.FromRgb(0, 255, 0), new Percentage(75));
				if (rand > .2 && rand <= .3) magickImage.Colorize(MagickColor.FromRgb(0, 0, 255), new Percentage(75));
				if (rand > .3 && rand <= .4) magickImage.Colorize(MagickColor.FromRgb(255, 255, 0), new Percentage(75));
				if (rand > .4 && rand <= .5) magickImage.Colorize(MagickColor.FromRgb(255, 0, 255), new Percentage(75));
				if (rand > .5 && rand <= .6) magickImage.Colorize(MagickColor.FromRgb(0, 255, 255), new Percentage(75));
				if (rand > .6 && rand <= .7) magickImage.Colorize(MagickColor.FromRgb(255, 255, 255), new Percentage(75));
				if (rand > .7 && rand <= .8) magickImage.Colorize(MagickColor.FromRgb(0, 0, 0), new Percentage(75));
				if (rand > .8 && rand <= .9) magickImage.Colorize(MagickColor.FromRgb(127, 0, 0), new Percentage(75));
				if (rand > .9)               magickImage.Colorize(MagickColor.FromRgb(0, 127, 0), new Percentage(75));

				layers[layer.Key] = magickImage.ToByteArray();
			}

			return Task.FromResult(true);
		}
    }
}
