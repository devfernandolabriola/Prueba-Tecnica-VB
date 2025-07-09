<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCliente
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
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.btnCrearCliente = New System.Windows.Forms.Button()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.lblTelefonoCliente = New System.Windows.Forms.Label()
        Me.lblCorreoCliente = New System.Windows.Forms.Label()
        Me.btnCancelarCliente = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(260, 51)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(265, 20)
        Me.txtNombre.TabIndex = 0
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(260, 120)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(265, 20)
        Me.txtTelefono.TabIndex = 1
        '
        'txtCorreo
        '
        Me.txtCorreo.Location = New System.Drawing.Point(260, 188)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(265, 20)
        Me.txtCorreo.TabIndex = 2
        '
        'btnCrearCliente
        '
        Me.btnCrearCliente.Location = New System.Drawing.Point(292, 234)
        Me.btnCrearCliente.Name = "btnCrearCliente"
        Me.btnCrearCliente.Size = New System.Drawing.Size(75, 23)
        Me.btnCrearCliente.TabIndex = 3
        Me.btnCrearCliente.Text = "Crear Cliente"
        Me.btnCrearCliente.UseVisualStyleBackColor = True
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Location = New System.Drawing.Point(371, 35)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(39, 13)
        Me.lblNombreCliente.TabIndex = 4
        Me.lblNombreCliente.Text = "Cliente"
        '
        'lblTelefonoCliente
        '
        Me.lblTelefonoCliente.AutoSize = True
        Me.lblTelefonoCliente.Location = New System.Drawing.Point(371, 104)
        Me.lblTelefonoCliente.Name = "lblTelefonoCliente"
        Me.lblTelefonoCliente.Size = New System.Drawing.Size(49, 13)
        Me.lblTelefonoCliente.TabIndex = 5
        Me.lblTelefonoCliente.Text = "Telefono"
        '
        'lblCorreoCliente
        '
        Me.lblCorreoCliente.AutoSize = True
        Me.lblCorreoCliente.Location = New System.Drawing.Point(371, 172)
        Me.lblCorreoCliente.Name = "lblCorreoCliente"
        Me.lblCorreoCliente.Size = New System.Drawing.Size(38, 13)
        Me.lblCorreoCliente.TabIndex = 6
        Me.lblCorreoCliente.Text = "Correo"
        '
        'btnCancelarCliente
        '
        Me.btnCancelarCliente.Location = New System.Drawing.Point(417, 234)
        Me.btnCancelarCliente.Name = "btnCancelarCliente"
        Me.btnCancelarCliente.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelarCliente.TabIndex = 4
        Me.btnCancelarCliente.Text = "Cancelar"
        Me.btnCancelarCliente.UseVisualStyleBackColor = True
        '
        'FormCliente
        '
        Me.AcceptButton = Me.btnCrearCliente
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelarCliente
        Me.ClientSize = New System.Drawing.Size(800, 311)
        Me.Controls.Add(Me.btnCancelarCliente)
        Me.Controls.Add(Me.lblCorreoCliente)
        Me.Controls.Add(Me.lblTelefonoCliente)
        Me.Controls.Add(Me.lblNombreCliente)
        Me.Controls.Add(Me.btnCrearCliente)
        Me.Controls.Add(Me.txtCorreo)
        Me.Controls.Add(Me.txtTelefono)
        Me.Controls.Add(Me.txtNombre)
        Me.Name = "FormCliente"
        Me.Text = "CRUDForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents btnCrearCliente As Button
    Friend WithEvents lblNombreCliente As Label
    Friend WithEvents lblTelefonoCliente As Label
    Friend WithEvents lblCorreoCliente As Label
    Friend WithEvents btnCancelarCliente As Button
End Class
