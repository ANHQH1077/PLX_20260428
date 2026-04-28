
Imports Newtonsoft.Json

Public Class JsonStructure

    Public Sub clsPost_LenhXuatBoSung_JSON(ByVal p_DataTable As DataTable, ByRef o_err As String, ByVal p_Link As String, ByVal p_UserAPI As String, ByVal p_PassAPI As String)
        Post_LenhXuatBoSung_JSON(p_DataTable, o_err, p_Link, p_UserAPI, p_PassAPI)

    End Sub


    Public Sub clsUpdateTrangThaiTichKe_JSON(ByVal p_SoLenh As String, ByRef o_err As String, ByVal p_Link As String, ByVal p_UserAPI As String, ByVal p_PassAPI As String)
        UpdateTrangThaiTichKe_JSON(p_SoLenh, o_err, p_Link, p_UserAPI, p_PassAPI)

    End Sub



#Region "Trang thai tich ke -> SAP"

    Friend Class ObjDATAInTickKe
        <JsonProperty("FUNC")>
        Public Property FUNC As String = "ZFM_HTTG_PUT_INTICKKE"
        <JsonProperty("DATA")>
        Public Property DATA As New IT_DATA_TICHKE

        Public Sub New()

        End Sub
    End Class

    Friend Class IT_DATA_TICHKE
        <JsonProperty("I_VBELN")>
        Public Property I_VBELN As String
    End Class
   

    Friend Class ObjDATADensity
        <JsonProperty("FUNC")>
        Public Property FUNC As String = "ZFM_HTTG_LIMS_GET_VCF"
        <JsonProperty("DATA")>
        Public Property DATA As New IT_DATA_Density
        Public Sub New()

        End Sub
    End Class

    Friend Class IT_DATA_Density
        <JsonProperty("I_WERKS")>
        Public Property I_WERKS As String
        <JsonProperty("I_DATE")>
        Public Property I_DATE As String
    End Class

#End Region





#Region "Thong tin bo sung -> SAP"
    Friend Class ObjDATA
        <JsonProperty("FUNC")>
        Public Property FUNC As String = "ZFM_HTTG_PUSH_LX_V1"
        <JsonProperty("DATA")>
        Public Property DATA As New IT_DATA

        Public Sub New()

        End Sub
    End Class


    Friend Class IT_DATA
        <JsonProperty("IT_DATA")>
        Public Property IT_DATA As New List(Of ObjDetail)
    End Class

    Friend Class ObjDetail
        <JsonProperty("USERNAME")>
        Public Property USERNAME As String
        <JsonProperty("DATE_TIME")>
        Public Property DATE_TIME As String
        <JsonProperty("COMPARTMENT")>
        Public Property COMPARTMENT As String
        <JsonProperty("ORDER_NO")>
        Public Property ORDER_NO As String
        <JsonProperty("LINEID")>
        Public Property LINEID As String
        <JsonProperty("ZZERDAT")>
        Public Property ZZERDAT As String
        <JsonProperty("ZZERTIM")>
        Public Property ZZERTIM As String
        <JsonProperty("ZZAEDAT")>
        Public Property ZZAEDAT As String
        <JsonProperty("ZZAETIM")>
        Public Property ZZAETIM As String
        <JsonProperty("FLG_HTTG")>
        Public Property FLG_HTTG As String
        <JsonProperty("FLG_RUT_TDH")>
        Public Property FLG_RUT_TDH As String
        <JsonProperty("NHIENDO_PT")>
        Public Property NHIENDO_PT As String
        <JsonProperty("CHIEUCAO_HH")>
        Public Property CHIEUCAO_HH As String
        <JsonProperty("BATCH_ND")>
        Public Property BATCH_ND As String
        <JsonProperty("MATNR")>
        Public Property MATNR As String
        <JsonProperty("CUSTOMER")>
        Public Property CUSTOMER As String

        <JsonProperty("VEHICLE")>
        Public Property VEHICLE As String
        <JsonProperty("METER_NO")>
        Public Property METER_NO As String

        <JsonProperty("METER_START")>
        Public Property METER_START As String
        <JsonProperty("METER_END")>
        Public Property METER_END As String

        <JsonProperty("QUANTITY_CONFIRM")>
        Public Property QUANTITY_CONFIRM As String
        <JsonProperty("TEMP_CONFIRM")>
        Public Property TEMP_CONFIRM As String

        <JsonProperty("DENS_CONFIRM")>
        Public Property DENS_CONFIRM As String
        <JsonProperty("NIEM_TEXT")>
        Public Property NIEM_TEXT As String
        <JsonProperty("OUTBOUND")>
        Public Property OUTBOUND As String
        <JsonProperty("ITEM_ND")>
        Public Property ITEM_ND As String
    End Class
#End Region


End Class
