Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Reflection
Imports Microsoft.Office
'Imports Data.OleDb
'Imports Microsoft.Data.Odbc
Imports outlook = Microsoft.Office.Interop.Outlook

Public Class Form1
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim vBooking As String
        If txtContainer.Text <> "" Then
            vBooking = getBooking(txtContainer.Text.Trim.ToUpper)
        Else
            vBooking = txtBooking.Text.Trim.ToUpper
        End If

        getContainer(vBooking)
    End Sub


    Sub getContainer(vBooking As String)
        'If vBooking = "" Then
        '    MsgBox("Booking is required, please enter booking number")
        '    Exit Sub
        'End If
        clear()
        Dim dtBooking As DataTable
        dtBooking = getContainers(vBooking)
        Dim x As Integer = dtBooking.Rows.Count
        lblRecord.Text = Str(x) + " Container(s)"
        DataGridView1.DataSource = dtBooking
    End Sub

    Sub clear()
        txtContainer.Text = ""
        lblRecord.Text = ""
        txtPlateNumber.Text = ""
        lblContainer.Text = ""
        lblLocation.Text = ""
        rbA0.Checked = True
        rbXray.Checked = True
        'DataGridView1.DataSource = Nothing
    End Sub

    Friend Function getContainers(ByVal booking As String) As DataTable

        Dim cmd As New OdbcCommand
        Dim sqlBooking As String
        Dim da As New OdbcDataAdapter
        'Readconnectionstring()
        'Dim con As New OdbcConnection("Server='" & server & "';DATABASE='" & paraudstat.compid & "';Integrated Security='SSPI';")
        'Dim con As New OdbcConnection("Provider=MSDASQL;driver={SQL Server};Intial Catalog='SAMLTD';Data Source='ACCPAC';User Id='sa';Password='cats@123';") 'Trusted_Connection=Yes;") 'Trusted_Connection=Yes;persist security info=False;")

        'OdbcConnection
        Dim con As OdbcConnection
        Dim connectionString As String
        connectionString = "DSN=CTCS1;UserID=OPSCC;Password=OPSCC21;DataCompression=True;"
        con = New OdbcConnection(connectionString)
        con.Open()


        'sql = "SELECT 
        '        BOOKLIST.CNID94 as container,
        '        BOOKLIST.HIDT94 as date_in, 
        '        CTHNDL09.HDDT03 as date_out,
        '        BOOKLIST.CNPT03 as location,
        '        BOOKLIST.LYND03 as line,
        '        BOOKLIST.ORGV05 as agent,
        '        BOOKLIST.CNIS03 as iso,
        '        BOOKLIST.CNLL03 as size,
        '        BOOKLIST.ORRF93 as Booking,
        '        BOOKLIST.VMID01 as vessel_code,
        '        BOOKLIST.MVVA47 as vessel_name,
        '        BOOKLIST.MVV247 as vessel_type,
        '        BOOKLIST.RSIN01 as voy_in, 
        '        BOOKLIST.RSUT01 as voy_out, 
        '        BOOKLIST.OP0103 
        '        FROM S2114C2V.LCB1DAT.BOOKLIST BOOKLIST
        '        INNER JOIN CTHNDL09 ON BOOKLIST.HDID94 = CTHNDL09.HDID03
        '        where BOOKLIST.ORRF93 = ? "

        sqlBooking = "SELECT 
                BOOKLIST.CNID94 as container,
                BOOKLIST.HIDT94 as date_in, 
                BOOKLIST.CNPT03 as location,
                BOOKLIST.ORRF93 as Booking,
                BOOKLIST.LYND03 as line,
                BOOKLIST.ORGV05 as agent,
                BOOKLIST.CNIS03 as iso,
                BOOKLIST.CNLL03 as size,
                
                BOOKLIST.VMID01 as vessel_code,
                BOOKLIST.MVVA47 as vessel_name,
                BOOKLIST.MVV247 as vessel_type,
                BOOKLIST.RSIN01 as voy_in, 
                BOOKLIST.RSUT01 as voy_out, 
                BOOKLIST.OP0103 
                FROM S2114C2V.LCB1DAT.BOOKLIST BOOKLIST
                where BOOKLIST.ORRF93 = ? "

        ' Create an OleDbDataAdapter object
        Dim adapter As OdbcDataAdapter = New OdbcDataAdapter()
        'adapter.SelectCommand = New OdbcCommand(sql, con)


        Dim ds As New DataTable

        ' Create Data Set object
        'Dim ds As DataSet = New DataSet("orders")
        ' Call DataAdapter's Fill method to fill data from the
        ' DataAdapter to the DataSet 
        'adapter.Fill(ds)

        With cmd

            .CommandType = CommandType.Text
            .Connection = con
            .CommandTimeout = 100

            .CommandText = sqlBooking
            .Parameters.Add(New OdbcParameter("booking", booking))

        End With



        'In case Search Booking by Container

        da.SelectCommand = cmd
        da.Fill(ds)





        Return ds


    End Function


    Friend Function getBooking(container As String) As String

        Dim cmd As New OdbcCommand
        Dim sqlContainer As String
        Dim da As New OdbcDataAdapter

        'OdbcConnection
        Dim con As OdbcConnection
        Dim connectionString As String
        connectionString = "DSN=CTCS1;UserID=OPSCC;Password=OPSCC21;DataCompression=True;"
        con = New OdbcConnection(connectionString)
        con.Open()



        sqlContainer = "SELECT 
                BOOKLIST.CNID94 as container,
                BOOKLIST.HIDT94 as date_in, 
                BOOKLIST.CNPT03 as location,
                BOOKLIST.ORRF93 as Booking,
                BOOKLIST.LYND03 as line,
                BOOKLIST.ORGV05 as agent,
                BOOKLIST.CNIS03 as iso,
                BOOKLIST.CNLL03 as size,  
                BOOKLIST.VMID01 as vessel_code,
                BOOKLIST.MVVA47 as vessel_name,
                BOOKLIST.MVV247 as vessel_type,
                BOOKLIST.RSIN01 as voy_in, 
                BOOKLIST.RSUT01 as voy_out, 
                BOOKLIST.OP0103 
                FROM S2114C2V.LCB1DAT.BOOKLIST BOOKLIST
                where BOOKLIST.CNID94 = ? "



        ' Create an OleDbDataAdapter object
        Dim adapter As OdbcDataAdapter = New OdbcDataAdapter()

        With cmd

            .CommandType = CommandType.Text
            .Connection = con
            .CommandTimeout = 100

            .CommandText = sqlContainer
            .Parameters.Add(New OdbcParameter("container", container))

        End With
        'In case Search Booking by Container
        Dim dsContainer As New DataTable
        da.SelectCommand = cmd
        da.Fill(dsContainer)


        Dim lastRow As DataRow
        lastRow = dsContainer.Rows.Cast(Of DataRow)().LastOrDefault()

        If lastRow Is Nothing Then
            'The table contains no rows.
            Return ""
        Else
            'Use lastRow here.
            Return lastRow.Item("booking").trim()

        End If



    End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'Dim selectedCellCount As String = DataGridView1.SelectedRows(0).Cells(0).ToString
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        lblContainer.Text = DataGridView1.Item(0, i).Value
        lblLocation.Text = DataGridView1.Item(2, i).Value
        lblBooking.Text = DataGridView1.Item(3, i).Value

        Dim vAgent As String = Trim(DataGridView1.Item(5, i).Value)
        rbA0.Checked = True
        rbB1.Checked = IIf(vAgent = "MSK1" Or vAgent = "MSC", True, False)
        'rbB1.Checked = IIf(vAgent = "MSC", True, False)

        'MsgBox(selectedCellCount)
    End Sub

    Private Sub fill_to_excel(vContainer As String, vPosition As String,
                              vTerminal As String, vPlate As String,
                              vType As String, vBooking As String)
        Dim xlsWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlsWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim xls As New Microsoft.Office.Interop.Excel.Application

        'Dim resourcesFolder = IO.Path.GetFullPath(Application.StartupPath & "\..\..\Resources\")
        Dim resourcesFolder = IO.Path.GetFullPath(Application.StartupPath & "\")
        Dim fileName = "FastlaneTemplate.xlsx"

        xlsWorkBook = xls.Workbooks.Open(resourcesFolder & fileName)
        xlsWorkSheet = xlsWorkBook.Sheets("Sheet2")

        Dim vNewPosition As String
        If vPosition.Length = 9 Then
            vNewPosition = Mid(vPosition, 1, 3) & "-" & Mid(vPosition, 4, 2) & "-" & Mid(vPosition, 6, 2)
        Else
            vNewPosition = vPosition
        End If
        xlsWorkSheet.Cells(5, 2) = Now()
        xlsWorkSheet.Cells(6, 2) = vType
        xlsWorkSheet.Cells(7, 2) = vBooking
        xlsWorkSheet.Cells(7, 10) = vPlate
        xlsWorkSheet.Cells(6, 10) = vTerminal
        xlsWorkSheet.Cells(9, 10) = vNewPosition

        xlsWorkSheet.Cells(9, 2) = vContainer


        'xlsWorkBook.Close()
        'xls.Quit()

        xls.DisplayAlerts = False


        xlsWorkBook.Close(True)



        releaseObject(xlsWorkSheet)
        releaseObject(xlsWorkBook)
        releaseObject(xls)

        'MsgBox("file saved to " & resourcesFolder)

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        start_print_process()
    End Sub

    Sub start_print_process()
        If txtPlateNumber.Text = "" Then
            MsgBox("Plate number is required, please enter!!")
            txtPlateNumber.Focus()
            Exit Sub
        End If
        Dim vBody As String = "<h1>Request for : " & IIf(rbXray.Checked, "X-RAY", "เปิดตรวจ") & "  of " & lblContainer.Text.Trim & "</h1> <br>
                                   <table border=""1"">
                                        <tr>
                                            <th>Item</th>
                                            <th>Value</th>
                                        </tr>
                                        <tr>
                                            <td>Container:</td>
                                            <td>" & lblContainer.Text.Trim & "</td>
                                        </tr>
                                        <tr>
                                            <td>Terminal:</td>
                                            <td>" & IIf(rbA0.Checked, "A0", "B1") & "</td>
                                        </tr>

                                        <tr>
                                            <td>Truck plate:</td>
                                            <td>" & txtPlateNumber.Text.Trim.ToUpper & "</td>
                                        </tr>
                                        <tr>
                                            <td>Position:</td>
                                            <td>" & lblLocation.Text.Trim & "</td>
                                        </tr>
                                        <tr>
                                            <td>Request Date:</td>
                                            <td>" & Now() & "</td>
                                        </tr>
                                    </table><br><hr>
                                    <b>Note : Do not reply. This message sent from auto Cashier system.</b>"

        Dim vMailSubject As String = "Fast-lane " & IIf(rbXray.Checked, "X-RAY", "เปิดตรวจ") & " request :" & lblContainer.Text.Trim & " " &
                                    " --- truck : " & txtPlateNumber.Text.Trim.ToUpper & " [" & IIf(rbA0.Checked, "A0", "B1") & "]"

        fill_to_excel(lblContainer.Text.Trim,
                      lblLocation.Text.Trim,
                      IIf(rbA0.Checked, "A0", "B1"),
                      txtPlateNumber.Text.Trim.ToUpper,
                      IIf(rbXray.Checked, "X-RAY", "เปิดตรวจ"),
                      lblBooking.Text.Trim)

        print_excel()

        txtPlateNumber.Text = ""

        'SendKeys Email
        If chkSendmail.Checked Then

            Dim mailTo As String
            If My.Computer.FileSystem.FileExists("mail_list.txt") Then
                mailTo = My.Computer.FileSystem.ReadAllText("mail_list.txt")
                If mailTo = "" Then
                    MsgBox("No email list in file")
                    Exit Sub
                End If


                setEmailSend(vMailSubject,
                              vBody,
                              mailTo,
                              "",
                             "",
                             "")
            Else
                MsgBox("Not found mail_list.txt , syytem will not send mail")
            End If

        End If

    End Sub


    Sub print_excel()
        Dim strFile As String = "FastlaneTemplate.xlsx"
        Dim objProcess As New System.Diagnostics.ProcessStartInfo

        With objProcess
            .FileName = strFile
            .WindowStyle = ProcessWindowStyle.Hidden
            .Verb = "print"


            .CreateNoWindow = True
            .UseShellExecute = True
        End With
        Try
            System.Diagnostics.Process.Start(objProcess)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub txtBooking_TextChanged(sender As Object, e As EventArgs) Handles txtBooking.TextChanged
        txtContainer.Text = ""
    End Sub

    Private Sub txtBooking_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBooking.KeyPress
        If e.KeyChar = Chr(13) Then
            getContainer(txtBooking.Text.Trim)
        End If

    End Sub


    Private Sub txtPlateNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPlateNumber.KeyPress
        If e.KeyChar = Chr(13) Then
            start_print_process()
        End If
    End Sub

    Private Sub txtContainer_TextChanged(sender As Object, e As EventArgs) Handles txtContainer.TextChanged
        txtBooking.Text = ""
    End Sub

    Private Sub txtContainer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContainer.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim vBooking As String
            vBooking = getBooking(txtContainer.Text.Trim.ToUpper)
            getContainer(vBooking)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clear()
        'setEmailSend("Test Subject", "<b1><u>Test Body</u></b1>", "chutchai@lcb1.com", "", "", "test Display")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim versionNumber As Version

        versionNumber = Assembly.GetExecutingAssembly().GetName().Version
        Me.Text = Me.Text & " version :" & versionNumber.ToString
    End Sub


    Private Sub setEmailSend(sSubject As String, sBody As String,
                             sTo As String, sCC As String,
                             sFilename As String, sDisplayname As String)
        Dim oApp As Interop.Outlook._Application
        oApp = New Interop.Outlook.Application

        Dim oMsg As Interop.Outlook._MailItem
        oMsg = oApp.CreateItem(Interop.Outlook.OlItemType.olMailItem)

        oMsg.Subject = sSubject
        'oMsg.Body = sBody
        oMsg.HTMLBody = sBody

        oMsg.To = sTo
        oMsg.CC = sCC

        oMsg.BodyFormat = outlook.OlBodyFormat.olFormatHTML


        Dim strS As String = sFilename
        Dim strN As String = sDisplayname
        If sFilename <> "" Then
            Dim sBodyLen As Integer = Int(sBody.Length)
            Dim oAttachs As Interop.Outlook.Attachments = oMsg.Attachments
            Dim oAttach As Interop.Outlook.Attachment

            oAttach = oAttachs.Add(strS, , sBodyLen, strN)

        End If

        oMsg.Send()
        MessageBox.Show("Email Send successful...", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    End Sub
End Class
