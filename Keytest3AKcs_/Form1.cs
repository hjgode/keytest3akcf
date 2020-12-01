using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KeybdHook;

namespace Keytest3AKcs_
{
    public partial class Form1 : Form
    {
        //HookKeyboard
        KeyHook.KeyboardHook _keyboardHook;

        public Form1()
        {
            InitializeComponent();
            win32.AllKeys(true);
            _keyboardHook = new KeyHook.KeyboardHook(this);
            _keyboardHook.HookEvent += new KeyHook.KeyboardHook.HookEventHandler(_keyboardHook_HookEvent);
        }

        void _keyboardHook_HookEvent(object sender, KeyHook.KeyboardHook.HookEventArgs hookArgs)
        {
            string s = String.Format("{0:X8}, {1:X8}", hookArgs.wParam.ToInt32(), hookArgs.hookstruct.vkCode);
            System.Diagnostics.Debug.WriteLine(s);
            listBox1.Items.Add(s);
        }
    }
}