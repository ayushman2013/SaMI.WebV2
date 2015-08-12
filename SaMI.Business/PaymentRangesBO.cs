using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;


namespace SaMI.Business
{
    public class PaymentRangesBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new PaymentRangesDAO().SelectAll(Select);

        }
        public static int InsertPaymentRanges(PaymentRanges objPaymentRanges)
        {
            return new PaymentRangesDAO().InsertPaymentRanges(objPaymentRanges);
        }

        public static PaymentRanges GetPaymentRanges(int PaymentRangeID)
        {
            PaymentRanges objPaymentRanges = new PaymentRanges();
            return (PaymentRanges)(new PaymentRangesDAO().FillDTO(objPaymentRanges, "PaymentRangeID=" + PaymentRangeID));
        }
        public static int UpdatePaymentRanges(PaymentRanges objPaymentRanges)
        {
            return new PaymentRangesDAO().UpdatePaymentRanges(objPaymentRanges);
        }

        public static int Delete(int PaymentRangeID)
        {
            String sql = "SELECT ForeignEmploymentStatusID FROM tbl_foreign_employment_status " +
                         "WHERE MadePaymentRangeID = " + PaymentRangeID  + " OR AskedPayemntRageID = " + PaymentRangeID +
                         " OR ReceiptPaymentRangeID = " + PaymentRangeID;
            DataView dv = new BaseDAO().ExecuteQuery(sql);

            if(dv.Count == 0)
                return new PaymentRangesDAO().Delete("PaymentRangeID=" + PaymentRangeID);

            return -1;
        }

        public static int DeletePaymentRanges(PaymentRanges objPaymentRanges)
        {
            return new PaymentRangesDAO().DeletePaymentRanges(objPaymentRanges);
        }

    }
}
