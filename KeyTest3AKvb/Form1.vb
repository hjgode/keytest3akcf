Imports KeybdHook
Imports System.Text

Public Class Form1
    Dim WithEvents _keyhook As KeybdHook.KeyHook.KeyboardHook
    Dim _bForwardKeys As Boolean = False

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initListView()
        _keyhook = New KeybdHook.KeyHook.KeyboardHook(Me)

        'AddHandler _keyhook.HookEvent, AddressOf hookProc 'do not use or you will get messages twice
        win32.AllKeys(True)
    End Sub

    Public Sub hookProc(ByVal sender As Object, ByVal hookArgs As KeybdHook.KeyHook.KeyboardHook.HookEventArgs) Handles _keyhook.HookEvent
        'System.Diagnostics.Debug.WriteLine("hookProc: " + hookArgs.wParam.ToInt32().ToString("X8"))

        addItem(hookArgs)
        Select Case hookArgs.wParam.ToInt32()
            Case WindowsMessages.WM_KEYDOWN
                System.Diagnostics.Debug.WriteLine("WM_KEYDOWN: " + hookArgs.hookstruct.vkCode.ToString("X8"))
            Case WindowsMessages.WM_KEYUP
                System.Diagnostics.Debug.WriteLine("WM_KEYUP: " + hookArgs.hookstruct.vkCode.ToString("X8"))
        End Select
    End Sub

    '##############################
    Private Sub initListView()
        Dim col0 As ColumnHeader, col1 As ColumnHeader, col2 As ColumnHeader
        col0 = New ColumnHeader()
        col0.Text = "Message"
        col0.TextAlign = HorizontalAlignment.Left
        col0.Width = ListView1.Width / 3

        col1 = New ColumnHeader()
        col1.Text = "vkCode"
        col1.TextAlign = HorizontalAlignment.Left
        col1.Width = listView1.Width / 3

        col2 = New ColumnHeader()
        col2.Text = "lParam"
        col2.TextAlign = HorizontalAlignment.Left
        col2.Width = listView1.Width / 3

        listView1.Columns.Add(col0)
        listView1.Columns.Add(col1)
        listView1.Columns.Add(col2)

        listView1.View = View.Details
    End Sub
    Private Sub addItem(ByVal hookArgs As KeybdHook.KeyHook.KeyboardHook.HookEventArgs)
        Dim lvi As New ListViewItem(CType(hookArgs.wParam, WindowsMessages.WM_MESG).ToString())
        'lvi.SubItems.Add(win32.helpers.hex8(hookArgs.hookstruct.vkCode));
        lvi.SubItems.Add(CType(hookArgs.hookstruct.vkCode, vkcodes.VKEY).ToString())
        lvi.SubItems.Add(win32.helpers.hex8(hookArgs.hookstruct.scanCode))
        ListView1.Items.Add(lvi)
        ListView1.EnsureVisible(ListView1.Items.Count - 1)
    End Sub

    Private Sub mnuClearLog_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClearLog.Click
        ListView1.Items.Clear()
    End Sub

    Private Sub mnuExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Application.Exit()
    End Sub

    Private Sub mnuSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSave.Click
        If ListView1.Items.Count > 0 Then
            Dim sfd As New SaveFileDialog()
            sfd.Filter = "*.txt|*.txt|*.*|*.*"

            If sfd.ShowDialog() = DialogResult.OK Then
                Using sw As New System.IO.StreamWriter(sfd.FileName)
                    'sw.WriteLine(txtLog.Text)
                    sw.WriteLine(ListViewHelper.ListViewToCSV(ListView1, sfd.FileName, True))
                    sw.Flush()
                End Using
            End If
        End If
    End Sub

    Private Sub mnuForwardFKeys_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuForwardFKeys.Click
        mnuForwardFKeys.Checked = Not mnuForwardFKeys.Checked
        _bForwardKeys = mnuForwardFKeys.Checked
        _keyhook._consumeKey = Not mnuForwardFKeys.Checked
    End Sub

    '##########################################
    Class ListViewHelper
        Public Shared Function ListViewToCSV(ByVal listView As ListView, ByVal filePath As String, ByVal includeHidden As Boolean) As String
            'make header string
            Dim result As New StringBuilder()
            WriteCSVRow(result, listView.Columns.Count, Function(i) includeHidden OrElse listView.Columns(i).Width > 0, Function(i) listView.Columns(i).Text)

            'export data rows
            For Each listItem As ListViewItem In listView.Items
                WriteCSVRow(result, listView.Columns.Count, Function(i) includeHidden OrElse listView.Columns(i).Width > 0, Function(i) listItem.SubItems(i).Text)
            Next

            'File.WriteAllText(filePath, result.ToString());
            Return result.ToString()
        End Function

        Private Shared Sub WriteCSVRow(ByVal result As StringBuilder, ByVal itemsCount As Integer, ByVal isColumnNeeded As Func(Of Integer, Boolean), ByVal columnValue As Func(Of Integer, String))
            Dim isFirstTime As Boolean = True
            For i As Integer = 0 To itemsCount - 1
                If Not isColumnNeeded(i) Then
                    Continue For
                End If

                If Not isFirstTime Then
                    result.Append(",")
                End If
                isFirstTime = False

                result.Append([String].Format("""{0}""", columnValue(i)))
            Next
            result.AppendLine()
        End Sub
    End Class

    Private Sub mnuAllkeys_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAllkeys.Click
        mnuAllkeys.Checked = Not mnuAllkeys.Checked
        win32.AllKeys(mnuAllkeys.Checked)

    End Sub
End Class
