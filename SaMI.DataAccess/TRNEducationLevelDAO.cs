using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DBTools;
using System.Data;

using SaMI.DTO;

namespace SaMI.DataAccess
{
  public  class TRNEducationLevelDAO:BaseDAO
    {
       public TRNEducationLevelDAO() : base() { }
       public TRNEducationLevelDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "TRNEducationLevel";
            KeyField = "ID";
        }

        public DataView SelectAllEducationLevel(Boolean Select)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT 0 as ID, '[Education Level]' AS EducationLevel " +
                       " UNION " +
                       " SELECT ID, EducationLevel FROM TRNEducationLevel WHERE Status = 1";
            else
                sql = "SELECT ID, EducationLevel FROM TRNEducationLevel WHERE Status = 1";
            return ExecuteQuery(sql);
        }

        public int InsertQualification(TRNEducationLevel objQualification)
        {
            objQualification.EducationalLevelID = 1;
            BeginTransaction();
            try
            {
                objQualification.EducationalLevelID = Insert(objQualification);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objQualification.EducationalLevelID = -1;
            }

            return objQualification.EducationalLevelID;
        }

        public int UpdateQualification(TRNEducationLevel objQualification)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "EducationLevel", "Status" };
                rowsaffected = Update(objQualification, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;
        }

        public int DeleteQualification(TRNEducationLevel objQualification)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objQualification, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;
        }

        public DataView SelectQualificationByID(int QualificationId)
        {
            String sql = "SELECT * FROM TRNEducationLevel WHERE ID = " + QualificationId;
            return ExecuteQuery(sql);
        }
    }
}
