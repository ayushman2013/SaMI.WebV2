using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DBTools;
using System.Data;
using SaMI.DTO;

namespace SaMI.DataAccess
{
    public class TRNOrganizationDAO:BaseDAO
    {
         public TRNOrganizationDAO() : base() { }

         public TRNOrganizationDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "TRNOrganization";
            KeyField = "ID";
        }

        public DataView SelectAllOrganization(Boolean Select=false)
        {
            String sql = "SELECT ID, Organization, Country FROM TRNOrganization WHERE Status='1'";   
            if(Select)
                sql = "SELECT 0 AS ID, '[Organization]' AS Organization UNION SELECT ID, Organization FROM TRNOrganization WHERE Status='1'"; 
            return ExecuteQuery(sql);
        }

        public DataView SelectOrganizationByID(int OrganizationID)
        {
            String sql = "SELECT * FROM TRNOrganization WHERE ID='"+OrganizationID+"'";       
           
            return ExecuteQuery(sql);
        }

        public int InsertOrganization(TRNOrganization objOrganization)
        {
            objOrganization.OrganizationID = 1;
            BeginTransaction();

            try
            {
                objOrganization.OrganizationID = Insert(objOrganization);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objOrganization.OrganizationID = -1;
            }

            return objOrganization.OrganizationID;
        }

        public int UpdateOrganization(TRNOrganization objOrganization)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Organization", "Country", "ModifiedBy", "ModifiedDate", "Status" };
                rowsaffected = Update(objOrganization, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteOrganization(TRNOrganization objOrganization)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "ModifiedBy", "ModifiedDate", "Status" };
                rowsaffected = Update(objOrganization, UpdateProperties);

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
