using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GameEngine.UI
{
	public class UIText : BaseUI
	{
		public event EventHandler ClickEnter;
		public string Text { get; set; }
		public Color ForeColor { get; set; }
		public System.Drawing.Font Font { get; set; }
		private System.Drawing.StringFormat sf;
		public UIText()
		{
			Font = new System.Drawing.Font("Calibri", 14);
			Width = 250;
			Height = 40;
			Text = "TEXT";
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
			Game.GetInstance().GetGraphics().Get().DrawString(Text, Font, new System.Drawing.SolidBrush(ForeColor), X, Y, sf);
		}

		public override void Step(float dt)
		{
		}
	}
}
