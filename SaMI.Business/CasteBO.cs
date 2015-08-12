using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class CasteBO
    {      
       
        public static DataView GetByEthnicityID(int EthnicityID, Boolean Select = false)
        {
            return new CasteDAO().SelectAllByEthnicity(EthnicityID, Select);
        }

        public static Caste GetCaste(int casteID)
        {
            Caste objCaste = new Caste();
            return (Caste)(new CasteDAO().FillDTO(objCaste, "CasteID=" + casteID));

        }

        public static int InsertCaste(Caste objCaste)
        {
            return new CasteDAO().InsertCaste(objCaste);
        }

        

        public static DataView GetAllCustom()
        {
            return new CasteDAO().SelectAllCustom();

        }

        public static Caste GetCaseType(int CasteID)
        {
            Caste objCaseType = new Caste();
            return (Caste)(new CasteDAO().FillDTO(objCaseType, "CasteID=" + CasteID));
        }
        public static int UpdateCaste(Caste objCaste)
        {
            return new CasteDAO().UpdateCaste(objCaste);
        }

        public static int Delete(int CasteID)
        {
            return new CasteDAO().Delete("CasteID=" + CasteID);
        }

        public static bool CheckDiscrimination(int CasteID)
        {
            if (GetCaseType(CasteID).IsDiscriminated == 1)
                return true;
            else
                return false;
        }

        public static int DeleteCaste(Caste objCaste)
        {
            return new CasteDAO().DeleteCaste(objCaste);
        }
    }
}
