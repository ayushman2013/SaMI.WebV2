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
    public class RequestHandler : IHttpHandler, IRequiresSessionState
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

                else
                {

                    if (UserID > 0)
                    {
                        context.Request.InputStream.Position = 0;
                        using (var inputStream = new StreamReader(context.Request.InputStream))
                        {
                            jsonString = inputStream.ReadToEnd();
                        }

                        if (SaveData(jsonString, UserID))
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

        public Boolean SaveData(String jsonString, int UserID)
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
                String strErrorMsg = SaMIProfileBO.InsertMultipleProfile(lstSaMIProfiles);
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
                        objSaMIProfiles.DistrictID = AppCommonBO.GetOptionValue(val[1], "DistrictName", "DistrictID", "tbl_districts");
                        break;
                    case "gender":
                        if (val[1] == "Male")
                            objSaMIProfiles.Gender = "M";
                        else
                            objSaMIProfiles.Gender = "F";
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
                        objSaMIProfiles.AgeGroupID = AppCommonBO.GetOptionValue(val[1], "AgeGroupDesc", "AgeGroupID", "tbl_age_groups");
                        break;
                    case "casteCaste":
                        objSaMIProfiles.CasteID = AppCommonBO.GetOptionValue(val[1], "CasteName", "CasteID", "tbl_caste");
                        break;
                    case "casteEthnicity":
                        break;
                    case "isDiscriminated":
                        if (val[1] == "true")
                            objSaMIProfiles.IsDiscriminated = 1;
                        else
                            objSaMIProfiles.IsDiscriminated = 0;
                        break;                    
                    case "phone":
                        objSaMIProfiles.VisitorPhone = val[1];
                        break;
                    case "phoneFamily":
                        objSaMIProfiles.FamilyMemberPhone = val[1];
                        break;
                    case "permanentDistrict":
                        objSaMIProfiles.AddressDistrictID = AppCommonBO.GetOptionValue(val[1], "DistrictName", "DistrictID", "tbl_districts");
                        break;
                    case "permanentVDC":
                        objSaMIProfiles.VDCID = AppCommonBO.GetOptionValue(val[1], "VDCName", "VDCID", "tbl_VDC");
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
                        if(!blnSameAsPermanent)
                            objSaMIProfiles.AddressDistrictIDTemp = AppCommonBO.GetOptionValue(val[1], "DistrictName", "DistrictID", "tbl_districts");
                        break;
                    case "temporaryVDC":
                        if (!blnSameAsPermanent)
                            objSaMIProfiles.VDCIDTemp = AppCommonBO.GetOptionValue(val[1], "VDCName", "VDCID", "tbl_VDC");
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
                        objSaMIProfiles.EducationalStatusID = AppCommonBO.GetOptionValue(val[1], "EducationalStatusDesc", "EducationalStatusID", "tbl_educational_status");
                        break;
                    case "presentOccupation":
                        objSaMIProfiles.OccupationTypeID = AppCommonBO.GetOptionValue(val[1], "OccupationTypeDesc", "OccupationTypeID", "tbl_occupation_types");
                        break;
                    case "maritalStatus":
                        objSaMIProfiles.MaritalStatusID = AppCommonBO.GetOptionValue(val[1], "MaritalStatusDesc", "MaritalStatusID", "tbl_marital_status");
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
                            objSaMIProfiles.ICKnowledgeID = AppCommonBO.GetOptionValue(val[1], "ICKnowledgeDesc", "ICKnowledgeID", "tbl_ic_knowledges");
                        break;
                    case "frequencyOfVisit":
                        if (val[1] == "Once")
                            objSaMIProfiles.FrequencyOfVisit = 1;
                        else
                            objSaMIProfiles.FrequencyOfVisit = 2;
                        break;
                    case "reasonForVisiting":
                        if (val[1] == "General Information")
                            objSaMIProfiles.ReasonForVisiting = 1;
                        else
                            objSaMIProfiles.ReasonForVisiting = 2;
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
                if(UserBO.CheckLogin(arr[0], arr[1]))
                    return AppCommonBO.GetOptionValue(arr[0], "UserName", "UserID", "tbl_users");
            }

            return UserID;
        }

        public void TestHeader()
        {
            //NameValueCollection headers = context.Request.Headers.get;
            //for (int i = 0; i < headers.Count; i++)
            //{
            //    string key = headers.GetKey(i);
            //    string value = headers.Get(i);
            //    string test = key + " = " + value + "<br/>";
            //    using (StreamWriter _testData = new StreamWriter(HttpContext.Current.Server.MapPath("~/data.txt"), true))
            //    {
            //        _testData.WriteLine(test);
            //    }
            //}


            //LogData(jsonString);

            /*
            var emplList = jsonSerializer.Deserialize<List<Employee>>(jsonString);
            var resp = String.Empty;

            foreach (var emp in emplList)
            {
                resp += emp.name + " \\ ";
            }
             * 
             *  StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");            
            //jsonBuilder.Append(",");

               
            jsonBuilder.Append("\"" + "code" + "\":" + "1,");
            jsonBuilder.Append("\"" + "status" + "\":" + "200");
               
            jsonBuilder.Append("}");

            String test = jsonSerializer.Serialize(resp);
            */
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