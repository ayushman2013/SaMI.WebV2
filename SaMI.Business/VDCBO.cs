using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class VDCBO
    {
        public static DataView GetAll(Boolean Select)
        {
            return new VDCDAO().SelectAll(Select);

        }

        public static DataView GetAllByDistrictID(int DistrictID, Boolean Select)
        {
            return new VDCDAO().SelectAllByDistrictID(DistrictID, Select);

        }

        public static VDC GetVDC(int VDCID)
        {
            VDC objVDC = new VDC();
            return (VDC)(new VDCDAO().FillDTO(objVDC, "VDCID=" + VDCID));
        }
    }
}
