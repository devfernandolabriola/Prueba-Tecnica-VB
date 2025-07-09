Imports Entidades
Imports Data
Imports System.Text.RegularExpressions
Public Class ProductoNegocio
    Private ProductoDAL As New ProductoDAL()
    Private EsModificado As Boolean = False

    Public Function ListarProductos() As List(Of EntidadProducto)
        Return ProductoDAL.ListarProductos()
    End Function

    Public Function RegistrarProducto(producto As EntidadProducto) As Boolean
        Dim errores As List(Of String) = ValidarProducto(producto)

        If errores.Count > 0 Then
            Throw New Exception("Errores de validación: " & String.Join(" | ", errores))
        End If

        Return ProductoDAL.CrearProducto(producto)
    End Function

    Private Function ValidarProducto(producto As EntidadProducto) As List(Of String)
        Dim errores As New List(Of String)

        If EsModificado = False Then
            If String.IsNullOrWhiteSpace(producto.Nombre) Then
                errores.Add("El nombre del producto es obligatorio.")
            ElseIf ProductoDAL.ProductoExistente(producto.Nombre.ToLower()) Then
                errores.Add("El producto ya existe en la Base de datos")
            End If
        End If

        Dim regexPrecio As New Regex("^\d+(\.\d{1,2})?$")
        Dim precioTexto As String = producto.Precio.ToString(System.Globalization.CultureInfo.InvariantCulture)
        If Not regexPrecio.IsMatch(precioTexto) Then
            errores.Add("El precio debe ser un número válido con hasta 2 decimales.")
        ElseIf producto.Precio <= 0 Then
            errores.Add("El precio debe ser mayor a 0")
        End If

        If String.IsNullOrWhiteSpace(producto.Categoria) Then
            errores.Add("La categoría es obligatoria.")
        End If

        Return errores
    End Function

    Public Function ModificarProducto(producto As EntidadProducto) As Boolean
        EsModificado = True
        Dim errores As List(Of String) = ValidarProducto(producto)

        If errores.Count > 0 Then
            Throw New Exception("Errores de validación: " & String.Join(" | ", errores))
        End If

        Return ProductoDAL.ModificarProducto(producto)
    End Function

    Public Function EliminarProducto(id As Integer) As Boolean
        If id <= 0 Then
            Throw New Exception("ID de producto inválido.")
        End If

        Return ProductoDAL.EliminarProducto(id)
    End Function

    Public Function ObtenerNombreProductoPorID(idProducto As Integer) As String
        Return ProductoDAL.ObtenerNombreProductoPorID(idProducto)
    End Function
End Class
