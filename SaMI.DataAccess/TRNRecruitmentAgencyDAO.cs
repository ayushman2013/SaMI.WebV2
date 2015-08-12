using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DTO;
using SaMI.DBTools;
using System.Data;

namespace SaMI.DataAccess
{
  public  class TRNRecruitmentAgencyDAO:BaseDAO
    {
    public TRNRecruitmentAgencyDAO() : base() { }

    public TRNRecruitmentAgencyDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "TRNRecruitmentAgency";
            KeyField = "ID";
        }

        public DataView SelectAllRecruitmentAgency(Boolean Select = false)
        {
            String sql = "SELECT ID,RecruitmentAgency FROM TRNRecruitmentAgency WHERE Status='1'";
            if(Select)
                sql = "SELECT 0 AS ID, '[Recruitment Agency]' AS RecruitmentAgency UNION SELECT ID,RecruitmentAgency FROM TRNRecruitmentAgency WHERE Status='1'";

            return ExecuteQuery(sql);
        }

        public DataView SelectRecruitmentAgencyByID(int RecruitmentAgencyID)
        {
            String sql = "SELECT * FROM TRNRecruitmentAgency WHERE ID='" + RecruitmentAgencyID + "'";
            return ExecuteQuery(sql);
        }

        public int InsertRecruitmentAgency(TRNRecruitmentAgency objRec)
        {
            objRec.RecAgencyID = 1;
            objRec.CreatedDate = DateTime.Now;
            BeginTransaction();
            try
            {
                objRec.RecAgencyID = Insert(objRec);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objRec.RecAgencyID = -1;
            }

            return objRec.RecAgencyID;
        }

        public int UpdateRecruitmentAgency(TRNRecruitmentAgency objRec)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "RecruitmentAgency","UpdatedBy","UpdatedDate","Status" };
                rowsaffected = Update(objRec, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteRecruitmentAgency(TRNRecruitmentAgency objRec)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "UpdatedBy","UpdatedDate","Status"};
                rowsaffected = Update(objRec, UpdateProperties);

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
