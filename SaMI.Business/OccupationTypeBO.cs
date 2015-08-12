using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DataAccess;
using SaMI.DTO;

namespace SaMI.Business
{
    public class OccupationTypeBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new OccupationTypeDAO().SelectAll(Select);
        }
        public static int InsertOccupationType(OccupationTypes objOccupationType)
        {
            return new OccupationTypeDAO().InsertOccupationType(objOccupationType);
        }
        public static OccupationTypes GetOccupationType(int OccupationTypeID)
        {
            OccupationTypes objOccupationType = new OccupationTypes();
            return (OccupationTypes)(new OccupationTypeDAO().FillDTO(objOccupationType, "OccupationTypeID=" + OccupationTypeID));
        }
        public static int UpdateOccupationTypes(OccupationTypes objOccupationTypes)
        {
            return new OccupationTypeDAO().UpdateOccupationTypes(objOccupationTypes);
        }
        public static int Delete(int OccupationTypeID)
        {
            return new OccupationTypeDAO().Delete("OccupationTypeID=" + OccupationTypeID);
        }

        public static int DeleteOccupationTypes(OccupationTypes objOccupationTypes)
        {
            return new OccupationTypeDAO().DeleteOccupationTypes(objOccupationTypes);
        }

    }
}
