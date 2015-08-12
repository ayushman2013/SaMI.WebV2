using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class VDCDAO : BaseDAO
    {
        public VDCDAO() : base() { }
        public VDCDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_VDC";
            KeyField = "VDCID";
        }

        public DataView SelectAll(Boolean Select)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT 0 as VDCID, '[VDC]' AS VDCName " +
                       " UNION " +
                       " SELECT VDCID, VDCName FROM tbl_VDC " +
                       " JOIN tbl_districts D ON D.DistrictCode = tbl_VDC.DistrictCode " +
                       " ORDER BY VDCName";
            else
                sql = "SELECT * FROM tbl_VDC ORDER BY VDCName";
            return ExecuteQuery(sql);
        }
        public DataView SelectAllByDistrictID(int DistrictID, Boolean Select)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT 0 as VDCID, '[VDC]' AS VDCName " +
                       " UNION " +
                       " SELECT VDCID, VDCName FROM tbl_VDC "+
                       " JOIN tbl_districts D ON D.DistrictCode = tbl_VDC.DistrictCode " +
                       " WHERE D.DistrictID = '" + DistrictID + "' ORDER BY VDCName";
            else
                sql = "SELECT * FROM tbl_VDC " +
                        " JOIN tbl_districts D ON D.DistrictCode = tbl_VDC.DistrictCode " +
                       " WHERE D.DistrictID = '" + DistrictID + "' ORDER BY VDCName";
            return ExecuteQuery(sql);
        }
    }
}
