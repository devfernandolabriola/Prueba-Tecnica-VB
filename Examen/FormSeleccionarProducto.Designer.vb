<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSeleccionarProducto
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
        Me.dgvProductos = New System.Windows.Forms.DataGridView()
        Me.btnBusquedaProducto = New System.Windows.Forms.Button()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.txtBuscarProducto = New System.Windows.Forms.TextBox()
        Me.btnAgregarProducto = New System.Windows.Forms.Button()
        Me.nudCantidad = New System.Windows.Forms.NumericUpDown()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.btnlimpiarSelProducto = New System.Windows.Forms.Button()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvProductos
        '
        Me.dgvProductos.AllowUserToAddRows = False
        Me.dgvProductos.AllowUserToDeleteRows = False
        Me.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductos.Location = New System.Drawing.Point(5, 7)
        Me.dgvProductos.MultiSelect = False
        Me.dgvProductos.Name = "dgvProductos"
        Me.dgvProductos.ReadOnly = True
        Me.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductos.Size = New System.Drawing.Size(579, 330)
        Me.dgvProductos.TabIndex = 8
        '
        'btnBusquedaProducto
        '
        Me.btnBusquedaProducto.Location = New System.Drawing.Point(609, 120)
        Me.btnBusquedaProducto.Name = "btnBusquedaProducto"
        Me.btnBusquedaProducto.Size = New System.Drawing.Size(75, 23)
        Me.btnBusquedaProducto.TabIndex = 1
        Me.btnBusquedaProducto.Text = "Buscar"
        Me.btnBusquedaProducto.UseVisualStyleBackColor = True
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Location = New System.Drawing.Point(653, 50)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(86, 13)
        Me.lblProducto.TabIndex = 0
        Me.lblProducto.Text = "Buscar Producto"
        '
        'txtBuscarProducto
        '
        Me.txtBuscarProducto.Location = New System.Drawing.Point(609, 77)
        Me.txtBuscarProducto.Name = "txtBuscarProducto"
        Me.txtBuscarProducto.Size = New System.Drawing.Size(179, 20)
        Me.txtBuscarProducto.TabIndex = 0
        '
        'btnAgregarProducto
        '
        Me.btnAgregarProducto.Location = New System.Drawing.Point(625, 258)
        Me.btnAgregarProducto.Name = "btnAgregarProducto"
        Me.btnAgregarProducto.Size = New System.Drawing.Size(145, 23)
        Me.btnAgregarProducto.TabIndex = 4
        Me.btnAgregarProducto.Text = "Añadir Producto"
        Me.btnAgregarProducto.UseVisualStyleBackColor = True
        '
        'nudCantidad
        '
        Me.nudCantidad.Location = New System.Drawing.Point(638, 219)
        Me.nudCantidad.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudCantidad.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudCantidad.Name = "nudCantidad"
        Me.nudCantidad.Size = New System.Drawing.Size(120, 20)
        Me.nudCantidad.TabIndex = 3
        Me.nudCantidad.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Location = New System.Drawing.Point(667, 203)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(49, 13)
        Me.lblCantidad.TabIndex = 0
        Me.lblCantidad.Text = "Cantidad"
        '
        'btnlimpiarSelProducto
        '
        Me.btnlimpiarSelProducto.Location = New System.Drawing.Point(713, 120)
        Me.btnlimpiarSelProducto.Name = "btnlimpiarSelProducto"
        Me.btnlimpiarSelProducto.Size = New System.Drawing.Size(75, 23)
        Me.btnlimpiarSelProducto.TabIndex = 2
        Me.btnlimpiarSelProducto.Text = "Limpiar"
        Me.btnlimpiarSelProducto.UseVisualStyleBackColor = True
        '
        'FormSeleccionarProducto
        '
        Me.AcceptButton = Me.btnBusquedaProducto
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 340)
        Me.Controls.Add(Me.btnlimpiarSelProducto)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.nudCantidad)
        Me.Controls.Add(Me.btnAgregarProducto)
        Me.Controls.Add(Me.txtBuscarProducto)
        Me.Controls.Add(Me.lblProducto)
        Me.Controls.Add(Me.btnBusquedaProducto)
        Me.Controls.Add(Me.dgvProductos)
        Me.Name = "FormSeleccionarProducto"
        Me.Text = "SeleccionarProducto"
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvProductos As DataGridView
    Friend WithEvents btnBusquedaProducto As Button
    Friend WithEvents lblProducto As Label
    Friend WithEvents txtBuscarProducto As TextBox
    Friend WithEvents btnAgregarProducto As Button
    Friend WithEvents nudCantidad As NumericUpDown
    Friend WithEvents lblCantidad As Label
    Friend WithEvents btnlimpiarSelProducto As Button
End Class
