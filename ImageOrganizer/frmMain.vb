Imports System.ComponentModel
Imports System.Data.Entity
Imports System.Data.Entity.Core.Objects
Imports System.Runtime.Remoting.Contexts
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class frmMain
    Dim directoryList As New List(Of String)
    Dim fileList As New List(Of String)
    Dim WithEvents dbContext As New ScanContext


    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim st As New Stopwatch : st.Start
        dbContext = New ScanContext
        ScanDirectoriesAndRebuild(ButtonEdit1.Text, dbContext)
        dbContext.SaveChanges

        dbContext = New ScanContext
        dbContext.Directories.Load
        'GridControl1.DataSource = (From r in dbContext.Directories Order by r.Path).ToList
        GridControl1.DataSource = dbContext.Directories.Local.ToBindingList
        Debug.Print("Scanned {0} Directories and {1} Files in {2} milliseconds which averages {3} per file", dbContext.Directories.Count, dbContext.Files.Count, st.ElapsedMilliseconds, st.ElapsedMilliseconds / dbContext.Files.Count)
        Debug.Print("rebuild finished")
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Using dbContext
            dbContext.Database.ExecuteSqlCommand("DELETE FROM Directories Where 1=1")
            dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE Files")
            dbContext.SaveChanges

        End Using
    End Sub

    Private Sub dbContext_DataChanged() Handles dbContext.DataChanged
        'Exit Sub
        'GridControl1.DataSource = (From r in dbContext.Directories Order by r.Path).ToList
        dbContext = New ScanContext

        GridControl1.DataSource = dbContext.Directories.Local.ToBindingList
        Debug.Print("DataChanged")
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        dbContext = New ScanContext
        dbContext.Directories.Load
        GridControl1.DataSource = dbContext.Directories.Local.ToBindingList
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        dbContext = New ScanContext
        Dim st As New Stopwatch : st.Start
        ScanDirectories(ButtonEdit1.Text, dbContext, False, 0)
        dbContext.SaveChanges
        Debug.Print("Scanned {0} Directories and {1} Files in {2} milliseconds which averages {3} per file", dbContext.Directories.Count, dbContext.Files.Count, st.ElapsedMilliseconds, st.ElapsedMilliseconds / dbContext.Files.Count)
        Debug.Print("update finished")
        'dbContext = New ScanContext
        dbContext.Directories.Load
        GridControl1.DataSource = dbContext.Directories.Local.ToBindingList
        st.Stop
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        dbContext = New ScanContext
        Dim results = (From s In dbContext.Directories Where s.PctPhotos < 1 Select s).ToList
        For Each item As Directory In results
            dbContext.Directories.Remove(item)
        Next
        dbContext.SaveChanges
    End Sub

    Private Sub ReloadData(Optional Sql As String = "")
        dbContext = New ScanContext
        dbContext.Directories.Load
        If Sql = "" Then
            GridControl1.DataSource = dbContext.Directories.Local.ToBindingList
        Else
            GridControl1.DataSource = (From r In dbContext.Directories Order By r.Path).ToList
        End If
    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        dbContext = Nothing
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        ExifToolLib.ExifToolIO.Initiailize
    End Sub

    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        ExifToolLib.ExifToolIO.Close
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_MouseClick(sender As Object, e As MouseEventArgs) Handles GridControl1.MouseClick
        If e.Button = MouseButtons.Right Then
            Dim view As GridView = sender.FocusedView
            Dim hitInfo As GridHitInfo = view.CalcHitInfo(e.Location)
            view.SelectRow(hitInfo.RowHandle)
            Dim fn As String = view.GetRow(hitInfo.RowHandle).FullPath
            frmTest.ShowInfo(fn)
        End If
    End Sub
End Class