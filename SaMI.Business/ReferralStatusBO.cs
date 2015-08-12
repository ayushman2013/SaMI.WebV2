using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class ReferralStatusBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new ReferralStatusDAO().SelectAll(Select);

        }

        public static int InsertReferralStatus(ReferralStatus objReferralStatus)
        {
            return new ReferralStatusDAO().InsertReferralStatus(objReferralStatus);
        }

        public static ReferralStatus GetReferralStatus(int ReferralStausID)
        {
            ReferralStatus objReferralStatus = new ReferralStatus();
            return (ReferralStatus)(new ReferralStatusDAO().FillDTO(objReferralStatus, "ReferralStausID=" + ReferralStausID));
        }
        public static int UpdateReferralStatus(ReferralStatus objReferralStatus)
        {
            return new ReferralStatusDAO().UpdateReferralStatus(objReferralStatus);
        }
        public static int Delete(int ReferralStausID)
        {
            return new ReferralStatusDAO().Delete("ReferralStausID=" + ReferralStausID);
        }
    }
}
