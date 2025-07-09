Imports System.Data.SqlClient
Imports System.Xml.Schema
Imports Entidades

Public Class VentaDAL
    Private Conexion As New Conexion
    Public Function CrearVenta(venta As EntidadVenta) As Boolean
        Using con As SqlConnection = Conexion.AbrirConexion()
            Using tran As SqlTransaction = con.BeginTransaction()
                Try
                    'Insertar Venta
                    Dim ventaQuery As String = "INSERT INTO Ventas (Fecha, IDCliente,Total) OUTPUT INSERTED.ID VALUES (@Fecha,@IDCliente,@Total)"
                    Dim ventacmd As New SqlCommand(ventaQuery, con, tran)
                    ventacmd.Parameters.AddWithValue("@Fecha", venta.Fecha)
                    ventacmd.Parameters.AddWithValue("@IDCliente", venta.IDCliente)
                    ventacmd.Parameters.AddWithValue("@Total", venta.Total)
                    Dim IDVenta As Integer = Convert.ToInt32(ventacmd.ExecuteScalar())

                    'Insertar Items a Venta
                    For Each item In venta.Detalle
                        Dim itemQuery As String = "Insert into VentasItems (IDVenta,IDProducto,Cantidad,PrecioUnitario,PrecioTotal) VALUES (@IDVenta,@IDProducto,@Cantidad,@PrecioUnitario,@PrecioTotal)"
                        Dim itemCmd As New SqlCommand(itemQuery, con, tran)
                        itemCmd.Parameters.AddWithValue("@IDVenta", IDVenta)
                        itemCmd.Parameters.AddWithValue("@IDProducto", item.IDProducto)
                        itemCmd.Parameters.AddWithValue("@Cantidad", item.Cantidad)
                        itemCmd.Parameters.AddWithValue("@PrecioUnitario", item.PrecioUnitario)
                        itemCmd.Parameters.AddWithValue("@PrecioTotal", item.PrecioTotal)
                        itemCmd.ExecuteNonQuery()
                    Next

                    tran.Commit()
                    Return True
                Catch ex As Exception
                    tran.Rollback()
                    Throw New Exception("Error al registrar la venta " & ex.Message)
                End Try
            End Using
        End Using
    End Function

    Public Function ListarVentas()

        Dim lista As New List(Of EntidadVenta)
        Try
            Using con As SqlConnection = Conexion.AbrirConexion()
                Dim query As String = "Select ID, IDCliente, Fecha, Total FROM ventas"
                Using cmd As New SqlCommand(query, con)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim venta As New EntidadVenta With {
                                .ID = Convert.ToInt32(reader("ID")),
                                .IDCliente = Convert.ToInt32(reader("IDCliente")),
                                .Fecha = Convert.ToDateTime(reader("Fecha")),
                                .Total = Convert.ToDecimal(reader("Total")),
                                .Detalle = New List(Of EntidadVentaItem)()
                            }
                            lista.Add(venta)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener las ventas. " & ex.Message)
        End Try
        Return lista
    End Function

    Public Function ObtenerItemsPorVentaID(IDVenta As Integer) As List(Of EntidadVentaItem)
        Dim lista As New List(Of EntidadVentaItem)

        Try
            Using con As SqlConnection = Conexion.AbrirConexion()
                Dim query As String = "SELECT ID, IDVenta, IDProducto, Cantidad, PrecioUnitario, PrecioTotal FROM VentasItems WHERE IDVenta = @IDVenta"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@IDVenta", IDVenta)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim item As New EntidadVentaItem With {
                                .ID = Convert.ToInt32(reader("ID")),
                                .IDVenta = Convert.ToInt32(reader("IDVenta")),
                                .IDProducto = Convert.ToInt32(reader("IDProducto")),
                                .Cantidad = Convert.ToInt32(reader("Cantidad")),
                                .PrecioUnitario = Convert.ToDecimal(reader("PrecioUnitario")),
                                .PrecioTotal = Convert.ToDecimal(reader("PrecioTotal"))
                            }
                            lista.Add(item)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener ítems de venta: " & ex.Message)
        End Try

        Return lista
    End Function
    Public Sub EliminarVenta(idVenta As Integer)
        Using con As SqlConnection = Conexion.AbrirConexion()
            Dim trans As SqlTransaction = con.BeginTransaction()

            Try
                Dim queryDetalle As String = "DELETE FROM VentasItems WHERE IDVenta = @IDVenta"
                Using cmdDetalle As New SqlCommand(queryDetalle, con, trans)
                    cmdDetalle.Parameters.AddWithValue("@IDVenta", idVenta)
                    cmdDetalle.ExecuteNonQuery()
                End Using

                Dim queryVenta As String = "DELETE FROM Ventas WHERE ID = @IDVenta"
                Using cmdVenta As New SqlCommand(queryVenta, con, trans)
                    cmdVenta.Parameters.AddWithValue("@IDVenta", idVenta)
                    cmdVenta.ExecuteNonQuery()
                End Using

                trans.Commit()
            Catch ex As Exception
                trans.Rollback()
                Throw New Exception("Error al eliminar la venta: " & ex.Message)
            End Try
        End Using
    End Sub

    Public Function ModificarVenta(venta As EntidadVenta) As Boolean
        Try
            Using con As SqlConnection = Conexion.AbrirConexion()
                Using tran As SqlTransaction = con.BeginTransaction()
                    Try
                        Dim queryVenta As String = "Update Ventas SET IDCliente = @IDCliente, Fecha = @Fecha, Total = @Total WHERE ID = @ID"
                        Using cmdVenta As New SqlCommand(queryVenta, con, tran)
                            cmdVenta.Parameters.AddWithValue("@ID", venta.ID)
                            cmdVenta.Parameters.AddWithValue("@IDCliente", venta.IDCliente)
                            cmdVenta.Parameters.AddWithValue("@Fecha", venta.Fecha)
                            cmdVenta.Parameters.AddWithValue("@Total", venta.Total)
                            cmdVenta.ExecuteNonQuery()
                        End Using

                        Dim queryDeleteItems As String = "Delete FROM ventasItems WHERE IDVenta = @IDVenta"
                        Using cmdDelete As New SqlCommand(queryDeleteItems, con, tran)
                            cmdDelete.Parameters.AddWithValue("@IDVenta", venta.ID)
                            cmdDelete.ExecuteNonQuery()
                        End Using

                        For Each item In venta.Detalle
                            Dim queryInsertItems As String = "Insert INTO ventasItems (IDVenta, IDProducto, Cantidad, PrecioUnitario, PrecioTotal) VALUES (@IDVenta, @IDProducto, @Cantidad, @PrecioUnitario, @PrecioTotal)"
                            Using cmdItem As New SqlCommand(queryInsertItems, con, tran)
                                cmdItem.Parameters.AddWithValue("@IDVenta", venta.ID)
                                cmdItem.Parameters.AddWithValue("@IDProducto", item.IDProducto)
                                cmdItem.Parameters.AddWithValue("@Cantidad", item.Cantidad)
                                cmdItem.Parameters.AddWithValue("@PrecioUnitario", item.PrecioUnitario)
                                cmdItem.Parameters.AddWithValue("@PrecioTotal", item.PrecioTotal)
                                cmdItem.ExecuteNonQuery()
                            End Using
                        Next

                        tran.Commit()
                    Catch ex As Exception
                        tran.Rollback()
                        Throw New Exception("Error al modificar la venta: " & ex.Message)
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error general en modificación de venta: " & ex.Message)
        End Try
    End Function



End Class
