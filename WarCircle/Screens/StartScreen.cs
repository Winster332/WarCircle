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
		GameEngine.UI.TextBox t;
		public override void Dispose()
		{
		}
		public override void Draw()
		{
			t.Draw();
		}
		public override void Paused()
		{
		}
		public override void Resume()
		{
			t = new GameEngine.UI.TextBox();
			t.X = Game.GetInstance().GetSettings().WindowSize.Width / 2;
			t.Y = Game.GetInstance().GetSettings().WindowSize.Height / 2;
		}
		public override void Step(float dt)
		{
			x += 1 * dt;

			var keys = Game.GetInstance().GetInput().GetKeyboardDown();
            for (int i = 0; i < keys.Count; i++)
			{
				if (keys[i] == System.Windows.Forms.Keys.Escape)
					System.Windows.Forms.Application.Exit();
			}
		}
	}
}
