Imports MySql.Data.MySqlClient
Public Class ClassDB
    Private comando As New MySqlCommand
    Private armazena As MySqlDataReader

    Public Sub AbrirConexao(ByRef conexao As MySqlConnection)
        conexao = New MySqlConnection
        conexao.ConnectionString = "server=localhost; user id=root; password= ; database = lcvb"
        conexao.Open()
    End Sub

    Public Sub FecharConexao(ByRef conexao As MySqlConnection)
        conexao.Close()
    End Sub

    Public Sub ExecutaSQL(ByVal conexao As MySqlConnection, ByVal instrucao As String)
        comando.Connection = conexao
        comando.CommandText = instrucao
        comando.ExecuteNonQuery()
    End Sub

    Public Function ExecutaSelect(ByVal conexao As MySqlConnection, ByVal instrucao As String) As MySqlDataReader
        comando.Connection = conexao
        comando.CommandText = instrucao
        armazena = comando.ExecuteReader()
        Return armazena
    End Function

End Class
