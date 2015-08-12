using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
   public class VisitReasonBO
    {
       public static DataView GetAll(String Select)
       {
           return new VisitReasonDAO().SelectAll(Select);
       }
    }
}
