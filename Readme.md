<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128571635/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T180275)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
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


