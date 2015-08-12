using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class VisitFrequenciesBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new VisitFrequenciesDAO().SelectAll(Select);

        }
        public static int InsertVisitFrequencies(VisitFrequencies objVisitFrequencies)
        {
            return new VisitFrequenciesDAO().InsertVisitFrequencies(objVisitFrequencies);
        }
        public static VisitFrequencies GetVisitFrequencies(int VisitFrequencyID)
        {
            VisitFrequencies objVisitFrequencies = new VisitFrequencies();
            return (VisitFrequencies)(new VisitFrequenciesDAO().FillDTO(objVisitFrequencies, "VisitFrequencyID=" + VisitFrequencyID));
        }
        public static int UpdateVisitFrequencies(VisitFrequencies objVisitFrequencies)
        {
            return new VisitFrequenciesDAO().UpdateVisitFrequencies(objVisitFrequencies);
        }

        public static int Delete(int VisitFrequencyID)
        {
            return new VisitFrequenciesDAO().Delete("VisitFrequencyID=" + VisitFrequencyID);
        }

        public static int DeleteVisitFrequencies(VisitFrequencies objVisitFrequencies)
        {
            return new VisitFrequenciesDAO().DeleteVisitFrequencies(objVisitFrequencies);
        }
    }
}
