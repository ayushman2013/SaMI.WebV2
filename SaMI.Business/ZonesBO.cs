using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class ZonesBO
    {
        public static DataView GetAll()
        {
            return new ZonesDAO().SelectAll();

        }
    }
}
