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
		public System.Windows.Forms.Timer timer;
		protected GameWindow(string title)
		{
			this.Text = title;
			this.Paint += GameWindow_Paint;
			this.DoubleBuffered = true;
			this.timer = new System.Windows.Forms.Timer();
			this.timer.Tick += Timer_Tick;
			this.timer.Interval = Game.GetInstance().GetSettings().UpdateFrames;

			this.FormClosed += GameWindow_Disposed;

			this.MouseDown += (o, e) => { Game.GetInstance().GetInput().SetMouse(e, MouseState.Down); };
			this.MouseMove += (o, e) => { Game.GetInstance().GetInput().SetMouse(e, MouseState.Move); };
			this.MouseUp += (o, e) => { Game.GetInstance().GetInput().SetMouse(e, MouseState.Up); };

			this.KeyDown += (o, e) => { Game.GetInstance().GetInput().SetKeyboardDown(e.KeyCode); };
			this.KeyUp += (o, e) => { Game.GetInstance().GetInput().SetKeyboardUp(e.KeyCode); };

			Initialize();

			timer.Start();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			this.Invalidate();
		}

		private void GameWindow_Disposed(object sender, EventArgs e)
		{
			Game.GetInstance().Dispose();
		}
		private void GameWindow_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			var graphics = e.Graphics;
			var dt = 1f;
			graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			Game.GetInstance().GetGraphics().Set(graphics);

			Game.GetInstance().Step(dt);
			Update(dt);

			graphics.Clear(Game.GetInstance().GetGraphics().GetClearColor());
			Game.GetInstance().Draw();
			Drawing();
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
