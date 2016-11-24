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
		private ManagerFlyObjects()
		{
			objects = new List<GameEngine.UI.BaseUI>();
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
		public void Dispose()
		{
			objects.Clear();
			objects = null;
		}
	}
}
