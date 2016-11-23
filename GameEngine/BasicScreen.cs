using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GameEngine
{
	public abstract class BasicScreen : IDisposable
	{
		protected event EventHandler Closed;
		public bool IsEnableLight { get; set; }
		protected int AlphaScreenMask { get; set; }
		private int timePaused = 50;
		private int valVelAlphaScreenMask = 5;
		public BasicScreen()
		{
			IsEnableLight = false;
			AlphaScreenMask = 255;
		}
		public void EnableLight(bool IsEnableLight, int velAlpha, int timeout = -1)
		{
			this.IsEnableLight = IsEnableLight;
			this.valVelAlphaScreenMask = velAlpha;
			this.timePaused = timeout;
		}
		protected void DrawLight()
		{
			Game.GetInstance().GetGraphics().Get().FillRectangle(new SolidBrush(Color.FromArgb(AlphaScreenMask, 0, 0, 0)), 0, 0,
				Game.GetInstance().GetSettings().WindowSize.Width, Game.GetInstance().GetSettings().WindowSize.Height);
		}
		public void StepLight(float dt)
		{
			if (IsEnableLight)
			{
				if (AlphaScreenMask > 0)
					AlphaScreenMask -= valVelAlphaScreenMask;
				else
				{
					if (timePaused != -1)
						if (timePaused > 0)
							timePaused--;
						else IsEnableLight = false;
				}
			}
			else if (!IsEnableLight)
			{
				if (AlphaScreenMask <= 245)
					AlphaScreenMask += valVelAlphaScreenMask;
				else
				{
					if (Closed != null)
						Closed(this, null);
				}
			}
		}
		public abstract void Resume();
		public abstract void Paused();
		public abstract void Draw();
		public abstract void Step(float dt);
		public abstract void Dispose();
	}
}
