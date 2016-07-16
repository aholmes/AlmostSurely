using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using AlmostSurely.Models.Interfaces;

namespace AlmostSurely.Models
{
	[DataContract]
	public abstract class ImageBase : IImage
	{
		[DataMember]
		public string Name { get; }
		[DataMember]
		public byte[] Data { get; set; }

		public ImageBase(string name, byte[] data)
		{
			Name = name;
			Data = data;
		}
	}
}
