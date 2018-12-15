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

    Private Sub Button61_Click(sender As Object, e As EventArgs) Handles Button61.Click
        ' Close The File
        FileClose(1)

        ' Exit Program
        End
    End Sub

    ' NEW TRIP Button
    Private Sub Button57_Click(sender As Object, e As EventArgs) Handles Button57.Click
        ' define current position
        position = Loc(1)

        ' تستخدم هذه الدالة لتغيير للموضع الذي تريد القراءة أو الكتابة عليه
        Seek(1, Val(TextBox1.Text))

        prec.trip_no = Val(TextBox1.Text)
        prec.trip_date = TextBox2.Text
        prec.trip_time = TextBox4.Text
        prec.arrive_time = TextBox5.Text
        prec.city1 = TextBox3.Text
        prec.city2 = TextBox6.Text

        For i = 0 To 55
            prec.korsi(i) = 0
            prec.passenger(i) = "0"
            prec.phone(i) = "0"
            prec.address(i) = "0"
        Next
        s = Val(TextBox1.Text)
        FilePut(1, prec, s)
        clear()
    End Sub

    ' Book a chair
    Private Sub Button58_Click(sender As Object, e As EventArgs) Handles Button58.Click
        view()
        x = MsgBox("هل تريد حجز هذا الكرسي؟", MsgBoxStyle.OkCancel)
        If x = 1 Then
            buttons(j).BackColor = Color.Orange
            z = 1
            FileGet(1, prec, Val(TextBox1.Text))
            prec.korsi(j) = z
            prec.passenger(j) = TextBox7.Text
            prec.phone(j) = TextBox8.Text
            prec.address(j) = TextBox9.Text

            s = Val(TextBox1.Text)

            FilePut(1, prec, s)
        ElseIf x = 2 Then
            buttons(j).BackColor = Color.Lime

        End If
        clear2()
    End Sub

    ' Delete a booking
    Private Sub Button60_Click(sender As Object, e As EventArgs) Handles Button60.Click
        view()

    End Sub

    Sub view()
        FileGet(1, prec, Val(TextBox1.Text))

        If prec.trip_no <> Val(TextBox1.Text) Then
            MsgBox("No trip Exists under this number")
            FileClose(1)
            Exit Sub
        End If

        TextBox2.Text = prec.trip_date
        TextBox3.Text = prec.city1
        TextBox4.Text = prec.trip_time
        TextBox5.Text = prec.arrive_time
        TextBox6.Text = prec.city2

        For i = 0 To 55
            If prec.korsi(i) = 1 Then
                buttons(i).BackColor = Color.Orange
            ElseIf prec.korsi(i) = 2 Then
                buttons(i).BackColor = Color.Red
            Else
                buttons(i).BackColor = Color.Lime
            End If
        Next
    End Sub

    ' Confirm Booking
    Private Sub Button59_Click(sender As Object, e As EventArgs) Handles Button59.Click
        view()
        If z = 0 Then
            MsgBox("لم يسبق الحجز")
        ElseIf z = 1 Then
            x = MsgBox("هل تريد تأكيد حجز هذا الكرسي؟", MsgBoxStyle.OkCancel)
            If x = 1 Then
                buttons(j).BackColor = Color.Red
                z = 2
                FileGet(1, prec, Val(TextBox1.Text))

                prec.korsi(j) = z
                s = Val(TextBox1.Text)
                FilePut(1, prec, s)

            ElseIf x = 2 Then
                buttons(j).BackColor = Color.Orange
                Exit Sub

            End If
        End If
        clear2()

    End Sub

    Public Sub korsyy_no(ByVal sender As System.Object, ByVal e As System.EventArgs)

        FileGet(1, prec, Val(TextBox1.Text))
        For i = 0 To buttons.Length - 1
            If buttons(i) Is sender Then
                j = i
                Exit For
            End If
        Next

        z = prec.korsi(j)
        If z = 0 Then
        Else
            TextBox7.Text = prec.passenger(j)
            TextBox8.Text = prec.phone(j)
            TextBox9.Text = prec.address(j)
        End If

        If j < 8 Then
            Label13.Text = "First Class"
        Else
            Label13.Text = "Second Class"
        End If
    End Sub

    Public Sub clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
    End Sub

    Public Sub clear2()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
    End Sub
End Class
