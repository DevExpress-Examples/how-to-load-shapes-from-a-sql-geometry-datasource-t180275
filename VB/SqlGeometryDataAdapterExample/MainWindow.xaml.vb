Imports DevExpress.Xpf.Map
Imports System
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows

Namespace SqlGeometryDataAdapterExample
	Partial Public Class MainWindow
		Inherits Window

		Private Const filePath As String = "..\..\Data\SQLG.mdf"
		Private Shared fullFilePath As String = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath))
		Public ReadOnly Property ConnectionString() As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName=" & fullFilePath & ";Database=SqlGeometryDB;Integrated Security=True;MultipleActiveResultSets=True"

		Public Sub New()
			InitializeComponent()
			Me.DataContext = ConnectionString
		End Sub

		Private Sub MapEditor_MapItemEdited(ByVal sender As Object, ByVal e As DevExpress.Xpf.Map.MapItemEditedEventArgs)
			For Each path As MapPath In e.Items
				Dim id As Integer = Convert.ToInt32(path.Attributes("id").Value)
				Dim modified As String = path.ExportToWkt().ToString()
				path.Attributes("TextCol").Value = "Australia" & " " & DateTime.Now.Second.ToString()

				Using cn As New SqlConnection() With {.ConnectionString = Me.ConnectionString}
					cn.Open()
					' For more information about SRID parameters, see https://docs.microsoft.com/en-us/sql/t-sql/spatial-geography/stsrid-geography-data-type?view=sql-server-ver15
					Dim updatecmd As New SqlCommand("UPDATE DemoTable SET GeomCol1 = geometry::STGeomFromText('" & modified & "', 4326 ) WHERE id = " & id.ToString(), cn)
					updatecmd.ExecuteNonQuery()

					Dim updateattr As New SqlCommand("UPDATE DemoTable SET TextCol = '" & path.Attributes("TextCol").Value.ToString() & "' WHERE id =" & id.ToString(), cn)
					updateattr.ExecuteNonQuery()
				End Using
			Next path
		End Sub

		Private Sub VectorLayer_DataLoaded(ByVal sender As Object, ByVal e As DataLoadedEventArgs)
			mapControl.ZoomToFitLayerItems()
		End Sub
	End Class
End Namespace