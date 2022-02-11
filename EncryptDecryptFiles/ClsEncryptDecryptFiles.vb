﻿Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Public Class ClsEncryptDecryptFiles

    Public Sub New(_KEY As String)

        KeyStr = _KEY

    End Sub

    Private KeyValue As String
    Public Property KeyStr() As String
        Get
            Return KeyValue
        End Get
        Set(ByVal value As String)
            KeyValue = value
        End Set
    End Property

    Function Encryption(ByVal Path As String) As Byte()

        Dim input As Byte() = File.ReadAllBytes(Path)

        Dim AES As New RijndaelManaged
        Dim SHA256 As New SHA256Cng
        Dim ciphertext As String = ""
        Try
            AES.Key = SHA256.ComputeHash(ASCIIEncoding.ASCII.GetBytes(KeyStr))
            AES.Mode = CipherMode.ECB
            Dim DESEncrypter As ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = input
            Return DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length)
        Catch ex As Exception
        End Try
    End Function

    Function Decryption(ByVal Path As String) As Byte()

        Dim input As Byte() = File.ReadAllBytes(Path)

        Dim AES As New RijndaelManaged
        Dim SHA256 As New SHA256Cng
        Try
            AES.Key = SHA256.ComputeHash(ASCIIEncoding.ASCII.GetBytes(KeyStr))
            AES.Mode = CipherMode.ECB
            Dim DESDecrypter As ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = input
            Return DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length)
        Catch ex As Exception
        End Try
    End Function

End Class
