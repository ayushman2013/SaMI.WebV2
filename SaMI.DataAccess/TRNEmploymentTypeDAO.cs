using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
  public  class TRNEmploymentTypeDAO:BaseDAO
    {

       public TRNEmploymentTypeDAO() : base() { }

       public TRNEmploymentTypeDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "TRNTrainingAgency";
            KeyField = "ID";
        }

        public DataView GetAllEmployeeType(Boolean Select = false)
        {
            String sql = "SELECT ID, EmploymentType FROM TRNEmploymentType WHERE Status='1'";
            if (Select)
                sql = "SELECT 0 AS ID, '[Employment Type]' AS EmploymentType UNION SELECT ID, EmploymentType FROM TRNEmploymentType WHERE Status='1'";
            return ExecuteQuery(sql);
        }

        public DataView GetEmployeeTypeByID(int EmploymentTypeID)
        {
            String sql = "SELECT * FROM TRNEmploymentType WHERE ID='"+EmploymentTypeID+"'";
            return ExecuteQuery(sql);
        }
       
        public int InsertEmployeementType(TRNEmploymentType objType)
        {
            objType.EmployeeTypeID = 1;           
            BeginTransaction();
            try
            {
                objType.EmployeeTypeID = Insert(objType);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objType.EmployeeTypeID = -1;
            }

            return objType.EmployeeTypeID;
        }

        public int UpdateEmployeementType(TRNEmploymentType objType)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "EmploymentType","UpdatedBy","UpdatedDate","Status" };
                rowsaffected = Update(objType, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteEmployeementType(TRNEmploymentType objType)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "UpdatedBy", "UpdatedDate", "Status" };
                rowsaffected = Update(objType, UpdateProperties);

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
