Imports MySql.Data.MySqlClient
Public Class Form1
    Private conexao As New MySqlConnection
    Private aux As New ClassDB

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
    End Sub

    Private Sub CriaTabelas()
        Try
            aux.AbrirConexao(conexao)

            Try
                aux.ExecutaSQL(conexao, "CREATE TABLE If NOT EXISTS TIME(codtime INTEGER" +
                               " PRIMARY KEY AUTO_INCREMENT, NomeTime VARCHAR(30), EstadoTime VARCHAR(2))")
                aux.ExecutaSQL(conexao, " CREATE TABLE IF NOT exists Estadio(CodTime INTEGER PRIMARY KEY, NomeEstadio VARCHAR(30))")
                aux.ExecutaSQL(conexao, " CREATE TABLE IF NOT exists Partida(CodTimeC INTEGER,CodTimeV INTEGER,Dia DATE,Hora VARCHAR(5),PRIMARY KEY(CodTimeC,CodTimeV,Dia))")
            Catch ex As Exception
                MessageBox.Show("Erro no SQL")

            End Try
            aux.FecharConexao(conexao)
        Catch ex As Exception
            MessageBox.Show("Erro no acesso ao DB")

        End Try
    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CriaTabelas()

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Form3.ShowDialog()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form4.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form5.Show()
    End Sub
End Class
