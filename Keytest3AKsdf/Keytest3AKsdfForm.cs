using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.WindowsCE.Forms;
using OpenNETCF.Windows.Forms;

namespace Keytest3AKsdf
{
    public partial class Keytest3AKsdfForm : Form,IMessageFilter
    {
        public Keytest3AKsdfForm()
        {
            InitializeComponent();
            initListView();
            _hwnd = new List<IntPtr>();
            _hwnd.Add(this.Handle);
            _hwnd.Add(this.listView1.Handle);
            Application2.AddMessageFilter(this);
            win32.AllKeys(true);
		}

        #region IMessageFilter Members
        /// <summary>
        /// a list of window handles part of the form
        /// </summary>
        List<IntPtr> _hwnd;
        bool _bForwardKeys = false;
/*
 * Startet, pressed F1, pressed GREEN, pressed D key
 * watch the different windows handles!
        msghandler2: 7C0932B0, 00000005, 00000000, 00C800C8
        msghandler2: 7C092540, 0000C004, 00000003, 00000000
        msghandler2: 7C092D30, 0000000F, 00000000, 00000000
        msghandler2: 7C092D30, 0000000F, 00000000, 00000000
        msghandler2: 7C091600, 00000100, 00000070, 00050001
        msghandler2: 7C091600, 00000100, 00000070, 00050001
        msghandler2: 7C091600, 00000400, 00000000, 00000000
        msghandler2: 7C091600, 00000101, 00000070, C0050001
        msghandler2: 7C091600, 00000101, 00000070, C0050001
        msghandler2: 7C091600, 0000000F, 00000000, 00000000
        msghandler2: 7C091600, 00000101, 0000009A, C09A0001
        msghandler2: 7C091600, 00000101, 0000009A, C09A0001
        msghandler2: 7C091600, 0000000F, 00000000, 00000000
        msghandler2: 7C091600, 00000100, 00000044, 00230001
        msghandler2: 7C091600, 00000100, 00000044, 00230001
        msghandler2: 7C091600, 00000102, 00000064, 00230001
        msghandler2: 7C091600, 0000000F, 00000000, 00000000
        msghandler2: 7C091600, 00000101, 00000044, C0230001
        msghandler2: 7C091600, 00000101, 00000044, C0230001
        msghandler2: 7C091600, 0000000F, 00000000, 00000000
*/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public bool PreFilterMessage(ref Message m)
        {
            System.Diagnostics.Debug.WriteLine("msghandler1: " + 
                m.HWnd.ToInt32().ToString("X8") +
                ", " + m.Msg.ToString("X8") +
                ", " + m.WParam.ToInt32().ToString("X8") +
                ", " + m.LParam.ToInt32().ToString("X8"));

            //only process msg to our windows
            if (_hwnd.Contains(m.HWnd))
                return MsgHandler(m);
            else
                return false;

        }

        private bool MsgHandler(Message m)
        {
            if (m.Msg == WindowsMessages.WM_KEYDOWN || m.Msg == WindowsMessages.WM_KEYUP)
            {
                //add the msg to our listview
                addItem(m);
                Keys k = (Keys)m.WParam.ToInt32();
                System.Diagnostics.Debug.WriteLine("msghandler2: " + m.HWnd.ToInt32().ToString("X8") +
                    //", " + m.Msg.ToString("X8") +
                    ", " + ((WindowsMessages.WM_MESG)m.Msg).ToString() +
                    ", " + m.WParam.ToInt32().ToString("X8") + 
                    ", " + m.LParam.ToInt32().ToString("X8"));
                if (_bForwardKeys == false)
                    return true;//let windows now that we handled the message
                else
                    return false;
            }
            return false;//let windows now that we DID NOT handled the message
        }

        const int WM_KEYDOWN = 0x0100;
        const int WM_KEYUP = 0x0101;
        #endregion

        void initListView()
        {
            ColumnHeader col0, col1, col2;
            col0 = new ColumnHeader();
            col0.Text = "Message";
            col0.TextAlign = HorizontalAlignment.Left;
            col0.Width = listView1.Width / 3;

            col1 = new ColumnHeader();
            col1.Text = "vkCode";
            col1.TextAlign = HorizontalAlignment.Left;
            col1.Width = listView1.Width / 3;

            col2 = new ColumnHeader();
            col2.Text = "lParam";
            col2.TextAlign = HorizontalAlignment.Left;
            col2.Width = listView1.Width / 3;

            listView1.Columns.Add(col0);
            listView1.Columns.Add(col1);
            listView1.Columns.Add(col2);

            listView1.View = View.Details;
        }

        /// <summary>
        /// add a WM_KeyUp/Down item to listview
        /// </summary>
        /// <param name="m"></param>
        public void addItem(Message m)
        {
            ListViewItem lvi = new ListViewItem(((WindowsMessages.WM_MESG)m.Msg).ToString());//msg
            
            lvi.SubItems.Add(((vkcodes.VKEY)m.WParam.ToInt32()).ToString());//key code
            lvi.SubItems.Add(win32.helpers.hex8(m.LParam));//lparm argument

            listView1.Items.Add(lvi);
            listView1.EnsureVisible(listView1.Items.Count - 1);
        }

        private void mnuAllkeys_Click(object sender, EventArgs e)
        {
            mnuAllkeys.Checked = !mnuAllkeys.Checked;
            win32.AllKeys(mnuAllkeys.Checked);
        }

        private void mnuForwardKeys_Click(object sender, EventArgs e)
        {
            mnuForwardKeys.Checked = !mnuForwardKeys.Checked;
            _bForwardKeys = mnuForwardKeys.Checked;
        }

        private void mnuClearList_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application2.Exit();
        }
    }
}