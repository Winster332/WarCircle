using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GameEngine.UI;
using GameEngine;

namespace WarCircle.Models
{
	public class Circle : BaseUI
	{

		public float Radius { get; set; }
		public Circle()
		{

		}
		public override void Dispose()
		{
		}
		public override void Draw()
		{
			Game.GetInstance().GetGraphics().Get().FillEllipse(new SolidBrush(Color), X-Radius, Y-Radius, Radius*2, Radius*2);
		}
		public override void Step(float dt)
		{
		}
	}
}
