﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GameEngine;
using GameEngine.UI;

namespace WarCircle.Screens
{
	public class ScreenGame : BasicScreen
	{
		public event EventHandler IntentTo;
		private Button buttonToMenu;
		private UIText textBall;
		private UIText textLive;
		private Models.Im im;
		private int currentBall;
		private int currentLive;
		public override void Dispose()
		{
			buttonToMenu.Dispose();
			buttonToMenu = null;
			textBall.Dispose();
			textBall = null;
			im.Dispose();
			im = null;
			textLive.Dispose();
			textLive = null;
			currentBall = 0;
			currentLive = 0;
		}
		public override void Draw()
		{
			buttonToMenu.Draw();
			textBall.Draw();
			textLive.Draw();

			Models.ManagerFlyObjects.GetInstance().DrawAndUpdate();
			Game.GetInstance().GetSystemParticles().Draw();

			im.Draw();

			DrawLight();
		}
		public override void Paused()
		{
		}
		public override void Resume()
		{
			#region setup
			IsEnableLight = false;
			AlphaScreenMask = 255;
			Closed += (screen, e) => { IntentTo(this, e); };
			this.EnableLight(true, 5);
			Console.WriteLine("show game screen");
			buttonToMenu = new Button();
			buttonToMenu.Width = 65;
			buttonToMenu.Height = 25;
			buttonToMenu.Text = "МЕНЮ";
			buttonToMenu.X = buttonToMenu.Width - 30;
			buttonToMenu.Y = buttonToMenu.Height - 10;
			buttonToMenu.MouseScaleBorder = new Point(-3,-2);
			buttonToMenu.BorderThrick = 1;
			buttonToMenu.Click += (o, e) => { IntentTo(this, null); };

			textBall = new UIText();
			textBall.X = Game.GetInstance().GetSettings().WindowSize.Width - 50;
			textBall.Y = 15;
			textBall.ForeColor = Color.FromArgb(100, 100, 100);
			textBall.Text = "0";

			textLive = new UIText();
			textLive.X = Game.GetInstance().GetSettings().WindowSize.Width / 2;
			textLive.Y = 15;
			textLive.ForeColor = Color.FromArgb(100, 100, 100);
			textLive.Text = "3";
			#endregion

			currentBall = 0;
			currentLive = 3;
			im = new Models.Im();
			Models.ManagerFlyObjects.GetInstance().SetIm(im);
			Models.ManagerFlyObjects.GetInstance().DeadObject += (o, e) =>
			{
				currentBall++;
			};
		}
		public override void Step(float dt)
		{
			Game.GetInstance().GetSystemParticles().Step(dt);
			StepLight(dt);

			im.Step(dt);
			Models.ManagerFlyObjects.GetInstance().GenerateRandomModel();
			buttonToMenu.Step(dt);

			if (textLive != null)
			{
				textLive.Step(dt);
				textLive.Text = currentLive.ToString();
			}
			if (textBall != null)
			{
				textBall.Step(dt);
				textBall.Text = currentBall.ToString();
			}
		}
	}
}
