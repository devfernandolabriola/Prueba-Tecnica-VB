Imports System.ComponentModel
Imports System.Security.Cryptography.X509Certificates
Imports Capa_de_Dominio
Imports Entidades
Imports Microsoft.Office.Interop
Imports Microsoft.Vbe.Interop

Public Class Form1

    'Form1 Load

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarClientesEnGrid()
        CargarProductosEnGrid()
        CargarVentasEnGrid()
    End Sub


    'Clientes MAIN FORM


    Private listaClientes As List(Of EntidadCliente)
    Private clienteNegocio As New ClienteNegocio()
    Private Sub CargarClientesEnGrid()
        Try
            listaClientes = clienteNegocio.ListarClientes()
            dgvClientes.DataSource = listaClientes
            dgvClientes.Columns("Cliente").HeaderText = "Cliente"
            dgvClientes.Columns("Correo").HeaderText = "Correo"
            dgvClientes.Columns("ID").Visible = False
        Catch ex As Exception
            MessageBox.Show("Error al cargar clientes: " & ex.Message)
        End Try
    End Sub

    Private Sub btnCrearCliente_Click(sender As Object, e As EventArgs) Handles btnCrearCliente.Click
        Dim form = New FormCliente()
        form.ShowDialog()

        If form.ClienteAgregado Then
            CargarClientesEnGrid()
        End If

    End Sub

    Private Sub btnModificarCliente_Click(sender As Object, e As EventArgs) Handles btnModificarCliente.Click
        If dgvClientes.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecciona un cliente para modificar", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim fila As DataGridViewRow = dgvClientes.SelectedRows(0)
        Dim clienteSeleccionado As New EntidadCliente With {
            .ID = Convert.ToInt32(fila.Cells("Id").Value),
            .Cliente = fila.Cells("Cliente").Value.ToString(),
            .Telefono = fila.Cells("Telefono").Value.ToString(),
            .Correo = fila.Cells("Correo").Value.ToString()
        }

        Dim formEdit As New FormCliente(clienteSeleccionado)
        formEdit.ShowDialog()

        If formEdit.ClienteModificado Then
            CargarClientesEnGrid()
        End If
    End Sub

    Private Sub tabClientes_Enter(sender As Object, e As EventArgs) Handles TabClientes.Enter

    End Sub

    Private Sub tabVentas_Enter(sender As Object, e As EventArgs) Handles TabVentas.Enter

    End Sub
    Private Sub btnEliminarCliente_Click(sender As Object, e As EventArgs) Handles btnEliminarCliente.Click
        If dgvClientes.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecciona un cliente para eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim fila As DataGridViewRow = dgvClientes.SelectedRows(0)
        Dim nomCliente As String = fila.Cells("Cliente").Value
        Dim confirmacion As DialogResult = MessageBox.Show("¿Estas seguro que desea eliminar al cliente " + nomCliente + "?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmacion = DialogResult.No Then Return
        Dim idCliente As Integer = Convert.ToInt32(fila.Cells("Id").Value)


        Dim exito As Boolean = clienteNegocio.EliminarCliente(idCliente)

        If exito Then
            MessageBox.Show("Cliente eliminado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CargarClientesEnGrid()
        Else
            MessageBox.Show("No se pudo eliminar el Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnVerVentasCliente_Click(sender As Object, e As EventArgs) Handles btnVerVentasCliente.Click
        If dgvClientes.CurrentRow Is Nothing Then
            MessageBox.Show("Seleccioná un cliente.")
            Return
        End If

        Dim cliente As EntidadCliente = CType(dgvClientes.CurrentRow.DataBoundItem, EntidadCliente)
        Dim idCliente As Integer = cliente.ID

        TabControlMain.SelectedTab = TabVentas

        Dim ventasFiltradas = ventas.Where(Function(v) v.IDCliente = idCliente).ToList()

        dgvVentas.DataSource = Nothing
        dgvVentas.DataSource = New BindingList(Of EntidadVenta)(ventasFiltradas)
        dgvVentas.Columns("ID").Visible = False
        dgvVentas.Columns("IDCliente").Visible = False

        If dgvVentas.Rows.Count > 0 Then
            dgvVentas.Rows(0).Selected = True
        End If
    End Sub


    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click, TabVentas.Enter, TabClientes.Enter
        Dim textoBusqueda As String = txtBuscarCliente.Text.Trim().ToLower()

        If String.IsNullOrWhiteSpace(textoBusqueda) Then
            dgvClientes.DataSource = Nothing
            dgvClientes.DataSource = New BindingList(Of EntidadCliente)(listaClientes)
            Return
        End If

        Dim clientesFiltrados = listaClientes.Where(Function(c) _
        c.Cliente.ToLower().Contains(textoBusqueda) OrElse
        c.Telefono.ToLower().Contains(textoBusqueda) OrElse
        c.Correo.ToLower().Contains(textoBusqueda)
    ).ToList()

        dgvClientes.DataSource = Nothing
        dgvClientes.DataSource = New BindingList(Of EntidadCliente)(clientesFiltrados)
        dgvClientes.Columns("ID").Visible = False
    End Sub

    Private Sub btnFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnFiltroCliente.Click
        txtBuscarCliente.Text = ""
        CargarClientesEnGrid()
    End Sub

    Private Sub btnVerCliente_Click(sender As Object, e As EventArgs) Handles btnVerCliente.Click
        If dgvVentas.CurrentRow Is Nothing Then
            MessageBox.Show("Seleccioná una venta.")
            Return
        End If


        Dim venta As EntidadVenta = CType(dgvVentas.CurrentRow.DataBoundItem, EntidadVenta)
        Dim idCliente As Integer = venta.IDCliente

        TabControlMain.SelectedTab = TabClientes


        Dim clienteFiltrado = listaClientes.Where(Function(c) c.ID = idCliente).ToList()

        dgvClientes.DataSource = Nothing
        dgvClientes.DataSource = New BindingList(Of EntidadCliente)(clienteFiltrado)
        dgvClientes.Columns("ID").Visible = False
        For Each row As DataGridViewRow In dgvClientes.Rows
            If Not row.IsNewRow Then
                Dim cliente As EntidadCliente = CType(row.DataBoundItem, EntidadCliente)
                If cliente.ID = idCliente Then
                    row.Selected = True
                    dgvClientes.FirstDisplayedScrollingRowIndex = row.Index
                    Exit For
                End If
            End If
        Next
    End Sub

    'Productos MAIN FORM

    Private productoNegocio As New ProductoNegocio()
    Private listaproductos As New List(Of EntidadProducto)
    Private Sub tabProductos_Enter(sender As Object, e As EventArgs) Handles TabProductos.Enter
        Me.BeginInvoke(Sub()
                           If dgvProductos.Rows.Count > 0 Then
                               dgvProductos.ClearSelection()
                           End If
                       End Sub)
    End Sub

    Private Sub CargarProductosEnGrid()
        Try
            listaproductos = productoNegocio.ListarProductos()
            dgvProductos.DataSource = listaproductos
            dgvProductos.Columns("Nombre").HeaderText = "Producto"
            dgvProductos.Columns("Precio").DefaultCellStyle.Format = "C2"
            dgvProductos.Columns("Categoria").HeaderText = "Categoría"
            dgvProductos.Columns("Id").Visible = False
            dgvProductos.Columns("Categoria").DisplayIndex = 0
            dgvProductos.Columns("Nombre").DisplayIndex = 1
            dgvProductos.Columns("Precio").DisplayIndex = 2
        Catch ex As Exception
            MessageBox.Show("Error al cargar productos: " & ex.Message)
        End Try

        If dgvProductos.Rows.Count > 0 Then
            Me.BeginInvoke(Sub() dgvProductos.ClearSelection())
        End If
    End Sub

    Private Sub btnCrearProducto_Click(sender As Object, e As EventArgs) Handles btnCrearProducto.Click
        Dim form As New FormProducto()
        form.ShowDialog()

        If form.ProductoAgregado Then
            CargarProductosEnGrid()
        End If
    End Sub

    Private Sub btnModificarProducto_Click(sender As Object, e As EventArgs) Handles btnModificarProducto.Click
        If dgvProductos.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecciona un producto para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim fila As DataGridViewRow = dgvProductos.SelectedRows(0)
        Dim productoSeleccionado As New EntidadProducto With {
            .ID = Convert.ToInt32(fila.Cells("Id").Value),
            .Nombre = fila.Cells("Nombre").Value.ToString(),
            .Precio = Convert.ToDecimal(fila.Cells("Precio").Value),
            .Categoria = fila.Cells("Categoria").Value.ToString()
        }

        Dim formEdit As New FormProducto(productoSeleccionado)
        formEdit.ShowDialog()

        If formEdit.ProductoModificado Then
            CargarProductosEnGrid()
        End If
    End Sub

    Private Sub btnEliminarProducto_Click(sender As Object, e As EventArgs) Handles btnEliminarProducto.Click
        If dgvProductos.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecciona un cliente para eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim fila As DataGridViewRow = dgvProductos.SelectedRows(0)
        Dim nomProducto As String = fila.Cells("Nombre").Value
        Dim confirmacion As DialogResult = MessageBox.Show("¿Estas seguro que desea eliminar el producto " + nomProducto + "?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmacion = DialogResult.No Then Return
        Dim idProducto As Integer = Convert.ToInt32(fila.Cells("Id").Value)


        Dim exito As Boolean = productoNegocio.EliminarProducto(idProducto)

        If exito Then
            MessageBox.Show("Producto eliminado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CargarProductosEnGrid()
        Else
            MessageBox.Show("No se pudo eliminar el Producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub btnBuscarProducto_Click(sender As Object, e As EventArgs) Handles btnBuscarProducto.Click, TabControlMain.Enter
        Dim textoBusqueda As String = txtBuscarProducto.Text.Trim().ToLower()

        ' Si no hay texto, mostramos todos los productos
        If String.IsNullOrWhiteSpace(textoBusqueda) Then
            dgvProductos.DataSource = Nothing
            dgvProductos.DataSource = New BindingList(Of EntidadProducto)(listaproductos)
            Return
        End If

        ' Filtramos por nombre o categoría
        Dim productosFiltrados = listaproductos.Where(Function(p) _
            p.Nombre.ToLower().Contains(textoBusqueda) OrElse
            p.Categoria.ToLower().Contains(textoBusqueda)
        ).ToList()

        dgvProductos.DataSource = Nothing
        dgvProductos.DataSource = New BindingList(Of EntidadProducto)(productosFiltrados)
        dgvProductos.Columns("ID").Visible = False
        dgvProductos.Columns("Nombre").HeaderText = "Producto"
        dgvProductos.Columns("Categoria").HeaderText = "Categoría"
        dgvProductos.Columns("Categoria").DisplayIndex = 0
        dgvProductos.Columns("Nombre").DisplayIndex = 1
        dgvProductos.Columns("Precio").DisplayIndex = 2
    End Sub

    Private Sub btnFiltroProducto_Click(sender As Object, e As EventArgs) Handles btnFiltroProducto.Click
        txtBuscarProducto.Text = ""
        CargarProductosEnGrid()
    End Sub


    'Ventas MAIN FORM

    Private VentaNegocio As New VentaNegocio

    Private ventas As List(Of EntidadVenta)
    Private Sub btnCrearVenta_Click(sender As Object, e As EventArgs) Handles btnCrearVenta.Click
        Dim form As New FormVenta
        form.ShowDialog()
        CargarVentasEnGrid()
    End Sub


    Private Sub CargarVentasEnGrid()
        Try
            ventas = VentaNegocio.ListarVentas()

            For Each v In ventas
                v.Detalle = VentaNegocio.ObtenercantidaditemsporVentaID(v.ID)
            Next

            dgvVentas.DataSource = Nothing
            dgvVentas.DataSource = New BindingList(Of EntidadVenta)(ventas)

            dgvVentas.Columns("ID").Visible = False
            dgvVentas.Columns("IDCliente").Visible = False
            dgvVentas.Columns("Total").DefaultCellStyle.Format = "C2"
            dgvVentas.Columns("NombreCliente").HeaderText = "Cliente"
            dgvVentas.Columns("Fecha").HeaderText = "Fecha"
            dgvVentas.Columns("Total").HeaderText = "Precio Total"
            dgvVentas.Columns("CantidadProductos").HeaderText = "Productos"
            dgvVentas.Columns("NombreCliente").DisplayIndex = 0
            dgvVentas.Columns("CantidadProductos").DisplayIndex = 1
            dgvVentas.Columns("Fecha").DisplayIndex = 2
            dgvVentas.Columns("Total").DisplayIndex = 3
            dtpDesde.Value = New DateTime(2025, 1, 1)
            dtpHasta.Value = DateTime.Now
        Catch ex As Exception
            MessageBox.Show("Error al cargar ventas: " & ex.Message)
        End Try
    End Sub

    Private Sub btnEliminarVenta_Click(sender As Object, e As EventArgs) Handles btnEliminarVenta.Click
        If dgvVentas.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecciona una venta para eliminar", "Atencion", MessageBoxButtons.OK)
            Return
        End If

        Dim fila As DataGridViewRow = dgvVentas.SelectedRows(0)
        Dim idVenta As Integer = Convert.ToInt32(fila.Cells("ID").Value)

        Dim confirmar = MessageBox.Show("¿Estás seguro de que deseas eliminar esta venta?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirmar = DialogResult.Yes Then
            Try
                VentaNegocio.EliminarVenta(idVenta)
                MessageBox.Show("Venta eliminada con exito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CargarVentasEnGrid()
            Catch ex As Exception
                MessageBox.Show("Error al eliminar la venta: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnModificarVenta_Click(sender As Object, e As EventArgs) Handles btnModificarVenta.Click
        If dgvVentas.CurrentRow IsNot Nothing Then
            Dim ventaSel As EntidadVenta = CType(dgvVentas.CurrentRow.DataBoundItem, EntidadVenta)
            Dim form As New FormVenta()
            form.VentaAEditar = ventaSel
            form.ShowDialog()

            If form.VentaModificada Then
                CargarVentasEnGrid()
            End If
            form.Dispose()
        Else
            MessageBox.Show("Selecciona una venta para modificar.","Advertencia", MessageBoxButtons.OK)
        End If
    End Sub



    Private Sub btnBuscarVenta_Click(sender As Object, e As EventArgs) Handles btnBuscarVenta.Click
        Dim textoCliente = txtBuscarVenta.Text.Trim().ToLower()
        Dim fechaDesde = dtpDesde.Value.Date
        Dim fechaHasta = dtpHasta.Value.Date

        If fechaDesde > fechaHasta Then
            MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.", "Error de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpDesde.Value = dtpHasta.Value.Date
            fechaDesde = dtpDesde.Value.Date
            Return
        End If

        If fechaHasta > DateTime.Now Then
            MessageBox.Show("La fecha 'Hasta' no puede ser posterior a la fecha actual.", "Error de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpHasta.Value = DateTime.Now
            fechaHasta = dtpHasta.Value.Date
            Return
        End If

        Dim ventasFiltradas = ventas.Where(Function(v)
                                               Dim coincideCliente = String.IsNullOrWhiteSpace(textoCliente) OrElse
                                            v.NombreCliente.ToLower().Contains(textoCliente.ToLower())
                                               Dim coincideFecha = v.Fecha.Date >= fechaDesde.Date AndAlso
                                             v.Fecha.Date <= fechaHasta.Date
                                               Return coincideCliente AndAlso coincideFecha
                                           End Function).
    ToList()

        dgvVentas.DataSource = New BindingList(Of EntidadVenta)(ventasFiltradas)
        dgvVentas.Columns("IDCliente").Visible = False
        dgvVentas.Columns("NombreCliente").DisplayIndex = 0
        dgvVentas.Columns("CantidadProductos").DisplayIndex = 1
        dgvVentas.Columns("Fecha").DisplayIndex = 2
        dgvVentas.Columns("Total").DisplayIndex = 3
    End Sub



    Private Sub btnDetalleVenta_Click(sender As Object, e As EventArgs) Handles btnDetalleVenta.Click
        If dgvVentas.CurrentRow Is Nothing Then
            MessageBox.Show("Seleccioná una venta.")
            Return
        End If

        Dim venta As EntidadVenta = CType(dgvVentas.CurrentRow.DataBoundItem, EntidadVenta)


        venta.Detalle = VentaNegocio.ObtenerItemsPorVentaID(venta.ID)

        For Each producto In venta.Detalle
            producto.NombreProducto = productoNegocio.ObtenerNombreProductoPorID(producto.IDProducto)
        Next

        Dim detalleForm As New FormDetalleVenta(venta)
        detalleForm.lblPrecioFinal.Text = "Precio Final: $" & venta.Detalle.Sum(Function(p) p.PrecioTotal)
        detalleForm.ShowDialog()
    End Sub

    Private Sub dgvLimpiarFiltrosVenta_Click(sender As Object, e As EventArgs) Handles dgvLimpiarFiltrosVenta.Click
        txtBuscarVenta.Text = ""
        CargarVentasEnGrid()
    End Sub

    Private Sub Exportar_Venta_Click(sender As Object, e As EventArgs) Handles Exportar_Venta.Click
        ExportaraExcel(dgvVentas)
    End Sub

    Private Sub ExportaraExcel(ByVal dgv As DataGridView)
        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook = xlApp.Workbooks.Add()
        Dim xlWorkSheet As Excel.Worksheet = CType(xlWorkBook.Sheets(1), Excel.Worksheet)
        Dim columnasExcluidas As New List(Of String) From {"ID", "IDCliente"}

        Try
            ' Escribir encabezados (omitiendo los excluidos)
            Dim colIndex As Integer = 1
            For Each col As DataGridViewColumn In dgv.Columns
                If Not columnasExcluidas.Contains(col.Name) Then
                    xlWorkSheet.Cells(1, colIndex) = col.HeaderText
                    xlWorkSheet.Cells(1, colIndex).Interior.Color = Color.FromArgb(255, 0, 128, 0)
                    xlWorkSheet.Cells(1, colIndex).Font.Color = Color.FromArgb(255, 255, 255)
                    colIndex += 1
                End If
            Next

            ' Escribir datos
            Dim rowIndex As Integer = 2
            For Each row As DataGridViewRow In dgv.Rows
                If row.Visible AndAlso Not row.IsNewRow Then
                    colIndex = 1
                    For Each col As DataGridViewColumn In dgv.Columns
                        If Not columnasExcluidas.Contains(col.Name) Then
                            Dim valor = row.Cells(col.Index).Value
                            If valor IsNot Nothing Then
                                xlWorkSheet.Cells(rowIndex, colIndex) = valor.ToString()
                                xlWorkSheet.Cells(rowIndex, colIndex).Interior.Color = Color.FromArgb(255, 0, 172, 0)
                                xlWorkSheet.Cells(rowIndex, colIndex).Font.Color = Color.FromArgb(255, 255, 255)
                            End If
                            colIndex += 1
                        End If
                    Next
                    rowIndex += 1
                End If
            Next

            xlApp.Visible = True
        Catch ex As Exception
            MessageBox.Show("Error al exportar: " & ex.Message)
        End Try
    End Sub

    Private Sub btnExportarSeleccionado_Click(sender As Object, e As EventArgs) Handles btnExportarSeleccionado.Click
        ExportarFilaSeleccionadaAExcel(dgvVentas)
    End Sub

    Private Sub ExportarFilaSeleccionadaAExcel(ByVal dgv As DataGridView)
        If dgv.CurrentRow Is Nothing Then
            MessageBox.Show("No hay una fila seleccionada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook = xlApp.Workbooks.Add()
        Dim xlWorkSheet As Excel.Worksheet = CType(xlWorkBook.Sheets(1), Excel.Worksheet)
        Dim columnasExcluidas As New List(Of String) From {"ID", "IDCliente"}

        Try
            ' Escribir encabezados (omitiendo los excluidos)
            Dim colIndex As Integer = 1
            For Each col As DataGridViewColumn In dgv.Columns
                If Not columnasExcluidas.Contains(col.Name) Then
                    xlWorkSheet.Cells(1, colIndex) = col.HeaderText
                    xlWorkSheet.Cells(1, colIndex).Interior.Color = Color.FromArgb(255, 0, 128, 0)
                    xlWorkSheet.Cells(1, colIndex).Font.Color = Color.FromArgb(255, 255, 255)
                    colIndex += 1
                End If
            Next

            ' Escribir solo la fila seleccionada
            Dim rowIndex As Integer = 2
            colIndex = 1
            Dim row As DataGridViewRow = dgv.CurrentRow
            Dim idVenta As Integer = Convert.ToInt32(row.Cells("ID").Value)

            For Each col As DataGridViewColumn In dgv.Columns
                If Not columnasExcluidas.Contains(col.Name) Then
                    Dim valor = row.Cells(col.Index).Value
                    If valor IsNot Nothing Then
                        xlWorkSheet.Cells(rowIndex, colIndex) = valor.ToString()
                        xlWorkSheet.Cells(rowIndex, colIndex).Interior.Color = Color.FromArgb(255, 0, 172, 0)
                        xlWorkSheet.Cells(rowIndex, colIndex).Font.Color = Color.FromArgb(255, 255, 255)
                    End If
                    colIndex += 1
                End If
            Next

            Dim productos As List(Of EntidadVentaItem) = VentaNegocio.ObtenerItemsPorVentaID(idVenta)


            For Each producto In productos
                producto.NombreProducto = productoNegocio.ObtenerNombreProductoPorID(producto.IDProducto)
            Next
            ' Agregar encabezado de productos
            rowIndex += 4 ' Deja una fila en blanco
            xlWorkSheet.Cells(rowIndex, 1) = "Producto"
            xlWorkSheet.Cells(rowIndex, 1).Interior.Color = Color.FromArgb(255, 255, 210, 0)
            xlWorkSheet.Cells(rowIndex, 2) = "Precio Unitario"
            xlWorkSheet.Cells(rowIndex, 2).Interior.Color = Color.FromArgb(255, 255, 210, 0)
            xlWorkSheet.Cells(rowIndex, 3) = "Cantidad"
            xlWorkSheet.Cells(rowIndex, 3).Interior.Color = Color.FromArgb(255, 255, 210, 0)
            xlWorkSheet.Cells(rowIndex, 4) = "Precio Total"
            xlWorkSheet.Cells(rowIndex, 4).Interior.Color = Color.FromArgb(255, 255, 210, 0)
            rowIndex += 1

            ' Escribir productos
            For Each item In productos
                xlWorkSheet.Cells(rowIndex, 1) = item.NombreProducto
                xlWorkSheet.Cells(rowIndex, 1).Interior.Color = Color.FromArgb(255, 255, 255, 0)
                xlWorkSheet.Cells(rowIndex, 2) = item.PrecioUnitario
                xlWorkSheet.Cells(rowIndex, 2).Interior.Color = Color.FromArgb(255, 255, 255, 0)
                xlWorkSheet.Cells(rowIndex, 3) = item.Cantidad
                xlWorkSheet.Cells(rowIndex, 3).Interior.Color = Color.FromArgb(255, 255, 255, 0)
                xlWorkSheet.Cells(rowIndex, 4) = item.PrecioTotal
                xlWorkSheet.Cells(rowIndex, 4).Interior.Color = Color.FromArgb(255, 255, 255, 0)
                rowIndex += 1
            Next

            xlApp.Visible = True
        Catch ex As Exception
            MessageBox.Show("Error al exportar: " & ex.Message)
        End Try
    End Sub
End Class
