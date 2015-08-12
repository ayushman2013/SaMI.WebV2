using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
   public class TRNEducationLevelBO
    {
       public DataView GetAllEducationLevel(Boolean Select = false)
       {
           return new TRNEducationLevelDAO().SelectAllEducationLevel(Select);
       }

       public static TRNEducationLevel GetAll(int EducationLevelID)
       {
           TRNEducationLevel objEducationLevel = new TRNEducationLevel();
           return (TRNEducationLevel)(new TRNEducationLevelDAO().FillDTO(objEducationLevel, "ID=" + EducationLevelID));
       }

       public int UpdateQualification(TRNEducationLevel objQualification)
       {
           return new TRNEducationLevelDAO().UpdateQualification(objQualification);
       }

       public int InsertQualification(TRNEducationLevel objQualification)
       {
           return new TRNEducationLevelDAO().InsertQualification(objQualification);
       }

       public int DeleteQualification(TRNEducationLevel objQualification)
       {
           return new TRNEducationLevelDAO().DeleteQualification(objQualification);
       }

       public DataView SelectQualificationByID(int QualificationId)
       {
           return new TRNEducationLevelDAO().SelectQualificationByID(QualificationId);
       }
    }
}
