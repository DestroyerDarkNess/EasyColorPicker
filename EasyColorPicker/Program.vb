Imports System.Runtime.InteropServices
Imports DearImguiSharp
Imports EasyColorPicker.Core

NotInheritable Class Program

    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function SetProcessDPIAware() As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True, ExactSpelling:=True)>
    Private Shared Function FreeConsole() As Boolean
    End Function

    <STAThread>
    Friend Shared Sub Main()
        SetProcessDPIAware()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        FreeConsole()

        Dim PowerSaveMode As Boolean = My.Settings.PowerSave
        Dim CursorManager As Core.CursorChanger = New Core.CursorChanger
        Dim Styles As Style.DarkTheme = New Style.DarkTheme With {.Alpha = 130}
        Dim Transparent As Boolean = True

        If PowerSaveMode = False Then
            Styles.Alpha = 130
            Transparent = True
        Else
            Styles.Alpha = 255
            Transparent = False
        End If

        Dim SingleImguiWindow As EasyImGui.ImGuiForm = New EasyImGui.ImGuiForm(Transparent, True) With {.Size = New Size(300, 440), .AutoReset = True}

        If PowerSaveMode = True Then SingleImguiWindow.Height += 20

        Dim MenuConfig As Core.Config = New Core.Config With {.Enabled = True, .ExecuteAction = New Action(Sub()
                                                                                                               SingleImguiWindow.Icon = My.Resources.AppIcon
                                                                                                               SingleImguiWindow.Text = "Easy ColorPicker"
                                                                                                               Styles.ApplyColors()

                                                                                                               If PowerSaveMode Then
                                                                                                                   SingleImguiWindow.BackColor = Color.Gray
                                                                                                                   SingleImguiWindow.ClearColor = SharpDX.Color.Gray
                                                                                                                   SingleImguiWindow.ImGuiWindowFlagsEx = ImGuiWindowFlags.NoTitleBar
                                                                                                                   SingleImguiWindow.MaximizeBox = False
                                                                                                               Else
                                                                                                                   Dim Theme = New Themer.ThemerApplier(SingleImguiWindow.Handle)
                                                                                                                   Theme.Apply(Themer.Themes.Acrylic)
                                                                                                               End If
                                                                                                               SingleImguiWindow.Focus()
                                                                                                           End Sub)}





        Dim CurrentColor As Color = Color.DodgerBlue
        Dim OutAlpha As Single

        Dim captureColor As Boolean = False
        AddHandler SingleImguiWindow.Render, Function()
                                                 'Menu Config
                                                 MenuConfig.Apply()

                                                 'Check Key Is Enabled
                                                 captureColor = ImGui.IsKeyDown(Keys.LControlKey)

                                                 'Change MouseCursor
                                                 'If captureColor Then
                                                 '    If IO.File.Exists("cursor.ico") = False Then
                                                 '        Using IconStream As New IO.StreamWriter("cursor.ico")
                                                 '            My.Resources.cursor.Save(IconStream.BaseStream)
                                                 '        End Using
                                                 '    End If
                                                 '    CursorManager.SetCustomCursor("cursor.ico")
                                                 'Else
                                                 '    CursorManager.RestoreDefaultCursor()
                                                 'End If


                                                 If SystemInformation.PowerStatus.BatteryChargeStatus = BatteryChargeStatus.Low Then
                                                     Dim percent As Single = SystemInformation.PowerStatus.BatteryLifePercent
                                                     If PowerSaveMode = False AndAlso percent < 20 Then
                                                         My.Settings.PowerSave = True
                                                         My.Settings.Save()
                                                         Process.Start(Application.ExecutablePath)
                                                         Environment.Exit(0)
                                                     End If
                                                 End If

                                                 'Show Capture Status
                                                 Core.CustomImGuiControls.CustomCheckbox("Is Capturing Color", captureColor)


                                                 'RGB Colors
                                                 'Dim Style = DearImguiSharp.ImGui.GetStyle()
                                                 'Dim TextColor As DearImguiSharp.ImVec4 = Style.Colors(DearImguiSharp.ImGuiCol.Text)
                                                 'TextColor.X = color_red : TextColor.Y = color_green : TextColor.Z = color_blue

                                                 If captureColor = True Then
                                                     Dim cursorPosition As Point = Cursor.Position
                                                     CurrentColor = Core.Helpers.GetColorAt(cursorPosition.X, cursorPosition.Y)
                                                 End If

                                                 Using ColorImVec4 As ImVec4 = CurrentColor.ToImVec4(False)
                                                     Dim SingleColors() As Single = {ColorImVec4.X, ColorImVec4.Y, ColorImVec4.Z}

                                                     ImGui.ColorPicker3("Color Picker", SingleColors, ImGuiColorEditFlags.DisplayRGB Or ImGuiColorEditFlags.DisplayHSV Or ImGuiColorEditFlags.DisplayHex Or ImGuiColorEditFlags.DisplayMask)

                                                     Using NewColorImVec4 As ImVec4 = New ImVec4() With {.X = SingleColors(0), .Y = SingleColors(1), .Z = SingleColors(2), .W = 1.0F}
                                                         CurrentColor = NewColorImVec4.ToColor
                                                     End Using
                                                 End Using



                                                 Dim windowPadding = DearImguiSharp.ImGui.GetStyle().WindowPadding

                                                 'If DearImguiSharp.ImGui.Button("OpenFileDialog Test", New DearImguiSharp.ImVec2() With {
                                                 '                                               .X = SingleImguiWindow.Size.Width - 15,
                                                 '                                               .Y = 20
                                                 '                                           }) Then

                                                 '    'Dim TaskAsync As Task(Of Object) = Core.AsyncAction.Call(Sub()
                                                 '    '                                                             Dim OpenFileDialog As New OpenFileDialog
                                                 '    '                                                             If OpenFileDialog.ShowDialog = DialogResult.OK Then
                                                 '    '                                                                 FileEx = OpenFileDialog.FileName
                                                 '    '                                                                 Console.WriteLine("File: " & FileEx)
                                                 '    '                                                             End If
                                                 '    '                                                             OpenFileDialog.Dispose()
                                                 '    '                                                         End Sub)
                                                 'End If

                                                 ImGui.Spacing()

                                                 If Core.CustomImGuiControls.CustomCheckbox("PowerSaveMode", PowerSaveMode) Then
                                                     'PowerSaveMode = Not PowerSaveMode
                                                     My.Settings.PowerSave = PowerSaveMode
                                                     My.Settings.Save()
                                                     Dim TaskAsync As Task(Of Object) = Core.AsyncAction.Call(Sub()
                                                                                                                  If MessageBox.Show("Some changes require restarting the application.", "Enter To Power Save Mode?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                                                                                                                      Process.Start(Application.ExecutablePath)
                                                                                                                      Environment.Exit(0)
                                                                                                                  End If
                                                                                                              End Sub)
                                                 End If

                                                 If DearImguiSharp.ImGui.Button("Close App", New DearImguiSharp.ImVec2() With {
                                                                                                .X = SingleImguiWindow.ClientSize.Width - 15,
                                                                                                .Y = 20
                                                                                            }) Then Environment.Exit(0) 'SingleImguiWindow.Visible = False

                                                 ImGui.Spacing()
                                                 ImGui.Spacing()
                                                 ImGui.Spacing()
                                                 ImGui.Separator()
                                                 ImGui.Spacing() : ImGui.Spacing() : ImGui.Spacing()
                                                 DearImguiSharp.ImGui.Text("Tip: Right Click for more features.")
                                                 ImGui.Spacing()
                                                 DearImguiSharp.ImGui.Text("Power By Destroyer")
                                                 DearImguiSharp.ImGui.Text("https://github.com/DestroyerDarkNess")

                                                 'Disabled Drag ON Others ImGui Windows or ImGui controls
                                                 Dim IsFocusOnMainImguiWindow = DearImguiSharp.ImGui.IsWindowFocused(DearImguiSharp.ImGuiFocusedFlags.RootWindow)
                                                 If DearImguiSharp.ImGui.IsAnyItemHovered() = True Then
                                                     SingleImguiWindow.EnableDrag = False
                                                 Else
                                                     SingleImguiWindow.EnableDrag = IsFocusOnMainImguiWindow
                                                 End If




                                                 Return True
                                             End Function
        Try
            Application.Run(SingleImguiWindow)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try

        Environment.Exit(0)
    End Sub

    Private Shared color_red As Single = 1.0F
    Private Shared color_green As Single = 0F
    Private Shared color_blue As Single = 1.0F

    Public Shared Sub ColorChange()
        Dim Color(3) As Single
        Dim Tickcount As UInteger = 0

        DearImguiSharp.ImGui.ColorConvertRGBtoHSV(color_red, color_green, color_blue, Color(0), Color(1), Color(2))

        If Environment.TickCount - Tickcount > 0 Then
            Color(0) += 0.002F
            Tickcount = CUInt(Environment.TickCount)
        End If

        If Color(0) < 0.0F Then Color(0) += 1.0F

        DearImguiSharp.ImGui.ColorConvertHSVtoRGB(Color(0), Color(1), Color(2), color_red, color_green, color_blue)
    End Sub

End Class