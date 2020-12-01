namespace Keytest3AKwm61
{
    partial class Keytest3AKwm61
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.listView1 = new System.Windows.Forms.ListView();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.mnuSave = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.mnuClearLog = new System.Windows.Forms.MenuItem();
            this.mnuOptions = new System.Windows.Forms.MenuItem();
            this.mnuAllkeys = new System.Windows.Forms.MenuItem();
            this.mnuIMessageFilter = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(240, 268);
            this.listView1.TabIndex = 3;
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
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click_1);
            // 
            // mnuExit
            // 
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click_1);
            // 
            // mnuClearLog
            // 
            this.mnuClearLog.Text = "Clear Log";
            this.mnuClearLog.Click += new System.EventHandler(this.mnuClearLog_Click);
            // 
            // mnuOptions
            // 
            this.mnuOptions.MenuItems.Add(this.mnuAllkeys);
            this.mnuOptions.MenuItems.Add(this.mnuIMessageFilter);
            this.mnuOptions.Text = "Options";
            // 
            // mnuAllkeys
            // 
            this.mnuAllkeys.Checked = true;
            this.mnuAllkeys.Text = "AllKeys";
            this.mnuAllkeys.Click += new System.EventHandler(this.mnuAllkeys_Click);
            // 
            // mnuIMessageFilter
            // 
            this.mnuIMessageFilter.Checked = true;
            this.mnuIMessageFilter.Text = "IMessageFilter";
            this.mnuIMessageFilter.Click += new System.EventHandler(this.mnuIMessageFilter_Click);
            // 
            // Keytest3AKwm61
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.listView1);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "Keytest3AKwm61";
            this.Text = "Keytest3AKwm61";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Keytest3AKwm61_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Keytest3AKwm61_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuFile;
        private System.Windows.Forms.MenuItem mnuSave;
        private System.Windows.Forms.MenuItem mnuExit;
        private System.Windows.Forms.MenuItem mnuClearLog;
        private System.Windows.Forms.MenuItem mnuOptions;
        private System.Windows.Forms.MenuItem mnuAllkeys;
        private System.Windows.Forms.MenuItem mnuIMessageFilter;
    }
}

