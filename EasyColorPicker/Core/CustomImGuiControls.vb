Imports DearImguiSharp

Namespace Core
    Public Class CustomImGuiControls
        Public Shared Function CustomCheckbox(label As String, ByRef value As Boolean, Optional ByVal CheckMark As String = "✔") As Boolean
            DearImguiSharp.ImGui.PushID_Str(label.GetHashCode())

            Dim changed As Boolean = False

            ' Renderizar checkbox personalizado con bordes redondeados
            ImGui.BeginGroup()
            ImGui.PushStyleVarFloat(ImGuiStyleVar.FrameRounding, 5.0F)
            changed = ImGui.Checkbox(label, value)
            ImGui.PopStyleVar(0)
            ImGui.EndGroup()

            ' Cambiar el icono cuando está activado
            If value Then
                Dim checkMarkIcon As ImVec2 = New ImVec2()
                ImGui.CalcTextSize(checkMarkIcon, CheckMark, CheckMark, True, 0)
            End If


            ImGui.PopID()

            Return changed
        End Function
    End Class
End Namespace

