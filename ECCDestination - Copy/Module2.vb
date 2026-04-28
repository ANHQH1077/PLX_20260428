Imports System.IO
Imports System.Windows.Forms
Module Module2
    Private g_DirectoryFilePath As String = Application.StartupPath
    Public Sub WritetoTxt(ByVal p_Desc As String)
        Dim strFile As String
        Dim sw As StreamWriter
        Dim outFile As IO.StreamWriter
        Dim fs As FileStream = Nothing

        Try
            Try
                If Strings.Right(g_DirectoryFilePath, 1) = "\" Then
                    strFile = g_DirectoryFilePath & "AALog_" & DateAdd(DateInterval.Day, -1, Now.Date).ToString("yyyyMMdd") & ".txt"


                Else
                    strFile = g_DirectoryFilePath & "\AALog_" & DateAdd(DateInterval.Day, -1, Now.Date).ToString("yyyyMMdd") & ".txt"
                End If
                If Dir(strFile) <> "" Then
                    IO.File.Delete(strFile)
                End If
            Catch ex As Exception

            End Try


            If Strings.Right(g_DirectoryFilePath, 1) = "\" Then
                strFile = g_DirectoryFilePath & "AALog_" & DateTime.Today.ToString("yyyyMMdd") & ".txt"


            Else
                strFile = g_DirectoryFilePath & "\AALog_" & DateTime.Today.ToString("yyyyMMdd") & ".txt"
            End If

            If Dir(strFile) <> "" Then
                outFile = My.Computer.FileSystem.OpenTextFileWriter(strFile, True)
            Else
                outFile = My.Computer.FileSystem.OpenTextFileWriter(strFile, False)
            End If



            ''outFile.WriteLine("Occured at-- " & DateTime.Now)
            outFile.WriteLine(p_Desc)
            outFile.Close()


        Catch ex As Exception

        End Try

    End Sub

End Module
