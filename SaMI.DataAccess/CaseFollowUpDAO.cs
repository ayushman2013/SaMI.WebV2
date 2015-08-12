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
    public class CaseFollowUpDAO : BaseDAO
    {
         public CaseFollowUpDAO() : base() { }
         public CaseFollowUpDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }


        public override void Initilize()
        {
            Table = "tbl_case_follow_up";
            KeyField = "CaseFollowUpID";
        }

        public DataView SelectAll(int SaMIProfileID)
        {
            String sql = "SELECT * FROM tbl_case_follow_up WHERE SaMIProfileID = " + SaMIProfileID;
            return ExecuteQuery(sql);
        }

        public DataView SelectCustom(int CaseProfileID)
        {
            String sql = "SELECT CF.CaseFollowUpID, " +
                         "CONVERT(varchar(10), CF.FollowUpDate, 111) AS FollowUpDate, " +
                         "CT.CaseTypeDesc, CF.Description " +
                         "FROM tbl_case_follow_up AS CF " +
                         "JOIN tbl_cases AS C " +
                         "  ON C.CaseID = CF.CaseID " +   
                         "JOIN tbl_case_types AS CT " +
                         "  ON CT.CaseTypeID = C.CaseTypeID " +                         
                         "WHERE C.CaseProfileID = " + CaseProfileID;
            return ExecuteQuery(sql);
        }

        public int InsertCaseFollowUp(CaseFollowUp objCaseFollowUp)
        {
            objCaseFollowUp.CaseFollowUpID = 1;
            BeginTransaction();

            try
            {
                objCaseFollowUp.CaseFollowUpID = Insert(objCaseFollowUp);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objCaseFollowUp.CaseFollowUpID = -1;
            }

            return objCaseFollowUp.CaseFollowUpID;
        }

        public int UpdateCaseFollowUp(CaseFollowUp objCaseFollowUp)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "FollowUpDate", "CaseID", "Description"
                                                            , "UpdatedBy", "UpdatedDate"
                                                            };
                rowsaffected = Update(objCaseFollowUp, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView SelectCaseFollowUpUpdateRemider(int Frequency, int DistrictID, int PartnerID)
        {
            ArrayList paramField = new ArrayList { "@Frequency", "@PartnerID", "@DistrictID" };
            ArrayList paramValue = new ArrayList { Frequency, PartnerID, DistrictID };
            return DBHelper.ExecuteStoredProc("sp_GetCaseFollowUpUpdateReminder", paramField, paramValue);
        }
    }
}
