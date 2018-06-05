Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.IO

Public Class frmManifestImport

    Dim dtBooking As DataTable

    Friend Function getContainers(ByVal booking As String) As DataTable

        Dim cmd As New SqlCommand
        Dim sqlBooking As String
        Dim da As New SqlDataAdapter
        'Readconnectionstring()
        'Dim con As New OdbcConnection("Server='" & server & "';DATABASE='" & paraudstat.compid & "';Integrated Security='SSPI';")
        'Dim con As New OdbcConnection("Provider=MSDASQL;driver={SQL Server};Intial Catalog='SAMLTD';Data Source='ACCPAC';User Id='sa';Password='cats@123';") 'Trusted_Connection=Yes;") 'Trusted_Connection=Yes;persist security info=False;")

        'OdbcConnection
        Dim con As SqlConnection
        Dim connectionString As String
        connectionString = "Server=192.168.10.53;Database=GoodsTransit;User Id=goods;
                            Password=password;"
        con = New SqlConnection(connectionString)
        con.Open()

        sqlBooking = " SELECT 
                        masterbl as booking,
                        containerdetail_number as container,
                        callsign,
                        voyagenumber as voy,
                        berthdate
                 FROM MMAN
                 where masterbl = @booking"

        ' Create an OleDbDataAdapter object
        Dim adapter As SqlDataAdapter = New SqlDataAdapter()
        'adapter.SelectCommand = New OdbcCommand(sql, con)


        Dim ds As New DataTable


        With cmd

            .CommandType = CommandType.Text
            .Connection = con
            .CommandTimeout = 100

            .CommandText = sqlBooking
            .Parameters.Add(New SqlParameter("@booking", booking))

        End With



        'In case Search Booking by Container

        da.SelectCommand = cmd
        da.Fill(ds)





        Return ds


    End Function

    Private Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click
        Dim vBooking As String
        vBooking = txtBooking.Text.Trim.ToUpper
        getContainer(vBooking)
    End Sub

    Sub getContainer(vBooking As String)

        dtBooking = getContainers(vBooking)
        Dim x As Integer = dtBooking.Rows.Count
        lblRecord.Text = Str(x) + " Container(s)"
        DataGridView1.DataSource = dtBooking
        If x > 0 Then
            txtAgent.Enabled = True
            txtLine.Enabled = True
        Else
            txtAgent.Enabled = False
            txtLine.Enabled = False
            btnFullout.Enabled = False
        End If
    End Sub

    Private Sub btnFullout_Click(sender As Object, e As EventArgs) Handles btnFullout.Click
        createFullOutText(dtBooking, txtLine.Text.Trim, txtAgent.Text.Trim)
        RunCommandCom("execute_fullout.bat", "", False)
    End Sub

    Public Shared Sub createFullOutText(dt As DataTable, vLine As String, vAgent As String)
        Dim path As String = "fullout.txt"

        If File.Exists(path) Then
            File.Delete(path)
        End If

        ' Create a file to write to.
        Using sw As StreamWriter = File.AppendText(path)
            Dim strDetail As String
            For Each row As DataRow In dt.Rows
                strDetail = row("booking") &
                    "|" & row("container") &
                    "|" & vLine.Trim.ToUpper &
                    "|" & vAgent.Trim.ToUpper &
                    "|" & "FULL OUT AUTO (AUTO cashier)"
                sw.WriteLine(strDetail)
            Next row
        End Using

        '' Open the file to read from. 
        'Using sr As StreamReader = File.OpenText(path)
        '    Do While sr.Peek() >= 0
        '        Console.WriteLine(sr.ReadLine())
        '    Loop
        'End Using

    End Sub

    Sub RunCommandCom(command As String, arguments As String, permanent As Boolean)
        If File.Exists(Application.StartupPath & "\" & command) Then
            Shell(Application.StartupPath & "\" & command, AppWinStyle.MaximizedFocus, True)
            'ShellandWaitX(Application.StartupPath & "\" & command, "")
        Else
            MsgBox("Not found")
        End If

    End Sub

    Private Sub txtBooking_TextChanged(sender As Object, e As EventArgs) Handles txtBooking.TextChanged
        txtAgent.Text = ""
        txtLine.Text = ""
        btnFullout.Enabled = False
        DataGridView1.DataSource = Nothing
        If File.Exists("fullout.txt") Then
            File.Delete("fullout.txt")
        End If
    End Sub


    Private Sub txtBooking_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBooking.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim vBooking As String
            vBooking = txtBooking.Text.Trim.ToUpper
            getContainer(vBooking)
        End If
    End Sub

    Private Sub txtLine_TextChanged(sender As Object, e As EventArgs) Handles txtLine.TextChanged
        If txtLine.Text <> "" And txtAgent.Text <> "" Then
            btnFullout.Enabled = True
        Else
            btnFullout.Enabled = False
        End If
    End Sub

    Private Sub txtAgent_TextChanged(sender As Object, e As EventArgs) Handles txtAgent.TextChanged
        If txtLine.Text <> "" And txtAgent.Text <> "" Then
            btnFullout.Enabled = True
        Else
            btnFullout.Enabled = False
        End If
    End Sub

    'Sub ShellandWaitX(ByVal ProcessPath As String, ByVal Arguments As String)
    '    Dim objProcess As System.Diagnostics.Process
    '    Try
    '        objProcess = New System.Diagnostics.Process()
    '        objProcess.StartInfo.Arguments = Arguments
    '        objProcess.StartInfo.FileName = ProcessPath
    '        objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
    '        objProcess.Start()
    '        'Wait until it's finished
    '        objProcess.WaitForExit()
    '        'Exitcode as String
    '        Console.WriteLine(objProcess.ExitCode.ToString())
    '        objProcess.Close()
    '    Catch ex As Exception
    '        Console.WriteLine("Could not start process " & ProcessPath & "  " & ex.Message.ToString)
    '    End Try

    'End Sub

End Class