Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class frmReport
    Dim dtInspection As DataTable
    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDateFrom.Text = Format(Now(), "yyyy/MM/dd")
        txtDateTo.Text = Format(Now(), "yyyy/MM/dd")
    End Sub


    Function getInspection(ByVal from_ As String, to_ As String) As DataTable

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

        sqlBooking = " SELECT *
                    FROM container_inspection 
                    where issue_date between '" & from_ & "' and '" & to_ & " 23:59:59.999' " &
                    "order by issue_date desc"

        ' Create an OleDbDataAdapter object
        Dim adapter As SqlDataAdapter = New SqlDataAdapter()
        'adapter.SelectCommand = New OdbcCommand(sql, con)


        Dim ds As New DataTable


        With cmd

            .CommandType = CommandType.Text
            .Connection = con
            .CommandTimeout = 100

            .CommandText = sqlBooking
            '.Parameters.Add(New SqlParameter("@booking", booking))

        End With



        'In case Search Booking by Container

        da.SelectCommand = cmd
        da.Fill(ds)

        con.Close()



        Return ds


    End Function

    Function getBooking(ByVal from_ As String, to_ As String) As DataTable

        Dim cmd As New SqlCommand
        Dim sqlBooking As String
        Dim da As New SqlDataAdapter

        'OdbcConnection
        Dim con As SqlConnection
        Dim connectionString As String
        connectionString = "Server=192.168.10.53;Database=GoodsTransit;User Id=goods;
                            Password=password;"
        con = New SqlConnection(connectionString)
        con.Open()

        sqlBooking = " SELECT issue_date,booking,terminal,line,agent,consignee 
                    FROM booking_import  
                    where issue_date between '" & from_ & "' and '" & to_ & " 23:59:59.999' " &
                    "order by issue_date desc"

        ' Create an OleDbDataAdapter object
        Dim adapter As SqlDataAdapter = New SqlDataAdapter()
        'adapter.SelectCommand = New OdbcCommand(sql, con)


        Dim ds As New DataTable


        With cmd

            .CommandType = CommandType.Text
            .Connection = con
            .CommandTimeout = 100

            .CommandText = sqlBooking
            '.Parameters.Add(New SqlParameter("@booking", booking))

        End With



        'In case Search Booking by Container

        da.SelectCommand = cmd
        da.Fill(ds)

        con.Close()



        Return ds


    End Function

    Private Sub btnXray_Click(sender As Object, e As EventArgs) Handles btnXray.Click


        dtInspection = getInspection(txtDateFrom.Text, txtDateTo.Text)
        Dim x As Integer = dtInspection.Rows.Count
        lblRecord.Text = Str(x) + " Container(s)"
        DataGridView1.DataSource = dtInspection

        ' Resize the master DataGridView columns to fit the newly loaded data.
        DataGridView1.AutoResizeColumns()

        ' Configure the details DataGridView so that its columns automatically
        ' adjust their widths when the data changes.
        DataGridView1.AutoSizeColumnsMode =
        DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub btnBooking_Click(sender As Object, e As EventArgs) Handles btnBooking.Click
        dtInspection = getBooking(txtDateFrom.Text, txtDateTo.Text)
        Dim x As Integer = dtInspection.Rows.Count
        lblRecord.Text = Str(x) + " Booking(s)"
        DataGridView1.DataSource = dtInspection

        ' Resize the master DataGridView columns to fit the newly loaded data.
        DataGridView1.AutoResizeColumns()

        ' Configure the details DataGridView so that its columns automatically
        ' adjust their widths when the data changes.
        DataGridView1.AutoSizeColumnsMode =
        DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub ExportToExcel(ByVal dtTemp As DataTable, ByVal filepath As String)
        Dim strFileName As String = filepath
        If System.IO.File.Exists(strFileName) Then
            If (MessageBox.Show("Do you want to replace from the existing file?", "Export to Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes) Then
                System.IO.File.Delete(strFileName)
            Else
                Return
            End If

        End If
        Dim _excel As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        wBook = _excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()

        Dim dt As System.Data.DataTable = dtTemp
        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0

        Dim vPreviousLine As String = ""


        'Add Column
        'With dt
        '    .Columns.Add("day")
        '    .Columns.Add("free")
        '    .Columns.Add("total")
        '    .Columns.Add("1-3 day")
        '    .Columns.Add("4-10 day")
        '    .Columns.Add("over 10 day")
        'End With
        colIndex = 0
        rowIndex = 0
        For Each dr In dt.Rows
            'Create Sheet per Line
            'If vPreviousLine <> dr("line") Then

            'wSheet = wBook.Sheets.Add()
            'wSheet.Name = dr("line")
            If rowIndex = 0 Then
                For Each dc In dt.Columns
                    colIndex = colIndex + 1
                    wSheet.Cells(1, colIndex) = dc.ColumnName
                Next
            End If

            '  vPreviousLine = dr("line")
            ' End If
            '-----------------------------------
            If rowIndex > 0 Then
                For Each dc In dt.Columns
                    colIndex = colIndex + 1
                    wSheet.Cells(rowIndex + 1, colIndex) = "'" & dr(dc.ColumnName)
                    'If dc.ColumnName = "ITEM" Then
                    '    wSheet.Cells(rowIndex + 1, colIndex) = rowIndex
                    'End If
                Next
            End If
            rowIndex = rowIndex + 1
            colIndex = 0
            'colIndex = colIndex - 6
            'Dim d, free, total As Integer
            'd = calculate_day(dr("in"), dr("out"))
            'free = 7
            'total = IIf(free >= d, 0, d - free)
            'wSheet.Cells(rowIndex + 1, colIndex + 1) = d 'Day
            'wSheet.Cells(rowIndex + 1, colIndex + 2) = free 'Free
            'wSheet.Cells(rowIndex + 1, colIndex + 3) = total 'Total
            'wSheet.Cells(rowIndex + 1, colIndex + 4) = IIf(total > 3, 3, total) '1-3
            'wSheet.Cells(rowIndex + 1, colIndex + 5) = IIf(total > 10, 7, IIf(total - 3 < 0, 0, total - 3)) '4-10
            'wSheet.Cells(rowIndex + 1, colIndex + 6) = IIf(total > 10, total - 10, 0) 'Over10

            'wSheet.Columns.AutoFit()
        Next
        wSheet.Columns.AutoFit()



        wBook.SaveAs(strFileName)

        ReleaseObject(wSheet)
        wBook.Close(False)
        ReleaseObject(wBook)
        _excel.Quit()
        ReleaseObject(_excel)
        GC.Collect()

        MessageBox.Show("File Export Successfully!")
        System.Diagnostics.Process.Start(filepath)
    End Sub
    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ExportToExcel(dtInspection, "d:\report_" & txtDateTo.Text.Replace("/", "-") & ".xlsx")
    End Sub
End Class