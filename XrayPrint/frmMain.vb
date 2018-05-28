Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Data.SqlClient
'Imports Data.OleDb
'Imports Microsoft.Data.Odbc

Public Class Form1
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        getContainer(txtBooking.Text.Trim.ToUpper)
    End Sub

    Sub getContainer(vBooking As String)
        If vBooking = "" Then
            MsgBox("Booking is required, please enter booking number")
            Exit Sub
        End If
        clear()
        Dim dtBooking As DataTable
        dtBooking = accbynodes(vBooking)
        Dim x As Integer = dtBooking.Rows.Count
        lblRecord.Text = Str(x) + " Container(s)"
        DataGridView1.DataSource = dtBooking
    End Sub

    Sub clear()
        lblRecord.Text = ""
        txtPlateNumber.Text = ""
        lblContainer.Text = ""
        lblLocation.Text = ""
        rbA0.Checked = True
        rbXray.Checked = True
    End Sub

    Friend Function accbynodes(ByVal booking As String) As DataTable

        Dim cmd As New OdbcCommand
        Dim sql As String
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


        sql = "SELECT 
                BOOKLIST.CNID94 as container,
                BOOKLIST.HIDT94 as date_in, 
                CTHNDL09.HDDT03 as date_out,
                BOOKLIST.CNPT03 as location,
                BOOKLIST.LYND03 as line,
                BOOKLIST.ORGV05 as agent,
                BOOKLIST.CNIS03 as iso,
                BOOKLIST.CNLL03 as size,
                BOOKLIST.ORRF93 as Booking,
                BOOKLIST.VMID01 as vessel_code,
                BOOKLIST.MVVA47 as vessel_name,
                BOOKLIST.MVV247 as vessel_type,
                BOOKLIST.RSIN01 as voy_in, 
                BOOKLIST.RSUT01 as voy_out, 
                BOOKLIST.OP0103 
                FROM S2114C2V.LCB1DAT.BOOKLIST BOOKLIST
                INNER JOIN CTHNDL09 ON BOOKLIST.HDID94 = CTHNDL09.HDID03
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
            .CommandText = sql
            .CommandType = CommandType.Text
            .Connection = con
            .CommandTimeout = 100
            .Parameters.Add(New OdbcParameter("booking", booking))

        End With


        da.SelectCommand = cmd
        da.Fill(ds)

        Return ds


    End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'Dim selectedCellCount As String = DataGridView1.SelectedRows(0).Cells(0).ToString
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        lblContainer.Text = DataGridView1.Item(0, i).Value
        lblLocation.Text = DataGridView1.Item(3, i).Value

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

        fill_to_excel(lblContainer.Text.Trim,
                      lblLocation.Text.Trim,
                      IIf(rbA0.Checked, "A0", "B1"),
                      txtPlateNumber.Text.Trim.ToUpper,
                      IIf(rbXray.Checked, "X-RAY", "เปิดตรวจ"),
                      txtBooking.Text.Trim.ToUpper)

        print_excel()

        txtPlateNumber.Text = ""

        'If PrintDialog1.ShowDialog = DialogResult.OK Then
        '    ' print the document
        '    print_excel()
        'End If
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
End Class
