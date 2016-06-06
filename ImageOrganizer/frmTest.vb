Imports ExifToolLib
Imports System.IO
Imports System.ComponentModel

Public Class frmTest
    'Private FileTagList As New List(Of FileTagValues)
    Private fileTagValues As FileTagValues
    
Public Sub ShowInfo(fn As String)
        Me.Show
        TextBox1.Text = fn
        fileTagValues = New FileTagValues(fn, true)
        PictureBox1.ImageLocation = fn
        ShowTagValues
End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim st As New Stopwatch
        st.Start
        'Dim paramText As String = TextBox2.Text.Replace(vbCr,"")
        'Dim tagList() As String = paramText.Split(vbLf)
        
        fileTagValues = New FileTagValues(TextBox1.Text, true)
        'FileTagList.Add(fileTagValues)
        ShowTagValues
        Debug.Print("Elapsed milliseconds: {0}",st.ElapsedMilliseconds)
        st.stop

    End Sub

    Private Sub frmTest_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim ExifToolReturnCode As Integer = ExifToolIO.Close()
    End Sub

    Private Sub frmTest_Load(sender As Object, e As EventArgs) Handles Me.Load
        StartExifTool()
    End Sub

    Private Sub ShowTagValues()
        'If FileTagList.Count = 0 Then Return

        Me.lvTagList.Items.Clear()
        Dim values As List(Of TagValue) = fileTagValues.TagValueList

        Me.gbxTagValues.Text = Path.GetFileName(fileTagValues.FileName)

        For Each tv As TagValue In values
            Dim group As ListViewGroup = Nothing
            For Each g As ListViewGroup In Me.lvTagList.Groups
                If g.Header = tv.Group Then
                    group = g
                    Exit For
                End If
            Next

            If group Is Nothing Then
                group = New ListViewGroup(tv.Group)
                Me.lvTagList.Groups.Add(group)
            End If

            If tv.PrintValue.Count > 1 Then
                For i As Integer = 0 To tv.PrintValue.Count - 1
                    If tv.Value Is Nothing Then
                        Me.lvTagList.Items.Add(New ListViewItem({tv.Name & "(" & i & ")", "", tv.PrintValue(i)}, group))
                    Else
                        Me.lvTagList.Items.Add(New ListViewItem({tv.Name & "(" & i & ")", tv.Value(i), tv.PrintValue(i)}, group))
                    End If
                Next
            Else
                If tv.Value Is Nothing Then
                    Me.lvTagList.Items.Add(New ListViewItem({tv.Name, "", tv.PrintValue(0)}, group))
                Else
                    Me.lvTagList.Items.Add(New ListViewItem({tv.Name, tv.Value(0), tv.PrintValue(0)}, group))
                End If
            End If
        Next
    End Sub

    Private Sub StartExifTool()
        If ExifToolIO.Initiailize() Then
            Me.Text = "ExifToolIO.dll demo and test program - exiftool version currently loaded: " & ExifToolIO.LoadedVersion
            'Me.cbxUseResourcesExifToolExe.Text = "Use exiftool.exe from resources? (version " & ExifToolIO.ResourcesVersion & ")"
        Else
            MsgBox("Exiftool initialization failed")
            Application.Exit()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For Each item As TagValue In fileTagValues.TagValueList
            If item.Name="CreateDate" Then
                item.Value = {"2005:10:25 14:40"}
                fileTagValues.WriteOneTag(TextBox1.Text, item, true)
            End If
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) 
        'Dim xmp As Xmp = xmp.FromFile(TextBox1.Text)

    End Sub
End Class