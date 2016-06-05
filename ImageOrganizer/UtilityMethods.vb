
Imports System.Collections.ObjectModel
Imports System.Data.Entity
Imports System.IO
Imports Microsoft.WindowsAPICodePack.Shell
Imports Microsoft.WindowsAPICodePack.Shell.PropertySystem

Module UtilityMethods


' Process all files in the directory passed in, recurse on any directories  
' that are found, and process the files they contain. 
'optional rebuild determines whether we add new recs or attempt to update existing ones
    Public Sub ScanDirectoriesAndRebuild(targetDirectory As String, ByRef dbContext As ScanContext)
        '// wipe database
        'dbContext.Directories.
        dbContext.Database.ExecuteSqlCommand("DELETE FROM Directories Where 1=1")
        dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE Files")
        dbContext.SaveChanges
        dbContext = New ScanContext
        ScanDirectories(targetDirectory, dbContext, True)
    End Sub
    

    Public Sub ScanDirectories(targetDirectory As String, ByRef dbContext As ScanContext, rebuild As Boolean)
        ' Process the list of files found in the directory. 
        Dim di As DirectoryInfo = New DirectoryInfo(targetDirectory)
        ProcessDirectoryAndFiles(di, dbcontext, rebuild)

        ' Recurse into subdirectories of this directory. 
        
        For Each subdirectory As DirectoryInfo In di.GetDirectories
            ScanDirectories(subdirectory.FullName, dbContext, rebuild)
        Next
    End Sub
    
    Public Sub ProcessDirectoryAndFiles(di As DirectoryInfo, byref dbContext As ScanContext, rebuild As Boolean)
        Dim newdir As Directory 
        
        If rebuild Then
            newdir = New Directory With {.Path = di.FullName}
            dbContext.Directories.Add(newdir)
        Else
            '// Query for the Blog named ADO.NET Blog 
            Dim ex = dbcontext.Directories.FirstOrDefault(Function (b) b.Path = di.FullName)
            If ex IsNot Nothing Then
                newdir = ex
            Else
                newdir = New Directory With {.Path = di.FullName}
                dbContext.Directories.Add(newdir)
            End If
        End If

        

        
        Dim numFiles As Integer = 0
        Dim numImages As Integer = 0
        Dim numNonImages As Integer = 0
        Dim pct As Single = 0

        For Each fi In di.GetFiles
            If fi.Name.ToLower <> "thumbs.db" Then 
                numFiles += 1
                If fi.Extension.ToLower = ".jpg" Then
                    numImages += 1
                Else
                    numNonImages += 1
                End If
                Dim newfi As New File With {.Path=fi.FullName}
                newdir.Files.Add(newfi)
                newfi.Extension = fi.Extension
                newfi.Filename = fi.Name
                newfi = ProcessFile(fi, newfi)
            End If
        Next
        
        newdir.NumFiles = numFiles
        newdir.NumImages = numImages
        newdir.NumNonImages = numNonImages
        If numFiles>0 Then newdir.PctImages = numImages/numFiles
    End Sub

    ' Insert logic for processing found files here. 
    Public Function ProcessFile(fi As FileInfo, newfi As File) As File
        Dim pic As ShellObject = ShellObject.FromParsingName(fi.FullName)
        newfi.CameraMake = GetValue(pic.Properties.GetProperty(SystemProperties.System.Photo.CameraManufacturer))
        newfi.CameraModel = GetValue(pic.Properties.GetProperty(SystemProperties.System.Photo.CameraModel))
        Dim datetaken = GetValue(pic.Properties.GetProperty(SystemProperties.System.Photo.DateTaken))
        If datetaken<>"" Then
            'Debug.Print("a date is found!")
            newfi.ShootDate = dateTaken
        Else
            Dim d1 = fi.CreationTime
            Dim d2 = fi.LastWriteTime
            If newfi.CameraMake<>"" Then
                newfi.ShootDate = d2
            End If
        End If
        Console.WriteLine("Processed file '{0}'.", fi.Name)
        Return newfi
    End Function

    Private Function GetValue(value As IShellProperty) As String
		If value Is Nothing OrElse value.ValueAsObject Is Nothing Then
			Return ""
		End If
		Return value.ValueAsObject.ToString()
	End Function
    

End Module
