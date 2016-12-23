Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop
'Imports System.IO

Public Class frmLeadView

    Dim gbMain As New GroupBox
    Public dictOutcomes As New Dictionary(Of String, String)
    'Public isQaFix As Boolean = True
    Public prodCode As String = ""
    Public allowClose As Boolean = False
    Dim fromLoad As Boolean = False
    Dim previousSale As Boolean = False
    Public dtLeadDetails As Data.DataTable

    Dim selectedDay As String
    Dim selectedHour As String
    Dim selectedMin As String

    Dim btnCounter As Integer = 5
    Dim adminCode As String = ""

    Dim earliestCollectionDate As Date

#Region "General"

    Private Sub frmLeadView_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not allowClose Then e.Cancel = True
    End Sub

    Private Sub LeadView_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MdiParent = frmMain

        lvComments.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)

        lbCancerUW.Text = ""
        AddHandler btReschedual.Click, AddressOf controlRelocate
        AddHandler btInvalid.Click, AddressOf controlRelocate
        AddHandler btDeclined.Click, AddressOf controlRelocate
        AddHandler btUncontactable.Click, AddressOf controlRelocate
        AddHandler btSale.Click, AddressOf controlRelocate

        Dim rButtons As New List(Of RadioButton) From {rbCore, rbStandard, rbUniversal, rbNoExcess, rbWithExcess, rbNoCancer, rbCancer1, rbCancer2, rbNoDentistry, rbWithDentistry, rbMatchCover, rbUniversal2017, rbTypeOther, rbTypeSingle}
        For Each rb In rButtons
            AddHandler rb.CheckedChanged, AddressOf rbChecked_CheckedChanged
        Next rb

        Dim mtbs As New List(Of MaskedTextBox) From {mtbIdNumber, mtbContactNumber, mtbCellNumber, mtbWorkNumber, mtbHomeNumber}
        For Each mtb In mtbs
            AddHandler mtb.MouseClick, AddressOf mtb_MouseClick
        Next mtb

        If dtpDOB.Checked = False Then dtpDOB.Value = Today

        AddHandler rbCancerUwYes.CheckedChanged, AddressOf rbCancerUw_CheckedChanged
        AddHandler rbCancerUwNo.CheckedChanged, AddressOf rbCancerUw_CheckedChanged


        If Month(DateAdd(DateInterval.WeekOfYear, 2, Today)) = Month(Today) + 1 Then
            earliestCollectionDate = DateAdd(DateInterval.WeekOfYear, 2, Today)
            lbCollectionDate.Text = "Earliest = " & DateAdd(DateInterval.WeekOfYear, 2, Today) _
                    & vbNewLine & "Latest = " & DateAdd(DateInterval.Month, 3, Today)
        Else
            earliestCollectionDate = Today.AddDays((Today.Day - 1) * -1).AddMonths(1)
            lbCollectionDate.Text = "Earliest = " & Today.AddDays((Today.Day - 1) * -1).AddMonths(1) _
                & vbNewLine & "Latest = " & DateAdd(DateInterval.Month, 3, Today)
        End If
        

        lbDentistryUW.Text = "The cover has a 6 month waiting period except if the claim arises as a result of an accident that occured after taking out the extended dentistry cover." _
                & vbNewLine & "In these circumstances you will enjoy full cover for all events." _
                & vbNewLine & "Pay out of the extanded dentistry cover amounts are fixed and are not dependedant on actual treatment costs or medical scheme approval." _
                & vbNewLine & "The extended dentistry cover is avaliable for an additional premium of R238.00 per month."

        AddHandler cbEvents.CheckedChanged, AddressOf refreshHistory
        AddHandler cbChanges.CheckedChanged, AddressOf refreshHistory
        AddHandler cbComments.CheckedChanged, AddressOf refreshHistory
        AddHandler cbCalls.CheckedChanged, AddressOf refreshHistory

        lbDisclosures.Text = "By supplying your banking details and agreeing that you can afford the premium, you are authorizing Zestlife to collect the monthly premium only via debit order" _
                        & " from your bank account on the selected dat. If this day falls on a Sunday or public holiday, we will then deduct the previous ordinary business day." _
                        & vbNewLine & "The amount collected will never exceed the premiums that you owe. If there are insufficient funds in your account, Zestlife will be entitled to track the account" _
                        & " and collect the premiums as soon as the funds are available. You will not be entitled to any refund of premiums provided they are legally owed to Zestlife and" _
                        & " the authority to debit your account may be cancelled by giving us 30 days’ notice." _
                        & vbNewLine & "You are covered for all of the in hospital doctors, specialist charges, but not the hospital costs itself. Certain outpatient procedures are also covered, " _
                        & "they bear with them a waiting period of 6 month where you are able to claim back 50% in your second 6 months." _
                        & vbNewLine & vbNewLine & "List of exclusions - Nuclear activity, surgery for obesity and cosmetic surgery, routine medicals of a diagnostic nature, depression and mental disorder, " _
                        & "taking of drugs and alcohol, suicide or attempted suicide, illegal racing driving, military activity and home nursing." _
                        & vbNewLine & vbNewLine & "Your premiums will increase each year in line with medical inflation. Universal Gap Cover gap cover is a short term insurance policy which is underwritten by Gaurdrisk." _
                        & " Gaurdrisk is now a subsidiary of MMI, the Merged Momentum and Metropolitan insurance group, who happens to be the 3rd largest insurer in South Africa." _
                        & " You are entitled to a 30 day review period and a non-payment of 2 months will result in a cancellation. Zestlife holds the relevant professional indemnity insurance in place and earns a regulated monthly commission of 20% which is already included in your premium."


        lbPopi.Text = "Would it be okay with you if I keep in touch with you every 6 months or so just to find out how things are going?" _
                & vbNewLine & vbNewLine & "On the email that I've sent you, you'll see that we have a referral system as well." _
                & vbNewLine & "So for each person you send me for Gap Cover, we will pay you R400 per person after their 2nd successful premium collection." _
                & vbNewLine & "So for any friends, family members or work colleagues, you are more than welcome to refer them to me." _
                & vbNewLine & vbNewLine & "Please take the number of my compliance department; Moonstone Compliance - 021 883 800"

        cbMedicalAid.Items.AddRange(arrMedAidNames)
        cbMedicalAid.SelectedIndex = -1

        cbPostalSuburb.Items.AddRange(arrSuburbItems)
        cbPostalCity.Items.AddRange(arrCityItems)
        cbPostalProvince.Items.AddRange(arrProvinceItems)

        If cbProdYear.Text = "" Then cbProdYear.Text = "2017"

    End Sub

    Private Sub frmLeadView_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim buttonList As New List(Of Button) From {btReschedual, btInvalid, btDeclined, btUncontactable, btSale}
        Dim defaultHeight As Integer = (Me.Height - 40) / btnCounter
        Dim locationY As Integer = 0
        For Each btn As Button In buttonList
            btn.Height = defaultHeight
            btn.Location = New System.Drawing.Point(707, locationY)
            locationY += defaultHeight
        Next btn
    End Sub

    Public Sub loadLead(leadID As Integer)
        frmSide.removeLead(leadID)
        fromLoad = True
        lbLeadID.Text = leadID
        conn.fillDS("SELECT loadedDate, status, outcome, source, affinityCode, affinityName, title, firstName, lastName, idNumber, contactNumber, emailAddress, cellNumber, homeNumber, workNumber, dateOfBirth, gender, langauge, medicalAid, medicalAidPlan, appType, medicalDependants, procedureIn12Months, annualHousehold, " _
                                       & "holderName, accountNumber, accountType, bankName, branchCode, " _
                                       & "paymentType, paymentDay, firstDebitDate, productTaken, productYear, policyReplaced, popiAccepted, uwPreviousRelitivesCancer, affinities.groupName, employeeNum, " _
                                       & "postal1, postal2, postalSuburb, postalCity, postalProvince, postalCode, physicalIsPostal, physical1, physical2, physicalSuburb, physicalCity, physicalProvince, physicalCode " _
                                       & "FROM lead_primary " _
                                       & "LEFT JOIN affinities ON affinityCode = adminCode " _
                                       & "LEFT JOIN lead_banking ON lead_banking.leadID = lead_primary.leadID " _
                                       & "LEFT JOIN lead_sale_info ON lead_sale_info.leadID = lead_primary.leadID " _
                                       & "LEFT JOIN lead_address ON lead_address.leadID = lead_primary.leadID " _
                                       & "WHERE lead_primary.leadID = " & leadID, "leadDetails")

        dtLeadDetails = conn.ds.Tables("leadDetails")
        'Loading all controls
        With conn.ds.Tables("leadDetails").Rows(0)
            If .Item("status") = "Sale" Then
                If MsgBox("Would you like to edit this sale?", MsgBoxStyle.YesNo) = vbNo Then
                    Exit Sub
                Else
                    If conn.sendReturn("SELECT qaStatus FROM lead_sale_info WHERE leadID = " & leadID) = "Pass" Then
                        MsgBox("This lead has already been QA passed. Please contact QA.")
                        Exit Sub
                    Else
                        Dim closedDate As Date = CDate(conn.sendReturn("SELECT closedDate FROM lead_primary WHERE leadID = " & leadID))
                        Dim salesFileDate As Date = CDate(conn.sendReturn("SELECT value FROM sys_defaults WHERE description = 'lastSalesFilePull'"))
                        If closedDate <= salesFileDate Then
                            MsgBox("The sales file has already been pulled for this lead. Please contact admin.")
                            Exit Sub
                        End If
                    End If
                    previousSale = True
                    conn.recordEvent("Lead Re-instated", .Item("status"), leadID)
                End If
            ElseIf Not (.Item("status") = "Allocated" Or .Item("status") = "Busy") Then
                If MsgBox("The status for this lead is " & .Item("status") & ". Would you like to re-instate this lead to Busy status?", MsgBoxStyle.YesNo) = vbNo Then
                    Exit Sub
                Else
                    conn.recordEvent("Lead Re-instated", .Item("status"), leadID)
                    If .Item("status") = "Recycle" Then
                        conn.recordChange("agent", conn.sendReturn("SELECT agent FROM lead_primary WHERE leadID = " & leadID), frmSide.lbUser.Text, leadID, "Recycled re-instated")
                        conn.send("UPDATE lead_primary SET agent = '" & frmSide.lbUser.Text & "' WHERE leadID = " & leadID)
                    End If
                End If
            End If
            conn.send("UPDATE lead_primary SET status = 'Busy', outcome = 'Picked' WHERE leadID = " & leadID)

            Me.Text = leadID & " - " & If(Not IsDBNull(.Item("title")), .Item("title") & " ", " ") & If(Not IsDBNull(.Item("firstName")), .Item("firstName") & " ", "") & If(Not IsDBNull(.Item("lastName")), .Item("lastName"), "")

            If Not IsDBNull(.Item("affinityCode")) Then adminCode = .Item("affinityCode")

            'Top lead Info
            If (Not IsDBNull(.Item("firstName"))) And (Not IsDBNull(.Item("lastName"))) Then lbLeadName.Text = "Name: " & .Item("firstName") & " " & .Item("lastName")
            'If Not IsDBNull(.Item("contactNumber")) Then lbContactNum.Text = "Contact Number: " & .Item("contactNumber")
            If Not IsDBNull(.Item("contactNumber")) Then
                Dim contNum As String = .Item("contactNumber")
                If contNum.Length > 7 Then
                    lbContactNum.Text = "Contact Number: " & "(" & contNum.Substring(0, contNum.Length - 7) & ") " & contNum.Substring(contNum.Length - 7, 3) & "-" & contNum.Substring(contNum.Length - 4, 4)
                Else
                    lbContactNum.Text = "Contact Number: " & contNum
                End If
            End If
            If Not IsDBNull(.Item("affinityName")) Then lbAffinity.Text = "Affinity: " & .Item("affinityName")
            If Not IsDBNull(.Item("source")) Then lbSource.Text = "Source: " & .Item("source")
            If Not IsDBNull(.Item("loadedDate")) Then lbLoadedDate.Text = "Loaded: " & .Item("loadedDate")

            'Intro
            If Not IsDBNull(.Item("appType")) Then
                If .Item("appType") = "Telephonic" Then
                    rbTelApplication.Checked = True
                ElseIf .Item("appType") = "Manual" Then
                    rbManApplication.Checked = True
                End If
            End If
            If Not IsDBNull(.Item("medicalDependants")) Then nudDependants.Value = CInt(.Item("medicalDependants"))
            If Not IsDBNull(.Item("medicalAid")) Then
                rbMedAidYes.Checked = True
                cbMedicalAid.Text = .Item("medicalAid")
                If Not IsDBNull(.Item("medicalAidPlan")) Then
                    cbMedAidPlan.Items.Clear()
                    Dim plans() As DataRow = dtMedicalAids.Select("medicalAidName = '" & cbMedicalAid.Text & "'")
                    For Each plan In plans
                        cbMedAidPlan.Items.Add(plan(1))
                    Next
                    cbMedAidPlan.Text = .Item("medicalAidPlan")
                End If

            End If
            If Not IsDBNull(.Item("procedureIn12Months")) Then
                If (.Item("procedureIn12Months") <> "N") And (.Item("procedureIn12Months") <> "") Then
                    rbProcedureYes.Checked = True
                    mtbProcedure.Text = .Item("procedureIn12Months")
                ElseIf .Item("procedureIn12Months") = "N" Then
                    rbProcedureNo.Checked = True
                End If
            End If


            'Primary
            If Not IsDBNull(.Item("title")) Then cbTitle.Text = .Item("title")
            If Not IsDBNull(.Item("firstName")) Then txFirstName.Text = .Item("firstName")
            If Not IsDBNull(.Item("lastName")) Then txLastName.Text = .Item("lastName")
            If Not IsDBNull(.Item("dateOfBirth")) Then
                dtpDOB.Checked = True
                dtpDOB.Value = CDate(.Item("dateOfBirth"))
            End If

            If Not IsDBNull(.Item("idNumber")) Then
                If validateIdNumber(.Item("idNumber")) <> "Pass" Then
                    cbNonSaID.Checked = True
                End If
                mtbIdNumber.Text = .Item("idNumber")
            End If

            If Not IsDBNull(.Item("gender")) Then cbGender.Text = .Item("gender")
            If Not IsDBNull(.Item("contactNumber")) Then mtbContactNumber.Text = If(.Item("contactNumber").ToString.Length = 9, "0" & .Item("contactNumber"), .Item("contactNumber"))
            If Not IsDBNull(.Item("cellNumber")) Then mtbCellNumber.Text = If(.Item("cellNumber").ToString.Length = 9, "0" & .Item("cellNumber"), .Item("cellNumber"))
            If Not IsDBNull(.Item("workNumber")) Then mtbWorkNumber.Text = If(.Item("workNumber").ToString.Length = 9, "0" & .Item("workNumber"), .Item("workNumber"))
            If Not IsDBNull(.Item("homeNumber")) Then mtbHomeNumber.Text = If(.Item("homeNumber").ToString.Length = 9, "0" & .Item("homeNumber"), .Item("homeNumber"))
            If Not IsDBNull(.Item("emailAddress")) Then
                cbEmail.Checked = True
                txEmailAddress.Text = .Item("emailAddress")
            End If


            'Product
            If IsDBNull(.Item("groupName")) Then
                If Not IsDBNull(.Item("productTaken")) Then
                    If Not IsDBNull(.Item("productYear")) Then
                        If .Item("productYear") = "2017" Then
                            cbProdYear.Text = "2017"
                            'Primary Product
                            If .Item("productTaken").length > 0 Then
                                Select Case .Item("productTaken").substring(0, 1)
                                    Case "M"
                                        rbMatchCover.Checked = True
                                    Case "U"
                                        rbUniversal2017.Checked = True
                                End Select
                            End If


                            'Excess
                            If .Item("productTaken").length > 1 Then
                                Select Case .Item("productTaken").substring(1, 1)
                                    Case "S"
                                        rbTypeSingle.Checked = True
                                    Case "O"
                                        rbTypeOther.Checked = True
                                End Select
                            End If

                        Else
                            GoTo 1
                        End If
                    Else
