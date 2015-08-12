using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
   public class EducationalStatusBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new EducationalStatusDAO().SelectAll(Select);

        }

        public static int InsertEduationalStatus(EducationalStatus objEducationalStatus)
        {
            return new EducationalStatusDAO().InsertEduationalStatus(objEducationalStatus);
        }

        public static EducationalStatus GetEducationalStatus(int EducationalStatusID)
        {
            EducationalStatus objEducationalStatus = new EducationalStatus();
            return (EducationalStatus)(new EducationalStatusDAO().FillDTO(objEducationalStatus, "EducationalStatusID=" + EducationalStatusID));
        }

        public static int UpdateEducationalStatus(EducationalStatus objEducationalStatus)
        {
            return new EducationalStatusDAO().UpdateEducationalStatus(objEducationalStatus);
        }

        public static int Delete(int EducationalStatusID)
        {
            return new EducationalStatusDAO().Delete("EducationalStatusID=" + EducationalStatusID);
        }

        public static int DeleteEducationalStatus(EducationalStatus objEducationalStatus)
        {
            return new EducationalStatusDAO().DeleteEducationalStatus(objEducationalStatus);
        }
       
        public static DataView GetEducationalStatusIDForSync()
        {
            return new EducationalStatusDAO().GetEducationalStatusIDForSync();
        }
    }
}
