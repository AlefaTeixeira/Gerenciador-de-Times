Imports MySql.Data.MySqlClient
Public Class Form4
    Private conexao As New MySqlConnection
    Private aux As New ClassDB
    Private armazena As MySqlDataReader
    Private Codigo As String



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        inserirPartida()

    End Sub


    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuscaTimesComEstadio()
        BuscaTimeVisitante()

    End Sub
    Private Sub BuscaTimesComEstadio()
        Try
            aux.AbrirConexao(conexao)

            Try
                armazena = aux.ExecutaSelect(conexao, "SELECT NomeTime FROM Time WHERE CodTime IN (Select CodTime From Estadio)")

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
            MessageBox.Show("Erro no acesso ao DB1")

        End Try
    End Sub
    Private Sub BuscaEStadio()
        Try
            aux.AbrirConexao(conexao)
            Try
                armazena = aux.ExecutaSelect(conexao, "SELECT estadio.NomeEstadio FROM time, estadio WHERE time.CodTime = estadio.CodTime AND NomeTime = '" + ComboBox1.Text + "'")
                armazena.Read()
                TextBox1.Text = armazena("NomeEstadio").ToString()
            Catch ex As Exception
                MessageBox.Show("Erro no SQL")

            End Try
            aux.FecharConexao(conexao)
        Catch ex As Exception
            MessageBox.Show("Erro no acesso ao DB")

        End Try
    End Sub
    Private Sub BuscaTimeVisitante()
        Try
            aux.AbrirConexao(conexao)

            Try
                armazena = aux.ExecutaSelect(conexao, "SELECT NomeTime FROM Time WHERE nometime <>'" + ComboBox1.Text + "'")

                If (armazena.HasRows) Then
                    ComboBox2.Items.Clear()
                    While (armazena.Read)
                        ComboBox2.Items.Add(armazena("NomeTime").ToString())
                    End While
                    ComboBox2.SelectedIndex = 0
                Else
                    MessageBox.Show("Cadastrar times")
                    Me.Close()
                End If


            Catch ex As Exception
                MessageBox.Show("Erro no SQL")

            End Try
            aux.FecharConexao(conexao)
        Catch ex As Exception
            MessageBox.Show("Erro no acesso ao DB1")

        End Try
    End Sub

    Public Function DescobreCodigo(ByVal time As String) As Integer
        Dim codigo As Integer
        Try
            aux.AbrirConexao(conexao)
            Try
                armazena = aux.ExecutaSelect(conexao, "SELECT codTime FROM time WHERE nomeTime = '" + time + "'")

                armazena.Read()
                codigo = armazena("codTime")

            Catch ex As Exception
                MessageBox.Show("Erro no SQL metodo busca time sem")
            End Try
            aux.FecharConexao(conexao)
        Catch ex As Exception
            MessageBox.Show("Erro no acesso ao banco de dados")
        End Try

        Return codigo

    End Function

    Private Sub inserirPartida()
        Dim codigoTimeCasa As Integer
        Dim codigoTimeVisitante As Integer
        Dim data As String

        codigoTimeCasa = DescobreCodigo(ComboBox1.Text)
        codigoTimeVisitante = DescobreCodigo(ComboBox2.Text)
        data = DateTimePicker1.Value.ToString("yyyy-MM-dd")

        Try
            aux.AbrirConexao(conexao)
            Try
                aux.ExecutaSQL(conexao, "INSERT INTO PARTIDA(CodTimeC,CodTimeV,Dia,Hora)values(" + codigoTimeCasa.ToString() + "," + codigoTimeVisitante.ToString() + ",'" + data + "','" + MaskedTextBox1.Text + "')")
            Catch ex As Exception
                MessageBox.Show("Erro no SQL")
            End Try
            aux.FecharConexao(conexao)
        Catch ex As Exception
            MessageBox.Show("Erro no acesso ao banco de dados")
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        BuscaEStadio()
    End Sub
End Class