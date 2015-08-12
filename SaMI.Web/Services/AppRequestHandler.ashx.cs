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
    public class AppRequestHandler : IHttpHandler, IRequiresSessionState
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
                else if (strResponseType == "get")
                {
                    context.Request.InputStream.Position = 0;
                    using (var inputStream = new StreamReader(context.Request.InputStream))
                    {
                        jsonString = inputStream.ReadToEnd();
                        LogData(jsonString);
                        responseText = SaMIProfileBO.GetUnSyncSaMIProfiles();
                    }
                }

                else if (strResponseType == "put")
                {
                    context.Request.InputStream.Position = 0;
                    using (var inputStream = new StreamReader(context.Request.InputStream))
                    {
                        jsonString = inputStream.ReadToEnd();
                    }

                    if (SaveData(jsonString, 1))
                    {
                        responseText = "{\"code\":\"1\",\"status\":\"200\",\"data\":\"success\"}";
                    }
                    else
                    {
                        responseText = "{\"code\":\"1\",\"status\":\"404\",\"data\":\"Invalid Request.\"}";
                    }
                }
                else
                {
                    responseText = "{\"code\":\"1\",\"status\":\"401\",\"data\":\"Unauthorized Access\"}";
                }

            }
            catch (Exception ex)
            {
                responseText = "{\"code\":\"1\",\"status\":\"400\",\"data\":\"" + ex.Message + "\"}";
            }
            finally
            {
                SendResponse(context, responseText);

            }
        }


        public void LogData(String jsonString)
        {
            using (StreamWriter _testData = new StreamWriter(HttpContext.Current.Server.MapPath("~/data.txt"), true))
            {
                String strLog = String.Empty;

                String data = jsonString.Replace("[", String.Empty);
                data = data.Replace("]", String.Empty);
                data = data.Replace("\"", String.Empty);

                String[] arrData = data.Split(',');
                foreach (String strData in arrData)
                {
                    String[] strRow = strData.Split(',');
                    foreach (String rowData in strRow)
                    {
                        string strColumnData = rowData.Replace("{", String.Empty);
                        strColumnData = strColumnData.Replace("}", String.Empty);
                        _testData.WriteLine(strColumnData);
                    }
                }
                _testData.WriteLine(data);
            }
        }

        public Boolean SaveData(String jsonString, int UserID = 1)
        {

            String data = jsonString.Replace("[", String.Empty);
            data = data.Replace("]", String.Empty);
            data = data.Replace("\"", String.Empty);
            List<SaMIProfiles> lstSaMIProfiles = new List<SaMIProfiles>();

            String[] arrData = Regex.Split(data, "},{");
            foreach (String strData in arrData)
            {
                String strRowData = strData.Replace("{", String.Empty);
                strRowData = strRowData.Replace("}", String.Empty);
                SaMIProfiles objSaMIProfiles = MapSaMIProfileDTO(strRowData);
                objSaMIProfiles.CreatedBy = UserID;
                lstSaMIProfiles.Add(objSaMIProfiles);
            }

            if (lstSaMIProfiles.Count > 0)
            {
                String strErrorMsg = SaMIProfileBO.InsertUpdateMultipleProfile(lstSaMIProfiles);
                if (strErrorMsg == string.Empty)
                {
                    return true;
                }
                else
                {
                    using (StreamWriter _testData = new StreamWriter(HttpContext.Current.Server.MapPath("~/data.txt"), true))
                    {
                        _testData.WriteLine(strErrorMsg);
                    }
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public SaMIProfiles MapSaMIProfileDTO(String data)
        {
            Boolean blnSameAsPermanent = false;

            SaMIProfiles objSaMIProfiles = new SaMIProfiles();
            String[] arrData = data.Split(',');
            foreach (String cdata in arrData)
            {
                string[] val = cdata.Split(':');
                switch (val[0])
                {
                    case "informationSource":
                        objSaMIProfiles.InformationSource = val[1];
                        break;
                    case "registrationDate":
                        String strDate = Regex.Unescape(val[1]);
                        using (StreamWriter _testData = new StreamWriter(HttpContext.Current.Server.MapPath("~/data.txt"), true))
                        {
                            _testData.WriteLine(strDate);
                        }

                        objSaMIProfiles.RegistrationDate = Convert.ToDateTime(strDate);
                        break;
                    case "district":
                        objSaMIProfiles.DistrictID = Convert.ToInt32(val[1]);
                        break;
                    case "gender":
                        objSaMIProfiles.Gender = val[1];
                        break;
                    case "fname":
                        objSaMIProfiles.FirstName = val[1];
                        break;
                    case "mname":
                        objSaMIProfiles.MiddleName = val[1];
                        break;
                    case "lname":
                        objSaMIProfiles.LastName = val[1];
                        break;
                    case "age":
                        objSaMIProfiles.AgeGroupID = Convert.ToInt32(val[1]);
                        break;
                    case "casteCaste":
                        objSaMIProfiles.CasteID = Convert.ToInt32(val[1]);
                        break;
                    case "casteEthnicity":
                        break;
                    case "isDiscriminated":
                        objSaMIProfiles.IsDiscriminated = Convert.ToInt32(val[1]);
                        break;
                    case "phone":
                        objSaMIProfiles.VisitorPhone = val[1];
                        break;
                    case "phoneFamily":
                        objSaMIProfiles.FamilyMemberPhone = val[1];
                        break;
                    case "permanentDistrict":
                        objSaMIProfiles.AddressDistrictID = Convert.ToInt32(val[1]);
                        break;
                    case "permanentVDC":
                        objSaMIProfiles.VDCID = Convert.ToInt32(val[1]);
                        break;
                    case "permanentWard":
                        objSaMIProfiles.Ward = val[1];
                        break;
                    case "permanentDetails":
                        objSaMIProfiles.Address = val[1];
                        break;
                    case "temporarySameAsPermanent":
                        if (val[1] == "true")
                            blnSameAsPermanent = true;
                        break;
                    case "temporaryDistrict":
                        if (!blnSameAsPermanent)
                            objSaMIProfiles.AddressDistrictIDTemp = Convert.ToInt32(val[1]);
                        break;
                    case "temporaryVDC":
                        if (!blnSameAsPermanent)
                            objSaMIProfiles.VDCIDTemp = Convert.ToInt32(val[1]);
                        break;
                    case "temporaryWard":
                        if (!blnSameAsPermanent)
                            objSaMIProfiles.WardTemp = val[1];
                        break;
                    case "temporaryDetails":
                        if (!blnSameAsPermanent)
                            objSaMIProfiles.AddressTemp = val[1];
                        break;
                    case "educationalStatus":
                        objSaMIProfiles.EducationalStatusID = Convert.ToInt32(val[1]);
                        break;
                    case "presentOccupation":
                        objSaMIProfiles.OccupationTypeID = Convert.ToInt32(val[1]);
                        break;
                    case "maritalStatus":
                        objSaMIProfiles.MaritalStatusID = Convert.ToInt32(val[1]);
                        break;
                    case "familyMembersA":
                        if (val[1] != "Select")
                            objSaMIProfiles.NoOfChildMale = Convert.ToInt32(val[1]);
                        break;
                    case "familyMembersB":
                        if (val[1] != "Select")
                            objSaMIProfiles.NoOfChildFemale = Convert.ToInt32(val[1]);
                        break;
                    case "familyMembersC":
                        if (val[1] != "Select")
                            objSaMIProfiles.NoOfAdultMale = Convert.ToInt32(val[1]);
                        break;
                    case "familyMembersD":
                        if (val[1] != "Select")
                            objSaMIProfiles.NoOfAdultFemale = Convert.ToInt32(val[1]);
                        break;
                    case "username":
                        break;
                    case "registrationNumber":
                        objSaMIProfiles.RegistrationNumber = val[1];
                        break;
                    case "howYouKnowIC":
                        if (val[1] != "Select")
                            objSaMIProfiles.ICKnowledgeID = Convert.ToInt32(val[1]);
                        break;
                    case "frequencyOfVisit":
                        objSaMIProfiles.FrequencyOfVisit = Convert.ToInt32(val[1]);
                        break;
                    case "reasonForVisiting":
                        objSaMIProfiles.ReasonForVisiting = Convert.ToInt32(val[1]);
                        break;
                    case "gpsLongitude":
                        try
                        {
                            objSaMIProfiles.GPSLongitude = Convert.ToDecimal(val[1]);
                        }
                        catch (Exception ex)
                        {

                        }
                        break;
                    case "gpsLatitude":
                        try
                        {
                            objSaMIProfiles.GPSLatitude = Convert.ToDecimal(val[1]);
                        }
                        catch (Exception ex)
                        {

                        }
                        break;
                    case "guid":
                        objSaMIProfiles.GUID = val[1].ToString();
                        break;
                    default:
                        break;
                }
            }

            if (blnSameAsPermanent)
            {
                objSaMIProfiles.AddressDistrictIDTemp = objSaMIProfiles.AddressDistrictID;
                objSaMIProfiles.VDCIDTemp = objSaMIProfiles.VDCID;
                objSaMIProfiles.WardTemp = objSaMIProfiles.Ward;
                objSaMIProfiles.AddressTemp = objSaMIProfiles.Address;
            }
            return objSaMIProfiles;
        }

        public void SendResponse(HttpContext context, String responseText)
        {
            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = Encoding.UTF8;
            context.Response.Write(responseText);
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void TestData()
        {
            using (StreamWriter _testData = new StreamWriter(HttpContext.Current.Server.MapPath("~/data.txt"), true))
            {
                _testData.WriteLine("flowHere");
            }
        }


    }
}