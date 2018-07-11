<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManifestImport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManifestImport))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkCheckFirst = New System.Windows.Forms.CheckBox()
        Me.lblGross = New System.Windows.Forms.Label()
        Me.lblPackage = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnGetData = New System.Windows.Forms.Button()
        Me.txtBooking = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkAddress = New System.Windows.Forms.CheckBox()
        Me.txtDateUntil = New System.Windows.Forms.TextBox()
        Me.txtShore = New System.Windows.Forms.TextBox()
        Me.txtCarrier = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnFullout = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAgent = New System.Windows.Forms.TextBox()
        Me.txtLine = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnAddCFS = New System.Windows.Forms.Button()
        Me.btnCopyToClipboard = New System.Windows.Forms.Button()
        Me.btnAddBL = New System.Windows.Forms.Button()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.dgItem = New System.Windows.Forms.DataGridView()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbTarRif = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCfs = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.lblRecord = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnRecal = New System.Windows.Forms.Button()
        Me.txtDeliver = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.lblTotal15Day = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.lblTotal14Day = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lblTotal7Day = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblTotaldWell = New System.Windows.Forms.Label()
        Me.lblDwellRecord = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dgDwell = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgDwell, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkCheckFirst)
        Me.GroupBox1.Controls.Add(Me.lblGross)
        Me.GroupBox1.Controls.Add(Me.lblPackage)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.btnGetData)
        Me.GroupBox1.Controls.Add(Me.txtBooking)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(562, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "B/L Detail"
        '
        'chkCheckFirst
        '
        Me.chkCheckFirst.AutoSize = True
        Me.chkCheckFirst.Checked = True
        Me.chkCheckFirst.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCheckFirst.Location = New System.Drawing.Point(445, 54)
        Me.chkCheckFirst.Name = "chkCheckFirst"
        Me.chkCheckFirst.Size = New System.Drawing.Size(122, 17)
        Me.chkCheckFirst.TabIndex = 7
        Me.chkCheckFirst.Text = "check first container"
        Me.chkCheckFirst.UseVisualStyleBackColor = True
        '
        'lblGross
        '
        Me.lblGross.AutoSize = True
        Me.lblGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGross.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblGross.Location = New System.Drawing.Point(381, 68)
        Me.lblGross.Name = "lblGross"
        Me.lblGross.Size = New System.Drawing.Size(30, 25)
        Me.lblGross.TabIndex = 6
        Me.lblGross.Text = "..."
        '
        'lblPackage
        '
        Me.lblPackage.AutoSize = True
        Me.lblPackage.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPackage.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblPackage.Location = New System.Drawing.Point(95, 68)
        Me.lblPackage.Name = "lblPackage"
        Me.lblPackage.Size = New System.Drawing.Size(30, 25)
        Me.lblPackage.TabIndex = 5
        Me.lblPackage.Text = "..."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(305, 77)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Gross Weight  :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 77)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Package Amount  :"
        '
        'btnGetData
        '
        Me.btnGetData.Location = New System.Drawing.Point(444, 23)
        Me.btnGetData.Name = "btnGetData"
        Me.btnGetData.Size = New System.Drawing.Size(95, 27)
        Me.btnGetData.TabIndex = 2
        Me.btnGetData.Text = "Get Data"
        Me.btnGetData.UseVisualStyleBackColor = True
        '
        'txtBooking
        '
        Me.txtBooking.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBooking.Location = New System.Drawing.Point(100, 23)
        Me.txtBooking.Name = "txtBooking"
        Me.txtBooking.Size = New System.Drawing.Size(338, 38)
        Me.txtBooking.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "B/L number :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkAddress)
        Me.GroupBox2.Controls.Add(Me.txtDateUntil)
        Me.GroupBox2.Controls.Add(Me.txtShore)
        Me.GroupBox2.Controls.Add(Me.txtCarrier)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.btnFullout)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtAgent)
        Me.GroupBox2.Controls.Add(Me.txtLine)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(568, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(470, 100)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Full-Out"
        '
        'chkAddress
        '
        Me.chkAddress.AutoSize = True
        Me.chkAddress.Checked = True
        Me.chkAddress.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAddress.Location = New System.Drawing.Point(180, 80)
        Me.chkAddress.Name = "chkAddress"
        Me.chkAddress.Size = New System.Drawing.Size(120, 17)
        Me.chkAddress.TabIndex = 7
        Me.chkAddress.Text = "Go to Address page"
        Me.chkAddress.UseVisualStyleBackColor = True
        '
        'txtDateUntil
        '
        Me.txtDateUntil.Location = New System.Drawing.Point(351, 13)
        Me.txtDateUntil.Name = "txtDateUntil"
        Me.txtDateUntil.Size = New System.Drawing.Size(112, 20)
        Me.txtDateUntil.TabIndex = 4
        '
        'txtShore
        '
        Me.txtShore.Location = New System.Drawing.Point(86, 77)
        Me.txtShore.Name = "txtShore"
        Me.txtShore.Size = New System.Drawing.Size(88, 20)
        Me.txtShore.TabIndex = 6
        '
        'txtCarrier
        '
        Me.txtCarrier.Location = New System.Drawing.Point(86, 54)
        Me.txtCarrier.Name = "txtCarrier"
        Me.txtCarrier.Size = New System.Drawing.Size(246, 20)
        Me.txtCarrier.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Shore No :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Carrier Type :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(289, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Date Until :"
        '
        'btnFullout
        '
        Me.btnFullout.Enabled = False
        Me.btnFullout.Location = New System.Drawing.Point(350, 39)
        Me.btnFullout.Name = "btnFullout"
        Me.btnFullout.Size = New System.Drawing.Size(113, 43)
        Me.btnFullout.TabIndex = 8
        Me.btnFullout.Text = "Import to CTCS"
        Me.btnFullout.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(149, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Agent :"
        '
        'txtAgent
        '
        Me.txtAgent.Enabled = False
        Me.txtAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgent.Location = New System.Drawing.Point(196, 12)
        Me.txtAgent.Name = "txtAgent"
        Me.txtAgent.Size = New System.Drawing.Size(87, 38)
        Me.txtAgent.TabIndex = 3
        '
        'txtLine
        '
        Me.txtLine.Enabled = False
        Me.txtLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLine.Location = New System.Drawing.Point(55, 12)
        Me.txtLine.Name = "txtLine"
        Me.txtLine.Size = New System.Drawing.Size(87, 38)
        Me.txtLine.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Line :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnAddCFS)
        Me.GroupBox3.Controls.Add(Me.btnCopyToClipboard)
        Me.GroupBox3.Controls.Add(Me.btnAddBL)
        Me.GroupBox3.Controls.Add(Me.btnClearAll)
        Me.GroupBox3.Controls.Add(Me.dgItem)
        Me.GroupBox3.Controls.Add(Me.btnAdd)
        Me.GroupBox3.Controls.Add(Me.txtQty)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.cbTarRif)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(569, 116)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(468, 352)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Navision"
        '
        'btnAddCFS
        '
        Me.btnAddCFS.Location = New System.Drawing.Point(96, 321)
        Me.btnAddCFS.Name = "btnAddCFS"
        Me.btnAddCFS.Size = New System.Drawing.Size(101, 25)
        Me.btnAddCFS.TabIndex = 8
        Me.btnAddCFS.Text = "Add CFS Rent to"
        Me.btnAddCFS.UseVisualStyleBackColor = True
        '
        'btnCopyToClipboard
        '
        Me.btnCopyToClipboard.Location = New System.Drawing.Point(341, 321)
        Me.btnCopyToClipboard.Name = "btnCopyToClipboard"
        Me.btnCopyToClipboard.Size = New System.Drawing.Size(121, 25)
        Me.btnCopyToClipboard.TabIndex = 7
        Me.btnCopyToClipboard.Text = "Copy to Clipboard"
        Me.btnCopyToClipboard.UseVisualStyleBackColor = True
        '
        'btnAddBL
        '
        Me.btnAddBL.Location = New System.Drawing.Point(6, 321)
        Me.btnAddBL.Name = "btnAddBL"
        Me.btnAddBL.Size = New System.Drawing.Size(84, 25)
        Me.btnAddBL.TabIndex = 6
        Me.btnAddBL.Text = "Add B/L detail"
        Me.btnAddBL.UseVisualStyleBackColor = True
        '
        'btnClearAll
        '
        Me.btnClearAll.Location = New System.Drawing.Point(237, 44)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Size = New System.Drawing.Size(84, 25)
        Me.btnClearAll.TabIndex = 5
        Me.btnClearAll.Text = "Clear all Trarif"
        Me.btnClearAll.UseVisualStyleBackColor = True
        '
        'dgItem
        '
        Me.dgItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgItem.Location = New System.Drawing.Point(6, 75)
        Me.dgItem.Name = "dgItem"
        Me.dgItem.Size = New System.Drawing.Size(456, 240)
        Me.dgItem.TabIndex = 4
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(147, 44)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 25)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "Add Trarif"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(85, 44)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(56, 20)
        Me.txtQty.TabIndex = 2
        Me.txtQty.Text = "1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Quantity :"
        '
        'cbTarRif
        '
        Me.cbTarRif.FormattingEnabled = True
        Me.cbTarRif.Location = New System.Drawing.Point(85, 20)
        Me.cbTarRif.Name = "cbTarRif"
        Me.cbTarRif.Size = New System.Drawing.Size(349, 21)
        Me.cbTarRif.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Trarif Code:"
        '
        'btnCfs
        '
        Me.btnCfs.Enabled = False
        Me.btnCfs.Location = New System.Drawing.Point(447, 6)
        Me.btnCfs.Name = "btnCfs"
        Me.btnCfs.Size = New System.Drawing.Size(92, 30)
        Me.btnCfs.TabIndex = 9
        Me.btnCfs.Text = "CFS or LCL"
        Me.btnCfs.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(8, 113)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(553, 368)
        Me.TabControl1.TabIndex = 10
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Controls.Add(Me.btnCfs)
        Me.TabPage1.Controls.Add(Me.lblRecord)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(545, 342)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Container Detail"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 42)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(533, 294)
        Me.DataGridView1.TabIndex = 9
        '
        'lblRecord
        '
        Me.lblRecord.AutoSize = True
        Me.lblRecord.Location = New System.Drawing.Point(46, 23)
        Me.lblRecord.Name = "lblRecord"
        Me.lblRecord.Size = New System.Drawing.Size(13, 13)
        Me.lblRecord.TabIndex = 8
        Me.lblRecord.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Total :"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnRecal)
        Me.TabPage2.Controls.Add(Me.txtDeliver)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.GroupBox7)
        Me.TabPage2.Controls.Add(Me.GroupBox6)
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.lblDwellRecord)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.dgDwell)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(545, 342)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Dwell Detail"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnRecal
        '
        Me.btnRecal.Location = New System.Drawing.Point(478, 6)
        Me.btnRecal.Name = "btnRecal"
        Me.btnRecal.Size = New System.Drawing.Size(56, 20)
        Me.btnRecal.TabIndex = 19
        Me.btnRecal.Text = "Re-Cal"
        Me.btnRecal.UseVisualStyleBackColor = True
        '
        'txtDeliver
        '
        Me.txtDeliver.Location = New System.Drawing.Point(369, 6)
        Me.txtDeliver.Name = "txtDeliver"
        Me.txtDeliver.Size = New System.Drawing.Size(103, 20)
        Me.txtDeliver.TabIndex = 18
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(307, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Deliver On :"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.lblTotal15Day)
        Me.GroupBox7.Location = New System.Drawing.Point(369, 252)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(115, 84)
        Me.GroupBox7.TabIndex = 16
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Total > 15 Day"
        '
        'lblTotal15Day
        '
        Me.lblTotal15Day.AutoSize = True
        Me.lblTotal15Day.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal15Day.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblTotal15Day.Location = New System.Drawing.Point(18, 18)
        Me.lblTotal15Day.Name = "lblTotal15Day"
        Me.lblTotal15Day.Size = New System.Drawing.Size(78, 55)
        Me.lblTotal15Day.TabIndex = 1
        Me.lblTotal15Day.Text = "00"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.lblTotal14Day)
        Me.GroupBox6.Location = New System.Drawing.Point(248, 252)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(115, 84)
        Me.GroupBox6.TabIndex = 15
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Total 8-15 Day"
        '
        'lblTotal14Day
        '
        Me.lblTotal14Day.AutoSize = True
        Me.lblTotal14Day.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal14Day.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblTotal14Day.Location = New System.Drawing.Point(18, 15)
        Me.lblTotal14Day.Name = "lblTotal14Day"
        Me.lblTotal14Day.Size = New System.Drawing.Size(78, 55)
        Me.lblTotal14Day.TabIndex = 1
        Me.lblTotal14Day.Text = "00"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblTotal7Day)
        Me.GroupBox5.Location = New System.Drawing.Point(127, 252)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(115, 84)
        Me.GroupBox5.TabIndex = 14
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Total 1-7 Day"
        '
        'lblTotal7Day
        '
        Me.lblTotal7Day.AutoSize = True
        Me.lblTotal7Day.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal7Day.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblTotal7Day.Location = New System.Drawing.Point(18, 15)
        Me.lblTotal7Day.Name = "lblTotal7Day"
        Me.lblTotal7Day.Size = New System.Drawing.Size(78, 55)
        Me.lblTotal7Day.TabIndex = 1
        Me.lblTotal7Day.Text = "00"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblTotaldWell)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 252)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(115, 84)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Total dWell"
        '
        'lblTotaldWell
        '
        Me.lblTotaldWell.AutoSize = True
        Me.lblTotaldWell.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotaldWell.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblTotaldWell.Location = New System.Drawing.Point(14, 16)
        Me.lblTotaldWell.Name = "lblTotaldWell"
        Me.lblTotaldWell.Size = New System.Drawing.Size(78, 55)
        Me.lblTotaldWell.TabIndex = 0
        Me.lblTotaldWell.Text = "00"
        '
        'lblDwellRecord
        '
        Me.lblDwellRecord.AutoSize = True
        Me.lblDwellRecord.Location = New System.Drawing.Point(46, 7)
        Me.lblDwellRecord.Name = "lblDwellRecord"
        Me.lblDwellRecord.Size = New System.Drawing.Size(13, 13)
        Me.lblDwellRecord.TabIndex = 12
        Me.lblDwellRecord.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 7)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Total :"
        '
        'dgDwell
        '
        Me.dgDwell.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDwell.Location = New System.Drawing.Point(3, 32)
        Me.dgDwell.Name = "dgDwell"
        Me.dgDwell.Size = New System.Drawing.Size(533, 214)
        Me.dgDwell.TabIndex = 10
        '
        'frmManifestImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1047, 481)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmManifestImport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Import Container"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgDwell, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnGetData As Button
    Friend WithEvents txtBooking As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnFullout As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtAgent As TextBox
    Friend WithEvents txtLine As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cbTarRif As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents txtQty As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents dgItem As DataGridView
    Friend WithEvents btnClearAll As Button
    Friend WithEvents btnAddBL As Button
    Friend WithEvents btnCopyToClipboard As Button
    Friend WithEvents btnAddCFS As Button
    Friend WithEvents txtDateUntil As TextBox
    Friend WithEvents txtShore As TextBox
    Friend WithEvents txtCarrier As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblGross As Label
    Friend WithEvents lblPackage As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents chkAddress As CheckBox
    Friend WithEvents btnCfs As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents lblRecord As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dgDwell As DataGridView
    Friend WithEvents lblDwellRecord As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents lblTotal15Day As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents lblTotal14Day As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents lblTotal7Day As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents lblTotaldWell As Label
    Friend WithEvents btnRecal As Button
    Friend WithEvents txtDeliver As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents chkCheckFirst As CheckBox
End Class
