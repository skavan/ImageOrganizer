Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class Directory
    Implements INotifyPropertyChanged

    '// what type of directory is it?
    Public Enum eDirectoryType
        Unknown
        GoodPhotoDirectory          '// 100% photos
        DirtyPhotoDirectory         '// Photos + Images = Total File Count
        ImageDirectory              '// 100% non photo images
        MixedDirectory              '// Has Photos, Images and Other
        OtherDirectory              '// No Photos or Images
    End Enum
    '// what type of directory name is it?
    Public Enum eDirectoryNameType
        Unknown
        DateNameDirectory
        DescriptiveNameDirectory
    End Enum

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub New()
        Me.Files = New ObservableCollection(Of File)()
    End Sub

    Private Sub NotifyPropertyChanged()
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(String.Empty))
    End Sub

    ' Primary Key
    Public Property ID() As Integer
    <Index, MaxLength(260)> _
    Public Property Path As String
    <Index, MaxLength(260)> _
    Public Property SubDirName As String
    Public Property NumFiles As Integer
    Public Property NumPhotos As Integer
    Public Property NumImages As Integer
    Public Property NumOther As Integer
    <DisplayFormat(ApplyFormatInEditMode:=True, DataFormatString:="{0:P2}")> _
    Public Property PctImages As Single
    <DisplayFormat(ApplyFormatInEditMode:=True, DataFormatString:="{0:P2}")> _
    Public Property PctPhotos As Single
    Public Property DirectoryType As eDirectoryType=eDirectoryType.Unknown
    Public Property DirectoryNameType As eDirectoryNameType= eDirectoryNameType.Unknown
    Public Overridable Property Files() As ObservableCollection(Of File)
End Class
