using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text;

using System.Collections.Generic;

using System.Threading;
using System.Windows.Forms;

[assembly: CLSCompliant(true)]

namespace KeybdHook
{
    // Assembly marked as compliant.
    public class KeyHook
    {
        /*
        How can keypresses including F1-F24 forwarded and analyzed in compact framework app within WEH653?:

        Hooking [http://social.msdn.microsoft.com/Forums/en-US/vssmartdevicesvbcs/thread/5e686882-665b-4f75-8df6-d4e568799005/ ]
            hook the keyboard and send user messages to form's MessageWindow

        [-]
         * WndProc subclassing [http://msdn.microsoft.com/en-us/magazine/cc188736.aspx ], 
            but which window to subclass? CF under WEH653 does not have a single WndProc which handles form and
            menu keys (F1 F2)
            /-use user messages to inform main form about key events, or you may break the CF message handling_/ does not work,
            the form wndproc does not receive messages for F1/F2, these maybe catched by an IME window and forwarded as WM_Notify
            messages

        [+]
        AllKeys(true), needed at all. Use before Application.Run(new Form...

        for F1 F2: http://www.pcreview.co.uk/forums/invoke-menu-item-sendmessage-t3301484.html

        subclassing menu_worker: [ http://www.eggheadcafe.com/community/compact-framework/16/10389411/to-get-the-mouse-down-notification-on-the-top-toolbar-wm653.aspx ]

        */
        [CLSCompliantAttribute(true)]   //avoid vb.net warning
        public class KeyboardHook : IDisposable
        {
            private IntPtr _hook;

            /// <summary>
            /// should a key, if signaled, be forwarded to the def WndProc?
            /// </summary>
            [CLSCompliantAttribute(false)]   //avoid vb.net warning
            public bool _consumeKey{get; set;}

            private delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);
            private HookProc _hookDeleg;

            [CLSCompliantAttribute(false)]   //avoid vb.net warning
            public delegate void HookEventHandler(object sender, HookEventArgs hookArgs);
            [CLSCompliantAttribute(false)]   //avoid vb.net warning
            public event HookEventHandler HookEvent;

            /// <summary>
            /// define a list of msg you would like to be informed on
            /// if empty, all msg are signaled
            /// </summary>
            [CLSCompliantAttribute(false)]   //avoid vb.net warning
            public List<WindowsMessages.WM_MESG> _msgFilter = new List<WindowsMessages.WM_MESG>();

            /// <summary>
            /// define a list of vk values you would like to filter
            /// if empty, all vk values are signaled
            /// </summary>
            [CLSCompliantAttribute(false)]   //avoid vb.net warning
            public List<vkcodes.VKEY> _vkcodeFilter = new List<vkcodes.VKEY>();

            //public delegate void HookEventHandler();
            //public HookEventHandler HookEvent=null;

            private Form _owner;
            private IntPtr _hWnd=IntPtr.Zero;

            public KeyboardHook(Form owner)
            {
                _owner = owner;
                _hWnd = _owner.Handle;
                _consumeKey = false;
                Start();
            }

            #region public methods
            public void Start()
            {

                if (_hook != IntPtr.Zero)
                {
                    //Unhook the previouse one
                    this.Stop();
                }
                _hookDeleg = new HookProc(HookProcedure);

                _hook = NativeMethods.SetWindowsHookEx(
                    NativeMethods.WH_KEYBOARD_LL,
                    _hookDeleg,
                    NativeMethods.GetModuleHandle(null),
                    0);
                if (_hook == IntPtr.Zero)
                {
                    throw new SystemException("Failed acquiring of the hook.");
                }
            }

            ~KeyboardHook()
            {
                if (_hook != IntPtr.Zero)
                {
                    bool result = NativeMethods.UnhookWindowsHookEx(_hook);
                    _hook = IntPtr.Zero;
                }
            }
            public void Stop()
            {
                if (_hook != IntPtr.Zero)
                {
                    bool result = NativeMethods.UnhookWindowsHookEx(_hook);
                    _hook = IntPtr.Zero;
                }
            }

            public void Dispose()
            {
                Stop();
            }
            #endregion

