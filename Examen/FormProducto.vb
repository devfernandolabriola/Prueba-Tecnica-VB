Imports Capa_de_Dominio
Imports Entidades
Imports Negocio
Public Class FormProducto
    Private productoNegocio As New ProductoNegocio()

    Public Property ProductoAgregado As Boolean = False
    Public Property ProductoModificado As Boolean = False

    Private ProductoAModificar As EntidadProducto

    Public Sub New()
        InitializeComponent()
        Me.Text = "Nuevo Producto"
    End Sub

    Public Sub New(productoExistente As EntidadProducto)
        InitializeComponent()
        Me.Text = "Modificar Producto"
        btnCrearProducto.Text = "Modificar"
        ProductoAModificar = productoExistente

        ' Cargar datos en controles
        txtNombreProducto.Text = productoExistente.Nombre
        txtPrecio.Text = productoExistente.Precio.ToString()
        txtCategoria.Text = productoExistente.Categoria
    End Sub

    Private Sub btnCrearProducto_Click(sender As Object, e As EventArgs) Handles btnCrearProducto.Click
        Try
            ' Validaciones básicas
            If String.IsNullOrWhiteSpace(txtNombreProducto.Text) OrElse
               String.IsNullOrWhiteSpace(txtPrecio.Text) OrElse
               String.IsNullOrWhiteSpace(txtCategoria.Text) Then
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim precioDecimal As Decimal
            If Not Decimal.TryParse(txtPrecio.Text, precioDecimal) Then
                MessageBox.Show("El precio debe ser un número válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim productoNuevo As New EntidadProducto With {
                .Nombre = txtNombreProducto.Text.Trim(),
                .Precio = precioDecimal,
                .Categoria = txtCategoria.Text.Trim()
            }

            If ProductoAModificar Is Nothing Then
                ' Alta
                Dim resultado = productoNegocio.RegistrarProducto(productoNuevo)
                If resultado Then
                    MessageBox.Show("Producto creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ProductoAgregado = True
                    Me.Close()
                Else
                    MessageBox.Show("No se pudo crear el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                ' Modificación
                productoNuevo.ID = ProductoAModificar.ID
                Dim resultado = productoNegocio.ModificarProducto(productoNuevo)
                If resultado Then
                    MessageBox.Show("Producto modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ProductoModificado = True
                    Me.Close()
                Else
                    MessageBox.Show("No se pudo modificar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btncancelarProducto_Click(sender As Object, e As EventArgs) Handles btncancelarProducto.Click
        Me.Close()
    End Sub
End Class