using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_counselor_difficulties_per_service")]
    public class CounselorDifficultiesPerService
    {
        [ColumnAttribute(Name = "CounseloDifficultyPerServiceID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int CounseloDifficultyPerServiceID { get; set; }
        [ColumnAttribute(Name = "ServiceProvidedPerSaMIID", DbType = "INT NOT NULL")]
        public int ServiceProvidedPerSaMIID { get; set; }
        [ColumnAttribute(Name = "CounselorDifficultyID", DbType = "INT NOT NULL")]
        public int CounselorDifficultyID { get; set; }
    }
}
