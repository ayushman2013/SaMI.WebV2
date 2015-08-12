using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class WorkTypesBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new WorkTypesDAO().SelectAll(Select);

        }

        public static int InsertWorkTypes(WorkTypes objWorkTypes)
        {
            return new WorkTypesDAO().InsertWorkTypes(objWorkTypes);
        }
        public static WorkTypes GetWorkTypes(int WorkTypeID)
        {
            WorkTypes objWorkTypes = new WorkTypes();
            return (WorkTypes)(new WorkTypesDAO().FillDTO(objWorkTypes, "WorkTypeID=" + WorkTypeID));
        }

        public static int UpdateWorkTypes(WorkTypes objWorkTypes)
        {
            return new WorkTypesDAO().UpdateWorkTypes(objWorkTypes);
        }

        public static int Delete(int WorkTypeID)
        {
            DataView dv = new WorkTypesDAO().Select("WorkTypeID", "tbl_foreign_employment_status", "WorkTypeID=" + WorkTypeID);
            if(dv.Count == 0)
                return new WorkTypesDAO().Delete("WorkTypeID=" + WorkTypeID);
            return -1;
        }

        public static int DeleteWorkTypes(WorkTypes objWorkTypes)
        {
            return new WorkTypesDAO().DeleteWorkTypes(objWorkTypes);
        }


    }
}
