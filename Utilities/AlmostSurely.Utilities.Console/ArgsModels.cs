using CommandLine;
using CommandLine.Text;

namespace AlmostSurely.Utilities.Console
{
	internal class ArgsModel
	{
		[HelpOption]
		public string GetUsage()
		{
			return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
		}

		private const string ImagesHelpText = "";
		[Option('i', "images", Required = false, HelpText = ImagesHelpText)]
		public string Images { get; set; }

		private const string ImageOutputWidthHelpText = "";
		[Option('W', "width", DefaultValue = 400, Required = false, HelpText = ImageOutputWidthHelpText)]
		public int ImageOutputWidth { get; set; }

		private const string ImageOutputHeightHelpText = "";
		[Option('H', "height", DefaultValue = 300, Required = false, HelpText = ImageOutputHeightHelpText)]
		public int ImageOutputHeight { get; set; }

		private const string OutputPathHelpText = "";
		[Option('o', "outpath", DefaultValue = "", Required = false, HelpText = OutputPathHelpText)]
		public string OutputPath { get; set; }

		private const string VariationsHelpText = "";
		[Option('v', "variations", DefaultValue = 1, Required = false, HelpText = VariationsHelpText)]
		public int Variations { get; set; }

		private const string RecipeHelpText = "";
		[Option('f', "filter", DefaultValue = "All", Required = false, HelpText = RecipeHelpText)]
		public string Recipe { get; set; }
	}
}
