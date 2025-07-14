<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDetalleVenta
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
        Me.dgvDetalleVenta = New System.Windows.Forms.DataGridView()
        Me.lblPrecioFinal = New System.Windows.Forms.Label()
        CType(Me.dgvDetalleVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDetalleVenta
        '
        Me.dgvDetalleVenta.AllowUserToAddRows = False
        Me.dgvDetalleVenta.AllowUserToDeleteRows = False
        Me.dgvDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleVenta.Location = New System.Drawing.Point(6, 12)
        Me.dgvDetalleVenta.MultiSelect = False
        Me.dgvDetalleVenta.Name = "dgvDetalleVenta"
        Me.dgvDetalleVenta.ReadOnly = True
        Me.dgvDetalleVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalleVenta.Size = New System.Drawing.Size(513, 296)
        Me.dgvDetalleVenta.TabIndex = 0
        '
        'lblPrecioFinal
        '
        Me.lblPrecioFinal.AutoSize = True
        Me.lblPrecioFinal.Location = New System.Drawing.Point(525, 169)
        Me.lblPrecioFinal.Name = "lblPrecioFinal"
        Me.lblPrecioFinal.Size = New System.Drawing.Size(39, 13)
        Me.lblPrecioFinal.TabIndex = 1
        Me.lblPrecioFinal.Text = "Label1"
        '
        'FormDetalleVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 313)
        Me.Controls.Add(Me.lblPrecioFinal)
        Me.Controls.Add(Me.dgvDetalleVenta)
        Me.Name = "FormDetalleVenta"
        Me.Text = "FormDetalleVenta"
        CType(Me.dgvDetalleVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvDetalleVenta As DataGridView
    Friend WithEvents lblPrecioFinal As Label
End Class
