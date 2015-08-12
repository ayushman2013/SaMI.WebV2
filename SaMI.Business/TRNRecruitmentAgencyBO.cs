using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
    public class TRNRecruitmentAgencyBO
    {
        public int InsertRecruitmentAgency(TRNRecruitmentAgency recAgency)
        {
            return new TRNRecruitmentAgencyDAO().InsertRecruitmentAgency(recAgency);
        }

        public int UpdateRecruitmentAgency(TRNRecruitmentAgency recAgency)
        {
            recAgency.ModifiedDate = DateTime.Now;
            return new TRNRecruitmentAgencyDAO().UpdateRecruitmentAgency(recAgency);
        }

        public int DeleteRecruitmentAgency(TRNRecruitmentAgency recAgency)
        {
            recAgency.ModifiedDate = DateTime.Now;
            return new TRNRecruitmentAgencyDAO().DeleteRecruitmentAgency(recAgency);
        }

        public DataView GetAllRecruitmentAgency(Boolean select = false)
        {
            return new TRNRecruitmentAgencyDAO().SelectAllRecruitmentAgency(select);
        }
        public DataView GetRecruitmentAgencyByID(int RecID)
        {
            return new TRNRecruitmentAgencyDAO().SelectRecruitmentAgencyByID(RecID);
        }


    }
}
