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

namespace AlmostSurely.Processors
{
	public class ProcessContainer : IProcessContainer
	{
		public Size Dimensions { get; private set; } = new Size();
		public ICollection<IImage> Images { get; } = new ObservableCollection<IImage>();

		public ProcessContainer()
		{
			(Images as INotifyCollectionChanged).CollectionChanged += Images_CollectionChanged;
		}

		private void Images_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action != NotifyCollectionChangedAction.Add) return;

			foreach(IImage newItem in e.NewItems)
			{
				using (var bitmap = newItem.Data.ToBitmap())
				{
					if (bitmap.Size.Width > Dimensions.Width)
					{
						Dimensions = new Size(bitmap.Size.Width, Dimensions.Height);
					}

					if (bitmap.Size.Height > Dimensions.Height)
					{
						Dimensions = new Size(Dimensions.Width, bitmap.Size.Height);
					}
				}
			}
		}
	}
}
