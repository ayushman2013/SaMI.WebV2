using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class CasteDAO : BaseDAO
    {
        public CasteDAO() : base() { }
        public CasteDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_caste";
            KeyField = "CasteID";
        }

        public DataView SelectAllByEthnicity(int EthnicityID, Boolean Select = false)
        {
            String sql = string.Empty;

            if (Select)
                sql = "SELECT '' AS CasteID, '[Caste]' AS CasteName UNION " +
                        "SELECT CasteID, CasteName  FROM tbl_caste WHERE EthnicityID = " + EthnicityID +
                        " ORDER BY CasteName ";
            else
                sql = "SELECT * FROM tbl_caste WHERE EthnicityID = " + EthnicityID +
                        " ORDER BY CasteName "; 
            return ExecuteQuery(sql);
        }

        public DataView SelectAllCustom()
        {
            String sql = string.Empty;
            sql = "SELECT C.CasteID, C.CasteName, E.EthnicityName " +
                    "FROM tbl_caste AS C " +
                    "JOIN tbl_ethnicity AS E " +
                        "ON E.EthnicityID = C.EthnicityID " +
                       "WHERE C.Status <> 0 " +
                    "ORDER BY E.EthnicityName, CasteName";
            return ExecuteQuery(sql);
        }

        public int InsertCaste(Caste objCaste)
        {
            objCaste.CasteID = 1;
            BeginTransaction();

            try
            {
                objCaste.CasteID = Insert(objCaste);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objCaste.CasteID = -1;
            }

            return objCaste.CasteID;
        }


        public int UpdateCaste(Caste objCaste)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "CasteName", "EthnicityID", "UpdatedBy", "UpdatedDate", 
                                                           "IsDiscriminated", "Status", "SyncStatus" };
                rowsaffected = Update(objCaste, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;
        }

        public int DeleteCaste(Caste objCaste)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objCaste, UpdateProperties);

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
