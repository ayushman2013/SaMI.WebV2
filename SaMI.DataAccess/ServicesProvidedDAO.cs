using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class ServicesProvidedDAO : BaseDAO
    {
         public ServicesProvidedDAO() : base() { }
         public ServicesProvidedDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_services_provided";
            KeyField = "ServicesProvidedID";
        }

        public DataView SelectAll(Boolean Select)
        {
            String sql = string.Empty;
            if (Select)
            {
                sql = "SELECT 0 AS ServiceProvidedID, '[Select]' AS ServiceProvidedDesc " +
                    "UNION" +
                    " SELECT ServiceProvidedID, ServiceProvidedDesc FROM tbl_services_provided " +
                         "WHERE Status <> 0 ";
            }
            else
                sql = "SELECT * FROM tbl_services_provided " +
                             "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }
        public int InsertServicesProvided(ServicesProvided objServicesProvided)
        {
            objServicesProvided.ServiceProvidedID = 1;
            BeginTransaction();

            try
            {
                objServicesProvided.ServiceProvidedID = Insert(objServicesProvided);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objServicesProvided.ServiceProvidedID = -1;
            }

            return objServicesProvided.ServiceProvidedID;
        }
        public int UpdateServicesProvided(ServicesProvided objServicesProvided)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "ServiceProvidedDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objServicesProvided, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteServicesProvided(ServicesProvided objServicesProvided)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objServicesProvided, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView SelectServicesProvidedIDForSync()
        {
            String sql = string.Empty;

            sql = "SELECT ServiceProvidedID FROM tbl_services_provided " +
                         "WHERE SyncStatus='0'";
            return ExecuteQuery(sql);
        }
       
    }
}
