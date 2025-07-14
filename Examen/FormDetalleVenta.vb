Imports Entidades
Imports Microsoft.Office.Interop
Imports System.ComponentModel

Public Class FormDetalleVenta
    Private _venta As EntidadVenta

    Public Sub New(venta As EntidadVenta)
        InitializeComponent()
        _venta = venta
    End Sub

    Private Sub FormDetalleVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dgvDetalleVenta.DataSource = Nothing
        dgvDetalleVenta.DataSource = New BindingList(Of EntidadVentaItem)(_venta.Detalle)

        dgvDetalleVenta.Columns("ID").Visible = False
        dgvDetalleVenta.Columns("IDVenta").Visible = False
        dgvDetalleVenta.Columns("IDProducto").Visible = False
        dgvDetalleVenta.Columns("PrecioUnitario").DefaultCellStyle.Format = "C2"
        dgvDetalleVenta.Columns("PrecioTotal").DefaultCellStyle.Format = "C2"
    End Sub


End Class