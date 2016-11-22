using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.Engine;

namespace GameEngine
{
	public class Game : IDisposable
	{
		private static Game instance;
		private IFiles files;
		private IGraphics graphics;
		private IInput input;
		private ISystemParticles systemParticles;
		private ManagementScreen mScreen;
		public static Game GetInstance() => instance == null ? instance = new Game() : instance;
		private Game()
		{
			this.files = new ImplamentFiles();
			this.graphics = new ImplamentGraphics();
			this.input = new ImplamentInput();
			this.systemParticles = new ImplamentSystemParticles();
			this.mScreen = new ManagementScreen();
		}
		public void Step(float dt)
		{
		}
		public void Draw()
		{
		}
		public void Dispose()
		{
			instance.Dispose();
			files.Dispose();
			graphics.Dispose();
			input.Dispose();
			systemParticles.Dispose();
		}
	}
}
