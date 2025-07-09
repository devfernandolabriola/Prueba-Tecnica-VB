Public Class EntidadVenta
    Public Property ID As Integer
    Public Property IDCliente As Integer
    Public Property Fecha As DateTime
    Public Property Total As Decimal
    Public Property Detalle As List(Of EntidadVentaItem)
    Public Property NombreCliente As String

    Public ReadOnly Property CantidadProductos As Integer
        Get
            If Detalle Is Nothing Then Return 0
            Return Detalle.Sum(Function(i) i.Cantidad)
        End Get
    End Property
End Class
