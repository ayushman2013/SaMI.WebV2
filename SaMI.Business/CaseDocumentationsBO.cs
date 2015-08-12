using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
    public class CaseDocumentationsBO
    {
        public static DataView GetAll()
        {
            return new CaseDocumentationsDAO().SelectAll();
        }

        public static DataView GetBySaMIProfileID(int SaMIProfileID)
        {
            return new CaseDocumentationsDAO().SelectBySaMIProfileID(SaMIProfileID);
        }


        public static int InsertCase(CaseDocumentations objCaseDocumentations)
        {
            return new CaseDocumentationsDAO().InsertCase(objCaseDocumentations);
        }

        public static int UpdateCase(CaseDocumentations objCaseDocumentations)
        {
            return new CaseDocumentationsDAO().UpdateCase(objCaseDocumentations);
        }

        public static CaseDocumentations GetCaseDocumentation(int SaMIProfileID)
        {
            CaseDocumentations objCaseDocumentations = new CaseDocumentations();
            return (CaseDocumentations)(new CaseDocumentationsDAO().FillDTO(objCaseDocumentations, "SaMIProfileID=" + SaMIProfileID));
        }

    }
}
