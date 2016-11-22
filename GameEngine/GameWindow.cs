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
		protected GameWindow(string title)
		{
			this.Text = title;
			this.Paint += GameWindow_Paint;
			this.DoubleBuffered = true;
			
			Initialize();
		}

		private void GameWindow_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			
		}

		public void SetSettings(AppSettings settings)
		{
			this.Size = settings.WindowSize;
			this.DoubleBuffered = settings.IsDoubleBuffer;
			this.UpdateFrames = settings.UpdateFrames;
		}

		protected abstract void Initialize();
	}
}
