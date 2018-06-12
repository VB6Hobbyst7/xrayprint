Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Reflection

Public Class frmManifestImport

    Dim dtBooking As DataTable
    Dim dtDwell As DataTable
    Dim dtTarrifList As New DataTable
    Dim dtItem As New DataTable

    Function get_containers_list() As String
        Dim vList As String = ""
        For Each row As DataRow In dtBooking.Rows
            vList = vList & "    '" & row("container") & "',"
        Next
        Return Mid(vList, 1, Len(vList) - 1)
    End Function

    Friend Function getDwell(ByVal continerList As String,
                             callSign As String,
                             voy As String) As DataTable

        Dim cmd As New OdbcCommand
        Dim sqlBooking As String
        Dim da As New OdbcDataAdapter

        Dim con As OdbcConnection
        Dim connectionString As String
        connectionString = "DSN=CTCS1;UserID=OPSCC;Password=OPSCC21;DataCompression=True;"
        con = New OdbcConnection(connectionString)
        con.Open()
        '                HDTD03 as time_in,
        sqlBooking = "SELECT 
                CNID03 as container,
                HDDT03 as date_in,
                TOPR01 as terminal
                FROM S2114C2V.LCB1DAT.DISCHARGE DISCHARGE
                where DISCHARGE.CNID03 in (" & continerList & ") and DISCHARGE.MVV447 =? and 
                    DISCHARGE.RSIN01=?"

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
            '.Parameters.Add(New OdbcParameter("containers", continerList))
            .Parameters.Add(New OdbcParameter("callsign", callSign))
            .Parameters.Add(New OdbcParameter("voy", voy))

        End With



        'In case Search Booking by Container

        da.SelectCommand = cmd
        da.Fill(ds)





        Return ds


    End Function
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
                        berthdate,
                        consigneeinfo_name,
                        TotalgrossweightInfo_weight gross,
                        TotalgrossweightInfo_unitcode unit_gross,
                        TotalPackageInfo_amount amount,
                        TotalPackageInfo_unitcode unit_amount
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

        ' Resize the master DataGridView columns to fit the newly loaded data.
        DataGridView1.AutoResizeColumns()

        ' Configure the details DataGridView so that its columns automatically
        ' adjust their widths when the data changes.
        DataGridView1.AutoSizeColumnsMode =
        DataGridViewAutoSizeColumnsMode.AllCells

        If x > 0 Then
            btnCfs.Enabled = True
            txtAgent.Enabled = True
            txtLine.Enabled = True
            lblGross.Text = String.Format(CultureInfo.InvariantCulture,
                                 "{0:0,0}", dtBooking.Rows(0).Item("gross")) & " " & dtBooking.Rows(0).Item("unit_gross")
            lblPackage.Text = String.Format(CultureInfo.InvariantCulture,
                                 "{0:0,0}", dtBooking.Rows(0).Item("amount")) & " " & dtBooking.Rows(0).Item("unit_amount")

            Dim vList As String = get_containers_list()
            dtDwell = getDwell(vList,
                               dtBooking.Rows(0).Item("callsign"),
                               dtBooking.Rows(0).Item("voy"))
            lblDwellRecord.Text = Str(dtDwell.Rows.Count) + " Container(s)"


            '----Add Dewll---
            txtDeliver.Text = Format(Now(), "yyyyMMdd")
            calculate()

        Else
            lblDwellRecord.Text = ""
            txtAgent.Enabled = False
            txtLine.Enabled = False
            btnFullout.Enabled = False
            btnCfs.Enabled = False
            lblGross.Text = ""
            lblPackage.Text = ""
        End If
    End Sub

    Sub calculate(Optional vDate As String = "")

        If Not dtDwell.Columns.Contains("dWell") Then
            dtDwell.Columns.Add("dWell", GetType(Integer))
            dtDwell.Columns.Add("1-7day", GetType(Integer))
            dtDwell.Columns.Add("8-14day", GetType(Integer))
            dtDwell.Columns.Add(">15day", GetType(Integer))
        End If
        Dim wD As Long
        Dim vTotalDwell As Integer = 0
        Dim vTotal7Day As Integer = 0
        Dim vTotal14Day As Integer = 0
        Dim vTotal15Day As Integer = 0

        Dim dateIn As Date
        Dim dateToday As Date = Now()

        Dim vNewdWell As Integer = 0
        If vDate = "" Then
            dateToday = Now()
        Else
            dateToday = Date.ParseExact(vDate, "yyyyMMdd",
                System.Globalization.DateTimeFormatInfo.InvariantInfo)
        End If


        For Each row As DataRow In dtDwell.Rows

            If row("Terminal") = "Total" Then
                row.Delete()
                GoTo tag_total
            End If

            dateIn = Date.ParseExact(row("date_in"), "yyyyMMdd",
                System.Globalization.DateTimeFormatInfo.InvariantInfo)
            wD = DateDiff(DateInterval.Day, dateIn, dateToday)
            vTotalDwell = vTotalDwell + wD

            vNewdWell = wD - 3

            row("dwell") = 0
            row("1-7day") = 0
            row("8-14day") = 0
            row(">15day") = 0

            row("dwell") = wD

            If vNewdWell <= 3 Then
                vTotal7Day = vTotal7Day + 0
                row("1-7day") = 0
                row("8-14day") = 0
                row(">15day") = 0
            End If

            If vNewdWell > 0 And vNewdWell <= 7 Then
                vTotal7Day = vTotal7Day + vNewdWell
                row("1-7day") = vNewdWell
            End If
            If vNewdWell > 7 And vNewdWell <= 14 Then
                vTotal7Day = vTotal7Day + 7
                vTotal14Day = vTotal14Day + (vNewdWell - 7)
                row("1-7day") = 7
                row("8-14day") = vNewdWell - 7
            End If
            If vNewdWell >= 15 Then
                vTotal7Day = vTotal7Day + 7
                vTotal14Day = vTotal14Day + 7
                vTotal15Day = vTotal15Day + (vNewdWell - 14)
                row("1-7day") = 7
                row("8-14day") = 7
                row(">15day") = vNewdWell - 14
            End If
        Next
