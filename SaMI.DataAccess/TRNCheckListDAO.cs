using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DBTools;
using SaMI.DTO;
using System.Data;

namespace SaMI.DataAccess
{
  public  class TRNCheckListDAO:BaseDAO
    {

       public TRNCheckListDAO() : base() { }

       public TRNCheckListDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "TRNChecklist";
            KeyField = "ID";
        }

        public DataView SelectAllCheckList(Boolean Select=false)
        {
            String sql = "SELECT ID, Checklist FROM TRNChecklist WHERE Status='1'";            
            return ExecuteQuery(sql);
        }

        public DataView SelectCheckListByID(int CheckListID)
        {
            String sql = "SELECT * FROM TRNChecklist WHERE ID='" + CheckListID + "'";       
           
            return ExecuteQuery(sql);
        }

        public DataView SelectCheckListByTraineeID(int TraineeID)
        {
            String sql = "SELECT CL.Checklist FROM TRNChecklist CL " +
                        "LEFT JOIN TRNDepartureChecklist DCL ON DCL.ChecklistID = CL.ID " +
                        "LEFT JOIN TRNEmployment EMP ON EMP.ID = DCL.EmploymentID " +
                        "LEFT JOIN TRNTrainee T ON T.ID = EMP.TraineeID " +
                        "WHERE T.ID = " + TraineeID ;

            return ExecuteQuery(sql);
        }

        public int InsertCheckList(TRNCheckList objList)
        {
            objList.ChkListID = 1;
            BeginTransaction();

            try
            {
                objList.ChkListID = Insert(objList);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objList.ChkListID = -1;
            }

            return objList.ChkListID;
        }

        public int UpdateCheckList(TRNCheckList objList)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "CheckList", "ModifiedBy", "ModifiedDate", "Status" };
                rowsaffected = Update(objList, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteCheckList(TRNCheckList objList)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "ModifiedBy", "ModifiedDate", "Status" };
                rowsaffected = Update(objList, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }
    }
}
