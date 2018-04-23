Imports System
Imports System.IO
Imports System.Windows

Namespace SqlGeometryDataAdapterExample
    Partial Public Class MainWindow
        Inherits Window

        Private Const dbPath As String = "..\..\..\Data\SQLG.mdf"


        Private connectionString_Renamed As String = "Data Source=(local);AttachDbFileName=" & Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location, dbPath)) & ";Database=SqlGeometryDemoDB;Integrated Security=True;MultipleActiveResultSets=True"
        Public ReadOnly Property ConnectionString() As String
            Get
                Return connectionString_Renamed
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
            Me.DataContext = ConnectionString
        End Sub
    End Class
End Namespace
