Public Class Form5
    Public codigo As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim f As Form6 = New Form6(1)
        codigo = 1
        Form6.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dim f As Form6 = New Form6(2)
        codigo = 2
        Form6.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Dim f As Form6 = New Form6(3)
        codigo = 3
        Form6.Show()
    End Sub

    Private Sub Form5_Load(sendexr As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class