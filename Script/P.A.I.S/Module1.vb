''PAIS 
''copyright © Fabian Müller 2017-2018 (Paitorocxon)
''Act like it's a baby! ...it needs your protection! :'D
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Text
Imports System.IO
Imports System.IO.Compression
Imports System.IO.Compression.GZipStream



Module Module1
    Public Versionscode As String = "O- v1.1.5"
    Public Dir As String = Nothing
    Public procout As String = Nothing
    Public procerror As String = Nothing
    Public ForVar As String = Nothing
    Public VariableNames(3200) As String
    Public Vars(3200) As String

    Public Ret As String = 0

    Public IsBinary As Boolean = False


    Public Binfile As String = ""

    Public forcounts As Integer = 0
    Public MainFile As String = Nothing
    Public DefForeColor As ConsoleColor
    Public DefBackColor As ConsoleColor
    Public ImportedServer As Boolean = False
    Public ErrorsOn As Boolean = True
    Public Index0 As Integer = 0
    Public File() As String
    Public ImportedWindow As Boolean = False
    Public DefaultEncoding As Encoding
    Public OldIndex As Integer = 0
    Public OldMainFile As String



    Public Function _StringToBinary(ByVal Text As String, Optional ByVal Separator As String = " ") As String
        Dim oReturn As New System.Text.StringBuilder
        For Each Character As Byte In System.Text.ASCIIEncoding.ASCII.GetBytes(Text)
            oReturn.Append(Convert.ToString(Character, 2).PadLeft(8, "0"))
            oReturn.Append(Separator)
        Next
        Return oReturn.ToString
    End Function


    Public Function _BinaryToString(ByVal Binary As String) As String
        Dim Characters As String = System.Text.RegularExpressions.Regex.Replace(Binary, "[^01]", "")
        Dim ByteArray((Characters.Length / 8) - 1) As Byte
        For Index As Integer = 0 To ByteArray.Length - 1
            ByteArray(Index) = Convert.ToByte(Characters.Substring(Index * 8, 8), 2)
        Next
        Return System.Text.ASCIIEncoding.ASCII.GetString(ByteArray)
    End Function



    Public Function StringToBinary(ByVal Text As String, Optional ByVal Separator As String = " ") As String
        Return Text
    End Function


    Public Function BinaryToString(ByVal Binary As String) As String
        Return Binary
    End Function




    Sub Main()

        Dir = My.Application.Info.DirectoryPath
        VariableNames(0) = "nul"
        Vars(0) = "nul"
        VariableNames(0) = "nul"
        DefForeColor = Console.ForegroundColor

        DefBackColor = Console.BackgroundColor
        DefaultEncoding = Console.OutputEncoding


        Console.Title = "PAIS " & Versionscode
        Try
            If My.Computer.FileSystem.FileExists(My.Application.CommandLineArgs(0)) Then
                MainFile = My.Application.CommandLineArgs(0)
                IsBinary = True
            Else
                directinput()
            End If
        Catch ex As Exception
            directinput()
        End Try
        Try
            My.Computer.Registry.ClassesRoot.CreateSubKey(".pais").SetValue("", "pais", Microsoft.Win32.RegistryValueKind.String)
            My.Computer.Registry.ClassesRoot.CreateSubKey("pais\shell\open\command").SetValue("", """" & PAIS.My.Application.Info.DirectoryPath & "\pais.exe" & """" & """%1"" ", Microsoft.Win32.RegistryValueKind.String)
            My.Computer.Registry.ClassesRoot.CreateSubKey("pais\DefaultIcon").SetValue("", PAIS.My.Application.Info.DirectoryPath & "\favicon.ico,0", Microsoft.Win32.RegistryValueKind.String)
            Runtime()
            End
        Catch ausnahme As Exception
            Runtime()
            End
        End Try
        IsBinary = False
        directinput()
    End Sub




    Public Function Replac(ByVal sa As String) As String

     

        Dim NetInface As NetworkInformation.NetworkInterface() = NetworkInformation.NetworkInterface.GetAllNetworkInterfaces
        Dim WriteIndex As Integer = 0
        sa = sa.Replace("%simpletime", My.Computer.Clock.LocalTime.Hour & ":" & My.Computer.Clock.LocalTime.Minute)
        sa = sa.Replace("%ramav", My.Computer.Info.AvailableVirtualMemory)
        sa = sa.Replace("%ramap", My.Computer.Info.AvailablePhysicalMemory)
        sa = sa.Replace("%ramtv", My.Computer.Info.TotalPhysicalMemory)
        sa = sa.Replace("%ramtp", My.Computer.Info.TotalVirtualMemory)
        sa = sa.Replace("%network", My.Computer.Network.IsAvailable.ToString)
        sa = sa.Replace("%os", My.Computer.Info.OSFullName)
        sa = sa.Replace("%break", vbCrLf)
        sa = sa.Replace("%version", Versionscode)
        sa = sa.Replace("%path", My.Application.Info.DirectoryPath)
        sa = sa.Replace("%fors", forcounts)
        sa = sa.Replace("%for", ForVar)
        sa = sa.Replace("%procout", procout)
        sa = sa.Replace("%procerror", procout)
        sa = sa.Replace("%dir", Dir)

        sa = sa.Replace("%date.y", My.Computer.Clock.LocalTime.Year)
        sa = sa.Replace("%date.m", My.Computer.Clock.LocalTime.Month)
        sa = sa.Replace("%date.d", My.Computer.Clock.LocalTime.Day)
        sa = sa.Replace("%time.ticks", My.Computer.Clock.LocalTime.Ticks)
        sa = sa.Replace("%time.h", My.Computer.Clock.LocalTime.Hour)
        sa = sa.Replace("%time.m", My.Computer.Clock.LocalTime.Minute)
        sa = sa.Replace("%time.s", My.Computer.Clock.LocalTime.Second)
        sa = sa.Replace("%time.t", My.Computer.Clock.LocalTime.Millisecond)


        sa = sa.Replace("%time", My.Computer.Clock.LocalTime)
        sa = sa.Replace("%date", My.Computer.Clock.LocalTime.Date)

        Try
            sa = sa.Replace("%arg0", My.Application.CommandLineArgs(0))
            sa = sa.Replace("%arg1", My.Application.CommandLineArgs(1))
            sa = sa.Replace("%arg2", My.Application.CommandLineArgs(2))
            sa = sa.Replace("%arg3", My.Application.CommandLineArgs(3))
        Catch ex As Exception

        End Try





        For Each Variable In VariableNames
            If Variable = Nothing Then
                Exit For
            Else
                sa = sa.Replace("%" & Variable, Vars(WriteIndex))
                WriteIndex += 1
            End If
        Next



       

        Return sa
    End Function

    Public Function Float(ByVal Text As String, ByVal Speed As Integer) As String
        Dim Index As Integer = 0
        If Speed < 0 Then
            Speed = 1
        End If
floater:
        If Index = Text.Length Then
            Return Text
            Exit Function
        Else
            Console.Write(Text(Index))
            Threading.Thread.Sleep(Speed)
        End If
        Index += 1
        GoTo floater
        Return Text
    End Function
    Public Function Runtime()
Resetpoint:

        Try
            If My.Computer.FileSystem.FileExists(MainFile) Then
                File = IO.File.ReadAllLines(MainFile)
                AllFunctions(File(Index0))
                Index0 += 1
            Else
                End
            End If

        Catch ausnahme As Exception
            Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
            Exit Function

        End Try

        GoTo Resetpoint
        Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
    End Function

    Public Function SubRuntime()
Resetpoint:
        Try
            If My.Computer.FileSystem.FileExists(MainFile) Then
                File = IO.File.ReadAllLines(MainFile)
                AllFunctions(File(Index0))
                Index0 += 1
            Else
                End
            End If
        Catch ausnahme As Exception
            Index0 = OldIndex
            MainFile = OldMainFile
            Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
            Exit Function
        End Try
        GoTo Resetpoint
        Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
    End Function

    Function directinput()
DirectInput:
        Console.ForegroundColor = DefForeColor
        Console.BackgroundColor = DefBackColor
        Console.Write(">")

        AllFunctions(Console.ReadLine)
        GoTo DirectInput

        Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
    End Function
    Public Function AllFunctions(ByVal Scriptline As String)
        If IsBinary = True Then
            Scriptline = BinaryToString(Scriptline)
        End If
        Dim i As Integer = 0
        For Each Scriptlinepart In Scriptline
            If Scriptlinepart = " " Then
                i += 1
            ElseIf Scriptlinepart = vbTab Then
                i += 1
            Else
                Scriptline = Scriptline.Substring(i)
                Exit For
            End If

        Next

        Scriptline = Replac(Scriptline)

        If Scriptline.ToLower = "pause" Then
            Console.ForegroundColor = Console.BackgroundColor
            Console.ReadKey()
            Console.Write(vbCrLf)
            Console.ForegroundColor = DefForeColor
            Console.BackgroundColor = DefBackColor
        ElseIf Scriptline.ToLower.StartsWith("compile ") Then
            If My.Computer.FileSystem.FileExists(Scriptline.Substring(8)) Then
                Try
                    Dim CompilingLines() As String = IO.File.ReadAllLines(Scriptline.Substring(8))
                    Dim Compiled As String = "00100011 01010000 01000001 01001001 01010011 "
                    For Each CompilingLine In CompilingLines
                        Compiled = Compiled & vbCrLf & StringToBinary(CompilingLine)
                    Next
                    IO.File.WriteAllText(Scriptline.Substring(8), Compiled)
                Catch ex As Exception
                    ErrorHandle("Error while compiling")
                End Try
            End If
        ElseIf Scriptline.ToLower.StartsWith("decompile ") Then
            If My.Computer.FileSystem.FileExists(Scriptline.Substring(10)) Then
                Try
                    Dim CompilingLines() As String = IO.File.ReadAllLines(Scriptline.Substring(10))
                    Dim Compiled As String = ""
                    For Each CompilingLine In CompilingLines
                        Compiled = Compiled & vbCrLf & BinaryToString(CompilingLine)
                    Next
                    IO.File.WriteAllText(Scriptline.Substring(10), Compiled)
                Catch ex As Exception
                    ErrorHandle("Error while decompiling!")
                End Try
            End If
        ElseIf Scriptline.ToLower = "" Then
            Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
            Exit Function
        ElseIf Scriptline.ToLower = "vars" Then
            Variables()
        ElseIf Scriptline.ToLower = "error:on" Then
            ErrorsOn = True
        ElseIf Scriptline.ToLower = "error:off" Then
            ErrorsOn = False
        ElseIf Scriptline.ToLower = "exit" Then
            End
        ElseIf Scriptline.ToLower = "help" Then
            help()
        ElseIf Scriptline.ToLower.StartsWith("float ") Then
            Float(Replac(Scriptline.Substring(6)), 10)
        ElseIf Scriptline.ToLower.StartsWith("compile:") Then
            Dim Bintemp As String = IO.File.ReadAllText(Scriptline.Substring(8))
            Try
                IO.File.WriteAllText("compiled.pais", StringToBinary(Bintemp))
            Catch ex As Exception
                ErrorHandle("Error while compiling! Check what you've typed! --" & Scriptline.Substring(8) & "--" & vbCrLf & ex.ToString)
            End Try
        ElseIf Scriptline.ToLower = "clear" Then
            Console.Clear()
        ElseIf Scriptline.ToLower.StartsWith("title=") Then
            Console.Title = Replac(Scriptline.Substring(6))
        ElseIf Scriptline.ToLower.StartsWith("dialog ") Then
            MsgBox(Replac(Scriptline.Substring(7)))
        ElseIf Scriptline.ToLower.StartsWith("encoding:") Then
            If Scriptline.ToLower.Substring(9) = "unicode" Then
                Console.OutputEncoding = System.Text.Encoding.Unicode
            ElseIf Scriptline.ToLower.Substring(9) = "utf7" Then
                Console.OutputEncoding = System.Text.Encoding.UTF7
            ElseIf Scriptline.ToLower.Substring(9) = "utf8" Then
                Console.OutputEncoding = System.Text.Encoding.UTF8
            ElseIf Scriptline.ToLower.Substring(9) = "default" Then
                Console.OutputEncoding = System.Text.Encoding.Default
            ElseIf Scriptline.ToLower.Substring(9) = "big" Then
                Console.OutputEncoding = System.Text.Encoding.BigEndianUnicode
            ElseIf Scriptline.ToLower.Substring(9) = "ascii" Then
                Console.OutputEncoding = System.Text.Encoding.ASCII
            ElseIf Scriptline.ToLower.Substring(9) = "standard" Then
                Console.OutputEncoding = DefaultEncoding
            End If
        ElseIf Scriptline.ToLower.StartsWith("play ") Then
            If My.Computer.FileSystem.FileExists(Scriptline.Substring(5)) Then
                My.Computer.Audio.Play(Scriptline.Substring(5), AudioPlayMode.WaitToComplete)
            Else
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("File not found! (" & Scriptline.Substring(5) & ")")
                Console.ForegroundColor = DefForeColor
                Console.BackgroundColor = DefBackColor
            End If



        ElseIf Scriptline.ToLower.StartsWith("c:off") Then
            Console.TreatControlCAsInput = True

        ElseIf Scriptline.ToLower.StartsWith("c:on") Then
            Console.TreatControlCAsInput = False

        ElseIf Scriptline.ToLower.StartsWith("goto ") Then
            Dim TempIndex As Integer = 0
            Try

                If IsNumeric(Scriptline.ToLower.Substring(5)) Then

                    Index0 = Scriptline.ToLower.Substring(5)

                Else

                    For Each ScriptContent As String In File
                        If Replac(ScriptContent.ToLower) = "[" & Scriptline.ToLower.Substring(5) & "]" Then
                            Index0 = TempIndex
                            Exit For
                        Else
                            TempIndex += 1
                        End If
                    Next

                End If
            Catch ausnahme As Exception
                ErrorHandle("Error! " & vbCrLf & ausnahme.Message)
            End Try

        ElseIf Scriptline.ToLower.StartsWith("#") Then
        ElseIf Scriptline.ToLower.StartsWith("!") Then
        ElseIf Scriptline.ToLower.StartsWith(":") Then
        ElseIf Scriptline.ToLower.StartsWith("'") Then
        ElseIf Scriptline.ToLower.StartsWith("rem") Then
        ElseIf Scriptline.ToLower.StartsWith("com") Then
        ElseIf Scriptline.ToLower.StartsWith("//") Then

        ElseIf Scriptline.ToLower.StartsWith("cd ") Then

            If My.Computer.FileSystem.DirectoryExists(Scriptline.Substring(3)) Then
                If Scriptline.Substring(3) = ".." Then
                    Dir = UpperFolder(Dir, 1)
                Else
                    Dir = Scriptline.Substring(3)
                End If
            Else
                ErrorHandle("Directory does'nt exists!")

            End If

            Return Dir
            Exit Function
        ElseIf Scriptline.ToLower.StartsWith("dir") Then
            If Scriptline.Length > 3 Then
                Dim DirectoryInformation As New DirectoryInfo(Scriptline.Substring(4))
                Dim FileArray As FileInfo() = DirectoryInformation.GetFiles
                Dim DirectoryArray As DirectoryInfo() = DirectoryInformation.GetDirectories
                Dim FileF As FileInfo
                Dim FileD As DirectoryInfo

                For Each FileD In DirectoryArray
                    Console.Write(FileD)
                    Console.WriteLine("/")
                Next
                For Each FileF In FileArray
                    Console.WriteLine(FileF)
                Next

            Else
                Dim DirectoryInformation As New DirectoryInfo(Dir)
                Dim FileArray As FileInfo() = DirectoryInformation.GetFiles
                Dim DirectoryArray As DirectoryInfo() = DirectoryInformation.GetDirectories
                Dim FileF As FileInfo
                Dim FileD As DirectoryInfo

                For Each FileD In DirectoryArray
                    Console.Write(FileD)
                    Console.WriteLine("/")
                Next
                For Each FileF In FileArray
                    Console.WriteLine(FileF)
                Next
            End If




        ElseIf Scriptline.ToLower.StartsWith("rainbow ") Then
            Rainbow(Replac(Scriptline.Substring(8)))

        ElseIf Scriptline.ToLower.StartsWith("test") Then



        ElseIf Scriptline.ToLower.StartsWith("$") Then


            Dim ScIndex As Integer = 1
            Dim VariableName As String = Nothing
            Dim Method As String = ""
redo:
            Try
                If Scriptline(ScIndex) = "=" Then
                    Method = "="
                    ScIndex += 1
                    GoTo NextOne
                ElseIf Scriptline(ScIndex) = "<" Then
                    Method = "<"
                    ScIndex += 1
                    GoTo NextOne
                ElseIf Scriptline(ScIndex) = ":" Then
                    Method = ":"
                    ScIndex += 1
                    GoTo NextOne
                ElseIf Scriptline(ScIndex) = "+" Then
                    Method = "+"
                    ScIndex += 1
                    GoTo NextOne
                ElseIf Scriptline(ScIndex) = "-" Then
                    Method = "-"
                    ScIndex += 1
                    GoTo NextOne
                ElseIf Scriptline(ScIndex) = "*" Then
                    Method = "*"
                    ScIndex += 1
                    GoTo NextOne
                ElseIf Scriptline(ScIndex) = "/" Then
                    Method = "/"
                    ScIndex += 1
                    GoTo NextOne
                ElseIf Scriptline(ScIndex) = "|" Then
                    Method = "key"
                    ScIndex += 1
                ElseIf Scriptline(ScIndex) = "S" Then
                    Method = "S"
                    ScIndex += 1
                    GoTo NextOne
                ElseIf Scriptline(ScIndex) = "B" Then
                    Method = "B"
                    ScIndex += 1
                    GoTo NextOne

                ElseIf ScIndex = Scriptline.Length Then
                    ScIndex += 1
                    GoTo NextOne
                Else
                    VariableName = VariableName & Scriptline(ScIndex)
                    ScIndex += 1
                End If
                GoTo redo
            Catch ex As Exception
                ErrorHandle("Error while initializing variable!")
            End Try
NextOne:
            Dim VariableIndex As Integer = 0
            Try
                For Each Variable In VariableNames
                    If Variable = VariableName Then
                        If Method = "=" Then
                            VariableNames(VariableIndex) = VariableName
                            Vars(VariableIndex) = Tipper(Scriptline.Substring(ScIndex))
                        ElseIf Method = "/" Then
                            VariableNames(VariableIndex) = VariableName
                            Vars(VariableIndex) = Convert.ToInt32(Vars(VariableIndex)) / Convert.ToInt32((Replac(Scriptline.Substring(ScIndex))))
                        ElseIf Method = "*" Then
                            VariableNames(VariableIndex) = VariableName
                            Vars(VariableIndex) = Convert.ToInt32(Vars(VariableIndex)) * Convert.ToInt32((Replac(Scriptline.Substring(ScIndex))))
                        ElseIf Method = "+" Then
                            VariableNames(VariableIndex) = VariableName
                            Vars(VariableIndex) = Convert.ToInt32(Vars(VariableIndex)) + Convert.ToInt32((Replac(Scriptline.Substring(ScIndex))))
                        ElseIf Method = "-" Then
                            VariableNames(VariableIndex) = VariableName
                            Vars(VariableIndex) = Convert.ToInt32(Vars(VariableIndex)) - Convert.ToInt32((Replac(Scriptline.Substring(ScIndex))))
                        ElseIf Method = ":" Then
                            VariableNames(VariableIndex) = VariableName

                            If My.Computer.FileSystem.FileExists(Replac(Scriptline.Substring(ScIndex))) Then
                                Vars(VariableIndex) = IO.File.ReadAllText(Replac(Scriptline.Substring(ScIndex)))
                            Else
                                Vars(VariableIndex) = "NUL"
                            End If
                        ElseIf Method = "<" Then
                            VariableNames(VariableIndex) = VariableName
                            Vars(VariableIndex) = Console.ReadLine
                        ElseIf Method = "key" Then
                            Try
                                VariableNames(VariableIndex) = VariableName
                                Dim keyInfo As ConsoleKeyInfo
                                keyInfo = Console.ReadKey
                                Vars(VariableIndex) = keyInfo.KeyChar
                            Catch ex As Exception
                                Console.WriteLine(ex.Message.ToString)
                            End Try
                        End If
                        Exit For
                    Else
                        VariableIndex += 1
                    End If
                Next
                Dim WriteIndex As Integer = 0
                If VariableNames.Contains(VariableName) Then
                    For Each a In VariableNames
                        If a = VariableName Then
                            Vars(WriteIndex) = Tipper(Replac(Scriptline.Substring(ScIndex)))
                        End If
                    Next
                Else
                    For Each Value In Vars
                        If Value = Nothing Then
                            Exit For
                        Else
                            WriteIndex += 1
                        End If
                    Next
                    VariableNames(WriteIndex) = VariableName
                    Vars(WriteIndex) = Tipper(Replac(Scriptline.Substring(ScIndex)))
                End If
            Catch ex As Exception
                ErrorHandle("Error while initializing Variable")
            End Try
        ElseIf Scriptline = "version" Then
            Console.WriteLine("~Pais © Fabian Müller Version " & Versionscode & "~")
        ElseIf Scriptline = "1134-g-2601" Then
            For Each Value In Vars
                Console.WriteLine(Value)
            Next
        ElseIf Scriptline.ToLower.StartsWith("if ") Then
            Try

                Dim Method As String = Nothing
                Dim NewScriptline As String = Replac(Scriptline.Substring(3))
                Dim First As String = ""
                Dim Second As String = Nothing
                Dim TemporIndex As Integer = 0
first:
                If NewScriptline(TemporIndex) = "=" Then
                    Method = "eq"
                    TemporIndex += 1
                    GoTo second
                ElseIf NewScriptline(TemporIndex) = "!" Then
                    Method = "neq"
                    TemporIndex += 1
                    GoTo second
                ElseIf NewScriptline(TemporIndex) = "<" Then
                    Method = "smaller"
                    TemporIndex += 1
                    GoTo second
                ElseIf NewScriptline(TemporIndex) = ">" Then
                    Method = "bigger"
                    TemporIndex += 1
                    GoTo second
                ElseIf NewScriptline(TemporIndex) = "@" Then
                    Method = "contains"
                    TemporIndex += 1
                    GoTo second
                ElseIf NewScriptline(TemporIndex) = "$" Then
                    Method = "doesntcontains"
                    TemporIndex += 1
                    GoTo second
                Else
                    First = First & NewScriptline(TemporIndex)
                End If
                TemporIndex += 1
                GoTo first
second:
                If NewScriptline(TemporIndex) = ">" Then
                    If Method = "eq" Then
                        If Tipper(First) = Tipper(Second) Then
                            AllFunctions(NewScriptline.Substring(TemporIndex + 1))
                        Else
                        End If

                    ElseIf Method = "neq" Then
                        If Tipper(First) = Tipper(Second) Then
                        Else
                            AllFunctions(NewScriptline.Substring(TemporIndex + 1))
                        End If
                    ElseIf Method = "smaller" Then
                        If Tipper(First) < Tipper(Second) Then
                            AllFunctions(NewScriptline.Substring(TemporIndex + 1))
                        End If
                    ElseIf Method = "bigger" Then
                        If Tipper(First) > Tipper(Second) Then
                            AllFunctions(NewScriptline.Substring(TemporIndex + 1))
                        End If
                    ElseIf Method = "contains" Then
                        If Tipper(First.Contains(Second)) Then
                            AllFunctions(NewScriptline.Substring(TemporIndex + 1))
                        End If
                    ElseIf Method = "doesntcontains" Then
                        If Tipper(First.Contains(Second)) Then
                        Else
                            AllFunctions(NewScriptline.Substring(TemporIndex + 1))
                        End If
                    End If
                    Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
                    Exit Function
                Else
                    Second = Second & NewScriptline(TemporIndex)
                End If



                TemporIndex += 1
                GoTo second


            Catch ex As Exception

            End Try

        ElseIf Scriptline.ToLower.StartsWith("point(") Then
            Dim Method As String = Nothing
            Dim NewScriptline As String = Replac(Scriptline.Substring(6)).Replace(" ", "")
            Dim point_first As String = ""
            Dim point_second As String = Nothing
            Dim TemporIndex As Integer = 0
point_first:
            If NewScriptline(TemporIndex) = "," Then
                TemporIndex += 1
                GoTo point_second

            Else
                point_first = point_first & NewScriptline(TemporIndex)
                TemporIndex += 1
                GoTo point_first
            End If
point_second:
            If NewScriptline(TemporIndex) = ")" Then
                Try
                    Console.SetCursorPosition(Convert.ToInt32(point_first), Convert.ToInt32(point_second))
                Catch ex As Exception

                End Try
                Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
                Exit Function
            Else
                point_second = point_second & NewScriptline(TemporIndex)
            End If



            TemporIndex += 1
            GoTo point_second









        ElseIf Scriptline.ToLower.StartsWith("random(") Then
            Dim Method As String = Nothing
            Dim NewScriptline As String = Replac(Scriptline.Substring(7)).Replace(" ", "")
            Dim random_first As String = Nothing
            Dim random_second As String = Nothing
            Dim TemporIndex As Integer = 0
random_first:
            If NewScriptline(TemporIndex) = "," Then
                TemporIndex += 1
                GoTo random_second

            Else
                random_first = random_first & NewScriptline(TemporIndex)
                TemporIndex += 1
                GoTo random_first
            End If
random_second:


            If NewScriptline(TemporIndex) = ")" Then
                Try
                    Dim random As New System.Random
                    Dim TempRand As Integer = random.Next(Convert.ToInt32(random_first), Convert.ToInt32(random_second))
                    Return TempRand
                    Exit Function
                Catch ex As Exception
                    ErrorHandle("Error! The second parameter must be equals or less than the first parameter!")

                    Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
                End Try
            Else
                random_second = random_second & NewScriptline(TemporIndex)
            End If



            TemporIndex += 1
            GoTo random_second
        ElseIf Scriptline.ToLower.StartsWith("replace(") Then
            Dim ReplaceString As String = ""
            Dim Method As String = Nothing
            Dim NewScriptline As String = Replac(Scriptline.Substring(8))
            Dim replace_first As String = ""
            Dim replace_second As String = ""
            Dim replace_third As String = ""
            Dim TemporIndex As Integer = 0
replace_first:
            If NewScriptline(TemporIndex) = "|" Then
                TemporIndex += 1
                GoTo replace_second
            Else
                replace_first = replace_first & NewScriptline(TemporIndex)
                TemporIndex += 1
                GoTo replace_first
            End If
replace_second:
            If NewScriptline(TemporIndex) = "|" Then
                TemporIndex += 1
                GoTo replace_third
            Else
                replace_second = replace_second & NewScriptline(TemporIndex)
                TemporIndex += 1
                GoTo replace_second
            End If
replace_third:
            If NewScriptline(TemporIndex) = ")" Then
                Try
                    ReplaceString = replace_first
                    ReplaceString = ReplaceString.Replace(replace_second, replace_third)
                Catch ex As Exception

                End Try
                Return ReplaceString
                Exit Function
            Else
                replace_third = replace_third & NewScriptline(TemporIndex)
            End If
            TemporIndex += 1
            GoTo replace_third








        ElseIf Scriptline.ToLower.StartsWith("window(") Then

            Try




                Dim Method As String = Nothing
                Dim NewScriptline As String = Replac(Scriptline.Substring(7)).Replace(" ", "")
                Dim window_first As String = ""
                Dim window_second As String = Nothing
                Dim TemporIndex As Integer = 0
window_first:
                If NewScriptline(TemporIndex) = "," Then
                    TemporIndex += 1
                    GoTo window_second

                Else
                    window_first = window_first & NewScriptline(TemporIndex)
                    TemporIndex += 1
                    GoTo window_first
                End If
window_second:
                If NewScriptline(TemporIndex) = ")" Then
                    Try
                        Console.SetWindowSize(Convert.ToInt32(window_first), Convert.ToInt32(window_second))
                        Console.SetBufferSize(Convert.ToInt32(window_first), Convert.ToInt32(window_second))
                    Catch ex As Exception

                    End Try
                    Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
                    Exit Function
                Else
                    window_second = window_second & NewScriptline(TemporIndex)
                End If



                TemporIndex += 1
                GoTo window_second




            Catch ex As Exception
                ErrorHandle("Error while setting window size!")
            End Try









        ElseIf Scriptline.ToLower.StartsWith("buffer(") Then

            Try




                Dim Method As String = Nothing
                Dim NewScriptline As String = Replac(Scriptline.Substring(7)).Replace(" ", "")
                Dim buffer_first As String = ""
                Dim buffer_second As String = Nothing
                Dim TemporIndex As Integer = 0
buffer_first:
                If NewScriptline(TemporIndex) = "," Then
                    TemporIndex += 1
                    GoTo buffer_second

                Else
                    buffer_first = buffer_first & NewScriptline(TemporIndex)
                    TemporIndex += 1
                    GoTo buffer_first
                End If
buffer_second:
                If NewScriptline(TemporIndex) = ")" Then
                    Try
                        Console.SetBufferSize(Convert.ToInt32(buffer_first), Convert.ToInt32(buffer_second))
                        Console.SetBufferSize(Convert.ToInt32(buffer_first), Convert.ToInt32(buffer_second))
                    Catch ex As Exception

                    End Try
                    Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
                    Exit Function
                Else
                    buffer_second = buffer_second & NewScriptline(TemporIndex)
                End If



                TemporIndex += 1
                GoTo buffer_second




            Catch ex As Exception
                ErrorHandle("Error while setting buffer size!")
            End Try
















        ElseIf Scriptline.ToLower.StartsWith("border(") Then
            Try




                Dim Method As String = Nothing
                Dim NewScriptline As String = Replac(Scriptline.Substring(7)).Replace(" ", "")
                Dim border_first As String = ""
                Dim border_second As String = Nothing
                Dim TemporIndex As Integer = 0
border_first:
                If NewScriptline(TemporIndex) = "," Then
                    TemporIndex += 1
                    GoTo border_second

                Else
                    border_first = border_first & NewScriptline(TemporIndex)
                    TemporIndex += 1
                    GoTo border_first
                End If
border_second:
                If NewScriptline(TemporIndex) = ")" Then
                    Try
                        Dim tempcurserx = Console.CursorLeft
                        Dim tempcursery = Console.CursorTop
                        Dim yy As Integer = 0
                        Dim xx As Integer = 0
bordercalcx1:

                        ''╔║═╗╚╝


                        If xx = border_first Then
                            Console.Write("╗")
                            xx = 0
                        Else
                            If xx = 0 Then
                                Console.Write("╔")
                            Else
                                Console.Write("═")
                            End If
                            xx += 1

                            GoTo bordercalcx1
                        End If

                        Console.CursorLeft = tempcurserx
                        Console.CursorTop = tempcursery + border_second - 1

bordercalcx2:
                        If xx = border_first Then
                            Console.Write("╝")
                            xx = 0
                        Else
                            If xx = 0 Then
                                Console.Write("╚")
                            Else
                                Console.Write("═")
                            End If
                            xx += 1

                            GoTo bordercalcx2
                        End If

                        Console.CursorLeft = tempcurserx
                        Console.CursorTop = tempcursery
bordercalcy1:

                        Console.CursorTop += 1
                        Console.CursorLeft = tempcurserx
                        If yy = border_second - 2 Then
                        Else
                            Console.Write("║")

                            yy += 1

                            GoTo bordercalcy1
                        End If

                        yy = 0
                        Console.CursorLeft = tempcurserx + xx
                        Console.CursorTop = tempcursery
bordercalcy2:

                        Console.CursorLeft = tempcurserx + border_first
                        Console.CursorTop += 1
                        If yy = border_second - 2 Then
                        Else
                            Console.Write("║")
                            yy += 1
                            GoTo bordercalcy2
                        End If

                        yy = 0
                        Console.CursorTop += 1
                        Console.CursorLeft = 0




                    Catch ex As Exception

                    End Try
                    Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
                    Exit Function
                Else
                    border_second = border_second & NewScriptline(TemporIndex)
                End If



                TemporIndex += 1
                GoTo border_second




            Catch ex As Exception
                ErrorHandle("Error while setting border size!")
            End Try









        ElseIf Scriptline.ToLower.StartsWith("beep(") Then

            Try
                Dim Method As String = Nothing
                Dim NewScriptline As String = Replac(Scriptline.Substring(5))
                Dim beep_first As String = ""
                Dim beep_second As String = Nothing
                Dim TemporIndex As Integer = 0
beep_first:
                If NewScriptline(TemporIndex) = "," Then
                    TemporIndex += 1
                    GoTo beep_second

                Else
                    beep_first = beep_first & NewScriptline(TemporIndex)
                    TemporIndex += 1
                    GoTo beep_first
                End If
beep_second:
                If NewScriptline(TemporIndex) = ")" Then
                    Try
                        Console.Beep(Convert.ToInt32(beep_first), Convert.ToInt32(beep_second))
                    Catch ex As Exception
                        ErrorHandle("Error! Beep(" & beep_first & "," & beep_second & ")")
                    End Try
                    Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
                    Exit Function
                Else
                    beep_second = beep_second & NewScriptline(TemporIndex)
                End If

                TemporIndex += 1
                GoTo beep_second

            Catch ex As Exception
                ErrorHandle("Error! Uncought error!")
            End Try












        ElseIf Scriptline.ToLower.StartsWith("for each(") Then
            Try
                Dim Method As String = Nothing
                Dim NewScriptline As String = Replac(Scriptline.Substring(9))
                Dim for_first As String = ""
                Dim for_second As String = Nothing
                Dim TemporIndex As Integer = 0
for_first:
                If NewScriptline(TemporIndex) = "|" Then
                    TemporIndex += 1
                    GoTo for_second

                Else
                    for_first = for_first & NewScriptline(TemporIndex)
                    TemporIndex += 1
                    GoTo for_first
                End If
for_second:
                If NewScriptline(TemporIndex) = ")" Then
                    Try
                        For Each TempForVar As String In for_second
                            If TempForVar = for_first Then

                                forcounts += 1
                                ForVar = TempForVar
                                AllFunctions(Replac(Scriptline.Substring(9 + for_first.Length + 1 + for_second.Length + 1)))

                            End If
                        Next
                    Catch ex As Exception
                        ErrorHandle("Error! Uncought error!")
                    End Try
                    Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
                    Exit Function
                Else
                    for_second = for_second & NewScriptline(TemporIndex)
                End If

                TemporIndex += 1
                GoTo for_second

            Catch ex As Exception
                ErrorHandle("Error! Uncought error!")
            End Try




















        ElseIf Scriptline.ToLower.StartsWith("call ") Then

            Try
                If Scriptline.Substring(5).StartsWith("http://") Then
                    Dim webclient As New System.Net.WebClient
                    Dim WasBinary As Boolean = True
                    If IsBinary = True Then
                        WasBinary = True
                    Else
                        WasBinary = False
                        IsBinary = True
                    End If

                    OldMainFile = MainFile
                    OldIndex = Index0
                    Index0 = 0
                    webclient.DownloadFile(Scriptline.Substring(5), "tmp.tmp")
                    MainFile = "tmp.tmp"
                    SubRuntime()
                    If WasBinary = True Then
                        IsBinary = True
                    Else
                        IsBinary = False
                    End If
                ElseIf Scriptline.Substring(5).StartsWith("https://") Then
                    Dim webclient As New System.Net.WebClient
                    Dim WasBinary As Boolean = True
                    If IsBinary = True Then
                        WasBinary = True
                    Else

                        WasBinary = False
                        IsBinary = True
                    End If

                    OldMainFile = MainFile
                    OldIndex = Index0
                    Index0 = 0
                    webclient.DownloadFile(Scriptline.Substring(5), "tmp.tmp")
                    MainFile = "tmp.tmp"
                    SubRuntime()
                    If WasBinary = True Then
                        IsBinary = True
                    Else
                        IsBinary = False
                    End If
                ElseIf My.Computer.FileSystem.FileExists(Replac(Scriptline.Substring(5))) Then
                    Dim WasBinary As Boolean = True
                    If IsBinary = True Then
                        WasBinary = True
                    Else

                        WasBinary = False
                        IsBinary = True
                    End If
                    OldMainFile = MainFile
                    OldIndex = Index0
                    Index0 = 0
                    MainFile = Scriptline.ToLower.Substring(5)
                    SubRuntime()
                    If WasBinary = True Then
                        IsBinary = True
                    Else
                        IsBinary = False
                    End If
                End If
            Catch ausnahme As Exception
                ErrorHandle("Error!" & vbCrLf & ausnahme.Message)
            End Try
        ElseIf Scriptline.ToLower.StartsWith("extent(") Then
            Try
                Dim Method As String = Nothing
                Dim NewScriptline As String = Replac(Scriptline.Substring(7))
                Dim extent_first As String = ""
                Dim extent_second As String = Nothing
                Dim TemporIndex As Integer = 0
extent_first:
                If NewScriptline(TemporIndex) = "," Then
                    TemporIndex += 1
                    GoTo extent_second
                Else
                    extent_first = extent_first & NewScriptline(TemporIndex)
                    TemporIndex += 1
                    GoTo extent_first
                End If
extent_second:
                If NewScriptline(TemporIndex) = ")" Then
                    Try
                        If My.Computer.FileSystem.DirectoryExists("plugins\") Then
                            If My.Computer.FileSystem.FileExists("plugins\" & extent_first) Then

                                Dim proc As Process = New Process
                                proc.StartInfo.FileName = "plugins\" & extent_first

                                proc.StartInfo.Arguments = extent_second
                                proc.StartInfo.UseShellExecute = False
                                proc.StartInfo.RedirectStandardOutput = True
                                proc.Start()
                                Dim output As String = proc.StandardOutput.ReadToEnd
                                procout = output
                                proc.WaitForExit()


                            Else
                                ErrorHandle("File not found! Argument:" & extent_first)
                            End If
                        End If
                    Catch ex As Exception
                        ErrorHandle("Error while initializing plugin!")
                    End Try
                    Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
                    Exit Function
                Else
                    extent_second = extent_second & NewScriptline(TemporIndex)
                End If



                TemporIndex += 1
                GoTo extent_second









            Catch ex As Exception
                ErrorHandle("Error while initalizing extention!")
            End Try


        ElseIf Scriptline.ToLower.StartsWith("writetofile:") Then
            Try

                Dim aNewScriptlines As String = Replac(Scriptline.Substring(12))
                Dim aFirsts As String = Nothing
                Dim aSeconds As String = Nothing
                Dim aTemporIndexs As Integer = 0
firsts:
                If aNewScriptlines(aTemporIndexs) = "<" Then
                    aTemporIndexs += 1
                    GoTo seconds
                Else
                    aFirsts = aFirsts & aNewScriptlines(aTemporIndexs)
                End If
                aTemporIndexs += 1
                GoTo firsts
seconds:
                If aNewScriptlines(aTemporIndexs) = ">" Then
                    IO.File.WriteAllText(aFirsts, aSeconds)
                    Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
                    Exit Function
                Else
                    aSeconds = aSeconds & aNewScriptlines(aTemporIndexs)

                End If
                aTemporIndexs += 1
                GoTo seconds

            Catch ex As Exception
                ErrorHandle("Error while writing to file " & Replac(Scriptline.Substring(12)))
            End Try

        ElseIf Scriptline.ToLower.StartsWith("downloadfile:") Then
            Try
                Dim aNewScriptlines As String = Replac(Scriptline.Substring(13))
                Dim aFirsts As String = Nothing
                Dim aSeconds As String = Nothing
                Dim aTemporIndexs As Integer = 0
firstsa:
                If aNewScriptlines(aTemporIndexs) = "<" Then
                    aTemporIndexs += 1
                    GoTo secondsa
                Else
                    aFirsts = aFirsts & aNewScriptlines(aTemporIndexs)
                End If
                aTemporIndexs += 1
                GoTo firstsa
secondsa:
                If aNewScriptlines(aTemporIndexs) = ">" Then
                    Try
                        My.Computer.Network.DownloadFile(aFirsts, aSeconds)
                    Catch ex As Exception
                        IO.File.Delete(aSeconds)
                        My.Computer.Network.DownloadFile(aFirsts, aSeconds)

                    End Try
                    Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
                    Exit Function
                Else
                    aSeconds = aSeconds & aNewScriptlines(aTemporIndexs)

                End If
                aTemporIndexs += 1
                GoTo secondsa



            Catch ex As Exception
                ErrorHandle("Error while downloading and writing to file " & Replac(Scriptline.Substring(12)))
            End Try












        ElseIf Scriptline.ToLower.StartsWith("var") Then

            Dim Var As String = Scriptline.Substring(3)
            'Dim keyInfo As ConsoleKeyInfo


            'If Var.StartsWith("0+=") Then
            'var0 += Convert.ToInt32(Var.Substring(3))
            'ElseIf Var.StartsWith("0-=") Then
            '   var0 -= Convert.ToInt32(Var.Substring(3))
            'ElseIf Var.StartsWith("0*=") Then
            'ElseIf Var.StartsWith("0/=") Then
            '  var0 /= Convert.ToInt32(Var.Substring(3))
            'ElseIf Var.StartsWith("0=<") Then
            ' var0 = Console.ReadLine()
            'ElseIf Var.StartsWith("0=") Then
            'var0 = Var.Substring(2)
            'ElseIf Var.StartsWith("0:") Then
            'var0 = IO.File.ReadAllText(Var.Substring(2))
            'ElseIf Var.StartsWith("0|") Then
            'keyInfo = Console.ReadKey()
            'var0 = keyInfo.KeyChar
            'ElseIf Var.StartsWith("0_ToBin:") Then
            'var0 = StringToBinary(Scriptline.Substring(11))
            'ElseIf Var.StartsWith("0_FromBin:") Then
            'var0 = BinaryToString(Scriptline.Substring(13))
            'End If















        ElseIf Scriptline.ToLower.StartsWith("stop ") Then
            My.Computer.Audio.Stop()
        ElseIf Scriptline.ToLower.StartsWith("play+ ") Then
            If My.Computer.FileSystem.FileExists(Replac(Scriptline.Substring(6))) Then
                My.Computer.Audio.Play(Scriptline.Substring(6), AudioPlayMode.Background)
            Else
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("File not found! (" & Replac(Scriptline.Substring(5)) & ")")
                Console.ForegroundColor = DefForeColor
                Console.BackgroundColor = DefBackColor
            End If
        ElseIf Scriptline.ToLower = ("break") Then
            Console.Write(vbCrLf)

        ElseIf Scriptline.ToLower.StartsWith("[") Then
        ElseIf Scriptline.ToLower = ("reset") Then
            Console.ResetColor()
            Console.Clear()
        ElseIf Scriptline.ToLower = ("resetcolor") Then
            Console.ResetColor()
        ElseIf Scriptline.ToLower.StartsWith("echo ") Then
            Console.Write(Replac(Scriptline.Substring(5)))
        ElseIf Scriptline.ToLower.StartsWith("echol ") Then
            Console.Write(Replac(Scriptline.Substring(6)) & vbCrLf)
        ElseIf Scriptline.ToLower.StartsWith("print ") Then
            Console.Write(Replac(Scriptline.Substring(5)))
        ElseIf Scriptline.ToLower.StartsWith("printl ") Then
            Console.Write(Replac(Scriptline.Substring(6)) & vbCrLf)
        ElseIf Scriptline.ToLower.StartsWith("foreground=") Then
            If (Scriptline.ToLower.Substring(11)) = "red" Then
                Console.ForegroundColor = ConsoleColor.Red
            End If
            If (Scriptline.ToLower.Substring(11)) = "green" Then
                Console.ForegroundColor = ConsoleColor.Green
            End If
            If (Scriptline.ToLower.Substring(11)) = "blue" Then
                Console.ForegroundColor = ConsoleColor.Blue
            End If
            If (Scriptline.ToLower.Substring(11)) = "magenta" Then
                Console.ForegroundColor = ConsoleColor.Magenta
            End If
            If (Scriptline.ToLower.Substring(11)) = "darkmagenta" Then
                Console.ForegroundColor = ConsoleColor.DarkMagenta
            End If
            If (Scriptline.ToLower.Substring(11)) = "cyan" Then
                Console.ForegroundColor = ConsoleColor.Cyan
            End If
            If (Scriptline.ToLower.Substring(11)) = "white" Then
                Console.ForegroundColor = ConsoleColor.White
            End If
            If (Scriptline.ToLower.Substring(11)) = "black" Then
                Console.ForegroundColor = ConsoleColor.Black
            End If
            If (Scriptline.ToLower.Substring(11)) = "darkyellow" Then
                Console.ForegroundColor = ConsoleColor.DarkYellow
            End If
            If (Scriptline.ToLower.Substring(11)) = "yellow" Then
                Console.ForegroundColor = ConsoleColor.Yellow
            End If
            If (Scriptline.ToLower.Substring(11)) = "gray" Then
                Console.ForegroundColor = ConsoleColor.Gray
            End If
            If (Scriptline.ToLower.Substring(11)) = "darkgray" Then
                Console.ForegroundColor = ConsoleColor.DarkGray
            End If
            If (Scriptline.ToLower.Substring(11)) = "darkcyan" Then
                Console.ForegroundColor = ConsoleColor.DarkCyan
            End If
            If (Scriptline.ToLower.Substring(11)) = "darkblue" Then
                Console.ForegroundColor = ConsoleColor.DarkBlue
            End If
            If (Scriptline.ToLower.Substring(11)) = "darkred" Then
                Console.ForegroundColor = ConsoleColor.DarkRed
            End If
            If (Scriptline.ToLower.Substring(11)) = "darkgreen" Then
                Console.ForegroundColor = ConsoleColor.DarkGreen
            End If
            DefForeColor = Console.ForegroundColor
        ElseIf Scriptline.ToLower.StartsWith("background=") Then
            If (Replac(Scriptline.ToLower.Substring(11))) = "red" Then
                Console.BackgroundColor = ConsoleColor.Red
            End If
            If (Replac(Scriptline.ToLower.Substring(11))) = "green" Then
                Console.BackgroundColor = ConsoleColor.Green
            End If
            If (Scriptline.ToLower.Substring(11)) = "blue" Then
                Console.BackgroundColor = ConsoleColor.Blue
            End If
            If (Scriptline.ToLower.Substring(11)) = "magenta" Then
                Console.BackgroundColor = ConsoleColor.Magenta
            End If
            If (Scriptline.ToLower.Substring(11)) = "darkmagenta" Then
                Console.BackgroundColor = ConsoleColor.DarkMagenta
            End If
            If (Scriptline.ToLower.Substring(11)) = "cyan" Then
                Console.BackgroundColor = ConsoleColor.Cyan
            End If
            If (Scriptline.ToLower.Substring(11)) = "white" Then
                Console.BackgroundColor = ConsoleColor.White
            End If
            If (Scriptline.ToLower.Substring(11)) = "black" Then
                Console.BackgroundColor = ConsoleColor.Black
            End If
            If (Scriptline.ToLower.Substring(11)) = "darkyellow" Then
                Console.BackgroundColor = ConsoleColor.DarkYellow
            End If
            If (Scriptline.ToLower.Substring(11)) = "yellow" Then
                Console.BackgroundColor = ConsoleColor.Yellow
            End If
            If (Scriptline.ToLower.Substring(11)) = "gray" Then
                Console.BackgroundColor = ConsoleColor.Gray
            End If
            If (Scriptline.ToLower.Substring(11)) = "darkgray" Then
                Console.BackgroundColor = ConsoleColor.DarkGray
            End If
            If (Scriptline.ToLower.Substring(11)) = "darkcyan" Then
                Console.BackgroundColor = ConsoleColor.DarkCyan
            End If
            If (Scriptline.ToLower.Substring(11)) = "darkblue" Then
                Console.BackgroundColor = ConsoleColor.DarkBlue
            End If
            If (Scriptline.ToLower.Substring(11)) = "DarkRed" Then
                Console.BackgroundColor = ConsoleColor.DarkRed
            End If
            If (Scriptline.ToLower.Substring(11)) = "darkgreen" Then
                Console.BackgroundColor = ConsoleColor.DarkGreen
            End If
            DefBackColor = Console.BackgroundColor
        ElseIf Scriptline.ToLower.StartsWith("console_width=") Then
            Try
                Console.WindowWidth = Replac(Scriptline.Substring(14))
                Console.BufferWidth = Console.WindowHeight
            Catch SCHAISDARUF As Exception
            End Try
        ElseIf Scriptline.ToLower.StartsWith("console_height=") Then
            Try
                Console.WindowHeight = Replac(Scriptline.Substring(15))
                Console.BufferHeight = Console.WindowHeight
            Catch SCHAISDARUF As Exception
            End Try
        ElseIf Scriptline.ToLower.StartsWith("wait ") Then
            If Scriptline.Substring(5) > 0 Then
                Console.CursorVisible = False
                Threading.Thread.Sleep(Replac(Scriptline.Substring(5)))
                Console.CursorVisible = True
            Else
                Console.CursorVisible = False
                Threading.Thread.Sleep(1000)
                Console.CursorVisible = True
            End If
        ElseIf Scriptline.ToLower.StartsWith("beep ") Then
            If Replac(Scriptline.Substring(5)) > 32 Then
                If Replac(Scriptline.Substring(5)) < 32001 Then
                    Console.Beep(Replac(Scriptline.Substring(5)), 100)
                Else
                    Console.Beep(1000, 100)
                End If
            Else
                Console.Beep(1000, 100)
            End If



        ElseIf Scriptline.ToLower.StartsWith("zip ") Then
            Libraryst(Scriptline.Substring(4), 0)


        ElseIf Scriptline.ToLower.StartsWith("computer:shutdown ") Then
            If Scriptline.Substring(18) > -1 Then
                Process.Start("shutdown", "-s -t" & Scriptline.Substring(18) & " -f")
            End If
        ElseIf Scriptline.ToLower.StartsWith("system:") Then
            Dim cmdproc As New Process
            With cmdproc
                .StartInfo = New ProcessStartInfo("cmd.exe", "/C " & Replac(Scriptline.Substring(7)))
                With .StartInfo
                    .CreateNoWindow = True
                    .UseShellExecute = False
                    .RedirectStandardOutput = True
                    .RedirectStandardInput = True
                    .RedirectStandardError = True
                End With
                .Start()
                .WaitForExit()
            End With
            Dim dd As String = cmdproc.StandardOutput.ReadToEnd
            Console.WriteLine(dd)
        ElseIf Scriptline.ToLower.StartsWith("computer:logout ") Then
            If Scriptline.Substring(16) > -1 Then
                Process.Start("shutdown", "-l -t " & Scriptline.Substring(16) & " -f")
            End If
        ElseIf Scriptline.ToLower.StartsWith("license") Then
            Module1.copyright()

        ElseIf Scriptline.ToLower.StartsWith("computer:sleep ") Then
            If Scriptline.Substring(15) > -1 Then
                Process.Start("shutdown", "-h -t " & Scriptline.Substring(15) & " -f")
            End If
        ElseIf Scriptline.ToLower.StartsWith("computer:restart ") Then
            If Scriptline.Substring(17) > -1 Then
                Process.Start("shutdown", "-r -t " & Scriptline.Substring(17) & " -f")
            End If
        ElseIf Scriptline.ToLower.StartsWith("readfile:") Then
            If My.Computer.FileSystem.FileExists(Scriptline.ToLower.Substring(9)) Then
                Dim tempcurserx As Integer = Console.CursorLeft
                Dim Readfilelines() As String = IO.File.ReadAllLines(Scriptline.ToLower.Substring(9))
                For Each LINE In Readfilelines
                    Console.Write(LINE)
                    Console.CursorLeft = tempcurserx
                    Console.CursorTop += 1

                Next

            Else
                If ErrorsOn = "true" Then
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.WriteLine("FILE NOT FOUND! """ & Scriptline.Substring(9) & """" & "!" & vbCrLf & "For help type " & """HELP""")
                    Console.ForegroundColor = DefForeColor
                    Console.BackgroundColor = DefBackColor
                End If
            End If
        ElseIf Scriptline = "keyboard" Then
            Console.WriteLine("Use the numpad to play, q to exit keyboard")
Swimmer:
            Dim Keys As String = Console.ReadKey.KeyChar
            If Keys = "1" Then
                Console.Beep(500, 100)
            ElseIf Keys = "2" Then
                Console.Beep(750, 100)
            ElseIf Keys = "3" Then
                Console.Beep(1000, 100)
            ElseIf Keys = "4" Then
                Console.Beep(1250, 100)
            ElseIf Keys = "5" Then
                Console.Beep(1500, 100)
            ElseIf Keys = "6" Then
                Console.Beep(1750, 100)
            ElseIf Keys = "7" Then
                Console.Beep(2000, 100)
            ElseIf Keys = "8" Then
                Console.Beep(2250, 100)
            ElseIf Keys = "9" Then
                Console.Beep(2500, 100)
            ElseIf Keys = "0" Then
                Console.Beep(250, 100)
            ElseIf Keys = "q" Then
                GoTo jumpot
            End If
            GoTo Swimmer
jumpot:
        ElseIf Scriptline.ToLower.StartsWith("function ") Then

            If Scriptline.ToLower.Substring(9) = "(open_window)" Then
                If ImportedWindow = True Then
                    Dim ApplicationWindow As New ApplicationWindow
                    ApplicationWindow.ShowDialog()
                Else
                    ErrorHandle("UNKNOWN FUNCTION """ & Scriptline.Substring(9) & """" & "! YOU MAY FORGOT TO IMPORT SOMETHING?")
                End If
            ElseIf Scriptline.ToLower.Substring(9) = "(htmlserver.stop)" Then
                HTTPSession.StopServer = True

            ElseIf Scriptline.ToLower.Substring(9) = "(help)" Then
                help()

            ElseIf Scriptline.ToLower.Substring(9) = "(htmlserver.start)" Then
                If ImportedServer = True Then
                    WebServer.Main()

                Else
                    ErrorHandle("UNKNOWN FUNCTION """ & Scriptline.Substring(9) & """" & "! YOU MAY FORGOT TO IMPORT SOMETHING?")

                End If
            Else
                ErrorHandle("UNKNOWN FUNCTION """ & Scriptline.Substring(9) & """" & "! YOU MAY FORGOT TO IMPORT SOMETHING?")


            End If
        ElseIf Scriptline.ToLower = "import (winapi)" Then
            ImportedWindow = True
        ElseIf Scriptline.ToLower = "import (htmlserver)" Then
            ImportedServer = True
        ElseIf Scriptline.ToLower.StartsWith("read:") Then
            If My.Computer.FileSystem.FileExists(Scriptline.ToLower.Substring(5)) Then
                Console.WriteLine(IO.File.ReadAllText(Scriptline.ToLower.Substring(5)))
            Else
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("UNKNOWN FUNCTION """ & Scriptline.Substring(9) & """" & "! YOU MAY FORGOT TO IMPORT SOMETHING?")

                Console.ForegroundColor = DefForeColor
                Console.BackgroundColor = DefBackColor

            End If
        ElseIf Scriptline.ToLower.StartsWith("htmlserver.webfolder:") Then
            WebServer.Webfoldername = Scriptline.ToLower.Substring(21)

        ElseIf Scriptline.ToLower.StartsWith("htmlserver.logname:") Then
            WebServer.logname = Scriptline.ToLower.Substring(19)

        ElseIf Scriptline.ToLower.StartsWith("htmlserver.log:") Then
            If Scriptline.ToLower.Substring(15) = "true" Then
                WebServer.WriteLog = True
            ElseIf Scriptline.ToLower.Substring(15) = "false" Then
                WebServer.WriteLog = False

            End If





        Else
            ErrorHandle("UNKNOWN COMMAND """ & Scriptline & """" & "!" & vbCrLf & "For help type " & """HELP""")

        End If
        Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
    End Function















    Public Function UpperFolder(ByVal FolderName As String, ByVal level As Int32) As String
        Dim TheList As New List(Of String)()

        Do While Not String.IsNullOrEmpty(FolderName)
            Dim temp = Directory.GetParent(FolderName)
            If temp Is Nothing Then
                Exit Do
            End If
            FolderName = Directory.GetParent(FolderName).FullName
            TheList.Add(FolderName)
        Loop

        If TheList.Count > 0 AndAlso level > 0 Then
            If level - 1 <= TheList.Count - 1 Then
                Return TheList(level - 1)
            Else
                Return FolderName
            End If
        Else
            Return FolderName
        End If
    End Function








    Public Function Variables()
        Console.WriteLine( _
        "%simpletime                -Time [HH:MM]" & vbCrLf & _
        "%time                      -Time [.h/.s/.m/.t/.ticks]" & vbCrLf & _
        "%date                      -Date %date[.m/.d/.y]" & vbCrLf & _
        "%dir                       -Temporary Directory" & vbCrLf & _
        "%ramav                     -Available Virtual Memory" & vbCrLf & _
        "%ramap                     -Available Physical Memory" & vbCrLf & _
        "%ramtv                     -Total Virtual Memory" & vbCrLf & _
        "%ramtp                     -Total Physical Memory" & vbCrLf & _
        "%network                   -Returns a Boolean True/False if is connected to a Network" & vbCrLf & _
        "%os                        -Operatingsystem" & vbCrLf & _
        "%break                     -Linebreak" & vbCrLf & _
        "%version                   -PAIS versioncode" & vbCrLf & _
        "%path                      -Path of temporary runtime" & vbCrLf & _
        "")

        Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
    End Function

    Public Function Libraryst(ByVal Path As String, ByVal Argument As Integer)

        Try
            If My.Computer.FileSystem.FileExists(Path) Then
                Dim DataFile() As String = IO.File.ReadAllLines(Path)
                Dim Cluster As String = ""

                For Each Strip In DataFile
                    Dim Ascii As Byte() = System.Text.Encoding.ASCII.GetBytes(Strip)
                    For Each stripstrip In Ascii
                        Cluster = Cluster & stripstrip
                    Next
                    Cluster = Cluster & vbCrLf
                Next

                IO.File.WriteAllText("temp.txt", Cluster)


            Else
                ErrorHandle("Error! No such file in directory! '" & Path & "'")
            End If
        Catch ex As Exception
            ErrorHandle("Error! No such file in directory! '" & Path & "'")
        End Try

        Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
    End Function




    Public Function help()
        Console.ForegroundColor = DefForeColor
        Console.BackgroundColor = DefBackColor

        Console.WriteLine("PAIS © 2017 Paitorocxon")



        Console.ForegroundColor = DefForeColor
        Console.BackgroundColor = DefBackColor

        Console.ForegroundColor = ConsoleColor.White
        Dim Helptext As String = _
                "" & vbCrLf & _
                "" & vbCrLf & _
         "wait MILLISECONDS                  -Waits until the time is over" & vbCrLf & _
         "pause                              -Waits until the user pressed a key" & vbCrLf & _
         "foreground=COLORNAME               -Change foregroundcolor" & vbCrLf & _
         "background=COLORNAME               -Change backgroundcolor" & vbCrLf & _
         "title=TEXT                         -Change the title" & vbCrLf & _
         "border(NUMBER,NUMBER)              -Create border with width W and height H" & vbCrLf & _
         "call FILENAME                      -Run another module" & vbCrLf & _
         "clear                              -Clear the console" & vbCrLf & _
         "downloadfile:URL<PATH/NAME>        -Download and save file" & vbCrLf & _
         "float TEXT                         -Float a text onto the console" & vbCrLf & _
         "dialog TEXT                        -Show a dialog with the typed content" & vbCrLf & _
         "echo TEXT                          -Write text without linebreak" & vbCrLf & _
         "echol TEXT                         -Write text with linebreak" & vbCrLf & _
         "print TEXT                         -Write text without linebreak" & vbCrLf & _
         "printl TEXT                        -Write text with linebreak" & vbCrLf & _
         "reset                              -Reset the whole console" & vbCrLf & _
         "resetcolor                         -Reset the consoles color" & vbCrLf & _
         "point(X,Y)                         -Set cursorpoint" & vbCrLf & _
         "console_height=NUMBER              -Set consoles height (min=1)" & vbCrLf & _
         "console_width=NUMBER               -Set consoles width (min=1)" & vbCrLf & _
         "computer:sleep MILLISECONDS        -Set computer-activitystate to sleep" & vbCrLf & _
         "computer:shutdown MILLISECONDS     -Shutdown the Computer" & vbCrLf & _
         "computer:restart MILLISECONDS      -Restart the Computer" & vbCrLf & _
         "computer:logout MILLISECONDS       -The temoprary user will be logged out" & vbCrLf & _
         "beep FREQUENCY                     -Computer makes BEEP!" & vbCrLf & _
         "play PATH                          -Play .wav files" & vbCrLf & _
         "play+ PATH                         -Play .wav files w/o waiting untill it ends" & vbCrLf & _
         "system:ARGUEMENT                   -Run a system command" & vbCrLf & _
         "compile PATH/NAME                  -compile text to PAIS" & vbCrLf & _
         "decompile PATH/NAME                -decompile PAIS to text" & vbCrLf & _
         "rainbow TEXT                       -Rainbow effect" & vbCrLf & _
         "goto NAME                          -Requires a jumpoint like [NAME]" & vbCrLf & _
         "endcoding:ENCODING                 -Changes the console OUTPUT-ENCODING" & vbCrLf & _
         "                                    Encodings: ASCII, UTF7, UTF8, DEFAULT, STANDARD" & vbCrLf & _
         "error:on/error:off                 -Disable/Enable error messages while runtime" & vbCrLf & _
         "import (LIBRARYNAME)               -Import Library" & vbCrLf & _
         "replace(TEXT|TEXT|TEXT)            -Replace a string with a string" & vbCrLf & _
         "readfile:PATH/NAME                 -Read a textfile" & vbCrLf & _
         "license                            -Read the license!" & vbCrLf & _
         "writetofile:PATH/NAME<CONTENT>     -Write file" & vbCrLf & _
         "c:ON/OFF                           -ON=die if CTRL+C" & vbCrLf & _
         "#,!,:,',rem,com,//                 -Comment (Will be ignored by PAIS)" & vbCrLf & _
         "varVARNUMBER                       -Set a variable!" & vbCrLf & _
         "     %VAR=VARIABLE              :sets a variable to variable 1" & vbCrLf & _
         "     %VAR+=VARIABLE             :variable1 + variable" & vbCrLf & _
         "     %VAR-=VARIABLE             :variable1 - variable" & vbCrLf & _
         "     %VAR*=VARIABLE             :variable1 * variable" & vbCrLf & _
         "     %VAR/=VARIABLE             :variable1 / variable" & vbCrLf & _
         "     %VAR:PATH/NAME             :variable1 = FILECONTENT" & vbCrLf & _
         "     %VAR|                      :read key" & vbCrLf & _
         "  (!) For more GLOABL VARIABLES type 'vars'" & vbCrLf & _
         "  Using it in another modules is the same like you use it in your script" & vbCrLf & _
         "if %VAR=%VAR>COMMAND    -IF VALUE1 is VALUE2 then do a command" & vbCrLf & _
         "if %VAR<%VAR>COMMAND    -IF VALUE1 is smaller then VALUE2 then do a command" & vbCrLf & _
         "if %VAR<%VAR>COMMAND    -IF VALUE1 is bigger then VALUE2 then do a command" & vbCrLf & _
         "if %VAR!%VAR>COMMAND    -IF VALUE1 is'nt VALUE2 then do a command" & vbCrLf & _
         "if %VAR@%VAR>COMMAND    -IF VALUE1 contains VALUE2 then do a command" & vbCrLf & _
         "if %VAR$%VAR>COMMAND    -IF VALUE1 does'nt contains VALUE2 then do a command" & vbCrLf & _
         "" & _
         ""
        Console.WriteLine(Helptext)
        Console.ForegroundColor = DefForeColor
        Console.BackgroundColor = DefBackColor






        Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
    End Function



    Public Function Rainbow(ByVal Text As String)
        Dim Colorcode As Integer = 0
        Dim Index As Integer = 0
        For Each Character In Text
            If Colorcode = 0 Then
                Console.ForegroundColor = ConsoleColor.Red
            ElseIf Colorcode = 1 Then
                Console.ForegroundColor = ConsoleColor.Red
            ElseIf Colorcode = 2 Then
                Console.ForegroundColor = ConsoleColor.Yellow
            ElseIf Colorcode = 3 Then
                Console.ForegroundColor = ConsoleColor.Yellow
            ElseIf Colorcode = 4 Then
                Console.ForegroundColor = ConsoleColor.Green
            ElseIf Colorcode = 5 Then
                Console.ForegroundColor = ConsoleColor.Green
            ElseIf Colorcode = 6 Then
                Console.ForegroundColor = ConsoleColor.Cyan
            ElseIf Colorcode = 7 Then
                Console.ForegroundColor = ConsoleColor.Cyan
            ElseIf Colorcode = 8 Then
                Console.ForegroundColor = ConsoleColor.Magenta
            ElseIf Colorcode = 9 Then
                Console.ForegroundColor = ConsoleColor.Magenta
                Colorcode = 0
            End If

            Console.Write(Character)
            If Index = Text.Length Then
                Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
                Exit Function
            End If
            Index += 1
            Colorcode += 1
        Next

        Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
    End Function

    Public Function Tipper(ByVal Text As String)
        Dim Waserrors As Boolean = ErrorsOn
        ErrorsOn = False
        Dim OldVar As String = Text
        Dim Returner As String = AllFunctions((Text))
        If Returner = "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010" Then
            Return OldVar
        Else
            Return Returner
        End If
        ErrorsOn = Waserrors
    End Function

    Public Function copyright()
        Console.ForegroundColor = DefForeColor
        Console.BackgroundColor = DefBackColor

        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("" & _
       "  __     __  _____ ____ __    _ ______ ____" & vbCrLf & _
       " |  |   |  |/ ____|  __|  \  | | _____|  __|" & vbCrLf & _
       " |  |   |  | /    | |__|   \ | |____  | |__" & vbCrLf & _
       " |  |   |  ||     |  __| |\ \| |    | |  __|" & vbCrLf & _
       " |  |___|  | \____| |__| | \   |____| | |__" & vbCrLf & _
       " |______|__|\_____|____|_|  \__|______|____|" & vbCrLf & _
       "    COPYRIGHT © 2017-2018 Fabian Müller" & vbCrLf & _
       "" & vbCrLf & _
       "" & vbCrLf & _
                          "")
        Console.WriteLine("MIT License")
        Console.WriteLine("")
        Console.WriteLine("Copyright (c) 2017-2018 Fabian Müller (aka Paitorocxon)")
        Console.WriteLine("")
        Console.WriteLine("Permission is hereby granted, free of charge, to any person obtaining a copy")
        Console.WriteLine("of this software and associated documentation files (the ""Software""), to deal")
        Console.WriteLine("in the Software without restriction, including without limitation the rights")
        Console.WriteLine("to use, copy, modify, merge, publish, distribute, sublicense, and/or sell")
        Console.WriteLine("copies of the Software, and to permit persons to whom the Software is")
        Console.WriteLine("furnished to do so, subject to the following conditions:")
        Console.WriteLine("")
        Console.WriteLine("The above copyright notice and this permission notice shall be included in all")
        Console.WriteLine("copies or substantial portions of the Software.")
        Console.WriteLine("")
        Console.WriteLine("THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR")
        Console.WriteLine("IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,")
        Console.WriteLine("FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE")
        Console.WriteLine("AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER")
        Console.WriteLine("LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,")
        Console.WriteLine("OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE")
        Console.WriteLine("SOFTWARE.")


        Console.ForegroundColor = DefForeColor
        Console.BackgroundColor = DefBackColor
        Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
    End Function

    Public Function ErrorHandle(ByVal Message As String)
        If ErrorsOn = True Then
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine(Index0 & ":" & Message)
            Console.ForegroundColor = DefForeColor
        End If
        Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
    End Function



End Module
#Region "HTMLWebserver"
Public Class WebServer
    Public Shared Connections As Integer = 0
    Public Shared WebserverDomainName As String = "P.A.I.S Standard Webserver"
    Public Shared WriteLog As Boolean = False
    Public Shared Titles As String = Nothing
    Public Shared Webfoldername As String = "web"
    Public Shared logname As String = "log.log"




    Public Shared Sub Main()
        Console.ForegroundColor = ConsoleColor.White
        Startupanimation()
        If WebServer.WriteLog = True Then
            If My.Computer.FileSystem.FileExists(WebServer.Webfoldername & "\" & logname) Then
                IO.File.WriteAllText(WebServer.Webfoldername & "\" & logname, "Server started @" & My.Computer.Clock.LocalTime & vbCrLf & IO.File.ReadAllText(WebServer.Webfoldername & "\" & logname))
            Else

                IO.File.WriteAllText(WebServer.Webfoldername & "\" & logname, "Server started @" & My.Computer.Clock.LocalTime & vbCrLf & IO.File.ReadAllText(WebServer.Webfoldername & "\" & logname))
            End If
        End If
        Try
            Dim hostName As String = Dns.GetHostName()
            Dim Index As Integer = 0
            For Each IP As IPAddress In Dns.GetHostEntry(hostName).AddressList()
                console.writeline(Index & "= " & IP.ToString & vbCrLf, 5)
                Index += 1
            Next
            console.writeline("IP nr.:", 5)
            Console.ForegroundColor = ConsoleColor.Cyan
            Dim IpIndex As Integer = Console.ReadLine


            Dim serverIP As IPAddress = Dns.GetHostEntry(hostName).AddressList(IpIndex)
            console.writeline("Serverport (type 80 for default!)" & vbCrLf & "Port:", 5)
            Console.ForegroundColor = ConsoleColor.Yellow
            Dim Port As String = Console.ReadLine
            Dim tcpListener As New TcpListener(serverIP, Int32.Parse(Port))
            tcpListener.Start()
            Console.ForegroundColor = ConsoleColor.Green
            If WriteLog = True Then
                If My.Computer.FileSystem.FileExists(WebServer.Webfoldername & "\" & logname) Then
                    IO.File.WriteAllText(WebServer.Webfoldername & "\" & logname, "Setup (" & serverIP.ToString & ":" & Port & ") @" & My.Computer.Clock.LocalTime & vbCrLf & IO.File.ReadAllText(WebServer.Webfoldername & "\" & logname))
                Else

                    IO.File.WriteAllText(WebServer.Webfoldername & "\" & logname, "Setup (" & serverIP.ToString & ":" & Port & ") @" & My.Computer.Clock.LocalTime & vbCrLf & IO.File.ReadAllText(WebServer.Webfoldername & "\" & logname))
                End If

            End If
            Console.Write("IP: " & serverIP.ToString() & ":[" & Port & "]", 15)

            Console.ForegroundColor = DefForeColor
            Console.BackgroundColor = DefBackColor

            Console.WriteLine("")

            Process.Start("http://" & serverIP.ToString & "/")
            Dim httpSession As New HTTPSession(tcpListener)
            Dim serverThread As New Thread(New ThreadStart(AddressOf httpSession.ProcessThread))
            serverThread.Start()

        Catch ex As Exception
        End Try
    End Sub
    Public Shared Function Startupanimation()


        If WebServer.WriteLog = True Then
            If My.Computer.FileSystem.FileExists(WebServer.Webfoldername & "\" & logname) Then
            Else
                My.Computer.FileSystem.WriteAllText(WebServer.Webfoldername & "\" & logname, "", False)
            End If
        End If
        If My.Computer.FileSystem.DirectoryExists(Webfoldername) Then
        Else
            My.Computer.FileSystem.CreateDirectory(Webfoldername)
        End If
        If My.Computer.FileSystem.FileExists(WebServer.Webfoldername & "/index.html") Then
        Else
            My.Computer.FileSystem.WriteAllText(WebServer.Webfoldername & "/index.html", "<h1>Website, YEAH!</h1>", False)
        End If



        Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
    End Function
End Class
Public Class HTTPSession
    Private tcpListener As System.Net.Sockets.TcpListener
    Public Shared clientSocket As System.Net.Sockets.Socket
    Public Shared StopServer As Boolean = False
    Public Sub New(ByVal tcpListener As System.Net.Sockets.TcpListener)
        Me.tcpListener = tcpListener
    End Sub
    Public Sub ProcessThread()

        While (True)
            If StopServer = True Then

                Exit Sub

            End If
            Try
                clientSocket = tcpListener.AcceptSocket()
                ' Socket Information 
                Dim clientInfo As IPEndPoint = CType(clientSocket.RemoteEndPoint, IPEndPoint)
                Console.ForegroundColor = ConsoleColor.Cyan
                Console.WriteLine("FROM: " + clientInfo.Address.ToString() + ":" + clientInfo.Port.ToString())
                WebServer.Connections += 1
                If WebServer.WriteLog = True Then
                    If My.Computer.FileSystem.FileExists(WebServer.Webfoldername & "\" & WebServer.logname) Then
                        IO.File.WriteAllText(WebServer.Webfoldername & "\" & WebServer.logname, "FROM: " + clientInfo.Address.ToString() + ":" + clientInfo.Port.ToString() + " @" & My.Computer.Clock.LocalTime & vbCrLf & IO.File.ReadAllText(WebServer.Webfoldername & "\" & WebServer.logname))
                    Else

                        IO.File.WriteAllText(WebServer.Webfoldername & "\" & WebServer.logname, "FROM: " + clientInfo.Address.ToString() + ":" + clientInfo.Port.ToString() + " @" & My.Computer.Clock.LocalTime)
                    End If
                End If
                Console.ForegroundColor = DefForeColor
                Console.BackgroundColor = DefBackColor


                ' Set Thread for each Web Browser Connection

                Dim clientThread As New Thread(New ThreadStart(AddressOf ProcessRequest))
                clientThread.Start()
            Catch ex As Exception
                Console.ForegroundColor = ConsoleColor.Red
                If clientSocket.Connected Then
                    Try
                        If WebServer.WriteLog = True Then
                            Dim clientInfo As IPEndPoint = CType(clientSocket.RemoteEndPoint, IPEndPoint)
                            If My.Computer.FileSystem.FileExists(WebServer.Webfoldername & "\" & WebServer.logname) Then
                                IO.File.WriteAllText(WebServer.Webfoldername & "\" & WebServer.logname, "ERROR (" & clientInfo.Address.ToString() & ":" & clientInfo.Port.ToString & ") @" & My.Computer.Clock.LocalTime & vbCrLf & IO.File.ReadAllText(WebServer.Webfoldername & "\" & WebServer.logname))
                            Else

                                IO.File.WriteAllText(WebServer.Webfoldername & "\" & WebServer.logname, "ERROR (" & clientInfo.Address.ToString() & ":" & clientInfo.Port.ToString & ") @" & My.Computer.Clock.LocalTime & vbCrLf & IO.File.ReadAllText(WebServer.Webfoldername & "\" & WebServer.logname))
                            End If
                        End If
                    Catch exasdasd As Exception

                    End Try


                    clientSocket.Close()
                    console.writeline("Closed!", 10)
                End If
            End Try
        End While
    End Sub
    Protected Sub ProcessRequest()

        Dim recvBytes(1024) As Byte
        Dim htmlReq As String = Nothing
        Dim bytes As Int32
        Try
            ' Receive HTTP Request from Web Browser 
            bytes = clientSocket.Receive(recvBytes, 0, clientSocket.Available, SocketFlags.None)
            htmlReq = Encoding.ASCII.GetString(recvBytes, 0, bytes)
            Console.ForegroundColor = ConsoleColor.Magenta

            Console.WriteLine("HyperTextTransportProtocol [Request] ")
            Dim rootPath As String = Directory.GetCurrentDirectory() & "/" & WebServer.Webfoldername & "/"

            Console.ForegroundColor = DefForeColor
            Console.BackgroundColor = DefBackColor

            Console.ForegroundColor = ConsoleColor.Red
            Dim defaultPage As String = "index.html"
            Dim strArray() As String
            Dim strRequest As String
            strArray = htmlReq.Trim.Split(" ")
            If strArray(0).Trim().ToUpper.Equals("GET") Then

                strRequest = strArray(1).Trim
                If (strRequest.StartsWith("/")) Then
                    strRequest = strRequest.Substring(1)
                End If
                If (strRequest.EndsWith("/") Or strRequest.Equals("")) Then

                    strRequest = strRequest & defaultPage
                End If
                strRequest = rootPath & strRequest
                sendHTMLResponse(strRequest)
            Else
                strRequest = rootPath & "400.html"
                sendHTMLResponse(strRequest)
            End If
            Console.ForegroundColor = DefForeColor
            Console.BackgroundColor = DefBackColor


        Catch ex As Exception


            Try
                Dim clientInfo As IPEndPoint = CType(clientSocket.RemoteEndPoint, IPEndPoint)

                If WebServer.WriteLog Then
                    If My.Computer.FileSystem.FileExists(WebServer.Webfoldername & "\" & WebServer.logname) Then
                        IO.File.WriteAllText(WebServer.Webfoldername & "\" & WebServer.logname, "ERROR (" & clientInfo.Address.ToString() & ":" & clientInfo.Port.ToString & ") @" & My.Computer.Clock.LocalTime & vbCrLf & IO.File.ReadAllText(WebServer.Webfoldername & "\" & WebServer.logname))
                    Else

                        IO.File.WriteAllText(WebServer.Webfoldername & "\" & WebServer.logname, "ERROR (" & clientInfo.Address.ToString() & ":" & clientInfo.Port.ToString & ") @" & My.Computer.Clock.LocalTime & vbCrLf & IO.File.ReadAllText(WebServer.Webfoldername & "\" & WebServer.logname))
                    End If
                End If
            Catch exs As Exception

            End Try


            If clientSocket.Connected Then

                clientSocket.Close()
            End If
        End Try
    End Sub
    Private Sub sendHTMLResponse(ByVal httpRequest As String)



        Try

            'Get the file content of HTTP Request
            Dim streamReader As StreamReader = New StreamReader(httpRequest)
            Dim strBuff As String = streamReader.ReadToEnd()
            streamReader.Close()
            streamReader = Nothing
            ' The content Length of HTTP Request 
            Dim respByte() As Byte = Encoding.ASCII.GetBytes(strBuff)
            ' Set HTML Header 
            Console.ForegroundColor = ConsoleColor.Yellow
            Dim htmlHeader As String = _
                "HTTP/1.0 200 OK" & ControlChars.CrLf & _
                "Server:" & WebServer.WebserverDomainName & ControlChars.CrLf & _
                "Content-Length: " & respByte.Length & ControlChars.CrLf & _
                "Content-Type: " & getContentType(httpRequest) & _
                ControlChars.CrLf & ControlChars.CrLf
            ' The content Length of HTML Header
            Dim headerByte() As Byte = Encoding.ASCII.GetBytes(htmlHeader)
            Console.ForegroundColor = DefForeColor
            Console.BackgroundColor = DefBackColor

            clientSocket.Send(headerByte, 0, headerByte.Length, SocketFlags.None)
            clientSocket.Send(respByte, 0, respByte.Length, SocketFlags.None)
            clientSocket.Shutdown(SocketShutdown.Both)
            clientSocket.Close()
        Catch ex As Exception

            Dim clientInfo As IPEndPoint = CType(clientSocket.RemoteEndPoint, IPEndPoint)
            If WebServer.WriteLog = True Then

                If My.Computer.FileSystem.FileExists(WebServer.Webfoldername & "\" & WebServer.logname) Then
                    IO.File.WriteAllText(WebServer.Webfoldername & "\" & WebServer.logname, "ERROR (" & clientInfo.Address.ToString() & ":" & clientInfo.Port.ToString & ") @" & My.Computer.Clock.LocalTime & vbCrLf & IO.File.ReadAllText(WebServer.Webfoldername & "\" & WebServer.logname))
                Else

                    IO.File.WriteAllText(WebServer.Webfoldername & "\" & WebServer.logname, "ERROR (" & clientInfo.Address.ToString() & ":" & clientInfo.Port.ToString & ") @" & My.Computer.Clock.LocalTime & vbCrLf & IO.File.ReadAllText(WebServer.Webfoldername & "\" & WebServer.logname))
                End If
            End If
            If clientSocket.Connected Then
                clientSocket.Close()
            End If
            Console.ForegroundColor = DefForeColor
            Console.BackgroundColor = DefBackColor


        End Try
    End Sub

    Public Function ErrorHandle(ByVal errormessage As String)
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine(errormessage)
        Console.ForegroundColor = DefForeColor
        Return "100101010010010100100101001001010100100101001001010100100101010010010101001011100011001001010100100110010010001010010100100101001001010100100101001001010"
    End Function

    Private Function getContentType(ByVal httpRequest As String) As String
        Try
            If WebServer.WriteLog = True Then
                Dim clientInfo As IPEndPoint = CType(clientSocket.RemoteEndPoint, IPEndPoint)
                If My.Computer.FileSystem.FileExists(WebServer.Webfoldername & "\" & WebServer.logname) Then
                    IO.File.WriteAllText(WebServer.Webfoldername & "\" & WebServer.logname, "NAVIGATION (" & clientInfo.Address.ToString() & ":" & clientInfo.Port.ToString & ") (" & httpRequest & ")@" & My.Computer.Clock.LocalTime & vbCrLf & IO.File.ReadAllText(WebServer.Webfoldername & "\" & WebServer.logname))
                Else

                    IO.File.WriteAllText(WebServer.Webfoldername & "\" & WebServer.logname, "NAVIGATION (" & clientInfo.Address.ToString() & ":" & clientInfo.Port.ToString & ") (" & httpRequest & ")@" & My.Computer.Clock.LocalTime & vbCrLf & IO.File.ReadAllText(WebServer.Webfoldername & "\" & WebServer.logname))
                End If
            End If
        Catch ex As Exception

        End Try


        Console.WriteLine("Request:" & httpRequest)
        If (httpRequest.EndsWith("html")) Then
            Return "text/html"
        ElseIf (httpRequest.EndsWith("htm")) Then
            Return "text/html"
        ElseIf (httpRequest.EndsWith("txt")) Then
            Return "text/plain"
        ElseIf (httpRequest.EndsWith("gif")) Then
            Return "image/gif"
        ElseIf (httpRequest.EndsWith("jpg")) Then
            Return "image/jpeg"
        ElseIf (httpRequest.EndsWith("jpeg")) Then
            Return "image/jpeg"
        ElseIf (httpRequest.EndsWith("png")) Then
            Return "image/png"
        ElseIf (httpRequest.EndsWith("pdf")) Then
            Return "application/pdf"
        ElseIf (httpRequest.EndsWith("doc")) Then
            Return "application/msword"
        ElseIf (httpRequest.EndsWith("ppt")) Then
            Return "application/vnd.ms-powerpoint"
        ElseIf (httpRequest.EndsWith("flamable")) Then
            Return "text/xml"
        ElseIf (httpRequest.EndsWith("mp4")) Then
            Return "video/mp4"
        End If
        Return "text/plain"
    End Function

End Class
#End Region