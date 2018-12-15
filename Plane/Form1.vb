Imports System.IO
Imports System.IO.IOException
Imports System.Windows.Forms.Control

Public Structure hagz
    Dim trip_no As Integer
    Dim trip_date As String
    Dim trip_time As String
    Dim arrive_time As String
    Dim city1 As String
    Dim city2 As String
    ' Define the capacity of arrays
    <VBFixedArray(55)> Dim korsi() As Integer
    <VBFixedArray(55)> Dim passenger() As String
    <VBFixedArray(55)> Dim phone() As String
    <VBFixedArray(55)> Dim address() As String
End Structure
Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim buttons(55) As Button
    Dim z, i, s, x, j As Integer

    Private Sub Button61_Click(sender As Object, e As EventArgs) Handles Button61.Click
        ' Close The File
        FileClose(1)

        ' Exit Program
        End
    End Sub

    Dim position As Integer

    Public prec As hagz
    Dim m, n, l As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FileOpen(1, "records.txt", OpenMode.Random,,, Len(prec))

        prec.korsi = New Integer(55) {}
        prec.passenger = New String(55) {}
        prec.phone = New String(55) {}
        prec.address = New String(55) {}

        Label1.Text = Now()

        For i = 1 To 56
            buttons(i - 1) = Me.Controls("button" & i)
            AddHandler buttons(i - 1).Click, AddressOf korsyy_no
        Next
    End Sub


End Class
