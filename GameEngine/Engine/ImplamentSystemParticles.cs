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
			particles.Clear();
			particles = null;
			rand = null;
		}
		public List<ParticleBackground> particles;
		public List<ParticleEffect> particlesEffect;
		private Random rand;
		public float width;
		public float height;
		public ImplamentSystemParticles(float width, float height)
		{
			this.width = width;
			this.height = height;
			particles = new List<ParticleBackground>();
			particlesEffect = new List<ParticleEffect>();
			rand = new Random();
		}
		public void Step(float dt)
		{
		}
		public void Draw()
		{
			particles.ForEach(p1 =>
			{
				p1.Step(1);

				if (p1.Position.X <= 1 || p1.Position.X >= width - 20)
					p1.Velocity.X *= -1;
				if (p1.Position.Y <= 1 || p1.Position.Y >= height - 40)
					p1.Velocity.Y *= -1;

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
			for (int i = 0; i < particlesEffect.Count; i++)
			{
				particlesEffect[i].Step(1f);
				particlesEffect[i].Draw();

				if (particlesEffect[i].IsDead)
					particlesEffect.RemoveAt(i);
			}
		}
		public void AddOnFon(float x, float y, PointF vel)
		{
			float rad = (float)rand.Next(10, 20) / 10;
			particles.Add(new ParticleBackground(x, y, rad, Color.FromArgb(100, 50,50,50), vel));
		}
		public void AddOnEffectFair(float x, float y)
		{
			for (int i = 0; i < 1; i++)
			{
				PointF vel = GetV2(x, y, rand.Next(7, 15) / 10.0f);
				float rad = (float)rand.Next(1, 5);
				int alpha = 255;
				int velAlpha = 5;
				float velrad = 0.05f;
				Color color = Color.FromArgb(200, 100, 100);
				particlesEffect.Add(new ParticleEffect(x, y, rad, color, vel, alpha, velAlpha, velrad));
			}
			for (int i = 0; i < 1; i++)
			{
				PointF vel = GetV2(x, y, rand.Next(7, 15) / 10.0f);
				float rad = (float)rand.Next(5, 10);
				int alpha = 255;
				int velAlpha = 5;
				float velrad = 0.1f;
				Color color = Color.FromArgb(100, 100, 200);
				particlesEffect.Add(new ParticleEffect(x, y, rad, color, vel, alpha, velAlpha, velrad));
			}
		}
		public PointF GetV2(float x, float y, float length)
		{
			PointF r = new PointF();

			r.X = (float)Math.Cos(x * length);
			r.Y = (float)Math.Sin(y * length);

			return r;
		}
		public class ParticleEffect : ParticleBackground
		{
			public int velAlpha;
			public int AlphaColor;
			public float VelacityRadius;
			public ParticleEffect(float x, float y, float rad, Color color, PointF velocity, int Alpha, int velAlpha, float VelRad) : base(x, y, rad, color, velocity)
			{
				this.AlphaColor = Alpha;
				this.velAlpha = velAlpha;
				this.VelacityRadius = VelRad;
			}
			public new void Step(float dt)
			{
				this.Position.X += Velocity.X * dt;
				this.Position.Y += Velocity.Y * dt;

				if (this.AlphaColor > 1)
					AlphaColor -= velAlpha;
				else IsDead = true;

				if (Radius > 2)
					Radius -= VelacityRadius;
				else IsDead = true;
			}
			public new void Draw()
			{
				Game.GetInstance().GetGraphics()
					.Get().FillEllipse(new SolidBrush(Color.FromArgb(AlphaColor, this.Color)), Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2);
			}
		}
		public class ParticleBackground
		{
			public bool IsDead;
			public float Radius { get; set; }
			public PointF Position;
			public Color Color { get; set; }
			public PointF Velocity;
			public ParticleBackground(float x, float y, float rad, Color color, PointF velocity)
			{
				this.Radius = rad;
				this.Position = new PointF(x, y);
				this.Color = color;
				this.Velocity = velocity;
				IsDead = false;
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
