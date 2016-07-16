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
using CommandLine;
using AlmostSurely.Models;

namespace AlmostSurely.Utilities.Console
{
	class Program
	{
		private static IContainer Container { get; set; }
		private static ArgsModel options { get; set; }

		private static void Initialize()
		{
			var builder = new ContainerBuilder();
			builder.RegisterModule(new ProcessorModule());
			builder.RegisterModule(new FilterModule());
			Container = builder.Build();
		}

		private static void Main(string[] args)
		{
			Initialize();

			options = new ArgsModel();
			var result = Parser.Default.ParseArguments(args, options);

			if (string.IsNullOrEmpty(options.OutputPath))
			{
				options.OutputPath = Path.Combine(
					Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
					"AlmostSurely"
				);
			}

			var imagePaths = options.Images.Split(',');

			var processContainer = new Processors.ProcessContainer();

			using (var ms = new MemoryStream())
			{
				foreach(var imagePath in imagePaths)
				{
					ms.Seek(0, SeekOrigin.Begin);
					var file = File.Open(imagePath, FileMode.Open);
					file.CopyTo(ms);

					processContainer.Images.Add(new Image(imagePath, ms.ToArray()));
				}
			}

			//ProcessImagesInternally(options, imagePaths);
			var client = new AlmostSurelyServiceReference.AlmostSurelyServiceClient();
			client.GetNewImages(processContainer);
		}

		private static void ProcessImagesInternally(ArgsModel options, string[] imagePaths)
		{
			var processContainer = new Processors.ProcessContainer();

			using (var ms = new MemoryStream())
			{
				foreach(var imagePath in imagePaths)
				{
					ms.Seek(0, SeekOrigin.Begin);
					var file = File.Open(imagePath, FileMode.Open);
					file.CopyTo(ms);

					processContainer.Images.Add(new Image(imagePath, ms.ToArray()));
				}
			}

			using (var scope = Container.BeginLifetimeScope())
			{
				var processor = scope.Resolve<IProcessor>();

				processor.ImageProcessed += Processor_ImageProcessed;

				processor.Process(processContainer).Wait();
			}
		}

		private static void Processor_ImageProcessed(Processors.Event.ImageProcessedEventArgs e)
		{
			if (!Directory.Exists(options.OutputPath))
			{
				Directory.CreateDirectory(options.OutputPath);
			}

			e.Image.Save(Path.Combine(options.OutputPath, "image.jpg"));

			e.Image.Dispose();
		}
	}
}