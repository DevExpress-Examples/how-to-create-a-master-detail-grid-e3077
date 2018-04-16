Imports Microsoft.VisualBasic
Imports System
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Grid
Imports System.Windows.Data

Namespace SLGridExample
	Public Class GridDetailContainer
		Inherits ContentPresenter

		Public Shared ReadOnly IsVisibleProperty As DependencyProperty = DependencyProperty.Register("IsVisible", GetType(Boolean), GetType(GridDetailContainer), New PropertyMetadata(False, New PropertyChangedCallback(AddressOf GridPropertyChangedCallback)))

		Public Overloads Property IsVisible() As Boolean
			Get
				Return CBool(GetValue(IsVisibleProperty))
			End Get
			Set(ByVal value As Boolean)
				SetValue(IsVisibleProperty, value)
			End Set
		End Property

		Public Shared ReadOnly GridProperty As DependencyProperty = DependencyProperty.Register("Grid", GetType(GridControl), GetType(GridDetailContainer), New PropertyMetadata(Nothing, New PropertyChangedCallback(AddressOf GridPropertyChangedCallback)))

		Public Property Grid() As GridControl
			Get
				Return CType(GetValue(GridProperty), GridControl)
			End Get
			Set(ByVal value As GridControl)
				SetValue(GridProperty, value)
			End Set
		End Property

		Private Shared Sub GridPropertyChangedCallback(ByVal s As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			CType(s, GridDetailContainer).OnChanged()
		End Sub

		Private gridItemsSourceBinding_Renamed As Binding
		Public Property GridItemsSourceBinding() As Binding
			Get
				Return gridItemsSourceBinding_Renamed
			End Get
			Set(ByVal value As Binding)
				gridItemsSourceBinding_Renamed = value
				OnChanged()
			End Set
		End Property

		Private Sub OnChanged()
			Content = Grid
			If IsVisible Then
				Visibility = Visibility.Visible
				If Grid IsNot Nothing AndAlso GridItemsSourceBinding IsNot Nothing Then
					Grid.SetBinding(GridControl.DataSourceProperty, GridItemsSourceBinding)
				End If
			Else
				Visibility = Visibility.Collapsed
				If Grid IsNot Nothing Then
					Grid.ClearValue(GridControl.DataSourceProperty)
				End If
			End If
		End Sub

	End Class
End Namespace
