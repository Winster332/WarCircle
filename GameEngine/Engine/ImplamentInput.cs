using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameEngine.Engine
{
	public class ImplamentInput : IInput
	{
		private List<Keys> keysDown;
		private List<Keys> keysUp;
		private int maxSize;
		private MouseEventArgs mouse;
		private MouseState mouseState;
		public ImplamentInput()
		{
			keysDown = new List<Keys>();
			keysUp = new List<Keys>();
			maxSize = 5;
		}
		public void Dispose()
		{
			keysDown.Clear();
			keysDown = null;
			keysUp.Clear();
			keysUp = null;
			maxSize = 0;
			mouse = null;
		}
		public List<Keys> GetKeyboardDown()
		{
			return keysDown;
		}
		public List<Keys> GetKeyboardUp()
		{
			return keysUp;
		}
		public int GetMaxLength()
		{
			return maxSize;
		}
		public Tuple<MouseEventArgs, MouseState> GetMouse()
		{
			return new Tuple<MouseEventArgs, MouseState>(mouse, mouseState);
		}
		public void SetKeyboardDown(Keys key)
		{
			keysDown.Add(key);

			if (keysDown.Count > maxSize)
				keysDown.RemoveAt(keysDown.Count - 1);
		}
		public void SetKeyboardUp(Keys key)
		{
			keysUp.Add(key);

			if (keysUp.Count > maxSize)
				keysUp.RemoveAt(keysUp.Count - 1);
		}
		public void SetMaxLength(int size)
		{
			this.maxSize = size;
		}
		public void SetMouse(MouseEventArgs mouse, MouseState state)
		{
			this.mouse = mouse;
			this.mouseState = state;
		}
		public void Update()
		{
			if (keysDown != null)
				keysDown.Clear();
			if (keysUp != null)
				keysUp.Clear();
			mouseState = MouseState.none;
		}
	}
}
