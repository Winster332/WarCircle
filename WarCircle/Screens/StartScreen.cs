﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GameEngine;

namespace WarCircle.Screens
{
	public class StartScreen : BasicScreen
	{
		private StringFormat sf = new StringFormat();
		public event EventHandler IntentTo;
		public override void Dispose()
		{
		}
		public override void Draw()
		{
			Game.GetInstance().GetGraphics().Get().DrawString("War Circle", new Font("Calibri", 25), new SolidBrush(Color.FromArgb(180, 50, 50, 50)),
				Game.GetInstance().GetSettings().WindowSize.Width / 2, Game.GetInstance().GetSettings().WindowSize.Height / 2 - 50, sf);
			Game.GetInstance().GetSystemParticles().Draw();

			DrawLight();
		}
		public override void Paused()
		{
		}
		public override void Resume()
		{
			Closed += (screen, e) => { IntentTo(this, e); };
			this.EnableLight(true, 5, 10);
			//	t = new GameEngine.UI.TextBox();
			//	t.X = Game.GetInstance().GetSettings().WindowSize.Width / 2;
			//	t.Y = Game.GetInstance().GetSettings().WindowSize.Height / 2;

			//	b = new GameEngine.UI.Button();
			//	b.X = Game.GetInstance().GetSettings().WindowSize.Width / 2;
			//	b.Y = Game.GetInstance().GetSettings().WindowSize.Height / 2-50;
			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;

			Random random = new Random();

			for (int i = 0; i < 10; i++)
				Game.GetInstance().GetSystemParticles().AddOnFon(Game.GetInstance().GetSettings().WindowSize.Width / 2 * (float)random.NextDouble(),
					Game.GetInstance().GetSettings().WindowSize.Height / 2 * (float)random.NextDouble(), new PointF(1.0f / random.Next(-20, 20), 1.0f / random.Next(-20, 20)));
		}
		public override void Step(float dt)
		{
			StepLight(dt);
			Game.GetInstance().GetSystemParticles().Step(dt);

			//	t.Step(dt);
			//	b.Step(dt);
			//	var keys = Game.GetInstance().GetInput().GetKeyboardDown();
			////	Console.WriteLine(keys.Count);
			//          for (int i = 0; i < keys.Count; i++)
			//	{
			//		if (keys[i] == System.Windows.Forms.Keys.Escape)
			//			System.Windows.Forms.Application.Exit();
			//	}
			//	var mouse = Game.GetInstance().GetInput().GetMouse();

			//	if (mouse.Item2 == MouseState.Move)
			//	{

			//	}
		}
	}
}
