using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;

namespace GameEngine
{
	[Serializable]
	public class AppSettings
	{
		public Size WindowSize;
		public bool IsDoubleBuffer;
		public int UpdateFrames;
		public User InfoUser { get; set; }
		public AppSettings()
		{
			WindowSize = new Size(350, 300);
			IsDoubleBuffer = true;
			UpdateFrames = 30;
			InfoUser = new User();
		}
		public AppSettings Load()
		{
			if (!File.Exists(Environment.CurrentDirectory + "\\settings.txt"))
				Save();

			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
				using (Stream stream = new FileStream(Environment.CurrentDirectory + "\\settings.txt", FileMode.Open))
				{
					AppSettings settings = (AppSettings)serializer.Deserialize(stream);
					SetSettings(settings);
				}
				return this;
			}
			catch (Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.ToString(), "Не удалось загрузить файл настроек");
			}
			return null;
		}
		public AppSettings Save()
		{
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
				using (Stream stream = new FileStream(Environment.CurrentDirectory + "\\settings.txt", FileMode.Create))
				{
					serializer.Serialize(stream, this);
				}
				return this;
			}
			catch (Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.ToString(), "Не удалось сохранить файл настроек");
			}
			return null;
		}
		public AppSettings SetSettings(AppSettings s)
		{
			this.WindowSize = s.WindowSize;
			this.IsDoubleBuffer = s.IsDoubleBuffer;
			this.UpdateFrames = s.UpdateFrames;
			this.InfoUser = s.InfoUser;

			return this;
		}

		public class User
		{
			public string Name;
			public int Record;
			public User()
			{
				Name = "Player";
				Record = 0;
			}
		}
	}
}
