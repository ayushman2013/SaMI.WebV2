using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DataAccess;
using System.Data;
using SaMI.DataAccess;
using SaMI.DTO;

namespace SaMI.Business
{
  public  class TRNTrainingAgencyBO
    {
        public int InsertTrainingAgency(TRNTrainingAgency objAgency)
        {
            return new TRNTrainingAgencyDAO().InsertTrainingAgency(objAgency);
        }

        public int UpdateTrainingAgency(TRNTrainingAgency objAgency)
        {
            objAgency.ModifiedDate = DateTime.Now;
            return new TRNTrainingAgencyDAO().UpdateTrainingAgency(objAgency);
        }

        public int DeleteTrainingAgency(TRNTrainingAgency objAgency)
        {
            objAgency.ModifiedDate = DateTime.Now;
            return new TRNTrainingAgencyDAO().UpdateTrainingAgency(objAgency);
        }

        public DataView GetAllTraingAgency(Boolean Select = false)
        {
            return new TRNTrainingAgencyDAO().SelectAllTrainingAgency(Select);
        }

        public DataView GetTrainingAgencyByID(int AgencyID)
        {
            return new TRNTrainingAgencyDAO().SelectTrainingAgencyByID(AgencyID);
        }


    }
}
