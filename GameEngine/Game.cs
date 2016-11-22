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
		private IGraphics graphics;
		private IInput input;
		private ISystemParticles systemParticles;
		private ManagementScreen mScreen;
		private AppSettings settings;
		private GameState State;
		public static Game GetInstance() => instance == null ? instance = new Game() : instance;
		private Game()
		{
			this.State = GameState.Initialized;
			this.graphics = new ImplamentGraphics();
			this.input = new ImplamentInput();
			this.systemParticles = new ImplamentSystemParticles();
			this.mScreen = new ManagementScreen();
			this.settings = new AppSettings();
			this.settings.Load();
		}
		public void Run(BasicScreen screen)
		{
			this.State = GameState.Running;
				mScreen.SetScreen(screen);
		}
		public IGraphics GetGraphics() => graphics;
		public IInput GetInput() => input;
		public ISystemParticles GetSystemParticles() => systemParticles;
		public AppSettings GetSettings() => settings;
		public ManagementScreen GetManagementScreen() => mScreen;
		public void Step(float dt)
		{
			if (State == GameState.Running)
				mScreen.Step(dt);
			input.Update();
		}
		public void Draw()
		{
			if (State == GameState.Running)
				mScreen.Draw();
		}
		public void Paused()
		{
			State = GameState.Paused;
		}
		public void Dispose()
		{
			State = GameState.Finished;
			instance = null;
			graphics.Dispose();
			input.Dispose();
			systemParticles.Dispose();
		}
	}
}
