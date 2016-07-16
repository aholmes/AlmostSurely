using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using AlmostSurely.Models.Interfaces;

namespace AlmostSurely.Models
{
	public class Image : ImageBase
	{
		public Image(string name, byte[] data)
			:base(name, data)
		{

		}
	}
}
