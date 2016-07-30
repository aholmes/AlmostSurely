using AlmostSurely.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.IO;
using System.ComponentModel;
using System.Collections.ObjectModel;
using AlmostSurely.Extensions;
using System.Runtime.Serialization;
using AlmostSurely.Models;

namespace AlmostSurely.Processors
{
	[DataContract]
	public abstract class ProcessContainerBase : IProcessContainer
	{
		[DataMember]
		public Size Dimensions { get; set; } = new Size();
		[DataMember]
		public Collection<ImageBase> Images { get; set; } = new ObservableCollection<ImageBase>();

		ICollection<IImage> IProcessContainer.Images => Images as ICollection<IImage>;
	}
}
