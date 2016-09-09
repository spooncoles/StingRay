Module modValidateBanking
    Public Function checkBankDetails(accNum As String, bankName As String, branchCode As String, accType As String) As String
        Dim accountType As Integer = 0
        Select Case accType
            Case "Cheque"
                accountType = 1
            Case "Savings"
                accountType = 2
            Case "Transmission"
                accountType = 3
        End Select

        If Not validateBranchCode(bankName, branchCode) Then
            Return "Branch Code incorrect"
            Exit Function
        End If


        accNum = "00000000000".Substring(0, 11 - accNum.Length) & accNum

        Return "Not Validated"
    End Function

    Private Function validateBranchCode(bankName As String, branchCode As String) As Boolean
        conn.fillDS("SELECT branchFrom, branchTo FROM sys_banking_branches WHERE bankName = '" & bankName & "'", "branches")
        Return False
    End Function
End Module
