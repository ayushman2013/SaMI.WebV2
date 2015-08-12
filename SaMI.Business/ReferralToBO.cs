using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class ReferralToBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new ReferralToDAO().SelectAll(Select);

        }

        public static int InsertReferralTo(ReferralTo objReferralTo)
        {
            return new ReferralToDAO().InsertReferralTo(objReferralTo);
        }

        public static ReferralTo GetReferralTo(int ReferralToID)
        {
            ReferralTo objCaseType = new ReferralTo();
            return (ReferralTo)(new ReferralToDAO().FillDTO(objCaseType, "ReferralToID=" + ReferralToID));
        }
        public static int UpdateReferralTo(ReferralTo objReferralTo)
        {
            return new ReferralToDAO().UpdateReferralTo(objReferralTo);
        }
        public static int Delete(int ReferralToID)
        {
            DataView dv = new ReferralToDAO().Select("ReferralToID", "tbl_case_documentations", "ReferralToID=" + ReferralToID);
            if(dv.Count == 0)
                return new ReferralToDAO().Delete("ReferralToID=" + ReferralToID);
            return -1;
        }
    }
}
