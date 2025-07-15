Imports Data
Imports Entidades
Public Class VentaNegocio
    Private VentaDAL As New VentaDAL

    Public Function RegistrarVenta(venta As EntidadVenta) As Boolean
        If venta.IDCliente <= 0 Then
            Throw New Exception("Debe seleccionar un cliente.")
        End If
        If venta.Detalle Is Nothing OrElse venta.Detalle.Count = 0 Then
            Throw New Exception("Debe agregar al menos un producto")
        End If
        For Each item In venta.Detalle
            If item.Cantidad <= 0 Then Throw New Exception("Cantidad invalida de productos")
            If item.PrecioUnitario <= 0 Then Throw New Exception("Precio invalido de producto")
        Next
        Return VentaDAL.CrearVenta(venta)
    End Function

    Public Function ListarVentas()
        Return VentaDAL.ListarVentas()
    End Function

    Public Sub EliminarVenta(idVenta As Integer)
        VentaDAL.EliminarVenta(idVenta)
    End Sub

    Public Function ModificarVenta(venta As EntidadVenta) As Boolean
        Try
            If venta.ID <= 0 Then
                Throw New Exception("Id de venta invalido")
            ElseIf venta.Detalle Is Nothing OrElse venta.Detalle.Count = 0 Then
                Throw New Exception("La venta debe tener al menos un producto")
            Else
                If venta.Total <= 0 Then Throw New Exception("El precio total debe ser mayor a cero.")
            End If

            Return VentaDAL.ModificarVenta(venta)
        Catch ex As Exception
            Throw New Exception("Error al modificar la venta: " & ex.Message)
        End Try
    End Function

    Public Function ObtenerItemsPorVentaID(IDVenta As Integer) As List(Of EntidadVentaItem)
        Return VentaDAL.ObtenerItemsPorVentaID(IDVenta)
    End Function

    Public Function ObtenercantidaditemsporVentaID(IDVenta As Integer) As List(Of EntidadVentaItem)
        Return VentaDAL.ObtenercantidaditemsporVentaID(IDVenta)
    End Function
End Class
