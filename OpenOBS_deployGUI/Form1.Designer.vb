﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnSend = New System.Windows.Forms.Button()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.serialLog = New System.Windows.Forms.RichTextBox()
        Me.tbBattery = New System.Windows.Forms.TextBox()
        Me.dtpStartTime = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.cbDelay = New System.Windows.Forms.CheckBox()
        Me.dtpInterval = New System.Windows.Forms.DateTimePicker()
        Me.cbContinuous = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbPorts = New System.Windows.Forms.ComboBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.tbSN = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.link328 = New System.Windows.Forms.LinkLabel()
        Me.cbBattery = New System.Windows.Forms.ComboBox()
        Me.tbCapacity = New System.Windows.Forms.TextBox()
        Me.lblCapacity = New System.Windows.Forms.Label()
        Me.lblBatteryConfig = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BatteryPanel = New System.Windows.Forms.Panel()
        Me.linkIridium = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnHexSend = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BatteryPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSend
        '
        Me.btnSend.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSend.Enabled = False
        Me.btnSend.Location = New System.Drawing.Point(223, 84)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(127, 29)
        Me.btnSend.TabIndex = 0
        Me.btnSend.Text = "Send Settings"
        Me.btnSend.UseVisualStyleBackColor = False
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(126, 29)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(89, 29)
        Me.btnConnect.TabIndex = 3
        Me.btnConnect.TabStop = False
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(157, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Est. Battery Life [days]:"
        '
        'serialLog
        '
        Me.serialLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.serialLog.Font = New System.Drawing.Font("Courier New", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.serialLog.Location = New System.Drawing.Point(379, 32)
        Me.serialLog.Name = "serialLog"
        Me.serialLog.ReadOnly = True
        Me.serialLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.serialLog.Size = New System.Drawing.Size(425, 533)
        Me.serialLog.TabIndex = 11
        Me.serialLog.Text = ""
        '
        'tbBattery
        '
        Me.tbBattery.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbBattery.Location = New System.Drawing.Point(174, 83)
        Me.tbBattery.Name = "tbBattery"
        Me.tbBattery.ReadOnly = True
        Me.tbBattery.Size = New System.Drawing.Size(90, 27)
        Me.tbBattery.TabIndex = 13
        '
        'dtpStartTime
        '
        Me.dtpStartTime.Enabled = False
        Me.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartTime.Location = New System.Drawing.Point(246, 350)
        Me.dtpStartTime.Name = "dtpStartTime"
        Me.dtpStartTime.ShowUpDown = True
        Me.dtpStartTime.Size = New System.Drawing.Size(78, 27)
        Me.dtpStartTime.TabIndex = 14
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Enabled = False
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(143, 350)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(97, 27)
        Me.dtpStartDate.TabIndex = 17
        '
        'cbDelay
        '
        Me.cbDelay.AutoSize = True
        Me.cbDelay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.cbDelay.Location = New System.Drawing.Point(26, 350)
        Me.cbDelay.Name = "cbDelay"
        Me.cbDelay.Size = New System.Drawing.Size(114, 21)
        Me.cbDelay.TabIndex = 18
        Me.cbDelay.Text = "Delayed start"
        Me.cbDelay.UseVisualStyleBackColor = True
        '
        'dtpInterval
        '
        Me.dtpInterval.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInterval.Location = New System.Drawing.Point(224, 269)
        Me.dtpInterval.Name = "dtpInterval"
        Me.dtpInterval.ShowUpDown = True
        Me.dtpInterval.Size = New System.Drawing.Size(104, 27)
        Me.dtpInterval.TabIndex = 15
        Me.dtpInterval.Value = New Date(1970, 1, 1, 0, 15, 0, 0)
        '
        'cbContinuous
        '
        Me.cbContinuous.AutoSize = True
        Me.cbContinuous.Location = New System.Drawing.Point(26, 297)
        Me.cbContinuous.Name = "cbContinuous"
        Me.cbContinuous.Size = New System.Drawing.Size(149, 24)
        Me.cbContinuous.TabIndex = 5
        Me.cbContinuous.Text = "Continuous (1 Hz)"
        Me.cbContinuous.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 274)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(195, 20)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Sample Interval [HH:mm:ss]:"
        '
        'cbPorts
        '
        Me.cbPorts.FormattingEnabled = True
        Me.cbPorts.Location = New System.Drawing.Point(12, 30)
        Me.cbPorts.Name = "cbPorts"
        Me.cbPorts.Size = New System.Drawing.Size(94, 28)
        Me.cbPorts.TabIndex = 20
        '
        'Timer1
        '
        Me.Timer1.Interval = 25
        '
        'tbSN
        '
        Me.tbSN.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbSN.Location = New System.Drawing.Point(105, 85)
        Me.tbSN.Name = "tbSN"
        Me.tbSN.ReadOnly = True
        Me.tbSN.Size = New System.Drawing.Size(71, 27)
        Me.tbSN.TabIndex = 21
        Me.tbSN.Text = "N/A"
        Me.tbSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Serial No."
        '
        'link328
        '
        Me.link328.AutoSize = True
        Me.link328.Location = New System.Drawing.Point(77, 558)
        Me.link328.Name = "link328"
        Me.link328.Size = New System.Drawing.Size(103, 20)
        Me.link328.TabIndex = 24
        Me.link328.TabStop = True
        Me.link328.Text = "OpenOBS-328"
        '
        'cbBattery
        '
        Me.cbBattery.FormattingEnabled = True
        Me.cbBattery.Items.AddRange(New Object() {"2000 mAh Li-SOCL2", "800 mAh Li-ion", "Custom (3.3-5V)"})
        Me.cbBattery.Location = New System.Drawing.Point(11, 46)
        Me.cbBattery.Name = "cbBattery"
        Me.cbBattery.Size = New System.Drawing.Size(269, 28)
        Me.cbBattery.TabIndex = 27
        '
        'tbCapacity
        '
        Me.tbCapacity.Location = New System.Drawing.Point(192, 116)
        Me.tbCapacity.Name = "tbCapacity"
        Me.tbCapacity.Size = New System.Drawing.Size(58, 27)
        Me.tbCapacity.TabIndex = 28
        Me.tbCapacity.Text = "2000"
        Me.tbCapacity.Visible = False
        '
        'lblCapacity
        '
        Me.lblCapacity.AutoSize = True
        Me.lblCapacity.Location = New System.Drawing.Point(11, 116)
        Me.lblCapacity.Name = "lblCapacity"
        Me.lblCapacity.Size = New System.Drawing.Size(114, 20)
        Me.lblCapacity.TabIndex = 29
        Me.lblCapacity.Text = "Capacity [mAh]:"
        Me.lblCapacity.Visible = False
        '
        'lblBatteryConfig
        '
        Me.lblBatteryConfig.AutoSize = True
        Me.lblBatteryConfig.BackColor = System.Drawing.Color.Transparent
        Me.lblBatteryConfig.Location = New System.Drawing.Point(11, 13)
        Me.lblBatteryConfig.Name = "lblBatteryConfig"
        Me.lblBatteryConfig.Size = New System.Drawing.Size(149, 20)
        Me.lblBatteryConfig.TabIndex = 32
        Me.lblBatteryConfig.Text = "Battery configuration"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(7, 131)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(366, 123)
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'BatteryPanel
        '
        Me.BatteryPanel.Controls.Add(Me.lblBatteryConfig)
        Me.BatteryPanel.Controls.Add(Me.lblCapacity)
        Me.BatteryPanel.Controls.Add(Me.cbBattery)
        Me.BatteryPanel.Controls.Add(Me.tbCapacity)
        Me.BatteryPanel.Controls.Add(Me.Label3)
        Me.BatteryPanel.Controls.Add(Me.tbBattery)
        Me.BatteryPanel.Location = New System.Drawing.Point(12, 395)
        Me.BatteryPanel.Name = "BatteryPanel"
        Me.BatteryPanel.Size = New System.Drawing.Size(338, 160)
        Me.BatteryPanel.TabIndex = 33
        '
        'linkIridium
        '
        Me.linkIridium.AutoSize = True
        Me.linkIridium.Location = New System.Drawing.Point(186, 558)
        Me.linkIridium.Name = "linkIridium"
        Me.linkIridium.Size = New System.Drawing.Size(126, 20)
        Me.linkIridium.TabIndex = 34
        Me.linkIridium.TabStop = True
        Me.linkIridium.Text = "OpenOBS-Iridium"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 558)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 20)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Github:"
        '
        'btnHexSend
        '
        Me.btnHexSend.Location = New System.Drawing.Point(249, 29)
        Me.btnHexSend.Name = "btnHexSend"
        Me.btnHexSend.Size = New System.Drawing.Size(104, 29)
        Me.btnHexSend.TabIndex = 36
        Me.btnHexSend.TabStop = False
        Me.btnHexSend.Text = "Upload .hex"
        Me.btnHexSend.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(221, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 20)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "OR"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(816, 591)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnHexSend)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.linkIridium)
        Me.Controls.Add(Me.BatteryPanel)
        Me.Controls.Add(Me.link328)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbSN)
        Me.Controls.Add(Me.cbPorts)
        Me.Controls.Add(Me.cbDelay)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.dtpInterval)
        Me.Controls.Add(Me.dtpStartTime)
        Me.Controls.Add(Me.serialLog)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbContinuous)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.btnSend)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "OpenOBS-328"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BatteryPanel.ResumeLayout(False)
        Me.BatteryPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSend As Button
    Friend WithEvents btnConnect As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents serialLog As RichTextBox
    Friend WithEvents tbBattery As TextBox
    Friend WithEvents dtpStartTime As DateTimePicker
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents cbDelay As CheckBox
    Friend WithEvents dtpInterval As DateTimePicker
    Friend WithEvents cbContinuous As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbPorts As ComboBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents tbSN As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents link_328 As LinkLabel
    Friend WithEvents cbBattery As ComboBox
    Friend WithEvents tbCapacity As TextBox
    Friend WithEvents lblCapacity As Label
    Friend WithEvents lblBatteryConfig As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BatteryPanel As Panel
    Friend WithEvents linkIridium As LinkLabel
    Friend WithEvents link328 As LinkLabel
    Friend WithEvents Label4 As Label
    Friend WithEvents btnHexSend As Button
    Friend WithEvents Label5 As Label
End Class
