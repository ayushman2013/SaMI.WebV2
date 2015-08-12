using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
  public class TRNEmploymentTypeBO
    {
        public int InsertTrainingAgency(TRNEmploymentType objType)
        {
            objType.CreatedDate = DateTime.Now;
            return new TRNEmploymentTypeDAO().InsertEmployeementType(objType);
        }

        public int UpdateTrainingAgency(TRNEmploymentType objType)
        {
            objType.ModifiedDate = DateTime.Now;
            return new TRNEmploymentTypeDAO().UpdateEmployeementType(objType);
        }

        public int DeleteTrainingAgency(TRNEmploymentType objType)
        {
            objType.ModifiedDate = DateTime.Now;
            return new TRNEmploymentTypeDAO().DeleteEmployeementType(objType);
        }

        public DataView GetAllEmploymentType(Boolean Select = false)
        {
            return new TRNEmploymentTypeDAO().GetAllEmployeeType(Select);
        }

        public DataView GetTrainingAgencyByID(int EmploymentTypeID)
        {
            return new TRNEmploymentTypeDAO().GetEmployeeTypeByID(EmploymentTypeID);
        }

    }
}
