using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
    public class UserBO
    {
        public static DataView GetAll(int DistrictID = 0, int SaMIOrganizationID = 0, int PartnerID = 0, int SkillPartnerID = 0)
        {
            String strFilter = "";

            if (DistrictID > 0)
                strFilter += " AND U.DistrictID = " + DistrictID;
            if (SaMIOrganizationID > 0)
                strFilter += " AND U.SaMIOrganizationID = " + SaMIOrganizationID;
            if (PartnerID > 0)
                strFilter += " AND U.PartnerID = " + PartnerID;
            if (SkillPartnerID > 0)
                strFilter += " AND U.SkillPartnerID = " + SkillPartnerID;

            return new UserDAO().SelectAll(strFilter);

        }

        public static DataView GetUserInfoByUserNamePassword(String UserName, String Password)
        {
            return new UserDAO().SelectUserInfoByUserNamePassword(UserName, Password);
        }

        public static DataView GetUsers(Boolean Select = false)
        {
            return new UserDAO().SelectUsers(Select);

        }

        public static DataView GetByDistrictID(int DistrictID)
        {
            String strFilter = "";
            if (DistrictID > 0)
                strFilter = " AND U.DistrictID = '" + DistrictID + "'";
            return new UserDAO().SelectAll(strFilter);
        }

        public static Users GetUser(int userID)
        {
            Users objUsers = new Users();
            return (Users)(new UserDAO().FillDTO(objUsers, "UserID=" + userID));

        }
        public static Boolean CheckLogin(string username, string password)
        {
            Boolean blnLogin = false;
            DataView dv = new UserDAO().CheckLogin(username, AppCommonBO.EncodeUserPassword(password));
            if (dv.Table.Rows.Count > 0)
                blnLogin = true;

            return blnLogin;
        }



        public static AppUserDetails SetAppUserDetails(string username)
        {
            string sql = "SELECT U.UserID, U.UserName, U.DistrictID, U.PartnerID, D.DistrictName, UT.UserTypeCode, U.FullName, U.SaMIOrganizationID " +
                            "FROM tbl_users AS U " +
                            "JOIN tbl_districts AS D ON D.DistrictID = U.DistrictID " +
                            "JOIN tbl_user_types UT ON UT.UserTypeID = U.UserTypeID " +
                            "LEFT JOIN tbl_stakeholders SH ON SH.StakeHolderID = U.PartnerID " +
                            "LEFT JOIN tbl_SaMI_organizations SO ON SO.SaMIOrganizationID = U.SaMIOrganizationID " +
                            "WHERE UserName = '" + username + "'";
            DataView dv = new UserDAO().ExecuteQuery(sql);

            AppUserDetails objAppUserDetails = null;

            if (dv.Table.Rows.Count > 0)
            {
                objAppUserDetails = new AppUserDetails();
                objAppUserDetails.UserID = (int)dv.Table.Rows[0]["UserID"];
                objAppUserDetails.DistrictID = (int)dv.Table.Rows[0]["DistrictID"];
                objAppUserDetails.PartnerID = (int)dv.Table.Rows[0]["PartnerID"];
                objAppUserDetails.UserType = dv.Table.Rows[0]["UserTypeCode"].ToString();
                objAppUserDetails.FullName = dv.Table.Rows[0]["FullName"].ToString();
                objAppUserDetails.DistrictName = dv.Table.Rows[0]["DistrictName"].ToString();
                if (dv.Table.Rows[0]["SaMIOrganizationID"] != DBNull.Value)
                    objAppUserDetails.SaMIOrganizationID = (int)dv.Table.Rows[0]["SaMIOrganizationID"];
                else
                    objAppUserDetails.SaMIOrganizationID = 0;
            }

            return objAppUserDetails;
        }


        public static void ResetUserDetails()
        { }


        public static int ChangePassword(Users objUsers)
        {
            objUsers.Password = AppCommonBO.EncodeUserPassword(objUsers.Password);
            return new UserDAO().ChangePassword(objUsers);
        }

        public static int InsertUser(Users objUsers)
        {
            objUsers.Password = AppCommonBO.EncodeUserPassword(objUsers.Password);
            return new UserDAO().InsertUser(objUsers);
        }

        public static int UpdateUser(Users objUsers)
        {
            //if(!String.IsNullOrEmpty(objUsers.Password))
               // objUsers.Password = AppCommonBO.EncodeUserPassword(objUsers.Password);
            return new UserDAO().UpdateUser(objUsers);
        }

        public static Boolean IsUserExists(string UserName)
        {
            Boolean blnExists = false;

            DataView dv = new UserDAO().Select("UserName", "", "UserName = '" + UserName + "'");

            if (dv.Count > 0)
                blnExists = true;

            return blnExists;
        }

        public static int DeleteUser(int UserID)
        {
            return new UserDAO().Delete("UserID=" + UserID);
        }

        public static DataView GetUsersIDByOrganization(int OrganizationID)
        {
            return new UserDAO().SelectUsersIDByOrganization(OrganizationID);

        }

        public static DataView GetAllUsersIDByOrganizationID(int OrganizationID)
        {
            return new UserDAO().SelectAllUsersIDByOrganizationID(OrganizationID);

        }

        public static Boolean CheckUserAuthentication(string username, string password)
        {
            Boolean blnLogin = false;
            DataView dv = new UserDAO().CheckUserAuthentication(username, password);
            if (dv.Table.Rows.Count > 0)
                blnLogin = true;

            return blnLogin;
        }

        public static DataView SelectByDistrictID(int DistrictID, String Select)
        {
            return new UserDAO().SelectByDistrictID(DistrictID, Select);
        }

        public static DataView SelectByUserId(int UserId)
        {
            return new UserDAO().SelectByUserId(UserId);
        }

    }
}
