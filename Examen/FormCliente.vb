Imports System.Security.Cryptography.X509Certificates
Imports Capa_de_Dominio
Imports Entidades
Imports Negocio

Public Class FormCliente

    Private clienteNegocio As New ClienteNegocio()

    Private ClienteAModificar As EntidadCliente = Nothing
    Public Property ClienteModificado As Boolean = False

    Private TelefonoCambio As Boolean = False
    Private CorreoCambio As Boolean = False
    Public Property ClienteAgregado As Boolean = False

    Private Sub btnCrearCliente_Click(sender As Object, e As EventArgs) Handles btnCrearCliente.Click
        Try
            'Crear
            Dim NuevoCliente As New EntidadCliente With {
                .Cliente = txtNombre.Text.Trim(),
                .Telefono = txtTelefono.Text.Trim(),
                .Correo = txtCorreo.Text.Trim()
            }

            If ClienteAModificar Is Nothing Then
                Dim resultado As Boolean = clienteNegocio.RegistrarCliente(NuevoCliente)
                If resultado Then
                    MessageBox.Show("Cliente creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClienteAgregado = True
                    LimpiarCampos()
                    Me.Close()
                Else
                    MessageBox.Show("No se pudo crear el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                'Modificación
                NuevoCliente.ID = ClienteAModificar.ID
                If NuevoCliente.Correo <> ClienteAModificar.Correo Then
                    CorreoCambio = True
                End If
                If NuevoCliente.Telefono <> ClienteAModificar.Telefono Then
                    TelefonoCambio = True
                End If
                Dim resultado As Boolean = clienteNegocio.ModificarCliente(NuevoCliente, CorreoCambio, TelefonoCambio)
                If resultado Then
                    MessageBox.Show("Cliente modificado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClienteModificado = True
                    Me.Close()
                Else
                    MessageBox.Show("No se pudo modificar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If



        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(clienteExistente As EntidadCliente)

        InitializeComponent()
        ClienteAModificar = clienteExistente
    End Sub

    Private Sub FormCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ClienteAModificar IsNot Nothing Then
            txtNombre.Text = ClienteAModificar.Cliente
            txtTelefono.Text = ClienteAModificar.Telefono
            txtCorreo.Text = ClienteAModificar.Correo
            btnCrearCliente.Text = "Modificar Cliente"
        End If
    End Sub
    Private Sub LimpiarCampos()
        txtNombre.Clear()
        txtTelefono.Clear()
        txtCorreo.Clear()
    End Sub

    Private Sub btnCancelarCliente_Click(sender As Object, e As EventArgs) Handles btnCancelarCliente.Click
        Me.Close()
    End Sub
End Class