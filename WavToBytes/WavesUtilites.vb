Imports NAudio

Public Class WavesUtilites

    Public FileHeader As Header
    Public FileFormatSubChunk As FormatSubChunk
    Public FileDataSubChunk As DataSubChunk
    Private StreamPoisition As Long

    Public Structure WaveFileOptions
        Public SampleRate As WavSampleRate
        Public AudioFormat As Format
        Public BitsPerSample As BitsPerSample
        Public NumberOfChannels As NumberOfChannels
        Public FormatSize As FormatSize
        Public NumberOfSamples As UInt32
        Public Data As Int16()
    End Structure
    '                                               DATATYPE          OFFSET        Endian           Description
    Structure Header
        Public Property ChunkID As Byte() '          Dword              0             Big            Contains the letters "RIFF" in ASCII form(0x52494646 big-endian form).
        Public Property ChunkSize As UInt32 '        Dword              4             Little         36 + SubChunk2Size, or more precisely: 4 + (8 + SubChunk1Size) + (8 + SubChunk2Size)
        Public Property Format As Byte() '           Dword              8             Big            Contains the letters "WAVE" in ASCII form (0x57415645 big-endian form).
    End Structure

    Structure FormatSubChunk
        Public Property Subchunk1ID As Byte() '      Dword              12            Big            Contains the letters "fmt "(0x666d7420 big-endian form).
        Public Property Subchunk1Size As UInt32 '    Dword              16            little         16 for PCM.  This is the size of the rest of the Subchunk which follows this number.
        Public Property AudioFormat As UInt16  '     Word               20            little         PCM = 1 (i.e. Linear quantization)Values other than 1 indicate some form of compression.
        Public Property NumChannels As UInt16 '      Word               22            little         Mono = 1, Stereo = 2, etc.
        Public Property SampleRate As UInt32 '       Dword              24            little         8000, 44100, etc.
        Public Property ByteRate As UInt32 '         Dword              28            little         == SampleRate * NumChannels * BitsPerSample/8
        Public Property BlockAlign As UInt16 '       Word               32            little         == NumChannels * BitsPerSample/8
        Public Property BitsPerSample As UInt16 '    Word               34            little         8 bits = 8, 16 bits = 16, etc.
    End Structure

    Structure DataSubChunk
        Public Property Subchunk2ID As Byte() '      Dword              36            Big            Contains the letters "data"(0x64617461 big-endian form).
        Public Property Subchunk2Size As UInt32 '    Dword              40            little         == NumSamples * NumChannels * BitsPerSample/8     This is the number of bytes in the data.
        Public Property Data As Int16() '             VariableLength     44            little         The actual sound data.
    End Structure

    Public Enum WavSampleRate As UInt32
        hz8000 = 8000
        hz11025 = 11025
        hz16000 = 16000
        hz22050 = 22050
        hz32000 = 32000
        hz44100 = 44100
        hz48000 = 48000
        hz96000 = 96000
        hz192000 = 192000
    End Enum

    Public Enum Format As UInt16
        Standard = 1
    End Enum

    Public Enum BitsPerSample As UInt16
        bps_8 = 8
        bps_16 = 16
        bps_32 = 32
        bps_64 = 64
        bps_128 = 128
        bps_256 = 256
    End Enum

    Public Enum NumberOfChannels As UInt16
        Mono = 1
        Stereo = 2
    End Enum

    Public Enum FormatSize As UInt32
        PCM = 16
    End Enum

    Public Sub CopyWaveFile(ByVal sourcePath As String, ByVal destinationPath As String)

        If IO.File.Exists(destinationPath) = False Then
            IO.File.Copy(sourcePath, destinationPath)
        End If

    End Sub

    Public Sub RetriveWaveFileData(ByVal filePath As String)

        Dim stream As IO.FileStream = New IO.FileStream(filePath, IO.FileMode.Open, IO.FileAccess.Read)

        Dim reader As System.IO.BinaryReader = New IO.BinaryReader(stream)

        stream.Position = 0

        ' Getting File Headers
        FileHeader.ChunkID = reader.ReadBytes(4)
        FileHeader.ChunkSize = reader.ReadUInt32()
        FileHeader.Format = reader.ReadBytes(4)

        ' Get Format Sub Chunk
        FileFormatSubChunk.Subchunk1ID = reader.ReadBytes(4)
        FileFormatSubChunk.Subchunk1Size = reader.ReadUInt32()
        FileFormatSubChunk.AudioFormat = reader.ReadUInt16()
        FileFormatSubChunk.NumChannels = reader.ReadUInt16()
        FileFormatSubChunk.SampleRate = reader.ReadUInt32()
        FileFormatSubChunk.ByteRate = reader.ReadUInt32()
        FileFormatSubChunk.BlockAlign = reader.ReadUInt16()
        FileFormatSubChunk.BitsPerSample = reader.ReadUInt16()

        ' Get Data Sub Chunk
        FileDataSubChunk.Subchunk2ID = reader.ReadBytes(4)
        FileDataSubChunk.Subchunk2Size = reader.ReadUInt32()

        ' Get Data Bytes
        Dim dataBytes As List(Of Int16) = New List(Of Int16)

        'If stream.Position < stream.Length Then
        '    StreamPoisition = stream.Position
        'End If

        Do While stream.Position < stream.Length
            dataBytes.Add(reader.ReadInt16())
        Loop

        FileDataSubChunk.Data = dataBytes.ToArray()

        reader.Close()
    End Sub

    Public Sub ModifyWaveFileData(ByVal filePath As String, ByVal value As Integer)

        Dim stream As IO.FileStream = New IO.FileStream(filePath, IO.FileMode.Open, IO.FileAccess.ReadWrite)

        Dim writer As IO.BinaryWriter = New IO.BinaryWriter(stream)

        stream.Position = StreamPoisition

        If FileDataSubChunk.Data.Length > 0 Then
            For index = 0 To FileDataSubChunk.Data.Length - 1
                Dim dataValue As Int16 = FileDataSubChunk.Data(index)

                Dim modifiedValue As Int16 = If(value > 0,
                                                  If((dataValue + value) > Int16.MaxValue, Int16.MaxValue, (dataValue + value)),
                                                  If((dataValue - value) < Int16.MinValue, Int16.MinValue, dataValue - value))

                writer.Write(modifiedValue)

                FileDataSubChunk.Data(index) = modifiedValue ' Write data back to data array
            Next
        End If

        writer.Close()
    End Sub

    Public Sub ModifyWaveSampleRate(ByVal filePath As String)

        Dim stream As IO.FileStream = New IO.FileStream(filePath, IO.FileMode.Open, IO.FileAccess.ReadWrite)

        Dim writer As IO.BinaryWriter = New IO.BinaryWriter(stream)

        stream.Position = StreamPoisition

        Dim sampleRate As UInt32 = 22050
        writer.Write(sampleRate)

        writer.Close()
    End Sub

    Public Sub ChangeBitsPerSample(ByVal sourcePath As String, ByVal destinationPath As String)
        Using waveFileReader As NAudio.Wave.WaveFileReader = New NAudio.Wave.WaveFileReader(sourcePath)
            Dim format As NAudio.Wave.WaveFormat = New Wave.WaveFormat(WavSampleRate.hz44100, 24, waveFileReader.WaveFormat.Channels)
            Using conversionStream = New Wave.WaveFormatConversionStream(format, waveFileReader)
                Wave.WaveFileWriter.CreateWaveFile(destinationPath, conversionStream)
            End Using
        End Using
    End Sub


    Public Sub SynthesizeWaveFileData(ByVal filePath As String)

        Dim stream As IO.FileStream = New IO.FileStream(filePath, IO.FileMode.Open, IO.FileAccess.ReadWrite)

        Dim writer As IO.BinaryWriter = New IO.BinaryWriter(stream)

        stream.Position = StreamPoisition

        If FileDataSubChunk.Data.Length > 0 Then
            For index = 0 To FileDataSubChunk.Data.Length - 2 ' Skip Last Sample for Comparison

                Dim currentDataValue As Int16 = FileDataSubChunk.Data(index) ' Getting value of current sample
                Dim nextDataValue As Int16 = FileDataSubChunk.Data(index + 1) ' Getting value of next sample
                Dim difference As Int16 = Math.Abs(nextDataValue - currentDataValue) ' Getting difference between current and next sample

                If difference > 40 Then

                    Dim adjustmentValue As Int16 = difference / 2

                    stream.Position = (index * 2) + StreamPoisition ' Adjust stream current position

                    currentDataValue = If(currentDataValue > 0, (currentDataValue - adjustmentValue), (currentDataValue + adjustmentValue)) ' Modify Current Sample Value
                    nextDataValue = If(nextDataValue > 0, (nextDataValue - adjustmentValue), (nextDataValue + adjustmentValue)) ' Modify Next Sample Value

                    writer.Write(currentDataValue) ' Write current sample to file
                    writer.Write(nextDataValue) ' Write next sample to file

                    FileDataSubChunk.Data(index) = currentDataValue ' Write current sample back to array
                    FileDataSubChunk.Data(index + 1) = nextDataValue ' Write next sample back to array

                End If

            Next
        End If

        writer.Close()

    End Sub

End Class
