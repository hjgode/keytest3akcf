<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.mnuFile = New System.Windows.Forms.MenuItem
        Me.mnuSave = New System.Windows.Forms.MenuItem
        Me.mnuExit = New System.Windows.Forms.MenuItem
        Me.mnuClearLog = New System.Windows.Forms.MenuItem
        Me.mnuOptions = New System.Windows.Forms.MenuItem
        Me.mnuForwardFKeys = New System.Windows.Forms.MenuItem
        Me.mnuAllkeys = New System.Windows.Forms.MenuItem
        Me.mnuKeyPreview = New System.Windows.Forms.MenuItem
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(240, 268)
        Me.ListView1.TabIndex = 0
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.mnuFile)
        Me.mainMenu1.MenuItems.Add(Me.mnuOptions)
        '
        'mnuFile
        '
        Me.mnuFile.MenuItems.Add(Me.mnuSave)
        Me.mnuFile.MenuItems.Add(Me.mnuExit)
        Me.mnuFile.MenuItems.Add(Me.mnuClearLog)
        Me.mnuFile.Text = "File"
        '
        'mnuSave
        '
        Me.mnuSave.Text = "Save"
        '
        'mnuExit
        '
        Me.mnuExit.Text = "Exit"
        '
        'mnuClearLog
        '
        Me.mnuClearLog.Text = "Clear Log"
        '
        'mnuOptions
        '
        Me.mnuOptions.MenuItems.Add(Me.mnuForwardFKeys)
        Me.mnuOptions.MenuItems.Add(Me.mnuAllkeys)
        Me.mnuOptions.MenuItems.Add(Me.mnuKeyPreview)
        Me.mnuOptions.Text = "Options"
        '
        'mnuForwardFKeys
        '
        Me.mnuForwardFKeys.Checked = True
        Me.mnuForwardFKeys.Text = "Forward F Keys"
        '
        'mnuAllkeys
        '
        Me.mnuAllkeys.Checked = True
        Me.mnuAllkeys.Text = "AllKeys"
        '
        'mnuKeyPreview
        '
        Me.mnuKeyPreview.Text = "Keypreview"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.ListView1)
        Me.Menu = Me.mainMenu1
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "KeyTest3AKvb"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Private WithEvents mainMenu1 As System.Windows.Forms.MainMenu
    Private WithEvents mnuFile As System.Windows.Forms.MenuItem
    Private WithEvents mnuSave As System.Windows.Forms.MenuItem
    Private WithEvents mnuExit As System.Windows.Forms.MenuItem
    Private WithEvents mnuClearLog As System.Windows.Forms.MenuItem
    Private WithEvents mnuOptions As System.Windows.Forms.MenuItem
    Private WithEvents mnuForwardFKeys As System.Windows.Forms.MenuItem
    Private WithEvents mnuAllkeys As System.Windows.Forms.MenuItem
    Private WithEvents mnuKeyPreview As System.Windows.Forms.MenuItem

End Class
