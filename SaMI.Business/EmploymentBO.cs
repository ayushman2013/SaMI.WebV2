using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
    public class EmploymentBO
    {
        public static DataView GetAll(int SaMIProfileID)
        {
            return new EmploymentDAO().SelectAll(SaMIProfileID);
        }

        public static DataView GetCustom(int EmploymentSkillID)
        {
            return new EmploymentDAO().SelectCustom(EmploymentSkillID);
        }

        public static DataView GetCustomDetails(int countryID , int ethnicityID, int casteID, int districtID, int vdcID = 0, string gender = "", string discriminated = "", String orderBy = "")
        {
            String strFilter = "WHERE 1=1 ";

            if(countryID > 0)
                strFilter += " AND ES.CountryID = " + countryID;
            if (ethnicityID > 0)
                strFilter += " AND E.EthnicityID = " + ethnicityID;
            if (casteID > 0)
                strFilter += " AND C.CasteID = " + casteID;
            if (districtID > 0)
                strFilter += " AND D.DistrictID = " + districtID;
            
            if (vdcID > 0)
                strFilter += " AND V.VDCID= " + vdcID;
            if (gender != string.Empty)
                strFilter += " AND SP.Gender = '" + gender + "'";

            return new EmploymentDAO().SelectCustomDetails(strFilter, orderBy);

        }

        public static int InsertEmployment(Employments objEmployments)
        {
            return new EmploymentDAO().InsertEmployment(objEmployments);
        }

        public static int UpdateEmployment(Employments objEmployments)
        {
            return new EmploymentDAO().UpdateEmployment(objEmployments);
        }

        public static Employments GetEmployment(int EmploymentID)
        {
            Employments objEmployments = new Employments();
            return (Employments)(new EmploymentDAO().FillDTO(objEmployments, "EmploymentID=" + EmploymentID));

        }

        public static int DeleteEmployment(int EmploymentID)
        {
            return new EmploymentDAO().Delete("EmploymentID=" + EmploymentID);
        }

       
    }
}
