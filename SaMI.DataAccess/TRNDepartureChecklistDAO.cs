using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DBTools;
using SaMI.DTO;
using System.Data;

namespace SaMI.DataAccess
{
   public class TRNDepartureChecklistDAO:BaseDAO
    {
       public TRNDepartureChecklistDAO() : base() { }

       public TRNDepartureChecklistDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "TRNDepartureChecklist";
            KeyField = "ID";
        }

        public DataView SelectDepartureCheckListByEmploymentID(int EmploymentID)
        {
            String sql = "SELECT CheckListID FROM TRNDepartureChecklist WHERE EmploymentID = " + EmploymentID;
            return ExecuteQuery(sql);
        }

        public DataView SelectID(int EmploymentID, int CheckListID)
        {
            String sql = "SELECT ID FROM TRNDepartureChecklist WHERE EmploymentID = " + EmploymentID + " AND ChecklistID = " + CheckListID;
            return ExecuteQuery(sql);
        }

        public int DeleteDepartureList(int EmploymentID, int CheckListID)
        {
            String sql = "DELETE FROM TRNDepartureChecklist WHERE EmploymentID = " + EmploymentID + " AND ChecklistID = " + CheckListID;
            return ExecuteNonQuery(sql);
        }

       
    }
}
