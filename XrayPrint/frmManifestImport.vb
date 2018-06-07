Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Reflection

Public Class frmManifestImport

    Dim dtBooking As DataTable
    Dim dtTarrifList As New DataTable
    Dim dtItem As New DataTable

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
            txtAgent.Enabled = True
            txtLine.Enabled = True
            lblGross.Text = String.Format(CultureInfo.InvariantCulture,
                                 "{0:0,0}", dtBooking.Rows(0).Item("gross")) & " " & dtBooking.Rows(0).Item("unit_gross")
            lblPackage.Text = String.Format(CultureInfo.InvariantCulture,
                                 "{0:0,0}", dtBooking.Rows(0).Item("amount")) & " " & dtBooking.Rows(0).Item("unit_amount")
        Else
            txtAgent.Enabled = False
            txtLine.Enabled = False
            btnFullout.Enabled = False
            lblGross.Text = ""
            lblPackage.Text = ""
        End If
    End Sub

    Private Sub btnFullout_Click(sender As Object, e As EventArgs) Handles btnFullout.Click
        createFullOutText(dtBooking, txtLine.Text.Trim, txtAgent.Text.Trim,
                          txtDateUntil.Text.Trim.ToUpper, txtCarrier.Text.Trim.ToUpper,
                          txtShore.Text.Trim.ToUpper)
        RunCommandCom("execute_fullout.bat", "", False)
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
                    "|" & vDateUntil &
                    "|" & vCarrier
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
        lblGross.Text = ""
        lblPackage.Text = ""
        txtDateUntil.Text = ""
        txtCarrier.Text = ""
        txtShore.Text = ""
        btnFullout.Enabled = False
        DataGridView1.DataSource = Nothing
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

        For Each row As DataRow In dtBooking.Rows
            addToItem("Resource", "", row("container"), "")
        Next
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


End Class