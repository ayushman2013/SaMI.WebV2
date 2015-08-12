using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class NonFollowUpReasonsBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new NonFollowUpReasonsDAO().SelectAll(Select);

        }

        public static int InsertNonFollowUpReasons(NonFollowUpReasons objNonFollowUpReasons)
        {
            return new NonFollowUpReasonsDAO().InsertNonFollowUpReasons(objNonFollowUpReasons);
        }
        public static NonFollowUpReasons GetNonFollowUpReasons(int NonFollowUpReasonID)
        {
            NonFollowUpReasons objNonFollowUpReasons = new NonFollowUpReasons();
            return (NonFollowUpReasons)(new NonFollowUpReasonsDAO().FillDTO(objNonFollowUpReasons, "NonFollowUpReasonID=" + NonFollowUpReasonID));
        }
        public static int UpdateNonFollowUpReasons(NonFollowUpReasons objNonFollowUpReasons)
        {
            return new NonFollowUpReasonsDAO().UpdateNonFollowUpReasons(objNonFollowUpReasons);
        }

        public static int Delete(int NonFollowUpReasonID)
        {
            DataView dv = new NonReferralReasonsDAO().Select("NonFollowUpReasonID", "tbl_other_followup_per_service", "NonFollowUpReasonID=" + NonFollowUpReasonID);
            if(dv.Count == 0)
                return new NonFollowUpReasonsDAO().Delete("NonFollowUpReasonID=" + NonFollowUpReasonID);
            return -1;
        }

        public static int DeleteNonFollowUpReasons(NonFollowUpReasons objNonFollowUpReasons)
        {
            return new NonFollowUpReasonsDAO().DeleteNonFollowUpReasons(objNonFollowUpReasons);
        }
    }

    
}
