using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class TRNRecruitmentListDAO : BaseDAO
    {
        public TRNRecruitmentListDAO() : base() { }
        public TRNRecruitmentListDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "TRNRecruitmentList";
            KeyField = "RecruitmentID";
        }

        public int InsertRecruitmentList(TRNRecruitmentList objRecruitmentList)
        {
            objRecruitmentList.RecruitmentID = 1;
            BeginTransaction();

            try
            {
                objRecruitmentList.RecruitmentID = Insert(objRecruitmentList);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objRecruitmentList.RecruitmentID = -1;
            }

            return objRecruitmentList.RecruitmentID;
        }
        public int UpdateRecruitmentList(TRNRecruitmentList objRecruitmentList)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "OrganizationID", "SaMIProfileID", "Status", "UpdatedBy", "UpdatedDate" };
                rowsaffected = Update(objRecruitmentList, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView SelectAll()
        {
            String sql = "SELECT * FROM TRNRecruitmentList ";
            return ExecuteQuery(sql);
        }

        public DataView SelectRecruitmentList(string strName)
        {
            String sql = "SELECT SO.SaMIOrganizationName, SP.SaMIProfileID, SP.SaMIProfileNumber, " +
                         "CASE SP.MiddleName " +
                         "WHEN '' THEN " +
                         "(SP.FirstName + ' ' + SP.LastName) " +
                         "ELSE " +
                         "(SP.FirstName + ' ' + SP.MiddleName + ' ' + SP.LastName) END AS Name, " +
                         "CASE Gender  WHEN 'M' Then 'Male'  ELSE 'Female'  END AS Gender, " +
                         "E.EthnicityName, SP.VisitorPhone, D.DistrictName " +
                         "FROM tbl_SaMI_profiles AS SP " +
                         "JOIN tbl_ethnicity as E ON E.EthnicityID = SP.EthnicityID " +
                         "JOIN tbl_districts as D ON D.DistrictID = SP.DistrictID " +
                         "JOIN tbl_users U ON U.UserID = SP.CreatedBy " +
                         "LEFT JOIN tbl_SaMI_organizations SO ON SO.SaMIOrganizationID = U.SaMIOrganizationID " +
                         "JOIN tbl_foreign_employment_status FES ON FES.SaMIProfileID = SP.SaMIProfileID " +
                         "WHERE FES.ReferToFSkill = 1 ";


            if (strName != string.Empty)
            {
                String[] arrName = strName.Split(' ');

                if (arrName.Length == 1)
                {
                    sql += " AND (LOWER(SP.FirstName) LIKE '" + arrName[0].ToLower() + "%' OR LOWER(SP.LastName) LIKE'" + arrName[0].ToLower() + "%')";
                }
                else if (arrName.Length == 2)
                {
                    sql += " AND LOWER(SP.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                    sql += " AND (LOWER(SP.LastName) LIKE '" + arrName[1].ToLower() + "%' OR LOWER(SP.MiddleName) LIKE'" + arrName[1].ToLower() + "%')";
                }
                else if (arrName.Length == 3)
                {
                    sql += " AND LOWER(SP.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                    sql += " AND LOWER(SP.MiddleName) LIKE '" + arrName[1].ToLower() + "%'";
                    sql += " AND LOWER(SP.LastName) LIKE '" + arrName[2].ToLower() + "%'";
                }
            }

            sql += "ORDER BY SO.SaMIOrganizationID ";
            return ExecuteQuery(sql);
        }

        public DataView CountRecruitmentList(string strName)
        {
            String sql = "SELECT Count(SP.SaMIProfileID) AS DataCount " +
                         "FROM tbl_SaMI_profiles AS SP " +
                         "JOIN tbl_ethnicity as E ON E.EthnicityID = SP.EthnicityID " +
                         "JOIN tbl_districts as D ON D.DistrictID = SP.DistrictID " +
                         "JOIN tbl_users U ON U.UserID = SP.CreatedBy " +
                         "LEFT JOIN tbl_SaMI_organizations SO ON SO.SaMIOrganizationID = U.SaMIOrganizationID " +
                         "JOIN tbl_foreign_employment_status FES ON FES.SaMIProfileID = SP.SaMIProfileID " +
                         "WHERE FES.ReferToFSkill = 1 ";

            if (strName != string.Empty)
            {
                String[] arrName = strName.Split(' ');

                if (arrName.Length == 1)
                {
                    sql += " AND (LOWER(SP.FirstName) LIKE '" + arrName[0].ToLower() + "%' OR LOWER(SP.LastName) LIKE'" + arrName[0].ToLower() + "%')";
                }
                else if (arrName.Length == 2)
                {
                    sql += " AND LOWER(SP.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                    sql += " AND (LOWER(SP.LastName) LIKE '" + arrName[1].ToLower() + "%' OR LOWER(SP.MiddleName) LIKE'" + arrName[1].ToLower() + "%')";
                }
                else if (arrName.Length == 3)
                {
                    sql += " AND LOWER(SP.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                    sql += " AND LOWER(SP.MiddleName) LIKE '" + arrName[1].ToLower() + "%'";
                    sql += " AND LOWER(SP.LastName) LIKE '" + arrName[2].ToLower() + "%'";
                }
            }
            return ExecuteQuery(sql);
        }

        public DataView GetStatus(int SaMIProfileID)
        {
            String sql = "SELECT ReferStatus FROM TRNRecruitmentList WHERE SaMIProfileID = " + SaMIProfileID ;
            return ExecuteQuery(sql);
        }

        public int DeleteRecruitmentList(int SaMIProfileID)
        {
            String sql = "DELETE FROM TRNRecruitmentList WHERE SaMIProfileID = " + SaMIProfileID;
            return ExecuteNonQuery(sql);
        }

        public DataView SelectReferredProfile(int SaMIProfileID)
        {
            string sql = "SELECT RL.SaMIProfileID, CASE SP.MiddleName WHEN '' THEN SP.FirstName " +
                        "ELSE (SP.FirstName + ' ' + SP.MiddleName) END AS FirstName, SP.LastName, " +
                        "CASE SP.Gender  WHEN 'M' Then 'Male'  ELSE 'Female'  END AS Gender, " +
                        "M.MaritalStatusDesc, SP.EthnicityID, SP.DistrictID, " +
                        "SP.Ward, SP.VisitorPhone, SP.FamilyMemberPhone " +
                        "FROM TRNRecruitmentList RL " +
                        "JOIN tbl_SaMI_profiles SP ON SP.SaMIProfileID = RL.SaMIProfileID " +
                        "JOIN tbl_marital_status M ON M.MaritalStatusID = SP.MaritalStatusID " +
                        "JOIN tbl_ethnicity E ON E.EthnicityID = SP.EthnicityID " +
                        "WHERE SP.SaMIProfileID = " + SaMIProfileID;
            return ExecuteQuery(sql);
        }

        public DataView GetTRNRecruitmentListIDForSync(String CreatedBy)
        {
            String sql = "SELECT RecruitmentID FROM TRNRecruitmentList WHERE SyncStatus='0' AND  " + CreatedBy;
            return ExecuteQuery(sql);
        }


    }
}
