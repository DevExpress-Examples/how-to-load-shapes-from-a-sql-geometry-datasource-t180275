using System;
using System.IO;
using System.Windows;

namespace SqlGeometryDataAdapterExample {
    public partial class MainWindow : Window {
        const string dbPath = "..\\..\\..\\Data\\SQLG.mdf";

        string connectionString = "Data Source=(local);AttachDbFileName=" +
            Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location, dbPath)) +
            ";Database=SqlGeometryDemoDB;Integrated Security=True;MultipleActiveResultSets=True";
        public String ConnectionString { get { return connectionString; } }

        public MainWindow() {
            InitializeComponent();
            this.DataContext = ConnectionString;
        }
    }
}