            void ProcessHookEvent(HookEventArgs args)
            {
                if (HookEvent != null)
                {
                    //_owner.Invoke(HookEvent(args));
                    HookEvent(this, args);
                }
            }

            /// <summary>
            /// the function called for every keypress!
            /// </summary>
            /// <param name="code"></param>
            /// <param name="wParam">the keyboard message WM_Keydown/UP etc</param>
            /// <param name="lParam">the KBDLLHOOKSTRUCT info</param>
            /// <returns></returns>
            private IntPtr HookProcedure(int code, IntPtr wParam, IntPtr lParam)
            {
                IntPtr hwnd=IntPtr.Zero;
                hwnd = win32.GetForegroundWindow();
                if (hwnd == _hWnd)  //filter messages for our window only!
                {
                    KBDLLHOOKSTRUCT hookStruct = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));
                    if (_msgFilter.Count == 0 || _msgFilter.Contains((WindowsMessages.WM_MESG)wParam))
                    {
                        if (_vkcodeFilter.Contains((vkcodes.VKEY)hookStruct.vkCode) || _vkcodeFilter.Count == 0)
                        {
                            //OnHookEvent();
                            HookEventArgs hookArgs = new HookEventArgs();
                            hookArgs.Code = code;
                            hookArgs.hookstruct = hookStruct;
                            hookArgs.wParam = wParam;
                            ProcessHookEvent(hookArgs);
                            //forward the key or just discard the keyboard message?
                            if (_consumeKey)
                                return (IntPtr)1;
                        }
                    }
                }
                return NativeMethods.CallNextHookEx(_hookDeleg, code, wParam, lParam);
            }

            [CLSCompliantAttribute(false)]  //avoid vb.net warning
            public class HookEventArgs : EventArgs
            {
                public int Code;  // Hook code
                public IntPtr wParam;  // WPARAM argument
                public KBDLLHOOKSTRUCT hookstruct;  // KBDLLHOOKSTRUCT argument
            }
#pragma warning disable 649
            public class KeyBoardInfo
            {
                public int vkCode;
                public int scanCode;
                public int flags;
                public int time;
            }
            public struct KBDLLHOOKSTRUCT
            {
                public int vkCode;
                public int scanCode;
                public int flags;
                public int time;
                public IntPtr dwExtraInfo;
#pragma warning restore 649
            }

            private static class NativeMethods
            {
                #region P/Invoke declarations
                [DllImport("coredll.dll", CharSet = CharSet.Auto, SetLastError = true)]
                public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

                [DllImport("coredll.dll")]
                public static extern IntPtr GetModuleHandle(string mod);

                [DllImport("coredll.dll")]
                public static extern IntPtr CallNextHookEx(
                                HookProc hhk,
                                int nCode,
                                IntPtr wParam,
                                IntPtr lParam
                                );

                [DllImport("coredll.dll")]
                public static extern int GetCurrentThreadId();

                [DllImport("coredll.dll", CharSet = CharSet.Auto, SetLastError = true)]
                [return: MarshalAs(UnmanagedType.Bool)]
                public static extern bool UnhookWindowsHookEx(IntPtr hhk);



                public const int WH_KEYBOARD_LL = 20;
                public const int WM_KEYUP = 0x0101;
                public const int WM_SYSKEYUP = 0x0105;
                #endregion
            }
        }
        /*
        Somewhere in your form:
        ...
        //HookKeyboard
        KeyHook.KeyboardHook _keyboardHook;
        public Form(){
            InitializeComponent();
            this.KeyPreview = true; //or we will not catch keypress if main window has sub controls
            try{
                _keyboardHook = new KeyHook.KeyboardHook(this);
                _keyboardHook.HookEvent += new KeyHook.KeyboardHook.HookEventHandler(_kHook_HookEvent);  
            }
            catch( Exception ex )
            {
                utils.Logger.WriteLine( ex.ToString() );
                _keyboardHook = null;
            }
            
            void _kHook_HookEvent(object sender, KeyHook.KeyboardHook.HookEventArgs hookArgs)
            {
                addLog("HookEvent: ");
            }
        */
    }
}
