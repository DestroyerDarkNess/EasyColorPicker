Imports System.Management

Namespace Core
    Public Class Helpers

        Public Shared Function GetColorAt(x As Integer, y As Integer) As Color
            Using screen As Bitmap = New Bitmap(1, 1)
                Using g As Graphics = Graphics.FromImage(screen)
                    g.CopyFromScreen(x, y, 0, 0, New Size(1, 1))
                End Using

                Return screen.GetPixel(0, 0)
            End Using
        End Function

        Public Shared Function IsPowerSaverMode() As Boolean
            Try
                Dim searcher As New ManagementObjectSearcher("root\cimv2", "SELECT * FROM Win32_PowerSetting WHERE ElementName='Power Saving Mode'")

                For Each queryObj As ManagementObject In searcher.Get()
                    Dim value As Object = queryObj("SettingIndex")

                    If value IsNot Nothing AndAlso value.ToString() = "1" Then
                        Return True
                    End If
                Next
            Catch ex As Exception
                ' Handle exceptions if any
            End Try

            Return False
        End Function

    End Class
End Namespace

