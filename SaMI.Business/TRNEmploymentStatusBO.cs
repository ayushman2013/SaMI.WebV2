using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
   public class TRNEmploymentStatusBO
    {
       public DataView GetAllEmploymentStatus(Boolean Select = false)
       {
           return new TRNEmploymentStatusDAO().GetAllEmploymentStatus(Select);
       }

       public int InsertEmploymentStatus(DTO.TRNEmploymentStatus objEmploymentStatus)
       {
           return new TRNEmploymentStatusDAO().InsertEmploymentStatus(objEmploymentStatus);
       }

       public int UpdateEmploymentStatus(DTO.TRNEmploymentStatus objEmploymentStatus)
       {
           return new TRNEmploymentStatusDAO().UpdateEmploymentStatus(objEmploymentStatus);
       }

       public int DeleteEmploymentStatus(DTO.TRNEmploymentStatus objEmploymentStatus)
       {
           return new TRNEmploymentStatusDAO().DeleteEmploymentStatus(objEmploymentStatus);
       }

       public DataView SelectEmploymentStatusByID(int EmploymentStatusId)
       {
           return new TRNEmploymentStatusDAO().SelectEmploymentStatusByID(EmploymentStatusId);
       }
    }
}
