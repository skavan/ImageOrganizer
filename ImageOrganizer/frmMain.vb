Imports System.Data.Entity
Imports System.Data.Entity.Core.Objects
Imports System.Runtime.Remoting.Contexts

Public Class frmMain
    Dim directoryList As New List(Of String)
    Dim fileList As New List(Of String)
    Dim WithEvents dbContext As New ScanContext

    
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        
        dbContext = New ScanContext
        ScanDirectoriesAndRebuild(ButtonEdit1.Text, dbContext)
        dbContext.SaveChanges

        dbContext = New ScanContext
        dbContext.Directories.Load
        'GridControl1.DataSource = (From r in dbContext.Directories Order by r.Path).ToList
        GridControl1.DataSource = dbContext.Directories.Local.ToBindingList
        Debug.Print("finished")
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
        ScanDirectories(ButtonEdit1.Text, dbContext, false)
        dbContext.SaveChanges
        dbContext = New ScanContext
        dbContext.Directories.Load
        GridControl1.DataSource = dbContext.Directories.Local.ToBindingList
        Debug.Print("finished")
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        dbContext = New ScanContext
            Dim results = (From s In dbContext.Directories Where s.PctImages<1 Select s).ToList
            For each item As Directory In results
                dbContext.Directories.Remove(item)
            Next
            dbContext.SaveChanges
    End Sub

    Private Sub ReloadData(optional Sql As String = "")
        dbContext = New ScanContext
        dbContext.Directories.Load
        If Sql = "" Then
            GridControl1.DataSource = dbContext.Directories.Local.ToBindingList
        Else
            GridControl1.DataSource = (From r in dbContext.Directories Order by r.Path).ToList
        End If
    End Sub
End Class