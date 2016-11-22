using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GameEngine;

namespace WarCircle.Screens
{
	public class StartScreen : BasicScreen
	{
		float x = 0;
		public override void Dispose()
		{
		}
		public override void Draw()
		{
			Game.GetInstance().GetGraphics().Get().DrawLine(new Pen(Color.Gray, 5), 100+x, 100, 100, 200);
		}
		public override void Paused()
		{
		}
		public override void Resume()
		{
		}
		public override void Step(float dt)
		{
			x += 1 * dt;
		}
	}
}
