using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;


namespace SaMI.Business
{
    public class CaseRegistrarBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new CaseRegistrarDAO().SelectAll(Select);

        }

        public static CaseRegistrars GetCaseRegistrar(int CaseRegistrarID)
        {
            CaseRegistrars obj = new CaseRegistrars();
            return (CaseRegistrars)(new CaseRegistrarDAO().FillDTO(obj, "CaseRegistrarID=" + CaseRegistrarID));
        }

    }
}
