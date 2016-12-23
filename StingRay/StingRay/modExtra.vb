Imports System.Net
Imports System.Net.Mail
Imports System
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Text
Imports MySql.Data.MySqlClient
Module modExtra

    Public conn As New clConn("224")

    Public dictAffType As New Dictionary(Of String, String)
    Public dictAffinities As New Dictionary(Of String, String)
    Public dictAgents As New Dictionary(Of String, Integer)
    Public dictProducts2016 As New Dictionary(Of String, String)
    Public dictProducts2017 As New Dictionary(Of String, String)
    Public sourcesArray() As String = {"SMS", "Email", "Warm", "Cold", "Call Centre", "Web Search", "Referral", "Radio Add", "CPT", "JHB", "Facebook"}
    Public leadTypeArray() As String = {"Inbound", "Outbound", "Zwing", "Liberty"}
    Public systemFolder As String = "\\zactfp03\Zestlife_home\Zestlife Call Centre\ZestSystem\"
    Public dtMedicalAids As New DataTable
    Public arrMedAidNames As Array
    Public dtStatuses As DataTable = Nothing
    Public recycleAvaliable As Boolean = False

    Public dtAddressesAll As New DataTable
    Public arrSuburbItems As Array
    Public arrCityItems As Array
    Public arrProvinceItems As Array

    Public teamLeader As Boolean = False

    Public campaign As String = ""

    Public Sub refreshSideBar()
        Dim agent As String = frmSide.lbUser.Text

        frmSide.btAllocated.Text = conn.sendReturn("SELECT COUNT(leadID) from lead_primary WHERE status = 'Allocated' AND agent = '" & agent & "'")

        frmSide.btBusy.Text = conn.sendReturn("SELECT COUNT(leadID) from lead_primary WHERE status = 'Busy' AND agent = '" & agent & "'")

        frmSide.btScheduled.Text = conn.sendReturn("SELECT COUNT(id) FROM zestlife.lead_reschedule INNER JOIN lead_primary ON lead_primary.leadID = lead_reschedule.leadID" _
                                   & " WHERE active = 1 AND DATE(rescheduleDateTime) <= DATE(NOW()) AND status = 'Busy' AND agent = '" & agent & "'")

        frmSide.btQaFails.Text = conn.sendReturn("SELECT COUNT(lead_sale_info.leadID) FROM lead_sale_info INNER JOIN lead_primary ON lead_primary.leadID = lead_sale_info.leadID WHERE qaStatus = 'Sent Back' AND status IN ('Sale', 'Busy') AND agent = '" & agent & "'")

        frmSide.btTransfers.Text = conn.sendReturn("SELECT count(leadID) from lead_primary WHERE status = 'Busy' AND outcome = 'Transfered' AND agent = '" & agent & "'")
        'Debug.Print(conn.sendReturn("SELECT viewSalesCount FROM sys_agent_info WHERE userName = '" & frmSide.lbUser.Text & "'"))
        If conn.sendReturn("SELECT viewSalesCount FROM sys_agent_info WHERE userName = '" & frmSide.lbUser.Text & "'") = "True" Then
            frmSide.btSales.Text = conn.sendReturn("SELECT count(leadID) from lead_primary WHERE status = 'Sale' AND MONTH(closedDate) = MONTH(CURDATE()) AND YEAR(closedDate) = YEAR(CURDATE()) AND agent = '" & agent & "'")
        Else
            frmSide.btSales.Text = "###"
        End If


        Dim sideButtons As New List(Of Button) From {frmSide.btSales, frmSide.btQaFails, frmSide.btScheduled, frmSide.btAllocated, frmSide.btBusy, frmSide.btTransfers}
        For Each bt In sideButtons
            If bt.Text = "NULL" Then bt.Text = "0"
        Next bt

        Dim recieveResponse As String = conn.sendReturn("SELECT recieveLeads FROM sys_agent_info WHERE userName = '" & frmSide.lbUser.Text & "'")
        If recieveResponse = "0" Then
            frmSide.cbRecieveLeads.Checked = False
            frmSide.cbRecieveLeads.ForeColor = Color.Red
        Else
            frmSide.cbRecieveLeads.Checked = True
            frmSide.cbRecieveLeads.ForeColor = Color.Black
        End If
        'If CInt(frmSide.btBusy.Text) > 300 Then
        '    frmSide.btBusy.BackColor = Color.Red
        'ElseIf CInt(frmSide.btBusy.Text) > 200 Then
        '    frmSide.btBusy.BackColor = Color.Orange
        'End If

    End Sub

    Public Sub afterlogin()

        Select Case frmSide.lbType.Text
            Case "Agent"
                Select Case campaign
                    Case "Gap"
                        frmMain.mainMenuAL.Visible = False
                    Case "AL"
                        frmMain.mainMenuGap.Visible = False


                End Select
                refreshSideBar()
                loadDictionaries(True, True, True, True, True, True)
                menuItems(True, False, False, False)

                If frmSide.btScheduled.Text <> 0 Then
                    notify("You have " & frmSide.btScheduled.Text & " rechedules today or before." & vbNewLine & "Please click ""Reschedule"" button in side bar to view.")
                End If

                If frmSide.btQaFails.Text <> 0 Then
                    MsgBox("You have outstanding QA fix(es). Please try resolve.", MsgBoxStyle.Critical)
                End If

                recycleAvaliable = conn.sendReturn("SELECT recycleAvaliable FROM sys_agent_info WHERE userName = '" & frmSide.lbUser.Text & "'")

                If conn.sendReturn("SELECT previousQueue FROM sys_agent_info WHERE userName = '" & frmSide.lbUser.Text & "'") <> "NULL" Then
                    loadQueue(frmSide.lbUser.Text)
                End If


            Case "QA Agent"
                loadDictionaries(True, True, False, False, False, False)
                menuItems(False, True, False, False)
                hideSideButtons()

            Case "Lead Admin"
                loadDictionaries(True, True, False, False, False, False)
                menuItems(False, False, True, False)
                hideSideButtons()

            Case "Sale Admin"
                loadDictionaries(False, False, False, False, False, False)
                menuItems(False, False, False, True)
                hideSideButtons()
                frmExportSalesFile.Show()
            Case "Referral Admin"
                loadDictionaries(False, False, False, False, False, False)
                menuItems(False, False, False, True)
                hideSideButtons()
                frmReferralLookUp.Show()
                frmMain.ExportSalesFileToolStripMenuItem.Visible = False

            Case "Admin"
                refreshSideBar()
                loadDictionaries(True, True, True, True, True, True)
        End Select

        Dim leaderCount As String = conn.sendReturn("SELECT COUNT(userName) FROM sys_agent_info WHERE teamleaderName = '" & frmSide.lbUser.Text & "'")
        If leaderCount <> "NULL" And leaderCount <> "0" Then
            teamLeader = True
            If dictAgents.Keys.Count = 0 Then loadDictionaries(True, False, False, False, False, False)

        Else
            teamLeader = False
            frmMain.menuIncentives.Visible = False
        End If

        'modSignalrClient.Main()
        frmMain.Show()

    End Sub

    Sub menuItems(agent As Boolean, qa As Boolean, leadAdmin As Boolean, saleAdmin As Boolean)

        If Not agent Then
            frmMain.menuFindLead.ShortcutKeys = Nothing
            frmMain.menuFindLeadAl.ShortcutKeys = Nothing
            frmMain.menuFindLead.Visible = False
            frmMain.menuFindLead.Enabled = False
            frmMain.menuLoadLead.Visible = False
            frmMain.menuLoadLead.Enabled = False
            frmMain.menuLoadReferral.Visible = False
            frmMain.menuLoadReferral.Enabled = False
        Else
            If campaign = "Gap" Then
                frmMain.menuFindLeadAl.ShortcutKeys = Nothing
                frmMain.mainMenuAL.Visible = False
            ElseIf campaign = "AL" Then
                frmMain.menuFindLead.ShortcutKeys = Nothing
                frmMain.mainMenuGap.Visible = False
            End If
        End If

        If Not qa Then
            frmMain.menuQA.Visible = False
            frmMain.menuQA.Enabled = False
        Else
            frmMain.menuQaPickUp.ShortcutKeys = 131142
            If frmSide.lbType.Text = "QA Agent" Then
                frmMain.mainMenuGap.Visible = False
                frmMain.mainMenuAL.Visible = False
            End If
        End If

        If Not leadAdmin Then
            frmMain.menuAdmin.Visible = False
            frmMain.menuAdmin.Enabled = False
            frmMain.menuChangeLeads.Visible = False
            frmMain.menuChangeLeads.Enabled = False
        Else
            frmMain.menuChangeLeads.ShortcutKeys = 131142
            frmMain.LoadLeadToolStripMenuItem.ShortcutKeys = 131150
            frmMain.menuLoadLead.Visible = True
            frmMain.menuLoadLead.Enabled = True
        End If

        If saleAdmin Then
            frmMain.menuAdmin.Enabled = True
            frmMain.menuAdmin.Visible = True
            frmMain.LoadLeadToolStripMenuItem.Visible = False
            frmMain.menuChangeLeads.Visible = False
            frmMain.menuLoadAfinity.Visible = False
            frmMain.menuNewUser.Visible = False
            frmMain.mainMenuGap.Visible = False
        End If

    End Sub

    Sub loadDictionaries(agents As Boolean, affinities As Boolean, products As Boolean, addresses As Boolean, medAids As Boolean, statuses As Boolean)
        If agents Then
            conn.fillDS("SELECT userName FROM sys_users WHERE active = 1 AND type = 'Agent' AND campaign = '" & campaign & "' ORDER BY userName", "agents")
            For Each agent In conn.ds.Tables("agents").Rows
                dictAgents.Add(agent.item(0), 0)
            Next agent
        End If

        If affinities Then
            conn.fillDS("SELECT affinityName, adminCode FROM zestlife.affinities WHERE affinity = 1 AND campaign = '" & campaign & "' ORDER BY affinityName", "affinities")
            dictAffinities.Add("Referal", 0)
            For Each affinity In conn.ds.Tables("affinities").Rows
                dictAffinities.Add(affinity.item(0), affinity.item(1))
            Next affinity

            conn.fillDS("SELECT adminCode, type FROM affinities WHERE affinity = 1 AND type NOT IN  ('Inbound', 'Zwing') AND campaign = '" & campaign & "'", "affTypes")
            For Each affinity In conn.ds.Tables("affTypes").Rows
                dictAffType.Add(affinity.item(0), affinity.item(1))
            Next affinity

        End If

        If products Then
            conn.fillDS("SELECT productID, CAST(CONCAT(cost, '_', description) AS CHAR(200)) FROM sys_products WHERE campaign = 'Gap' AND year = '2016'", "products")
            For Each product In conn.ds.Tables("products").Rows
                dictProducts2016.Add(product.item(0), product.item(1))
            Next product

            conn.fillDS("SELECT productID, CAST(CONCAT(cost, '_', description) AS CHAR(200)) FROM sys_products WHERE campaign = 'Gap' AND year = '2017'", "products")
            For Each product In conn.ds.Tables("products").Rows
                dictProducts2017.Add(product.item(0), product.item(1))
            Next product
        End If

        If addresses Then

            conn.fillDS("SELECT postalCode, suburb, city, province FROM sys_addresses", "addresses")
            dtAddressesAll = conn.ds.Tables("addresses")

            arrSuburbItems = dtAddressesAll.AsEnumerable().Select(Function(d) d.Field(Of String)("suburb")).Distinct().ToArray()
            arrCityItems = dtAddressesAll.AsEnumerable().Select(Function(d) d.Field(Of String)("city")).Distinct().ToArray()
            arrProvinceItems = dtAddressesAll.AsEnumerable().Select(Function(d) d.Field(Of String)("province")).Distinct().ToArray()

        End If

        If medAids Then
            conn.fillDS("SELECT medicalAidName, medicalAidPlan FROM sys_medical_aids", "medAids")
            dtMedicalAids = conn.ds.Tables("medAids")
            arrMedAidNames = dtMedicalAids.AsEnumerable().Select(Function(d) d.Field(Of String)("medicalAidName")).Distinct().ToArray()
        End If

        If statuses Then
            conn.fillDS("SELECT status, outcome FROM sys_status", "statuses")
            dtStatuses = conn.ds.Tables("statuses")
        End If

    End Sub

    Sub hideSideButtons()
        With frmSide
            Dim hideControls As New List(Of Control) From { .pbRefresh, .lbAllocated, .btAllocated, .lbBusy, .btBusy, .lbScheduled, .btScheduled, .lbQaFails, .btQaFails, .lbTransfers, .btTransfers, .lbSales, .btSales, .cbRecieveLeads}
            For Each field In hideControls
                field.Visible = False
            Next field

            .lbQueue.Location = New Point(12, 82)
            .lvQueue.Location = New Point(12, 98)
            .btRemoveSelected.Location = New Point(12, 309)
            .llPickFromQueue.Location = New Point(109, 82)
            .Height = 338

        End With
    End Sub

    Public Sub notify(notification As String)
        frmMain.NotificationIcon.Visible = True
        frmMain.NotificationIcon.ShowBalloonTip(5000, Application.ProductName, notification, ToolTipIcon.Info)
    End Sub

    Public Function frmNotOpen(frm As Form) As Boolean

        If Not frm.Visible Then
            Return True
        Else
            MsgBox("You are in a lead!")
            frm.Focus()
            Return False
        End If
    End Function

    Public Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Public Sub email(ByVal toAdd As String, ByVal subject As String, ByVal body As String, Optional ByVal attachment As String = "")
        Dim mail As New MailMessage("zest.dev@zestlife.co.za", toAdd, subject, body)
        'mail.CC.Add("deanc@exim.co.za")
        Console.WriteLine(body)
        If attachment <> "" Then
            mail.Attachments.Add(New Attachment(attachment))
        End If
        Dim smtp As New SmtpClient()
        smtp.Host = "yasur.dot.co.za"
        smtp.Credentials = New NetworkCredential("yasur.dot.co.za\zest.dev", "Asdfg09")
        smtp.Send(mail)
        notify("Mail sent.")
    End Sub

    Public Sub emailOutlook(ByVal toAdd As String, ByVal subject As String, ByVal body As String, Optional ccAdd As String = "", Optional ByVal attachment As String = "")

        Dim objOutlk As New Outlook.Application
        Const olMailItem As Integer = 0
        Dim objMail As New System.Object
        objMail = objOutlk.CreateItem(olMailItem)

        objMail.To = toAdd
        'objMail.cc = txCC
        objMail.subject = subject
        If attachment <> "" Then
            For Each attachement In attachment.Split(";")
                objMail.attachments.add(attachement)
            Next
        End If


        objMail.display()
        Dim msg As String = "<span style=""font-family:Century Gothic;font-size: 10pt;"">"
        '"<BODY style=font-size:11pt><br><br>Hi, <br>"

        Dim strb As New StringBuilder
        'objMail.attachments.add(attachment)

        strb.Append(Replace(body, vbNewLine, "<br/>"))
        msg += strb.ToString
        objMail.htmlbody = msg & objMail.htmlbody & "</span>"


        objMail = Nothing
        objOutlk = Nothing

        notify("Email created. Please check outlook.")

    End Sub

