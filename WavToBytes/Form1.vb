Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        openFileDialog.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles openFileDialog.FileOk
        txtFileName.Text = openFileDialog.SafeFileName

        'Enable Other Controls
        If String.IsNullOrEmpty(txtFileName.Text).Equals(False) Then
            UpdateUI(True)
        Else
            UpdateUI(False)
        End If
    End Sub

    Private Sub bytesDifferenceBar_MouseUp(sender As Object, e As MouseEventArgs) Handles bytesDifferenceBar.MouseUp
        bytesDifferenceBar.Value = CInt((Math.Round(bytesDifferenceBar.Value / 50.0) * 50))
    End Sub

    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        saveFileDialog.FileName = openFileDialog.FileName
        saveFileDialog.ShowDialog()
    End Sub

    Private Sub saveFileDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles saveFileDialog.FileOk
        ' Disable All Controls
        UpdateUI(False)
        btnBrowse.Enabled = False
        lblBrowseWaveFile.Enabled = False

        ' Enable Progress Bar Only
        progressBar.Enabled = True

        ' Modify Wave File & update Progress Bar
        Dim waveUtilites As WavesUtilites = New WavesUtilites()

        'waveUtilites.CopyWaveFile(openFileDialog.FileName, saveFileDialog.FileName)
        'progressBar.PerformStep()

        'waveUtilites.RetriveWaveFileData(saveFileDialog.FileName)
        'progressBar.PerformStep()

        'waveUtilites.ModifyWaveFileData(saveFileDialog.FileName, bytesDifferenceBar.Value)
        'waveUtilites.SynthesizeWaveFileData(saveFileDialog.FileName)
        'waveUtilites.ModifyWaveSampleRate(saveFileDialog.FileName)
        waveUtilites.ChangeBitsPerSample(openFileDialog.FileName, saveFileDialog.FileName)
        progressBar.PerformStep()

        ' Play Updated File
        'If chbPlay.Checked Then
        '    Dim memoryStream As IO.MemoryStream = New IO.MemoryStream(IO.File.ReadAllBytes(updatedFilePath))
        '    Dim player As System.Media.SoundPlayer = New Media.SoundPlayer(memoryStream)
        '    player.Play()
        'End If

        ' Display Message to User
        MessageBox.Show("File conversion completed" + If(chbPlay.Checked, " & played", String.Empty) + " successfully.")

        ' Reset UI to Intial Stage
        btnBrowse.Enabled = True
        lblBrowseWaveFile.Enabled = True
        progressBar.Value = 0

    End Sub

    Private Sub UpdateUI(enable As Boolean)
        lblBytesDifference.Enabled = enable
        lblBytesValues.Enabled = enable
        progressBar.Enabled = enable
        btnConvert.Enabled = enable
        bytesDifferenceBar.Enabled = enable
        chbPlay.Enabled = enable
    End Sub


End Class
