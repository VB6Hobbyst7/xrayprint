Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Globalization
Imports Microsoft.Office
Imports outlook = Microsoft.Office.Interop.Outlook

Public Class frmCFS
    Dim dtBooking As DataTable
    Dim vBLnumber As String
    Dim vVoynumber As String
    Dim vCallSignnumber As String
    Public Property BL_Number() As String
        Get
            Return vBLnumber
        End Get
        Set(ByVal value As String)
            vBLnumber = value
        End Set
    End Property

    Public Property Voy_Number() As String
        Get
            Return vVoynumber
        End Get
        Set(ByVal value As String)
            vVoynumber = value
        End Set
    End Property


    Public Property CallSign_Number() As String
        Get
            Return vCallSignnumber
        End Get
        Set(ByVal value As String)
            vCallSignnumber = value
        End Set
    End Property

    Private Sub frmCFS_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblBL.Text = vBLnumber
        dtBooking = getContainers(vBLnumber)

        'Show Details

        lblContainer.Text = dtBooking.Rows(0).Item("container")

        lblShipperName.Text = dtBooking.Rows(0).Item("ShipperInfo_Name")
        txtShipperAddr.Text = dtBooking.Rows(0).Item("ShipperInfo_NameAndAddress")


        lblConsigneeName.Text = dtBooking.Rows(0).Item("ConsigneeInfo_Name")
        txtConsigneeAddr.Text = dtBooking.Rows(0).Item("ConsigneeInfo_NameAndAddress")


        txtShippingMark.Text = dtBooking.Rows(0).Item("shippingMarks")
        txtGoodsDesc.Text = dtBooking.Rows(0).Item("descriptionOfGoods")

        'lblGross.Text = String.Format(CultureInfo.InvariantCulture,
        '                         "{0,0}", dtBooking.Rows(0).Item("gross")) & " " & dtBooking.Rows(0).Item("unit_gross")
        'lblPackage.Text = String.Format(CultureInfo.InvariantCulture,
        '                     "{0,0}", dtBooking.Rows(0).Item("amount")) & " " & dtBooking.Rows(0).Item("unit_amount")
        lblGross.Text = Val(dtBooking.Rows(0).Item("gross")).ToString("0,0.0", CultureInfo.InvariantCulture) & " " & dtBooking.Rows(0).Item("unit_gross")
        lblPackage.Text = Val(dtBooking.Rows(0).Item("amount")).ToString("0.0", CultureInfo.InvariantCulture) & " " & dtBooking.Rows(0).Item("unit_amount")
        lblMeasurement.Text = Val(dtBooking.Rows(0).Item("meas")).ToString("0.0", CultureInfo.InvariantCulture) & " " & dtBooking.Rows(0).Item("unit_meas")
        ' & " " & dtBooking.Rows(0).Item("unit_meas")

        'String.Format(CultureInfo.InvariantCulture,
        '                     "{0,0.0}", dtBooking.Rows(0).Item("meas")) & " " & dtBooking.Rows(0).Item("unit_meas")

        Dim vCodeStatus As String = dtBooking.Rows(0).Item("containerdetail_status")
        Dim vStatus As String = ""
        Select Case vCodeStatus
            Case "4" : vStatus = "MTY"
            Case "7" : vStatus = "LCL"
            Case "8" : vStatus = "FCL"
            Case "9" : vStatus = "LCL/CFS"
        End Select
        lblStatus.Text = vStatus
        lblVoy.Text = dtBooking.Rows(0).Item("voy")

        '2835 == A0
        '2811 == B1
        If dtBooking.Rows(0).Item("shedNumberReleasePort") = "2835" Then
            rbA0.Checked = True
        Else
            rbB1.Checked = True
        End If

        'Show Vessel Detail
        Dim dtVessel As DataTable
        dtVessel = getDwell(lblContainer.Text.Trim, vCallSignnumber, vVoynumber)
        If dtVessel.Rows.Count > 0 Then
            lblVesselCode.Text = dtVessel.Rows(0).Item("vessel_code")
            lblVesselName.Text = dtVessel.Rows(0).Item("vessel_name")
        Else
            lblVesselCode.Text = ""
            lblVesselName.Text = ""
        End If

    End Sub

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
                        TotalgrossweightInfo_weight gross,
                        TotalgrossweightInfo_unitcode unit_gross,
                        TotalPackageInfo_amount amount,
                        TotalPackageInfo_unitcode unit_amount,
                        shippingMarks,
                        descriptionOfGoods,
                        ShipperInfo_Name,ShipperInfo_NameAndAddress,
                        ConsigneeInfo_Name,ConsigneeInfo_NameAndAddress,
                        MeasurementInfo_Measurement meas,MeasurementInfo_unitcode unit_meas,
                        containerdetail_status,
                        shedNumberReleasePort
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

    Friend Function getDwell(ByVal continer As String,
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
                TOPR01 as terminal,
                MVVA47 as vessel_name,
                VMID01 as vessel_code
                FROM S2114C2V.LCB1DAT.DISCHARGE DISCHARGE
                where DISCHARGE.CNID03 =? and DISCHARGE.MVV447 =? and 
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
            .Parameters.Add(New OdbcParameter("containers", continer))
            .Parameters.Add(New OdbcParameter("callsign", callSign))
            .Parameters.Add(New OdbcParameter("voy", voy))

        End With



        'In case Search Booking by Container

        da.SelectCommand = cmd
        da.Fill(ds)





        Return ds


    End Function
    Friend Function getBooking(container As String, booking As String) As DataTable

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
                where BOOKLIST.CNID94 = ? and BOOKLIST.ORRF93 = ? "
        'BOOKLIST.CNID94 = ? and 


        ' Create an OleDbDataAdapter object
        Dim adapter As OdbcDataAdapter = New OdbcDataAdapter()

        With cmd

            .CommandType = CommandType.Text
            .Connection = con
            .CommandTimeout = 100

            .CommandText = sqlContainer
            .Parameters.Add(New OdbcParameter("container", container))
            .Parameters.Add(New OdbcParameter("booking", booking))

        End With
        'In case Search Booking by Container
        Dim dsContainer As New DataTable
        da.SelectCommand = cmd
        da.Fill(dsContainer)

        Return dsContainer

        'Dim lastRow As DataRow
        'lastRow = dsContainer.Rows.Cast(Of DataRow)().LastOrDefault()

        'If lastRow Is Nothing Then
        '    'The table contains no rows.
        '    Return ""
        'Else
        '    'Use lastRow here.
        '    Return lastRow.Item("booking").trim()

        'End If



    End Function

    Function get_containers() As String
        Dim vList As String = ""
        For Each row As DataRow In dtBooking.Rows
            vList = vList & "    " & row("container")
        Next
        Return vList
    End Function

    Sub start_print_process()

        Dim vBody As String = "<h1>Request for : CFS  of " & lblBL.Text.Trim & "</h1> <br>
                                   <table border=""1"">
                                        <tr>
                                            <td colspan=2 bgcolor=""#00FFFF"">Container Info</td>
                                        </tr>
                                        <tr>
                                            <td>B/L:</td>
                                            <td>" & lblBL.Text.Trim & "</td>
                                        </tr>
                                        <tr>
                                            <td>Voy:</td>
                                            <td>" & lblVoy.Text & "</td>
                                        </tr>
                                        
                                          <tr>
                                            <td>Vessel :</td>
                                            <td>" & lblVesselCode.Text.Trim & "/" & lblVesselName.Text.Trim & "</td>
                                        </tr>
                                        <tr>
                                            <td>Container:</td>
                                            <td>" & get_containers() & "</td>
                                        </tr>

                                          <tr>
                                            <td>Status :</td>
                                            <td>" & lblStatus.Text & "</td>
                                        </tr>

                                         <tr>
                                            <td>Received Date:</td>
                                            <td>" & txtReceiveDate.Text & "</td>
                                        </tr>

                                          <tr>
                                            <td>Expired Date:</td>
                                            <td>" & txtExpire.Text & "</td>
                                        </tr>

                                        <tr>
                                            <td>Request Date:</td>
                                            <td>" & Now() & "</td>
                                        </tr>
                                        
                                        <tr>
                                            <td colspan=2 bgcolor=""#00FFFF"">Goods Information</td>
                                         
                                        </tr>
                                        
                                        <tr>
                                            <td>Shipping Mark</td>
                                            <td>" & txtShippingMark.Text & "</td>
                                        </tr>
                                        
                                        <tr>
                                            <td>Description</td>
                                            <td>" & txtGoodsDesc.Text & "</td>
                                        </tr>
                                        <tr>
                                            <td>Gross Weight</td>
                                            <td>" & lblGross.Text & "</td>
                                        </tr>
                                        
                                           <tr>
                                            <td>Total Package</td>
                                            <td>" & lblPackage.Text & "</td>
                                        </tr>

                                        <tr>
                                            <td>Measurement</td>
                                            <td>" & lblMeasurement.Text & "</td>
                                        </tr>

                                          <tr>
                                            <td colspan=2 bgcolor=""#00FFFF"">Special Request</td>
                                         
                                        </tr>
                                          <tr>
                                       
                                            <td colspan=2>" & txtSpecialRequest.Text & "</td>
                                        </tr>

                                       <tr>
                                            <td colspan=2 bgcolor=""#00FFFF"">Consignee Info</td>
                                         
                                        </tr>
                                        
                                         <tr>
                                            <td>Name</td>
                                            <td>" & lblConsigneeName.Text & "</td>
                                        </tr>
                                        
                                        <tr>
                                            <td>Address</td>
                                            <td>" & txtConsigneeAddr.Text & "</td>
                                        </tr>
                                        
                                        <tr>
                                            <td colspan=2 bgcolor=""#00FFFF"">Shipper Info</td>
                                         
                                        </tr>
                                        
                                         <tr>
                                            <td>Name</td>
                                            <td>" & lblShipperName.Text & "</td>
                                        </tr>
                                        
                                        <tr>
                                            <td>Address</td>
                                            <td>" & txtShipperAddr.Text & "</td>
                                        </tr>
                                        
                                    </table><br><hr>
                  
                                    <b>Note : Do not reply. This message sent from auto Cashier system.</b>"

        Dim vMailSubject As String = "Request CFS/LCL of  " & lblBL.Text.Trim() & " " & IIf(txtSpecialRequest.Text = "", "", "*** Special Request ***")

        fill_to_excel()
        'fill_to_excel(lblContainer.Text.Trim,
        '              lblLocation.Text.Trim,
        '              IIf(rbA0.Checked, "A0", "B1"),
        '              txtPlateNumber.Text.Trim.ToUpper,
        '              IIf(rbXray.Checked, "X-RAY", "เปิดตรวจ"),
        '              lblBooking.Text.Trim)

        print_excel()
        'print 2 copy
        print_excel()



        'SendKeys Email
        If chkSendmail.Checked Then

            Dim mailTo As String
            If My.Computer.FileSystem.FileExists("cfs_mail_list.txt") Then
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


    Private Sub fill_to_excel()
        Dim xlsWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlsWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim xls As New Microsoft.Office.Interop.Excel.Application

        Dim resourcesFolder = IO.Path.GetFullPath(Application.StartupPath & "\")
        Dim fileName = "CFSTemplate.xlsx"

        xlsWorkBook = xls.Workbooks.Open(resourcesFolder & fileName)
        xlsWorkSheet = xlsWorkBook.Sheets("Sheet1")

        With xlsWorkSheet
            'Terminal
            .Cells(6, 11) = IIf(rbA0.Checked, "A0", "B1")
            'Status
            .Cells(7, 11) = lblStatus.Text
            .Cells(8, 10) = IIf(lblStatus.Text = "LCL", "Demurrage  for LCL", "")
            .Cells(9, 11) = "'" & IIf(lblStatus.Text = "LCL", txtExpire.Text, "")
            'Consignee
            .Cells(6, 3) = lblConsigneeName.Text
            .Cells(7, 3) = txtConsigneeAddr.Text
            .Cells(9, 3) = lblVesselCode.Text.Trim & "/" & lblVesselName.Text.Trim & " (Voy:" & lblVoy.Text & ")"
            .Cells(10, 3) = txtReceiveDate.Text
            'Container
            .Cells(12, 3) = "'" & lblBL.Text
            .Cells(14, 3) = get_containers()

            'goods
            .Cells(20, 1) = txtShippingMark.Text
            .Cells(20, 3) = lblPackage.Text
            .Cells(20, 5) = txtGoodsDesc.Text
            .Cells(20, 10) = lblGross.Text
            .Cells(20, 11) = lblMeasurement.Text

            'spectial request
            .Cells(33, 1) = txtSpecialRequest.Text

            'shipper
            .Cells(42, 2) = lblShipperName.Text
            .Cells(43, 2) = txtShipperAddr.Text

            'issue date
            .Cells(56, 10) = Now()
        End With


        xls.DisplayAlerts = False


        xlsWorkBook.Close(True)



        releaseObject(xlsWorkSheet)
        releaseObject(xlsWorkBook)
        releaseObject(xls)

        'MsgBox("file saved to " & resourcesFolder)

    End Sub

    Sub print_excel()
        Dim strFile As String = "CFSTemplate.xlsx"
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

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        start_print_process()
    End Sub
End Class