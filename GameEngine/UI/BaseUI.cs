using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.UI
{
	public abstract class BaseUI : IDisposable
	{
		public float X { get; set; }
		public float Y { get; set; }
		public System.Drawing.Color Color { get; set; }
		protected float Width { get; set; }
		protected float Height { get; set; }
		public abstract void Step(float dt);
		public abstract void Draw();
		public abstract void Dispose();
	}
}
