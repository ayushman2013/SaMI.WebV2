using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
    public class EmploymentSkillBO
    {
        public static DataView GetAll()
        {
            return new EmploymentSkillDAO().SelectAll();
        }

        public static DataView GetCustom(int ethnicityID, int casteID, int districtID, int vdcID = 0, string gender = "", string fromDate = "", string toDate = "", string discriminated = "", String orderBy = "")
        {
            String strFilter = "WHERE 1=1 ";

            if (ethnicityID > 0)
                strFilter += " AND E.EthnicityID = " + ethnicityID;
            if (casteID > 0)
                strFilter += " AND C.CasteID = " + casteID;
            if (districtID > 0)
                strFilter += " AND ES.TrainingDistrictID = " + districtID;            
            if (vdcID > 0)
                strFilter += " AND V.VDCID= " + vdcID;
            if (gender != string.Empty)
                strFilter += " AND SP.Gender = '" + gender + "'";
            if (fromDate != string.Empty && toDate != string.Empty)
                strFilter += " AND CONVERT(DATE, ES.TrainingStratDate) BETWEEN CONVERT(DATE,'" + fromDate + "') AND CONVERT(DATE,'" + toDate + "')";
            else if(fromDate != string.Empty)
                strFilter += " AND CONVERT(DATE, ES.TrainingStratDate) = CONVERT(DATE,'" + fromDate + "')";

            return new EmploymentSkillDAO().SelectCustom(strFilter, orderBy);

        }

        public static int InsertSkill(EmploymentSkills objEmploymentSkills)
        {
            return new EmploymentSkillDAO().InsertSkill(objEmploymentSkills);
        }

        public static int UpdateSkill(EmploymentSkills objEmploymentSkills)
        {
            return new EmploymentSkillDAO().UpdateSkill(objEmploymentSkills);
        }

        public static EmploymentSkills GetEmploymentSkill(int EmploymentSkillID)
        {
            EmploymentSkills objEmploymentSkills = new EmploymentSkills();
            return (EmploymentSkills)(new EmploymentSkillDAO().FillDTO(objEmploymentSkills, "EmploymentSkillID=" + EmploymentSkillID));

        }
    }
}
