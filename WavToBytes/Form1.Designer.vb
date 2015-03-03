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
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.lblBrowseWaveFile = New System.Windows.Forms.Label()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.lblBytesDifference = New System.Windows.Forms.Label()
        Me.saveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.btnConvert = New System.Windows.Forms.Button()
        Me.bytesDifferenceBar = New System.Windows.Forms.TrackBar()
        Me.lblBytesValues = New System.Windows.Forms.Label()
        Me.progressBar = New System.Windows.Forms.ProgressBar()
        Me.chbPlay = New System.Windows.Forms.CheckBox()
        CType(Me.bytesDifferenceBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'openFileDialog
        '
        Me.openFileDialog.DefaultExt = "wav"
        Me.openFileDialog.Filter = "Wave Sound Files (*.wav)|*.wav"
        Me.openFileDialog.Title = "Select File"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(351, 14)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 0
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'lblBrowseWaveFile
        '
        Me.lblBrowseWaveFile.AutoSize = True
        Me.lblBrowseWaveFile.Location = New System.Drawing.Point(12, 19)
        Me.lblBrowseWaveFile.Name = "lblBrowseWaveFile"
        Me.lblBrowseWaveFile.Size = New System.Drawing.Size(93, 13)
        Me.lblBrowseWaveFile.TabIndex = 1
        Me.lblBrowseWaveFile.Text = "Browse Wave File"
        '
        'txtFileName
        '
        Me.txtFileName.Enabled = False
        Me.txtFileName.Location = New System.Drawing.Point(112, 16)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(233, 20)
        Me.txtFileName.TabIndex = 2
        '
        'lblBytesDifference
        '
        Me.lblBytesDifference.AutoSize = True
        Me.lblBytesDifference.Enabled = False
        Me.lblBytesDifference.Location = New System.Drawing.Point(12, 60)
        Me.lblBytesDifference.Name = "lblBytesDifference"
        Me.lblBytesDifference.Size = New System.Drawing.Size(85, 13)
        Me.lblBytesDifference.TabIndex = 3
        Me.lblBytesDifference.Text = "Bytes Difference"
        '
        'saveFileDialog
        '
        Me.saveFileDialog.DefaultExt = "wav"
        Me.saveFileDialog.Filter = "Wave Sound Files (*.wav)|*.wav"
        '
        'btnConvert
        '
        Me.btnConvert.Enabled = False
        Me.btnConvert.Location = New System.Drawing.Point(351, 112)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(75, 23)
        Me.btnConvert.TabIndex = 3
        Me.btnConvert.Text = "Convert"
        Me.btnConvert.UseVisualStyleBackColor = True
        '
        'bytesDifferenceBar
        '
        Me.bytesDifferenceBar.Enabled = False
        Me.bytesDifferenceBar.LargeChange = 100
        Me.bytesDifferenceBar.Location = New System.Drawing.Point(112, 69)
        Me.bytesDifferenceBar.Maximum = 200
        Me.bytesDifferenceBar.Minimum = -200
        Me.bytesDifferenceBar.Name = "bytesDifferenceBar"
        Me.bytesDifferenceBar.Size = New System.Drawing.Size(205, 45)
        Me.bytesDifferenceBar.SmallChange = 50
        Me.bytesDifferenceBar.TabIndex = 1
        Me.bytesDifferenceBar.TickFrequency = 50
        '
        'lblBytesValues
        '
        Me.lblBytesValues.AutoSize = True
        Me.lblBytesValues.Enabled = False
        Me.lblBytesValues.Location = New System.Drawing.Point(109, 53)
        Me.lblBytesValues.Name = "lblBytesValues"
        Me.lblBytesValues.Size = New System.Drawing.Size(208, 13)
        Me.lblBytesValues.TabIndex = 6
        Me.lblBytesValues.Text = "-200  -150 -100  -50   0    50  100  150 200"
        '
        'progressBar
        '
        Me.progressBar.Enabled = False
        Me.progressBar.Location = New System.Drawing.Point(15, 112)
        Me.progressBar.Maximum = 60
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(330, 23)
        Me.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.progressBar.TabIndex = 7
        '
        'chbPlay
        '
        Me.chbPlay.AutoSize = True
        Me.chbPlay.Enabled = False
        Me.chbPlay.Location = New System.Drawing.Point(351, 59)
        Me.chbPlay.Name = "chbPlay"
        Me.chbPlay.Size = New System.Drawing.Size(46, 17)
        Me.chbPlay.TabIndex = 2
        Me.chbPlay.Text = "Play"
        Me.chbPlay.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chbPlay.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 144)
        Me.Controls.Add(Me.chbPlay)
        Me.Controls.Add(Me.progressBar)
        Me.Controls.Add(Me.lblBytesValues)
        Me.Controls.Add(Me.bytesDifferenceBar)
        Me.Controls.Add(Me.btnConvert)
        Me.Controls.Add(Me.lblBytesDifference)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.lblBrowseWaveFile)
        Me.Controls.Add(Me.btnBrowse)
        Me.Name = "Form1"
        Me.Text = "Wave Modifier"
        CType(Me.bytesDifferenceBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents openFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents lblBrowseWaveFile As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents lblBytesDifference As System.Windows.Forms.Label
    Friend WithEvents saveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnConvert As System.Windows.Forms.Button
    Friend WithEvents bytesDifferenceBar As System.Windows.Forms.TrackBar
    Friend WithEvents lblBytesValues As System.Windows.Forms.Label
    Friend WithEvents progressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents chbPlay As System.Windows.Forms.CheckBox

End Class
