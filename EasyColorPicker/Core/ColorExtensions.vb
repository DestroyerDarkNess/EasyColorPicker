

Imports System.Runtime.CompilerServices
Imports DearImguiSharp

Namespace Core


    Module ColorExtensions

        <Extension()>
        Function ToImVec4(ByVal color As System.Drawing.Color, Optional ByVal WithAlpha As Boolean = True) As DearImguiSharp.ImVec4

            Dim Result As DearImguiSharp.ImVec4 = New DearImguiSharp.ImVec4 With {
                .W = color.A / 255.0F,
                .X = color.R / 255.0F,
                .Y = color.G / 255.0F,
                .Z = color.B / 255.0F
            }

            If WithAlpha = True Then Result.W = 255.0F

            Return Result
        End Function

        <Extension()>
        Function ToImVec4(ByVal color As System.Drawing.Color) As DearImguiSharp.ImVec4
            Return New DearImguiSharp.ImVec4 With {
                .W = color.A / 255.0F,
                .X = color.R / 255.0F,
                .Y = color.G / 255.0F,
                .Z = color.B / 255.0F
            }
        End Function

        <Extension()>
        Function ToColor(ByVal imVec4 As ImVec4) As System.Drawing.Color
            Dim alpha As Byte = CByte((imVec4.W * 255.0F))
            Dim red As Byte = CByte((imVec4.X * 255.0F))
            Dim green As Byte = CByte((imVec4.Y * 255.0F))
            Dim blue As Byte = CByte((imVec4.Z * 255.0F))
            Return System.Drawing.Color.FromArgb(alpha, red, green, blue)
        End Function

    End Module

End Namespace

