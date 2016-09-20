Imports Microsoft.Office.Interop
Public Class frmExportSalesFile
    Dim xlApp As Excel.Application
    Dim xlWB As Excel.Workbook
    Dim xlWS As Excel.Worksheet

    Private Sub frmExportSalesFile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
        cbFileName.SelectedIndex = 0
        dtFrom.Value = DateSerial(Today.Year, Today.Month, 1)
        dtTo.Value = Today
    End Sub

    Private Sub btExport_Click(sender As Object, e As EventArgs) Handles btExport.Click

        If CDate(dtFrom.Value.ToString("d")) > CDate(dtTo.Value.ToString("d")) Then
            MsgBox("From date cannot be greater than the to date.")
        ElseIf conn.sendReturn("SELECT COUNT(leadID) FROM lead_primary WHERE status = 'Sale' AND DATE(closedDate) BETWEEN '" & Format(dtFrom.Value(), "yyyy-MM-dd") & "' AND '" & Format(dtTo.Value(), "yyyy-MM-dd") & "'") = "NULL" Then
            MsgBox("No sales for the given dates.")
        Else
            'Try
            btExport.Text = "Exporting..."
            Me.Cursor = Cursors.WaitCursor
            Dim dictColumnLocation As New Dictionary(Of String, Integer)

            xlApp = CreateObject("Excel.Application")
            xlWB = xlApp.Workbooks.Add()
            xlWS = xlWB.Sheets(1)

            Dim endWhere As String = ""
            If cbFileName.Text = "Gap Sales File" Then
                conn.fillDS("SELECT salesFileColumn, databaseColumn FROM sys_sales_files WHERE salesFileName = 'GapSalesFile'", "salesColumns")
                endWhere = " AND affinities.groupName IS NULL"
            ElseIf cbFileName.Text = "Group Sales File" Then
                conn.fillDS("SELECT salesFileColumn, databaseColumn FROM sys_sales_files WHERE salesFileName = 'GroupSalesFile'", "salesColumns")
                endWhere = " AND affinities.groupName IS NOT NULL"
            End If

            'Create SELECT query
            Dim selectStatement As String = "SELECT "
            For i = 0 To conn.ds.Tables("salesColumns").Rows.Count - 1
                xlWS.Cells(1, i + 1).Value = conn.ds.Tables("salesColumns").Rows(i).Item(0)
                If Not IsDBNull(conn.ds.Tables("salesColumns").Rows(i).Item(1)) Then
                    If conn.ds.Tables("salesColumns").Rows(i).Item(1).ToString.Contains(".") Then
                        'selectStatement = selectStatement & conn.ds.Tables("salesColumns").Rows(i).Item(1) & ", "
                        'dictColumnLocation.Add(Split(conn.ds.Tables("salesColumns").Rows(i).Item(1), ".")(1), i + 1)
                        selectStatement = selectStatement & "" & conn.ds.Tables("salesColumns").Rows(i).Item(1) & " AS `" & conn.ds.Tables("salesColumns").Rows(i).Item(0) & "`, "
                        dictColumnLocation.Add(conn.ds.Tables("salesColumns").Rows(i).Item(0), i + 1)
                    Else
                        selectStatement = selectStatement & "'" & conn.ds.Tables("salesColumns").Rows(i).Item(1) & "' AS `" & conn.ds.Tables("salesColumns").Rows(i).Item(0) & "`, "
                        dictColumnLocation.Add(conn.ds.Tables("salesColumns").Rows(i).Item(0), i + 1)
                    End If
                End If
            Next i

            'Collecting Data
            selectStatement = selectStatement.Substring(0, selectStatement.Length - 2) & " FROM lead_primary " _
                & "LEFT JOIN lead_sale_info ON lead_primary.leadID = lead_sale_info.leadID " _
                & "LEFT JOIN lead_banking ON lead_primary.leadID = lead_banking.leadID " _
                & "LEFT JOIN lead_address ON lead_primary.leadID = lead_address.leadID " _
                & "LEFT JOIN affinities ON lead_primary.affinityCode = affinities.adminCode " _
                & "LEFT JOIN sys_products ON lead_sale_info.productTaken = sys_products.productID " _
                & "WHERE status = 'Sale' AND DATE(closedDate) BETWEEN '" & Format(dtFrom.Value(), "yyyy-MM-dd") & "' AND '" & Format(dtTo.Value(), "yyyy-MM-dd") & "'" & endWhere
            conn.fillDS(selectStatement, "leadSales")



            'Export
            Dim postalSubstitue As String = "0000"
            Dim postal As String
            Dim contactNum As String
            For i = 0 To conn.ds.Tables("leadSales").Rows.Count - 1
                For Each column In conn.ds.Tables("leadSales").Columns
                    If Not IsDBNull(conn.ds.Tables("leadSales").Rows(i).Item(column.ToString)) Then
                        If column.ToString = "Unique identifier" Then
                            xlWS.Cells(i + 2, CInt(dictColumnLocation.Item(column.ToString))).Value = i + 1

                        ElseIf column.ToString = "ID" Or column.ToString = "Life Insured ID" Then
                            If validateIdNumber(conn.ds.Tables("leadSales").Rows(i).Item(column.ToString)) = "Pass" Then
                                xlWS.Cells(i + 2, CInt(dictColumnLocation.Item(column.ToString))).NumberFormat = "0"
                                xlWS.Cells(i + 2, CInt(dictColumnLocation.Item(column.ToString))).Value = conn.ds.Tables("leadSales").Rows(i).Item(column.ToString)
                            Else
                                xlWS.Cells(i + 2, CInt(dictColumnLocation.Item(column.ToString) + 1)).Value = conn.ds.Tables("leadSales").Rows(i).Item(column.ToString)
                            End If

                        ElseIf (column.ToString = "Physical address Postal Code") Or (column.ToString = "Postal address Postal code") Then
                            xlWS.Cells(i + 2, CInt(dictColumnLocation.Item(column.ToString))).NumberFormat = "@"
                            postal = conn.ds.Tables("leadSales").Rows(i).Item(column.ToString)
                            xlWS.Cells(i + 2, CInt(dictColumnLocation.Item(column.ToString))).Value = postalSubstitue.Substring(0, 4 - postal.Length) & postal

                        ElseIf (column.ToString = "Cell no") Or (column.ToString = "Business tel no") Or (column.ToString = "Home Tel No") Or (column.ToString = "Fax no") Or
                            (column.ToString = "Life Insured Cell Number") Or (column.ToString = "Life Insured Business number") Then
                            contactNum = conn.ds.Tables("leadSales").Rows(i).Item(column.ToString)
                            xlWS.Cells(i + 2, CInt(dictColumnLocation.Item(column.ToString))).NumberFormat = "@"
                            If contactNum.Length = 9 Then
                                xlWS.Cells(i + 2, CInt(dictColumnLocation.Item(column.ToString))).Value = "0" & contactNum
                            Else
                                xlWS.Cells(i + 2, CInt(dictColumnLocation.Item(column.ToString))).Value = contactNum
                            End If

                        ElseIf column.ToString = "Zwing ID" Then
                            xlWS.Cells(i + 2, CInt(dictColumnLocation.Item(column.ToString))).NumberFormat = "0"
                            xlWS.Cells(i + 2, CInt(dictColumnLocation.Item(column.ToString))).Value = conn.ds.Tables("leadSales").Rows(i).Item(column.ToString)

                        ElseIf column.ToString = "Non SA ID" Or column.ToString = "Zwing Entity code" Then
                            xlWS.Cells(i + 2, CInt(dictColumnLocation.Item(column.ToString))).NumberFormat = "@"
                            xlWS.Cells(i + 2, CInt(dictColumnLocation.Item(column.ToString))).Value = conn.ds.Tables("leadSales").Rows(i).Item(column.ToString)

                        ElseIf dictColumnLocation.ContainsKey(column.ToString) Then
                            xlWS.Cells(i + 2, CInt(dictColumnLocation.Item(column.ToString))).Value = conn.ds.Tables("leadSales").Rows(i).Item(column.ToString)
                        End If
                    End If

                Next
            Next

            'Catch ex As Exception
            'MsgBox(ex.Message)
            'MsgBox(" Error exporting sales file! Please contact the administrtor.", MsgBoxStyle.Critical)
            'Finally
            xlApp.ActiveWindow.WindowState = Excel.XlWindowState.xlMaximized
            xlApp.Visible = True
            releaseObject(xlWS)
            releaseObject(xlWB)
            releaseObject(xlApp)
            btExport.Text = "Export"
            Me.Cursor = Cursors.Default
            If MsgBox("Sales file exported, update latest pull date?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                conn.send("UPDATE sys_defaults SET value = '" & Format(CDate(dtTo.Value), "yyyy-MM-dd") & "' WHERE description = 'lastSalesFilePull'")
                notify("Latest pull date updated.")
            End If
            'End Try
        End If
    End Sub


End Class