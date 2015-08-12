using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DBTools;
using System.Data;

namespace SaMI.DataAccess
{
  public  class TRNEmploymentStatusDAO:BaseDAO
    {
       public TRNEmploymentStatusDAO() : base() { }

       public TRNEmploymentStatusDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "TRNEmploymentStatus";
            KeyField = "ID";
        }

        public DataView GetAllEmploymentStatus(Boolean Select = false)
        {
            String sql = "SELECT ID, EmploymentStatus FROM TRNEmploymentStatus WHERE Status = 1";
            if (Select)
                sql = "SELECT 0 AS ID, '[Employment Status]' AS EmploymentStatus UNION SELECT ID, EmploymentStatus FROM TRNEmploymentStatus WHERE Status = 1";
            return ExecuteQuery(sql);
        }

        public int InsertEmploymentStatus(DTO.TRNEmploymentStatus objEmploymentStatus)
        {
            objEmploymentStatus.EmploymentStatusID = 1;
            BeginTransaction();
            try
            {
                objEmploymentStatus.EmploymentStatusID = Insert(objEmploymentStatus);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objEmploymentStatus.EmploymentStatusID = -1;
            }

            return objEmploymentStatus.EmploymentStatusID;
        }

        public int UpdateEmploymentStatus(DTO.TRNEmploymentStatus objEmploymentStatus)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "EmploymentStatus", "Status" };
                rowsaffected = Update(objEmploymentStatus, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;
        }

        public int DeleteEmploymentStatus(DTO.TRNEmploymentStatus objEmploymentStatus)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objEmploymentStatus, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;
        }

        public DataView SelectEmploymentStatusByID(int EmploymentStatusId)
        {
            String sql = "SELECT * FROM TRNEmploymentStatus WHERE ID = " + EmploymentStatusId;
            return ExecuteQuery(sql);
        }
    }
}
