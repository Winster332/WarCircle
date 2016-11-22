using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
	public interface IInput : IDisposable
	{
		List<System.Windows.Forms.Keys> GetKeyboardDown();
		List<System.Windows.Forms.Keys> GetKeyboardUp();
		void SetKeyboardDown(System.Windows.Forms.Keys key);
		void SetKeyboardUp(System.Windows.Forms.Keys key);
		void SetMaxLength(int size);
		int GetMaxLength();
		void SetMouse(System.Windows.Forms.MouseEventArgs mouse, MouseState state);
		Tuple<System.Windows.Forms.MouseEventArgs, MouseState> GetMouse();
	//	System.Windows.Forms.Keys GetKeyDown();
	//	System.Windows.Forms.Keys GetKeyUp();
		void Update();
	}
	public enum MouseState
	{
		Down,
		Up,
		Move,
		none
	}
}
