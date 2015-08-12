using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_other_info_per_SaMI_profile")]
    public class OtherInfoPerSaMIProfile : BaseDTO
    {
        [ColumnAttribute(Name = "OtherInfoPerSaMIProfileID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int OtherInfoPerSaMIProfileID { get; set; }
        [ColumnAttribute(Name = "SaMIProfileID", DbType = "INT NOT NULL")]
        public int SaMIProfileID { get; set; }
        [ColumnAttribute(Name = "HaveExperienceORTraining", DbType = "TINYINT NOT NULL")]
        public int HaveExperienceORTraining { get; set; }
        [ColumnAttribute(Name = "HaveJobExperience", DbType = "TINYINT NOT NULL")]
        public int HaveJobExperience { get; set; }
        [ColumnAttribute(Name = "IsPreviousForeignExperienced", DbType = "TINYINT NOT NULL")]
        public int IsPreviousForeignExperienced { get; set; }
        
    }
}
