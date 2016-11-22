using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
	public class ImplamentGraphics : IGraphics
	{
		private System.Drawing.Graphics g;
		private System.Drawing.Color color;

		public ImplamentGraphics()
		{
			color = Color.FromArgb(192, 192, 192);
		}
		public void Dispose()
		{
			g = null;
		}
		public Graphics Get()
		{
			return g;
		}

		public Color GetClearColor()
		{
			return color;
		}

		public void Set(Graphics g)
		{
			this.g = g;
		}

		public void SetColorClear(Color color)
		{
			this.color = color;
		}
	}
}
