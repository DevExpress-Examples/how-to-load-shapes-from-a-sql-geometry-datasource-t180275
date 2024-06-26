<!-- default file list -->
*Files to look at*:

* **[MainWindow.xaml](./CS/SqlGeometryDataAdapterExample/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/SqlGeometryDataAdapterExample/MainWindow.xaml))**
* [MainWindow.xaml.cs](./CS/SqlGeometryDataAdapterExample/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/SqlGeometryDataAdapterExample/MainWindow.xaml.vb))
<!-- default file list end -->
# How to: Load shapes from a SQL Geometry datasource


This example demonstrates how to load shapes from a SQL Geometry data source.


<h3>Description</h3>

<p>&nbsp;To load data from a SQL Geometry data source, do the following.<br />1. Create a <a href="https://documentation.devexpress.com/#WPF/clsDevExpressXpfMapSqlGeometryDataAdaptertopic">SqlGeometryDataAdapter</a>&nbsp;object and assign it to the <a href="https://documentation.devexpress.com/#WPF/DevExpressXpfMapVectorLayer_Datatopic">VectorLayer.Data</a>&nbsp;property.<br />2. Specify the <a href="https://documentation.devexpress.com/#WPF/DevExpressXpfMapSqlGeometryDataAdapter_ConnectionStringtopic">ConnectionString</a>, <a href="https://documentation.devexpress.com/#WPF/DevExpressXpfMapSqlGeometryDataAdapter_SpatialDataMembertopic">SpatialDataMember</a>&nbsp;and <a href="https://documentation.devexpress.com/#WPF/DevExpressXpfMapSqlGeometryDataAdapter_SqlTexttopic">SqlText</a>&nbsp;properties.<br /><br /></p>
<p>Note that all data table fields loaded from the database will be provided as attributes for each <a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapSqlGeometryItemtopic">SqlGeometryItem</a>&nbsp;object generated using <a href="https://documentation.devexpress.com/#WPF/clsDevExpressXpfMapSqlGeometryDataAdaptertopic">SqlGeometryDataAdapter</a>.</p>

<br/>


