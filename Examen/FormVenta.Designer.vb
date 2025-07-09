<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVenta
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.cbxCliente = New System.Windows.Forms.ComboBox()
        Me.dgvItemsVenta = New System.Windows.Forms.DataGridView()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.btnQuitarProducto = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.btnCrearVenta = New System.Windows.Forms.Button()
        Me.btnAgregarProducto = New System.Windows.Forms.Button()
        Me.lblDetalle = New System.Windows.Forms.Label()
        CType(Me.dgvItemsVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(676, 30)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(39, 13)
        Me.lblCliente.TabIndex = 0
        Me.lblCliente.Text = "Cliente"
        '
        'cbxCliente
        '
        Me.cbxCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxCliente.FormattingEnabled = True
        Me.cbxCliente.Location = New System.Drawing.Point(611, 46)
        Me.cbxCliente.Name = "cbxCliente"
        Me.cbxCliente.Size = New System.Drawing.Size(163, 21)
        Me.cbxCliente.TabIndex = 0
        '
        'dgvItemsVenta
        '
        Me.dgvItemsVenta.AllowUserToAddRows = False
        Me.dgvItemsVenta.AllowUserToDeleteRows = False
        Me.dgvItemsVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItemsVenta.Location = New System.Drawing.Point(3, 30)
        Me.dgvItemsVenta.MultiSelect = False
        Me.dgvItemsVenta.Name = "dgvItemsVenta"
        Me.dgvItemsVenta.ReadOnly = True
        Me.dgvItemsVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvItemsVenta.Size = New System.Drawing.Size(570, 316)
        Me.dgvItemsVenta.TabIndex = 3
        '
        'dtpFecha
        '
        Me.dtpFecha.Location = New System.Drawing.Point(588, 105)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(200, 20)
        Me.dtpFecha.TabIndex = 1
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(676, 89)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 5
        Me.lblFecha.Text = "Fecha"
        '
        'btnQuitarProducto
        '
        Me.btnQuitarProducto.Location = New System.Drawing.Point(645, 205)
        Me.btnQuitarProducto.Name = "btnQuitarProducto"
        Me.btnQuitarProducto.Size = New System.Drawing.Size(101, 23)
        Me.btnQuitarProducto.TabIndex = 3
        Me.btnQuitarProducto.Text = "Quitar Producto"
        Me.btnQuitarProducto.UseVisualStyleBackColor = True
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(642, 257)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(13, 13)
        Me.lblTotal.TabIndex = 9
        Me.lblTotal.Text = "0"
        '
        'btnCrearVenta
        '
        Me.btnCrearVenta.Location = New System.Drawing.Point(635, 292)
        Me.btnCrearVenta.Name = "btnCrearVenta"
        Me.btnCrearVenta.Size = New System.Drawing.Size(121, 23)
        Me.btnCrearVenta.TabIndex = 4
        Me.btnCrearVenta.Text = "Crear Venta"
        Me.btnCrearVenta.UseVisualStyleBackColor = True
        '
        'btnAgregarProducto
        '
        Me.btnAgregarProducto.Location = New System.Drawing.Point(645, 152)
        Me.btnAgregarProducto.Name = "btnAgregarProducto"
        Me.btnAgregarProducto.Size = New System.Drawing.Size(101, 23)
        Me.btnAgregarProducto.TabIndex = 2
        Me.btnAgregarProducto.Text = "Añadir Producto"
        Me.btnAgregarProducto.UseVisualStyleBackColor = True
        '
        'lblDetalle
        '
        Me.lblDetalle.AutoSize = True
        Me.lblDetalle.Location = New System.Drawing.Point(238, 9)
        Me.lblDetalle.Name = "lblDetalle"
        Me.lblDetalle.Size = New System.Drawing.Size(85, 13)
        Me.lblDetalle.TabIndex = 12
        Me.lblDetalle.Text = "Detalle de venta"
        '
        'FormVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 347)
        Me.Controls.Add(Me.lblDetalle)
        Me.Controls.Add(Me.btnAgregarProducto)
        Me.Controls.Add(Me.btnCrearVenta)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.btnQuitarProducto)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.dgvItemsVenta)
        Me.Controls.Add(Me.cbxCliente)
        Me.Controls.Add(Me.lblCliente)
        Me.Name = "FormVenta"
        Me.Text = "VentaCRUDForm"
        CType(Me.dgvItemsVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCliente As Label
    Friend WithEvents cbxCliente As ComboBox
    Friend WithEvents dgvItemsVenta As DataGridView
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents lblFecha As Label
    Friend WithEvents btnQuitarProducto As Button
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnCrearVenta As Button
    Friend WithEvents btnAgregarProducto As Button
    Friend WithEvents lblDetalle As Label
End Class
