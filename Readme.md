<!-- default file list -->
*Files to look at*:

* [MainPage.xaml](./CS/MainPage.xaml) (VB: [MainPage.xaml](./VB/MainPage.xaml))
* [MainPage.xaml.cs](./CS/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/MainPage.xaml.vb))
* [ViewModel.cs](./CS/ViewModel.cs) (VB: [ViewModel.vb](./VB/ViewModel.vb))
<!-- default file list end -->
# How to create a master-detail grid


<p><em><strong>Update:</strong></em><br /><em>Starting with version 12.1, you can create a master-detail grid without any custom templates using the <a href="https://documentation.devexpress.com/#Silverlight/clsDevExpressXpfGridDataControlDetailDescriptortopic">DataControlDetailDescriptor</a> class. See the example project below for more information.</em></p>
<br />
<p>With later versions of our controls you can use the previous workaround:<br /> The following example demonstrates how to create a master-detail grid.</p>
<p>To accomplish this, it is necessary to create a custom <a href="http://documentation.devexpress.com/#Silverlight/DevExpressXpfGridTableView_DataRowTemplatetopic"><u>template</u></a> for master-grid rows and place a nested grid control for details displayed within this template. The detail grid <a href="http://documentation.devexpress.com/#Silverlight/DevExpressXpfGridGridControl_DataSourcetopic"><u>DataSource</u></a> property should be bound to the appropriate column in the master grid. So, there will be a dedicated nested grid in every row of the master grid.</p>
<p>Since the count of detail grids is equal to the master grid row count, it is necessary to handle visibility and data binding of the detail grid to avoid a reduction in performance. Every detail grid must be hidden until it's master row is collapsed to show the detail information. That is why the detail grid in this example is wrapped with the <strong>GridDetailContainer</strong> class.</p>
<p>This class is designed to manage the Visibility and the DataSource properties of the nested grid. It has the <strong>IsVisible</strong> dependency property bound to the master row's <strong>IsExpanded</strong> attached property. When the master row expands the GridDetailContainer it sets the grid Visibility property to Visible and assigns it's DataSource. This adjustment is performed in the IsVisibleChanged callback.</p>
<p>So, the rendering and data source binding is required for visible detail grids only to help keep performance at a high level.</p>
<p>Note that this approach is a temporary solution, which is intended to be used until master-detail mode is truly supported in the DXGrid suite. If you want to be notified when this feature is implemented, track the corresponding suggestion: <a href="https://www.devexpress.com/Support/Center/p/S30644">Data Binding - Master-Detail support</a>.</p>
<p>Also please note, that by default, there is no Expander control in Silverlight SDK. In this example, the Expander from Silverlight Toolkit package is used. You can easily download this tool kit from the Silverlight Toolkit <a href="http://silverlight.codeplex.com/"><u>site</u></a>.</p>

<br/>


