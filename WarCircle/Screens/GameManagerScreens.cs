using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine;

namespace WarCircle.Screens
{
	public class GameManagerScreens
	{
		private StartScreen startScreen;
		private ScreenMenu menuScreen;
		private ScreenRecord recordScreen;
		private ScreenGame gameScreen;
		public GameManagerScreens()
		{
			startScreen = new StartScreen();
			menuScreen = new ScreenMenu();
			recordScreen = new ScreenRecord();
			gameScreen = new ScreenGame();
		}
		public BasicScreen GetStartScreen() => startScreen;
	}
}