#Region "OLD stuff"
    'Public Sub emailOutlook(ByVal toAdd As String, ByVal subject As String, ByVal body As String, Optional ccAdd As String = "", Optional ByVal attachment As String = "")

    '    Dim oApp As New Outlook.Application
    '    'Dim oMsg As Outlook.MailItem = oApp.CreateItem(Outlook.OlItemType.olMailItem)
    '    Dim oMsg As Outlook.MailItem = oApp.CreateItem(0)
    '    oMsg.BodyFormat = Outlook.OlBodyFormat.olFormatHTML
    '    oMsg.To = toAdd
    '    oMsg.Subject = subject
    '    oMsg.Display()
    '    Dim signature = oMsg.HTMLBody
    '    oMsg.HTMLBody = body & signature
    '    'oMsg.Body = body
    '    Dim oAttachs As Outlook.Attachments = oMsg.Attachments

    '    If attachment <> "" Then oAttachs.Add(attachment)

    '    oApp = Nothing
    '    oMsg = Nothing
    '    oAttachs = Nothing

    'End Sub


    'Public Function GetFileFromDB(docName As String) As String
    '    'Dim conn As New MySqlConnection
    '    'Dim cmd As New MySqlCommand
    '    Dim myData As MySqlDataReader
    '    Dim SQL As String
    '    Dim rawData() As Byte
    '    Dim FileSize As UInt32
    '    Dim fs As FileStream

    '    'conn.ConnectionString = "server=127.0.0.1;" _
    '    '    & "uid=root;" _
    '    '    & "pwd=12345;" _
    '    '    & "database=test"

    '    SQL = "SELECT docName, fileSize, doc FROM sys_documents"

    '    Try
    '        'conn.Open()

    '        'cmd.Connection = conn
    '        'cmd.CommandText = SQL
    '        conn.comSQL.CommandText = SQL

    '        myData = conn.comSQL.ExecuteReader

    '        If Not myData.HasRows Then Throw New Exception("There are no BLOBs to save")

    '        myData.Read()

    '        FileSize = myData.GetUInt32(myData.GetOrdinal("fileSize"))
    '        rawData = New Byte(FileSize) {}

    '        myData.GetBytes(myData.GetOrdinal("doc"), 0, rawData, 0, FileSize)

    '        fs = New FileStream(Path.GetTempPath() & docName, FileMode.OpenOrCreate, FileAccess.Write)
    '        fs.Write(rawData, 0, FileSize)
    '        fs.Close()

    '        Return Path.GetTempPath() & docName

    '        MessageBox.Show("File successfully written to disk!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

    '        myData.Close()
    '        'conn.Close()
    '    Catch ex As Exception
    '        Return "NULL"
    '        MessageBox.Show("There was an error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Function

