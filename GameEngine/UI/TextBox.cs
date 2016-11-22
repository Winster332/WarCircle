using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = System.Drawing.Color;

namespace GameEngine.UI
{
	public class TextBox : BaseUI
	{
		public event EventHandler ClickEnter;
		public new float Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				base.Width = value;
			}
		}
		public new float Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = value;
			}
		}
		public string Text { get; set; }
		public Color BackgroundColor
		{
			get
			{
				return base.Color;
			}
			set
			{
				base.Color = value;
			}
		}
		public Color ForeColor { get; set; }
		public System.Drawing.Font Font { get; set; }
		private System.Drawing.StringFormat sf;
		public TextBox()
		{
			Font = new System.Drawing.Font("Calibri", 14);
			Width = 250;
			Height = 40;
			Text = "TEXT";
			BackgroundColor = Color.FromArgb(100, 100, 100);
			ForeColor = Color.FromArgb(50, 50, 50);
			sf = new System.Drawing.StringFormat();
			sf.Alignment = System.Drawing.StringAlignment.Center;
			sf.LineAlignment = System.Drawing.StringAlignment.Center;
		}
		public override void Dispose()
		{
		}
		public override void Draw()
		{
			Game.GetInstance().GetGraphics().Get().FillRectangle(new System.Drawing.SolidBrush(BackgroundColor), this.X - this.Width / 2, this.Y - this.Height / 2, this.Width, this.Height);
			Game.GetInstance().GetGraphics().Get().DrawString(Text, Font, new System.Drawing.SolidBrush(ForeColor), X, Y, sf);
		}
		public override void Step(float dt)
		{
			var keys = Game.GetInstance().GetInput().GetKeyboardDown();

			if (keys.Count > 0)
			{
				if (keys[0] == System.Windows.Forms.Keys.Back)
				{
					if (Text.Length != 0)
						Text = Text.Substring(0, Text.Length - 1);
				}
				else if (keys[0] == System.Windows.Forms.Keys.Enter)
				{
					if (ClickEnter != null)
						ClickEnter(this, null);
				}
				else if (keys[0] != System.Windows.Forms.Keys.Oemtilde &&
					keys[0] != System.Windows.Forms.Keys.ControlKey &&
					keys[0] != System.Windows.Forms.Keys.ShiftKey &&
					keys[0] != System.Windows.Forms.Keys.Menu &&
					keys[0] != System.Windows.Forms.Keys.LWin &&
					keys[0] != System.Windows.Forms.Keys.Oem5 &&
					keys[0] != System.Windows.Forms.Keys.OemMinus &&
					keys[0] != System.Windows.Forms.Keys.Oemplus &&
					keys[0] != System.Windows.Forms.Keys.Tab &&
					keys[0] != System.Windows.Forms.Keys.CapsLock) Text += keys[0];
			}
		}
	}
}
