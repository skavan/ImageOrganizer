<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonEdit1 = New DevExpress.XtraEditors.ButtonEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.TabPane1 = New DevExpress.XtraBars.Navigation.TabPane()
        Me.TabNavigationPage1 = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TabNavigationPage2 = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.PanelControl1.SuspendLayout
        CType(Me.ButtonEdit1.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.BarManager1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TabPane1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabPane1.SuspendLayout
        Me.TabNavigationPage1.SuspendLayout
        CType(Me.GridControl1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabNavigationPage2.SuspendLayout
        CType(Me.GridControl2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SimpleButton5)
        Me.PanelControl1.Controls.Add(Me.SimpleButton4)
        Me.PanelControl1.Controls.Add(Me.SimpleButton3)
        Me.PanelControl1.Controls.Add(Me.SimpleButton2)
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Controls.Add(Me.ButtonEdit1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 54)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1365, 125)
        Me.PanelControl1.TabIndex = 0
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Location = New System.Drawing.Point(900, 40)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(131, 37)
        Me.SimpleButton4.TabIndex = 5
        Me.SimpleButton4.Text = "Update dB"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Location = New System.Drawing.Point(763, 40)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(131, 37)
        Me.SimpleButton3.TabIndex = 4
        Me.SimpleButton3.Text = "Load"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Location = New System.Drawing.Point(626, 40)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(131, 37)
        Me.SimpleButton2.TabIndex = 3
        Me.SimpleButton2.Text = "Clear"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(489, 40)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(131, 37)
        Me.SimpleButton1.TabIndex = 2
        Me.SimpleButton1.Text = "Build dB"
        '
        'ButtonEdit1
        '
        Me.ButtonEdit1.EditValue = "G:\Pictures\Lacie"
        Me.ButtonEdit1.Location = New System.Drawing.Point(13, 46)
        Me.ButtonEdit1.MenuManager = Me.BarManager1
        Me.ButtonEdit1.Name = "ButtonEdit1"
        Me.ButtonEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("ButtonEdit1.Properties.Buttons"),System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, true)})
        Me.ButtonEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.ButtonEdit1.Size = New System.Drawing.Size(470, 26)
        Me.ButtonEdit1.TabIndex = 1
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1, Me.Bar2, Me.Bar3})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 0
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 1
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.Text = "Tools"
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.OptionsBar.MultiLine = true
        Me.Bar2.OptionsBar.UseWholeRow = true
        Me.Bar2.Text = "Main menu"
        '
        'Bar3
        '
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.OptionsBar.AllowQuickCustomization = false
        Me.Bar3.OptionsBar.DrawDragBorder = false
        Me.Bar3.OptionsBar.UseWholeRow = true
        Me.Bar3.Text = "Status bar"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = false
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1365, 54)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = false
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 757)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1365, 26)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = false
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 54)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 703)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = false
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1365, 54)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 703)
        '
        'TabPane1
        '
        Me.TabPane1.Controls.Add(Me.TabNavigationPage1)
        Me.TabPane1.Controls.Add(Me.TabNavigationPage2)
        Me.TabPane1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabPane1.Location = New System.Drawing.Point(0, 179)
        Me.TabPane1.Name = "TabPane1"
        Me.TabPane1.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.TabNavigationPage1, Me.TabNavigationPage2})
        Me.TabPane1.RegularSize = New System.Drawing.Size(1365, 578)
        Me.TabPane1.SelectedPage = Me.TabNavigationPage2
        Me.TabPane1.SelectedPageIndex = 0
        Me.TabPane1.Size = New System.Drawing.Size(1365, 578)
        Me.TabPane1.TabIndex = 1
        Me.TabPane1.Text = "TabPane1"
        '
        'TabNavigationPage1
        '
        Me.TabNavigationPage1.Caption = "TabNavigationPage1"
        Me.TabNavigationPage1.Controls.Add(Me.GridControl1)
        Me.TabNavigationPage1.Name = "TabNavigationPage1"
        Me.TabNavigationPage1.Size = New System.Drawing.Size(1339, 510)
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.MenuManager = Me.BarManager1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1339, 510)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'TabNavigationPage2
        '
        Me.TabNavigationPage2.Caption = "TabNavigationPage2"
        Me.TabNavigationPage2.Controls.Add(Me.GridControl2)
        Me.TabNavigationPage2.Name = "TabNavigationPage2"
        Me.TabNavigationPage2.Size = New System.Drawing.Size(1339, 510)
        '
        'GridControl2
        '
        Me.GridControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl2.Location = New System.Drawing.Point(0, 0)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.MenuManager = Me.BarManager1
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(1339, 510)
        Me.GridControl2.TabIndex = 1
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        '
        'SimpleButton5
        '
        Me.SimpleButton5.Location = New System.Drawing.Point(1182, 40)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(131, 37)
        Me.SimpleButton5.TabIndex = 6
        Me.SimpleButton5.Text = "Delete Test"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(144!, 144!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1365, 783)
        Me.Controls.Add(Me.TabPane1)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "frmMain"
        Me.Text = "frmMain"
        CType(Me.PanelControl1,System.ComponentModel.ISupportInitialize).EndInit
        Me.PanelControl1.ResumeLayout(false)
        CType(Me.ButtonEdit1.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.BarManager1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TabPane1,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabPane1.ResumeLayout(false)
        Me.TabNavigationPage1.ResumeLayout(false)
        CType(Me.GridControl1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabNavigationPage2.ResumeLayout(false)
        CType(Me.GridControl2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView2,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TabPane1 As DevExpress.XtraBars.Navigation.TabPane
    Friend WithEvents TabNavigationPage1 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents TabNavigationPage2 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents ButtonEdit1 As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
End Class
