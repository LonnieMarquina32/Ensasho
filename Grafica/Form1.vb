Imports System.Windows.Forms.DataVisualization.Charting
'Imports System.ComponentModel

Public Class Form1

    Private Sub close_Click(sender As Object, e As EventArgs) Handles close.Click
        Me.Dispose()
    End Sub


    Private Sub Grafica_Load(sender As Object, e As EventArgs) Handles Me.Load
        Grafica1.Visible = True
        Dim Nombre_variable1 As String
        Dim Nombre_variable2 As String
        Nombre_variable1 = InputBox("Ingrese Primer Variable", "registro de variables", "", 100, 0)
        Me.DataGridView1.Columns.Add(Nombre_variable1, Nombre_variable1)
        Nombre_variable2 = InputBox("Ingrese Segunda Variable", "registro de variables", "", 100, 0)
        Me.DataGridView1.Columns.Add(Nombre_variable2, Nombre_variable2)

    End Sub

    Sub RecorreDGV()
        If DataGridView1.Rows.Count = 1 Then
            MessageBox.Show("Ingresa datos en la grilla, porfavor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            'DataGridView1.Sort(DataGridView1.Columns(0), ListSortDirection.Ascending)

            micolecciondatos = New ColeccionDatos

            For FILA = 0 To DataGridView1.Rows.Count - 2
                misdatos = New Datos
                misdatos.dato1 = DataGridView1.Rows(FILA).Cells(0).Value
                misdatos.dato2 = DataGridView1.Rows(FILA).Cells(1).Value
                micolecciondatos.Add(misdatos)
            Next
            NumeroFilas()
            Ordenar()
        End If
    End Sub

    Sub NumeroFilas()
        Me.DataGridView1.RowHeadersWidth = 35
        If DataGridView1.Rows.Count > 0 Then
            For r = 0 To DataGridView1.Rows.Count - 1
                Me.DataGridView1.Rows(r).HeaderCell.Value = CStr(r + 1)
            Next
        End If
        DataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)
    End Sub


    Private Sub Grafica_Click(sender As Object, e As EventArgs) Handles Grafica.Click
        RecorreDGV()

        Grafica1.Series.Clear()
        Grafica1.ChartAreas.Clear()

        Grafica1.Series.Add("Relacion")
        Grafica1.Series.Add("Linea")

        Grafica1.Series("Relacion").ChartType = DataVisualization.Charting.SeriesChartType.Line


        Grafica1.Series("Relacion").ChartType = SeriesChartType.Point
        Grafica1.Series("Linea").ChartType = SeriesChartType.Line


        Grafica1.Series("Relacion").IsValueShownAsLabel = True
        Grafica1.Series("Relacion")("LabelStyle") = "Center"
        Grafica1.Series("Relacion").Palette = ChartColorPalette.SeaGreen

        Grafica1.Series("Relacion").MarkerSize = 30

        Grafica1.Series("Relacion").MarkerStyle = MarkerStyle.Star10

        Grafica1.ChartAreas.Add("Default").Area3DStyle.Enable3D = False
        For i = 0 To micolecciondatos.Count - 1
            Grafica1.Series("Relacion").Points.AddXY(micolecciondatos.item(i).dato1, micolecciondatos.item(i).dato2)
        Next
    End Sub

    Sub Ordenar()
        Dim Temp, Aux As Double
        For i = 0 To micolecciondatos.Count - 2
            For j = 0 To micolecciondatos.Count - 2

                If (DataGridView1.Rows(j).Cells(0).Value > DataGridView1.Rows(j + 1).Cells(0).Value) Then
                    Temp = DataGridView1.Rows(j).Cells(0).Value
                    DataGridView1.Rows(j).Cells(0).Value = DataGridView1.Rows(j + 1).Cells(0).Value
                    DataGridView1.Rows(j + 1).Cells(0).Value = Temp

                    Aux = DataGridView1.Rows(j).Cells(1).Value
                    DataGridView1.Rows(j).Cells(1).Value = DataGridView1.Rows(j + 1).Cells(1).Value
                    DataGridView1.Rows(j + 1).Cells(1).Value = Aux
                End If
            Next
        Next
    End Sub

End Class
