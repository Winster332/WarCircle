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
		GameEngine.UI.Button b;
		public override void Dispose()
		{
		}
		public override void Draw()
		{
			t.Draw();
			b.Draw();
		}
		public override void Paused()
		{
		}
		public override void Resume()
		{
			t = new GameEngine.UI.TextBox();
			t.X = Game.GetInstance().GetSettings().WindowSize.Width / 2;
			t.Y = Game.GetInstance().GetSettings().WindowSize.Height / 2;

			b = new GameEngine.UI.Button();
			b.X = Game.GetInstance().GetSettings().WindowSize.Width / 2;
			b.Y = Game.GetInstance().GetSettings().WindowSize.Height / 2-50;
		}
		public override void Step(float dt)
		{
			x += 1 * dt;
			t.Step(dt);
			b.Step(dt);
			var keys = Game.GetInstance().GetInput().GetKeyboardDown();
		//	Console.WriteLine(keys.Count);
            for (int i = 0; i < keys.Count; i++)
			{
				if (keys[i] == System.Windows.Forms.Keys.Escape)
					System.Windows.Forms.Application.Exit();
			}
		}
	}
}
