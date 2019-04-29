Imports MySql.Data.MySqlClient

Public Class Form2
    Private conexao As New MySqlConnection
    Private aux As New ClassDB

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0


    End Sub

    Private Sub InserirTime()
        Try
            aux.AbrirConexao(conexao)

            Try
                aux.ExecutaSQL(conexao, "INSERT INTO Time(NomeTime,estadoTime) VALUES('" + TextBox1.Text + "','" + ComboBox1.Text + "')")

            Catch ex As Exception
                MessageBox.Show("Erro no SQL")

            End Try
            aux.FecharConexao(conexao)

        Catch ex As Exception
            MessageBox.Show("Erro no acesso ao DB")

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        InserirTime()
        MessageBox.Show("Time cadastrado com sucesso")
        TextBox1.Clear()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class