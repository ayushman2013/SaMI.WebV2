using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class EvidenceTypeBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new EvidenceTypeDAO().SelectAll(Select);
        }
        public static int InsertEvidenceTypes(EvidenceTypes objCaseType)
        {
            return new EvidenceTypeDAO().InsertEvidenceTypes(objCaseType);
        }

        public static EvidenceTypes GetEvidenceTypes(int EvidenceTypeID)
        {
            EvidenceTypes objCaseType = new EvidenceTypes();
            return (EvidenceTypes)(new EvidenceTypeDAO().FillDTO(objCaseType, "EvidenceTypeID=" + EvidenceTypeID));
        }

        public static int UpdateEvidenceTypes(EvidenceTypes objEvidenceTypes)
        {
            return new EvidenceTypeDAO().UpdateEvidenceTypes(objEvidenceTypes);
        }

        public static int Delete(int EvidenceTypeID)
        {
            return new EvidenceTypeDAO().Delete("EvidenceTypeID=" + EvidenceTypeID);
        }

        public static int DeleteEvidenceTypes(EvidenceTypes objEvidenceTypes)
        {
            return new EvidenceTypeDAO().DeleteEvidenceTypes(objEvidenceTypes);
        }
    }
}
