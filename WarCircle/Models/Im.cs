using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine;
using GameEngine.UI;

namespace WarCircle.Models
{
	public class Im : BaseUI
	{
		public float Angle { get; set; }
		public float Radius { get; set; }
		public Im()
		{
			this.Radius = 20;
			this.X = Game.GetInstance().GetSettings().WindowSize.Width / 2-5;
			this.Y = Game.GetInstance().GetSettings().WindowSize.Height - Radius*2;
			this.Color = System.Drawing.Color.FromArgb(100, 100, 100);
		}
		public override void Dispose()
		{
		}

		public override void Draw()
		{
			var graphicsState = Game.GetInstance().GetGraphics().Get().Save();

			//	Game.GetInstance().GetGraphics().Get().Transform.RotateAt(Angle*180/(float)Math.PI, new System.Drawing.PointF(X - Radius, Y - Radius));
			var matrix = new System.Drawing.Drawing2D.Matrix();
			matrix.Translate(X, Y - Radius);
			matrix.RotateAt(Angle * 180 / (float)Math.PI - 160, new System.Drawing.PointF(0, Radius));
			Game.GetInstance().GetGraphics().Get().Transform = matrix;
		//	Game.GetInstance().GetGraphics().Get().RotateTransform(Angle);
			Game.GetInstance().GetGraphics().Get().FillEllipse(new System.Drawing.SolidBrush(Color),Radius, 0, Radius, Radius);
			
			Game.GetInstance().GetGraphics().Get().Restore(graphicsState);
			Game.GetInstance().GetGraphics().Get().FillEllipse(new System.Drawing.SolidBrush(Color),X - Radius, Y - Radius, Radius * 2, Radius * 2);
		}

		public override void Step(float dt)
		{
			var mouse = Game.GetInstance().GetInput().GetMouse();

			if (mouse.Item2 == MouseState.Move)
			{
				float mx = mouse.Item1.X;
				float my = mouse.Item1.Y;

				this.Angle = (float)Math.Atan2(Y - my, X - mx);
			}
			if (mouse.Item2 == MouseState.Down)
			{
				float mx = mouse.Item1.X;
				float my = mouse.Item1.Y;

				this.Angle = (float)Math.Atan2(Y - my, X - mx);

				RunBullet((float)Math.Cos(Angle), (float)Math.Sin(Angle));
			}
		}
		public void RunBullet(float vx, float vy)
		{
		}
	}
}