tag_total:
        Dim sumRow As DataRow = dtDwell.NewRow()
        With sumRow
            sumRow("Terminal") = "Total"
            sumRow("dwell") = vTotalDwell
            sumRow("1-7day") = vTotal7Day
            sumRow("8-14day") = vTotal14Day
            sumRow(">15day") = vTotal15Day
        End With
        lblTotaldWell.Text = vTotalDwell.ToString
        lblTotal7Day.Text = vTotal7Day.ToString
        lblTotal14Day.Text = vTotal14Day.ToString
        lblTotal15Day.Text = vTotal15Day.ToString


        dtDwell.Rows.Add(sumRow)
        '----------------
        dgDwell.DataSource = dtDwell
        ' Resize the master DataGridView columns to fit the newly loaded data.
        dgDwell.AutoResizeColumns()

        ' Configure the details DataGridView so that its columns automatically
        ' adjust their widths when the data changes.
        dgDwell.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub btnFullout_Click(sender As Object, e As EventArgs) Handles btnFullout.Click
        createFullOutText(dtBooking, txtLine.Text.Trim, txtAgent.Text.Trim,
                          txtDateUntil.Text.Trim.ToUpper, txtCarrier.Text.Trim.ToUpper,
                          txtShore.Text.Trim.ToUpper)
        RunCommandCom("execute_fullout.bat", "", False)
        If chkAddress.Checked Then
            RunCommandCom("execute_address.bat", "", False)
        End If
    End Sub

    Public Shared Sub createFullOutText(dt As DataTable, vLine As String, vAgent As String,
                                        vDateUntil As String, vCarrier As String, vShore As String)
        Dim path As String = "fullout.txt"

        If File.Exists(path) Then
            File.Delete(path)
        End If
        Dim vConsignee As String

        ' Create a file to write to.
        Using sw As StreamWriter = File.AppendText(path)
            Dim strDetail As String
            Dim vFirst As Boolean = True
            For Each row As DataRow In dt.Rows
                vConsignee = row("consigneeinfo_name")
                vConsignee = vConsignee.Replace("(THAILAND)", "").Trim
                vConsignee = vConsignee.Replace("CO.,LTD", "").Trim
                vConsignee = vConsignee.Replace("COMPANY", "").Trim
                vConsignee = vConsignee.Replace("THAILAND", "").Trim
                vConsignee = vConsignee.Replace("CO.,", "").Trim
                vConsignee = vConsignee.Replace(".", "").Trim
                vConsignee = vConsignee.Replace(",", "").Trim
                vConsignee = vConsignee.Replace("LTD", "").Trim
                vConsignee = Mid(vConsignee, 1, 18) & "/" & IIf(vShore = "", "Auto", vShore)
                vConsignee = Mid(vConsignee, 1, 30)

                strDetail = row("booking") &
                    "|" & row("container") &
                    "|" & vLine.Trim.ToUpper &
                    "|" & vAgent.Trim.ToUpper &
                    "|" & vConsignee &
                    "|" & IIf(vFirst, vDateUntil, "") &
                    "|" & vCarrier
                sw.WriteLine(strDetail)
                vFirst = False
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
        lblGross.Text = ""
        lblPackage.Text = ""
        txtDateUntil.Text = ""
        txtCarrier.Text = ""
        txtShore.Text = ""
        btnFullout.Enabled = False
        btnCfs.Enabled = False
        DataGridView1.DataSource = Nothing
        dgDwell.DataSource = Nothing
        lblTotaldWell.Text = "0"
        lblTotal7Day.Text = "0"
        lblTotal14Day.Text = "0"
        lblTotal15Day.Text = "0"
        ' dgItem.DataSource = Nothing
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

    Sub openTarrifExcel()
        Try
            Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;
                                        Data Source=Trarifrate.xlsx;
                                        Extended Properties=""Excel 12.0 Xml;HDR=YES"";")
            Dim da As New OleDbDataAdapter("SELECT code,name FROM [Sheet1$]", conn)
            da.Fill(dtTarrifList)
            dtTarrifList.Columns.Add("display", GetType(String), "code + ' : ' + name")

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmManifestImport_Load(sender As Object, e As EventArgs) Handles Me.Load
        openTarrifExcel()
        With cbTarRif
            .DataSource = dtTarrifList
            .DisplayMember = "display"
            .ValueMember = "code"
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With

        'Create DataTable for Item
        With dtItem
            .Columns.Add("Type", GetType(String))
            .Columns.Add("Code", GetType(String))
            .Columns.Add("Description", GetType(String))
            .Columns.Add("Quantity", GetType(String))
        End With
        dgItem.DataSource = dtItem

        Dim versionNumber As Version

        versionNumber = Assembly.GetExecutingAssembly().GetName().Version
        Me.Text = Me.Text & " version :" & versionNumber.ToString

    End Sub



    Private Sub cbTarRif_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbTarRif.KeyPress

    End Sub



    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cbTarRif_KeyDown(sender As Object, e As KeyEventArgs) Handles cbTarRif.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    SendKeys.Send("{TAB}")
        'End If
    End Sub

    Private Sub txtLine_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLine.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtAgent_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAgent.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        addToItem("Resource", cbTarRif.SelectedValue, cbTarRif.SelectedItem("name"), txtQty.Text)
    End Sub

    Sub addToItem(vType As String, vCode As String, vDescription As String, vQty As String)
        Dim workRow As DataRow = dtItem.NewRow()
        With workRow
            workRow("type") = vType
            workRow("code") = vCode
            workRow("description") = vDescription
            workRow("quantity") = vQty
        End With
        dtItem.Rows.Add(workRow)

        ' Resize the master DataGridView columns to fit the newly loaded data.
        dgItem.AutoResizeColumns()

        ' Configure the details DataGridView so that its columns automatically
        ' adjust their widths when the data changes.
        dgItem.AutoSizeColumnsMode =
        DataGridViewAutoSizeColumnsMode.AllCells

        dgItem.ClipboardCopyMode =
        DataGridViewClipboardCopyMode.EnableWithoutHeaderText

        cbTarRif.Focus()
    End Sub

    Private Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
        dtItem.Rows.Clear()
    End Sub

    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged

    End Sub

    Private Sub txtQty_GotFocus(sender As Object, e As EventArgs) Handles txtQty.GotFocus
        txtQty.SelectAll()
    End Sub

    Private Sub btnAddBL_Click(sender As Object, e As EventArgs) Handles btnAddBL.Click
        'First Line B/L number
        addToItem("Resource", "", "B/L : " & txtBooking.Text.Trim.ToUpper, "")

        Dim vIndex As Integer = 1
        Dim vOdd As Integer = 0
        Dim vTempCont As String = ""
        'For Each row As DataRow In dtBooking.Rows
        '    addToItem("Resource", "", row("container"), "")
        'Next
        For Each row As DataRow In dtBooking.Rows
            vOdd = vIndex Mod 2
            If vOdd = 1 Then
                vTempCont = row("container") & " "
            Else
                vTempCont = vTempCont & " " & row("container")
                addToItem("Resource", "", vTempCont, "")
                vTempCont = ""
            End If


            vIndex = vIndex + 1
        Next
        If vOdd = 1 Then
            addToItem("Resource", "", vTempCont, "")
        End If
        'addToItem("", "", "", "")
    End Sub

    Private Sub btnCopyToClipboard_Click(sender As Object, e As EventArgs) Handles btnCopyToClipboard.Click

        Try
            dgItem.SelectAll()
            ' Add the selection to the clipboard.
            Clipboard.SetDataObject(
                    dgItem.GetClipboardContent())

            ' Replace the text box contents with the clipboard text.
            'Me.TextBox1.Text = Clipboard.GetText()

        Catch ex As System.Runtime.InteropServices.ExternalException
            MsgBox("The Clipboard could not be accessed. Please try again.")

        End Try

    End Sub

    Private Sub cbTarRif_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTarRif.SelectedIndexChanged

    End Sub

    Private Sub cbTarRif_RightToLeftChanged(sender As Object, e As EventArgs) Handles cbTarRif.RightToLeftChanged

    End Sub

    Private Sub btnAddCFS_Click(sender As Object, e As EventArgs) Handles btnAddCFS.Click
        addToItem("Resource", "", "CFS RENT TO ", "")
    End Sub

    Private Sub btnCfs_Click(sender As Object, e As EventArgs) Handles btnCfs.Click
        Dim vCfs As New frmCFS
        vCfs.BL_Number = txtBooking.Text.Trim.ToUpper
        vCfs.Show()
    End Sub

    Private Sub btnRecal_Click(sender As Object, e As EventArgs) Handles btnRecal.Click

        calculate(txtDeliver.Text)
    End Sub



    Private Sub txtDeliver_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDeliver.KeyPress
        If e.KeyChar = Chr(13) Then
            calculate(txtDeliver.Text)
        End If
    End Sub


End Class