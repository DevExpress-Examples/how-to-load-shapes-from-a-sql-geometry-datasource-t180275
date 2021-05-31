using DevExpress.Xpf.Map;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows;

namespace SqlGeometryDataAdapterExample {
    public partial class MainWindow : Window {

        const string filePath = "..\\..\\Data\\SQLG.mdf";
        static string fullFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath));
        public string ConnectionString { get; } = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName=" + fullFilePath + ";Database=SqlGeometryDB;Integrated Security=True;MultipleActiveResultSets=True";

        public MainWindow() {
            InitializeComponent();
            this.DataContext = ConnectionString;
        }

        private void MapEditor_MapItemEdited(object sender, DevExpress.Xpf.Map.MapItemEditedEventArgs e) {
            foreach (MapPath path in e.Items) {
                int id = Convert.ToInt32(path.Attributes["id"].Value);
                string modified = path.ExportToWkt().ToString();
                path.Attributes["TextCol"].Value = "Australia" + " " + DateTime.Now.Second.ToString();

                using (SqlConnection cn = new SqlConnection() { ConnectionString = this.ConnectionString }) {
                    cn.Open();
                    // For more information about SRID parameters, see https://docs.microsoft.com/en-us/sql/t-sql/spatial-geography/stsrid-geography-data-type?view=sql-server-ver15
                    SqlCommand updatecmd = new SqlCommand("UPDATE DemoTable SET GeomCol1 = geometry::STGeomFromText('" + modified + "', 4326 ) WHERE id = " + id.ToString(), cn);
                    updatecmd.ExecuteNonQuery();

                    SqlCommand updateattr = new SqlCommand("UPDATE DemoTable SET TextCol = '" + path.Attributes["TextCol"].Value.ToString() + "' WHERE id =" + id.ToString(), cn);
                    updateattr.ExecuteNonQuery();
                }
            }
        }

        private void VectorLayer_DataLoaded(object sender, DataLoadedEventArgs e) {
            mapControl.ZoomToFitLayerItems();
        }
    }
}