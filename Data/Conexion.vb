Imports System.Configuration
Imports System.Data.SqlClient
Public Class Conexion
    Private ReadOnly cadenaConexion As String
    Public Sub New()
        cadenaConexion = ConfigurationManager.ConnectionStrings("ConexionDB").ConnectionString
    End Sub

    Public Function AbrirConexion() As SqlConnection
        Dim con As New SqlConnection(cadenaConexion)
        con.Open()
        Return con
    End Function

    Public Function CerrarConexion()
        Dim con As New SqlConnection(cadenaConexion)
        con.Close()
        Return con
    End Function




End Class
