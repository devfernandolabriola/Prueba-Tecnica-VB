<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProducto
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
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtNombreProducto = New System.Windows.Forms.TextBox()
        Me.btnCrearProducto = New System.Windows.Forms.Button()
        Me.txtCategoria = New System.Windows.Forms.TextBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.btncancelarProducto = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(373, 46)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(50, 13)
        Me.lblNombre.TabIndex = 0
        Me.lblNombre.Text = "Producto"
        '
        'txtNombreProducto
        '
        Me.txtNombreProducto.Location = New System.Drawing.Point(267, 62)
        Me.txtNombreProducto.Name = "txtNombreProducto"
        Me.txtNombreProducto.Size = New System.Drawing.Size(259, 20)
        Me.txtNombreProducto.TabIndex = 0
        '
        'btnCrearProducto
        '
        Me.btnCrearProducto.Location = New System.Drawing.Point(292, 212)
        Me.btnCrearProducto.Name = "btnCrearProducto"
        Me.btnCrearProducto.Size = New System.Drawing.Size(75, 23)
        Me.btnCrearProducto.TabIndex = 3
        Me.btnCrearProducto.Text = "Crear"
        Me.btnCrearProducto.UseVisualStyleBackColor = True
        '
        'txtCategoria
        '
        Me.txtCategoria.Location = New System.Drawing.Point(267, 168)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.Size = New System.Drawing.Size(259, 20)
        Me.txtCategoria.TabIndex = 2
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(267, 114)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(259, 20)
        Me.txtPrecio.TabIndex = 1
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.Location = New System.Drawing.Point(371, 152)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(52, 13)
        Me.lblCategoria.TabIndex = 5
        Me.lblCategoria.Text = "Categoria"
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.Location = New System.Drawing.Point(373, 98)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(37, 13)
        Me.lblPrecio.TabIndex = 6
        Me.lblPrecio.Text = "Precio"
        '
        'btncancelarProducto
        '
        Me.btncancelarProducto.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncancelarProducto.Location = New System.Drawing.Point(431, 212)
        Me.btncancelarProducto.Name = "btncancelarProducto"
        Me.btncancelarProducto.Size = New System.Drawing.Size(75, 23)
        Me.btncancelarProducto.TabIndex = 4
        Me.btncancelarProducto.Text = "Cancelar"
        Me.btncancelarProducto.UseVisualStyleBackColor = True
        '
        'FormProducto
        '
        Me.AcceptButton = Me.btnCrearProducto
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btncancelarProducto
        Me.ClientSize = New System.Drawing.Size(800, 287)
        Me.Controls.Add(Me.btncancelarProducto)
        Me.Controls.Add(Me.lblPrecio)
        Me.Controls.Add(Me.lblCategoria)
        Me.Controls.Add(Me.txtPrecio)
        Me.Controls.Add(Me.txtCategoria)
        Me.Controls.Add(Me.btnCrearProducto)
        Me.Controls.Add(Me.txtNombreProducto)
        Me.Controls.Add(Me.lblNombre)
        Me.Name = "FormProducto"
        Me.Text = "ProductoCRUDForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombre As Label
    Friend WithEvents txtNombreProducto As TextBox
    Friend WithEvents btnCrearProducto As Button
    Friend WithEvents txtCategoria As TextBox
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents lblCategoria As Label
    Friend WithEvents lblPrecio As Label
    Friend WithEvents btncancelarProducto As Button
End Class