1:
                        'Primary Product
                        If .Item("productTaken").length > 0 Then
                            Select Case .Item("productTaken").substring(0, 1)
                                Case "C"
                                    rbCore.Checked = True
                                Case "S"
                                    rbStandard.Checked = True
                                Case "U"
                                    rbUniversal.Checked = True
                            End Select
                        End If


                        'Excess
                        If .Item("productTaken").length > 1 Then
                            Select Case .Item("productTaken").substring(1, 1)
                                Case "N"
                                    rbNoExcess.Checked = True
                                Case "E"
                                    rbWithExcess.Checked = True
                            End Select
                        End If

                    End If

                    'Cancer
                    If .Item("productTaken").length > 2 Then
                        Select Case .Item("productTaken").substring(2, 1)
                            Case "X"
                                rbNoCancer.Checked = True
                            Case "C"
                                rbCancer1.Checked = True
                            Case "K"
                                rbCancer2.Checked = True
                        End Select
                    End If


                    'Dentistry
                    If .Item("productTaken").length > 3 Then
                        Select Case .Item("productTaken").substring(3, 1)
                            Case "X"
                                rbNoDentistry.Checked = True
                            Case "D"
                                rbWithDentistry.Checked = True
                        End Select
                    End If

                    rbChecked_CheckedChanged()
                End If
            Else
                'Group Products
                gbProductPrimary.Visible = False
                gbProductExcess.Visible = False
                gbProductCancer.Visible = False
                gbProductDentistry.Visible = False
                lbProdDesc.Visible = False

                Dim lbGroupProductOption As New Label
                lbGroupProductOption.Location = New System.Drawing.Point(10, 40)
                lbGroupProductOption.AutoSize = True
                lbGroupProductOption.Text = .Item("groupName") & " product options:"

                Dim cbGroupProducts As New ComboBox
                cbGroupProducts.Location = New System.Drawing.Point(11, 60)
                cbGroupProducts.DropDownStyle = ComboBoxStyle.DropDownList

                conn.fillDS("SELECT productId, description, cost FROM sys_products WHERE groupName = '" & .Item("groupName") & "'", "groupProducts")
                For Each row In conn.ds.Tables("groupProducts").Rows
                    cbGroupProducts.Items.Add(row.item("description"))
                Next

                AddHandler cbGroupProducts.SelectedIndexChanged, Sub()
                                                                     Dim result() As DataRow = conn.ds.Tables("groupProducts").Select("description = '" & cbGroupProducts.Text & "'")
                                                                     prodCode = result(0).Item("productId")
                                                                     lbProdCost.Text = "R " & result(0).Item("cost")
                                                                 End Sub

                If Not IsDBNull(.Item("productTaken")) Then
                    Dim result() As DataRow = conn.ds.Tables("groupProducts").Select("productId = '" & .Item("productTaken") & "'")
                    cbGroupProducts.Text = result(0).Item("description")
                End If

                tpProduct.Controls.Add(lbGroupProductOption)
                tpProduct.Controls.Add(cbGroupProducts)
            End If


            'Addresses
            If Not IsDBNull(.Item("postal1")) Then txPostalLine1.Text = .Item("postal1")
            If Not IsDBNull(.Item("postal2")) Then txPostalLine2.Text = .Item("postal2")
            If Not IsDBNull(.Item("postalSuburb")) Then cbPostalSuburb.Text = .Item("postalSuburb")
            If Not IsDBNull(.Item("postalCity")) Then cbPostalCity.Text = .Item("postalCity")
            If Not IsDBNull(.Item("postalProvince")) Then cbPostalProvince.Text = .Item("postalProvince")
            If Not IsDBNull(.Item("postalCode")) Then txPostalCode.Text = .Item("postalCode")
            If Not IsDBNull(.Item("physicalIsPostal")) Then
                If .Item("physicalIsPostal") = 0 Then
                    chbSameAsPostal.Checked = False
                    If Not IsDBNull(.Item("physical1")) Then txPhysicalLine1.Text = .Item("physical1")
                    If Not IsDBNull(.Item("physical2")) Then txPhysicalLine2.Text = .Item("physical2")
                    If Not IsDBNull(.Item("physicalSuburb")) Then cbPhysicalSuburb.Text = .Item("physicalSuburb")
                    If Not IsDBNull(.Item("physicalCity")) Then cbPhysicalCity.Text = .Item("physicalCity")
                    If Not IsDBNull(.Item("physicalProvince")) Then cbPhysicalProvince.Text = .Item("physicalProvince")
                    If Not IsDBNull(.Item("physicalCode")) Then txPhysicalCode.Text = .Item("physicalCode")
                End If
            End If


            'Banking
            If Not IsDBNull(.Item("holderName")) Then txAccountHolder.Text = .Item("holderName")
            If Not IsDBNull(.Item("accountNumber")) Then txAccountNumber.Text = .Item("accountNumber")
            If Not IsDBNull(.Item("accountType")) Then cbAccountType.Text = .Item("accountType")
            If Not IsDBNull(.Item("BankName")) Then cbBankName.Text = .Item("BankName")
            If Not IsDBNull(.Item("branchCode")) Then txBranchCode.Text = .Item("branchCode")
            If Not IsDBNull(.Item("annualHousehold")) Then cbAnnualHousehold.Text = .Item("annualHousehold")
            If Not IsDBNull(.Item("paymentType")) Then cbPaymentType.Text = .Item("paymentType")
            If Not IsDBNull(.Item("paymentDay")) Then cbPaymentDay.Text = .Item("paymentDay")
            If Not IsDBNull(.Item("firstDebitDate")) Then
                dtpCollectionDate.Checked = True
                dtpCollectionDate.Value = CDate(.Item("firstDebitDate"))
            End If
            If Not IsDBNull(.Item("employeeNum")) Then txEmployeeNum.Text = .Item("employeeNum")


            'Disclosures
            If Not IsDBNull(.Item("policyReplaced")) Then
                If (.Item("policyReplaced") <> "N") And (.Item("policyReplaced") <> "") Then
                    rbPolicyReplaceYes.Checked = True
                    mtbReplacementPolicy.Text = .Item("policyReplaced")
                ElseIf .Item("policyReplaced") = "N" Then
                    rbPolicyReplaceNo.Checked = True
                End If
            End If

            'POPI
            If Not IsDBNull(.Item("popiAccepted")) Then
                If .Item("popiAccepted") = "1" Then
                    rbPopiYes.Checked = True
                ElseIf .Item("popiAccepted") = "0" Then
                    rbPopiNo.Checked = True
                End If
            End If
        End With


        'QA Faults
        conn.fillDS("SELECT qaStatus FROM lead_sale_info WHERE leadID = " & lbLeadID.Text, "qaStatus")
        If conn.ds.Tables("qaStatus").Rows.Count <> 0 Then
            If Not IsDBNull(conn.ds.Tables("qaStatus").Rows(0).Item("qaStatus")) Then
                If conn.ds.Tables("qaStatus").Rows(0).Item("qaStatus") = "Fail" Then
                    frmQaFaults.loadLead(leadID)
                End If
            End If
        End If

        conn.recordEvent("Lead Picked Up", , lbLeadID.Text)

        conn.fillDS("SELECT timeStamp, user, comment FROM lead_comments WHERE leadID = " & leadID & " ORDER BY timestamp DESC", "leadComments")
        For Each row As DataRow In conn.ds.Tables("leadComments").Rows
            Dim str() As String = {row.Item("timeStamp"), row.Item("user"), row.Item("Comment")}
            lvComments.Items.Add(New ListViewItem(str))
        Next

        fromLoad = False
        Me.Show()
        rbChecked_CheckedChanged()

    End Sub

    Private Sub validateSale(bt As Button, lv As ListView, submit As Button)

        If bt.Text = "Validate" Then
            lv.Items.Clear()
            Dim tabIndex As Integer = TabControl1.TabPages.IndexOf(TabControl1.SelectedTab)

            'Intro
            TabControl1.SelectTab(0)
            If Not (rbTelApplication.Checked Or rbManApplication.Checked) Then lv.Items.Add(New ListViewItem({"App type not selected", "Intro"}))
            If Not rbMedAidYes.Checked Then lv.Items.Add(New ListViewItem({"Client does not have Medical Aid!", "Intro"}))
            If cbMedicalAid.Text = "" Then lv.Items.Add(New ListViewItem({"Medical Aid needed", "Intro"}))
            If cbMedAidPlan.Visible And cbMedAidPlan.Text = "" Then lv.Items.Add(New ListViewItem({"Medical Aid Plan needed", "Intro"}))
            If nudDependants.Value = 0 Then lv.Items.Add(New ListViewItem({"Members needed", "Intro"}))
            If Not (rbProcedureYes.Checked Or rbProcedureNo.Checked) Then lv.Items.Add(New ListViewItem({"Medical procedure not answered.", "Intro"}))
            If rbProcedureYes.Checked And mtbProcedure.Text = "" Then lv.Items.Add(New ListViewItem({"No procedure mentionioned.", "Intro"}))

            'Primary
            TabControl1.SelectTab(1)
            If cbTitle.Text = "" Then lv.Items.Add(New ListViewItem({"Title not selected", "Primary"}))
            If txFirstName.Text = "" Then lv.Items.Add(New ListViewItem({"First name neeeded", "Primary"}))
            If txLastName.Text = "" Then lv.Items.Add(New ListViewItem({"Last name needed", "Primary"}))
            If dtpDOB.Checked And cbOverideDob.Checked = False Then
                If dtpDOB.Value > DateAdd(DateInterval.Year, -18, Today) Then lv.Items.Add(New ListViewItem({"DOB too young", "Primary"}))
                If dtpDOB.Value < DateAdd(DateInterval.Year, -65, Today) Then lv.Items.Add(New ListViewItem({"DOB too old", "Primary"}))
            ElseIf dtpDOB.Checked = False Then
                lv.Items.Add(New ListViewItem({"DOB needed", "Primary"}))
            End If
            If cbGender.Text = "" Then lv.Items.Add(New ListViewItem({"Gender needed", "Primary"}))
            Dim validResponse As String = ""
            Dim mtbPrimary As New List(Of MaskedTextBox) From {mtbIdNumber, mtbContactNumber, mtbCellNumber, mtbWorkNumber, mtbHomeNumber}
            Dim numberCheck As String = ""
            For Each mtb As MaskedTextBox In mtbPrimary
                mtb.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals

                If mtb.Name <> "mtbIdNumber" Then
                    numberCheck += mtb.Text
                End If

                If (mtb.Name = mtbIdNumber.Name) And (cbNonSaID.Checked = False) And (mtbIdNumber.Text <> "") Then
                    validResponse = validateIdNumber(mtbIdNumber.Text)
                    If validResponse <> "Pass" Then lv.Items.Add(New ListViewItem({validResponse, "Primary"}))
                ElseIf (mtb.Name <> mtbIdNumber.Name) And (mtb.Text <> "") Then
                    validResponse = validateContactNumber(mtb.Text)
                    If validResponse <> "Pass" Then lv.Items.Add(New ListViewItem({mtb.Tag & " - " & validResponse, "Primary"}))
                ElseIf (mtb.Name = mtbIdNumber.Name) And (mtb.Text = "") Then
                    lv.Items.Add(New ListViewItem({"ID Number needed", "Primary"}))
                End If
                mtb.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
            Next mtb
            If numberCheck = "" Then lv.Items.Add(New ListViewItem({"Please enter a contact number", "Primary"}))
            If cbEmail.Checked And txEmailAddress.Text <> "" Then
                If Not validateEmail(txEmailAddress.Text) Then lv.Items.Add(New ListViewItem({"Not a valid email", "Primary"}))
            ElseIf cbEmail.Checked And txEmailAddress.Text = "" Then
                lv.Items.Add(New ListViewItem({"Email needed", "Primary"}))
            End If

            'Product
            TabControl1.TabPages(2).Select()
            If lbProdCost.Text = "" Then
                lv.Items.Add(New ListViewItem({"Product needed", "Product"}))
            Else

                If cbProdYear.Text = "2016" Then
                    If dtpCollectionDate.Checked And dtpCollectionDate.Value.Year = 2017 Then
                        lv.Items.Add(New ListViewItem({"Prod year = 2016 but collection = 2017", "Product"}))
                    End If
                ElseIf cbProdYear.Text = "2017" Then
                    If dtpCollectionDate.Checked And dtpCollectionDate.Value.Year = 2016 Then
                        lv.Items.Add(New ListViewItem({"Prod year = 2017 but collection = 2016", "Product"}))
                    End If

                    If rbTypeSingle.Checked Then
                        If dtpDOB.Value < DateAdd(DateInterval.Year, -55, Today) Then
                            lv.Items.Add(New ListViewItem({"Too old for singles product", "Product"}))
                        End If
                        If nudDependants.Value <> 1 Then
                            lv.Items.Add(New ListViewItem({"Too many dependants for singles product", "Product"}))
                        End If
                    End If
                Else
                    lv.Items.Add(New ListViewItem({"Please select product year", "Product"}))
                End If

                If gbCancerUW.Visible Then
                    If Not (rbCancerUwYes.Checked Or rbCancerUwNo.Checked) Then
                        lv.Items.Add(New ListViewItem({"Please answer cancer UW", "Product"}))
                    Else
                        If rbCancerUwYes.Checked Then lv.Items.Add(New ListViewItem({"Client cannot get Cancer Cover", "Product"}))
                    End If
                End If

                If Not cbAfford.Checked Then lv.Items.Add(New ListViewItem({"Affordability needed", "Product"}))
            End If

            'Address
            TabControl1.SelectTab(3)
            If txPostalLine1.Text = "" Then lv.Items.Add(New ListViewItem({"Postal add 1 needed", "Address"}))
            'If txPostalLine2.Text = "" Then lv.Items.Add(New ListViewItem({"Postal add 2 needed", "Address"}))
            If cbPostalSuburb.Text = "" Then lv.Items.Add(New ListViewItem({"Postal Suburb needed", "Address"}))
            If cbPostalCity.Text = "" Then lv.Items.Add(New ListViewItem({"Postal City needed", "Address"}))
            If cbPostalProvince.Text = "" Then lv.Items.Add(New ListViewItem({"Postal province needed", "Address"}))
            If txPostalCode.Text = "" Then lv.Items.Add(New ListViewItem({"Postal Code needed", "Address"}))
            If chbSameAsPostal.Checked = False Then
                If txPhysicalLine1.Text = "" Then lv.Items.Add(New ListViewItem({"Physical add 1 needed", "Address"}))
                'If txPhysicalLine2.Text = "" Then lv.Items.Add(New ListViewItem({"Physical add 2 needed", "Address"}))
                If cbPhysicalSuburb.Text = "" Then lv.Items.Add(New ListViewItem({"Physical Suburb needed", "Address"}))
                If cbPhysicalCity.Text = "" Then lv.Items.Add(New ListViewItem({"Physical City needed", "Address"}))
                If cbPhysicalProvince.Text = "" Then lv.Items.Add(New ListViewItem({"Physical province needed", "Address"}))
                If txPhysicalCode.Text = "" Then lv.Items.Add(New ListViewItem({"Physical Code needed", "Address"}))
            End If

            'Banking
            TabControl1.SelectTab(4)
            If cbAnnualHousehold.Text = "" Then lv.Items.Add(New ListViewItem({"Annual income needed", "Banking"}))
            If cbPaymentType.Text = "" Then lv.Items.Add(New ListViewItem({"Payment type needed", "Banking"}))
            If cbPaymentType.Text <> "Cash" And cbPaymentType.Text <> "Payroll deduction" Then
                If btValidate.Text = "Validate" And cbBankingOveride.Checked = False Then lv.Items.Add(New ListViewItem({"Please validate banking", "Banking"}))
            End If
            If cbPaymentDay.Text = "" Then lv.Items.Add(New ListViewItem({"Payment day needed", "Banking"}))
            If Not dtpCollectionDate.Checked Then
                lv.Items.Add(New ListViewItem({"Collection date needed", "Banking"}))
            ElseIf lbCollectionError.Visible Then
                lv.Items.Add(New ListViewItem({"Collection date invalid", "Banking"}))
            End If
            If txEmployeeNum.Visible And txEmployeeNum.Enabled And txEmployeeNum.Text = "" Then
                lv.Items.Add(New ListViewItem({"Employee Num Needed", "Banking"}))
            End If

            'Disclosures
            TabControl1.SelectTab(5)
            If cbDisclosed.Checked = False Then lv.Items.Add(New ListViewItem({"Disclosures read needed", "Disclosures"}))
            If rbPolicyReplaceYes.Checked Or rbPolicyReplaceNo.Checked Then
                If rbPolicyReplaceYes.Checked And mtbReplacementPolicy.Text = "" Then lv.Items.Add(New ListViewItem({"Replacement policy needed", "Disclosures"}))
            Else
                lv.Items.Add(New ListViewItem({"Replacement policy option needed", "Disclosures"}))
            End If

            'POPI
            TabControl1.SelectTab(6)
            If Not (rbPopiYes.Checked Or rbPopiNo.Checked) Then
                lv.Items.Add(New ListViewItem({"POPI question needed", "POPI"}))
            End If

            TabControl1.SelectTab(tabIndex)

            If lv.Items.Count = 0 Then
                bt.Text = "Enable Editing"
                TabControl1.Enabled = False
                submit.Enabled = True
            Else
                lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
            End If
        ElseIf bt.Text = "Enable Editing" Then
            bt.Text = "Validate"
            TabControl1.Enabled = True
            submit.Enabled = False
        End If

    End Sub

    Private Sub updateRecord(type As String, reason As String, comment As String, Optional dtpDate As DateTimePicker = Nothing, Optional dtpTime As DateTimePicker = Nothing)
        Dim validatedResponse As String = ""
        If reason = "" Then
            MsgBox("Please select a reason")
            Exit Sub
        ElseIf reason = "Other" And comment = "" Then
            MsgBox("Please enter a comment")
            Exit Sub
        End If

        If type = "Busy" Then
            If dtpDate.Value < Today Then
                MsgBox("You cannot reschedule for a day in the past.")
                Exit Sub
            End If

            If MsgBox("Add reminder to Outlook?", MsgBoxStyle.YesNo) = vbYes Then
                outlookTask(New DateTime(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day, dtpTime.Value.Hour, dtpTime.Value.Minute, 0), "Call-back lead " & lbLeadID.Text, reason & vbNewLine & comment)
            End If

        End If

        Dim mtb As MaskedTextBox
        Dim dtp As DateTimePicker
        Dim chb As System.Windows.Forms.CheckBox

        Dim lead_primary As New List(Of Control) From {cbTitle, txFirstName, txLastName, dtpDOB, mtbIdNumber, cbGender, mtbCellNumber, mtbContactNumber, mtbHomeNumber, mtbWorkNumber, txEmailAddress, cbMedicalAid, cbMedAidPlan, mtbProcedure, nudDependants}
        Dim lead_sale_info As New List(Of Control) From {cbAnnualHousehold, cbPaymentType, cbPaymentDay, dtpCollectionDate, txEmployeeNum, cbProdYear}
        Dim lead_address As New List(Of Control) From {txPostalLine1, txPostalLine2, cbPostalSuburb, cbPostalCity, cbPostalProvince, txPostalCode, chbSameAsPostal, txPhysicalLine1, txPhysicalLine2, cbPhysicalCity, cbPhysicalSuburb, cbPhysicalProvince, txPhysicalCode}
        Dim lead_banking As New List(Of Control) From {txAccountHolder, txAccountNumber, cbAccountType, cbBankName, txBranchCode}

        Dim query As New Collection()
        Dim dictTables As New Dictionary(Of String, Object)

        dictTables.Add("lead_primary", lead_primary)
        dictTables.Add("lead_sale_info", lead_sale_info)
        dictTables.Add("lead_address", lead_address)
        If btValidate.Text <> "Validate" Then dictTables.Add("lead_banking", lead_banking)


        For Each tableInDB In dictTables.Keys
            Dim returnString As String = conn.sendReturn("SELECT Count(leadID) FROM " & tableInDB & " WHERE leadID='" & lbLeadID.Text & "'")
            Dim insertColumns As String = "INSERT INTO " & tableInDB & "("
            Dim insertValues As String = "leadID) VALUES("
            Dim updateStatment As String = "UPDATE " & tableInDB & " SET "
            For Each item As Control In dictTables(tableInDB)

                If (TypeOf item Is TextBox) Or (TypeOf item Is ComboBox) Then

                    If item.Text <> "" Then
                        If item.Name = "txEmailAddress" Then
                            If Not validateEmail(item.Text) Then
                                MsgBox("Invalid Email")
                                item.Focus()
                                Exit Sub
                            End If
                        End If

                        If returnString = "NULL" Then
                            insertColumns += item.Tag & ", "
                            insertValues += "'" & Replace(item.Text, "'", "''") & "', "
                        ElseIf returnString <> "NULL" Then
                            updateStatment += item.Tag & " = '" & Replace(item.Text, "'", "''") & "', "
                        End If
                    End If
                ElseIf TypeOf item Is NumericUpDown Then
                    Dim nud As NumericUpDown = item
                    If nud.Value > -1 Then
                        If returnString = "NULL" Then
                            insertColumns += item.Tag & ", "
                            insertValues += "'" & nud.Value & "', "
                        ElseIf returnString <> "NULL" Then
                            updateStatment += item.Tag & " = '" & nud.Value & "', "
                        End If
                    End If
                ElseIf TypeOf item Is MaskedTextBox Then

                    mtb = item
                    mtb.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals

                    If item.Text <> "" Then
                        Select Case mtb.Name
                            Case "mtbContactNumber", "mtbCellNumber", "mtbHomeNumber", "mtbWorkNumber"
                                validatedResponse = validateContactNumber(mtb.Text)
                                If validatedResponse <> "Pass" Then
                                    MsgBox(mtb.Tag & " - " & validatedResponse)
                                    mtb.Focus()
                                    Exit Sub
                                End If
                            Case "mtbIdNumber"
                                If Not cbNonSaID.Checked Then
                                    validatedResponse = validateIdNumber(mtb.Text)
                                    If validatedResponse <> "Pass" Then
                                        MsgBox(mtb.Tag & " - " & validatedResponse)
                                        mtb.Focus()
                                        Exit Sub
                                    End If
                                End If
                        End Select

                        If returnString = "NULL" Then
                            insertColumns += item.Tag & ", "
                            insertValues += "'" & mtb.Text & "', "
                        ElseIf returnString <> "NULL" Then
                            updateStatment += mtb.Tag & " = '" & mtb.Text & "', "
                        End If
                    End If

                    mtb.TextMaskFormat = MaskFormat.IncludePromptAndLiterals

                ElseIf TypeOf item Is DateTimePicker Then
                    dtp = item
                    If returnString = "NULL" And dtp.Checked Then
                        insertColumns += item.Tag & ", "
                        insertValues += "'" & Format(dtp.Value, "yyyy-MM-dd") & "', "
                    ElseIf returnString <> "NULL" And dtp.Checked Then
                        updateStatment += item.Tag & " = '" & Format(dtp.Value, "yyyy-MM-dd") & "', "
                    End If
                ElseIf TypeOf item Is System.Windows.Forms.CheckBox Then
                    chb = item
                    If returnString = "NULL" Then
                        insertColumns += item.Tag & ", "
                        insertValues += "'" & If(chb.Checked, "1", 0) & "', "
                    ElseIf returnString <> "NULL" Then
                        updateStatment += item.Tag & " = '" & If(chb.Checked, "1", 0) & "', "
                    End If
                End If

                Select Case item.Name
                    Case "mtbIdNumber", "mtbContactNumber", "dtpDOB", "cbPaymentType", "cbPaymentDay", "dtpCollectionDate", "txAccountHolder", "txAccountNumber", "cbAccountType", "cbBankName", "txBranchCode"
                        If TypeOf item Is DateTimePicker Then
                            dtp = item
                            If Not IsDBNull(dtLeadDetails.Rows(0).Item(item.Tag)) Then
                                If dtp.Checked Then
                                    conn.recordChange(item.Tag, Format(dtLeadDetails.Rows(0).Item(item.Tag), "yyyy-MM-dd"), Format(dtp.Value, "yyyy-MM-dd"), lbLeadID.Text)
                                End If
                            End If
                        ElseIf TypeOf item Is MaskedTextBox Then
                            mtb = item

                            mtb.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
                            If Not IsDBNull(dtLeadDetails.Rows(0).Item(item.Tag)) Then
                                If dtLeadDetails.Rows(0).Item(item.Tag) <> item.Text Then
                                    conn.recordChange(item.Tag, dtLeadDetails.Rows(0).Item(item.Tag), item.Text, lbLeadID.Text)
                                End If
                            End If
                            mtb.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
                        Else
                            If IsDBNull(dtLeadDetails.Rows(0).Item(item.Tag)) Then
                            Else
                                If dtLeadDetails.Rows(0).Item(item.Tag) <> item.Text Then
                                    conn.recordChange(item.Tag, dtLeadDetails.Rows(0).Item(item.Tag), item.Text, lbLeadID.Text)
                                End If
                            End If
                        End If
                End Select

            Next item

            If tableInDB = "lead_primary" Then
                If rbManApplication.Checked Or rbTelApplication.Checked Then
                    If returnString = "NULL" Then
                        insertColumns += "appType, "
                        If rbManApplication.Checked Then
                            insertValues += "'Manual', "
                        ElseIf rbTelApplication.Checked Then
                            insertValues += "'Telephonic', "
                        End If
                    ElseIf returnString <> "NULL" Then
                        If rbManApplication.Checked Then
                            updateStatment += "appType = 'Manual', "
                        ElseIf rbTelApplication.Checked Then
                            updateStatment += "appType = 'Telephonic', "
                        End If
                    End If
                End If

                If rbProcedureYes.Checked And mtbProcedure.Text <> "" Then
                    If returnString = "NULL" Then
                        insertColumns += "procedureIn12Months, "
                        insertValues += "'" & mtbProcedure.Text & "', "
                    ElseIf returnString <> "NULL" Then
                        updateStatment += "procedureIn12Months = '" & mtbProcedure.Text & "', "
                    End If
                ElseIf rbProcedureNo.Checked Then
                    If returnString = "NULL" Then
                        insertColumns += "procedureIn12Months, "
                        insertValues += "'N', "
                    ElseIf returnString <> "NULL" Then
                        updateStatment += "procedureIn12Months = 'N', "
                    End If
                End If
            End If

            If tableInDB = "lead_sale_info" Then
                If prodCode <> "" And returnString = "NULL" Then
                    insertColumns += "productTaken, "
                    insertValues += "'" & prodCode & "', "
                ElseIf prodCode <> "" And returnString <> "NULL" Then
                    updateStatment += "productTaken = '" & prodCode & "', "
                End If

                If IsDBNull(dtLeadDetails.Rows(0).Item("productTaken")) Then
                Else
                    If dtLeadDetails.Rows(0).Item("productTaken") <> prodCode Then
                        conn.recordChange("prodCode", dtLeadDetails.Rows(0).Item("productTaken"), prodCode, lbLeadID.Text)
                    End If
                End If

                If rbPolicyReplaceYes.Checked And mtbReplacementPolicy.Text <> "" Then
                    If returnString = "NULL" Then
                        insertColumns += "policyReplaced, "
                        insertValues += "'" & mtbProcedure.Text & "', "
                    ElseIf returnString <> "NULL" Then
                        updateStatment += "policyReplaced = '" & mtbProcedure.Text & "', "
                    End If
                ElseIf rbPolicyReplaceNo.Checked Then
                    If returnString = "NULL" Then
                        insertColumns += "policyReplaced, "
                        insertValues += "'N', "
                    ElseIf returnString <> "NULL" Then
                        updateStatment += "policyReplaced = 'N', "
                    End If
                End If

                If type = "Sale" Then
                    If returnString = "NULL" Then
                        insertColumns += "qaStatus, "
                        insertValues += "'Pending', "
                    ElseIf returnString <> "NULL" Then
                        updateStatment += "qaStatus = 'Pending', "
                    End If

                    'QA mandatory reasons
                    If cbOverideDob.Checked And cbBankingOveride.Checked Then
                        If returnString = "NULL" Then
                            insertColumns += "qaManditory, qaManditoryReason, "
                            insertValues += "'1', 'Both DOB and Banking', "
                        ElseIf returnString <> "NULL" Then
                            updateStatment += "qaManditory = '1', qaManditoryReason = 'Both DOB and Banking Overide', "
                        End If
                    ElseIf cbOverideDob.Checked Then
                        If returnString = "NULL" Then
                            insertColumns += "qaManditory, qaManditoryReason, "
                            insertValues += "'1', 'DOB Overide', "
                        ElseIf returnString <> "NULL" Then
                            updateStatment += "qaManditory = '1', qaManditoryReason = 'DOB overide', "
                        End If
                    ElseIf cbBankingOveride.Checked Then
                        If returnString = "NULL" Then
                            insertColumns += "qaManditory, qaManditoryReason, "
                            insertValues += "'1', 'Banking overide', "
                        ElseIf returnString <> "NULL" Then
                            updateStatment += "qaManditory = '1', qaManditoryReason = 'Banking overide', "
                        End If
                    End If

                End If

                If returnString = "NULL" Then
                    If rbCancerUwYes.Checked Then
                        insertColumns += "uwPreviousRelitivesCancer, "
                        insertValues += "'1', "
                    ElseIf rbCancerUwNo.Checked Then
                        insertColumns += "uwPreviousRelitivesCancer, "
                        insertValues += "'0', "
                    End If
                Else
                    If rbCancerUwYes.Checked Then
                        updateStatment += "uwPreviousRelitivesCancer = '1', "
                    ElseIf rbCancerUwNo.Checked Then
                        updateStatment += "uwPreviousRelitivesCancer = '0', "
                    End If
                End If

                If rbPopiYes.Checked Or rbPopiNo.Checked Then
                    If returnString = "NULL" Then
                        insertColumns += "popiAccepted, "
                        insertValues += If(rbPopiYes.Checked, 1, 0) & ", "
                    ElseIf returnString <> "NULL" Then
                        updateStatment += "popiAccepted = " & If(rbPopiYes.Checked, 1, 0) & ", "
                    End If
                End If

            End If


            If returnString = "NULL" Then
                If (insertColumns <> "INSERT INTO lead_sale_info(productYear, ") And (insertColumns <> "INSERT INTO lead_address(physicalIsPostal, ") Then
                    conn.send(insertColumns & insertValues & lbLeadID.Text & ")")
                End If

            ElseIf updateStatment.Substring(updateStatment.Length - 2, 2) = ", " Then
                    conn.send(updateStatment.Substring(0, updateStatment.Length - 2) & " WHERE leadID = " & lbLeadID.Text)
            End If
        Next tableInDB

        conn.send("UPDATE lead_reschedule SET `active`='0' WHERE leadID='" & lbLeadID.Text & "'")

        If type = "Busy" Then
            conn.send("INSERT INTO lead_reschedule(`leadID`,`user`,`rescheduleDateTime`,`comment`,`active`)VALUES('" & lbLeadID.Text & "','" & frmSide.lbUser.Text & "','" & Format(dtpDate.Value, "yyyy-MM-dd") & " " & Format(dtpTime.Value, "HH:mm:ss") & "'," & If(comment = "", "NULL", "'" & Replace(comment, "'", "''") & "'") & ",'1')")
        ElseIf Not previousSale Then
            conn.send("UPDATE lead_primary SET closedDate = '" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "' WHERE leadID = " & lbLeadID.Text)
        End If

        If comment <> "" Then
            conn.send("INSERT INTO lead_comments(user, leadID, comment) VALUES('" & frmSide.lbUser.Text & "', '" & lbLeadID.Text & "', '" & Replace(comment, "'", "''") & "')")
        End If

        conn.send("UPDATE lead_primary SET `outcome`='" & reason & "',`status`='" & type & "' WHERE leadID='" & lbLeadID.Text & "'")
        conn.recordEvent(type, reason, lbLeadID.Text)

        Dim ballDay As Boolean = False

        If type = "Sale" Then
            If System.Windows.Forms.Application.OpenForms().OfType(Of frmQaFaults).Any Then
                conn.send("UPDATE lead_sale_info SET qaStatus = 'Fixed' WHERE leadID='" & lbLeadID.Text & "'")
                frmQaFaults.Close()
                If MsgBox("QA Fix done, would you like to recreate the sale email?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    notify("Well done! Building email...")
                    saleConfirmationEmail()
                    Me.Cursor = Cursors.Default
                Else
                    notify("QA fault fixed. Thank-you!")
                End If
            ElseIf previousSale Then
                If MsgBox("Edit done, would you like to recreate the sale email?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    notify("Well done! Building email...")
                    saleConfirmationEmail()
                    Me.Cursor = Cursors.Default
                Else
                    notify("Edt Saved. Thank-you!")
                End If
            Else
                Me.Cursor = Cursors.WaitCursor
                notify("Well done! Building email...")
                saleConfirmationEmail()
                Me.Cursor = Cursors.Default

                If Format(Today, "dddd") = "Monday" Or Format(Today, "dddd") = "Saturday" Or (Today = #2016-11-22#) Then
                    ballDay = True
                End If

            End If

            If adminCode <> "" Then
                Dim affinity As String = conn.sendReturn("SELECT affinity FROM affinities WHERE adminCode = '" & adminCode & "'")
                If affinity = "0" Then
                    emailZwingSale(adminCode)
                End If
            End If
        Else
            notify("Lead updated")
        End If


        If System.Windows.Forms.Application.OpenForms().OfType(Of frmQaFaults).Any Then frmQaFaults.Close()

        If ballDay Then
            frmBallDay.Show()
        Else
            Select Case reason
                Case "No medical aid", "Wants medical aid", "Wants day-to-day / Pregnancy cover"
                    frmEmailEssential.loadLead(lbLeadID.Text, txFirstName.Text & " " & txLastName.Text, mtbContactNumber.Text)
                Case Else
                    frmAfterLead.Show()
            End Select

        End If

        modExtra.refreshSideBar()

        allowClose = True
        dtLeadDetails.Clear()


        Me.Close()

    End Sub

    Private Sub mtbComment_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mtbComment.KeyPress
        If Asc(e.KeyChar) = 13 And mtbComment.Text <> "" Then
            conn.send("INSERT INTO lead_comments(user, leadID, comment) VALUES('" & frmSide.lbUser.Text & "', '" & lbLeadID.Text & "', '" & Replace(mtbComment.Text, "'", "''") & "')")
            Dim str() As String = {Now, frmSide.lbUser.Text, mtbComment.Text}
            lvComments.Items.Insert(0, New ListViewItem(str))
            mtbComment.Text = ""
            lvComments.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        End If
    End Sub

    Private Sub btSendEmail_Click(sender As Object, e As EventArgs) Handles btSendEmail.Click
        Me.Cursor = Cursors.WaitCursor
        notify("Building email...")

        Dim emailHTML As String = "Dear " & cbTitle.Text & " " & txFirstName.Text & " " & txLastName.Text & "," & vbNewLine & vbNewLine
        emailHTML += "Please see attached the following documents:" & "<ul>"

        Dim attachements As String = ""

        For Each emailOption In clbEmailOptions.CheckedItems
            emailHTML += "<li>" & emailOption & "</li>"
            Select Case emailOption
                Case "Personal App"
                    attachements += completePersonalAppForm(systemFolder & "SystemMaterial\Personal App Form.docx") & ";"
                Case "Personal App (2017)"
                    attachements += completePersonalAppForm(systemFolder & "SystemMaterial\Personal App Form (2017).docx") & ";"
                Case Else
                    attachements += systemFolder & "SystemMaterial\" & emailOption & ".pdf" & ";"
            End Select
        Next
        emailHTML += "</ul>"

        emailHTML += vbNewLine & "Please do not hesitate to contact myself should you have any queries."

        emailOutlook(txEmailAddress.Text, "Zestlife Medical Gap Cover", emailHTML, , attachements.Substring(0, attachements.Length - 1))
        Me.Cursor = Cursors.Default
    End Sub

    Public Function completePersonalAppForm(appLocation As String) As String

        Dim oWord As New Word.Application
        Dim oDoc As Word.Document = oWord.Documents.Open(appLocation)
        oWord.Visible = True

        conn.fillDS("SELECT userName, emailAddress, workNumber FROM sys_users WHERE userName = '" & frmSide.lbUser.Text & "'", "agentInfo")

        Dim rng As Word.Range = oWord.ActiveDocument.Range()
        With rng.Find

            .Text = "<Agent Name>"
            .Replacement.Text = conn.ds.Tables("agentInfo").Rows(0).Item("userName")
            .Execute(Replace:=Word.WdReplace.wdReplaceAll)

            .Text = "<Agent Email>"
            .Replacement.Text = conn.ds.Tables("agentInfo").Rows(0).Item("emailAddress")
            .Execute(Replace:=Word.WdReplace.wdReplaceAll)

            .Text = "<Agent Number>"
            .Replacement.Text = conn.ds.Tables("agentInfo").Rows(0).Item("workNumber")
            .Execute(Replace:=Word.WdReplace.wdReplaceAll)

            Dim mtb As MaskedTextBox
            Dim dtp As DateTimePicker
            Dim controls As New List(Of Control) From {cbTitle, txFirstName, txLastName, dtpDOB, mtbIdNumber, cbGender, txEmailAddress, mtbContactNumber,
                                                       mtbWorkNumber, cbMedicalAid, cbMedAidPlan, txAccountHolder, cbBankName, txBranchCode, txAccountNumber, cbAccountType,
                                                       dtpCollectionDate, cbPaymentDay, mtbReplacementPolicy, mtbProcedure, txPostalLine1, txPostalLine2, cbPostalSuburb, cbPostalCity,
                                                       cbPostalProvince, txPostalCode, nudDependants, cbGender, cbAnnualHousehold}
            For Each control In controls

                If (TypeOf control Is TextBox) Or (TypeOf control Is ComboBox) Then
                    If control.Name = "cbGender" Then
                        If control.Text = "Male" Then
                            .Text = "<male>"
                            .Replacement.Text = "X"
                            .Execute(Replace:=Word.WdReplace.wdReplaceAll)
                            .Text = "<female>"
                            .Replacement.Text = " "
                            .Execute(Replace:=Word.WdReplace.wdReplaceAll)
                        ElseIf control.Text = "Female" Then
                            .Text = "<male>"
                            .Replacement.Text = " "
                            .Execute(Replace:=Word.WdReplace.wdReplaceAll)
                            .Text = "<female>"
                            .Replacement.Text = "X"
                            .Execute(Replace:=Word.WdReplace.wdReplaceAll)
                        Else
                            .Text = "<male>"
                            .Replacement.Text = " "
                            .Execute(Replace:=Word.WdReplace.wdReplaceAll)
                            .Text = "<female>"
                            .Replacement.Text = " "
                            .Execute(Replace:=Word.WdReplace.wdReplaceAll)
                        End If
                    ElseIf control.Name = "cbAnnualHousehold" Then
                        If control.Text = " < 60 000" Then
                            .Text = "<low>"
                            .Replacement.Text = "X"
                            .Execute(Replace:=Word.WdReplace.wdReplaceAll)
                        ElseIf control.Text = "60 001 - 480 000" Then
                            .Text = "<mid>"
                            .Replacement.Text = "X"
                            .Execute(Replace:=Word.WdReplace.wdReplaceAll)
                        ElseIf control.Text = "> 480 000" Then
                            .Text = "<high>"
                            .Replacement.Text = "X"
                            .Execute(Replace:=Word.WdReplace.wdReplaceAll)
                        ElseIf control.Text = "Undisclosed" Then
                            .Text = "<dis>"
                            .Replacement.Text = "X"
                            .Execute(Replace:=Word.WdReplace.wdReplaceAll)
                        End If

                        Dim incomes As New List(Of String) From {"low", "mid", "high", "dis"}
                        For Each income In incomes
                            .Text = "<" & income & ">"
                            .Replacement.Text = " "
                            .Execute(Replace:=Word.WdReplace.wdReplaceAll)
                        Next
                    Else
                        .Text = "<" & control.Tag & ">"
                        .Replacement.Text = If(control.Text = "", " ", control.Text)
                        .Execute(Replace:=Word.WdReplace.wdReplaceAll)
                    End If

                ElseIf TypeOf control Is MaskedTextBox Then

                        mtb = control
                        mtb.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
                        .Text = "<" & control.Tag & ">"
                        .Replacement.Text = If(control.Text = "", " ", control.Text)
                        .Execute(Replace:=Word.WdReplace.wdReplaceAll)
                        mtb.TextMaskFormat = MaskFormat.IncludePromptAndLiterals

                    ElseIf TypeOf control Is DateTimePicker Then
                        dtp = control
                        .Text = "<" & control.Tag & ">"
                        If dtp.Checked Then
                            .Replacement.Text = Format(dtp.Value, "dd/MM/yyyy")
                        Else
                            .Replacement.Text = "DD/MM/YYYY"
                            .Replacement.Font.Color = WdColor.wdColorGray35
                        End If
                        .Execute(Replace:=Word.WdReplace.wdReplaceAll)
                        .Replacement.Font.Color = WdColor.wdColorBlack
                    ElseIf TypeOf control Is NumericUpDown Then
                        Dim nud As NumericUpDown = control
                    .Text = "<" & control.Tag & ">"
                    If nud.Value > -1 Then
                        .Replacement.Text = nud.Value
                    Else
                        .Replacement.Text = " "
                    End If
                    .Execute(Replace:=Word.WdReplace.wdReplaceAll)

                End If
            Next
        End With
        oDoc.SaveAs(My.Computer.FileSystem.SpecialDirectories.Temp & "\Zestlife Gap App (" & lbLeadID.Text & ").pdf", 17)
        'Console.WriteLine(My.Computer.FileSystem.SpecialDirectories.Temp & "\Zestlife Gap App (" & lbLeadID.Text & ").pdf")
        oDoc.Saved = True
        oDoc.Close()
        oWord.Quit()
        releaseObject(oDoc)
        releaseObject(oWord)

        Return My.Computer.FileSystem.SpecialDirectories.Temp & "\Zestlife Gap App (" & lbLeadID.Text & ").pdf"

    End Function

#End Region

#Region "Side Controls"

    Public Sub createControls(sender As Object, groupHeight As Integer, groupLocationY As Integer)

        gbMain = New GroupBox
        gbMain.Location = New System.Drawing.Point(707, groupLocationY)
        gbMain.Height = groupHeight
        gbMain.Width = sender.width
        Me.Controls.Add(gbMain)

        Dim cbReason As New ComboBox()
        Dim tbComments As New TextBox
        If sender.text <> "Sale" Then

            'Reasons
            cbReason.DropDownStyle = ComboBoxStyle.DropDownList
            cbReason.Width = gbMain.Width - 4
            cbReason.Height = 20
            cbReason.Location = New System.Drawing.Point(2, gbMain.Height - 128)
            Dim result() As DataRow = dtStatuses.Select("status = '" & sender.tag & "'")
                        For Each row As DataRow In result
                cbReason.Items.Add(row(1))
            Next
            cbReason.Items.Add("Other")

            'Comments
            tbComments.Multiline = True
            tbComments.Width = gbMain.Width - 4
            tbComments.Height = 75
            tbComments.Location = New System.Drawing.Point(2, gbMain.Height - 104)
        End If
        gbMain.Controls.Add(cbReason)
        gbMain.Controls.Add(tbComments)


        Dim btSubmit As New Button
        btSubmit.Text = "Submit " & sender.Text
        btSubmit.Width = gbMain.Width - 4
        btSubmit.Height = 20
        btSubmit.Location = New System.Drawing.Point(2, gbMain.Height - 25)


        gbMain.Controls.Add(btSubmit)

        Select Case sender.text
            Case "Reschedual"

                Dim x As Integer = 10
                Dim y As Integer = 15

                '=================================
                '       gbDate Sub Controls
                '=================================
                Dim gbDate As New GroupBox
                gbDate.Location = New System.Drawing.Point(2, 20)
                gbDate.Width = gbMain.Width - 4
                gbDate.Height = 55
                gbDate.Text = "Date"
                gbDate.Tag = "Date"
                gbMain.Controls.Add(gbDate)

                Dim dateList As New List(Of String) From {"Today", "Tomorrow", "Next Week", "Next Month"}
                For Each dateRB In dateList
                    Dim rb As New RadioButton
                    rb.Text = dateRB
                    rb.Tag = "Date"
                    rb.AutoSize = True
                    Select Case dateRB
                        Case "Today"
                            rb.Location = New System.Drawing.Point(3, 15)
                        Case "Tomorrow"
                            rb.Location = New System.Drawing.Point(100, 15)
                        Case "Next Week"
                            rb.Location = New System.Drawing.Point(3, 35)
                        Case "Next Month"
                            rb.Location = New System.Drawing.Point(100, 35)
                    End Select
                    gbDate.Controls.Add(rb)
                    AddHandler rb.Click, AddressOf updateCallBack
                Next


                '=================================
                '       gbHours Sub Controls
                '=================================
                Dim gbHours As New GroupBox
                gbHours.Location = New System.Drawing.Point(2, 75)
                gbHours.Width = (gbMain.Width / 2) + 19
                gbHours.Height = 100
                gbHours.Text = "Hours"
                gbHours.Tag = "Hours"
                gbMain.Controls.Add(gbHours)

                Dim rbHours As RadioButton
                For i = 8 To 18
                    rbHours = New RadioButton
                    rbHours.Text = i
                    rbHours.AutoSize = True
                    If i <> 8 And i Mod 4 = 0 Then
                        x += 37
                        y = 15
                    End If
                    rbHours.Location = New System.Drawing.Point(x, y)
                    rbHours.Tag = "Hours"
                    gbHours.Controls.Add(rbHours)
                    AddHandler rbHours.Click, AddressOf updateCallBack
                    y += 20
                Next


                '=================================
                '       gbMins Sub Controls
                '=================================
                Dim gbMins As New GroupBox
                gbMins.Location = New System.Drawing.Point(126.5, 75)
                gbMins.Width = 79
                gbMins.Height = 100
                gbMins.Text = "Minutes"
                gbMins.Tag = "Minutes"
                gbMain.Controls.Add(gbMins)

                Dim rbMins As RadioButton
                y = 15
                For i = 0 To 45 Step 15
                    rbMins = New RadioButton
                    rbMins.Text = CStr(i)
                    rbMins.AutoSize = True
                    rbMins.Location = New System.Drawing.Point(10, y)
                    rbMins.Tag = "Minutes"
                    gbMins.Controls.Add(rbMins)
                    AddHandler rbMins.Click, AddressOf updateCallBack
                    y += 20
                Next


                '=================================
                '       DateTime Pickers
                '=================================
                Dim dpCallDate As New DateTimePicker
                dpCallDate.MinDate = Today
                dpCallDate.Format = DateTimePickerFormat.Short
                dpCallDate.Location = New System.Drawing.Point(3, 180)
                dpCallDate.Tag = "cbDate"
                dpCallDate.Width = gbMain.Width / 1.6
                dpCallDate.Value = Today().AddDays(1)
                gbMain.Controls.Add(dpCallDate)
                'AddHandler dpcallDate.ValueChanged, AddressOf clearDateShortcuts

                Dim dpcallTime As New DateTimePicker
                'dpcallTime.MinDate = Now
                dpcallTime.Format = DateTimePickerFormat.Custom
                dpcallTime.CustomFormat = "HH:mm"
                dpcallTime.Location = New System.Drawing.Point(135, 180)
                dpcallTime.Tag = "cbTime"
                dpcallTime.Width = gbMain.Width / 3
                dpcallTime.ShowUpDown = True
                gbMain.Controls.Add(dpcallTime)
                'AddHandler dpcallTime.ValueChanged, AddressOf clearDateShortcuts


                '=================================
                '       Other Sub Controls
                '=================================
                cbReason.Location = New System.Drawing.Point(2, dpCallDate.Location.Y + dpCallDate.Height + 4)
                tbComments.Height = btSubmit.Location.Y - cbReason.Location.Y - 28
                tbComments.Location = New System.Drawing.Point(2, cbReason.Location.Y + cbReason.Height + 4)


                If selectedDay <> "" Then
                    For Each Day As RadioButton In gbDate.Controls
                        If Day.Text = selectedDay Then
                            Day.Select()
                        End If
                    Next
                End If

                If selectedHour <> "" Then
                    For Each Hour As RadioButton In gbHours.Controls
                        If Hour.Text = selectedHour Then
                            Hour.Select()
                        End If
                    Next
                End If

                If selectedMin <> "" Then
                    For Each Min As RadioButton In gbMins.Controls
                        If Min.Text = selectedMin Then
                            Min.Select()
                        End If
                    Next
                End If


                AddHandler btSubmit.Click, Sub()
                                               updateRecord(sender.Tag, cbReason.Text, tbComments.Text, dpCallDate, dpcallTime)
                                           End Sub

            Case "Sale"
                'Validate button
                Dim btValidate As New Button
                btValidate.Text = "Validate"
                btValidate.Width = gbMain.Width - 4
                btValidate.Height = 20
                btValidate.Location = New System.Drawing.Point(2, 30)
                gbMain.Controls.Add(btValidate)

                'ListView
                Dim lvValidate As New ListView
                lvValidate.Columns.Add("Issue")
                lvValidate.Columns.Add("Tab")
                lvValidate.View = System.Windows.Forms.View.Details
                lvValidate.CheckBoxes = True
                lvValidate.Width = gbMain.Width - 4
                lvValidate.Height = gbMain.Height - 50 - 40
                lvValidate.Location = New System.Drawing.Point(2, 55)
                gbMain.Controls.Add(lvValidate)

                AddHandler btValidate.Click, Sub()
                                                 validateSale(btValidate, lvValidate, btSubmit)
                                             End Sub

                gbMain.Controls.Remove(cbReason)
                gbMain.Controls.Remove(tbComments)
                btSubmit.Enabled = False
                AddHandler btSubmit.Click, Sub()
                                               updateRecord(sender.Tag, "Sale", tbComments.Text)
                                           End Sub

            Case Else
                AddHandler btSubmit.Click, Sub()
                                               updateRecord(sender.Tag, cbReason.Text, tbComments.Text)
                                           End Sub
        End Select

    End Sub

    Public Sub controlRelocate(sender As Object, e As EventArgs)
        Dim buttonList As New List(Of Button) From {btReschedual, btInvalid, btDeclined, btUncontactable, btSale}
        Dim defaultHeight As Integer = (Me.Height - 40) / btnCounter
        Dim smallHeight As Integer = defaultHeight / 4
        Dim selectedHeight As Integer = defaultHeight / 2
        Dim locationY As Integer = 0

        removeControls(gbMain)

        If (sender.height = defaultHeight) Or (sender.height = smallHeight) Then
            For Each btn In buttonList
                If btn.Name <> sender.name Then
                    'set non-sender buttons to small
                    btn.Height = smallHeight
                    btn.Location = New System.Drawing.Point(707, locationY)
                    locationY += smallHeight
                ElseIf btn.Name = sender.name Then
                    'set sender button to selected size
                    btn.Height = selectedHeight
                    btn.Location = New System.Drawing.Point(707, locationY)
                    createControls(sender, Me.Height - 5 - (selectedHeight + (smallHeight * 5)), locationY + selectedHeight - 20)
                    locationY += Me.Height + btnCounter - (selectedHeight + (smallHeight * 4))
                End If
            Next btn
        ElseIf sender.height = selectedHeight Then
            'Set buttons back to defaults size
            For Each btn As Button In buttonList
                btn.Height = defaultHeight
                btn.Location = New System.Drawing.Point(707, locationY)
                locationY += defaultHeight
            Next btn
        End If
    End Sub

    Public Sub removeControls(control As Control)
        For Each ctrl As Control In control.Controls
            control.Controls.Remove(ctrl)
            ctrl.Dispose()
        Next
        Me.Controls.Remove(control)
        control.Dispose()
    End Sub

    Public Sub updateCallBack(sender As Object, e As EventArgs)
        Dim dtpDate As DateTimePicker = Nothing
        Dim dtpTime As DateTimePicker = Nothing

        For Each ctrl As DateTimePicker In gbMain.Controls.OfType(Of DateTimePicker)()
            If ctrl.Tag = "cbDate" Then
                dtpDate = ctrl
            ElseIf ctrl.Tag = "cbTime" Then
                dtpTime = ctrl
            End If
        Next ctrl

        Select Case sender.Tag
            Case "Date"
                Select Case sender.Text
                    Case "Today"
                        dtpDate.Value = DateTime.Now
                    Case "Tomorrow"
                        dtpDate.Value = DateAdd(DateInterval.Day, 1, DateTime.Now)
                    Case "Next Week"
                        dtpDate.Value = DateAdd(DateInterval.WeekOfYear, 1, DateTime.Now)
                    Case "Next Month"
                        dtpDate.Value = DateAdd(DateInterval.Month, 1, DateTime.Now)
                End Select
                selectedDay = sender.text
            Case "Hours"
                dtpTime.Value = CDate(Format(dtpDate.Value, "yyyy-MM-dd") & " " & sender.Text & ":" & Format(dtpTime.Value, "mm") & ":00")
                selectedHour = sender.text
            Case "Minutes"
                dtpTime.Value = CDate(Format(dtpDate.Value, "yyyy-MM-dd") & " " & Format(dtpTime.Value, "HH") & ":" & sender.Text & ":00")
                selectedMin = sender.text
        End Select
    End Sub

    Public Sub clearDateShortcuts(sender As Object, e As EventArgs)
        For Each gb As GroupBox In gbMain.Controls.OfType(Of GroupBox)()
            If sender.Tag = "cbDate" And gb.Tag = "Date" Then
                For Each rb As RadioButton In gb.Controls.OfType(Of RadioButton)()
                    rb.Checked = False
                Next
            ElseIf sender.tag = "cbTime" And (gb.Tag = "Hours" Or gb.Tag = "Minutes") Then
                For Each rb As RadioButton In gb.Controls.OfType(Of RadioButton)()
                    rb.Checked = False
                Next
            End If
        Next gb
    End Sub

#End Region

#Region "Tab Controls"

    Private Sub cbBankName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBankName.SelectedIndexChanged
        txBranchCode.Text = ""
        Select Case cbBankName.Text
            Case "FNB"
                txBranchCode.Text = "250655"
            Case "Standard Bank"
                txBranchCode.Text = "051001"
            Case "Standard Chartered"
                txBranchCode.Text = "051001"
            Case "Nedbank"
                txBranchCode.Text = "198765"
            Case "PEP Bank"
                txBranchCode.Text = "400001"
            Case "Post Bank"
                txBranchCode.Text = "460005"
            Case "Capitec"
                txBranchCode.Text = "470010"
            Case "Investec"
                txBranchCode.Text = "580105"
            Case "ABSA"
                txBranchCode.Text = "632005"
            Case "Albaraka"
                txBranchCode.Text = "800000"
        End Select
    End Sub

    Private Sub btValidate_Click(sender As Object, e As EventArgs) Handles btValidate.Click
        If btValidate.Text = "Validate" Then
            Dim lead_banking As New List(Of Control) From {txAccountHolder, txAccountNumber, cbAccountType, cbBankName, txBranchCode}

            For Each item In lead_banking
                If item.Text = "" Then
                    MsgBox(item.Tag & " is missing!")
                    item.Focus()
                    Exit Sub
                End If
            Next item

            If CheckBankCode(txAccountNumber.Text, cbBankName.Text) = True Then
                If CheckBranchCode(txBranchCode.Text, cbBankName.Text) = "Correct" Then
                    gbBanking.Enabled = False
                    btValidate.Text = "Enable editing"
                Else
                    MsgBox("Please double check the branch code and bank name.")
                End If
            Else
                MsgBox("Please double check the account number and bank name" & vbNewLine & "If the account is still not validated post fixing, contact your system administrator.")
            End If

        ElseIf btValidate.Text = "Enable editing" Then
            gbBanking.Enabled = True
            cbBankingOveride.Checked = False
            btValidate.Text = "Validate"
        End If
    End Sub

    Private Sub rbChecked_CheckedChanged()
        Dim rbPrimary As Object
        Dim rbExcess As Object
        Dim dictProducts As Dictionary(Of String, String)
        prodCode = ""
        If cbProdYear.Text = "2016" Then
            rbPrimary = New List(Of RadioButton) From {rbCore, rbStandard, rbUniversal}
            rbExcess = New List(Of RadioButton) From {rbNoExcess, rbWithExcess}
            dictProducts = New Dictionary(Of String, String)(dictProducts2016)
        Else
            rbPrimary = New List(Of RadioButton) From {rbMatchCover, rbUniversal2017}
            rbExcess = New List(Of RadioButton) From {rbTypeSingle, rbTypeOther}
            dictProducts = New Dictionary(Of String, String)(dictProducts2017)
        End If


        'Primary Info
        For Each rb In rbPrimary
            If rb.Checked Then
                prodCode = rb.Tag
                Exit For
            End If
        Next rb
        If prodCode = "" Then
            lbProdCost.Text = ""
            lbProdDesc.Text = "Please select a product."
            Exit Sub
        End If

        'ExcessInfo
        For Each rb In rbExcess
            If rb.Checked Then
                prodCode = prodCode & rb.Tag
                Exit For
            End If
        Next rb
        If Len(prodCode) = 1 Then
            lbProdCost.Text = ""
            If cbProdYear.Text = "2016" Then
                lbProdDesc.Text = "Please select with or without excess"
            Else
                lbProdDesc.Text = "Please select ""Single < 55"" or ""Other"""
            End If

            Exit Sub
        End If

        'Cancer
        Dim rbCancer As New List(Of RadioButton) From {rbNoCancer, rbCancer1, rbCancer2}
        For Each rb In rbCancer
            If rb.Checked Then
                prodCode = prodCode & rb.Tag
                Exit For
            End If
        Next rb
        If Len(prodCode) = 2 Then
            prodCode = prodCode & "X"
        End If

        'Dentistry
        Dim rbDentistry As New List(Of RadioButton) From {rbNoDentistry, rbWithDentistry}
        For Each rb In rbDentistry
            If rb.Checked Then
                prodCode = prodCode & rb.Tag
                Exit For
            End If
        Next rb
        If Len(prodCode) = 3 Then
            prodCode = prodCode & "X"
        End If

        lbProdCost.Text = "R " & dictProducts.Item(prodCode).Split("_")(0)
        lbProdDesc.Text = dictProducts.Item(prodCode).Split("_")(1)

        If rbCancer1.Checked Or rbCancer2.Checked Then
            gbCancerUW.Visible = True
        ElseIf rbNoCancer.Checked Then
            gbCancerUW.Visible = False
        End If

        If rbCancer1.Checked Or rbCancer2.Checked Then
            gbCancerUW.Visible = True
        ElseIf rbNoCancer.Checked Then
            gbCancerUW.Visible = False
        End If

        If rbWithDentistry.Checked Then
            gbDentistryUW.Visible = True
        Else
            gbDentistryUW.Visible = False
        End If

        cbAfford.Checked = False

    End Sub

    Private Sub cbAfford_CheckedChanged(sender As Object, e As EventArgs) Handles cbAfford.CheckedChanged
        If lbProdCost.Text = "" Then
            cbAfford.Checked = False
        End If

        If rbTypeSingle.Checked Then
            If cbAfford.Checked Then
                If dtpDOB.Value < DateAdd(DateInterval.Year, -55, Today) Then
                    MsgBox("Too old for singles product")
                    cbAfford.Checked = False
                End If
                If nudDependants.Value > 1 Then
                    MsgBox("Too many dependants for singles product")
                    cbAfford.Checked = False
                End If
            End If
        End If
    End Sub

    Private Sub rbCancerUw_CheckedChanged(sender As Object, e As EventArgs)
        If sender.Name = "rbCancerUwYes" Then
            lbCancerUW.Text = "Unfortunatly you do not qualify for the cancer cover."
        ElseIf sender.Name = "rbCancerUwNo" Then
            lbCancerUW.Text = "All cancer benefits in the policy will cease at age 65. This includes the cancer embed (R25,000), the 20% co-payment benefit and the Mastectomy benefit." _
                & vbNewLine & vbNewLine & "The 12 month pre-existing condition exclusion will be included in the policy and must become a QA fail if not properly explained!" _
                & vbNewLine & "Please remember to explain this to the client."
        End If
    End Sub

    Private Sub rbProcedureNo_CheckedChanged(sender As Object, e As EventArgs) Handles rbProcedureNo.CheckedChanged
        mtbProcedure.Visible = False
    End Sub

    Private Sub rbProcedureYes_CheckedChanged(sender As Object, e As EventArgs) Handles rbProcedureYes.CheckedChanged
        mtbProcedure.Visible = True
    End Sub

    Private Sub tbHistory_Enter(sender As Object, e As EventArgs) Handles tbHistory.Enter
        refreshHistory()
    End Sub

    Private Sub refreshHistory()
        If cbEvents.Checked Or cbChanges.Checked Or cbComments.Checked Or cbCalls.Checked Then
            Dim sqlQuery As String = "SELECT timeStamp, user, eventmain, CAST(eventSub AS CHAR(100)) AS eventSub, CAST(changeFrom AS CHAR(100)) AS changeFrom, CAST(changeTo AS CHAR(100)) AS changeTo, CAST(comment AS CHAR(100)) AS comment FROM ("

            If cbEvents.Checked Then sqlQuery = sqlQuery & "SELECT timeStamp, user, eventMain, eventSub, NULL AS changeFrom, NULL AS changeTo, NULL comment FROM hist_events WHERE leadID = " & lbLeadID.Text & " UNION "

            If cbChanges.Checked Then sqlQuery = sqlQuery & "SELECT timestamp, user, 'Change' As eventMain, field As eventSub, changeFrom, changeTo, comment FROM hist_changes WHERE leadID = " & lbLeadID.Text & " UNION "

            If cbComments.Checked Then sqlQuery = sqlQuery & "SELECT timeStamp, user, 'Comment' AS eventMain, NULL AS eventSub, NULL AS changeFrom, NULL AS changeTo, comment FROM lead_comments WHERE leadID = " & lbLeadID.Text & " UNION "

            If cbCalls.Checked Then sqlQuery = sqlQuery & "SELECT timeStamp, userName as user, IF(answered = 1, 'Answered Call', 'Missed Call') As eventMain, dialledNum AS eventSub, wait AS changeFrom, duration AS changeTo, NULL AS comment FROM queuemetrics " _
                & "LEFT JOIN lead_primary ON RIGHT(dialledNum, 9) = RIGHT(contactNumber, 9) LEFT JOIN sys_users ON RIGHT(sys_users.workNumber, 7) = agentCode WHERE leadID = " & lbLeadID.Text & " UNION "

            sqlQuery = sqlQuery.Substring(0, sqlQuery.Length() - 7) & ") as a ORDER BY timeStamp DESC"
            conn.fillDS(sqlQuery, "history")
            dgHistory.DataSource = conn.ds.Tables("history")
        Else
            conn.ds.Tables("history").Clear()
            dgHistory.DataSource = conn.ds.Tables("history")
        End If
    End Sub

    Private Sub rbPolicyReplaceYes_CheckedChanged(sender As Object, e As EventArgs) Handles rbPolicyReplaceYes.CheckedChanged
        If rbPolicyReplaceYes.Checked Then
            mtbReplacementPolicy.Visible = True
            If Not fromLoad Then
                MsgBox("I must make you aware that:" & vbNewLine & vbNewLine _
                   & "A replacement of any insurance may be to your disadvantage because you will be paying some fees and charges twice for your existing policy and again for your new policy." & vbNewLine & vbNewLine _
                   & "Your new policy may not have the same cover or premium as the existing policy." & vbNewLine & vbNewLine _
                   & "Your new policy may have more exclusions or restrictions." & vbNewLine & vbNewLine _
                   & "My advise is to cancel your existing policy only once you have satisfied yourself with the documentation that you recieve from us which you will recieve within the next 3 weeks.")
            End If
        Else
            mtbReplacementPolicy.Visible = False
        End If
    End Sub

    Private Sub rbPolicyReplaceNo_CheckedChanged_1(sender As Object, e As EventArgs) Handles rbPolicyReplaceNo.CheckedChanged
        If rbPolicyReplaceNo.Checked Then
            mtbReplacementPolicy.Visible = False
        Else
            mtbReplacementPolicy.Visible = True
        End If
    End Sub

    Private Sub chbSameAsPostal_CheckedChanged(sender As Object, e As EventArgs) Handles chbSameAsPostal.CheckedChanged
        If chbSameAsPostal.Checked Then
            gbPhysical.Enabled = False
        Else
            gbPhysical.Enabled = True
            If cbPhysicalSuburb.Items.Count = 0 Then
                cbPhysicalSuburb.Items.AddRange(arrSuburbItems)
                cbPhysicalCity.Items.AddRange(arrCityItems)
                cbPhysicalProvince.Items.AddRange(arrProvinceItems)
            End If
        End If
    End Sub

    Private Sub rbMedAidNo_CheckedChanged(sender As Object, e As EventArgs) Handles rbMedAidNo.CheckedChanged
        If MsgBox("Would you like to make this lead invalid?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            btInvalid.PerformClick()
        End If
    End Sub

    Private Sub cbMedicalAid_Leave(sender As Object, e As EventArgs) Handles cbMedicalAid.Leave
        If cbMedicalAid.Text <> "" Then
            If Not cbMedicalAid.Items.Contains(cbMedicalAid.Text) Then
                MsgBox("Please select a Medical Aid from the dropdown list.")
                cbMedicalAid.Focus()
            End If
        End If
    End Sub

    Private Sub cbMedicalAid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMedicalAid.SelectedIndexChanged
        cbMedAidPlan.Items.Clear()
        Dim plans() As DataRow = dtMedicalAids.Select("medicalAidName = '" & Replace(cbMedicalAid.Text, "'", "''") & "'")
        For Each plan In plans
            cbMedAidPlan.Items.Add(plan(1))
        Next
        If cbMedAidPlan.Items.Count = 1 And cbMedAidPlan.Items(0) = "" Then
            cbMedAidPlan.Visible = False
        Else
            cbMedAidPlan.Visible = True
        End If
    End Sub

    Private Sub dtpDOB_ValueChanged(sender As Object, e As EventArgs) Handles dtpDOB.ValueChanged
        checkDate()
    End Sub

    Private Sub cbOverideDob_CheckedChanged(sender As Object, e As EventArgs) Handles cbOverideDob.CheckedChanged
        If dtpDOB.Checked Then
            If cbOverideDob.Checked Then
                Dim overide As String = InputBox("Please supply a reason for overide.", "Please Comment")
                If overide <> "" Then
                    conn.recordEvent("DOB Overide", overide, lbLeadID.Text)
                Else
                    MsgBox("A reason is needed to overide.")
                    cbOverideDob.Checked = False
                End If
            End If
        Else
            MsgBox("You need to enable the DOB")
            cbOverideDob.Checked = False
        End If
        checkDate()
    End Sub

    Private Sub checkDate()
        If cbOverideDob.Checked Then
            lbDOBChange.Visible = False
            lbDOBChange.Text = "Temp"
        Else
            If dtpDOB.Checked Then
                If dtpDOB.Value > DateAdd(DateInterval.Year, -18, Today) Then

                    lbDOBChange.Visible = True
                    lbDOBChange.Text = "DOB too young"
                ElseIf dtpDOB.Value < DateAdd(DateInterval.Year, -65, Today) Then

                    lbDOBChange.Visible = True
                    lbDOBChange.Text = "DOB too old"
                Else
                    lbDOBChange.Visible = False
                    lbDOBChange.Text = "Temp"
                End If
            Else
                lbDOBChange.Visible = False
                lbDOBChange.Text = "Temp"
            End If
        End If
    End Sub

    Private Sub cbBankingOveride_CheckedChanged(sender As Object, e As EventArgs) Handles cbBankingOveride.CheckedChanged
        If cbBankingOveride.Checked Then
            If (txAccountHolder.Text = "") Or (txAccountNumber.Text = "") Or (cbAccountType.Text = "") Or (cbBankName.Text = "") Or (txBranchCode.Text = "") Then
                MsgBox("Please fill all info out first.")
                cbBankingOveride.Checked = False
                Exit Sub
            End If

            Dim overide As String = InputBox("Please supply a reason for overide.", "Please Comment")
            If overide <> "" Then
                conn.recordEvent("Banking Overide", overide, lbLeadID.Text)
                gbBanking.Enabled = False
                btValidate.Text = "Enable Editing"
            Else
                MsgBox("A reason is needed to overide.")
                cbBankingOveride.Checked = False
                btValidate.Text = "Validate"
            End If
        Else
            gbBanking.Enabled = True
        End If
    End Sub

#End Region

    Private Sub btPopulateAcountHolder_Click(sender As Object, e As EventArgs) Handles btPopulateAcountHolder.Click
        txAccountHolder.Text = txFirstName.Text & " " & txLastName.Text
    End Sub

    Private Sub dtpCollectionDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpCollectionDate.ValueChanged

        If dtpCollectionDate.Checked Then

            If CDate(dtpCollectionDate.Value) < earliestCollectionDate Then
                lbCollectionError.Text = "Collection too early."
                lbCollectionError.Visible = True
            ElseIf CDate(dtpCollectionDate.Value) > DateAdd(DateInterval.Month, 3, Today) Then
                lbCollectionError.Text = "Collection too late."
                lbCollectionError.Visible = True
            Else
                lbCollectionError.Visible = False
                lbCommDate.Visible = True
                If Month(dtpCollectionDate.Value) = Month(Today) Then
                    lbCommDate.Text = "Commencement Date = " & Now.AddDays((Now.Day - 1) * -1).AddMonths(1)
                ElseIf Month(dtpCollectionDate.Value) = Month(Today) + 1 Then
                    lbCommDate.Text = "Commencement Date = " & Now.AddDays((Now.Day - 1) * -1).AddMonths(1)
                ElseIf Month(dtpCollectionDate.Value) = Month(Today) + 2 Then
                    lbCommDate.Text = "Commencement Date = " & Now.AddDays((Now.Day - 1) * -1).AddMonths(2)
                End If
            End If
        Else
            lbCollectionError.Visible = False
        End If

    End Sub

    Private Sub cbOverideColectionDate_CheckedChanged(sender As Object, e As EventArgs) Handles cbOverideColectionDate.CheckedChanged
        If dtpCollectionDate.Checked Then
            If cbOverideColectionDate.Checked Then
                Dim overide As String = InputBox("Please supply a reason for overide.", "Please Comment")
                If overide <> "" Then
                    conn.recordEvent("Collection Date Overide", overide, lbLeadID.Text)
                    lbCollectionError.Visible = False
                Else
                    MsgBox("A reason is needed to overide.")
                    cbOverideColectionDate.Checked = False
                End If
            End If
        Else
            MsgBox("You need to enable the Collection Date")
        End If
    End Sub

    Private Sub cbPaymentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPaymentType.SelectedIndexChanged
        If cbPaymentType.Text = "Cash" Or cbPaymentType.Text = "Payroll deduction" Then
            gbBanking.Enabled = False
            btValidate.Enabled = False
            cbBankingOveride.Enabled = False
        Else
            If btValidate.Text = "Validate" Then
                gbBanking.Enabled = True
                btValidate.Enabled = True
                cbBankingOveride.Enabled = True
            End If
        End If

        If cbPaymentType.Text = "Payroll deduction" Then
            lbEmployeeNum.Visible = True
            txEmployeeNum.Visible = True
            cbOverrideEmployeeNum.Visible = True
        Else
            lbEmployeeNum.Visible = False
            txEmployeeNum.Visible = False
            cbOverrideEmployeeNum.Visible = False
        End If
    End Sub

    Private Sub mtbIdNumber_KeyUp(sender As Object, e As KeyEventArgs) Handles mtbIdNumber.KeyUp
        Try
            mtbIdNumber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
            If mtbIdNumber.Text.Length > 5 Then
                Dim dobDate As New Date(System.Globalization.CultureInfo.CurrentCulture.Calendar.ToFourDigitYear(mtbIdNumber.Text.Substring(0, 2)), CInt(mtbIdNumber.Text.Substring(2, 2)), CInt(mtbIdNumber.Text.Substring(4, 2)))
                dtpDOB.Value = dobDate
            End If
            If mtbIdNumber.Text.Length > 6 Then
                If mtbIdNumber.Text.Substring(6, 1) < 5 Then
                    cbGender.Text = "Female"
                ElseIf mtbIdNumber.Text.Substring(6, 1) > 4 Then
                    cbGender.Text = "Male"
                End If
            End If
        Catch
        Finally
            mtbIdNumber.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
        End Try
    End Sub

    Public Sub saleConfirmationEmail()
        Dim emailHTML As String = "Dear " & cbTitle.Text & " " & txFirstName.Text & " " & txLastName.Text & "," & vbNewLine & vbNewLine

        emailHTML += "Welcome to the ZestLife family!" & vbNewLine & vbNewLine

        emailHTML += "Attached please see the following documents:" & "<ul>"
        emailHTML += "<li>Your captured information, please review this document and notify us should we have captured any information incorrectly</li>"
        emailHTML += "<li>Medical Gap Brochure</li>"
        emailHTML += "<li>Legal Disclaimers</li>"
        emailHTML += "</ul>"

        Dim attachements As String = ""
        attachements += completeConfirmationForm(systemFolder & "SystemMaterial\Confirmation Form.docx") & ";"

        Dim groupCheck As String = conn.sendReturn("SELECT groupName FROM affinities WHERE adminCode = '" & adminCode & "'")
        If System.IO.File.Exists(systemFolder & "SystemMaterial\Brochure - " & groupCheck & ".pdf") Then
            attachements += systemFolder & "SystemMaterial\Brochure - " & groupCheck & ".pdf" & ";"
        Else
            If cbProdYear.Text = "2017" Then
                attachements += systemFolder & "SystemMaterial\Brochure (2017).pdf" & ";"
            Else
                attachements += systemFolder & "SystemMaterial\Brochure.pdf" & ";"
            End If

        End If

        attachements += systemFolder & "SystemMaterial\Disclosures.pdf" & ";"
        'attachements += systemFolder & "SystemMaterial\Zwing Network.pdf" & ";"


        emailHTML += vbNewLine & "Zestlife have set up a referral program which allows you to easily refer a friend or family member to the great products that Zestlife has to offer. If the person takes out one of our policies, we will pay you R400 on their second premium collection."
        emailHTML += vbNewLine & vbNewLine & "To refer a friend, just respond to this email."
        emailHTML += vbNewLine & vbNewLine & "It really is an easy way to bring smart products to your network of family and friends and get rewarded for it."
        emailHTML += vbNewLine & vbNewLine & "Please do not hesitate to contact myself should you have any queries."
        Try
            emailOutlook(txEmailAddress.Text, "Welcome to Zestlife", emailHTML, , attachements.Substring(0, attachements.Length - 1))
        Catch
            MsgBox("Error creating confirmation email")
        End Try

    End Sub

    Public Function completeConfirmationForm(appLocation As String) As String
        Dim oWord As New Word.Application
        Dim oDoc As Word.Document = oWord.Documents.Open(appLocation)
        'oWord.Visible = True

        Dim rng As Word.Range = oWord.ActiveDocument.Range()
        With rng.Find

            Dim mtb As MaskedTextBox
            Dim dtp As DateTimePicker
            Dim nud As NumericUpDown
            'cbDependents, 
            Dim controls As New List(Of Control) From {cbTitle, txFirstName, txLastName, dtpDOB, mtbIdNumber, cbGender, txEmailAddress, mtbContactNumber, _
                                                       mtbWorkNumber, mtbHomeNumber, cbMedicalAid, cbMedAidPlan, nudDependants, txAccountHolder, cbBankName, txBranchCode, txAccountNumber, cbAccountType, _
                                                       dtpCollectionDate, cbPaymentDay, mtbReplacementPolicy, mtbProcedure, txPostalLine1, txPostalLine2, cbPostalSuburb, cbPostalCity, _
                                                       cbPostalProvince, txPostalCode}
            For Each control In controls
                If (TypeOf control Is TextBox) Or (TypeOf control Is ComboBox) Then
                    .Text = "<" & control.Tag & ">"
                    .Replacement.Text = If(control.Text = "", "N/A", control.Text)
                    .Execute(Replace:=Word.WdReplace.wdReplaceAll)

                ElseIf TypeOf control Is MaskedTextBox Then

                    mtb = control
                    mtb.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
                    .Text = "<" & control.Tag & ">"
                    .Replacement.Text = If(control.Text = "", "N/A", control.Text)
                    .Execute(Replace:=Word.WdReplace.wdReplaceAll)
                    mtb.TextMaskFormat = MaskFormat.IncludePromptAndLiterals

                ElseIf TypeOf control Is DateTimePicker Then
                    dtp = control
                    .Text = "<" & control.Tag & ">"
                    If dtp.Checked Then
                        .Replacement.Text = Format(dtp.Value, "dd/MM/yyyy")
                    Else
                        .Replacement.Text = "DD/MM/YYYY"
                        .Replacement.Font.Color = WdColor.wdColorGray35
                    End If
                    .Execute(Replace:=Word.WdReplace.wdReplaceAll)
                    .Replacement.Font.Color = WdColor.wdColorBlack

                ElseIf TypeOf control Is NumericUpDown Then
                    nud = control
                    .Text = "<" & control.Tag & ">"
                    .Replacement.Text = nud.Value - 1
                    .Execute(Replace:=Word.WdReplace.wdReplaceAll)
                End If

            Next

            .Text = "<cancerUW>"
            If rbCancerUwYes.Checked Then
                .Replacement.Text = "Yes"
            Else
                .Replacement.Text = "No"
            End If
            .Execute(Replace:=Word.WdReplace.wdReplaceAll)

            .Text = "<procedure>"
            If rbProcedureYes.Checked Then
                .Replacement.Text = mtbProcedure.Text
            Else
                .Replacement.Text = "No"
            End If
            .Execute(Replace:=Word.WdReplace.wdReplaceAll)

            If rbPolicyReplaceYes.Checked Then
                .Text = "<replacementPolicy>"
                .Replacement.Text = mtbReplacementPolicy.Text
                .Execute(Replace:=Word.WdReplace.wdReplaceAll)
            ElseIf rbPolicyReplaceNo.Checked Then
                .Text = "<replacementPolicy>"
                .Replacement.Text = "N/A"
                .Execute(Replace:=Word.WdReplace.wdReplaceAll)
            End If

            If prodCode <> "" Then
                .Text = "<planCode>"
                .Replacement.Text = prodCode
                .Execute(Replace:=Word.WdReplace.wdReplaceAll)

                Dim dictProducts As New Dictionary(Of String, String)
                If cbProdYear.Text = "2016" Then
                    dictProducts = dictProducts2016
                Else
                    dictProducts = dictProducts2017
                End If

                .Text = "<planName>"
                .Replacement.Text = dictProducts.Item(prodCode).Split("_")(1)
                .Execute(Replace:=Word.WdReplace.wdReplaceAll)

                .Text = "<planMonthlyPremium>"
                .Replacement.Text = "R " & dictProducts.Item(prodCode).Split("_")(0)
                .Execute(Replace:=Word.WdReplace.wdReplaceAll)

            End If

        End With
        oDoc.SaveAs(My.Computer.FileSystem.SpecialDirectories.Temp & "\Confirmation Form (" & lbLeadID.Text & ").pdf", 17)
        oDoc.Saved = True
        oDoc.Close()
        oWord.Quit()
        releaseObject(oDoc)
        releaseObject(oWord)

        Return My.Computer.FileSystem.SpecialDirectories.Temp & "\Confirmation Form (" & lbLeadID.Text & ").pdf"

    End Function

    Private Sub cbEmail_CheckedChanged(sender As Object, e As EventArgs) Handles cbEmail.CheckedChanged
        If cbEmail.Checked Then
            txEmailAddress.Enabled = True
        Else
            txEmailAddress.Enabled = False
        End If
    End Sub

    Private Sub cbPostalSuburb_KeyDown(sender As Object, e As KeyEventArgs) Handles cbPostalSuburb.KeyDown
        If cbPostalSuburb.DroppedDown Then
            cbPostalSuburb.DroppedDown = False
        End If
    End Sub

    Private Sub cbPostalSuburb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPostalSuburb.SelectedIndexChanged
        Dim result() As DataRow = dtAddressesAll.Select("suburb = '" & Replace(cbPostalSuburb.Text, "'", "''") & "'")
        If result.Count > 0 Then
            cbPostalCity.Text = result(0).Item("city")
            cbPostalProvince.Text = result(0).Item("province")
            txPostalCode.Text = result(0).Item("postalCode")
        End If
        
    End Sub

    Private Sub cbPhysicalSuburb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPhysicalSuburb.SelectedIndexChanged
        Dim result() As DataRow = dtAddressesAll.Select("suburb = '" & cbPostalSuburb.Text & "'")
        If result.Count > 0 Then
            cbPhysicalCity.Text = result(0).Item("city")
            cbPhysicalProvince.Text = result(0).Item("province")
            txPhysicalCode.Text = result(0).Item("postalCode")
        End If
    End Sub

    Private Sub cbNonSaID_CheckedChanged(sender As Object, e As EventArgs) Handles cbNonSaID.CheckedChanged
        If cbNonSaID.Checked Then
            mtbIdNumber.Mask = ""
        Else
            mtbIdNumber.Mask = "000000-0000-000"
        End If

    End Sub

    Private Sub cbPhysicalSuburb_KeyDown(sender As Object, e As KeyEventArgs) Handles cbPhysicalSuburb.KeyDown
        If cbPhysicalSuburb.DroppedDown Then
            cbPhysicalSuburb.DroppedDown = False
        End If
    End Sub

    Private Sub mtb_MouseClick(sender As Object, e As MouseEventArgs)
        Dim mtb As MaskedTextBox = sender
        If mtb.Mask <> "" Then
            mtb.Select(mtb.MaskedTextProvider.LastAssignedPosition + 1, 0)
        End If

    End Sub

    Sub emailZwingSale(zwingAdminCode As String)
        If MsgBox("Would you like to email zwinger confirming sale?", MsgBoxStyle.YesNo) = vbYes Then
            conn.fillDS("SELECT affinityName, emailAdd FROM affinities WHERE adminCode = '" & zwingAdminCode & "'", "zwingDetails")
            If conn.ds.Tables("zwingDetails").Rows.Count <> 0 Then
                With conn.ds.Tables("zwingDetails").Rows(0)

                    Dim emailHTML As String = "Dear " & .Item("affinityName") & vbNewLine & vbNewLine

                    emailHTML += "Congratulations on the sale of the below referral:" & vbNewLine _
                                & vbTab & "&nbsp;Name: " & txFirstName.Text & " " & txLastName.Text & vbNewLine _
                                & vbTab & "&nbsp;ID: " & mtbIdNumber.Text & vbNewLine

                    emailHTML += vbNewLine & "Please contact myself should you have any other referrals for Gap Cover."
                    If Not IsDBNull(.Item("emailAdd")) Then
                        emailOutlook(.Item("emailAdd"), "Gap Zwing Sale", emailHTML)
                    Else
                        emailOutlook("", "Gap Zwing Sale", emailHTML)
                    End If

                End With
            End If
        End If
    End Sub

    Private Sub cbOverrideEmployeeNum_CheckedChanged(sender As Object, e As EventArgs) Handles cbOverrideEmployeeNum.CheckedChanged
        If cbOverrideEmployeeNum.Checked Then

            Dim overide As String = InputBox("Please supply a reason for overide.", "Please Comment")
            If overide <> "" Then
                conn.recordEvent("Employee Num Overide", overide, lbLeadID.Text)
                txEmployeeNum.Enabled = False
            Else
                MsgBox("A reason is needed to overide.")
                cbOverrideEmployeeNum.Checked = False
                btValidate.Text = "Validate"
            End If
        Else
            txEmployeeNum.Enabled = True
        End If
    End Sub

    Private Sub btTransfer_Click(sender As Object, e As EventArgs) Handles btTransfer.Click
        frmLeadTransfer.loadLead(lbLeadID.Text, "Agent")
    End Sub

    Private Sub llAnnualHosehold_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llAnnualHosehold.LinkClicked
        MsgBox("If single – then policyholder income only" & vbNewLine _
            & "If married – then income of spouse and policyholder" & vbNewLine _
            & "If married in common law – then income of both common law spouses" & vbNewLine _
            & "If married with adult dependants - then income of spouse, policyholder and adult dependants" & vbNewLine & vbNewLine _
            & "Monthly Calculation:" & vbNewLine & vbTab _
            & "< 60 000 = < 5 000 pm" & vbNewLine & vbTab _
            & "60 001 - 480 000 = 5 001 - 40 000 pm" & vbNewLine & vbTab _
            & "> 480 000 = > 40 000 pm" & vbNewLine & vbNewLine _
            & "Undisclosed = Client does not want to say", MsgBoxStyle.Information, "Annual Household Income")
    End Sub

    Private Sub llMonthlyDODay_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llMonthlyDODay.LinkClicked
        MsgBox("This is the day every month that the client would like to be debited." & vbNewLine _
            & "If the last day is requested, please select ""31""", MsgBoxStyle.Information, "Monthly Debit Order Day")
    End Sub

    Private Sub llFirstCollectionDate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llFirstCollectionDate.LinkClicked
        MsgBox("This is the date that the first collection will take place." & vbNewLine _
            & "First Collection can only take place 15 days after sale date.", MsgBoxStyle.Information, "First Collection Date")
    End Sub

    Private Sub llPreExisting_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llPreExisting.LinkClicked
        MsgBox("Pre-existing condition definition:" & vbNewLine & "Any medical condition the client is aware of and has sort professional medical assistance of any kind in the last 12 months.", , "Pre-existing condition")
    End Sub

    Private Sub cbProdYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProdYear.SelectedIndexChanged
        If cbProdYear.Text = "2016" Then
            gbProduct2016.Visible = True
            gbProduct2017.Visible = False
        ElseIf cbProdYear.Text = "2017" Then
            gbProduct2017.Visible = True
            gbProduct2016.Visible = False
        End If
        rbChecked_CheckedChanged()

    End Sub

End Class