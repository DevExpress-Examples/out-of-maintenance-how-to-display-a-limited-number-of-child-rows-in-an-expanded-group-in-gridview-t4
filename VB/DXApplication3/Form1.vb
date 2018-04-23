Imports System

Namespace DXApplication3
    Partial Public Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            ' TODO: This line of code loads data into the 'nWindDataSet.Products' table. You can move, or remove it, as needed.
            Me.productsTableAdapter.Fill(Me.nWindDataSet.Products)
            Dim helper = New GroupHelper(gridView1) With {.VisibleNumber = 7}
            gridView1.Columns("ReorderLevel").Group()
            gridView1.ExpandAllGroups()
        End Sub
    End Class
End Namespace
