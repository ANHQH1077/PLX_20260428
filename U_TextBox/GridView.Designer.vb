Imports System.Drawing
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GridView

    Inherits DevExpress.XtraGrid.Views.Grid.GridView

    'UserControl overrides dispose to clean up the component list.
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
        components = New System.ComponentModel.Container()

        '  SetGridFont(Me, New Font("Tahoma", 12))
        'For Each ap In view.Appearance
        '    ap.Font = Font
        'Next
    End Sub

    Sub SetGridFont(ByVal view As GridView, ByVal font As Font)
        Dim ap As AppearanceObject
        For Each ap In view.Appearance
            ap.Font = font
        Next
    End Sub


    'Protected Overrides Function CreateColumnCollection() As DevExpress.XtraGrid.Columns.GridColumnCollection
    '    Dim p_Column As New GridColumn
    '    MyBase.CreateColumnCollection.Add(p_Column)

    '    Return MyBase.CreateColumnCollection
    'End Function


    'Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() _
    '                                  {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4})
    'Protected Overrides ON


    'Protected Overloads Sub AddRange(ByVal column As GridColumn)
    '    MyBase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {column})
    'End Sub

    'Protected MustInherit GridColumn


    'Protected Overrides Sub OnColumnAdded(ByVal Column As DevExpress.XtraGrid.Columns.GridColumn)  ' ByVal column As GridColumn) 'Handles Me.

    '    Dim p_Column1 As New GridColumn
    '    '  p_Column = CType(p_Column, GridColumn)
    '    Dim p_GridColumn As String = "AGridColumn"
    '    p_Column1.Name = p_GridColumn & Me.Columns.Count + 1
    '    p_Column1.Caption = p_Column1.Name
    '    p_Column1.Visible = Me.Columns.Count + 1

    '    'Column.Name = p_GridColumn & Me.Columns.Count + 1
    '    'Column.Caption = p_GridColumn & Me.Columns.Count + 1
    '    '   p_Column.Name = p_Column1.Name
    '    '   Me.Columns.Add(p_Column1)

    '    MyBase.CreateColumnCollection.Add(p_Column1)
    '    '  MyBase.Columns.AddRange(MyBase.Columns.)
    '    MyBase.OnColumnAdded(p_Column1)
    '    MyBase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {p_Column1})
    '    ' OnColumnDeleted(Column)
    '    OnColumnDeleted(Column)
    '    ' Raise()
    '    'MyBase.Columns.Add(p_Column1)
    '    '  MyBase.Invalidate()
    'End Sub


    'Protected Overloads Sub Add(ByVal p_Column As DevExpress.XtraGrid.Columns.GridColumn)
    '    MyBase.Columns.Add(p_Column)
    'End Sub

    'Protected Overloads Sub AddRange(ByVal p_Column As DevExpress.XtraGrid.Columns.GridColumn)
    '    ' MyBase.Columns.Add()
    '    ' MyBase.Columns.AddRange(MyBase.Columns)
    'End Sub



    'Protected MustOverride Sub OnColumnAdded(ByVal p_Column As DevExpress.XtraGrid.Columns.GridColumn)

    'Dim p_Column1 As New GridColumn
    'p_Column = CType(p_Column, GridColumn)
    'p_Column1.Name = p_Column1.Name & Me.Columns.Count + 1
    '    MyBase.OnColumnAdded(p_Column)
    ' MyBase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {p_Column1})
    'End Sub



    'Protected Overrides Sub on


    'Next
    ' Friend WithEvents Column1 As GridColumn



    'Protected Overrides Sub  AddRange(   (ByVal column As GridColumn)
    '    MyBase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {column})
    'End Sub



    ''Protected Overloads Sub add
    '' Protected Overloads Sub oncolumn

    'Protected Overloads Sub OnColumnDeleted(ByVal column As GridColumn)
    '    MyBase.OnColumnDeleted(column)
    'End Sub



    Friend WithEvents ctlGridView As GridView
    'Friend WithEvents ctlGridView1 As DevExpress.XtraGrid.GridControl
End Class
