using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DBTools;
using SaMI.DTO;
using System.Data;

namespace SaMI.DataAccess
{
    public class TRNTrainingEventDAO : BaseDAO
    {
        public TRNTrainingEventDAO() : base() { }

        public TRNTrainingEventDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "TRNTrainingEvent";
            KeyField = "ID";
        }

        public DataView SelectAllTrainingEvent(Boolean Select = false, String EventID = "", int TradeID= 0, int TrainingAgencyID=0)
        {
            String sql = "SELECT TE.ID, TA.TrainingAgency, T.TradeName, TE.EventID, TE.Batch, TE.StartDate, TE.EndDate, " +
                        "CASE TE.CostSharing WHEN 1 THEN 'Yes' ELSE 'No' END AS CostSharing, " +
                        "CASE TE.Regular WHEN 1 THEN 'Yes' ELSE 'No' END AS Regular " +
                        "FROM TRNTrainingEvent TE " +
                        "JOIN TRNTrade T ON T.TRNTradeID = TE.TradeNameID " +
                        "JOIN TRNTrainingAgency TA ON TA.ID = TE.TrainingAgencyID " +
                        "WHERE TE.Status='1'";
            if (EventID != String.Empty)
                sql += " AND TE.EventID = '"+EventID+"'";
            if (TradeID > 0)
                sql += " AND TE.TradeNameID = '"+TradeID+"'";
            if (TrainingAgencyID > 0)
                sql += " AND TE.TrainingAgencyID = '"+TrainingAgencyID+"'";

            if (Select)
                sql = "SELECT '' AS ID, '[Event Id]' AS EventID UNION SELECT ID, EventID FROM TRNTrainingEvent WHERE Status='1'";

            return ExecuteQuery(sql);
        }

        public DataView SelectBatch()
        {
            String sql = "SELECT '[Batch]' AS Batch UNION SELECT DISTINCT Batch FROM TRNTrainingEvent WHERE Status='1'";
            return ExecuteQuery(sql);
        }

        public DataView SelectEventId()
        {
            String sql = "SELECT '[Event Id]' AS EventID UNION SELECT DISTINCT EventID FROM TRNTrainingEvent WHERE Status='1'";
            return ExecuteQuery(sql);
        }

        public DataView SelectTrainingEventByID(int EventID)
        {
            String sql = "SELECT * FROM TRNTrainingEvent WHERE ID='" + EventID + "'";
            return ExecuteQuery(sql);
        }

        public DataView SelectTrainingEventByTrainingAgency(int AgencyID, Boolean Select = false)
        {
            String sql = "SELECT ID, TradeNameID, EventID, Batch, StartDate, EndDate, CostSharing, Regular FROM TRNTrainingEvent WHERE TrainingAgencyID='" + AgencyID + "' AND Status='1'";
            if (Select)
                sql = "SELECT '' AS ID, '[Trade Name]' AS TradeName UNION SELECT ID,TradeName FROM TRNTrainingEvent WHERE TrainingAgencyID='" + AgencyID + "' AND Status='1'";

            return ExecuteQuery(sql);
        }

        public int InsertTrainingEvent(TRNTrainingEvent objEvent)
        {
            objEvent.EventID = 1;
            BeginTransaction();

            try
            {
                objEvent.EventID = Insert(objEvent);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objEvent.EventID = -1;
            }

            return objEvent.EventID;
        }

        public int UpdateTrainingEvent(TRNTrainingEvent objEvent)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Event", "Batch", "TradeNameID", "StartDate", "EndDate", "ModifiedBy", "ModifiedDate", "Status", "CostSharing", "Regular" };
                rowsaffected = Update(objEvent, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteTrainingEvent(TRNTrainingEvent objEvent)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "UpdatedBy", "UpdateDate", "Status" };
                rowsaffected = Update(objEvent, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView SelectID(String EventID, int TradeID, int TrainingAgencyID)
        {
            String sql = "";
            if (EventID != "")
            {
                sql += "SELECT ID FROM TRNTrainingEvent WHERE EventID='" + EventID + "'";
            }

            if (TradeID > 0)
            {
                sql += "SELECT ID FROM TRNTrainingEvent WHERE TradeNameID=" + TradeID;
            }

            if (TrainingAgencyID > 0)
            {
                sql += "SELECT ID FROM TRNTrainingEvent WHERE TrainingAgencyID=" + TrainingAgencyID;
            }

            return ExecuteQuery(sql);
        }

        public DataView GetTotalMaleNFemale(String EventIDs)
        {
            String sql = "SELECT " +
                         "(SELECT COUNT(Gender) FROM TRNTrainee WHERE Gender='M' AND (" + EventIDs + "))  AS Male, " +
                         "(SELECT COUNT(Gender)  FROM TRNTrainee WHERE Gender='F' AND (" + EventIDs + ")) AS Female, " +
                         "COUNT(*) AS Total  " +
                         "FROM TRNTrainee WHERE " + EventIDs ;
            return ExecuteQuery(sql);
        }
    }

}
