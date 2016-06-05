Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class Directory
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub New()
        Me.Files = New ObservableCollection(Of File)()
	End Sub

    Private Sub NotifyPropertyChanged()
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(String.Empty))
    End Sub


    ' Primary Key
    Public Property ID() As Integer

    Public Property Path As String
    Public Property NumFiles As Integer
    Public Property NumImages As Integer
    Public Property NumNonImages As Integer
    <DisplayFormat(ApplyFormatInEditMode := True, DataFormatString := "{0:P2}")> _
    Public Property PctImages As Single
    Public Overridable Property Files() As ObservableCollection(Of File)
End Class

Public Class File
    Public Sub New()
	End Sub

    ' Primary Key
    Public Property ID() As Integer
    Public Property DirectoryID_FK() As Integer

    Public Property Path As String
    Public Property Filename As String
    Public Property Extension As String
    Public Property FileSize As Integer
    Public Property FileType As eFileType
    Public Property Camera As String
    <Display(Name := "Shoot Date")> _
    Public Property ShootDate() As System.Nullable(Of DateTime)
    
    Public Property Width As Integer
    Public Property Height As Integer
    Public Overridable Property Directory() As Directory
End Class

Public Enum eFileType
    Unknown
    Photo
    Image
    Video
    Other
End Enum

Public Class ScanContext
	Inherits Entity.DbContext
    Public Event DataChanged 

	Public Property Directories() As Entity.DbSet(Of Directory)
    Public Property Files() As Entity.DbSet(Of File)

    Public Overloads Overrides Function SaveChanges As Integer
        RaiseEvent DataChanged
        Return MyBase.SaveChanges
    End Function


    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        '// disable default tables naming convention
        modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()
        '// create default values
        'modelBuilder.Entity(Of File)().
        'Map(Of File)(Function(t) t.Requires("FileType").
        '    HasValue(eFileType.Unknown))
        '// create table names
        modelBuilder.Entity(Of Directory)().ToTable("Directories")
        modelBuilder.Entity(Of File)().ToTable("Files")
        '// set widths
        'modelBuilder.Entity(Of File)().Property(Function(t) t.Extension).
        'HasMaxLength(3)
        '// specify required fields
        modelBuilder.Entity(Of Directory)().Property(Function(t) t.Path).IsRequired()
        modelBuilder.Entity(Of File)().Property(Function(t) t.Path).IsRequired()
        '// set column names
        modelBuilder.Entity(Of Directory)().Property(Function(t) t.PctImages).
            HasColumnName("Pct")
        '// connect foreign key
        modelBuilder.Entity(Of File)().HasRequired(Function(t) t.Directory).
            WithMany(Function(t) t.Files).
            HasForeignKey(Function(t) t.DirectoryID_FK)
        '// cascade delete
        modelBuilder.Entity(Of File)().
            HasRequired(Function(t) t.Directory).
            WithMany(Function(t) t.Files).
            HasForeignKey(Function(d) d.DirectoryID_FK).
            WillCascadeOnDelete(True)
    End Sub

End Class