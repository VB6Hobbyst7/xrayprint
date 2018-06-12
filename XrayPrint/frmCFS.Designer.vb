<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCFS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblBL = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtGoodsDesc = New System.Windows.Forms.TextBox()
        Me.txtShippingMark = New System.Windows.Forms.TextBox()
        Me.lblMeasurement = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblPackage = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblGross = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtShipperAddr = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblShipperName = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtConsigneeAddr = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblConsigneeName = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtSpecialRequest = New System.Windows.Forms.TextBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.chkSendmail = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblContainer = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtExpire = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.rbB1 = New System.Windows.Forms.RadioButton()
        Me.rbA0 = New System.Windows.Forms.RadioButton()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtReceiveDate = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblVoy = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "B/L :"
        '
        'lblBL
        '
        Me.lblBL.AutoSize = True
        Me.lblBL.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBL.Location = New System.Drawing.Point(40, 2)
        Me.lblBL.Name = "lblBL"
        Me.lblBL.Size = New System.Drawing.Size(161, 37)
        Me.lblBL.TabIndex = 1
        Me.lblBL.Text = "00000000"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtGoodsDesc)
        Me.GroupBox1.Controls.Add(Me.txtShippingMark)
        Me.GroupBox1.Controls.Add(Me.lblMeasurement)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.lblPackage)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.lblGross)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(362, 93)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(326, 260)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Goods Information"
        '
        'txtGoodsDesc
        '
        Me.txtGoodsDesc.Enabled = False
        Me.txtGoodsDesc.Location = New System.Drawing.Point(9, 118)
        Me.txtGoodsDesc.Multiline = True
        Me.txtGoodsDesc.Name = "txtGoodsDesc"
        Me.txtGoodsDesc.Size = New System.Drawing.Size(306, 71)
        Me.txtGoodsDesc.TabIndex = 14
        '
        'txtShippingMark
        '
        Me.txtShippingMark.Enabled = False
        Me.txtShippingMark.Location = New System.Drawing.Point(9, 34)
        Me.txtShippingMark.Multiline = True
        Me.txtShippingMark.Name = "txtShippingMark"
        Me.txtShippingMark.Size = New System.Drawing.Size(306, 71)
        Me.txtShippingMark.TabIndex = 13
        '
        'lblMeasurement
        '
        Me.lblMeasurement.AutoSize = True
        Me.lblMeasurement.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblMeasurement.Location = New System.Drawing.Point(97, 241)
        Me.lblMeasurement.Name = "lblMeasurement"
        Me.lblMeasurement.Size = New System.Drawing.Size(60, 13)
        Me.lblMeasurement.TabIndex = 12
        Me.lblMeasurement.Text = "Description"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 241)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Measurement :"
        '
        'lblPackage
        '
        Me.lblPackage.AutoSize = True
        Me.lblPackage.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblPackage.Location = New System.Drawing.Point(97, 215)
        Me.lblPackage.Name = "lblPackage"
        Me.lblPackage.Size = New System.Drawing.Size(60, 13)
        Me.lblPackage.TabIndex = 9
        Me.lblPackage.Text = "Description"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 215)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 13)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Total Package :"
        '
        'lblGross
        '
        Me.lblGross.AutoSize = True
        Me.lblGross.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblGross.Location = New System.Drawing.Point(97, 190)
        Me.lblGross.Name = "lblGross"
        Me.lblGross.Size = New System.Drawing.Size(60, 13)
        Me.lblGross.TabIndex = 6
        Me.lblGross.Text = "Description"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 190)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Gross Weight  :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Description :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Shipping Marks :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtShipperAddr)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.lblShipperName)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 93)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(347, 134)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Shipper Information"
        '
        'txtShipperAddr
        '
        Me.txtShipperAddr.Enabled = False
        Me.txtShipperAddr.Location = New System.Drawing.Point(9, 70)
        Me.txtShipperAddr.Multiline = True
        Me.txtShipperAddr.Name = "txtShipperAddr"
        Me.txtShipperAddr.Size = New System.Drawing.Size(306, 58)
        Me.txtShipperAddr.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Address :"
        '
        'lblShipperName
        '
        Me.lblShipperName.AutoSize = True
        Me.lblShipperName.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblShipperName.Location = New System.Drawing.Point(68, 28)
        Me.lblShipperName.Name = "lblShipperName"
        Me.lblShipperName.Size = New System.Drawing.Size(86, 13)
        Me.lblShipperName.TabIndex = 2
        Me.lblShipperName.Text = "Shipping Marks :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Name :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtConsigneeAddr)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.lblConsigneeName)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 233)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(347, 120)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Consignee Information"
        '
        'txtConsigneeAddr
        '
        Me.txtConsigneeAddr.Enabled = False
        Me.txtConsigneeAddr.Location = New System.Drawing.Point(9, 54)
        Me.txtConsigneeAddr.Multiline = True
        Me.txtConsigneeAddr.Name = "txtConsigneeAddr"
        Me.txtConsigneeAddr.Size = New System.Drawing.Size(306, 58)
        Me.txtConsigneeAddr.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Address :"
        '
        'lblConsigneeName
        '
        Me.lblConsigneeName.AutoSize = True
        Me.lblConsigneeName.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblConsigneeName.Location = New System.Drawing.Point(68, 16)
        Me.lblConsigneeName.Name = "lblConsigneeName"
        Me.lblConsigneeName.Size = New System.Drawing.Size(86, 13)
        Me.lblConsigneeName.TabIndex = 2
        Me.lblConsigneeName.Text = "Shipping Marks :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Name :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtSpecialRequest)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 359)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(676, 87)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Special Request :"
        '
        'txtSpecialRequest
        '
        Me.txtSpecialRequest.Location = New System.Drawing.Point(13, 20)
        Me.txtSpecialRequest.Multiline = True
        Me.txtSpecialRequest.Name = "txtSpecialRequest"
        Me.txtSpecialRequest.Size = New System.Drawing.Size(653, 57)
        Me.txtSpecialRequest.TabIndex = 2
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(551, 452)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(137, 37)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Text = "Print CFS request"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'chkSendmail
        '
        Me.chkSendmail.AutoSize = True
        Me.chkSendmail.Checked = True
        Me.chkSendmail.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSendmail.Location = New System.Drawing.Point(554, 497)
        Me.chkSendmail.Name = "chkSendmail"
        Me.chkSendmail.Size = New System.Drawing.Size(82, 17)
        Me.chkSendmail.TabIndex = 7
        Me.chkSendmail.Text = "Send E-mail"
        Me.chkSendmail.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Container No :"
        '
        'lblContainer
        '
        Me.lblContainer.AutoSize = True
        Me.lblContainer.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContainer.Location = New System.Drawing.Point(87, 39)
        Me.lblContainer.Name = "lblContainer"
        Me.lblContainer.Size = New System.Drawing.Size(161, 37)
        Me.lblContainer.TabIndex = 9
        Me.lblContainer.Text = "00000000"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtExpire)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.lblStatus)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.rbB1)
        Me.GroupBox5.Controls.Add(Me.rbA0)
        Me.GroupBox5.Location = New System.Drawing.Point(362, 13)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(325, 80)
        Me.GroupBox5.TabIndex = 10
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Terminal"
        '
        'txtExpire
        '
        Me.txtExpire.Location = New System.Drawing.Point(222, 50)
        Me.txtExpire.Name = "txtExpire"
        Me.txtExpire.Size = New System.Drawing.Size(93, 20)
        Me.txtExpire.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(150, 53)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(71, 13)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Expire Date  :"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblStatus.Location = New System.Drawing.Point(66, 53)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(60, 13)
        Me.lblStatus.TabIndex = 7
        Me.lblStatus.Text = "Description"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Status  :"
        '
        'rbB1
        '
        Me.rbB1.AutoSize = True
        Me.rbB1.Location = New System.Drawing.Point(88, 25)
        Me.rbB1.Name = "rbB1"
        Me.rbB1.Size = New System.Drawing.Size(38, 17)
        Me.rbB1.TabIndex = 1
        Me.rbB1.Text = "B1"
        Me.rbB1.UseVisualStyleBackColor = True
        '
        'rbA0
        '
        Me.rbA0.AutoSize = True
        Me.rbA0.Checked = True
        Me.rbA0.Location = New System.Drawing.Point(26, 25)
        Me.rbA0.Name = "rbA0"
        Me.rbA0.Size = New System.Drawing.Size(38, 17)
        Me.rbA0.TabIndex = 0
        Me.rbA0.TabStop = True
        Me.rbA0.Text = "A0"
        Me.rbA0.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(15, 464)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 13)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Receive Date :"
        '
        'txtReceiveDate
        '
        Me.txtReceiveDate.Location = New System.Drawing.Point(94, 461)
        Me.txtReceiveDate.Name = "txtReceiveDate"
        Me.txtReceiveDate.Size = New System.Drawing.Size(227, 20)
        Me.txtReceiveDate.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(50, 77)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(31, 13)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Voy :"
        '
        'lblVoy
        '
        Me.lblVoy.AutoSize = True
        Me.lblVoy.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblVoy.Location = New System.Drawing.Point(91, 78)
        Me.lblVoy.Name = "lblVoy"
        Me.lblVoy.Size = New System.Drawing.Size(25, 13)
        Me.lblVoy.TabIndex = 13
        Me.lblVoy.Text = "Voy"
        '
        'frmCFS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 524)
        Me.Controls.Add(Me.lblVoy)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtReceiveDate)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.lblContainer)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.chkSendmail)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblBL)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmCFS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmCFS"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblBL As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblMeasurement As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblPackage As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblGross As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lblShipperName As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents lblConsigneeName As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents txtSpecialRequest As TextBox
    Friend WithEvents btnPrint As Button
    Friend WithEvents chkSendmail As CheckBox
    Friend WithEvents txtShippingMark As TextBox
    Friend WithEvents txtGoodsDesc As TextBox
    Friend WithEvents txtShipperAddr As TextBox
    Friend WithEvents txtConsigneeAddr As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents lblContainer As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents rbB1 As RadioButton
    Friend WithEvents rbA0 As RadioButton
    Friend WithEvents lblStatus As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtReceiveDate As TextBox
    Friend WithEvents txtExpire As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lblVoy As Label
End Class
