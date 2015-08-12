using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DataAccess;
using SaMI.DTO;
using System.Data;

namespace SaMI.Business
{
    public class TRNTrainingEventBO
    {
        public int InsertTrainingEvent(TRNTrainingEvent objEvent)
        {
            objEvent.CreatedDate = DateTime.Now;
            return new TRNTrainingEventDAO().InsertTrainingEvent(objEvent);
        }

        public int UpdateTrainingEvent(TRNTrainingEvent objEvent)
        {
            objEvent.ModifiedDate = DateTime.Now;
            return new TRNTrainingEventDAO().UpdateTrainingEvent(objEvent);
        }

        public int DeleteTrainingEvent(TRNTrainingEvent objEvent)
        {
            objEvent.ModifiedDate = DateTime.Now;
            return new TRNTrainingEventDAO().DeleteTrainingEvent(objEvent);
        }

        public static DataView GetAllTrainingEvent(Boolean Select = false, String EventID = "", int TradeID = 0, int TrainingAgencyID = 0)
        {
            return new TRNTrainingEventDAO().SelectAllTrainingEvent(Select, EventID, TradeID, TrainingAgencyID);
        }

        public static DataView GetBatch()
        {
            return new TRNTrainingEventDAO().SelectBatch();
        }
        public static DataView GetEventId()
        {
            return new TRNTrainingEventDAO().SelectEventId();
        }

        public DataView GetTrainingEventByID(int EventID)
        {
            return new TRNTrainingEventDAO().SelectTrainingEventByID(EventID);
        }

        public DataView GetTrainingEventByTrainingAgency(int AgencyID, Boolean Select = false)
        {
            return new TRNTrainingEventDAO().SelectTrainingEventByTrainingAgency(AgencyID, Select);
        }


        public static DataView GetEID(String EventID, int TradeID, int TrainingAgencyID)
        {
            return new TRNTrainingEventDAO().SelectID(EventID, TradeID, TrainingAgencyID);
            
        }

        public static DataView GetTotalMaleFemale(String EventIDs)
        {
            return new TRNTrainingEventDAO().GetTotalMaleNFemale(EventIDs);

        }

    }
}
