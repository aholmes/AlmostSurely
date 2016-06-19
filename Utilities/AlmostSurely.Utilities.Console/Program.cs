using AlmostSurely.Filters.Interfaces;
using AlmostSurely.Processors.Interfaces;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AlmostSurely.Autofac;
using System.IO;

namespace AlmostSurely.Utilities.Console
{
	class Program
	{
		private static IContainer Container { get; set; }

		static void Main(string[] args)
		{
			var builder = new ContainerBuilder();
			builder.RegisterModule(new ProcessorModule());
			builder.RegisterModule(new FilterModule());
			Container = builder.Build();

			var processContainer = new Processors.ProcessContainer();
			const string imagePath = @"C:\Users\Aaron\Pictures\Bike\15_YZF-R6_Black_1.png";

			using (var ms = new MemoryStream())
			{
				var file = File.Open(imagePath, FileMode.Open);
				file.CopyTo(ms);

				processContainer.Images = new Dictionary<string, IEnumerable<byte>>
				{
					{" ", ms.ToArray() }
				};
			}

			using (var scope = Container.BeginLifetimeScope())
			{
				var processor = scope.Resolve<IProcessor>();
				processor.Process(processContainer).Wait();
			}

			var outPath = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
				"AlmostSurely"
			);

			if (!Directory.Exists(outPath))
			{
				Directory.CreateDirectory(outPath);
			}

			File.WriteAllBytes(Path.Combine(outPath, "image.jpg"), processContainer.Images.First().Value.ToArray());
		}
	}
}