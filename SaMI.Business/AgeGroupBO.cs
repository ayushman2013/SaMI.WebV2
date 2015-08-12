using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class AgeGroupBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new AgeGroupsDAO().SelectAll(Select);

        }

        public static int InsertAgeGroup(AgeGroups objAgeGroup)
        {
            return new AgeGroupsDAO().InsertAgeGroup(objAgeGroup);
        }

        public static AgeGroups GetAgeGroups(int AgeGroupID)
        {
            AgeGroups objCaseType = new AgeGroups();
            return (AgeGroups)(new AgeGroupsDAO().FillDTO(objCaseType, "AgeGroupID=" + AgeGroupID));
        }
        public static int UpdateAgeGroups(AgeGroups objAgeGroups)
        {
            return new AgeGroupsDAO().UpdateAgeGroups(objAgeGroups);
        }

        public static int Delete(int AgeGroupID)
        {
            return new AgeGroupsDAO().Delete("AgeGroupID=" + AgeGroupID);
        }

        public static int DeleteAgeGroups(AgeGroups objAgeGroups)
        {
            return new AgeGroupsDAO().DeleteAgeGroups(objAgeGroups);
        }

        public static DataView GetAgeGroupIDForSync()
        {
            return new AgeGroupsDAO().SelectAgeGroupIDForSync();

        }
    }
}
