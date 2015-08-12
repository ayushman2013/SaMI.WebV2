using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class MoneyRangesDAO : BaseDAO
    {
         public MoneyRangesDAO() : base() { }
         public MoneyRangesDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_money_ranges";
            KeyField = "MoneyRangeID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT '' AS MoneyRangeID, '[Select]' AS MoneyRangeDesc " +
                      "UNION " +
                      "SELECT MoneyRangeID, MoneyRangeDesc FROM tbl_money_ranges " +
                         "WHERE Status <> 0 ";
            else
                sql = "SELECT * FROM tbl_money_ranges " +
                         "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }

        public int InsertMoneyRanges(MoneyRanges objMoneyRanges)
        {
            objMoneyRanges.MoneyRangeID = 1;
            BeginTransaction();

            try
            {
                objMoneyRanges.MoneyRangeID = Insert(objMoneyRanges);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objMoneyRanges.MoneyRangeID = -1;
            }

            return objMoneyRanges.MoneyRangeID;
        }
        public int UpdateMoneyRanges(MoneyRanges objMoneyRanges)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "MoneyRangeDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objMoneyRanges, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteMoneyRanges(MoneyRanges objMoneyRanges)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objMoneyRanges, UpdateProperties);

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
