using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class MoneyRangesBO 
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new MoneyRangesDAO().SelectAll(Select);

        }

        public static int InsertMoneyRanges(MoneyRanges objMoneyRanges)
        {
            return new MoneyRangesDAO().InsertMoneyRanges(objMoneyRanges);
        }
        public static MoneyRanges GetMoneyRanges(int MoneyRangeID)
        {
            MoneyRanges objMoneyRanges = new MoneyRanges();
            return (MoneyRanges)(new MoneyRangesDAO().FillDTO(objMoneyRanges, "MoneyRangeID=" + MoneyRangeID));
        }
        public static int UpdateMoneyRanges(MoneyRanges objMoneyRanges)
        {
            return new MoneyRangesDAO().UpdateMoneyRanges(objMoneyRanges);
        }

        public static int Delete(int MoneyRangeID)
        {
            DataView dv = new MoneyRangesDAO().Select("MoneyRangeID", "tbl_other_member_migrations", "MoneyRangeID=" + MoneyRangeID);

            if(dv.Count == 0)
                return new MoneyRangesDAO().Delete("MoneyRangeID=" + MoneyRangeID);

            return -1;
        }

        public static int DeleteMoneyRanges(MoneyRanges objMoneyRanges)
        {
            return new MoneyRangesDAO().DeleteMoneyRanges(objMoneyRanges);
        }
    }
}
