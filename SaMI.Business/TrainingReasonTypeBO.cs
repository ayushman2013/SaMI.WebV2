using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class TrainingReasonTypeBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new TrainingReasonTypeDAO().SelectAll(Select);

        }
    }
}
