using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class DestinationAirportsBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new DestinationAirportsDAO().SelectAll(Select);

        }

        public static DestinationAirports GetDestinationAirport(int DestinationAirportID)
        {
            DestinationAirports obj = new DestinationAirports();
            return (DestinationAirports)(new DestinationAirportsDAO().FillDTO(obj, "DestinationAirportID=" + DestinationAirportID));
        }

    }
}
