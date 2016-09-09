Imports Microsoft.Office.Interop
Public Class frmIncentives

    Private Sub frmIncentives_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
    End Sub

    Private Sub btExport_Click(sender As Object, e As EventArgs) Handles btExport.Click
        Dim xlApp As Excel.Application
        Dim xlWB As Excel.Workbook
        Dim xlWS As Excel.Worksheet

        xlApp = CreateObject("Excel.Application")
        xlWB = xlApp.Workbooks.Open(systemFolder & "SystemMaterial\Incentive Template.xlsx")
        xlWS = xlWB.Sheets("Gap")
        'xlApp.Visible = True

        xlWB.RefreshAll()

        xlApp.DisplayAlerts = False
        xlWS.ExportAsFixedFormat(Type:=Excel.XlFixedFormatType.xlTypePDF, Filename:=systemFolder & "DataTrail\IncentiveExport\IncetiveExport_" & Format(Today, "yyyy.MM.dd") & ".pdf")
        'xlWB.SaveAs(systemFolder & "DataTrail\IncentiveExport\IncetiveExport_" & Format(Today, "yyyy.MM.dd") & ".xlsx")
        xlWB.Close()
        xlApp.Quit()
        releaseObject(xlWS)
        releaseObject(xlWB)
        releaseObject(xlApp)

        Dim FILE_NAME As String = systemFolder & "DataTrail\IncentiveExport\IncetiveExport_" & Format(Today, "yyyy.MM.dd") & ".pdf"

        If System.IO.File.Exists(FILE_NAME) = True Then
            Process.Start(FILE_NAME)
        Else
            MsgBox("File Does Not Exist")
        End If

    End Sub
End Class