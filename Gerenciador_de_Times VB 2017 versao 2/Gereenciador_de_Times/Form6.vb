Imports MySql.Data.MySqlClient
Public Class Form6
    Private conexao As New MySqlConnection
    Private aux As New ClassDB
    Private codigo As Integer
    Private adaptador As MySqlDataAdapter
    Private ds As New DataSet

    Public Sub Consultas()
        codigo = Form5.codigo
        ds = New DataSet()
        Try
            aux.AbrirConexao(conexao)
            Try
                If (codigo = 1) Then
                    adaptador = New MySqlDataAdapter("SELECT * from time ORDER by NomeTime", conexao)
                ElseIf (codigo = 2) Then
                    adaptador = New MySqlDataAdapter("SELECT T.NomeTime,E.NomeEstadio FROM time T,Estadio E WHERE T.CodTime=E.CodTime", conexao)
                ElseIf (codigo = 3) Then
                    adaptador = New MySqlDataAdapter("SELECT T.NomeTime,T1.NomeTime,P.Dia,P.Hora FROM time T, time T1, partida P WHERE T.codtime=P.CodTimeC AND T1.codtime = P.CodTimeV", conexao)
                End If
                adaptador.Fill(ds, "time")
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = "time"

            Catch ex As Exception
                MessageBox.Show("Erro no SQL")

            End Try
            aux.FecharConexao(conexao)

        Catch ex As Exception
            MessageBox.Show("Erro no acesso ao DB")

        End Try
    End Sub


    'Public Sub New(ByVal indice As Integer)

    '    codigo = indice
    '    MessageBox.Show(codigo.ToString())

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Consultas()
    End Sub
End Class
''