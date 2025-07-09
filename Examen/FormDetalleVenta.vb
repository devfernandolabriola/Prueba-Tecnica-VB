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
    End Sub

    Private Sub ExportarDetalle_Click(sender As Object, e As EventArgs) Handles ExportarDetalle.Click
        ExportaraExcel(dgvDetalleVenta)
    End Sub

    Private Sub ExportaraExcel(ByVal dgv As DataGridView)
        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook = xlApp.Workbooks.Add()
        Dim xlWorkSheet As Excel.Worksheet = CType(xlWorkBook.Sheets(1), Excel.Worksheet)
        Dim columnasExcluidas As New List(Of String) From {"ID", "IDVenta", "IDProducto"}

        Try
            Dim colIndex As Integer = 1
            For Each col As DataGridViewColumn In dgv.Columns
                If Not columnasExcluidas.Contains(col.Name) Then
                    xlWorkSheet.Cells(1, colIndex) = col.HeaderText
                    colIndex += 1
                End If
            Next

            ' Escribir datos
            Dim rowIndex As Integer = 2
            For Each row As DataGridViewRow In dgv.Rows
                If row.Visible AndAlso Not row.IsNewRow Then
                    colIndex = 1
                    For Each col As DataGridViewColumn In dgv.Columns
                        If Not columnasExcluidas.Contains(col.Name) Then
                            Dim valor = row.Cells(col.Index).Value
                            If valor IsNot Nothing Then
                                xlWorkSheet.Cells(rowIndex, colIndex) = valor.ToString()
                            End If
                            colIndex += 1
                        End If
                    Next
                    rowIndex += 1
                End If
            Next

            xlApp.Visible = True
        Catch ex As Exception
            MessageBox.Show("Error al exportar: " & ex.Message)
        End Try
    End Sub
End Class