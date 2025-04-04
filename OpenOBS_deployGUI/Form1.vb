﻿
Imports System.Diagnostics
Imports System.Threading
Imports System.Drawing
Imports System.Windows.Forms
Imports ArduinoUploader

Public Class Form1
    'battery variables
    Const continuousCurrent = 2.0
    Const onCurrent = 10.8
    Const offCurrent = 0.05
    Const onTime = 0.96
    Dim battery_mah = 2000

    Const textColumns = 50

    'Dim WithEvents comPort As New IO.Ports.SerialPort
    Dim comPort As New IO.Ports.SerialPort
    Dim connected As Boolean = False

    Dim intervalSetting As Date
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpInterval.Format = DateTimePickerFormat.Custom
        dtpInterval.CustomFormat = "HH:mm:ss"
        dtpStartTime.Format = DateTimePickerFormat.Custom
        dtpStartTime.CustomFormat = "HH:mm"

        btnSend.BackColor = Color.DarkGray
        serialLog.ReadOnly = True
        serialLog.BackColor = Color.White

        cbBattery.SelectedIndex = 0

        'Settings for SerialPort.
        comPort.BaudRate = 250000
        comPort.DtrEnable = True 'force Arduino reset
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Dim currentTime As UInt32 = (DateTime.Now - #1970/1/1#).TotalSeconds
        Dim delayStart = GetDelaySeconds()
        Dim measureInterval = (dtpInterval.Value - #1970/1/1#).TotalSeconds

        ' Build the flags byte:
        Dim measBitFlags As Byte = 0
        If cbAmbientLight.Checked Then measBitFlags = measBitFlags Or 1 ' Bit 0
        If cbBackscatter.Checked Then measBitFlags = measBitFlags Or 2 ' Bit 1
        If cbPressure.Checked Then measBitFlags = measBitFlags Or 4 ' Bit 2
        If cbTemperature.Checked Then measBitFlags = measBitFlags Or 8 ' Bit 3

        Dim current As Integer = nudCurrent.Value

        Dim settings = "SET," & currentTime & "," & measureInterval & "," & delayStart & "," & measBitFlags & "," & current
        SendMessage(settings)

    End Sub
    Private Sub SendMessage(sentence As String)
        If Not connected Then
            Return
        End If

        Dim message = "$" & sentence & "*" & GetChecksum(sentence)
        comPort.Write(message)
        LogText(message, "right")
    End Sub

    Private Sub cbContinuous_CheckedChanged(sender As Object, e As EventArgs) Handles cbContinuous.CheckedChanged
        dtpInterval.Enabled = Not cbContinuous.Checked
        If cbContinuous.Checked Then
            intervalSetting = dtpInterval.Value
            dtpInterval.Value = #1/1/1970# 'set time to 00:00:00
        Else
            dtpInterval.Value = intervalSetting 'return last time
        End If
    End Sub

    Private Sub cbDelay_CheckedChanged(sender As Object, e As EventArgs) Handles cbDelay.CheckedChanged
        dtpStartDate.Value = DateTime.Now
        dtpStartTime.Value = DateTime.Now
        dtpStartDate.Enabled = cbDelay.Checked
        dtpStartTime.Enabled = cbDelay.Checked
        updateBattery()
    End Sub

    Function GetDelaySeconds() As UInt32
        Dim delayDT = New Date(dtpStartDate.Value.Date.Ticks +
                               dtpStartTime.Value.TimeOfDay.Ticks)
        Dim delaySeconds = (delayDT - DateTime.Now).TotalSeconds
        If delaySeconds < 0 Then
            'Delay defaults to last time checkbox was toggled. Left unchanged, this gives a negative delay.
            Return 0
        End If
        Return delaySeconds
    End Function

    Function GetChecksum(sentence As String) As String
        Dim checksum As Integer = 0
        For Each Character As Char In sentence
            checksum = checksum Xor Convert.ToByte(Character)
        Next
        Return checksum.ToString("X2")
    End Function

    Function ValidateChecksum(message As String) As Boolean
        If String.IsNullOrEmpty(message) Then
            Return False
        End If

        Dim StartIdx = message.IndexOf("$")
        Dim EndIdx = message.IndexOf("*")

        ' Ensure valid positions and checksum length
        If StartIdx = -1 Or EndIdx = -1 Then
            Return False ' Missing start or end markers
        End If

        ' Check if there are at least 2 characters after the asterisk for the checksum
        If EndIdx + 3 > message.Length Then
            Return False ' Not enough characters for checksum
        End If

        'Prevent negative length in substring
        If EndIdx - StartIdx - 1 < 0 Then
            Return False
        End If

        Dim sentence = message.Substring(StartIdx + 1, EndIdx - StartIdx - 1)
        Dim expectedChecksum As String = GetChecksum(sentence)
        Dim providedChecksum As String = message.Substring(EndIdx + 1, 2)

        ' Case-insensitive comparison
        Return expectedChecksum.Equals(providedChecksum, StringComparison.OrdinalIgnoreCase)
    End Function

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        If btnConnect.Text.Equals("Connect") Then
            'attempt to connect
            connectCOM(cbPorts.SelectedItem)
            btnConnect.Text = "Disconnect"
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
            If comPort.IsOpen Then
                comPort.Close()
            End If
            btnConnect.Text = "Connect"
            btnSend.Enabled = False
            btnSend.BackColor = Color.DarkGray
            tbSN.Text = ""
            connected = False

        End If
    End Sub

    Private Sub connectCOM(PortName As String)
        On Error Resume Next
        If comPort.IsOpen Then
            comPort.Close()
        End If
        comPort.PortName = PortName
        comPort.Open()
        serialLog.ResetText()
    End Sub

    Private Sub parseMessage(message As String)
        Dim StartIdx = message.IndexOf("$")
        Dim EndIdx = message.IndexOf("*")
        Dim sentence = message.Substring(StartIdx + 1, EndIdx - StartIdx - 1)
        Dim words As String() = sentence.Split(",")

        If words(0).Equals("OPENOBS") Then
            connected = True
            SendMessage("OPENOBS")
            If words(1) IsNot Nothing Then
                tbSN.Text = words(1)
            End If
        ElseIf words(0).Equals("READY") Then
            btnSend.Enabled = True
            btnSend.BackColor = Color.YellowGreen
            LogText("Connected", "center")
            LogText("Send settings when ready", "center")
        ElseIf words(0).Equals("SET") And words(1).Equals("SUCCESS") Then
            btnSend.Enabled = False
            btnSend.BackColor = Color.DarkGray
            LogText("Settings Received", "center")
        ElseIf words(0).Equals("FILE") And words(1).Equals("OPEN") Then
            LogText("Sample Readings", "center")
        ElseIf words(0).Equals("SDINIT") And words(1).Equals("0") Then
            LogText("SD initialization failed", "center")
            LogText("Check for missing or corrupted SD card", "center")
        ElseIf words(0).Equals("CLKINIT") And words(1).Equals("0") Then
            LogText("RTC initialization failed", "center")
        ElseIf words(0).Equals("ADCINIT") And words(1).Equals("0") Then
            LogText("ADC initialization failed", "center")
        End If
    End Sub

    Private Sub VersionSwitch(version As String)
        Select Case version
            Case "328"
                BatteryPanel.Visible = True
            Case "Iridium"
                BatteryPanel.Visible = False
        End Select
    End Sub

    Private Sub LogText(str As String, Optional just As String = "left")
        Select Case just
            Case "left"
                serialLog.AppendText(str & Environment.NewLine)
            Case "right"
                Dim logStr = String.Format("{0," & textColumns & "}", str)
                serialLog.AppendText(logStr & Environment.NewLine)
            Case "center"
                Dim halfIdx As Integer = textColumns / 2 + str.Length() / 2
                Dim logStr = String.Format("{0," & halfIdx & "}", str)
                serialLog.AppendText(logStr & Environment.NewLine)
        End Select

    End Sub


    Private Sub cbPorts_DropDown(sender As Object, e As EventArgs) Handles cbPorts.DropDown
        cbPorts.Items.Clear()
        For Each sp As String In IO.Ports.SerialPort.GetPortNames
            cbPorts.Items.Add(sp)
        Next
    End Sub

    Private Sub link328_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link328.LinkClicked
        Dim url As String = "https://github.com/tedlanghorst/OpenOBS-328/"
        Dim psi As New ProcessStartInfo(url) With {.UseShellExecute = True}
        Process.Start(psi)
    End Sub

    Private Sub linkIridium_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkIridium.LinkClicked
        Dim url As String = "https://github.com/tedlanghorst/OpenOBS-Iridium/"
        Dim psi As New ProcessStartInfo(url) With {.UseShellExecute = True}
        Process.Start(psi)
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If comPort.IsOpen() = True Then
            Dim ReceivedMessage As String = comPort.ReadExisting()

            If ValidateChecksum(ReceivedMessage) Then
                serialLog.AppendText(ReceivedMessage)
                parseMessage(ReceivedMessage)
            End If
        End If
    End Sub

    Private Sub displayBatterySettings(show As Boolean)
        lblCapacity.Visible = show
        tbCapacity.Visible = show
    End Sub

    Private Sub dtpInterval_ValueChanged(sender As Object, e As EventArgs) Handles dtpInterval.ValueChanged,
        dtpStartDate.ValueChanged,
        dtpStartTime.ValueChanged,
        cbBattery.SelectedIndexChanged
        'tbCapacity.TextChanged,
        'tbVoltage.TextChanged,

        updateBattery()
    End Sub

    Private Sub tbCapacity_ValueChanged(sender As Object, e As EventArgs) Handles tbCapacity.TextChanged
        updateBattery()
        sender.Focus()
        'tbCapacity.SelectionStart = tbCapacity.Text.Length
    End Sub

    Private Sub updateBattery()
        'get battery configuration
        Select Case cbBattery.SelectedIndex()
            Case 0
                '2000 mAh Li-SOCL2
                displayBatterySettings(False)
                battery_mah = 2000
            Case 1
                '800 mAh Li-ion
                displayBatterySettings(False)
                battery_mah = 800

            Case 2
                'custom battery settings
                displayBatterySettings(True)
                Try
                    battery_mah = Integer.Parse(tbCapacity.Text)
                Catch
                    Return
                End Try
        End Select

        Dim delaySeconds = GetDelaySeconds()
        Dim delayBattery_mAh = battery_mah - (offCurrent * (delaySeconds / 3600))
        Dim offTime = (dtpInterval.Value - #1970/1/1#).TotalSeconds - onTime
        If offTime < 0 Then
            offTime = 0
        End If

        Dim averageConsumption_mA
        If offTime > 5 Then
            'weighted average current draw
            averageConsumption_mA = ((onCurrent * onTime) + (offCurrent * offTime)) / (offTime + onTime)
        Else
            averageConsumption_mA = continuousCurrent
        End If

        Dim battery_days = delayBattery_mAh / averageConsumption_mA / 24 + (delaySeconds / 3600 / 24)
        tbBattery.Text = Format(battery_days, "0.0")
    End Sub

    Private Sub btnHexSend_Click(sender As Object, e As EventArgs) Handles btnHexSend.Click
        'check that a port is selected
        Dim portName As String
        If cbPorts.SelectedIndex > -1 Then
            portName = cbPorts.SelectedItem
        Else
            LogText("Select a COM port", "center")
            Exit Sub
        End If

        'disconnect from com port before trying to send hex.
        If btnConnect.Text.Equals("Disconnect") Then
            Timer1.Enabled = False
            If comPort.IsOpen Then
                comPort.Close()
            End If
            btnConnect.Text = "Connect"
        End If


        Dim fileName As String
        Using dialog As New OpenFileDialog
            dialog.Filter = "hex files (*.hex)|*.hex"
            If dialog.ShowDialog() <> DialogResult.OK Then Return
            fileName = dialog.FileName
        End Using

        Dim uploadOptions = New ArduinoSketchUploaderOptions()
        uploadOptions.FileName = fileName
        'uploadOptions.FileName = "C:\Users\Ted\Downloads\OpenOBS-328.ino_atmega328p_8000000L.hex"
        uploadOptions.PortName = portName
        uploadOptions.ArduinoModel = Hardware.ArduinoModel.NanoR3
        Dim uploader = New ArduinoSketchUploader(uploadOptions)
        LogText("Uploading hex file", "center")
        uploader.UploadSketch()
        LogText("Upload complete", "center")
    End Sub

End Class
