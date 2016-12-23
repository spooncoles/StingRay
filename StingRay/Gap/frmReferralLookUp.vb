Public Class frmReferralLookUp
    Private Sub btSearch_Click(sender As Object, e As EventArgs) Handles btSearch.Click
        Dim searchFields As New List(Of WaterMarkTextBox) From {txName, txContactNum, txEmailAdd, txIDNum}
        Dim searchString As String = "SELECT adminCode, affinityName, contactNum, emailAdd, Vat_ID from affinities"
        Dim whereString As String = " WHERE "
        For Each field As WaterMarkTextBox In searchFields
            If field.Text <> "" Then
                whereString = whereString & field.Tag & " LIKE '%" & field.Text & "%', "
            End If
        Next

        If whereString <> " WHERE " Then
            searchString = searchString & whereString.Substring(0, whereString.Length - 2)
            searchString += " AND campaign = '" & campaign & "'"
        Else
            searchString += "AND campaign = '" & campaign & "'"
        End If

        conn.fillDS(searchString, "referralDetails")

        dgReferralDetails.DataSource = conn.ds.Tables("referralDetails")

    End Sub

    Private Sub txContactNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txContactNum.KeyPress
        If Asc(e.KeyChar) = 13 Then btSearch.PerformClick()
    End Sub

    Private Sub txEmailAdd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txEmailAdd.KeyPress
        If Asc(e.KeyChar) = 13 Then btSearch.PerformClick()
    End Sub

    Private Sub txIDNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txIDNum.KeyPress
        If Asc(e.KeyChar) = 13 Then btSearch.PerformClick()
    End Sub

    Private Sub txName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txName.KeyPress
        If Asc(e.KeyChar) = 13 Then btSearch.PerformClick()
    End Sub

    Private Sub frmReferralLookUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Are you sure you would Like To export all Zwingers?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            notify("Pulling data...")
            conn.fillDS("Select adminCode, affinityName, contactNum, Vat_ID, emailAdd, loadedBy FROM zestlife.affinities WHERE type = 'Zwing'", "zwingers")
            exportDataTable(conn.ds.Tables("zwingers"))
        End If
    End Sub

    Private Sub btExportWithAddress_Click(sender As Object, e As EventArgs) Handles btExportWithAddress.Click
        If MsgBox("Are you sure you would like to export all Zwingers?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            notify("Pulling data...")
            conn.fillDS("SELECT adminCode, affinityName, contactNum, Vat_ID, emailAdd, affinities.loadedBy, postal1, postal2, postalSuburb, postalCity, postalProvince, postalCode FROM zestlife.affinities " _
                         & "LEFT JOIN (SELECT idnumber, postal1, postal2, postalSuburb, postalCity, postalProvince, postalCode FROM lead_primary INNER JOIN lead_address ON lead_primary.leadID = lead_address.leadID WHERE idnumber IS NOT NULL) as a " _
                         & "ON idnumber = Vat_ID WHERE type = 'Zwing'", "zwingers")
            exportDataTable(conn.ds.Tables("zwingers"))
        End If
    End Sub
End Class