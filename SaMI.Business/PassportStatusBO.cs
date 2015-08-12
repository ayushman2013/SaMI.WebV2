using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class PassportStatusBO
    {
          public static DataView GetAll(Boolean Select = false)
            {
                return new PassportStatusDAO().SelectAll(Select);
            }

          public static int InsertPassportStatus(PassportStatus objPassportStatus)
          {
              return new PassportStatusDAO().InsertPassportStatus(objPassportStatus);
          }
          public static PassportStatus GetPassportStatus(int PassportStatusID)
          {
              PassportStatus objPassportStatus = new PassportStatus();
              return (PassportStatus)(new PassportStatusDAO().FillDTO(objPassportStatus, "PassportStatusID=" + PassportStatusID));
          }
          public static int UpdatePassportStatus(PassportStatus objPassportStatus)
          {
              return new PassportStatusDAO().UpdatePassportStatus(objPassportStatus);
          }
          public static int Delete(int PassportStatusID)
          {
              return new PassportStatusDAO().Delete("PassportStatusID=" + PassportStatusID);
          }
          public static int DeletePassportStatus(PassportStatus objPassportStatus)
          {
              return new PassportStatusDAO().DeletePassportStatus(objPassportStatus);
          }

          public static DataView GetPassporttatusIDForSync()
          {
              return new PassportStatusDAO().SelectPassporttatusIDForSync();
          }

    }
}
