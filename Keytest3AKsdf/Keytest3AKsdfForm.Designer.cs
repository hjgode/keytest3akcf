namespace Keytest3AKsdf
{
    partial class Keytest3AKsdfForm
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.mnuOptions = new System.Windows.Forms.MenuItem();
            this.mnuAllkeys = new System.Windows.Forms.MenuItem();
            this.mnuForwardKeys = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.mnuClearList = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuFile);
            this.mainMenu1.MenuItems.Add(this.mnuOptions);
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(240, 268);
            this.listView1.TabIndex = 0;
            // 
            // mnuFile
            // 
            this.mnuFile.MenuItems.Add(this.mnuExit);
            this.mnuFile.Text = "File";
            // 
            // mnuOptions
            // 
            this.mnuOptions.MenuItems.Add(this.mnuAllkeys);
            this.mnuOptions.MenuItems.Add(this.mnuForwardKeys);
            this.mnuOptions.MenuItems.Add(this.mnuClearList);
            this.mnuOptions.Text = "Options";
            // 
            // mnuAllkeys
            // 
            this.mnuAllkeys.Checked = true;
            this.mnuAllkeys.Text = "Allkeys(true)";
            this.mnuAllkeys.Click += new System.EventHandler(this.mnuAllkeys_Click);
            // 
            // mnuForwardKeys
            // 
            this.mnuForwardKeys.Text = "Forward keys";
            this.mnuForwardKeys.Click += new System.EventHandler(this.mnuForwardKeys_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuClearList
            // 
            this.mnuClearList.Text = "Clear List";
            this.mnuClearList.Click += new System.EventHandler(this.mnuClearList_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.listView1);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Keytest3AKsdf";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.MenuItem mnuFile;
        private System.Windows.Forms.MenuItem mnuOptions;
        private System.Windows.Forms.MenuItem mnuExit;
        private System.Windows.Forms.MenuItem mnuAllkeys;
        private System.Windows.Forms.MenuItem mnuForwardKeys;
        private System.Windows.Forms.MenuItem mnuClearList;
    }
}

