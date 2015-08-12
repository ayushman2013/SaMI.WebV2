using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_previous_fe_experiences")]
    public class PreviousFEExperiences : BaseDTO
    {
        [ColumnAttribute(Name = "ForeignEmploymentExperienceID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int ForeignEmploymentExperienceID { get; set; }
        [ColumnAttribute(Name = "SaMIProfileID", DbType = "INT NOT NULL")]
        public int SaMIProfileID { get; set; }
        [ColumnAttribute(Name = "CountryID", DbType = "INT NOT NULL")]
        public int CountryID { get; set; }       
        [ColumnAttribute(Name = "DestinationAirportID", DbType = "INT NOT NULL")]
        public int DestinationAirportID { get; set; }
        [ColumnAttribute(Name = "JobOfferedTypeID", DbType = "INT")]
        public int JobOfferedType { get; set; }
        [ColumnAttribute(Name = "StayDuration", DbType = "VARCHAR")]
        public String StayDuration { get; set; }

        [ColumnAttribute(Name = "Status", DbType = "TINYINT")]
        public int Status { get; set; }


    }
}
