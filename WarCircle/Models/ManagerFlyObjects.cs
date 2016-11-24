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
		private List<GameEngine.UI.BaseUI> objects;
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
		private ManagerFlyObjects()
		{
			objects = new List<GameEngine.UI.BaseUI>();
			rand = new Random();
			HZObjectGenerate = 100;
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
			Live live = new Live();
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

			objects.ForEach(o =>
			{
				o.BasicPhysicsStep(dt);
				o.Step(dt);
				o.Draw();
			});
		}
		public void GenerateRandomModel()
		{
			Console.WriteLine("Generate new object");
			if (CurrentHZGenerateObject < ConstHZGenerateObject)
				CurrentHZGenerateObject++;
			else
			{
				int idTypeObject = rand.Next(1, 4);
				float x = 100;
				float y = 100;
				float rad = 30;
				float vx = 0;
				float vy = 1;
				Color color = Color.FromArgb(100, 100, 100);
				float angle = 0;
				float angularVel = 0;

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
			objects = null;
			rand = null;
		}
	}
}
