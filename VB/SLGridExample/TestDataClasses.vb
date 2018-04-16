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
Imports System.ComponentModel
Imports System.Collections.Generic

Namespace SLGridExample

	Public Class TestRecordList
		Inherits List(Of TestRecord)
	End Class

	Public Class TestRecord
		Implements INotifyPropertyChanged

		Private privateDescription As String
		Public Property Description() As String
			Get
				Return privateDescription
			End Get
			Set(ByVal value As String)
				privateDescription = value
			End Set
		End Property

		Private privateMasterRecordID As String
		Public Property MasterRecordID() As String
			Get
				Return privateMasterRecordID
			End Get
			Set(ByVal value As String)
				privateMasterRecordID = value
			End Set
		End Property

		Private details As DetailsList
		Public Property DetailedInfo() As DetailsList
			Get
				Return details
			End Get
			Set(ByVal value As DetailsList)
				If details Is value Then
					Return
				End If
				details = value
				RaisePropertyChaged("DetailedInfo")
			End Set
		End Property

		#Region "INotifyPropertyChanged Members"

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
		Private Sub RaisePropertyChaged(ByVal propertyName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End Sub
		#End Region
	End Class

	Public Class DetailsList
		Inherits List(Of Details)
		Public Overrides Function ToString() As String
			Return "Detail (Count = " & Count.ToString() & ")"
		End Function
	End Class

	Public Class Details
		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property
		Private privateId As Integer
		Public Property Id() As Integer
			Get
				Return privateId
			End Get
			Set(ByVal value As Integer)
				privateId = value
			End Set
		End Property
	End Class
End Namespace
