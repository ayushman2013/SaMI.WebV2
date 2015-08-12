using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DataAccess;

namespace SaMI.Business
{
  public  class TRNEthnicityBO
    {
      public DataView GetAllEthnicity(Boolean Select = false)
      {
          return new TRNEthnicityDAO().SelectAllEthnicity(Select);
      }
    }
}
