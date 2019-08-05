Public Class ColeccionDatos
    Inherits System.Collections.CollectionBase

    ''' <summary>
    ''' Adhiere datos a la coleccion Datos
    ''' </summary>
    ''' <param name="misclientes"></param>
    ''' <remarks></remarks>
    Public Sub Add(ByVal misclientes As Datos)
        List.Add(misclientes)
    End Sub

    Public Sub Remove(ByVal index As Integer)
        If index > Count - 1 Or index < 0 Then
            System.Windows.Forms.MessageBox.Show("Index not valid!")
        Else
            List.RemoveAt(index)

        End If
    End Sub

    Public ReadOnly Property item(ByVal index As Integer) As Datos
        Get
            Return CType(List.Item(index), Datos)
        End Get
    End Property

    Public Sub ClearItems()
        List.Clear()
    End Sub
End Class
