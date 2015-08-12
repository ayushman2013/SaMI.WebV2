using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "TRNTrainingAgency")]
    public class TRNTrainingAgency:TRNBaseDTO
    {
        [ColumnAttribute(Name = "ID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int AgencyID { get; set; }

        [ColumnAttribute(Name = "TrainingAgency", DbType = "VARCHAR NOT NULL")]
        public String TrainingAgency { get; set; }

        [ColumnAttribute(Name = "Address", DbType = "VARCHAR")]
        public String Address { get; set; }

        [ColumnAttribute(Name = "Phone", DbType = "VARCHAR")]
        public String Phone { get; set; }

        [ColumnAttribute(Name = "ContactPerson", DbType = "VARCHAR")]
        public String ContactPerson { get; set; }

        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }

    }
}
