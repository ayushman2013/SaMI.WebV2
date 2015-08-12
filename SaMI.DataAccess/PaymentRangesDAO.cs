using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class PaymentRangesDAO : BaseDAO
    {
        public PaymentRangesDAO() : base() { }
        public PaymentRangesDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_payment_ranges";
            KeyField = "PaymentRangeID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT '' AS PaymentRangeID, '[Select]' AS PaymentRangeDesc " +
                      "UNION " +
                      "SELECT PaymentRangeID, PaymentRangeDesc FROM tbl_payment_ranges " +
                         "WHERE Status <> 0 ";
            else
                sql = "SELECT * FROM tbl_payment_ranges " +
                         "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }

        public int InsertPaymentRanges(PaymentRanges objPaymentRanges)
        {
            objPaymentRanges.PaymentRangeID = 1;
            BeginTransaction();

            try
            {
                objPaymentRanges.PaymentRangeID = Insert(objPaymentRanges);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objPaymentRanges.PaymentRangeID = -1;
            }

            return objPaymentRanges.PaymentRangeID;
        }
        public int UpdatePaymentRanges(PaymentRanges objPaymentRanges)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "PaymentRangeDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objPaymentRanges, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeletePaymentRanges(PaymentRanges objPaymentRanges)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objPaymentRanges, UpdateProperties);

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
