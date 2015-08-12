using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;
using System.Text;
using System.Reflection;
using System.Web.SessionState;
using System.Text.RegularExpressions;

using System.Data;
using SaMI.DTO;
using SaMI.Business;
using System.Collections.Specialized;

namespace SaMI.Web.Services
{
    /// <summary>
    /// Summary description for testHandler
    /// </summary>
    public class testHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var jsonSerializer = new JavaScriptSerializer();
            var jsonString = String.Empty;
            string responseText = String.Empty;

            try
            {
                String strAuthorization = context.Request.Headers.Get("Authorization");
                String strResponseType = context.Request.Headers.Get("response-type");
                int UserID = AuthenticateUser(strAuthorization);

                context.Response.Write(UserID);

            if (strResponseType == "authentication")
                {
                    if (UserID > 0)
                    {
                        responseText = "{\"code\":\"1\",\"status\":\"200\",\"data\":\"success\"}";
                       
                    }
                    else
                    {
                        responseText = "{\"code\":\"1\",\"status\":\"401\",\"data\":\"Unauthorized Access\"}";
                    }
                }

                //else
                //{

                //    if (UserID > 0)
                //    {
                //        context.Request.InputStream.Position = 0;
                //        using (var inputStream = new StreamReader(context.Request.InputStream))
                //        {
                //            jsonString = inputStream.ReadToEnd();
                //        }

                //        if (SaveData(jsonString, UserID))
                //        {
                //            responseText = "{\"code\":\"1\",\"status\":\"200\",\"data\":\"success\"}";
                //        }
                //        else
                //        {
                //            responseText = "{\"code\":\"1\",\"status\":\"404\",\"data\":\"Invalid Request.\"}";
                //        }
                //    }
                //    else
                //    {
                //        responseText = "{\"code\":\"1\",\"status\":\"401\",\"data\":\"Unauthorized Access\"}";
                //    }
                //}
                
            }
            catch (Exception ex)
            {
                responseText = "{\"code\":\"1\",\"status\":\"400\",\"data\":\"" + ex.Message + "\"}";
            }
            finally
            {
                //SendResponse(context, responseText);

            }

            //string username = userName();
            //context.Response.Write(username);
        }

        public int AuthenticateUser(String strAuthorization)
        {
            int UserID = 0;
            strAuthorization = UserAuthentication.base64Decode(strAuthorization);
            String[] arr = strAuthorization.Split(':');
            if (arr.Length > 1)
            {
                if (UserBO.CheckLogin(arr[0], arr[1]))
                    return AppCommonBO.GetOptionValue(arr[0], "UserName", "UserID", "tbl_users");
            }

            return UserID;
        }

        public string userName()
        {
           DataView dv = UserBO.GetAll();
           string username = dv.Table.Rows[0]["UserName"].ToString();
           return username;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}