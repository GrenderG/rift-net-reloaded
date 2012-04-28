﻿Public Class BaseWriter
    Implements IDisposable

    Public Enum LogType
        NETWORK                 'Network code debugging
        DEBUG                   'Packets processing
        INFORMATION             'User information
        USER                    'User actions
        SUCCESS                 'Normal operation
        WARNING                 'Warning
        FAILED                  'Processing Error
        CRITICAL                'Application Error
    End Enum
    Public L() As Char = {"N", "D", "I", "U", "S", "W", "F", "C"}

    Public LogLevel As LogType = LogType.NETWORK

    Public Sub New()
    End Sub
    Public Overridable Sub Dispose() Implements System.IDisposable.Dispose
    End Sub
    Public Overridable Sub Write(ByVal type As LogType, ByVal format As String, ByVal ParamArray arg() As Object)
    End Sub
    Public Overridable Sub WriteLine(ByVal type As LogType, ByVal format As String, ByVal ParamArray arg() As Object)
    End Sub
    Public Overridable Function ReadLine() As String
        Return Console.ReadLine()
    End Function


    Public Sub PrintDiagnosticTest()
        WriteLine(LogType.NETWORK, "{0}:************************* TEST *************************", 1)
        WriteLine(LogType.DEBUG, "{0}:************************* TEST *************************", 1)
        WriteLine(LogType.INFORMATION, "{0}:************************* TEST *************************", 1)
        WriteLine(LogType.USER, "{0}:************************* TEST *************************", 1)
        WriteLine(LogType.SUCCESS, "{0}:************************* TEST *************************", 1)
        WriteLine(LogType.WARNING, "{0}:************************* TEST *************************", 1)
        WriteLine(LogType.FAILED, "{0}:************************* TEST *************************", 1)
        WriteLine(LogType.CRITICAL, "{0}:************************* TEST *************************", 1)
    End Sub

    Public Shared Sub CreateLog(ByVal LogType As String, ByVal LogConfig As String, ByRef Log As BaseWriter)
        Try
            Select Case UCase(LogType)
                Case "COLORCONSOLE"
                    Log = New ColoredConsoleWriter
                Case "CONSOLE"
                    Log = New ConsoleWriter
                Case "FILE"
                    Log = New FileWriter(LogConfig)
            End Select
        Catch e As Exception
            Console.WriteLine("[{0}] Error creating log output!" & vbNewLine & e.ToString, Format(TimeOfDay, "HH:mm:ss"))
        End Try
    End Sub




End Class
