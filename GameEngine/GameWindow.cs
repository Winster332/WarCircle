using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Form = System.Windows.Forms.Form;

namespace GameEngine
{
	public abstract class GameWindow : Form
	{
		protected GameWindow(string title)
		{
			this.Text = title;
			this.Paint += GameWindow_Paint;
			this.DoubleBuffered = true;
		}

		private void GameWindow_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		}

		protected abstract void Initialize();
	}
}
