Imports System.ComponentModel
Imports Capa_de_Dominio
Imports Entidades
Public Class FormSeleccionarProducto
    Public Property ProductoSeleccionado As EntidadVentaItem

    Private ProductosDisponibles As List(Of EntidadProducto)

    Private Producto As New ProductoNegocio

    Private Sub btnAgregarProducto_Click(sender As Object, e As EventArgs) Handles btnAgregarProducto.Click
        If dgvProductos.CurrentRow Is Nothing Then
            MessageBox.Show("Selecciona un producto.")
            Return
        End If

        Dim producto As EntidadProducto = CType(dgvProductos.CurrentRow.DataBoundItem, EntidadProducto)
        Dim cantidad As Integer = CInt(nudCantidad.Value)

        If cantidad <= 0 Then
            MessageBox.Show("La cantidad debe ser mayor a cero")
            Return
        End If

        ProductoSeleccionado = New EntidadVentaItem With {
            .IDProducto = producto.ID,
            .NombreProducto = producto.Nombre,
            .Cantidad = cantidad,
            .PrecioUnitario = producto.Precio,
            .PrecioTotal = cantidad * producto.Precio
        }

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub FormSeleccionarProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarProductos()
    End Sub

    Private Sub CargarProductos()
        ProductosDisponibles = Producto.ListarProductos()
        MostrarProductos(ProductosDisponibles)
        dgvProductos.Columns("Categoria").DisplayIndex = 0
        dgvProductos.Columns("Nombre").DisplayIndex = 1
        dgvProductos.Columns("Precio").DisplayIndex = 2
    End Sub

    Private Sub MostrarProductos(productos As List(Of EntidadProducto))
        dgvProductos.Columns.Clear()
        dgvProductos.Rows.Clear()
        dgvProductos.DataSource = New BindingList(Of EntidadProducto)(productos)
        dgvProductos.Columns("ID").Visible = False
    End Sub

    Private Sub btnBusquedaProducto_Click(sender As Object, e As EventArgs) Handles btnBusquedaProducto.Click
        Dim textoBusqueda As String = txtBuscarProducto.Text.Trim().ToLower()

        ' Si está vacío, volvemos a cargar todos
        If String.IsNullOrWhiteSpace(textoBusqueda) Then
            CargarProductos()
            Return
        End If

        ' Filtramos los productos
        Dim productosFiltrados = ProductosDisponibles.Where(Function(p) p.Nombre.ToLower().Contains(textoBusqueda) OrElse p.Categoria.ToLower().Contains(textoBusqueda)).ToList()

        dgvProductos.DataSource = Nothing
        dgvProductos.DataSource = New BindingList(Of EntidadProducto)(productosFiltrados)
        dgvProductos.Columns("ID").Visible = False
    End Sub

    Private Sub btnlimpiarSelProducto_Click(sender As Object, e As EventArgs) Handles btnlimpiarSelProducto.Click

    End Sub
End Class