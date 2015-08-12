using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "TRNTrainingEvent")]
    public class TRNTrainingEvent : TRNBaseDTO
    {
        [ColumnAttribute(Name = "ID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int EventID { get; set; }

        [ColumnAttribute(Name = "TrainingAgencyID", DbType = "INT NOT NULL")]
        public int TrainingAgencyID { get; set; }

        [ColumnAttribute(Name = "EventID", DbType = "VARCHAR")]
        public String Event { get; set; }

        [ColumnAttribute(Name = "Batch", DbType = "VARCHAR")]
        public String Batch { get; set; }

        [ColumnAttribute(Name = "TradeNameID", DbType = "INT NOT NULL")]
        public int TradeNameID { get; set; }

        [ColumnAttribute(Name = "StartDate", DbType = "DATE")]
        public DateTime StartDate { get; set; }

        [ColumnAttribute(Name = "EndDate", DbType = "DATE")]
        public DateTime EndDate { get; set; }

        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }

        [ColumnAttribute(Name = "CostSharing", DbType = "INT")]
        public int CostSharing { get; set; }

        [ColumnAttribute(Name = "Regular", DbType = "INT")]
        public int Regular { get; set; }
    }

}
