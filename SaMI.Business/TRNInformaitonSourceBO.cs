using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DataAccess;
using System.Data;
using SaMI.DTO;

namespace SaMI.Business
{
  public  class TRNInformaitonSourceBO
    {

      public DataView GetAllInformationSource(Boolean Select=false)
      {
          return new TRNInformationSourceDAO().SelectAllInformationSource(Select);
      }

      public static TRNInformationSource GetAll(int ID)
      {
          TRNInformationSource objInformationSource = new TRNInformationSource();
          return (TRNInformationSource)(new TRNInformationSourceDAO().FillDTO(objInformationSource, "ID=" + ID));
      }
    }
}
