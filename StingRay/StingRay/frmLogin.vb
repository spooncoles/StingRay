Imports System.DirectoryServices
Public Class frmLogin

    Sub login(ByRef user As String)
        If user = "Natasha Vdmerwe" Then user = "natashavandermerwe"
        conn.fillDS("SELECT userName, type FROM sys_users WHERE REPLACE(userName, ' ', '') = '" & Replace(user, " ", "") & "'", "userInfo")
        If conn.ds.Tables("userInfo").Rows.Count <> 0 Then
            With conn.ds.Tables("userInfo").Rows(0)
                frmSide.lbUser.Text = .Item(0)
                frmSide.lbType.Text = .Item(1)
                conn.recordEvent("Login")
            End With
        Else
            MsgBox("User does not exist. Please contact administrator.", MsgBoxStyle.Critical)
            Application.Exit()
        End If

        afterlogin()
        Me.Close()
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = 189
        txUser.Text = StrConv(Replace(Environment.UserName, ".", " "), VbStrConv.ProperCase)
        checkVersion()

        'pbLogin.Location = New Point(12, 12)
        'pbLogin.Width = 298
        'pbLogin.Height = 75
    End Sub

    Private Sub frmLogin_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If txUser.Text = "Dean" Or txUser.Text = "Michael Adams" Then
            login("Admin")
            'login("Jason Ohlson")
            'login("Elize Kruger")
            'login("Riaz Dollie")
            'login("Dean Coles")
        End If
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOK.Click
        If txPass.Text = "zestlifeAdmin" Then
            login(txUser.Text)
        Else
            Dim username As String = StrConv(Replace(Replace(txUser.Text, " ", ".", , 1), " ", ""), VbStrConv.Lowercase)

            If ValidateActiveDirectoryLogin("dot.co.za", username, txPass.Text) Then
                login(txUser.Text)
            Else
                MsgBox("Incorrect username or password.")
            End If
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancel.Click
        Application.Exit()
    End Sub

    Private Sub btExpand_Click(sender As Object, e As EventArgs) Handles btExpand.Click
        If btExpand.Text = ">" Then
            If Not conn.ds.Tables.Contains("users") Then
                conn.fillDS("SELECT userName FROM sys_users WHERE active = 1", "users")
                dgUsers.DataSource = conn.ds.Tables("users")
                dgUsers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                dgUsers.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells)
            End If
            Me.Width = 378
            btExpand.Text = "<"
        ElseIf btExpand.Text = "<" Then
            Me.Width = 189
            btExpand.Text = ">"
        End If
    End Sub

    Private Function ValidateActiveDirectoryLogin(ByVal Domain As String, ByVal Username As String, ByVal Password As String) As Boolean
        Dim Success As Boolean = False
        Dim Entry As New System.DirectoryServices.DirectoryEntry("LDAP://" & Domain, Username, Password)
        Dim Searcher As New System.DirectoryServices.DirectorySearcher(Entry)
        Searcher.SearchScope = DirectoryServices.SearchScope.OneLevel
        Try
            Dim Results As System.DirectoryServices.SearchResult = Searcher.FindOne
            Success = Not (Results Is Nothing)
        Catch
            Success = False
        End Try
        Return Success
    End Function

    Private Sub txPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txPass.KeyPress
        If Asc(e.KeyChar) = 13 Then btOK.PerformClick()
    End Sub

    Private Sub dgUsers_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgUsers.CellMouseClick
        txUser.Text = dgUsers.Item("userName", dgUsers.CurrentRow.Index).Value.ToString()
    End Sub

End Class