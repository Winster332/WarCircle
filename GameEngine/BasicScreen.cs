using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
	public abstract class BasicScreen : IDisposable
	{
		public abstract void Resume();
		public abstract void Paused();
		public abstract void Draw();
		public abstract void Step(float dt);
		public abstract void Dispose();
	}
}
