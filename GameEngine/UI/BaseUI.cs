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
		public float Angle { get; set; }
		public float VelocityAngular { get; set; }
		public System.Drawing.PointF LinearVelocity { get; set; }
		public bool IsDead { get; set; }
		public BaseUI()
		{
			IsDead = false;
		}
		public void BasicPhysicsStep(float dt)
		{
			X += LinearVelocity.X;
			Y += LinearVelocity.Y;
			Angle += VelocityAngular;
		}
	}
}
