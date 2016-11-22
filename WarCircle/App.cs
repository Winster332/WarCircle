using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine;
using System.Windows.Forms;

namespace WarCircle
{
	class App
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Game.GetInstance().Run(new Screens.StartScreen());
			var window = new MainWindow("War Circle");
			window.SetSettings(Game.GetInstance().GetSettings());

            Application.Run(window);
		}
	}
}
