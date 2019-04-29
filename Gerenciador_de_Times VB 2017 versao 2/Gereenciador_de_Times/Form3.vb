Imports MySql.Data.MySqlClient


Public Class Form3
    Private conexao As New MySqlConnection
    Private aux As New ClassDB
    Private armazena As MySqlDataReader
    Private Codigo As Integer


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuscaTimesSemEstadio()
    End Sub
    Private Sub BuscaTimesSemEstadio()
        Try
            aux.AbrirConexao(conexao)

            Try
                armazena = aux.ExecutaSelect(conexao, "SELECT NomeTime FROM Time WHERE CodTime NOT IN(SELECT CodTime FROM Estadio)")
                If (armazena.HasRows) Then
                    ComboBox1.Items.Clear()
                    While (armazena.Read)
                        ComboBox1.Items.Add(armazena("NomeTime").ToString())
                    End While
                    ComboBox1.SelectedIndex = 0
                Else
                    MessageBox.Show("Cadastrar times")
                    Me.Close()
                End If


            Catch ex As Exception
                MessageBox.Show("Erro no SQL")

            End Try
            aux.FecharConexao(conexao)
        Catch ex As Exception
            MessageBox.Show("Erro no acesso ao DB")

        End Try
    End Sub

    Private Sub BuscaCodigoTime()
        Try
            aux.AbrirConexao(conexao)

            Try
                armazena = aux.ExecutaSelect(conexao, "SELECT codtime FROM time WHERE NomeTime ='" + combobox1.text + "'")
                armazena.Read()
                Codigo = armazena("codtime")
            Catch ex As Exception
                MessageBox.Show("Erro no SQL")

            End Try
            aux.FecharConexao(conexao)
        Catch ex As Exception
            MessageBox.Show("Erro no acesso ao DB")

        End Try
    End Sub


    Private Sub InserirEstadio()
        Try
            aux.AbrirConexao(conexao)

            Try
                aux.ExecutaSQL(conexao, "INSERT INTO Estadio(codtime,NomeEstadio) VALUES (" + Codigo.ToString() + ",'" + TextBox1.Text + "')")
            Catch ex As Exception
                MessageBox.Show("Erro no SQL")

            End Try
            aux.FecharConexao(conexao)
        Catch ex As Exception
            MessageBox.Show("Erro no acesso ao DB")

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        BuscaCodigoTime()
        InserirEstadio()
        MessageBox.Show("Estádio inserido com sucesso")
        BuscaTimesSemEstadio()
        TextBox1.Clear()

    End Sub
End Class