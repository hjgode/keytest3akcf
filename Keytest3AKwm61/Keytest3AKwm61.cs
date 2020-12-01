using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using OpenNETCF.Windows.Forms;

namespace Keytest3AKwm61
{
    public partial class Keytest3AKwm61 : Form, IMessageFilter
    {
        List<IntPtr> _hwnd;
        bool _bForwardKeys = false;
        bool _bMessageFilterActive = true;

        public Keytest3AKwm61()
        {
            InitializeComponent();
            //prepare listview
            initListView();

            Application2.AddMessageFilter(this);
            win32.AllKeys(true);

            this.KeyPreview = true;

            _hwnd = new List<IntPtr>();
            _hwnd.Add(this.Handle);
            _hwnd.Add(listView1.Handle);
        }

        public bool PreFilterMessage(ref Microsoft.WindowsCE.Forms.Message m)
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

        private bool MsgHandler(Microsoft.WindowsCE.Forms.Message m)
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
            col2.Text = "mod flags";
            col2.TextAlign = HorizontalAlignment.Left;
            col2.Width = listView1.Width / 3;

            listView1.Columns.Add(col0);
            listView1.Columns.Add(col1);
            listView1.Columns.Add(col2);

            listView1.View = View.Details;
        }
        void addItem(Microsoft.WindowsCE.Forms.Message msg)
        {
            ListViewItem lvi = new ListViewItem(((WindowsMessages.WM_MESG)msg.Msg).ToString());
            //lvi.SubItems.Add(win32.helpers.hex8(hookArgs.hookstruct.vkCode));
            lvi.SubItems.Add(((vkcodes.VKEY)msg.WParam).ToString());
            lvi.SubItems.Add(win32.helpers.hex8(msg.LParam));
            listView1.Items.Add(lvi);
            listView1.EnsureVisible(listView1.Items.Count - 1);
        }

        class ListViewHelper
        {
            public static string ListViewToCSV(ListView listView, string filePath)
            {
                StringBuilder sb = new StringBuilder();
                foreach (ListViewItem item in listView.Items)
                {
                    int subCount = 0;
                    foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                    {
                        if (subCount < item.SubItems.Count)
                            sb.Append("\t");
                        sb.Append(subitem.Text);
                        subCount++;
                    }

                    sb.Append("\r\n");
                }
                return sb.ToString();
            }
        }

        private void mnuClearLog_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void Keytest3AKwm61_KeyUp(object sender, KeyEventArgs e)
        {
            Microsoft.WindowsCE.Forms.Message msg = new Microsoft.WindowsCE.Forms.Message();
            msg.Msg=WindowsMessages.WM_KEYUP;
            msg.WParam=(IntPtr) e.KeyCode;
            int modFlags = (int)e.Modifiers;
            IntPtr pmodFlags = new IntPtr(modFlags);
            msg.LParam=pmodFlags;
            addItem(msg);
        }

        private void mnuAllkeys_Click(object sender, EventArgs e)
        {
            mnuAllkeys.Checked = !mnuAllkeys.Checked;
            win32.AllKeys(mnuAllkeys.Checked);
        }

        private void mnuSave_Click_1(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "*.txt|*.txt|*.*|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName))
                    {
                        sw.WriteLine(ListViewHelper.ListViewToCSV(listView1, sfd.FileName));
                        sw.Flush();
                    }
                }
            }

        }

        private void mnuExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Keytest3AKwm61_KeyDown(object sender, KeyEventArgs e)
        {
            Microsoft.WindowsCE.Forms.Message msg = new Microsoft.WindowsCE.Forms.Message();
            msg.Msg = WindowsMessages.WM_KEYDOWN;
            msg.WParam = (IntPtr)e.KeyCode;
            int modFlags = (int)e.Modifiers;
            IntPtr pmodFlags = new IntPtr(modFlags);
            msg.LParam = pmodFlags;
            addItem(msg);
        }

        private void mnuIMessageFilter_Click(object sender, EventArgs e)
        {
            mnuIMessageFilter.Checked = !mnuIMessageFilter.Checked;
            if (mnuIMessageFilter.Checked)
            {
                if (!_bMessageFilterActive)
                {
                    Application2.AddMessageFilter(this);
                    _bMessageFilterActive = true;
                }
            }
            else
            {
                if (_bMessageFilterActive)
                {
                    Application2.RemoveMessageFilter(this);
                    _bMessageFilterActive = false;
                }
            }
        }
    }
}