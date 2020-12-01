namespace KeyTest3AKcs
{
    partial class Keytest3AKcs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.mnuSave = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.mnuClearLog = new System.Windows.Forms.MenuItem();
            this.mnuOptions = new System.Windows.Forms.MenuItem();
            this.mnuForwardFKeys = new System.Windows.Forms.MenuItem();
            this.mnuAllkeys = new System.Windows.Forms.MenuItem();
            this.mnuKeyPreview = new System.Windows.Forms.MenuItem();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuFile);
            this.mainMenu1.MenuItems.Add(this.mnuOptions);
            // 
            // mnuFile
            // 
            this.mnuFile.MenuItems.Add(this.mnuSave);
            this.mnuFile.MenuItems.Add(this.mnuExit);
            this.mnuFile.MenuItems.Add(this.mnuClearLog);
            this.mnuFile.Text = "File";
            // 
            // mnuSave
            // 
            this.mnuSave.Text = "Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuClearLog
            // 
            this.mnuClearLog.Text = "Clear Log";
            this.mnuClearLog.Click += new System.EventHandler(this.mnuClearLog_Click);
            // 
            // mnuOptions
            // 
            this.mnuOptions.MenuItems.Add(this.mnuForwardFKeys);
            this.mnuOptions.MenuItems.Add(this.mnuAllkeys);
            this.mnuOptions.MenuItems.Add(this.mnuKeyPreview);
            this.mnuOptions.Text = "Options";
            // 
            // mnuForwardFKeys
            // 
            this.mnuForwardFKeys.Checked = true;
            this.mnuForwardFKeys.Text = "Forward F Keys";
            this.mnuForwardFKeys.Click += new System.EventHandler(this.mnuForwardFKeys_Click);
            // 
            // mnuAllkeys
            // 
            this.mnuAllkeys.Checked = true;
            this.mnuAllkeys.Text = "AllKeys";
            this.mnuAllkeys.Click += new System.EventHandler(this.mnuAllkeys_Click);
            // 
            // mnuKeyPreview
            // 
            this.mnuKeyPreview.Text = "Keypreview";
            // 
            // txtLog
            // 
            this.txtLog.AcceptsReturn = true;
            this.txtLog.AcceptsTab = true;
            this.txtLog.Location = new System.Drawing.Point(3, 212);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(232, 53);
            this.txtLog.TabIndex = 1;
            this.txtLog.TabStop = false;
            this.txtLog.WordWrap = false;
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(232, 203);
            this.listView1.TabIndex = 2;
            // 
            // Keytest3AKcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.txtLog);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "Keytest3AKcs";
            this.Text = "Keytest3AKcs";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.Keytest3AKcs_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuFile;
        private System.Windows.Forms.MenuItem mnuOptions;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.MenuItem mnuForwardFKeys;
        private System.Windows.Forms.MenuItem mnuAllkeys;
        private System.Windows.Forms.MenuItem mnuSave;
        private System.Windows.Forms.MenuItem mnuExit;
        private System.Windows.Forms.MenuItem mnuClearLog;
        private System.Windows.Forms.MenuItem mnuKeyPreview;
        private System.Windows.Forms.ListView listView1;
    }
}

