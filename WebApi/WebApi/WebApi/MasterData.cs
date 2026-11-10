using System.Data;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;


namespace WebApi
{
    public class MasterData
    {

        public class TransferResponse
        {
            [JsonPropertyName("status")]
            public int Status { get; set; }

            [JsonPropertyName("error")]
            public string? Error { get; set; }

            [JsonPropertyName("path")]
            public string? token { get; set; }
            [JsonPropertyName("expried")]
            public Int16? expried { get; set; }
        }

        public class mdconnect
        {

            public string nguoidung { get; set; }
            public string matkhau { get; set; }
        }

        public static string  gettoken (string data)
        {
            DataTable dt;
            string p_User;
            string p_Pass;
            string p_SQL = ""; 
            string p_Error = "";
            string strgettoken = "";
            TransferResponse responsedt = new TransferResponse();
            try
            {
                mdconnect res = JsonConvert.DeserializeObject<mdconnect>(data);
                responsedt.Status = 500;
                responsedt.Error = "Lỗi xác thực";

                p_User = res.nguoidung.ToString();
                p_Pass = res.matkhau.ToString();
                p_Pass = WebApi.Module.mdlCryptor_Encrypt(p_User, p_Pass);
                if (p_Pass != "" && p_User != "")
                {
                    p_SQL = "select 1 as nNumber from SYS_USER where upper('user_name')=" + p_User.ToUpper() + " and ENCRYPTED_USER_PASSWORD ='" + p_Pass + "'";
                    dt = WebApi.Module.dtGetDataTable(p_SQL, ref p_Error);
                    if (dt !=null && dt.Rows.Count > 0)
                    {
                        responsedt.Status = 200;
                        responsedt.Error = "OK";

                       

                    }
                }
            }
           catch (Exception ex)
            {
                responsedt.Status = 500;
                responsedt.Error = ex.Message.ToString ();
                strgettoken = JsonConvert.SerializeObject(responsedt);
            }
            finally
            {
                
            }
            return strgettoken;

        }

    }
}
