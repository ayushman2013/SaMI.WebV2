using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq.Mapping;


namespace SaMI.DTO
{
    [TableAttribute(Name = "TRNPreviousTraining")]
    public class TRNPreviousTraining
    {
        [ColumnAttribute(Name = "ID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int PreviousTrainingID { get; set; }

        [ColumnAttribute(Name = "TraineeID", DbType = "INT NOT NULL")]
        public int TraineeID { get; set; }

        [ColumnAttribute(Name = "Name", DbType = "VARCHAR")]
        public String Name { get; set; }

        [ColumnAttribute(Name = "Year", DbType = "VARCHAR")]
        public String Year { get; set; }

        [ColumnAttribute(Name = "Institute", DbType = "VARCHAR")]
        public String Institute { get; set; }

        [ColumnAttribute(Name = "Duration", DbType = "VARCHAR")]
        public String Duration { get; set; }
    }
}
