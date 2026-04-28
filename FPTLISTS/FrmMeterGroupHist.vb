Imports DevExpress.XtraGrid.Menu
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Utils.Menu
Public Class FrmMeterGroupHist

    Private p_TYTRONG_PTANG As Boolean = False

    Public p_SQLWHere As String




    Private Sub FrmMeter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_Meter As String
        Dim p_WhereCol As String
        Dim p_Column As U_TextBox.GridColumn
        Dim p_DataRow() As DataRow
        Dim p_DataTable As DataTable




        Dim p_SQL As String = ""
        Dim p_sMeter As String = ""


        p_SQL = "select Name_nd as BeXuat  from tblTank where  1=0"

        p_sMeter = "select MeterId  from tblMeter "
        Try
            p_XtraUserName = g_User_ID
            If g_Filter_Terminal = True Then
                If g_Terminal <> "" Then
                    Select Case g_Terminal
                        Case "A"
                            p_Meter = "C1"
                        Case "B"
                            p_Meter = "C2"
                        Case Else
                            p_Meter = "C3"
                    End Select
                    p_WhereCol = "left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'"
                    p_SQL = p_SQL & " and " & p_WhereCol

                    p_sMeter = p_sMeter & " where left(MeterId,LEN ('" & p_Meter & "')) like '" & p_Meter & "%'"

                    Me.GridView1.Where = "left(MeterId,LEN ('" & p_Meter & "')) like '" & p_Meter & "%'"
                End If
            End If
        Catch ex As Exception

        End Try


        Me.DefaultFormLoad = True
        Me.XtraForm1_Load()
        Me.DefaultFormLoad = True
        Me.GridView1.BestFitColumns()

        Me.GridView1.OptionsView.ShowGroupPanel = True





    End Sub



End Class