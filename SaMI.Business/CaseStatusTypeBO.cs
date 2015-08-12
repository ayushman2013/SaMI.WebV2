using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;


namespace SaMI.Business
{
    public class CaseStatusTypeBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new CaseStatusTypeDAO().SelectAll(Select);

        }
        public static CaseStatusTypes GetCaseStatusType(int CaseStatusTypeID)
        {
            CaseStatusTypes obj = new CaseStatusTypes();
            return (CaseStatusTypes)(new CaseStatusTypeDAO().FillDTO(obj, "CaseStatusTypeID=" + CaseStatusTypeID));
        }

    }
}
