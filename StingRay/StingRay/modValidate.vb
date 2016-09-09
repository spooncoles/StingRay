Imports System.Net.Mail
Imports System.Text.RegularExpressions
Imports System.DirectoryServices.AccountManagement
Module modValidate
    Public Function validateEmail(email As String) As Boolean
        Try
            Dim address As MailAddress = New MailAddress(email)
            address = Nothing
            If Regex.IsMatch(email, "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$") Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function validateContactNumber(number As String) As String
        number = Trim(number)
        If IsNumeric(number) Then
            If number.Length < 9 Then
                Return "Contact number too short!"
            Else
                Return "Pass"
            End If
        Else
            Return "Contact number is not numeric!"
        End If
    End Function

    Public Function validateIdNumber(idNumber As String) As String
        idNumber = Trim(idNumber)
        If Not IsNumeric(idNumber) Then
            Return "ID Number is not numeric!"
        Else

            If idNumber.Length <> 13 Then
                Return "ID Number is not the correct Length!"
            Else

                Try
                    Dim a As Integer = 0
                    For i As Integer = 0 To 5
                        a += CInt(idNumber.Substring(i * 2, 1))
                    Next

                    Dim b As Integer = 0
                    For i As Integer = 0 To 5
                        b = b * 10 + CInt(idNumber.Substring(2 * i + 1, 1))
                    Next
                    b *= 2
                    Dim c As Integer = 0
                    Do
                        c += b Mod 10
                        b = Int(b / 10)
                    Loop Until b <= 0
                    c += a
                    Dim d As Integer = 0
                    d = 10 - (c Mod 10)
                    If (d = 10) Then d = 0
                    If d = CInt(idNumber.Substring(12, 1)) Then
                        Return "Pass"
                    Else
                        Return "ID number not valid."
                    End If
                Catch ex As Exception
                    Return "ID number not valid."
                End Try


            End If

        End If
    End Function

    Public Function validateVatNumber(vatNumber As String) As String
        If Not IsNumeric(vatNumber) Then
            Return "VAT not numeric"
        Else

            Return "Pass"

                End If
    End Function

    'Public Function ifUserExists(userName As String) As Boolean

    '    Dim ctx As New PrincipalContext(ContextType.Domain)

    '    Dim user As UserPrincipal = UserPrincipal.FindByIdentity(ctx, Replace(Trim(userName), " ", "."))

    '    If user IsNot Nothing Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function
End Module
