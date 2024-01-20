Namespace Core

    Public Class Config
        Public Property Enabled As Boolean = False
        Public Property ExecuteAction As Action = Nothing

        Private IsApply As Boolean = False

        Public Sub Apply()
            If Enabled = True Then
                If IsApply = False Then
                    IsApply = True
                    ExecuteAction.Invoke()
                End If
            End If
        End Sub
    End Class

End Namespace

