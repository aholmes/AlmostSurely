using System;
using System.Collections.Generic;
using AlmostSurely.Models.Interfaces;

namespace AlmostSurely.Models
{
	public class Image : IImage
	{
		public string Name { get; }
		public IEnumerable<byte> Data { get; set; }

		public Image(string name, IEnumerable<byte> data)
		{
			Name = name;
			Data = data;
		}
	}
}
