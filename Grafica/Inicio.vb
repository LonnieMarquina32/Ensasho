Module Inicio
    Public micolecciondatos As ColeccionDatos
    Public misdatos As Datos

    Public Sub main()
        micolecciondatos = New ColeccionDatos

        Try
            Application.Run(New Form1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Module
