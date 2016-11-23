using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GameEngine;
using GameEngine.UI;

namespace WarCircle.Screens
{
	public class ScreenMenu : BasicScreen
	{
		public event EventHandler IntentTo;
		private Button buttonPlay;
		private StringFormat sf;
		public override void Dispose()
		{
			buttonPlay.Dispose();
			sf.Dispose();
			buttonPlay = null;
			sf = null;
		}
		public override void Step(float dt)
		{
			Game.GetInstance().GetSystemParticles().Step(dt);

			buttonPlay.Step(dt);

			StepLight(dt);
		}
		public override void Draw()
		{
			Game.GetInstance().GetGraphics().Get().DrawString(Game.GetInstance().GetSettings().InfoUser.Record.ToString(), 
				new Font("Calibri", 55), new SolidBrush(Color.FromArgb(180, 50, 50, 50)),
				Game.GetInstance().GetSettings().WindowSize.Width / 2, Game.GetInstance().GetSettings().WindowSize.Height / 2 - 100, sf);

			Game.GetInstance().GetSystemParticles().Draw();

			buttonPlay.Draw();

			DrawLight();
		}

		public override void Paused()
		{
		}

		public override void Resume()
		{
			IsEnableLight = false;
			AlphaScreenMask = 255;
			Closed += (screen, e) => { IntentTo(this, e); };
			this.EnableLight(true, 5);

			sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;

			buttonPlay = new Button();
			buttonPlay.X = Game.GetInstance().GetSettings().WindowSize.Width / 2;
			buttonPlay.Y = Game.GetInstance().GetSettings().WindowSize.Height / 2 + 50;
			buttonPlay.BorderThrick = 3;
			buttonPlay.Click += (o, e) => {	IntentTo(new ScreenGame(), null); };
			buttonPlay.Text = "ИГРАТЬ";
		}
	}
}
