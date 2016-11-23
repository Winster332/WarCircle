using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GameEngine.UI
{
	public class Button : BaseUI
	{
		public event EventHandler Click;
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
		public Font Font { get; set; }
		public float BorderThrick { get; set; }
		private StringFormat sf;
		private Point ScaleMouseMove;
		private bool IsEnable { get; set; }
		public Button()
		{
			IsEnable = true;
			Font = new System.Drawing.Font("Calibri", 14);
			Width = 250;
			Height = 40;
			Text = "TEXT";
			BackgroundColor = Color.FromArgb(100, 100, 100);
			ForeColor = Color.FromArgb(100, 100, 100);
			sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;
			BorderThrick = 5;
			ScaleMouseMove = new Point(5, 5);
		}
		public override void Dispose()
		{
		}

		public override void Draw()
		{
			Game.GetInstance().GetGraphics().Get().DrawRectangle(new Pen(BackgroundColor, BorderThrick),
				this.X - ScaleMouseMove.X - this.Width / 2, this.Y - ScaleMouseMove.Y - this.Height / 2, 
				this.Width + ScaleMouseMove.X * 2, this.Height + ScaleMouseMove.Y * 2);
			Game.GetInstance().GetGraphics().Get().DrawString(Text, Font, new SolidBrush(ForeColor), X, Y, sf);
		}

		public override void Step(float dt)
		{
			if (IsEnable)
			{
				var mouse = Game.GetInstance().GetInput().GetMouse();

				if (mouse.Item2 == MouseState.Move)
				{
					float mx = mouse.Item1.X;
					float my = mouse.Item1.Y;

					if (mx >= this.X - this.Width / 2 && mx <= this.X + this.Width / 2 &&
						my >= this.Y - this.Height / 2 && my <= this.Y + this.Height / 2)
					{
						ScaleMouseMove.X = 5;
						ScaleMouseMove.Y = 3;
					}
					else
					{
						ScaleMouseMove.X = 0;
						ScaleMouseMove.Y = 0;
					}
				}
				else if (mouse.Item2 == MouseState.Down)
				{
					if (Click != null)
						Click(this, null);
				}
			}
		}
	}
}
