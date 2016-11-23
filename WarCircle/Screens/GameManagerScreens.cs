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
		private ScreenGame gameScreen;
		public GameManagerScreens()
		{
			startScreen = new StartScreen();
			menuScreen = new ScreenMenu();
			gameScreen = new ScreenGame();

			startScreen.IntentTo += (next, _null) => { Game.GetInstance().GetManagementScreen().SetScreen(menuScreen); };
			menuScreen.IntentTo += (next, _null) => { Game.GetInstance().GetManagementScreen().SetScreen(gameScreen); };
			gameScreen.IntentTo += (next, _null) => { Game.GetInstance().GetManagementScreen().SetScreen(menuScreen); };
		}
		public BasicScreen GetStartScreen() => startScreen;
	}
}
