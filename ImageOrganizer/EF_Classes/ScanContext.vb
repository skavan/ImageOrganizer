Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions

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
        modelBuilder.Entity(Of File)().Property(Function(t) t.FullPath).IsRequired()
        '// set column names
        'modelBuilder.Entity(Of Directory)().Property(Function(t) t.PctPhotos).
        '    HasColumnName("Pct")
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
