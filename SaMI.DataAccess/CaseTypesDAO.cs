using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class CaseTypesDAO: BaseDAO
    {
        public CaseTypesDAO() : base() { }
        public CaseTypesDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_case_types";
            KeyField = "CaseTypeID";
        }

        public DataView SelectAll(Boolean Select)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT 0 as CaseTypeID, '[Select]' AS CaseTypeDesc " +
                       " UNION " +
                       " SELECT CaseTypeID, CaseTypeDesc FROM tbl_case_types " +
                      "WHERE Status <> 0";
            else
                sql = "SELECT * FROM tbl_case_types " +
                          "WHERE Status <> 0";
            return ExecuteQuery(sql);
        }


        public DataView SelectAllInCases(int CaseProfileID, Boolean Select)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT 0 as CaseID, '[Select]' AS CaseTypeDesc " +
                       " UNION " +
                       " SELECT C.CaseID, CT.CaseTypeDesc FROM tbl_cases AS C " +
                       " JOIN tbl_case_types AS CT ON CT.CaseTypeID = C.CaseTypeID " +
                       " WHERE C.CaseProfileID = " + CaseProfileID;
            else
                sql = " SELECT C.CaseID, CT.CaseTypeDesc FROM tbl_cass " +
                       " JOIN tbl_case_types AS CT ON CT.CaseTypeID = C.CaseTypeID " +
                       " WHERE C.CaseProfileID = " + CaseProfileID;
            return ExecuteQuery(sql);
        }


        public int InsertCaseTypes(CaseTypes objCaseType)
        {
            objCaseType.CaseTypeID = 1;
            BeginTransaction();

            try
            {
                objCaseType.CaseTypeID = Insert(objCaseType);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objCaseType.CaseTypeID = -1;
            }

            return objCaseType.CaseTypeID;
        }

        public int UpdateCaseTypes(CaseTypes objCaseTypes)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "CaseTypeDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objCaseTypes, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteCaseTypes(CaseTypes objCaseTypes)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objCaseTypes, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

    }
}
