﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnGetData = New System.Windows.Forms.Button()
        Me.txtBooking = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.lblRecord = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnFullout = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAgent = New System.Windows.Forms.TextBox()
        Me.txtLine = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnCopyToClipboard = New System.Windows.Forms.Button()
        Me.btnAddBL = New System.Windows.Forms.Button()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.dgItem = New System.Windows.Forms.DataGridView()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbTarRif = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAddCFS = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnGetData)
        Me.GroupBox1.Controls.Add(Me.txtBooking)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(554, 73)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "B/L Detail"
        '
        'btnGetData
        '
        Me.btnGetData.Location = New System.Drawing.Point(444, 23)
        Me.btnGetData.Name = "btnGetData"
        Me.btnGetData.Size = New System.Drawing.Size(95, 37)
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
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(8, 112)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(554, 357)
        Me.DataGridView1.TabIndex = 2
        '
        'lblRecord
        '
        Me.lblRecord.AutoSize = True
        Me.lblRecord.Location = New System.Drawing.Point(48, 96)
        Me.lblRecord.Name = "lblRecord"
        Me.lblRecord.Size = New System.Drawing.Size(13, 13)
        Me.lblRecord.TabIndex = 6
        Me.lblRecord.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Total :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnFullout)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtAgent)
        Me.GroupBox2.Controls.Add(Me.txtLine)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(568, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(470, 99)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Full-Out"
        '
        'btnFullout
        '
        Me.btnFullout.Enabled = False
        Me.btnFullout.Location = New System.Drawing.Point(55, 56)
        Me.btnFullout.Name = "btnFullout"
        Me.btnFullout.Size = New System.Drawing.Size(269, 37)
        Me.btnFullout.TabIndex = 4
        Me.btnFullout.Text = "Import to CTCS"
        Me.btnFullout.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(157, 30)
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
        'btnAddCFS
        '
        Me.btnAddCFS.Location = New System.Drawing.Point(96, 321)
        Me.btnAddCFS.Name = "btnAddCFS"
        Me.btnAddCFS.Size = New System.Drawing.Size(101, 25)
        Me.btnAddCFS.TabIndex = 8
        Me.btnAddCFS.Text = "Add CFS Rent to"
        Me.btnAddCFS.UseVisualStyleBackColor = True
        '
        'frmManifestImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1047, 481)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblRecord)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmManifestImport"
        Me.Text = "Import Container"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnGetData As Button
    Friend WithEvents txtBooking As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents lblRecord As Label
    Friend WithEvents Label4 As Label
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
End Class