Module Module1
    Dim n As String
    Dim totalLoker As Integer
    Dim exe As String
    Dim cmd As String = ""
    Dim command As String = ""
    Dim listOfString As List(Of String) = New List(Of String)
    Dim dt As New DataTable
    Dim nData As Integer = 0

    Sub Main()
        cmd = Console.ReadLine()
        If cmd <> "status" Then
            checkCommand(cmd)
        Else
            checkStatus()
        End If

    End Sub

    Sub checkStatus()
        Console.WriteLine("No Loker " & vbTab & " Tipe Identitas " & vbTab & "  No Identitas")
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim no As String = Convert.ToString(dt.Rows(i)(0))
            Dim pengenal As String = Convert.ToString(dt.Rows(i)(1))
            Dim noPengenal As String = Convert.ToString(dt.Rows(i)(2))
            Console.WriteLine(no & vbTab & vbTab & pengenal & vbTab & vbTab & noPengenal)
        Next

    End Sub

    Sub checkCommand(ByRef cmd As String)
        While cmd.Length > 2
            For i As Integer = 0 To cmd.Length - 1
                If cmd(i).ToString() = " " Then
                    command = cmd.Remove(i, cmd.Length - i)
                    n = cmd.Substring(command.Length + 1)

                    If command = "init" Then
                        For iColumns As Integer = 0 To 2 'add column
                            dt.Columns.Add()
                        Next

                        For iCreate As Integer = 0 To n - 1
                            dt.Rows.Add()
                            dt.Rows(iCreate)(0) = iCreate + 1
                            dt.Rows(iCreate)(1) = ""
                            dt.Rows(iCreate)(2) = ""
                        Next
                        Console.WriteLine("Berhasil membuat loker dengan jumlah " & n)

                    Else
                        If dt.Rows.Count = 0 Then
                            Console.WriteLine("Silahkan masukan jumlah loker terlebih dahulu")
                            Exit For
                        End If

                        If command = "input" Then
                            If nData > dt.Rows.Count - 1 Then
                                Console.WriteLine("Maaf loker sudah penuh")
                            End If

                            For counter As Integer = nData To dt.Rows.Count - 1
                                If dt.Rows(counter)(1) = "" And dt.Rows(counter)(2) = "" Then
                                    dt.Rows(counter)(1) = Convert.ToString(n.Substring(0, n.IndexOf(" ")))
                                    dt.Rows(counter)(2) = Convert.ToString(n.Substring(n.IndexOf(" ") + 1))
                                    Console.WriteLine("Kartu identitas disimpan di loker nomor " & dt.Rows(counter)(0))
                                    nData = nData + 1
                                    Exit For
                                Else
                                    nData = nData + 1
                                End If
                            Next
                        ElseIf command = "leave" Then
                            If n > dt.Rows.Count Then
                                Console.WriteLine("Loker yang dimasukan lebih besar daripada jumlah loker, mohon masukan nomor loker dengan benar")
                            Else
                                dt.Rows(n - 1)(1) = ""
                                dt.Rows(n - 1)(2) = ""
                                Console.WriteLine("Loker nomor " & n & " berhasil dikosongkan")
                                nData = 0
                            End If

                        ElseIf command = "find" Then
                            Dim status As Boolean
                            Dim val As Integer
                            For counter As Integer = 0 To dt.Rows.Count - 1
                                If dt.Rows(counter)(2) = Convert.ToString(n.Substring(n.IndexOf(" ") + 1)) Then
                                    status = True
                                    val = counter + 1
                                    Exit For
                                Else
                                    status = False
                                End If
                            Next

                            If status = True Then
                                Console.WriteLine("Kartu identitas tersebut berada di loker nomor " & val)
                            Else
                                Console.WriteLine("Kartu identitas tersebut tidak ditemukan")
                            End If

                        ElseIf command = "search" Then
                            Dim output As String = ""
                            Dim status As Boolean
                            For counter As Integer = 0 To dt.Rows.Count - 1
                                If dt.Rows(counter)(1) = Convert.ToString(n) Then
                                    If output <> "Data tidak ditemukan" Then
                                        output += dt.Rows(counter)(2) & ","
                                    Else
                                        output = dt.Rows(counter)(2) & ","
                                    End If
                                    status = True
                                Else
                                    If output = "" Then
                                        output = "Data tidak ditemukan"
                                        status = False
                                    End If
                                End If
                            Next

                            If status = True Then
                                Console.Write(output.Substring(0, output.Length - 1) & vbCrLf)
                            Else
                                Console.WriteLine(output)
                            End If
                        End If
                    End If
                End If
            Next

            Main()
        End While
    End Sub
End Module