using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Form = System.Windows.Forms.Form;

namespace GameEngine
{
	public abstract class GameWindow : Form
	{
		private int UpdateFrames;
		private int CurrentFrame;
		protected GameWindow(string title)
		{
			this.Text = title;
			this.Paint += GameWindow_Paint;
			this.DoubleBuffered = true;
			this.CurrentFrame = 0;

			Console.WriteLine(Game.GetInstance().GetSettings().UpdateFrames);

			this.FormClosed += GameWindow_Disposed;

			Initialize();
		}

		private void GameWindow_Disposed(object sender, EventArgs e)
		{
			Game.GetInstance().Dispose();
		}

		private void GameWindow_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			var graphics = e.Graphics;
			graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			Game.GetInstance().GetGraphics().Set(graphics);

			if (CurrentFrame == UpdateFrames)
			{
				Game.GetInstance().Step(1f);
				Update(1f);
				
				this.CurrentFrame = 0;
			}

			graphics.Clear(Game.GetInstance().GetGraphics().GetClearColor());
			Game.GetInstance().Draw();
			Drawing();

			CurrentFrame++;

			this.Invalidate();
		}

		public void SetSettings(AppSettings settings)
		{
			this.Size = settings.WindowSize;
			this.DoubleBuffered = settings.IsDoubleBuffer;
			this.UpdateFrames = settings.UpdateFrames;
		}
		protected abstract void Update(float dt);
		protected abstract void Drawing();
		protected abstract void Initialize();
	}
}
