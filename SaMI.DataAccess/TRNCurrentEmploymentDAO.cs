using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DBTools;
using SaMI.DTO;
using System.Data;

namespace SaMI.DataAccess
{
   public class TRNCurrentEmploymentDAO:BaseDAO
    {
       public TRNCurrentEmploymentDAO() : base() { }

       public TRNCurrentEmploymentDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "TRNCurrentEmployment";
            KeyField = "ID";
        }

        public DataView SelectCurrentEmploymentIdByTraineeId(int TraineeID)
        {
            String sql = "SELECT ID FROM TRNCurrentEmployment WHERE TraineeID = " + TraineeID;
            return ExecuteQuery(sql);
        }


        public DataView SelectCurrentEmploymentInfo(int TraineeID)
        {
            String sql = "SELECT CE.* FROM TRNCurrentEmployment CE " +
                       "WHERE CE.TraineeID = " + TraineeID;
            return ExecuteQuery(sql);
        }

        public DataView SelectByID(int TraineeID)
        {
            String sql = "SELECT E.CountryID, C.CountryName, E.WorkingYear, E.WorkingMonth, E.Occupation, E.MonthlySalary, E.ReturnDate " + 
                         "FROM TRNCurrentEmployment E " +
                         "JOIN tbl_countries C ON C.CountryID = E.CountryID " +
                       "WHERE E.TraineeID = " + TraineeID;
            return ExecuteQuery(sql);
        }
    }
}
