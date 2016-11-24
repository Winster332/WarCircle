using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine;
using System.Drawing;
using GameEngine.UI;

namespace WarCircle.Models
{
	public class Bullet : BaseUI
	{
		public override void Dispose()
		{
		}
		public override void Draw()
		{
		}
		public override void Step(float dt)
		{
			Game.GetInstance().GetGraphics().Get().FillEllipse(new SolidBrush(Color), X - Radius, Y - Radius, Radius * 2, Radius * 2);
		}
	}
}
