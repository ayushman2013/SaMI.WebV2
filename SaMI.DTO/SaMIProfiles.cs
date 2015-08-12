using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_SaMI_profiles")]
    public class SaMIProfiles : BaseDTO
    {
        [ColumnAttribute(Name = "SaMIProfileID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int SaMIProfileID { get; set; }
        [ColumnAttribute(Name = "SaMIProfileNumber", DbType = "VARCHAR NOT NULL")]
        public String SaMIProfileNumber { get; set; }

        [ColumnAttribute(Name = "RegistrationDate", DbType = "DATE")]
        public DateTime RegistrationDate { get; set; }

        [ColumnAttribute(Name = "DistrictID", DbType = "INT NOT NULL")]
        public int DistrictID { get; set; }

        [ColumnAttribute(Name = "Gender", DbType = "VARCHAR NOT NULL")]
        public String Gender { get; set; }
        [ColumnAttribute(Name = "FirstName", DbType = "VARCHAR NOT NULL")]
        public String FirstName { get; set; }
        [ColumnAttribute(Name = "MiddleName", DbType = "VARCHAR")]
        public String MiddleName { get; set; }
        [ColumnAttribute(Name = "LastName", DbType = "VARCHAR NOT NULL")]
        public String LastName { get; set; }
        [ColumnAttribute(Name = "CasteID", DbType = "INT NOT NULL")]
        public int CasteID { get; set; }
        [ColumnAttribute(Name = "IsDiscriminated", DbType = "TINYINT")]
        public int? IsDiscriminated { get; set; }
        
        [ColumnAttribute(Name = "Address", DbType = "VARCHAR NOT NULL")]        
        public String Address { get; set; }
        [ColumnAttribute(Name = "AddressDistrictID", DbType = "INT NOT NULL")]
        public int AddressDistrictID { get; set; }
        [ColumnAttribute(Name = "VDCID", DbType = "INT NOT NULL")]
        public int VDCID { get; set; }
        [ColumnAttribute(Name = "Ward", DbType = "VARCHAR")]
        public String Ward { get; set; }

        [ColumnAttribute(Name = "AddressTemp", DbType = "VARCHAR NOT NULL")]
        public String AddressTemp { get; set; }
        [ColumnAttribute(Name = "AddressDistrictIDTemp", DbType = "INT NOT NULL")]
        public int AddressDistrictIDTemp { get; set; }
        [ColumnAttribute(Name = "VDCIDTemp", DbType = "INT NOT NULL")]
        public int VDCIDTemp { get; set; }
        [ColumnAttribute(Name = "WardTemp", DbType = "VARCHAR")]
        public String WardTemp { get; set; }

        [ColumnAttribute(Name = "VisitorPhone", DbType = "VARCHAR NOT NULL")]        
        public String VisitorPhone { get; set; }
        [ColumnAttribute(Name = "FamilyMemberPhone", DbType = "VARCHAR")]
        public String FamilyMemberPhone { get; set; }

        [ColumnAttribute(Name = "AgeGroupID", DbType = "INT NOT NULL")]
        public int AgeGroupID { get; set; }
        [ColumnAttribute(Name = "EducationalStatusID", DbType = "INT NOT NULL")]
        public int EducationalStatusID { get; set; }
        [ColumnAttribute(Name = "MaritalStatusID", DbType = "INT NOT NULL")]
        public int MaritalStatusID { get; set; }
        [ColumnAttribute(Name = "NoOfChildMale", DbType = "INT NOT NULL")]
        public int NoOfChildMale { get; set; }
        [ColumnAttribute(Name = "NoOfChildFemale", DbType = "INT NOT NULL")]
        public int NoOfChildFemale { get; set; }
        [ColumnAttribute(Name = "NoOfAdultMale", DbType = "INT NOT NULL")]
        public int NoOfAdultMale { get; set; }
        [ColumnAttribute(Name = "NoOfAdultFemale", DbType = "INT NOT NULL")]
        public int NoOfAdultFemale { get; set; }

        [ColumnAttribute(Name = "OccupationTypeID", DbType = "INT NOT NULL")]
        public int OccupationTypeID { get; set; }
        [ColumnAttribute(Name = "InformationSource", DbType = "VARCHAR NOT NULL")]
        public String InformationSource { get; set; }
        [ColumnAttribute(Name = "ICKnowledgeID", DbType = "INT NOT NULL")]
        public int ICKnowledgeID { get; set; }
        [ColumnAttribute(Name = "FrequencyOfVisit", DbType = "INT NOT NULL")]
        public int FrequencyOfVisit { get; set; }
        [ColumnAttribute(Name = "ReasonForVisiting", DbType = "INT NOT NULL")]
        public int ReasonForVisiting { get; set; }
        [ColumnAttribute(Name = "RegistrationNumber", DbType = "VARCHAR")]
        public String RegistrationNumber { get; set; }

        [ColumnAttribute(Name = "GPSLongitude", DbType = "FLOAT")]
        public Decimal? GPSLongitude { get; set; }
        [ColumnAttribute(Name = "GPSLatitude", DbType = "FLOAT")]
        public Decimal? GPSLatitude { get; set; }

        [ColumnAttribute(Name = "ValidRegions", DbType = "VARCHAR")]
        public String ValidRegions { get; set; }
        [ColumnAttribute(Name = "EthnicityID", DbType = "INT")]
        public int EthnicityID { get; set; }
        
        [ColumnAttribute(Name = "Status", DbType = "TINYINT")]
        public int? Status { get; set; }

        [ColumnAttribute(Name = "FamilyHeadName", DbType = "VARCHAR")]
        public String FamilyHeadName { get; set; }
        [ColumnAttribute(Name = "FamilyHeadRelation", DbType = "VARCHAR")]
        public String FamilyHeadRelation { get; set; }
    }
}
