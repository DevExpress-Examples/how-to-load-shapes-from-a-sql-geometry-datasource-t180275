Imports DevExpress.Xpf.Map
Imports System
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows

Namespace SqlGeometryDataAdapterExample

    Public Partial Class MainWindow
        Inherits System.Windows.Window

        Const filePath As String = "..\..\Data\SQLG.mdf"

        Private Shared fullFilePath As String = System.IO.Path.GetFullPath(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, SqlGeometryDataAdapterExample.MainWindow.filePath))

        Public ReadOnly Property ConnectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName=" & SqlGeometryDataAdapterExample.MainWindow.fullFilePath & ";Database=SqlGeometryDB;Integrated Security=True;MultipleActiveResultSets=True"

        Public Sub New()
            Me.InitializeComponent()
            Me.DataContext = Me.ConnectionString
        End Sub

        Private Sub MapEditor_MapItemEdited(ByVal sender As Object, ByVal e As DevExpress.Xpf.Map.MapItemEditedEventArgs)
            For Each path As DevExpress.Xpf.Map.MapPath In e.Items
                Dim id As Integer = System.Convert.ToInt32(path.Attributes(CStr(("id"))).Value)
                Dim modified As String = path.ExportToWkt().ToString()
                path.Attributes(CStr(("TextCol"))).Value = "Australia" & " " & System.DateTime.Now.Second.ToString()
                Using cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection() With {.ConnectionString = Me.ConnectionString}
                    cn.Open()
                    ' For more information about SRID parameters, see https://docs.microsoft.com/en-us/sql/t-sql/spatial-geography/stsrid-geography-data-type?view=sql-server-ver15
                    Dim updatecmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand("UPDATE DemoTable SET GeomCol1 = geometry::STGeomFromText('" & modified & "', 4326 ) WHERE id = " & id.ToString(), cn)
                    updatecmd.ExecuteNonQuery()
                    Dim updateattr As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand("UPDATE DemoTable SET TextCol = '" & path.Attributes(CStr(("TextCol"))).Value.ToString() & "' WHERE id =" & id.ToString(), cn)
                    updateattr.ExecuteNonQuery()
                End Using
            Next
        End Sub

        Private Sub VectorLayer_DataLoaded(ByVal sender As Object, ByVal e As DevExpress.Xpf.Map.DataLoadedEventArgs)
            Me.mapControl.ZoomToFitLayerItems()
        End Sub
    End Class
End Namespace
