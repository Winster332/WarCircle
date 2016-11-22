using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
	public interface IGraphics : IDisposable
	{
		System.Drawing.Graphics Get();
		void Set(System.Drawing.Graphics g);
		void SetColorClear(System.Drawing.Color color);
		System.Drawing.Color GetClearColor();
	}
}
