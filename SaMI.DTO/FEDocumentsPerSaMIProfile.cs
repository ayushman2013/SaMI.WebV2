using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_fe_documents_per_SaMI_profile")]
    public class FEDocumentsPerSaMIProfile
    {
        [ColumnAttribute(Name = "FEDocumentPerSaMIProfileID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int FEDocumentPerSaMIProfileID { get; set; }
        [ColumnAttribute(Name = "SaMIProfileID", DbType = "INT NOT NULL")]
        public int SaMIProfileID { get; set; }
        [ColumnAttribute(Name = "DocumentTypeID", DbType = "INT NOT NULL")]
        public int DocumentTypeID { get; set; }
    }
}
