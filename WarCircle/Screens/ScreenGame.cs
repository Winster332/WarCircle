using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GameEngine;

namespace WarCircle.Screens
{
	public class ScreenGame : BasicScreen
	{
		public event EventHandler IntentTo;
	
		public override void Dispose()
		{
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
		public override void Step(float dt)
		{
			Game.GetInstance().GetSystemParticles().Step(dt);
			StepLight(dt);
		}
	}
}
