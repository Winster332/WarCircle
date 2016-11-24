using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Rectangle = WarCircle.Models.Rectangle;

namespace WarCircle.Models
{
	public class ManagerFlyObjects : IDisposable
	{
		public event EventHandler DeadObject;
		public event EventHandler DecrementLive;
		private List<GameEngine.UI.BaseUI> objects;
		private Models.Im im;
		private static ManagerFlyObjects instance;
		private Random rand;
		private int ConstHZGenerateObject;
		private int CurrentHZGenerateObject;
		public int HZObjectGenerate {
			get
			{
				return ConstHZGenerateObject;
			}
			set
			{
				ConstHZGenerateObject = value;
			}
		}
		public void SetIm(Im im)
		{
			this.im = im;
		}
		private ManagerFlyObjects()
		{
			objects = new List<GameEngine.UI.BaseUI>();
			rand = new Random();
			HZObjectGenerate = 50;
			CurrentHZGenerateObject = 0;
		}
		public static ManagerFlyObjects GetInstance()
		{
			if (instance == null)
				instance = new ManagerFlyObjects();
			return instance;
		}
		public void AddRect(float x, float y, float size, Color color, float angle, float velAngle, float vx, float vy)
		{
			Rectangle rect = new Rectangle();
			rect.X = x;
			rect.Y = y;
			rect.Radius = size;
			rect.Color = color;
			rect.Angle = angle;
			rect.VelocityAngular = velAngle;
			rect.LinearVelocity = new PointF(vx, vy);

			objects.Add(rect);
		}
		public void AddCircle(float x, float y, float radius, Color color, float vx, float vy)
		{
			Circle circle = new Circle();
			circle.X = x;
			circle.Y = y;
			circle.Radius = radius;
			circle.Color = color;
			circle.LinearVelocity = new PointF(vx, vy);

			objects.Add(circle);
		}
		public void AddLive(float x, float y, float size, Color color, float angle, float velAngle, float vx, float vy)
		{
			Triangle live = new Triangle();
			live.X = x;
			live.Y = y;
			live.Radius = size;
			live.Color = color;
			live.LinearVelocity = new PointF(vx, vy);
			live.Angle = angle;
			live.VelocityAngular = velAngle;

			objects.Add(live);
		}
		public void DrawAndUpdate()
		{
			float dt = 1;

			for (int j = 0; j < objects.Count; j++)
			{
				var o = objects[j];

				o.BasicPhysicsStep(dt);
				o.Step(dt);

				GameEngine.Game.GetInstance().GetSystemParticles().AddOnEffectFair(o.X, o.Y);

				if (o.Y >= GameEngine.Game.GetInstance().GetSettings().WindowSize.Height - 20)
				{
					if (DecrementLive != null)
						DecrementLive(null, null);
					objects.RemoveAt(j);
				}

				o.Draw();

				for (int i = 0; i < im.GetBullets().Count; i++)
				{
					var b = im.GetBullets()[i];
					var distance = (float)Math.Sqrt(Math.Pow(b.X - o.X, 2) + Math.Pow(b.Y - o.Y, 2));

					if (distance <= b.Radius + o.Radius)
					{
						b.IsDead = true;
						o.IsDead = true;

						if (DeadObject != null)
							DeadObject(null, null);
					}
				}

				if (o.IsDead)
					objects.RemoveAt(j);
			}
		}
		public void GenerateRandomModel()
		{
			if (CurrentHZGenerateObject < ConstHZGenerateObject)
				CurrentHZGenerateObject++;
			else
			{
				int idTypeObject = rand.Next(1, 4);
				float x = rand.Next(20, GameEngine.Game.GetInstance().GetSettings().WindowSize.Width - 40);
				float y = -50;
				float rad = rand.Next(10, 20);
				float vx = 0;
				float vy = (float)rand.Next(10, 30) / 10.0f;
				Color color = Color.FromArgb(rand.Next(100, 200), rand.Next(100, 200), rand.Next(100, 200));
				float angle = rand.Next(0, 180);
				float angularVel = (float)rand.Next(-10, 10) / 10.0f;

				Console.WriteLine("Generate new object " + vy);
				switch (idTypeObject)
				{
					case 1: AddCircle(x, y, rad, color, vx, vy); break;
					case 2: AddRect(x, y, rad, color, angle, angularVel, vx, vy); break;
					case 3: AddLive(x, y, rad, color, angle, angularVel, vx, vy); break;
				}
				CurrentHZGenerateObject = 0;
			}
		}
		public void Dispose()
		{
			objects.Clear();
		}
	}
}
