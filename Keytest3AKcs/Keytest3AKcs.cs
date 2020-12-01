using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Keyboard;

namespace KeyTest3AKcs
{
    public partial class Keytest3AKcs : Form
    {
        //HookKeyboard
        Keyboard.KeyHook.KeyboardHook _keyboardHook;

        public Keytest3AKcs()
        {
            //another way to catch all keys (except F1 and F2)
            /*
                win32.AllKeys(true);
                this.KeyPreview = true;
            */
            InitializeComponent();

            win32.AllKeys(mnuAllkeys.Checked);

            //prepare listview
            initListView();

            try
            {
                //test with keyhook
                _keyboardHook = new KeyHook.KeyboardHook(this);
                _keyboardHook.HookEvent += new KeyHook.KeyboardHook.HookEventHandler(_kHook_HookEvent);
                addLog("Init(): hook installed");
            }
            catch (SystemException ex)
            {
                addLog("Init(): " + ex.Message);
                _keyboardHook = null;
            }
        }
        void _kHook_HookEvent(object sender, KeyHook.KeyboardHook.HookEventArgs hookArgs)
        {
            addLog("HookEvent: " + //win32.helpers.hex8(hookArgs.Code) + ", " +
                win32.helpers.hex8(hookArgs.wParam) + ", " +
                win32.helpers.hex8(hookArgs.hookstruct.vkCode) + ", " +
                win32.helpers.hex8(hookArgs.hookstruct.scanCode) 
                );
            addItem(hookArgs);
#if DEBUG
            string sWM = ((WindowsMessages.WM_MESG)hookArgs.wParam).ToString();
            System.Diagnostics.Debug.WriteLine("msg=" + sWM + ", " + win32.helpers.hex8(hookArgs.hookstruct.dwExtraInfo) );
#endif
        }
        void initListView()
        {
            ColumnHeader col0, col1, col2;
            col0 = new ColumnHeader();
            col0.Text = "Message";
            col0.TextAlign = HorizontalAlignment.Left;
            col0.Width = listView1.Width/3;

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
        void addItem(KeyHook.KeyboardHook.HookEventArgs hookArgs)
        {
            ListViewItem lvi = new ListViewItem(((WindowsMessages.WM_MESG)hookArgs.wParam).ToString());
            //lvi.SubItems.Add(win32.helpers.hex8(hookArgs.hookstruct.vkCode));
            lvi.SubItems.Add(((vkcodes.VKEY)hookArgs.hookstruct.vkCode).ToString());
            lvi.SubItems.Add(win32.helpers.hex8(hookArgs.hookstruct.scanCode));
            listView1.Items.Add(lvi);
            listView1.EnsureVisible(listView1.Items.Count - 1);
        }
        delegate void SetTextCallback(string text);
        public void addLog(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtLog.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(addLog);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(text);
                if (txtLog.Text.Length > 8000)
                    txtLog.Text = "";
                txtLog.Text += text + "\r\n";
                txtLog.SelectionLength = 0;
                txtLog.SelectionStart = txtLog.Text.Length - 1;
                txtLog.ScrollToCaret();
            }
        }

        private void mnuForwardFKeys_Click(object sender, EventArgs e)
        {
            if (_keyboardHook != null)
            {
                _keyboardHook._consumeKey = !_keyboardHook._consumeKey;
                mnuForwardFKeys.Checked = !_keyboardHook._consumeKey;
            }
        }

        private void mnuAllkeys_Click(object sender, EventArgs e)
        {
            mnuForwardFKeys.Checked = !mnuForwardFKeys.Checked;
            win32.AllKeys(mnuForwardFKeys.Checked);
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            _keyboardHook.Dispose();
            Application.Exit();
        }

        private void mnuClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            if (txtLog.Text.Length > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "*.txt|*.txt|*.*|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName))
                    {
                        sw.WriteLine(txtLog.Text);
                        //sw.WriteLine(ListViewHelper.ListViewToCSV(listView1, sfd.FileName, true));
                        sw.Flush();
                    }
                }
            }
        }
        class ListViewHelper
        {
            public static string ListViewToCSV(ListView listView, string filePath, bool includeHidden)
            {
                //make header string
                StringBuilder result = new StringBuilder();
                WriteCSVRow(result, listView.Columns.Count, i => includeHidden || listView.Columns[i].Width > 0, i => listView.Columns[i].Text);

                //export data rows
                foreach (ListViewItem listItem in listView.Items)
                    WriteCSVRow(result, listView.Columns.Count, i => includeHidden || listView.Columns[i].Width > 0, i => listItem.SubItems[i].Text);

                //File.WriteAllText(filePath, result.ToString());
                return result.ToString();
            }

            private static void WriteCSVRow(StringBuilder result, int itemsCount, Func<int, bool> isColumnNeeded, Func<int, string> columnValue)
            {
                bool isFirstTime = true;
                for (int i = 0; i < itemsCount; i++)
                {
                    if (!isColumnNeeded(i))
                        continue;

                    if (!isFirstTime)
                        result.Append(",");
                    isFirstTime = false;

                    result.Append(String.Format("\"{0}\"", columnValue(i)));
                }
                result.AppendLine();
            }
        }

        private void Keytest3AKcs_Resize(object sender, EventArgs e)
        {
            //change layout
            int offs = System.Windows.Forms.SystemInformation.MenuHeight;            
            //use 3/4 1/4
            listView1.Top=offs;
            listView1.Width = this.ClientRectangle.Width;
            listView1.Height = this.ClientRectangle.Height / 4 * 3 - offs;

            txtLog.Top = offs + listView1.Height;
            txtLog.Width = this.ClientRectangle.Width;
            txtLog.Height = this.ClientRectangle.Height / 4 * 1 - offs;
        }

    }
}