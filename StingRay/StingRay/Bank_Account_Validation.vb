Module Bank_Account_Validation
    Dim digitSum As Integer
    Dim remainder As Integer
    Dim fudge As Byte
    Dim modder As Byte
    Dim weightCode As String

    Function CheckBankCode(accNo As String, BankName As String) As Boolean
        Dim missingZeros As Integer
        Dim digits(0 To 10) As Byte

        Dim multiCode(0 To 5) As String
        Dim multiMod(0 To 5) As Byte

        Dim correctDetails As Boolean
        Dim absaCheck As Byte
        Dim accNoOrig As String
        digitSum = 0
        remainder = 0
        accNoOrig = accNo

        'Can use replace for zero's - see salesfile
        missingZeros = 11 - Len(accNo)
        While missingZeros > 0
            accNo = "0" & accNo
            missingZeros = missingZeros - 1
        End While


        If Len(accNo) > 11 Then
            For i = 0 To 10
                digits(i) = CByte(Mid(accNo, i + 2, 1))
            Next
        Else
            For i = 0 To 10
                digits(i) = CByte(Mid(accNo, i + 1, 1))
            Next
        End If

        'FNB
        If BankName = "FNB" Or BankName = "Fnb" Then
            weightCode = "12121212121"
            fudge = 0
            modder = 10

        ElseIf BankName = "Standard Bank" Then

            weightCode = "11987654321"
            fudge = 0
            modder = 11

        ElseIf BankName = "Nedbank" Then

            weightCode = "11987654321"
            modder = 11

            If Left(accNoOrig, 1) = 1 Then
                fudge = 9
            Else
                fudge = 18
            End If

        ElseIf BankName = "Capitec" Then
            weightCode = "21987654321"
            fudge = 0
            modder = 11

        ElseIf BankName = "Absa" Or BankName = "ABSA" Then
            multiCode(0) = "17329874321"
            multiCode(1) = "14327654321"
            multiCode(2) = "54327654321"
            multiCode(3) = "11327654321"
            multiCode(4) = "11327654321"
            multiCode(5) = "14329874321"
            multiMod(0) = 10
            multiMod(1) = 11
            multiMod(2) = 11
            multiMod(3) = 11
            multiMod(4) = 11
            multiMod(5) = 10
            fudge = 0

        ElseIf BankName = "PEP Bank" Then
            weightCode = "18765432100"
            fudge = 2
            modder = 11

        ElseIf BankName = "BoE" Then
            weightCode = "18765432100"
            fudge = 0
            modder = 11


        ElseIf BankName = "SA Bank of Athens" Then
            weightCode = "11987654321"
            fudge = 0
            modder = 11

        ElseIf BankName = "Wizzit" Then
            weightCode = "11987654321"
            fudge = 0
            modder = 11

        ElseIf BankName = "African Bank" Then
            weightCode = "12121212121"
            fudge = 0
            modder = 10

        ElseIf BankName = "Post Bank" Then
            weightCode = "42184218421"
            fudge = 0
            modder = 10

        ElseIf BankName = "Standard Chartered" Then
            weightCode = "42184218421"
            fudge = 0
            modder = 11

        ElseIf BankName = "Ithala" Then
            weightCode = "12121212121"
            fudge = 0
            modder = 10

        ElseIf BankName = "Post Bank" Then
            weightCode = "42184218421"
            fudge = 0
            modder = 10

        ElseIf BankName = "Rennies" Then
            weightCode = "27654321000"
            fudge = 0
            modder = 11

        ElseIf BankName = "Bidvest" Then
            weightCode = "27654321000"
            fudge = 0
            modder = 11
        ElseIf BankName = "Investec" Then
            fudge = 0
            modder = 11
        Else
            CheckBankCode = False
            Exit Function
        End If


        If BankName = "Investec" Then
            correctDetails = InvestecModCheck(digits, 11)

        ElseIf BankName = "FNB" Then
            If digits(1) <> 0 Then
                correctDetails = ModCheck(digits, weightCode, modder, fudge)
            Else
                correctDetails = False
            End If

        ElseIf BankName = "Standard Bank" Then

            correctDetails = ModCheckStandard(digits, weightCode, modder, fudge)

        ElseIf BankName <> "Absa" And BankName <> "ABSA" Then
            correctDetails = ModCheck(digits, weightCode, modder, fudge)

        Else
            absaCheck = 0

            For j = 0 To 5
                If ModCheck(digits, multiCode(j), multiMod(j), fudge) Then
                    absaCheck = absaCheck + 1
                End If
            Next

            If (digits(0) <> 0 Or digits(1) <> 0) And (digits(10) = 0 Or digits(10) = 1) Then
                If ModCheckAbsa3(digits, multiCode(2), multiMod(2), fudge) Then
                    absaCheck = absaCheck + 1
                End If
            End If

            If ModCheckAbsa5(digits, multiCode(4), multiMod(4), fudge) Then
                absaCheck = absaCheck + 1
            End If


            If absaCheck > 0 Then
                correctDetails = True
            Else
                correctDetails = False
            End If

        End If

        If correctDetails Then
            CheckBankCode = True
        Else
            CheckBankCode = False
        End If


    End Function

    Function ModCheck(digits() As Byte, weightCode As String, modder As Byte, fudge As Byte) As Boolean

        For k = 0 To 10
            digitSum = digitSum + digits(k) * CByte(Mid(weightCode, k + 1, 1))
        Next
        remainder = (digitSum + fudge) Mod modder

        If remainder <> 0 Then
            ModCheck = False
        Else
            ModCheck = True
        End If

    End Function

    Function ModCheckStandard(digits() As Byte, weightCode As String, modder As Byte, fudge As Byte) As Boolean

        If digits(0) = 0 And digits(1) = 0 Then
            For k = 0 To 10
                digitSum = digitSum + digits(k) * CByte(Mid(weightCode, k + 1, 1))
            Next
        Else

            digitSum = digitSum + digits(0) * 13
            digitSum = digitSum + digits(1) * 12

            For k = 2 To 10
                digitSum = digitSum + digits(k) * CByte(Mid(weightCode, k, 1))
            Next


        End If

        remainder = (digitSum + fudge) Mod modder

        If remainder <> 0 Then
            ModCheckStandard = False
        Else
            ModCheckStandard = True
        End If

    End Function

    Function ModCheckAbsa3(digits() As Byte, weightCode As String, modder As Byte, fudge As Byte) As Boolean

        For k = 0 To 10
            digitSum = digitSum + digits(k) * CByte(Mid(weightCode, k + 1, 1))
        Next
        remainder = (digitSum + fudge) Mod modder

        If remainder <> 1 Then
            ModCheckAbsa3 = False
        Else
            ModCheckAbsa3 = True
        End If

    End Function

    Function ModCheckAbsa5(digits() As Byte, weightCode As String, modder As Byte, fudge As Byte) As Boolean

        If digits(10) < 4 Then
            digits(10) = digits(10) + 6
        Else
            digits(10) = digits(10) + 6 - 10
        End If

        For k = 0 To 10
            digitSum = digitSum + digits(k) * CByte(Mid(weightCode, k + 1, 1))
        Next
        remainder = (digitSum + fudge) Mod modder

        If remainder <> 0 Then
            ModCheckAbsa5 = False
        Else
            ModCheckAbsa5 = True
        End If

    End Function

    Function InvestecModCheck(digits() As Byte, modder As Byte) As Boolean
        Dim weightings(0 To 10) As Byte

        weightings(0) = 0
        weightings(1) = 0
        weightings(2) = 0
        weightings(3) = 23
        weightings(4) = 19
        weightings(5) = 17
        weightings(6) = 13
        weightings(7) = 7
        weightings(8) = 5
        weightings(9) = 3
        weightings(10) = 1

        For k = 0 To 10
            digitSum = digitSum + digits(k) * weightings(k)
        Next
        remainder = (digitSum + fudge) Mod modder

        If remainder <> 0 Then
            InvestecModCheck = False
        Else
            InvestecModCheck = True
        End If

    End Function

    Function CheckBranchCode(BranchCode As Long, BankName As String) As String
        Dim invalidBranchCode As Boolean

        invalidBranchCode = True
        'FNB
        If BankName = "FNB" Or BankName = "Fnb" Then

            If 200000 < BranchCode And BranchCode < 299999 Then
                invalidBranchCode = False
            End If

        ElseIf BankName = "Standard Bank" Then

            If (0 < BranchCode And BranchCode < 60066) Or (63968 < BranchCode And BranchCode < 99999) Then
                invalidBranchCode = False
            End If

        ElseIf BankName = "Nedbank" Then
            If 100000 < BranchCode And BranchCode < 199999 Then
                invalidBranchCode = False
            End If

        ElseIf BankName = "Capitec" Then
            If 470000 < BranchCode And BranchCode < 470999 Then
                invalidBranchCode = False
            End If

        ElseIf BankName = "ABSA" Then

            If (300000 < BranchCode And BranchCode < 349999) Or (420000 < BranchCode And BranchCode < 429999) Or (500000 < BranchCode And BranchCode < 569999) Or (630000 < BranchCode And BranchCode < 659999) Then
                invalidBranchCode = False
            End If

        ElseIf BankName = "PEP Bank" Then
            If 400000 < BranchCode And BranchCode < 400999 Then
                invalidBranchCode = False
            End If

        ElseIf BankName = "BoE" Then
            If 440000 < BranchCode And BranchCode < 449999 Then
                invalidBranchCode = False
            End If

        ElseIf BankName = "SA Bank of Athens" Then
            If 410000 < BranchCode And BranchCode < 419999 Then
                invalidBranchCode = False
            End If

        ElseIf BankName = "African Bank" Then
            If 430000 < BranchCode And BranchCode < 430999 Then
                invalidBranchCode = False
            End If

        ElseIf BankName = "Post Bank" Then
            If 460000 < BranchCode And BranchCode < 460999 Then
                invalidBranchCode = False
            End If

        ElseIf BankName = "Standard Chartered" Then
            If 730000 < BranchCode And BranchCode < 730999 Then
                invalidBranchCode = False
            End If

        ElseIf BankName = "Ithala" Then
            If 750000 < BranchCode And BranchCode < 759999 Then
                invalidBranchCode = False
            End If

        ElseIf BankName = "Rennies" Then
            If 462000 < BranchCode And BranchCode < 462999 Then
                invalidBranchCode = False
            End If

        ElseIf BankName = "Bidvest" Then
            If 462000 < BranchCode And BranchCode < 462999 Then
                invalidBranchCode = False
            End If
        ElseIf BankName = "Investec" Then
            If 580000 < BranchCode And BranchCode < 580999 Then
                invalidBranchCode = False
            End If
        Else
            CheckBranchCode = "Bank Name Unknown"
        End If

        If invalidBranchCode Then
            CheckBranchCode = "Invalid"
        Else
            CheckBranchCode = "Correct"
        End If
    End Function

End Module
