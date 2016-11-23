using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GameEngine.Engine
{
	public class ImplamentSystemParticles : ISystemParticles
	{
		public void Dispose()
		{
		}
		public List<Particle> particles;
		private Random rand;
		public float width;
		public float height;
		public ImplamentSystemParticles(float width, float height)
		{
			this.width = width;
			this.height = height;
			particles = new List<Particle>();
			rand = new Random();
		}
		public void Step(float dt)
		{
			particles.ForEach(p1 =>
			{
				p1.Step(dt);

				if (p1.Position.X <= 1 || p1.Position.X >= width - 20)
					p1.Velocity.X *= -1;
				if (p1.Position.Y <= 1 || p1.Position.Y >= height - 40)
					p1.Velocity.Y *= -1;

				
			});
		}
		public void Draw()
		{
			particles.ForEach(p1 =>
			{
				p1.Draw();

				particles.ForEach(p2 =>
				{
					if (p1 != p2)
					{
						float distance = (float)Math.Sqrt(Math.Pow(p1.Position.X - p2.Position.X, 2) +
							Math.Pow(p1.Position.Y - p2.Position.Y, 2));

						if (distance <= 100)
						{
							if ((int)distance >= 5)
							{
								Game.GetInstance().GetGraphics().Get().DrawLine(new Pen(Color.FromArgb(101-(int)distance, 100, 50, 50), 1.0f),
									p1.Position, p2.Position);
							}
						}
					}
				});
			});
		}
		public void AddOnFon(float x, float y, System.Drawing.PointF vel)
		{
			float rad = (float)rand.Next(10, 20) / 10;
			particles.Add(new Particle(x, y, rad, System.Drawing.Color.FromArgb(100, 50,50,50), vel));
		}

		public class Particle
		{
			public float Radius { get; set; }
			public PointF Position;
			public Color Color { get; set; }
			public PointF Velocity;
			public Particle(float x, float y, float rad, Color color, PointF velocity)
			{
				this.Radius = rad;
				this.Position = new PointF(x, y);
				this.Color = color;
				this.Velocity = velocity;
			}
			public void Step(float dt)
			{
				this.Position.X += Velocity.X * dt;
				this.Position.Y += Velocity.Y * dt;
			}
			public void Draw()
			{
				Game.GetInstance().GetGraphics()
					.Get().FillEllipse(new SolidBrush(this.Color), Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2);
			}
		}
	}
}
