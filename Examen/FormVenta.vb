Imports System.ComponentModel
Imports Capa_de_Dominio
Imports Entidades

Public Class FormVenta
    Private ProductosSeleccionados As New List(Of EntidadVentaItem)
    Private Cliente As New ClienteNegocio()
    Private VentaNegocio As New VentaNegocio()
    Private productonegocio As New ProductoNegocio()
    Public Property VentaModificada As Boolean = False
    Private Property Modificandoventa As Boolean = False

    Public VentaAEditar As EntidadVenta
    Private Sub RefrescarDetalleVenta()
        dgvItemsVenta.Rows.Clear()
        For Each item In ProductosSeleccionados
            dgvItemsVenta.Rows.Add(item.NombreProducto, item.Cantidad, item.PrecioUnitario, item.PrecioTotal)
        Next
        lblTotal.Text = "Precio Total: $" & ProductosSeleccionados.Sum(Function(p) p.PrecioTotal)

        If dgvItemsVenta.Rows.Count > 0 Then
            dgvItemsVenta.ClearSelection()
        End If
    End Sub
    Private Sub btnAgregarProducto_Click(sender As Object, e As EventArgs) Handles btnAgregarProducto.Click
        Dim formSel As New FormSeleccionarProducto
        If formSel.ShowDialog() = DialogResult.OK Then
            Dim ItemNuevo = formSel.ProductoSeleccionado

            Dim existente = ProductosSeleccionados.FirstOrDefault(Function(p) p.IDProducto = ItemNuevo.IDProducto)
            If existente IsNot Nothing Then
                existente.Cantidad += ItemNuevo.Cantidad
                existente.PrecioTotal = existente.Cantidad * existente.PrecioUnitario
            Else
                ProductosSeleccionados.Add(ItemNuevo)
            End If
            RefrescarDetalleVenta()
        End If

    End Sub

    Private Sub FormVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarClientes()
        ConfigurarGridItems()

        If VentaAEditar IsNot Nothing Then
            Modificandoventa = True
            Me.Text = "Modificar Venta"
            btnCrearVenta.Text = "Modificar"

            cbxCliente.SelectedValue = VentaAEditar.IDCliente
            dtpFecha.Value = VentaAEditar.Fecha
            ProductosSeleccionados = VentaAEditar.Detalle
            For Each producto In ProductosSeleccionados
                producto.NombreProducto = productonegocio.ObtenerNombreProductoPorID(producto.IDProducto)
            Next
            RefrescarDetalleVenta()
        End If

    End Sub

    Private Sub CargarClientes()
        Try
            Dim clientes = Cliente.ListarClientes()
            cbxCliente.DataSource = clientes
            cbxCliente.DisplayMember = "Cliente"
            cbxCliente.ValueMember = "ID"
            cbxCliente.SelectedIndex = -1
            dtpFecha.Value = DateTime.Now
        Catch ex As Exception
            MessageBox.Show("Error al cargar clientes: " & ex.Message)
        End Try

    End Sub

    Private Sub ConfigurarGridItems()
        dgvItemsVenta.Columns.Clear()
        dgvItemsVenta.Columns.Add("NombreProducto", "Producto")
        dgvItemsVenta.Columns.Add("Cantidad", "Cantidad")
        dgvItemsVenta.Columns.Add("PrecioUnitario", "Precio Unitario")
        dgvItemsVenta.Columns.Add("PrecioTotal", "Precio Total")
        dgvItemsVenta.Columns("PrecioUnitario").DefaultCellStyle.Format = "C2"
        dgvItemsVenta.Columns("PrecioTotal").DefaultCellStyle.Format = "C2"
    End Sub

    Private Sub btnQuitarProducto_Click(sender As Object, e As EventArgs) Handles btnQuitarProducto.Click
        If dgvItemsVenta.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione un producto para quitar")
            Return
        End If

        Dim Nombre As String = dgvItemsVenta.CurrentRow.Cells("NombreProducto").Value()


        Dim item = ProductosSeleccionados.FirstOrDefault(Function(p) p.NombreProducto = Nombre)

        If item IsNot Nothing Then
            If MessageBox.Show("¿Esta seguro que desea quitar el producto " + item.NombreProducto + " de la venta?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ProductosSeleccionados.Remove(item)
                RefrescarDetalleVenta()
            End If
        End If
    End Sub

    Private Sub btnCrearVenta_Click(sender As Object, e As EventArgs) Handles btnCrearVenta.Click
        If cbxCliente.SelectedItem Is Nothing Then
            MessageBox.Show("Selecciona un cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If ProductosSeleccionados.Count = 0 Then
            MessageBox.Show("Agrega al menos un producto a la venta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim venta As New EntidadVenta With {
            .ID = If(VentaAEditar IsNot Nothing, VentaAEditar.ID, 0),
            .IDCliente = CType(cbxCliente.SelectedItem, EntidadCliente).ID,
            .Fecha = dtpFecha.Value,
            .Detalle = ProductosSeleccionados,
            .Total = ProductosSeleccionados.Sum(Function(p) p.PrecioTotal)
        }

        Try
            If VentaAEditar IsNot Nothing Then
                VentaNegocio.ModificarVenta(venta)
                VentaModificada = True
                MessageBox.Show("Venta modificada con exito")
            Else
                VentaNegocio.RegistrarVenta(venta)
                MessageBox.Show("Venta creada con exito")
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error al registrar la venta: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class