using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.UI;

namespace WarCircle.Models
{
	public class Rectangle : BaseUI
	{
		public float Radius { get; set; }
		public override void Dispose()
		{
			Radius = 10;
		}
		public override void Draw()
		{
		}
		public override void Step(float dt)
		{
		}
	}
}
