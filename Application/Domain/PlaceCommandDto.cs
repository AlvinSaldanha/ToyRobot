using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
	public class PlaceCommandDto
	{
		public int X { get; set; }
		public int Y { get; set; }
		public Direction? Direction { get; set; }
	}
}
