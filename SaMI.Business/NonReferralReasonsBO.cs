using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class NonReferralReasonsBO
    {

        public static DataView GetAll(Boolean Select = false)
        {
            return new NonReferralReasonsDAO().SelectAll(Select);

        }

        public static int InsertNonReferralReasons(NonReferralReasons objNonReferralReasons)
        {
            return new NonReferralReasonsDAO().InsertNonReferralReasons(objNonReferralReasons);
        }

        public static NonReferralReasons GetNonReferralReasons(int NonReferralReasonID)
        {
            NonReferralReasons objNonReferralReasons = new NonReferralReasons();
            return (NonReferralReasons)(new NonReferralReasonsDAO().FillDTO(objNonReferralReasons, "NonReferralReasonID=" + NonReferralReasonID));
        }
        public static int UpdateNonReferralReasons(NonReferralReasons objNonReferralReasons)
        {
            return new NonReferralReasonsDAO().UpdateNonReferralReasons(objNonReferralReasons);
        }

        public static int Delete(int NonReferralReasonID)
        {
            DataView dv = new NonFollowUpReasonsDAO().Select("NonReferredReasonID", "tbl_case_documentations", "NonReferredReasonID=" + NonReferralReasonID);
            if(dv.Count == 0)
                return new NonReferralReasonsDAO().Delete("NonReferralReasonID=" + NonReferralReasonID);
            return -1;
        }

        public static int DeleteNonReferralReasons(NonReferralReasons objNonReferralReasons)
        {
            return new NonReferralReasonsDAO().DeleteNonReferralReasons(objNonReferralReasons);
        }
    }
}
