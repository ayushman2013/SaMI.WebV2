using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute (Name= "tbl_counselor_difficulties")]
    public class CounselorDifficulties : BaseDTO
    {
        [ColumnAttribute(Name = "CounselorDifficultyID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int CounselorDifficultyID { get; set; }
        [ColumnAttribute(Name = "CounselorDifficultyDesc", DbType = "VARCHAR NOT NULL")]
        public string CounselorDifficultyDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
