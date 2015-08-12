using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;


namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_cases")]
    public class Cases : BaseDTO
    {
        [ColumnAttribute(Name = "CaseID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int CaseID { get; set; }
        [ColumnAttribute(Name = "CaseProfileID", DbType = "INT NOT NULL")]
        public int CaseProfileID { get; set; }
        [ColumnAttribute(Name = "CaseTypeID", DbType = "INT NOT NULL")]
        public int CaseTypeID { get; set; }
        [ColumnAttribute(Name = "CaseNumber", DbType = "VARCHAR NOT NULL")]
        public String CaseNumber { get; set; }
        [ColumnAttribute(Name = "NameOfOpponent", DbType = "VARCHAR NOT NULL")]
        public String NameOfOpponent { get; set; }
        [ColumnAttribute(Name = "Description", DbType = "TEXT NOT NULL")]
        public String Description { get; set; }
        [ColumnAttribute(Name = "PartnerID", DbType = "INT NOT NULL")]
        public int PartnerID { get; set; }
        [ColumnAttribute(Name = "CaseRegistrarID", DbType = "INT NOT NULL")]
        public int CaseRegistrarID { get; set; }
        [ColumnAttribute(Name = "ResponsibleStaff", DbType = "VARCHAR NOT NULL")]
        public String ResponsibleStaff { get; set; }
        [ColumnAttribute(Name = "CaseStatusTypeID", DbType = "INT NOT NULL")]
        public int CaseStatusTypeID { get; set; }
        [ColumnAttribute(Name = "CompensationAmount", DbType = "INT")]
        public int? CompensationAmount { get; set; }
        [ColumnAttribute(Name = "OutputDetails", DbType = "TEXT")]
        public String OutputDetails { get; set; }
        [ColumnAttribute(Name = "CaseRegisteredDate", DbType = "DATETIME NOT NULL")]
        public DateTime CaseRegisteredDate { get; set; }

    }
}
