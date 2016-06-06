
Imports System.Collections.ObjectModel
Imports System.Data.Entity
Imports System.IO
Imports ExifToolLib
Imports Microsoft.WindowsAPICodePack.Shell
Imports Microsoft.WindowsAPICodePack.Shell.PropertySystem

Module UtilityMethods

    
' Process all files in the directory passed in, recurse on any directories  
' that are found, and process the files they contain. 
'optional rebuild determines whether we add new recs or attempt to update existing ones
    Public Sub ScanDirectoriesAndRebuild(targetDirectory As String, ByRef dbContext As ScanContext)
        '// wipe database
        dbContext.Database.ExecuteSqlCommand("DELETE FROM Directories Where 1=1")
        dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE Files")
        dbContext.SaveChanges
        '// since we've made direct sql changes, we need to re-initialize the  dbcontext
        dbContext = New ScanContext
        ScanDirectories(targetDirectory, dbContext, True, 0)
    End Sub
    

    Public Sub ScanDirectories(targetDirectory As String, ByRef dbContext As ScanContext, rebuild As Boolean, ByRef filecount As Integer)
        ' Process the list of files found in the directory. 
        Dim di As DirectoryInfo = New DirectoryInfo(targetDirectory)
        '// go fill in the data!
        Dim numFiles As Integer = ProcessDirectoryAndFiles(di, dbcontext, rebuild)
        filecount  = filecount + numFiles
        ' Recurse into subdirectories of this directory. 
        Debug.Print ("Processing directory {0}. NumFiles = {1}, Cumulative File count {2}", di.FullName, numFiles, filecount)
        For Each subdirectory As DirectoryInfo In di.GetDirectories
            ScanDirectories(subdirectory.FullName, dbContext, rebuild, filecount)
        Next
    End Sub
    Public Sub ProcessDirectoryAndFiles2(di As DirectoryInfo, byref dbContext As ScanContext, rebuild As Boolean)
        '// create a directory object
        Dim newdir As Directory 

        '// if in rebuild mode, we just add the record...but if in update mode we need to find the existing directory object
        If rebuild Then
            newdir = New Directory With {.Path = di.FullName}
            dbContext.Directories.Add(newdir)
        Else
            '// Query directory names di.FullName
            Dim ex = dbcontext.Directories.FirstOrDefault(Function (b) b.Path = di.FullName)
            If ex IsNot Nothing Then
                newdir = ex
            Else
                newdir = New Directory With {.Path = di.FullName}
                dbContext.Directories.Add(newdir)
            End If
        End If

    End Sub

    Public Function ProcessDirectoryAndFiles(di As DirectoryInfo, byref dbContext As ScanContext, rebuild As Boolean) As Integer
        
        Dim newdir As Directory 
        '// create fileinfo array once for speed.
        Dim fis As FileInfo() = di.GetFiles
        If fis.Count=0 Then Return 0 
        '// if we are in rebuild mode, then we can just create a new directory entry without checking the database
        If rebuild Then
            newdir = New Directory With {.Path = di.FullName}
            dbContext.Directories.Add(newdir)
        Else
            '// Query directory names for a match, and if it exists, use existing object (di.FullName)
            Dim ex = dbcontext.Directories.FirstOrDefault(Function (b) b.Path = di.FullName)
            If ex IsNot Nothing Then
                newdir = ex
            Else
                newdir = New Directory With {.Path = di.FullName}
                dbContext.Directories.Add(newdir)
            End If
        End If
        
        newdir.SubDirName = newdir.Path.Split(Path.DirectorySeparatorChar).Last()

        '// process all files in this directory
        Dim numFiles As Integer = 0
        Dim numPhotos As Integer = 0
        Dim numImages As Integer = 0
        Dim numOther As Integer = 0
        Dim pct As Single = 0

        
        '// iterate through all files
        For Each fi In fis
            '// ignore thumbs.db
            If fi.Name.ToLower <> "thumbs.db" Then 
                numFiles += 1
                
                '// if rebuilding, ignore current database (assumes its been emptied in advance)
                '// if updating, seach for an existing match and use it if available
                Dim newfi As File 
                If rebuild Then
                    '// in this case, we need to add the file to the parent directory
                    newfi = New File With {.FullPath=fi.FullName}
                    newdir.Files.Add(newfi)
                Else
                    '// Search for a match
                    Dim ex = dbcontext.Files.FirstOrDefault(Function (b) b.FullPath = fi.FullName)
                    If ex IsNot Nothing Then
                        newfi = ex
                    Else
                        '// in this case, we need to add the file to the parent directory
                        newfi = New File With {.FullPath=fi.FullName}
                        newdir.Files.Add(newfi)
                    End If
                End If

                '// now let's fill in the file data
                newfi.FileSize = fi.Length
                newfi.Extension = fi.Extension
                newfi.Filename = fi.Name
                newfi.CreationDate = fi.LastWriteTime
                
                '// now fill in EXIF type fields using WinAPICodePack
                newfi = ProcessFile(fi, newfi)

                '// now calculate FileType
                If newfi?.Width > 0 Then
                    '// it's an image or a photo
                    If newfi.CameraMake<>"" Then
                        newfi.FileType=File.eFileType.Photo
                        numPhotos += 1
                    Else
                        newfi.FileType=File.eFileType.Image
                        numImages += 1
                    End If
                Else
                    Select Case newfi.Extension.ToLower
                        Case ".psd",".tga",".tif",".tiff",".ico",".bmp"
                            newfi.FileType=File.eFileType.Image
                            numImages += 1
                        Case Else
                            newfi.FileType=File.eFileType.Other
                            numOther += 1
                    End Select
                    
                End If
                
                
            End If
        Next
        
        newdir.NumFiles = numFiles
        newdir.NumPhotos = numPhotos
        newdir.NumImages = numImages
        newdir.NumOther = numOther
        If numFiles>0 Then newdir.PctPhotos = numPhotos/numFiles Else newdir.PctPhotos = 0
        If numFiles>0 Then newdir.PctImages = numImages/numFiles Else newdir.PctImages = 0
        Select Case newdir.PctPhotos
            Case 0
                If numImages = numFiles Then
                    newdir.DirectoryType = Directory.eDirectoryType.ImageDirectory
                Else
                    If numImages>0 Then
                        newdir.DirectoryType = Directory.eDirectoryType.MixedDirectory
                    Else
                        newdir.DirectoryType = Directory.eDirectoryType.OtherDirectory
                    End If
                End If
            Case 1
                newdir.DirectoryType = Directory.eDirectoryType.GoodPhotoDirectory
            Case Else
                If numImages+numPhotos=numFiles Then
                    newdir.DirectoryType = Directory.eDirectoryType.DirtyPhotoDirectory
                Else
                    newdir.DirectoryType = Directory.eDirectoryType.MixedDirectory
                End If
        End Select
        If IsDate(newdir.SubDirName) Then newdir.DirectoryNameType=Directory.eDirectoryNameType.DateNameDirectory Else newdir.DirectoryNameType=Directory.eDirectoryNameType.DescriptiveNameDirectory
        If numFiles = 0 Then
            '// if its empty. Kill it.
            dbContext.Directories.Remove(newdir)
        End If
        Return numFiles
    End Function

    ' Insert logic for processing found files here. 
    Public Function ProcessFile(fi As FileInfo, newfi As File) As File
        Dim pic As ShellObject = ShellObject.FromParsingName(fi.FullName)
        
        newfi.CameraMake = GetValue(pic.Properties.GetProperty(SystemProperties.System.Photo.CameraManufacturer))
        newfi.CameraModel = GetValue(pic.Properties.GetProperty(SystemProperties.System.Photo.CameraModel))
        newfi.Width = Val(GetValue(pic.Properties.GetProperty(SystemProperties.System.Image.HorizontalSize)))
        newfi.Height = Val(GetValue(pic.Properties.GetProperty(SystemProperties.System.Image.VerticalSize)))
        Dim datetaken = GetValue(pic.Properties.GetProperty(SystemProperties.System.Photo.DateTaken))
        
        If datetaken<>"" Then
            'Debug.Print("a date is found!")
            newfi.ShootDate = dateTaken
            newfi.FileStatus = File.eFileStatus.None
        Else
            newfi.FileStatus=File.eFileStatus.MissingDate
        End If
        'Console.WriteLine("Processed file '{0}'.", fi.Name)
        Return newfi
    End Function

    Private Function GetValue(value As IShellProperty) As String
		If value Is Nothing OrElse value.ValueAsObject Is Nothing Then
			Return ""
		End If
		Return value.ValueAsObject.ToString()
	End Function
    

End Module
