using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class EvidenceTypeDAO : BaseDAO
    {
        public EvidenceTypeDAO() : base() { }
        public EvidenceTypeDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_evidence_types";
            KeyField = "EvidenceTypeID";
        }

        public DataView SelectAll(Boolean Select)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT 0 as EvidenceTypeID, '[Select]' AS EvidenceTypeDesc " +
                       " UNION " +
                       " SELECT EvidenceTypeID, EvidenceTypeDesc FROM tbl_evidence_types " +
                      "WHERE Status <> 0";
            else
                sql = "SELECT * FROM tbl_evidence_types " +
                      "WHERE Status <> 0";
            return ExecuteQuery(sql);
        }



        public int InsertEvidenceTypes(EvidenceTypes objCaseType)
        {
            objCaseType.EvidenceTypeID = 1;
            BeginTransaction();

            try
            {
                objCaseType.EvidenceTypeID = Insert(objCaseType);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objCaseType.EvidenceTypeID = -1;
            }

            return objCaseType.EvidenceTypeID;
        }

        public int UpdateEvidenceTypes(EvidenceTypes objEvidenceTypes)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "EvidenceTypeDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objEvidenceTypes, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteEvidenceTypes(EvidenceTypes objEvidenceTypes)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objEvidenceTypes, UpdateProperties);

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
