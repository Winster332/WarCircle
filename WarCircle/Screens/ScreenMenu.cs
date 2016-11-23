using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine;

namespace WarCircle.Screens
{
	public class ScreenMenu : BasicScreen
	{
		public event EventHandler IntentTo;
		public override void Dispose()
		{
		}
		public override void Step(float dt)
		{
			Game.GetInstance().GetSystemParticles().Step(dt);

			StepLight(dt);
		}
		public override void Draw()
		{
			Game.GetInstance().GetSystemParticles().Draw();

			DrawLight();
		}

		public override void Paused()
		{
		}

		public override void Resume()
		{
			Closed += (screen, e) => { IntentTo(this, e); };
			this.EnableLight(true, 5);
		}
	}
}
