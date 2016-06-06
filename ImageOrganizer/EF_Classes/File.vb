Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class File

    Public Enum eFileType
        Unknown
        Photo
        Photoshop
        Image
        Video
        Other
    End Enum

    Public Enum eFileStatus
        None = 0
        MissingDate = 1
    End Enum

    Public Sub New()
	End Sub

    ' Primary Key
    Public Property ID() As Integer
    Public Property DirectoryID_FK() As Integer

    '// max length important to allow index creation
    <Index, MaxLength(260)> _
    Public Property FullPath As String
    <Index, MaxLength(260)> _
    Public Property Filename As String
    Public Property Extension As String
    Public Property FileSize As Integer
    Public Property FileType As eFileType
    <Display(Name := "Creation Date")> _
    Public Property CreationDate() As System.Nullable(Of DateTime)

    Public Property CameraMake As String
    Public Property CameraModel As String
    <Display(Name := "Shoot Date")> _
    Public Property ShootDate() As System.Nullable(Of DateTime)
    
    Public Property FileStatus As eFileStatus
    Public Property Width As Integer
    Public Property Height As Integer
    Public Overridable Property Directory() As Directory
End Class
