<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TabControlMain = New System.Windows.Forms.TabControl()
        Me.TabVentas = New System.Windows.Forms.TabPage()
        Me.Exportar_Venta = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDesde = New System.Windows.Forms.Label()
        Me.lblHasta = New System.Windows.Forms.Label()
        Me.btnDetalleVenta = New System.Windows.Forms.Button()
        Me.btnVerCliente = New System.Windows.Forms.Button()
        Me.dgvLimpiarFiltrosVenta = New System.Windows.Forms.Button()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.btnEliminarVenta = New System.Windows.Forms.Button()
        Me.btnCrearVenta = New System.Windows.Forms.Button()
        Me.btnModificarVenta = New System.Windows.Forms.Button()
        Me.btnBuscarVenta = New System.Windows.Forms.Button()
        Me.txtBuscarVenta = New System.Windows.Forms.TextBox()
        Me.dgvVentas = New System.Windows.Forms.DataGridView()
        Me.TabClientes = New System.Windows.Forms.TabPage()
        Me.btnVerVentasCliente = New System.Windows.Forms.Button()
        Me.lblBuscarCliente = New System.Windows.Forms.Label()
        Me.btnFiltroCliente = New System.Windows.Forms.Button()
        Me.txtBuscarCliente = New System.Windows.Forms.TextBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.btnEliminarCliente = New System.Windows.Forms.Button()
        Me.btnModificarCliente = New System.Windows.Forms.Button()
        Me.btnCrearCliente = New System.Windows.Forms.Button()
        Me.dgvClientes = New System.Windows.Forms.DataGridView()
        Me.TabProductos = New System.Windows.Forms.TabPage()
        Me.lblBuscarProducto = New System.Windows.Forms.Label()
        Me.btnFiltroProducto = New System.Windows.Forms.Button()
        Me.btnBuscarProducto = New System.Windows.Forms.Button()
        Me.txtBuscarProducto = New System.Windows.Forms.TextBox()
        Me.btnEliminarProducto = New System.Windows.Forms.Button()
        Me.btnModificarProducto = New System.Windows.Forms.Button()
        Me.btnCrearProducto = New System.Windows.Forms.Button()
        Me.dgvProductos = New System.Windows.Forms.DataGridView()
        Me.btnExportarSeleccionado = New System.Windows.Forms.Button()
        Me.TabControlMain.SuspendLayout()
        Me.TabVentas.SuspendLayout()
        CType(Me.dgvVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabClientes.SuspendLayout()
        CType(Me.dgvClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabProductos.SuspendLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControlMain
        '
        Me.TabControlMain.Controls.Add(Me.TabVentas)
        Me.TabControlMain.Controls.Add(Me.TabClientes)
        Me.TabControlMain.Controls.Add(Me.TabProductos)
        Me.TabControlMain.Location = New System.Drawing.Point(2, 6)
        Me.TabControlMain.Name = "TabControlMain"
        Me.TabControlMain.SelectedIndex = 0
        Me.TabControlMain.Size = New System.Drawing.Size(831, 343)
        Me.TabControlMain.TabIndex = 0
        '
        'TabVentas
        '
        Me.TabVentas.Controls.Add(Me.btnExportarSeleccionado)
        Me.TabVentas.Controls.Add(Me.Exportar_Venta)
        Me.TabVentas.Controls.Add(Me.Label1)
        Me.TabVentas.Controls.Add(Me.lblDesde)
        Me.TabVentas.Controls.Add(Me.lblHasta)
        Me.TabVentas.Controls.Add(Me.btnDetalleVenta)
        Me.TabVentas.Controls.Add(Me.btnVerCliente)
        Me.TabVentas.Controls.Add(Me.dgvLimpiarFiltrosVenta)
        Me.TabVentas.Controls.Add(Me.dtpHasta)
        Me.TabVentas.Controls.Add(Me.dtpDesde)
        Me.TabVentas.Controls.Add(Me.btnEliminarVenta)
        Me.TabVentas.Controls.Add(Me.btnCrearVenta)
        Me.TabVentas.Controls.Add(Me.btnModificarVenta)
        Me.TabVentas.Controls.Add(Me.btnBuscarVenta)
        Me.TabVentas.Controls.Add(Me.txtBuscarVenta)
        Me.TabVentas.Controls.Add(Me.dgvVentas)
        Me.TabVentas.Location = New System.Drawing.Point(4, 22)
        Me.TabVentas.Name = "TabVentas"
        Me.TabVentas.Padding = New System.Windows.Forms.Padding(3)
        Me.TabVentas.Size = New System.Drawing.Size(823, 317)
        Me.TabVentas.TabIndex = 0
        Me.TabVentas.Text = "Ventas"
        Me.TabVentas.UseVisualStyleBackColor = True
        '
        'Exportar_Venta
        '
        Me.Exportar_Venta.Location = New System.Drawing.Point(722, 254)
        Me.Exportar_Venta.Name = "Exportar_Venta"
        Me.Exportar_Venta.Size = New System.Drawing.Size(89, 23)
        Me.Exportar_Venta.TabIndex = 24
        Me.Exportar_Venta.Text = "Exportar"
        Me.Exportar_Venta.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(669, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Busqueda por nombre"
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.Location = New System.Drawing.Point(708, 59)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 22
        Me.lblDesde.Text = "Desde"
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.Location = New System.Drawing.Point(708, 111)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 21
        Me.lblHasta.Text = "Hasta"
        '
        'btnDetalleVenta
        '
        Me.btnDetalleVenta.Location = New System.Drawing.Point(722, 196)
        Me.btnDetalleVenta.Name = "btnDetalleVenta"
        Me.btnDetalleVenta.Size = New System.Drawing.Size(89, 23)
        Me.btnDetalleVenta.TabIndex = 20
        Me.btnDetalleVenta.Text = "Ver Detalle"
        Me.btnDetalleVenta.UseVisualStyleBackColor = True
        '
        'btnVerCliente
        '
        Me.btnVerCliente.Location = New System.Drawing.Point(722, 225)
        Me.btnVerCliente.Name = "btnVerCliente"
        Me.btnVerCliente.Size = New System.Drawing.Size(89, 23)
        Me.btnVerCliente.TabIndex = 19
        Me.btnVerCliente.Text = "Ver Cliente"
        Me.btnVerCliente.UseVisualStyleBackColor = True
        '
        'dgvLimpiarFiltrosVenta
        '
        Me.dgvLimpiarFiltrosVenta.Location = New System.Drawing.Point(722, 167)
        Me.dgvLimpiarFiltrosVenta.Name = "dgvLimpiarFiltrosVenta"
        Me.dgvLimpiarFiltrosVenta.Size = New System.Drawing.Size(89, 23)
        Me.dgvLimpiarFiltrosVenta.TabIndex = 18
        Me.dgvLimpiarFiltrosVenta.Text = "Limpiar"
        Me.dgvLimpiarFiltrosVenta.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.Location = New System.Drawing.Point(620, 130)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(200, 20)
        Me.dtpHasta.TabIndex = 16
        '
        'dtpDesde
        '
        Me.dtpDesde.Location = New System.Drawing.Point(620, 75)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(200, 20)
        Me.dtpDesde.TabIndex = 15
        '
        'btnEliminarVenta
        '
        Me.btnEliminarVenta.Location = New System.Drawing.Point(620, 254)
        Me.btnEliminarVenta.Name = "btnEliminarVenta"
        Me.btnEliminarVenta.Size = New System.Drawing.Size(89, 23)
        Me.btnEliminarVenta.TabIndex = 14
        Me.btnEliminarVenta.Text = "Eliminar Venta"
        Me.btnEliminarVenta.UseVisualStyleBackColor = True
        '
        'btnCrearVenta
        '
        Me.btnCrearVenta.Location = New System.Drawing.Point(620, 196)
        Me.btnCrearVenta.Name = "btnCrearVenta"
        Me.btnCrearVenta.Size = New System.Drawing.Size(89, 23)
        Me.btnCrearVenta.TabIndex = 13
        Me.btnCrearVenta.Text = "Crear Venta"
        Me.btnCrearVenta.UseVisualStyleBackColor = True
        '
        'btnModificarVenta
        '
        Me.btnModificarVenta.Location = New System.Drawing.Point(620, 225)
        Me.btnModificarVenta.Name = "btnModificarVenta"
        Me.btnModificarVenta.Size = New System.Drawing.Size(89, 23)
        Me.btnModificarVenta.TabIndex = 12
        Me.btnModificarVenta.Text = "Modificar Venta"
        Me.btnModificarVenta.UseVisualStyleBackColor = True
        '
        'btnBuscarVenta
        '
        Me.btnBuscarVenta.Location = New System.Drawing.Point(620, 167)
        Me.btnBuscarVenta.Name = "btnBuscarVenta"
        Me.btnBuscarVenta.Size = New System.Drawing.Size(89, 23)
        Me.btnBuscarVenta.TabIndex = 11
        Me.btnBuscarVenta.Text = "Buscar"
        Me.btnBuscarVenta.UseVisualStyleBackColor = True
        '
        'txtBuscarVenta
        '
        Me.txtBuscarVenta.Location = New System.Drawing.Point(653, 25)
        Me.txtBuscarVenta.Name = "txtBuscarVenta"
        Me.txtBuscarVenta.Size = New System.Drawing.Size(142, 20)
        Me.txtBuscarVenta.TabIndex = 10
        '
        'dgvVentas
        '
        Me.dgvVentas.AllowUserToAddRows = False
        Me.dgvVentas.AllowUserToDeleteRows = False
        Me.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVentas.Location = New System.Drawing.Point(6, 6)
        Me.dgvVentas.MultiSelect = False
        Me.dgvVentas.Name = "dgvVentas"
        Me.dgvVentas.ReadOnly = True
        Me.dgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVentas.Size = New System.Drawing.Size(602, 308)
        Me.dgvVentas.TabIndex = 9
        '
        'TabClientes
        '
        Me.TabClientes.Controls.Add(Me.btnVerVentasCliente)
        Me.TabClientes.Controls.Add(Me.lblBuscarCliente)
        Me.TabClientes.Controls.Add(Me.btnFiltroCliente)
        Me.TabClientes.Controls.Add(Me.txtBuscarCliente)
        Me.TabClientes.Controls.Add(Me.btnBuscarCliente)
        Me.TabClientes.Controls.Add(Me.btnEliminarCliente)
        Me.TabClientes.Controls.Add(Me.btnModificarCliente)
        Me.TabClientes.Controls.Add(Me.btnCrearCliente)
        Me.TabClientes.Controls.Add(Me.dgvClientes)
        Me.TabClientes.Location = New System.Drawing.Point(4, 22)
        Me.TabClientes.Name = "TabClientes"
        Me.TabClientes.Padding = New System.Windows.Forms.Padding(3)
        Me.TabClientes.Size = New System.Drawing.Size(823, 317)
        Me.TabClientes.TabIndex = 1
        Me.TabClientes.Text = "Clientes"
        Me.TabClientes.UseVisualStyleBackColor = True
        '
        'btnVerVentasCliente
        '
        Me.btnVerVentasCliente.Location = New System.Drawing.Point(670, 242)
        Me.btnVerVentasCliente.Name = "btnVerVentasCliente"
        Me.btnVerVentasCliente.Size = New System.Drawing.Size(97, 23)
        Me.btnVerVentasCliente.TabIndex = 8
        Me.btnVerVentasCliente.Text = "Ver Ventas"
        Me.btnVerVentasCliente.UseVisualStyleBackColor = True
        '
        'lblBuscarCliente
        '
        Me.lblBuscarCliente.AutoSize = True
        Me.lblBuscarCliente.Location = New System.Drawing.Point(692, 20)
        Me.lblBuscarCliente.Name = "lblBuscarCliente"
        Me.lblBuscarCliente.Size = New System.Drawing.Size(75, 13)
        Me.lblBuscarCliente.TabIndex = 7
        Me.lblBuscarCliente.Text = "Buscar Cliente"
        '
        'btnFiltroCliente
        '
        Me.btnFiltroCliente.Location = New System.Drawing.Point(725, 72)
        Me.btnFiltroCliente.Name = "btnFiltroCliente"
        Me.btnFiltroCliente.Size = New System.Drawing.Size(86, 23)
        Me.btnFiltroCliente.TabIndex = 6
        Me.btnFiltroCliente.Text = "Limpiar"
        Me.btnFiltroCliente.UseVisualStyleBackColor = True
        '
        'txtBuscarCliente
        '
        Me.txtBuscarCliente.Location = New System.Drawing.Point(659, 36)
        Me.txtBuscarCliente.Name = "txtBuscarCliente"
        Me.txtBuscarCliente.Size = New System.Drawing.Size(134, 20)
        Me.txtBuscarCliente.TabIndex = 5
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Location = New System.Drawing.Point(626, 72)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(86, 23)
        Me.btnBuscarCliente.TabIndex = 4
        Me.btnBuscarCliente.Text = "Buscar"
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'btnEliminarCliente
        '
        Me.btnEliminarCliente.Location = New System.Drawing.Point(670, 203)
        Me.btnEliminarCliente.Name = "btnEliminarCliente"
        Me.btnEliminarCliente.Size = New System.Drawing.Size(97, 23)
        Me.btnEliminarCliente.TabIndex = 3
        Me.btnEliminarCliente.Text = "Eliminar Cliente"
        Me.btnEliminarCliente.UseVisualStyleBackColor = True
        '
        'btnModificarCliente
        '
        Me.btnModificarCliente.Location = New System.Drawing.Point(670, 163)
        Me.btnModificarCliente.Name = "btnModificarCliente"
        Me.btnModificarCliente.Size = New System.Drawing.Size(97, 23)
        Me.btnModificarCliente.TabIndex = 2
        Me.btnModificarCliente.Text = "Modificar Cliente"
        Me.btnModificarCliente.UseVisualStyleBackColor = True
        '
        'btnCrearCliente
        '
        Me.btnCrearCliente.Location = New System.Drawing.Point(670, 121)
        Me.btnCrearCliente.Name = "btnCrearCliente"
        Me.btnCrearCliente.Size = New System.Drawing.Size(97, 23)
        Me.btnCrearCliente.TabIndex = 1
        Me.btnCrearCliente.Text = "Crear Cliente"
        Me.btnCrearCliente.UseVisualStyleBackColor = True
        '
        'dgvClientes
        '
        Me.dgvClientes.AllowUserToAddRows = False
        Me.dgvClientes.AllowUserToDeleteRows = False
        Me.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClientes.Location = New System.Drawing.Point(6, 6)
        Me.dgvClientes.MultiSelect = False
        Me.dgvClientes.Name = "dgvClientes"
        Me.dgvClientes.ReadOnly = True
        Me.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClientes.Size = New System.Drawing.Size(602, 305)
        Me.dgvClientes.TabIndex = 0
        '
        'TabProductos
        '
        Me.TabProductos.Controls.Add(Me.lblBuscarProducto)
        Me.TabProductos.Controls.Add(Me.btnFiltroProducto)
        Me.TabProductos.Controls.Add(Me.btnBuscarProducto)
        Me.TabProductos.Controls.Add(Me.txtBuscarProducto)
        Me.TabProductos.Controls.Add(Me.btnEliminarProducto)
        Me.TabProductos.Controls.Add(Me.btnModificarProducto)
        Me.TabProductos.Controls.Add(Me.btnCrearProducto)
        Me.TabProductos.Controls.Add(Me.dgvProductos)
        Me.TabProductos.Location = New System.Drawing.Point(4, 22)
        Me.TabProductos.Name = "TabProductos"
        Me.TabProductos.Size = New System.Drawing.Size(823, 317)
        Me.TabProductos.TabIndex = 2
        Me.TabProductos.Text = "Productos"
        Me.TabProductos.UseVisualStyleBackColor = True
        '
        'lblBuscarProducto
        '
        Me.lblBuscarProducto.AutoSize = True
        Me.lblBuscarProducto.Location = New System.Drawing.Point(681, 20)
        Me.lblBuscarProducto.Name = "lblBuscarProducto"
        Me.lblBuscarProducto.Size = New System.Drawing.Size(86, 13)
        Me.lblBuscarProducto.TabIndex = 7
        Me.lblBuscarProducto.Text = "Buscar Producto"
        '
        'btnFiltroProducto
        '
        Me.btnFiltroProducto.Location = New System.Drawing.Point(725, 72)
        Me.btnFiltroProducto.Name = "btnFiltroProducto"
        Me.btnFiltroProducto.Size = New System.Drawing.Size(86, 23)
        Me.btnFiltroProducto.TabIndex = 6
        Me.btnFiltroProducto.Text = "Limpiar"
        Me.btnFiltroProducto.UseVisualStyleBackColor = True
        '
        'btnBuscarProducto
        '
        Me.btnBuscarProducto.Location = New System.Drawing.Point(626, 72)
        Me.btnBuscarProducto.Name = "btnBuscarProducto"
        Me.btnBuscarProducto.Size = New System.Drawing.Size(86, 23)
        Me.btnBuscarProducto.TabIndex = 5
        Me.btnBuscarProducto.Text = "Buscar"
        Me.btnBuscarProducto.UseVisualStyleBackColor = True
        '
        'txtBuscarProducto
        '
        Me.txtBuscarProducto.Location = New System.Drawing.Point(659, 36)
        Me.txtBuscarProducto.Name = "txtBuscarProducto"
        Me.txtBuscarProducto.Size = New System.Drawing.Size(134, 20)
        Me.txtBuscarProducto.TabIndex = 4
        '
        'btnEliminarProducto
        '
        Me.btnEliminarProducto.Location = New System.Drawing.Point(670, 203)
        Me.btnEliminarProducto.Name = "btnEliminarProducto"
        Me.btnEliminarProducto.Size = New System.Drawing.Size(106, 23)
        Me.btnEliminarProducto.TabIndex = 3
        Me.btnEliminarProducto.Text = "Eliminar Producto"
        Me.btnEliminarProducto.UseVisualStyleBackColor = True
        '
        'btnModificarProducto
        '
        Me.btnModificarProducto.Location = New System.Drawing.Point(670, 161)
        Me.btnModificarProducto.Name = "btnModificarProducto"
        Me.btnModificarProducto.Size = New System.Drawing.Size(106, 23)
        Me.btnModificarProducto.TabIndex = 2
        Me.btnModificarProducto.Text = "Modificar Producto"
        Me.btnModificarProducto.UseVisualStyleBackColor = True
        '
        'btnCrearProducto
        '
        Me.btnCrearProducto.Location = New System.Drawing.Point(670, 121)
        Me.btnCrearProducto.Name = "btnCrearProducto"
        Me.btnCrearProducto.Size = New System.Drawing.Size(106, 23)
        Me.btnCrearProducto.TabIndex = 1
        Me.btnCrearProducto.Text = "Crear Producto"
        Me.btnCrearProducto.UseVisualStyleBackColor = True
        '
        'dgvProductos
        '
        Me.dgvProductos.AllowUserToAddRows = False
        Me.dgvProductos.AllowUserToDeleteRows = False
        Me.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductos.Location = New System.Drawing.Point(6, 6)
        Me.dgvProductos.MultiSelect = False
        Me.dgvProductos.Name = "dgvProductos"
        Me.dgvProductos.ReadOnly = True
        Me.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductos.Size = New System.Drawing.Size(602, 308)
        Me.dgvProductos.TabIndex = 0
        '
        'btnExportarSeleccionado
        '
        Me.btnExportarSeleccionado.Location = New System.Drawing.Point(722, 281)
        Me.btnExportarSeleccionado.Name = "btnExportarSeleccionado"
        Me.btnExportarSeleccionado.Size = New System.Drawing.Size(89, 23)
        Me.btnExportarSeleccionado.TabIndex = 25
        Me.btnExportarSeleccionado.Text = "Exportar Sel."
        Me.btnExportarSeleccionado.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 351)
        Me.Controls.Add(Me.TabControlMain)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.TabControlMain.ResumeLayout(False)
        Me.TabVentas.ResumeLayout(False)
        Me.TabVentas.PerformLayout()
        CType(Me.dgvVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabClientes.ResumeLayout(False)
        Me.TabClientes.PerformLayout()
        CType(Me.dgvClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabProductos.ResumeLayout(False)
        Me.TabProductos.PerformLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControlMain As TabControl
    Friend WithEvents TabVentas As TabPage
    Friend WithEvents TabClientes As TabPage
    Friend WithEvents dgvVentas As DataGridView
    Friend WithEvents btnEliminarVenta As Button
    Friend WithEvents btnCrearVenta As Button
    Friend WithEvents btnModificarVenta As Button
    Friend WithEvents btnBuscarVenta As Button
    Friend WithEvents txtBuscarVenta As TextBox
    Friend WithEvents TabProductos As TabPage
    Friend WithEvents dgvClientes As DataGridView
    Friend WithEvents btnCrearCliente As Button
    Friend WithEvents btnModificarCliente As Button
    Friend WithEvents btnEliminarCliente As Button
    Friend WithEvents dgvProductos As DataGridView
    Friend WithEvents btnEliminarProducto As Button
    Friend WithEvents btnModificarProducto As Button
    Friend WithEvents btnCrearProducto As Button
    Friend WithEvents txtBuscarCliente As TextBox
    Friend WithEvents btnBuscarCliente As Button
    Friend WithEvents dtpHasta As DateTimePicker
    Friend WithEvents dtpDesde As DateTimePicker
    Friend WithEvents btnDetalleVenta As Button
    Friend WithEvents btnVerCliente As Button
    Friend WithEvents dgvLimpiarFiltrosVenta As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblDesde As Label
    Friend WithEvents lblHasta As Label
    Friend WithEvents btnFiltroCliente As Button
    Friend WithEvents btnFiltroProducto As Button
    Friend WithEvents btnBuscarProducto As Button
    Friend WithEvents txtBuscarProducto As TextBox
    Friend WithEvents lblBuscarCliente As Label
    Friend WithEvents lblBuscarProducto As Label
    Friend WithEvents btnVerVentasCliente As Button
    Friend WithEvents Exportar_Venta As Button
    Friend WithEvents btnExportarSeleccionado As Button
End Class
