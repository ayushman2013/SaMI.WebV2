using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;


namespace SaMI.DataAccess
{
    public class StakeholderDAO : BaseDAO
    {
        public StakeholderDAO() : base() { }
        public StakeholderDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_stakeholders";
            KeyField = "StakeHolderID";
        }

        public DataView SelectAll(Boolean Select)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT 0 as StakeHolderID, '[Case Partner]' AS StakeHolderName " +
                       " UNION " +
                       " SELECT StakeHolderID, StakeHolderName FROM tbl_stakeholders";
            else
                sql = "SELECT * FROM tbl_stakeholders";
            return ExecuteQuery(sql);
        }

        public int InsertStakeHolders(StakeHolders objStakeHolders)
        {
            objStakeHolders.StakeHolderID = 1;
            BeginTransaction();

            try
            {
                objStakeHolders.StakeHolderID = Insert(objStakeHolders);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objStakeHolders.StakeHolderID = -1;
            }

            return objStakeHolders.StakeHolderID;
        }
        public int UpdateStakeHolders(StakeHolders objStakeHolders)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "StakeHolderName", "UpdatedBy", "UpdatedDate" };
                rowsaffected = Update(objStakeHolders, UpdateProperties);

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
