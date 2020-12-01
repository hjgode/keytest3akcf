using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text;

namespace System
{
    public static class win32
    {
        [DllImport("coredll.dll", SetLastError = true)]
        public static extern Boolean AllKeys(bool bAllKeys);

        [DllImport("coredll.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("coredll.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("coredll.dll")]
        public static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("coredll.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        //###############################
        [DllImport("aygshell.dll")]
        public static extern IntPtr SHFindMenuBar(IntPtr hWnd);

        [DllImport("coredll.dll")]
        public static extern IntPtr GetForegroundWindow();

        #region helpers
        public static class helpers
        {
            public static string hex8(int i)
            {
                string s = String.Format("0x{0:x8}", i);
                return s;
            }
            public static string hex4(int i)
            {
                string s = String.Format("0x{0:x4}", i);
                return s;
            }
            public static string hex8(IntPtr i)
            {
                int ii = i.ToInt32();
                string s = String.Format("0x{0:x8}", ii);
                return s;
            }
        }
        #endregion
    }
}
