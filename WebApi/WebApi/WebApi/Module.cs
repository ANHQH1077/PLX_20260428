using System.Data;

using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Xml;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System;
using System.Security.Cryptography;
using System.Text;

//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Net.NetworkInformation;

namespace WebApi
{
    public class Module
    {
        public static class Globals
        {
            public static SqlConnection conn;
            public static string g_PathXML = Environment.CurrentDirectory + @"\Config.xml";

            public static IConfigurationRoot g_Connect;
            public static string g_ConnectString;
            public static string g_RedirectURL = "https://localhost:44334/";


        }

        public static string  createtoken()
        {
            var builder = WebApplication.CreateBuilder(Array.Empty<string>());

            // 1. Đọc thông tin cấu hình từ appsettings.json
            var jwtSecretKey = builder.Configuration["JwtSettings:SecretKey"] ?? "default_secret_key_long_enough";
            var issuer = builder.Configuration["JwtSettings:Issuer"] ?? "JwtAuthApi";
            var audience = builder.Configuration["JwtSettings:Audience"] ?? "JwtAuthUsers";

            // Tạo JWT Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(jwtSecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {              
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return "";
        }


        public static string mdlCryptor_Encrypt(string nguoidung, string matkhau)
        {
            string returnvalue="";
            using var aes = Rijndael.Create();
            using var hashAes = MD5.Create();

            try
            {
                using (var md5Hasher = MD5.Create())
                {
                    var encoder = Encoding.UTF8; // Hoặc Encoding.ASCII tùy theo code cũ của bạn
                    byte[] p_PassStr_Arr = md5Hasher.ComputeHash(encoder.GetBytes(matkhau));
                    returnvalue  = Convert.ToBase64String(p_PassStr_Arr);                    
                }
                return returnvalue;
            }
            catch (Exception)
            {
                return "";
            }
        }


        public static void GetCnnString()
        {

            //string path = Environment.CurrentDirectory +  @"\Config.xml";
            string sErr;
            string p_DB;
            string p_Port;
            string p_User;
            string p_Pass;
            string p_Server;
            string p_Timeout;
            XmlNode node;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Globals.g_PathXML);
                if (doc.DocumentElement != null)
                {
                    node = doc.DocumentElement.SelectSingleNode("/Config/DB_NAME");
                    p_DB = node.InnerText.ToString();
                    node = doc.DocumentElement.SelectSingleNode("/Config/DB_PORT");
                    p_Port = node.InnerText.ToString();
                    node = doc.DocumentElement.SelectSingleNode("/Config/DB_USER");
                    p_User = node.InnerText.ToString();
                    node = doc.DocumentElement.SelectSingleNode("/Config/DB_PASS");
                    p_Pass = node.InnerText.ToString();
                    node = doc.DocumentElement.SelectSingleNode("/Config/DB_IPADDRESS");
                    p_Server = node.InnerText.ToString();
                    node = doc.DocumentElement.SelectSingleNode("/Config/TIMEOUT");
                    p_Timeout = node.InnerText.ToString();
                    if (p_Timeout == "")
                    {
                        p_Timeout = "200";
                    }
                    if (p_Server != "")
                    {
                        if (p_Port == "")
                        {
                            Globals.g_ConnectString = "Provider=SQLOLEDB;Data Source=" + p_Server + ";Persist Security Info=True;User ID=" +
                                    p_User + ";Password=" + p_Pass + ";Initial Catalog=" + p_DB + ";Connect Timeout=" + p_Timeout;
                        }
                        else
                        {

                            Globals.g_ConnectString = "Provider=SQLOLEDB;Data Source=" + p_Server + "," + p_Port + ";Persist Security Info=True;User ID=" +
                                    p_User + ";Password=" + p_Pass + ";Initial Catalog=" + p_DB + ";Connect Timeout=" + p_Timeout;
                            Globals.g_ConnectString = "server=" + p_Server + "," + p_Port + "; user id= " + p_User + ";password=" + p_Pass + ";Persist Security Info=False;database=" + p_DB + ";Encrypt=False"; // + "; Port=" + p_Port;
                        }


                    }

                }
                Globals.conn = new SqlConnection(Globals.g_ConnectString);
                Globals.conn.Open();
            }

            catch (Exception Ex)
            {
                sErr = Ex.Message;

            }
        }

        public static DataTable dtGetDataTable(string sSQL, ref string sErr)
        {
            DataTable dt;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            try
            {
                sErr = "";
                if (Globals.conn == null)
                {
                    GetCnnString();
                }
                if (Globals.conn.State == ConnectionState.Closed)
                {
                    GetCnnString();
                }
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Globals.conn;
                reader = cmd.ExecuteReader();
                // Data is accessible through the DataReader object here.
                dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
            catch (Exception Ex)
            {
                sErr = Ex.Message;
                return null;
            }

        }
        public static void ExecString(string sSQL, ref string sErr)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                sErr = "";
                if (Globals.conn == null)
                {
                    GetCnnString();
                }
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Globals.conn;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                sErr = Ex.Message;
            }

        }

    }


}
