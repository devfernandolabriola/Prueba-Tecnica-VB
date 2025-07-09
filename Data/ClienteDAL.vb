Imports System.Data.SqlClient
Imports Entidades
Public Class ClienteDAL
    Private Conexion As New Conexion

    Public Function CrearCliente(Cliente As EntidadCliente) As Boolean
        Dim resultado As Boolean = False

        Try
            Using con As SqlConnection = Conexion.AbrirConexion()
                Dim query As String = "Insert into Clientes (Cliente,Telefono,Correo) VALUES (@Cliente,@Telefono,@Correo)"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Cliente", Cliente.Cliente)
                    cmd.Parameters.AddWithValue("@Telefono", Cliente.Telefono)
                    cmd.Parameters.AddWithValue("@Correo", Cliente.Correo.ToLower())

                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                    resultado = (filasAfectadas > 0)
                End Using

            End Using
        Catch ex As Exception
            Throw ex
        Finally
            Conexion.CerrarConexion()
        End Try

        Return resultado

    End Function

    Public Function ObtenerClientes() As List(Of EntidadCliente)
        Dim lista As New List(Of EntidadCliente)

        Try

            Using con As SqlConnection = Conexion.AbrirConexion()
                Dim query As String = "SELECT Id, Cliente, Telefono, Correo FROM Clientes"

                Using cmd As New SqlCommand(query, con)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim cliente As New EntidadCliente With {
                                .ID = Convert.ToInt32(reader("Id")),
                                .Cliente = reader("Cliente").ToString(),
                                .Telefono = reader("Telefono").ToString(),
                                .Correo = reader("Correo").ToString()
                            }
                            lista.Add(cliente)
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Throw New Exception("Error al obtener los clientes: " & ex.Message)
        End Try

        Return lista

    End Function

    Public Function CorreoTelefonoExistente(correo As String, telefono As String) As Boolean
        Dim existe As Boolean = False

        Try
            Using con As SqlConnection = Conexion.AbrirConexion()
                Dim query As String = "Select Count(*) FROM Clientes WHERE Correo = @Correo OR Telefono = @Telefono"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Correo", correo)
                    cmd.Parameters.AddWithValue("@Telefono", telefono)
                    Dim contador As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    existe = (contador > 0)
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al validar correo o teléfono duplicado: " & ex.Message)
        End Try

        Return existe

    End Function

    Public Function CorreoExistente(correo As String) As Boolean
        Dim existe As Boolean = False

        Try
            Using con As SqlConnection = Conexion.AbrirConexion()
                Dim query As String = "Select Count(*) FROM Clientes WHERE Correo = @Correo"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Correo", correo)
                    Dim contador As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    existe = (contador > 0)
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al validar correo duplicado: " & ex.Message)
        End Try

        Return existe

    End Function

    Public Function TelefonoExistente(telefono As String) As Boolean
        Dim existe As Boolean = False

        Try
            Using con As SqlConnection = Conexion.AbrirConexion()
                Dim query As String = "Select Count(*) FROM Clientes WHERE Telefono = @Telefono"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Telefono", telefono)
                    Dim contador As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    existe = (contador > 0)
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al validar teléfono duplicado: " & ex.Message)
        End Try

        Return existe

    End Function

    Public Function ModificarCliente(cliente As EntidadCliente) As Boolean
        Dim resultado As Boolean = False

        Try
            Using con As SqlConnection = Conexion.AbrirConexion()
                Dim query As String = "UPDATE Clientes SET Cliente = @Cliente, Telefono = @Telefono, Correo = @Correo WHERE Id = @Id"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Cliente", cliente.Cliente)
                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono)
                    cmd.Parameters.AddWithValue("@Correo", cliente.Correo.ToLower())
                    cmd.Parameters.AddWithValue("@Id", cliente.ID)

                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                    resultado = (filasAfectadas > 0)
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al modificar el cliente" & ex.Message)

        Finally
            Conexion.CerrarConexion()
        End Try

        Return resultado
    End Function

    Public Function EliminarCliente(Id As Integer) As Boolean
        Dim eliminado As Boolean = False
        Try
            Using con As SqlConnection = Conexion.AbrirConexion()
                Dim query As String = "Delete FROm Clientes WHERE Id = @Id"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Id", Id)
                    eliminado = cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As SqlException
            If ex.Number = 547 Then
                Throw New Exception("No se puede eliminar el cliente porque tiene registros relacionados (ventas u otros).")
            Else
                Throw New Exception("Error SQL al eliminar el cliente: " & ex.Message)
            End If

        Catch ex As Exception
            Throw New Exception("Error al eliminar el cliente" & ex.Message)
        End Try
        Return eliminado
    End Function

    Public Function BuscarNombreClientePorID(IDCliente As Integer) As String

        Try

            Using con As SqlConnection = Conexion.AbrirConexion()
                Dim query As String = "SELECT Cliente FROM Clientes WHERE ID = @IDCliente"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@IDCliente", IDCliente)

                    Dim resultado As Object = cmd.ExecuteScalar()
                    If resultado IsNot Nothing AndAlso Not IsDBNull(resultado) Then
                        Return resultado.ToString()
                    Else
                        Return "Desconocido"
                    End If
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Function

End Class
