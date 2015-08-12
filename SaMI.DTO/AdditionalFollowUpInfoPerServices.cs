using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_additional_followup_info_per_service")]
    public class AdditionalFollowUpInfoPerServices
    {
        [ColumnAttribute(Name = "AdditionalFollowUpInfoPerServiceID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int AdditionalFollowUpInfoPerServiceID { get; set; }
        [ColumnAttribute(Name = "ServiceProvidedPerSaMIID", DbType = "INT NOT NULL")]
        public int ServiceProvidedPerSaMIID { get; set; }
        [ColumnAttribute(Name = "AdditionalFollowupInfoID", DbType = "INT NOT NULL")]
        public int AdditionalFollowupInfoID { get; set; }

        [ColumnAttribute(Name = "GUID", DbType = "INT")]
        public int GUID { get; set; }
        [ColumnAttribute(Name = "SyncStatus", DbType = "INT")]
        public int SyncStatus { get; set; }
    }
}
