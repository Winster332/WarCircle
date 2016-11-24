using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine;
using GameEngine.UI;

namespace WarCircle.Models
{
	public class Triangle : BaseUI
	{
		public float Radius
		{
			get
			{
				return _Radius;
			}
			set
			{
				points[0] = new System.Drawing.PointF(0, -value);
				points[1] = new System.Drawing.PointF(value, value);
				points[2] = new System.Drawing.PointF(-value, value);

				_Radius = value;
			}
		}
		private float _Radius;
		private System.Drawing.PointF[] points;
        public override void Dispose()
		{
		}
		public Triangle()
		{
			points = new System.Drawing.PointF[3];
		}
		public override void Draw()
		{
			var graphicsState = Game.GetInstance().GetGraphics().Get().Save();
			System.Drawing.Drawing2D.Matrix m = new System.Drawing.Drawing2D.Matrix();
			m.Translate(X, Y);
			Game.GetInstance().GetGraphics().Get().Transform = m;
			Game.GetInstance().GetGraphics().Get().FillPolygon(new System.Drawing.SolidBrush(Color), points);
			Game.GetInstance().GetGraphics().Get().Restore(graphicsState);
		}
		public override void Step(float dt)
		{
		}
	}
}
