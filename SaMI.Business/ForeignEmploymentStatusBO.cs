using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
    public class ForeignEmploymentStatusBO
    {
        public static DataView GetAll(int SaMIProfileID)
        {
            return new ForeignEmploymentStatusDAO().SelectAll(SaMIProfileID);
        }

        public static int InsertFEStatus(ForeignEmploymentStatus objForeignEmploymentStatus)
        {
            return new ForeignEmploymentStatusDAO().InsertFEStatus(objForeignEmploymentStatus);
        }

        public static int UpdateFEStatus(ForeignEmploymentStatus objForeignEmploymentStatus)
        {
            return new ForeignEmploymentStatusDAO().UpdateFEStatus(objForeignEmploymentStatus);
        }

        public static ForeignEmploymentStatus GetFEStatus(int SaMIProfileID)
        {
            ForeignEmploymentStatus objForeignEmploymentStatus = new ForeignEmploymentStatus();
            return (ForeignEmploymentStatus)(new ForeignEmploymentStatusDAO().FillDTO(objForeignEmploymentStatus, "SaMIProfileID=" + SaMIProfileID));

        }

        public static DataView GetForeignEmploymentStatusIDForSync(String CreatedBy)
        {
            return new ForeignEmploymentStatusDAO().SelectForeignEmploymentStatusIDForSync(CreatedBy);
        }

        public static ForeignEmploymentStatus GetForeignEStatus(int ForeignEmploymentStatusID)
        {
            ForeignEmploymentStatus objForeignEmploymentStatus = new ForeignEmploymentStatus();
            return (ForeignEmploymentStatus)(new ForeignEmploymentStatusDAO().FillDTO(objForeignEmploymentStatus, "ForeignEmploymentStatusID=" + ForeignEmploymentStatusID));

        }
    }
}
