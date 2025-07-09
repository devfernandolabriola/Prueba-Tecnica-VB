Imports System.Text.RegularExpressions
Imports Data
Imports Entidades
Public Class ClienteNegocio
    Private clienteDAL As New ClienteDAL

    Private EsModificado As Boolean = False

    Private CambioCorreo = False

    Private CambioTelefono = False
    Public Function ValidarCliente(cliente As EntidadCliente) As List(Of String)
        Dim errores As New List(Of String)

        'Validación de Cliente
        If String.IsNullOrWhiteSpace(cliente.Cliente) Then
            errores.Add("El nombre del cliente es obligatorio")
        End If
        'Validación de Telefono
        If String.IsNullOrWhiteSpace(cliente.Telefono) Then
            errores.Add("El numero de telefono es obligatorio")
        ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(cliente.Telefono, "^\+?\d+$") Then
            errores.Add("El telefono solo debe contener numeros")
        End If
        'Validación de Correo
        If String.IsNullOrWhiteSpace(cliente.Correo) Then
            errores.Add("El correo electronico es obligatorio")
        Else
            Dim pattern As String = "^[^@\s]+@[^@\s]+\.[^@\s]+$"
            If Not Regex.IsMatch(cliente.Correo, pattern) Then
                errores.Add("El formato del correo electrónico no es válido.")
            End If

        End If

        'Validacion para evitar correo o telefono duplicados
        If EsModificado = False Then
            If clienteDAL.CorreoTelefonoExistente(cliente.Correo.ToLower(), cliente.Telefono) Then
                errores.Add("El correo o el telefono ya existen en la base da datos")
            End If
        ElseIf CambioTelefono = True Then
            If clienteDAL.TelefonoExistente(cliente.Telefono) Then
                errores.Add("El Telefono ya existe")
            End If
        ElseIf CambioCorreo = True Then
            If clienteDAL.CorreoExistente(cliente.Correo) Then
                errores.Add("El correo ya existe")
            End If

        End If


        Return errores
    End Function
    Public Function RegistrarCliente(Cliente As EntidadCliente) As Boolean
        Dim errores = ValidarCliente(Cliente)
        If errores.Count > 0 Then
            Throw New Exception(String.Join(Environment.NewLine, errores))
        End If

        Return clienteDAL.CrearCliente(Cliente)
    End Function

    Public Function ListarClientes() As List(Of EntidadCliente)
        Return clienteDAL.ObtenerClientes()
    End Function

    Public Function ModificarCliente(cliente As EntidadCliente, correocambio As Boolean, telefonocambio As Boolean) As Boolean
        EsModificado = True
        If correocambio = True Then
            CambioCorreo = True
        End If
        If telefonocambio = True Then
            CambioTelefono = True
        End If
        Dim errores = ValidarCliente(cliente)

        If errores.Count > 0 Then
            Throw New Exception(String.Join(Environment.NewLine, errores))
        End If

        Return clienteDAL.ModificarCliente(cliente)
    End Function

    Public Function EliminarCliente(Id As Integer) As Boolean
        Return clienteDAL.EliminarCliente(Id)
    End Function

    Public Function BuscarNombreClientePorID(IdCliente As Integer) As String
        If IdCliente > 0 Then
            Return clienteDAL.BuscarNombreClientePorID(IdCliente)
        End If
    End Function

End Class
