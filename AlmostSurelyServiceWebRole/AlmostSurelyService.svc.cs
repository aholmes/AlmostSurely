using AlmostSurely.Models.Interfaces;
using AlmostSurely.Processors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AlmostSurely.Processors.Event;
using System.IO;

namespace AlmostSurelyServiceWebRole
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlmostSurelyService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select AlmostSurelyService.svc or AlmostSurelyService.svc.cs at the Solution Explorer and start debugging.
	public class AlmostSurelyService : IAlmostSurelyService
	{
		private IProcessor _processor;

		public AlmostSurelyService(IProcessor processor)
		{
			_processor = processor;
			_processor.ImageProcessed += Processor_ImageProcessed;
		}

		public void GetData(IProcessContainer container)
		{
			_processor.Process(container);
		}

		public CompositeType GetDataUsingDataContract(CompositeType composite)
		{
			if (composite == null)
			{
				throw new ArgumentNullException("composite");
			}
			if (composite.BoolValue)
			{
				composite.StringValue += "Suffix";
			}
			return composite;
		}

		private static void Processor_ImageProcessed(ImageProcessedEventArgs e)
		{
			var outputPath = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
				"AlmostSurely"
			);

			if (!Directory.Exists(outputPath))
			{
				Directory.CreateDirectory(outputPath);
			}

			e.Image.Save(Path.Combine(outputPath, "image.jpg"));

			e.Image.Dispose();
		}
	}
}
