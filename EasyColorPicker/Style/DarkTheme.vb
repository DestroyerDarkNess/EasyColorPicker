Imports DearImguiSharp
Imports EasyColorPicker.Core
Imports RenderSpy.ImGui.Core

Namespace Style

    Public Class DarkTheme
        'https://www.unknowncheats.me/forum/c-and-c-/189635-imgui-style-settings.html

        Public Property Alpha As Integer = 255

        Public Sub ApplyColors()
            Dim Style = DearImguiSharp.ImGui.GetStyle()
            Dim colors = New FinalizedList(Of DearImguiSharp.ImVec4(), DearImguiSharp.ImVec4)(Style.Colors)


            colors.Instance(ImGuiCol.Text) = Color.FromArgb(Alpha, 204, 204, 211).ToImVec4()
            colors.Instance(ImGuiCol.TextDisabled) = Color.FromArgb(Alpha, 61, 59, 74).ToImVec4()
            colors.Instance(ImGuiCol.WindowBg) = Color.FromArgb(Alpha, 15, 13, 18).ToImVec4()
            colors.Instance(ImGuiCol.ChildBg) = Color.FromArgb(Alpha, 18, 18, 23).ToImVec4()
            colors.Instance(ImGuiCol.PopupBg) = Color.FromArgb(Alpha, 18, 18, 23).ToImVec4()
            colors.Instance(ImGuiCol.Border) = Color.FromArgb(Alpha, 204, 204, 211).ToImVec4()
            colors.Instance(ImGuiCol.BorderShadow) = Color.FromArgb(Alpha, 235, 232, 224).ToImVec4()
            colors.Instance(ImGuiCol.FrameBg) = Color.FromArgb(Alpha, 26, 23, 31).ToImVec4()
            colors.Instance(ImGuiCol.FrameBgHovered) = Color.FromArgb(Alpha, 61, 59, 74).ToImVec4()
            colors.Instance(ImGuiCol.FrameBgActive) = Color.FromArgb(Alpha, 143, 143, 148).ToImVec4()
            colors.Instance(ImGuiCol.TitleBg) = Color.FromArgb(Alpha, 26, 23, 31).ToImVec4()
            colors.Instance(ImGuiCol.TitleBgCollapsed) = Color.FromArgb(Alpha, 255, 250, 242).ToImVec4()
            colors.Instance(ImGuiCol.TitleBgActive) = Color.FromArgb(Alpha, 18, 18, 23).ToImVec4()
            colors.Instance(ImGuiCol.MenuBarBg) = Color.FromArgb(Alpha, 26, 23, 31).ToImVec4()
            colors.Instance(ImGuiCol.ScrollbarBg) = Color.FromArgb(Alpha, 26, 23, 31).ToImVec4()
            colors.Instance(ImGuiCol.ScrollbarGrab) = Color.FromArgb(Alpha, 204, 204, 211).ToImVec4()
            colors.Instance(ImGuiCol.ScrollbarGrabHovered) = Color.FromArgb(Alpha, 143, 143, 148).ToImVec4()
            colors.Instance(ImGuiCol.ScrollbarGrabActive) = Color.FromArgb(Alpha, 15, 13, 18).ToImVec4()
            'Dim ComboBg = Color.FromArgb(Alpha,49, 46, 54, 255).ToImVec4()

            colors.Instance(ImGuiCol.CheckMark) = Color.FromArgb(Alpha, 204, 204, 211).ToImVec4()
            colors.Instance(ImGuiCol.SliderGrab) = Color.FromArgb(Alpha, 204, 204, 211).ToImVec4()
            colors.Instance(ImGuiCol.SliderGrabActive) = Color.FromArgb(Alpha, 15, 13, 18).ToImVec4()
            colors.Instance(ImGuiCol.Button) = Color.FromArgb(Alpha, 26, 23, 31).ToImVec4()
            colors.Instance(ImGuiCol.ButtonHovered) = Color.FromArgb(Alpha, 61, 59, 74).ToImVec4()
            colors.Instance(ImGuiCol.ButtonActive) = Color.FromArgb(Alpha, 143, 143, 148).ToImVec4()
            colors.Instance(ImGuiCol.Header) = Color.FromArgb(Alpha, 26, 23, 31).ToImVec4()
            colors.Instance(ImGuiCol.HeaderHovered) = Color.FromArgb(Alpha, 143, 143, 148).ToImVec4()
            colors.Instance(ImGuiCol.HeaderActive) = Color.FromArgb(Alpha, 15, 13, 18).ToImVec4()
            'Dim Column = Color.FromArgb(Alpha,143, 143, 148, 255).ToImVec4()
            'Dim ColumnHovered = Color.FromArgb(Alpha,61, 59, 74, 255).ToImVec4()
            'Dim ColumnActive = Color.FromArgb(Alpha,143, 143, 148, 255).ToImVec4()
            colors.Instance(ImGuiCol.ResizeGrip) = Color.FromArgb(Alpha, 0, 0, 0).ToImVec4()
            colors.Instance(ImGuiCol.ResizeGripHovered) = Color.FromArgb(Alpha, 143, 143, 148).ToImVec4()
            colors.Instance(ImGuiCol.ResizeGripActive) = Color.FromArgb(Alpha, 15, 13, 18).ToImVec4()
            'Dim CloseButton = Color.FromArgb(Alpha,102, 100, 97, 41).ToImVec4()
            'Dim CloseButtonHovered = Color.FromArgb(Alpha,102, 100, 97, 99).ToImVec4()
            'Dim CloseButtonActive = Color.FromArgb(Alpha,102, 100, 97, 255).ToImVec4()
            colors.Instance(ImGuiCol.PlotLines) = Color.FromArgb(Alpha, 102, 100, 97).ToImVec4()
            colors.Instance(ImGuiCol.PlotLinesHovered) = Color.FromArgb(Alpha, 64, 255, 0).ToImVec4()
            colors.Instance(ImGuiCol.PlotHistogram) = Color.FromArgb(Alpha, 102, 100, 97).ToImVec4()
            colors.Instance(ImGuiCol.PlotHistogramHovered) = Color.FromArgb(Alpha, 64, 255, 0).ToImVec4()
            colors.Instance(ImGuiCol.TextSelectedBg) = Color.FromArgb(Alpha, 64, 255, 0).ToImVec4()
            colors.Instance(ImGuiCol.ModalWindowDimBg) = Color.FromArgb(Alpha, 255, 250, 242).ToImVec4()


            Style.Colors = colors
        End Sub



    End Class

End Namespace

