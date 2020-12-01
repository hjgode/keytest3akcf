using System;

namespace System.Windows.Forms
{
	/// <summary>
	/// Windows message values from Winuser.h
	/// </summary>
	public class WindowsMessages
	{
        public const int WM_KEYDOWN       = 0x0100;
        public const int WM_KEYUP         = 0x0101;
        public const int WM_CHAR          = 0x0102;
        public const int WM_SYSKEYDOWN    = 0x0104;
        public const int WM_SYSKEYUP      = 0x0105;
        public const int WM_SYSCHAR       = 0x0106;
        public enum WM_MESG
        {
            WM_KEYDOWN       = 0x0100,
            WM_KEYUP         = 0x0101,
            WM_CHAR          = 0x0102,
            WM_SYSKEYDOWN    = 0x0104,
            WM_SYSKEYUP      = 0x0105,
            WM_SYSCHAR       = 0x0106,
        }
	}
}