#End Region

    Public Sub checkVersion()
        If (conn.sendReturn("SELECT value FROM sys_defaults WHERE description = 'Version'") <> Application.ProductVersion) Then
            MsgBox("Version out of date. Click OK to update.", MsgBoxStyle.Critical, "Old version")
            Process.Start(systemFolder & "Application\StingrayUpdate.vbs")
            Application.Exit()
        End If
    End Sub

    Public Sub saveQueue(agent As String)
        Dim queueLeads As String = "UPDATE sys_agent_info SET previousQueue = '"
        For Each item As ListViewItem In frmSide.lvQueue.Items
            queueLeads += "" & item.SubItems(0).Text & ";"
        Next
        queueLeads = queueLeads.Substring(0, queueLeads.Length - 1) & "' WHERE userName = '" & agent & "'"
        conn.send(queueLeads)
    End Sub

    Public Sub loadQueue(agent As String)
        Dim leads As String() = Nothing
        Dim status As String
        conn.fillDS("SELECT previousQueue FROM sys_agent_info WHERE userName = '" & agent & "'", "queueLeads")
        If Not IsDBNull(conn.ds.Tables("queueLeads").Rows(0).Item(0)) Then
            leads = Split(conn.ds.Tables("queueLeads").Rows(0).Item(0), ";")
        End If
        For Each lead In leads
            status = conn.sendReturn("SELECT status FROM lead_primary WHERE leadID = " & lead)
            If status = "Busy" Or status = "Allocated" Then
                frmSide.addToQueue(lead, conn.sendReturn("SELECT CONCAT(COALESCE(firstName,''), ' ', COALESCE(lastName,'')) AS Name FROM lead_primary WHERE leadID = " & lead))
            End If
        Next
    End Sub

    Public Sub outlookTask(taskDateTime As DateTime, subject As String, Optional body As String = "")

        Dim objOutlk As New Outlook.Application

        Dim objTask As Outlook.TaskItem = Nothing
        objTask = objOutlk.CreateItem(Outlook.OlItemType.olTaskItem)
        objTask.Subject = subject
        If body <> "" Then objTask.Body = body
        objTask.ReminderSet = True
        objTask.ReminderTime = taskDateTime
        objTask.Save()

    End Sub

    Public Sub exportDataTable(dt As DataTable)
        Dim xlApp As Excel.Application = CreateObject("Excel.Application")
        Dim xlWB As Excel.Workbook = xlApp.Workbooks.Add()
        Dim xlWS As Excel.Worksheet = xlWB.Sheets(1)
        Try
            notify("Exporting...")

            For col = 0 To dt.Columns.Count - 1
                xlWS.Cells(1, col + 1).Value = dt.Columns(col).ColumnName

                For i = 0 To dt.Rows.Count - 1
                    xlWS.Cells(i + 2, col + 1).Value = dt.Rows(i).Item(col)
                Next i

            Next col
        Catch ex As Exception
            MsgBox("There was an error with exporting. Please speak to the administrator!", MsgBoxStyle.Critical)
        Finally
            xlApp.ActiveWindow.WindowState = Excel.XlWindowState.xlMaximized
            xlApp.Visible = True
            releaseObject(xlWS)
            releaseObject(xlWB)
            releaseObject(xlApp)
            MsgBox("Export Done")

        End Try



    End Sub

End Module
