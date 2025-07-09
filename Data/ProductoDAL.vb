Imports System.Data.SqlClient
Imports Entidades
Public Class ProductoDAL
    Private Conexion As New Conexion

    Public Function ListarProductos() As List(Of EntidadProducto)
        Dim lista As New List(Of EntidadProducto)
        Try
            Using con As SqlConnection = Conexion.AbrirConexion()
                Dim query As String = "Select Id, Nombre, Precio, Categoria FROM Productos"
                Using cmd As New SqlCommand(query, con)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim producto As New EntidadProducto With {
                                .ID = Convert.ToInt32(reader("Id")),
                                .Nombre = reader("Nombre").ToString(),
                                .Precio = Convert.ToDecimal(reader("Precio")),
                                .Categoria = reader("categoria").ToString()
                            }
                            lista.Add(producto)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener los productos. " & ex.Message)
        End Try
        Return lista
    End Function

    Public Function CrearProducto(producto As EntidadProducto) As Boolean
        Dim resultado As Boolean = False

        Try
            Using con As SqlConnection = Conexion.AbrirConexion()
                Dim query As String = "INSERT INTO Productos (Nombre, Precio, Categoria) VALUES (@Nombre, @Precio, @Categoria)"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre.ToLower())
                    cmd.Parameters.AddWithValue("@Precio", producto.Precio)
                    cmd.Parameters.AddWithValue("@Categoria", producto.Categoria.ToLower())

                    resultado = cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al crear el producto: " & ex.Message)
        End Try

        Return resultado
    End Function

    Public Function ModificarProducto(producto As EntidadProducto) As Boolean
        Dim resultado As Boolean = False

        Try
            Using con As SqlConnection = Conexion.AbrirConexion()
                Dim query As String = "UPDATE Productos SET Nombre = @Nombre, Precio = @Precio, Categoria = @Categoria WHERE Id = @Id"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre.ToLower())
                    cmd.Parameters.AddWithValue("@Precio", producto.Precio)
                    cmd.Parameters.AddWithValue("@Categoria", producto.Categoria.ToLower())
                    cmd.Parameters.AddWithValue("@Id", producto.ID)

                    resultado = cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al modificar el producto: " & ex.Message)
        End Try

        Return resultado
    End Function

    Public Function EliminarProducto(id As Integer) As Boolean
        Dim resultado As Boolean = False

        Try
            Using con As SqlConnection = Conexion.AbrirConexion()
                Dim query As String = "DELETE FROM Productos WHERE Id = @Id"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Id", id)
                    resultado = cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al eliminar el producto: " & ex.Message)
        End Try

        Return resultado
    End Function

    Public Function ProductoExistente(nombre As String) As Boolean
        Dim existe As Boolean = False

        Try
            Using con As SqlConnection = Conexion.AbrirConexion()
                Dim query As String = "Select Count(*) from Productos where Nombre = @Nombre"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Nombre", nombre)
                    Dim contador As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    existe = (contador > 0)
                End Using

            End Using
        Catch ex As Exception
            Throw New Exception("Error al validar el producto duplicado: " & ex.Message)
        End Try
        Return existe
    End Function

    Public Function ObtenerNombreProductoPorID(idProducto As Integer) As String
        Dim nombreProducto As String = ""

        Dim query As String = "SELECT Nombre FROM Productos WHERE ID = @ID"

        Using con As SqlConnection = Conexion.AbrirConexion(),
              cmd As New SqlCommand(query, con)

            cmd.Parameters.AddWithValue("@ID", idProducto)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                nombreProducto = reader("Nombre").ToString()
            End If

        End Using

        Return nombreProducto
    End Function
End Class
