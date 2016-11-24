using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine;
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
			Game.GetInstance().GetGraphics().Get().FillRectangle(new System.Drawing.SolidBrush(Color), X - Radius, Y - Radius, Radius * 2, Radius * 2);
		}
		public override void Step(float dt)
		{
		}
	}
}
