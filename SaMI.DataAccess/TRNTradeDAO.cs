using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DBTools;
using SaMI.DTO;

namespace SaMI.DataAccess
{
   public class TRNTradeDAO:BaseDAO
    {
       
        public TRNTradeDAO() : base() { }

        public TRNTradeDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "TRNTrade";
            KeyField = "TRNTradeID";
        }

        public DataView GetAllTradeName(Boolean Select = false)
        {
            String sql = "SELECT TRNTradeID, TradeName FROM TRNTrade WHERE Status='1'";
            if (Select)
                sql = "SELECT 0 AS TRNTradeID, '[Trade Name]' AS TradeName UNION SELECT TRNTradeID, TradeName FROM TRNTrade WHERE Status='1' ";
            return ExecuteQuery(sql);
        }

        public DataView GetTradeNameByID(int TradeID)
        {
            String sql = "SELECT * FROM TRNTrade WHERE TRNTradeID = " + TradeID;
            return ExecuteQuery(sql);
        }

        public int InsertTradeName(TRNTrade objTrade)
        {
            objTrade.TradeID = 1;           
            BeginTransaction();
            try
            {
                objTrade.TradeID = Insert(objTrade);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objTrade.TradeID = -1;
            }

            return objTrade.TradeID;
        }

        public int UpdateTradeName(TRNTrade objTrade)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "TradeName", "Status" };
                rowsaffected = Update(objTrade, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteTradeName(TRNTrade objTrade)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objTrade, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }



        public object SelectAllTrade(bool select)
        {
            String sql = "SELECT TRNTradeID, TradeName FROM TRNTrainingEvent WHERE Status='1'";
            if (select)
                sql = "SELECT '0' AS TRNTradeID, '[Trade Name]' AS TradeName UNION SELECT TRNTradeID, TradeName FROM TRNTrade WHERE Status='1'";
            return ExecuteQuery(sql);
        }

        public object SelectAllEvents(bool select)
        {
            String sql = "";
            return ExecuteQuery(sql);
        }
       
    }
}
