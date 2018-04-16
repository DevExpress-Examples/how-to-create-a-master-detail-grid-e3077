Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.ComponentModel
Imports System.Windows.Threading
Imports DevExpress.Xpf.Grid
Imports System.Windows.Data

Namespace SLGridExample
	Partial Public Class MainPage
		Inherits UserControl

		Public Shared ReadOnly IsExpandedProperty As DependencyProperty = DependencyProperty.RegisterAttached("IsExpanded", GetType(Boolean), GetType(MainPage), New PropertyMetadata(False))

		Public Shared Sub SetIsExpanded(ByVal element As DependencyObject, ByVal value As Boolean)
			element.SetValue(IsExpandedProperty, value)
		End Sub

		Public Shared Function GetIsExpanded(ByVal element As DependencyObject) As Boolean
			Return CBool(element.GetValue(IsExpandedProperty))
		End Function

		Public Sub New()
			InitializeComponent()

			AddHandler Loaded, AddressOf MainPage_Loaded
		End Sub

		Private Sub MainPage_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)

			Dim recListMain As New TestRecordList()

			Dim rnd As New Random()
			For i As Integer = 0 To 49
				Dim recList As New DetailsList()

				Dim count As Integer = rnd.Next(40) + 10
				For j As Integer = 0 To count - 1
					recList.Add(New Details() With {.Id = j, .Name = "Detail name #" & j})
				Next j

				recListMain.Add(New TestRecord() With {.Description = "The master record #" & i, .MasterRecordID = "id " & i, .DetailedInfo = recList})
			Next i

			grid.DataSource = recListMain
		End Sub
	End Class
End Namespace
