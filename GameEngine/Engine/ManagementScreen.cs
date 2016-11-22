using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
	public class ManagementScreen
	{
		private BasicScreen currentScreen;
		public ManagementScreen()
		{
			currentScreen = null;
		}
		public void SetScreen(BasicScreen screen)
		{
			this.currentScreen.Paused();
			this.currentScreen.Dispose();
			screen.Resume();
			this.currentScreen = screen;
		}
		public BasicScreen GetScreen()
		{
			return this.currentScreen;
		}
		public void Draw()
		{
			if (this.currentScreen != null)
				this.currentScreen.Draw();
		}
		public void Step(float dt)
		{
			if (this.currentScreen != null)
				this.currentScreen.Step(dt);
		}
	}
}
