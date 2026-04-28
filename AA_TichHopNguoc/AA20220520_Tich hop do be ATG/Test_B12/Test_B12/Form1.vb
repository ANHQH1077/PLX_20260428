Imports System.ServiceModel
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Web.Script.Serialization
Imports System.Xml

Public Class Form1
    Dim g_1EndPointAddress As String = "http://www.b12petroleum.com.vn/tichhoptrungtam/Service/ServiceATG.svc"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        updateConfigFile("aaaa")


    End Sub

    Public Sub updateConfigFile(ByVal con As String)
        'updating config file
        Dim XmlDoc As New XmlDocument()
        'Loading the Config file
        XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)
        For Each xElement As XmlElement In XmlDoc.DocumentElement
            If xElement.Name = "client" Then
                'setting the coonection string
                xElement.FirstChild.Attributes(2).Value = con


            End If
        Next
        'writing the connection string in config file
        XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)
    End Sub



    Public Sub GetATG(p_Date As Date, p_MaBe As String,
                        ByRef p_thoidiem As String,
                      ByRef p_TankCode As String,
                      ByRef p_ChieuCao As Double,
                      ByRef p_NhietDo As Double,
                      ByRef p_TrongBe As Double, ByRef p_ChieuCaoNuoc As Double, p_Kho As String
                      )
        Dim remoteAddress = New System.ServiceModel.EndpointAddress(New Uri(g_1EndPointAddress))

        Dim p_Binding As System.ServiceModel.BasicHttpBinding
        If InStr(UCase(g_1EndPointAddress), UCase("https"), CompareMethod.Text) > 0 Then
            p_Binding = New System.ServiceModel.BasicHttpBinding(BasicHttpSecurityMode.Transport)
        Else
            p_Binding = New System.ServiceModel.BasicHttpBinding()
            ' p_Binding.Security.Mode = BasicHttpSecurityMode.None
        End If
        '' p_Binding, remoteAddress
        'Dim p_SvrB121 As ATGSvr.ServiceATGClient()

        Dim p_SvrB121 As New ATGSvr.ServiceATGClient()

        Dim p_String As String = ""
        Dim p_SQL As String = ""
        Dim p_JsonStr As String = ""
        p_thoidiem = ""
        p_TankCode = ""
        p_ChieuCao = 0
        p_NhietDo = 0
        p_TrongBe = 0
        p_ChieuCaoNuoc = 0
        'p_String = p_SvrB121.LayDoMuc(p_Date, p_MaBe)
        p_String = p_SvrB121.LayDoMucKhoBe(p_Date, p_Kho, p_MaBe)
        Dim jResults As New JArray
        Dim p_JToken As JToken
        Dim p_Object As JObject
        Try
            jResults = JArray.Parse(p_String)
            If jResults.Count > 0 Then
                p_Object = jResults(0)
                p_Object.CreateReader()
                p_thoidiem = p_Object.GetValue("thoidiem").ToString
                p_TankCode = p_Object.GetValue("Ma_be").ToString
                Double.TryParse(p_Object.GetValue("ChieuCaoBe").ToString, p_ChieuCao)
                Double.TryParse(p_Object.GetValue("NhietDo").ToString, p_NhietDo)
                Double.TryParse(p_Object.GetValue("TrongBe").ToString, p_TrongBe)
                Double.TryParse(p_Object.GetValue("ChieuCaoNuoc").ToString, p_ChieuCaoNuoc)
            End If
        Catch ex As Exception
            p_SQL = ex.Message
        End Try

    End Sub

    Public Sub CreateServicePublic()
        Dim p_SerVice As ATGSvr.ServiceATGClient
        Dim p_SQL As String = ""
        Try
            '  Dim 
            Dim remoteAddress = New System.ServiceModel.EndpointAddress(g_1EndPointAddress)

            Dim p_Binding As System.ServiceModel.BasicHttpBinding
            If InStr(UCase(g_1EndPointAddress), UCase("https"), CompareMethod.Text) > 0 Then
                p_Binding = New System.ServiceModel.BasicHttpBinding(BasicHttpSecurityMode.Transport)
            Else
                p_Binding = New System.ServiceModel.BasicHttpBinding()
            End If
            p_Binding.MaxReceivedMessageSize = 2147483647
            'p_Binding.MessageEncoding = System.Text.UTF8Encoding
            'remoteAddress.
            p_SerVice = New ATGSvr.ServiceATGClient(p_Binding, remoteAddress)
            p_SQL = p_SerVice.LayDoMuc(DateTime.Now, "00D2")
        Catch ex As Exception
            p_SQL = ex.Message
        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim p_thoidiem As String
        Dim p_TankCode As String
        Dim p_Kho As String
        Dim p_BeXuat As String
        Dim p_ChieuCao As Double
        Dim p_NhietDo As Double
        Dim p_TrongBe As Double
        Dim p_ChieuCaoNuoc As Double
        Dim p_Date As Date
        p_Date = Me.pDate.Value
        p_BeXuat = Me.p_Tank.Text
        p_Kho = Me.Kho.Text
        GetATG(p_Date, p_BeXuat, p_thoidiem,
                       p_TankCode,
                       p_ChieuCao,
                       p_NhietDo,
                       p_TrongBe, p_ChieuCaoNuoc, p_Kho)
        Try
            Me.ChieuCao.Text = p_ChieuCao.ToString("###,###,###")
            Me.NhietDo.Text = p_NhietDo.ToString("###,###,###.##")
            'Me.TyTrong.Value = p_TrongBe
            Me.ChieuCaoNuoc.Text = p_ChieuCaoNuoc.ToString("###,###,###")
            Me.ThoiDiem.Value = p_thoidiem
        Catch ex As Exception

        End Try

    End Sub
End Class
