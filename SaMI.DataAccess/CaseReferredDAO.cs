using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DBTools;
using SaMI.DTO;
using System.Data;
using System.Collections;

namespace SaMI.DataAccess
{
   public class CaseReferredDAO : BaseDAO
    {
        public CaseReferredDAO() : base() { }
        public CaseReferredDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }


        public override void Initilize()
        {
            Table = "tbl_case_referred";
            KeyField = "CaseReferredID";
        }

        public int InsertCaseReferred(CaseReferred objCaseReferred)
        {
            objCaseReferred.CaseReferredID = 1;
            BeginTransaction();

            try
            {
                objCaseReferred.CaseReferredID = Insert(objCaseReferred);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objCaseReferred.CaseReferredID = -1;
            }

            return objCaseReferred.CaseReferredID;
        }

        public int UpdateCaseReferred(CaseReferred objCaseReferred)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "SaMIProfileID", "ReferStatus", "UpdatedBy", "UpdatedDate" };
                rowsaffected = Update(objCaseReferred, UpdateProperties);

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
            String sql = "SELECT * FROM tbl_case_referred ";
            return ExecuteQuery(sql);
        }

        public DataView GetStatus(int SaMIProfileID)
        {
            String sql = "SELECT ReferStatus FROM tbl_case_referred WHERE SaMIProfileID = " + SaMIProfileID;
            return ExecuteQuery(sql);
        }

        public int DeleteCaseReferred(int SaMIProfileID)
        {
            String sql = "DELETE FROM tbl_case_referred WHERE SaMIProfileID = " + SaMIProfileID;
            return ExecuteNonQuery(sql);
        }

        public DataView SelectReferredProfile(int SaMIProfileID)
        {
            string sql = "SELECT CR.SaMIProfileID, SP.FirstName, SP.MiddleName, SP.LastName, SP.DistrictID " +
                        "FROM tbl_case_referred CR " +
                        "JOIN tbl_SaMI_profiles SP ON SP.SaMIProfileID = CR.SaMIProfileID " +
                        "WHERE SP.SaMIProfileID = " + SaMIProfileID;
            return ExecuteQuery(sql);
        }

        public DataView SelectRecruitmentList(string strName)
        {
            String sql = "SELECT SP.SaMIProfileID, SP.SaMIProfileNumber, " +
                         "SP.FirstName, SP.MiddleName, SP.LastName, " +
                         "D.DistrictName, U.UserName, SP.CreatedDate " +
                         "FROM tbl_SaMI_profiles AS SP " +
                         "JOIN tbl_districts as D ON D.DistrictID = SP.DistrictID " +
                         "JOIN tbl_users U ON U.UserID = SP.CreatedBy " +
                         "JOIN tbl_foreign_employment_status FES ON FES.SaMIProfileID = SP.SaMIProfileID " +
                         "WHERE FES.ReferToCase = 1 ";


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

            sql += "ORDER BY SP.CreatedDate ";
            return ExecuteQuery(sql);
        }

        public DataView CountRecruitmentList(string strName)
        {
            String sql = "SELECT Count(SP.SaMIProfileID) AS DataCount " +
                         "FROM tbl_SaMI_profiles AS SP " +
                         "JOIN tbl_districts as D ON D.DistrictID = SP.DistrictID " +
                         "JOIN tbl_users U ON U.UserID = SP.CreatedBy " +
                         "JOIN tbl_foreign_employment_status FES ON FES.SaMIProfileID = SP.SaMIProfileID " +
                         "WHERE FES.ReferToCase = 1 ";

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
        public DataView GetCaseReferredIDForSync(String CreatedBy)
        {
            String sql = "SELECT CaseReferredID FROM tbl_case_referred WHERE SyncStatus='0' AND  " + CreatedBy;
            return ExecuteQuery(sql);
        }
    }
}
