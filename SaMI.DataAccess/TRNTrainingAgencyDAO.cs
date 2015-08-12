using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DBTools;
using SaMI.DTO;
using System.Data;

namespace SaMI.DataAccess
{
    public class TRNTrainingAgencyDAO : BaseDAO
    {

        public TRNTrainingAgencyDAO() : base() { }

        public TRNTrainingAgencyDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "TRNTrainingAgency";
            KeyField = "ID";
        }

        public DataView SelectAllTrainingAgency(Boolean Select = false)
        {
            String sql = "SELECT ID, TrainingAgency, Address, Phone, ContactPerson FROM TRNTrainingAgency WHERE Status='1'";
            if(Select)
            sql = "SELECT 0 AS ID, '[Training Agency]' AS TrainingAgency UNION SELECT ID,TrainingAgency FROM TRNTrainingAgency WHERE Status='1'";
            return ExecuteQuery(sql);
        }

        public DataView SelectTrainingAgencyByID(int AgencyID)
        {
            String sql = "SELECT * FROM TRNTrainingAgency WHERE ID='"+AgencyID+"'";
            return ExecuteQuery(sql);
        }

        public int InsertTrainingAgency(TRNTrainingAgency objAgency)
        {
            objAgency.AgencyID = 1;           
            objAgency.CreatedDate = DateTime.Now;
            BeginTransaction();
            try
            {
                objAgency.AgencyID = Insert(objAgency);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objAgency.AgencyID = -1;
            }

            return objAgency.AgencyID;
        }

        public int UpdateTrainingAgency(TRNTrainingAgency objAgency)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "TrainingAgency","Address","Phone","ContactPerson","UpdatedBy","UpdatedDate","Status" };
                rowsaffected = Update(objAgency, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteTrainingAgency(TRNTrainingAgency objAgency)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objAgency, UpdateProperties);

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
