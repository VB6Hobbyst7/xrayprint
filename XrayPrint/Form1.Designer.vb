<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtContainer = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.txtBooking = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtSpecial = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkSendmail = New System.Windows.Forms.CheckBox()
        Me.lblBooking = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbB1 = New System.Windows.Forms.RadioButton()
        Me.rbA0 = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbCheck = New System.Windows.Forms.RadioButton()
        Me.rbXray = New System.Windows.Forms.RadioButton()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.txtPlateNumber = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblContainer = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblRecord = New System.Windows.Forms.Label()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.btnImportFullout = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.txtContainer)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnQuery)
        Me.GroupBox1.Controls.Add(Me.txtBooking)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(481, 111)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Booking Info"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(355, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Clear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtContainer
        '
        Me.txtContainer.Location = New System.Drawing.Point(67, 71)
        Me.txtContainer.Name = "txtContainer"
        Me.txtContainer.Size = New System.Drawing.Size(200, 20)
        Me.txtContainer.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Container"
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(274, 30)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(75, 23)
        Me.btnQuery.TabIndex = 2
        Me.btnQuery.Text = "Get Detail"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'txtBooking
        '
        Me.txtBooking.Location = New System.Drawing.Point(67, 30)
        Me.txtBooking.Name = "txtBooking"
        Me.txtBooking.Size = New System.Drawing.Size(200, 20)
        Me.txtBooking.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Booking"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 133)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(672, 357)
        Me.DataGridView1.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSpecial)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.chkSendmail)
        Me.GroupBox2.Controls.Add(Me.lblBooking)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.btnPrint)
        Me.GroupBox2.Controls.Add(Me.txtPlateNumber)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lblLocation)
        Me.GroupBox2.Controls.Add(Me.lblContainer)
        Me.GroupBox2.Location = New System.Drawing.Point(690, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(218, 478)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fast Lane Print"
        '
        'txtSpecial
        '
        Me.txtSpecial.Location = New System.Drawing.Point(12, 304)
        Me.txtSpecial.Multiline = True
        Me.txtSpecial.Name = "txtSpecial"
        Me.txtSpecial.Size = New System.Drawing.Size(190, 163)
        Me.txtSpecial.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 282)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Special Request :"
        '
        'chkSendmail
        '
        Me.chkSendmail.AutoSize = True
        Me.chkSendmail.Checked = True
        Me.chkSendmail.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSendmail.Location = New System.Drawing.Point(13, 262)
        Me.chkSendmail.Name = "chkSendmail"
        Me.chkSendmail.Size = New System.Drawing.Size(79, 17)
        Me.chkSendmail.TabIndex = 17
        Me.chkSendmail.Text = "Send Email"
        Me.chkSendmail.UseVisualStyleBackColor = True
        '
        'lblBooking
        '
        Me.lblBooking.AutoSize = True
        Me.lblBooking.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBooking.Location = New System.Drawing.Point(70, 67)
        Me.lblBooking.Name = "lblBooking"
        Me.lblBooking.Size = New System.Drawing.Size(25, 24)
        Me.lblBooking.TabIndex = 16
        Me.lblBooking.Text = "..."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "B/L :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbB1)
        Me.GroupBox4.Controls.Add(Me.rbA0)
        Me.GroupBox4.Location = New System.Drawing.Point(113, 88)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(89, 69)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Terminal"
        '
        'rbB1
        '
        Me.rbB1.AutoSize = True
        Me.rbB1.Location = New System.Drawing.Point(6, 42)
        Me.rbB1.Name = "rbB1"
        Me.rbB1.Size = New System.Drawing.Size(38, 17)
        Me.rbB1.TabIndex = 8
        Me.rbB1.Text = "B1"
        Me.rbB1.UseVisualStyleBackColor = True
        '
        'rbA0
        '
        Me.rbA0.AutoSize = True
        Me.rbA0.Checked = True
        Me.rbA0.Location = New System.Drawing.Point(6, 19)
        Me.rbA0.Name = "rbA0"
        Me.rbA0.Size = New System.Drawing.Size(38, 17)
        Me.rbA0.TabIndex = 7
        Me.rbA0.TabStop = True
        Me.rbA0.Text = "A0"
        Me.rbA0.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbCheck)
        Me.GroupBox3.Controls.Add(Me.rbXray)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 88)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(97, 69)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Type"
        '
        'rbCheck
        '
        Me.rbCheck.AutoSize = True
        Me.rbCheck.Location = New System.Drawing.Point(8, 42)
        Me.rbCheck.Name = "rbCheck"
        Me.rbCheck.Size = New System.Drawing.Size(69, 17)
        Me.rbCheck.TabIndex = 14
        Me.rbCheck.Text = "เปิดตรวจ"
        Me.rbCheck.UseVisualStyleBackColor = True
        '
        'rbXray
        '
        Me.rbXray.AutoSize = True
        Me.rbXray.Checked = True
        Me.rbXray.Location = New System.Drawing.Point(8, 19)
        Me.rbXray.Name = "rbXray"
        Me.rbXray.Size = New System.Drawing.Size(57, 17)
        Me.rbXray.TabIndex = 13
        Me.rbXray.TabStop = True
        Me.rbXray.Text = "X-RAY"
        Me.rbXray.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(9, 223)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(193, 35)
        Me.btnPrint.TabIndex = 9
        Me.btnPrint.Text = "Print Fast-lane"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'txtPlateNumber
        '
        Me.txtPlateNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlateNumber.Location = New System.Drawing.Point(9, 183)
        Me.txtPlateNumber.Name = "txtPlateNumber"
        Me.txtPlateNumber.Size = New System.Drawing.Size(194, 29)
        Me.txtPlateNumber.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 167)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Vehicle License no :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Position :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Container :"
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.Location = New System.Drawing.Point(70, 40)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(25, 24)
        Me.lblLocation.TabIndex = 1
        Me.lblLocation.Text = "..."
        '
        'lblContainer
        '
        Me.lblContainer.AutoSize = True
        Me.lblContainer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContainer.Location = New System.Drawing.Point(70, 16)
        Me.lblContainer.Name = "lblContainer"
        Me.lblContainer.Size = New System.Drawing.Size(25, 24)
        Me.lblContainer.TabIndex = 0
        Me.lblContainer.Text = "..."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Total :"
        '
        'lblRecord
        '
        Me.lblRecord.AutoSize = True
        Me.lblRecord.Location = New System.Drawing.Point(52, 115)
        Me.lblRecord.Name = "lblRecord"
        Me.lblRecord.Size = New System.Drawing.Size(13, 13)
        Me.lblRecord.TabIndex = 4
        Me.lblRecord.Text = "0"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'btnImportFullout
        '
        Me.btnImportFullout.Location = New System.Drawing.Point(508, 9)
        Me.btnImportFullout.Name = "btnImportFullout"
        Me.btnImportFullout.Size = New System.Drawing.Size(157, 40)
        Me.btnImportFullout.TabIndex = 5
        Me.btnImportFullout.Text = "Import Full-out"
        Me.btnImportFullout.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 502)
        Me.Controls.Add(Me.btnImportFullout)
        Me.Controls.Add(Me.lblRecord)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.Text = "Xray Fast-Lane Request"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnQuery As Button
    Friend WithEvents txtBooking As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblLocation As Label
    Friend WithEvents lblContainer As Label
    Friend WithEvents txtPlateNumber As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnPrint As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents rbB1 As RadioButton
    Friend WithEvents rbA0 As RadioButton
    Friend WithEvents rbCheck As RadioButton
    Friend WithEvents rbXray As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents lblRecord As Label
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents txtContainer As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents lblBooking As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents chkSendmail As CheckBox
    Friend WithEvents txtSpecial As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnImportFullout As Button
End Class
