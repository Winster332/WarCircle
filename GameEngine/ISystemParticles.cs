using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
	public interface ISystemParticles : IDisposable
	{
		void Step(float dt);
		void Draw();
		void AddOnFon(float x, float y, System.Drawing.PointF vel);
		void AddOnEffectFair(float x, float y);
    }
}
