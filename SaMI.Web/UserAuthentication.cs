using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

using SaMI.Business;
using SaMI.DTO;

namespace SaMI.Web
{
    public class UserAuthentication
    {

        public static int GetUserId(System.Web.UI.Page passPage)
        {
            if (passPage.Session[AppSettings.GetUserSessionName()] != null)
            {
                SaMI.DTO.AppUserDetails objAppUserDetails = (SaMI.DTO.AppUserDetails)passPage.Session[AppSettings.GetUserSessionName()];

                return objAppUserDetails.UserID;
            }

            return -1;
        }

        public static string GetUserType(System.Web.UI.Page passPage)
        {
            if (passPage.Session[AppSettings.GetUserSessionName()] != null)
            {
                SaMI.DTO.AppUserDetails objAppUserDetails = (SaMI.DTO.AppUserDetails)passPage.Session[AppSettings.GetUserSessionName()];

                return objAppUserDetails.UserType;
            }

            return string.Empty;
        }

        public static string GetUserFullName(System.Web.UI.Page passPage)
        {
            if (passPage.Session[AppSettings.GetUserSessionName()] != null)
            {
                SaMI.DTO.AppUserDetails objAppUserDetails = (SaMI.DTO.AppUserDetails)passPage.Session[AppSettings.GetUserSessionName()];

                return objAppUserDetails.FullName;
            }

            return string.Empty;
        }

        public static string GetUserDistrictName(System.Web.UI.Page passPage)
        {
            if (passPage.Session[AppSettings.GetUserSessionName()] != null)
            {
                SaMI.DTO.AppUserDetails objAppUserDetails = (SaMI.DTO.AppUserDetails)passPage.Session[AppSettings.GetUserSessionName()];

                return objAppUserDetails.DistrictName;
            }

            return string.Empty;
        }

        public static int GetUserTypeId(System.Web.UI.Page passPage)
        {
            if (passPage.Session[AppSettings.GetUserSessionName()] != null)
            {
                SaMI.DTO.AppUserDetails objAppUserDetails = (SaMI.DTO.AppUserDetails)passPage.Session[AppSettings.GetUserSessionName()];

                return objAppUserDetails.UserTypeID;
            }

            return -1;
        }

        public static int GetDistrictId(System.Web.UI.Page passPage)
        {
            if (passPage.Session[AppSettings.GetUserSessionName()] != null)
            {
                SaMI.DTO.AppUserDetails objAppUserDetails = (SaMI.DTO.AppUserDetails)passPage.Session[AppSettings.GetUserSessionName()];

                return objAppUserDetails.DistrictID;
            }

            return -1;
        }

        public static int GetPartnerId(System.Web.UI.Page passPage)
        {
            if (passPage.Session[AppSettings.GetUserSessionName()] != null)
            {
                SaMI.DTO.AppUserDetails objAppUserDetails = (SaMI.DTO.AppUserDetails)passPage.Session[AppSettings.GetUserSessionName()];

                return objAppUserDetails.PartnerID;
            }

            return -1;
        }

        public static int GetSaMIOrganizationId(System.Web.UI.Page passPage)
        {
            if (passPage.Session[AppSettings.GetUserSessionName()] != null)
            {
                SaMI.DTO.AppUserDetails objAppUserDetails = (SaMI.DTO.AppUserDetails)passPage.Session[AppSettings.GetUserSessionName()];

                return objAppUserDetails.SaMIOrganizationID;
            }

            return -1;
        }

        public static void SetSession(System.Web.UI.Page page, string sessionName, object obj)
        {
            page.Session[sessionName] = obj;
        }

        public static void DestroySession(System.Web.UI.Page page, string sessionName)
        {
            page.Session[sessionName] = null;
        }

        public static string GetModule(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                string[] directory = path.Split('/');

                if (directory.Length > 0)
                {
                    if (directory.Length == 1) return "Root";

                    if (!string.IsNullOrEmpty(directory[directory.Length - 2]))
                    {

                        string module = directory[directory.Length - 2];

                        string temp = "/" + module + "/";
                        if (temp == System.Configuration.ConfigurationManager.AppSettings.Get("BaseURL").ToString())
                            return "Root";
                        else
                            return char.ToUpper(module[0]) + module.Substring(1);
                    }
                    else
                    {
                        return "Root";
                    }

                }
            }

            return string.Empty;

        }

        public static Boolean CheckPermission(int SaMIProfileID, System.Web.UI.Page page )
        {
            Boolean valid = false;
            String UserType = GetUserType(page);

            switch (UserType)
            {
                case "USER":
                    valid = SaMIProfileBO.CheckSaMIProfileByDistrict(GetDistrictId(page), SaMIProfileID);
                    break;
                case "PARTNER":
                    valid = CaseBO.CheckCaseBySaMIProfileID(SaMIProfileID, GetPartnerId(page)) || SaMIProfileBO.CheckSaMIProfileByUser(GetUserId(page), SaMIProfileID);
                    break;
                case "CASEUSR":
                case "ADMIN":
                    valid = true;
                    break;
                default:
                    break;
            }
            
            return valid;
        }

        public static string base64Decode(string data)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();

                byte[] todecode_byte = Convert.FromBase64String(data);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception e)
            {
                return "";
            }
        }
       
    }
}