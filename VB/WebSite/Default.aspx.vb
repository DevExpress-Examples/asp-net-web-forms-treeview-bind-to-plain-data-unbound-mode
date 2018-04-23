Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxTreeView

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim table As DataTable = GetDataTable()
		If (Not IsPostBack) Then
			CreateTreeViewNodesRecursive(table, Me.treeView.Nodes, "0")
		End If
	End Sub

	Private Sub CreateTreeViewNodesRecursive(ByVal table As DataTable, ByVal nodesCollection As TreeViewNodeCollection, ByVal parentID As String)
		For i As Integer = 0 To table.Rows.Count - 1
			If table.Rows(i)("ParentID").ToString() = parentID Then
				Dim node As New TreeViewNode(table.Rows(i)("Title").ToString(), table.Rows(i)("ID").ToString())
				nodesCollection.Add(node)
				CreateTreeViewNodesRecursive(table, node.Nodes, node.Name)
			End If
		Next i
	End Sub

	Private Function GetDataTable() As DataTable

		Dim dt As New DataTable()
		dt.Columns.Add("ID", GetType(System.Int32))
		dt.Columns.Add("Title", GetType(System.String))
		dt.Columns.Add("ParentID", GetType(System.Int32))

		dt.PrimaryKey = New DataColumn() { dt.Columns("ID") }

		dt.Rows.Add(1, "Nokia", 0)
		dt.Rows.Add(2, "N8", 1)
		dt.Rows.Add(3, "N91", 1)
		dt.Rows.Add(4, "Samsung", 0)
		dt.Rows.Add(5, "Corby9", 4)
		dt.Rows.Add(6, "Star", 0)

		Return dt
	End Function
End Class
