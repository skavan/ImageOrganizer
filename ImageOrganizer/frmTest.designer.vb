<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTest
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTest))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.gbxTagValues = New System.Windows.Forms.GroupBox()
        Me.lvTagList = New System.Windows.Forms.ListView()
        Me.colTagName = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.colValue = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.colPrintValue = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gbxTagValues.SuspendLayout
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TableLayoutPanel1.SuspendLayout
        Me.GroupBox1.SuspendLayout
        Me.SuspendLayout
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(6, 25)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(376, 26)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "G:\Pictures\Lacie_E\P1010001.JPG"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(388, 57)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(140, 50)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Read Values"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(6, 57)
        Me.TextBox2.Multiline = true
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox2.Size = New System.Drawing.Size(376, 289)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Text = resources.GetString("TextBox2.Text")
        '
        'gbxTagValues
        '
        Me.gbxTagValues.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.gbxTagValues, 2)
        Me.gbxTagValues.Controls.Add(Me.lvTagList)
        Me.gbxTagValues.Location = New System.Drawing.Point(4, 404)
        Me.gbxTagValues.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gbxTagValues.Name = "gbxTagValues"
        Me.gbxTagValues.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gbxTagValues.Size = New System.Drawing.Size(1326, 567)
        Me.gbxTagValues.TabIndex = 7
        Me.gbxTagValues.TabStop = false
        Me.gbxTagValues.Text = "Tag Values for the above selected file"
        '
        'lvTagList
        '
        Me.lvTagList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colTagName, Me.colValue, Me.colPrintValue})
        Me.lvTagList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvTagList.Location = New System.Drawing.Point(4, 24)
        Me.lvTagList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lvTagList.Name = "lvTagList"
        Me.lvTagList.Size = New System.Drawing.Size(1318, 538)
        Me.lvTagList.TabIndex = 2
        Me.lvTagList.UseCompatibleStateImageBehavior = false
        Me.lvTagList.View = System.Windows.Forms.View.Details
        '
        'colTagName
        '
        Me.colTagName.Text = "Tag Name"
        Me.colTagName.Width = 200
        '
        'colValue
        '
        Me.colValue.Text = "Value"
        Me.colValue.Width = 200
        '
        'colPrintValue
        '
        Me.colPrintValue.Text = "Print Value"
        Me.colPrintValue.Width = 200
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(388, 113)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(140, 53)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Write Date"
        Me.Button2.UseVisualStyleBackColor = true
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(670, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(661, 393)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = false
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.gbxTagValues, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox1, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.88115!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.11885!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1334, 976)
        Me.TableLayoutPanel1.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(661, 393)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "File && Tag Selection"
        '
        'frmTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9!, 20!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1334, 976)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmTest"
        Me.Text = "frmTest"
        Me.gbxTagValues.ResumeLayout(false)
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents gbxTagValues As GroupBox
    Friend WithEvents lvTagList As ListView
    Friend WithEvents colTagName As ColumnHeader
    Friend WithEvents colValue As ColumnHeader
    Friend WithEvents colPrintValue As ColumnHeader
    Friend WithEvents Button2 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupBox1 As GroupBox
End Class
