using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DBTools;
using System.Data.Linq.Mapping;
using System.Reflection;
using System.Configuration;
using SaMI.Utilities;
using SaMI.DTO;
using System.Collections;

namespace SaMI.DataAccess
{
    public class BaseDAO
    {
        public int UserId { get; set; }
        public String Table { get; set; }
        public String KeyField { get; set; }
        public MSSqlHelper DBHelper { get; set; }

        public virtual void Initilize()
        {

        }       

        public BaseDAO()
        {
            Initilize();
            DBHelper = new MSSqlHelper();
        }

        public BaseDAO(MSSqlHelper objDBHelper)
        {
            Initilize();
            DBHelper = objDBHelper;
        }

        public BaseDAO(String ConnectionStringName)
        {
            Initilize();
            DBHelper = new MSSqlHelper(ConnectionStringName);
        }

        public DataView GetServerDate()
        {
            String query = "SELECT GetDate() as 'datetime'";
            return ExecuteQuery(query);
        }

        public static String FormatDate(DateTime? strDate)
        {
            if (strDate != null)
                return ((DateTime)strDate).ToString("MM/dd/yyyy hh:mm:ss");
            else
                return null;
        }

        public DateTime GetCurrentDate()
        {
            DataView dv = GetServerDate();
            return Convert.ToDateTime(dv.Table.Rows[0]["datetime"].ToString());
        }

        public Boolean CheckDBConnection()
        {
            return DBHelper.CheckDBConnection();
        }

        public DataView Select(String strSelect = "", String strFrom = "", String strWhere = "")
        {
            DBHelper.Reset();
            if (strFrom != "")
                DBHelper.SQLFrom = strFrom;
            else
                DBHelper.SQLFrom = Table;
            if (strSelect != "")
                DBHelper.SQLSelect = strSelect;
            if (strWhere != "")
                DBHelper.SQLWhere = strWhere;
            return DBHelper.ExecuteSelect();
        }

        public DataView SelectAll(String strWhere = "")
        {
            DBHelper.Reset();
            DBHelper.SQLFrom = Table;
            if (strWhere != "")
                DBHelper.SQLWhere = strWhere;
            return DBHelper.ExecuteSelect();
        }

        public int ExecuteNonQuery(String strquery)
        {
            return DBHelper.ExecuteNonQuery(strquery);
        }

        public DataView ExecuteQuery(String strquery)
        {
            DataView objDataView = new DataView();
            objDataView = DBHelper.ExecuteQuery(strquery);

            return objDataView;
        }

        public int ExecuteInsert(String strFrom, String strInsertFields, String strInsertValues, String stKeyField)
        {
            int newid = -1;
            if ((strInsertFields != "") && (strFrom != "") && (strInsertValues != ""))
            {
                //strInsertFields = strInsertFields + ",rcd_date,rud_date,version_no";
                //strInsertValues = strInsertValues + ",NOW(),NOW(),1";
                DBHelper.Reset();
                DBHelper.KeyField = stKeyField;
                DBHelper.SQLFrom = strFrom;
                DBHelper.SQLInsertFields = strInsertFields;
                DBHelper.SQLInsertValues = strInsertValues;
                newid = DBHelper.ExecuteInsert();
            }
            return newid;
        }

        public int ExecuteUpdate(String strFrom, String strSet, String strWhere)
        {
            int rowaffected = -1;
            if ((strFrom != "") && (strSet != "") && (strWhere != ""))
            {

                //strSet = strSet + ",rud_date=NOW(),version_no=version_no+1";
                DBHelper.Reset();
                DBHelper.SQLFrom = strFrom;
                DBHelper.SQLSet = strSet;
                DBHelper.SQLWhere = strWhere;
                rowaffected = DBHelper.ExecuteUpdate();
            }
            return rowaffected;
        }

        private bool IsUpdateProperty(String[] DTOProperties, String Property)
        {
            bool ret = false;
            foreach (String DTOProperty in DTOProperties)
            {
                if (DTOProperty == Property)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        public object FillDTO(object objDTO)
        {
            String strWhere = "1=1";
            Type DTOtype = objDTO.GetType();
            PropertyInfo[] DTOTypeProperties = DTOtype.GetProperties();
            var arrPrperty = from property in DTOTypeProperties
                             where ((ColumnAttribute)(property.GetCustomAttributes(typeof(ColumnAttribute), true)[0])).IsPrimaryKey == true
                             select property;
            foreach (PropertyInfo prp in arrPrperty)
                if (prp.GetValue(objDTO, null) != null)
                    strWhere = ((ColumnAttribute)(prp.GetCustomAttributes(typeof(ColumnAttribute), true)[0])).Name + "='" + Convert.ToString(prp.GetValue(objDTO, null)) + "'";
            return FillDTO(objDTO, strWhere);
        }

        public object FillDTO(object objDTO, String strWhere, String strSelect = "")
        {
            String Table = "";

            ColumnAttribute propertyAttr;
            TableAttribute classAttr;
            object[] property_attributes;
            object[] class_attributes;

            Type DTOtype = objDTO.GetType();

            class_attributes = DTOtype.GetCustomAttributes(typeof(TableAttribute), true);
            classAttr = (TableAttribute)class_attributes[0];
            Table = classAttr.Name;

            DataView dv = new DataView();

            if(strWhere == string.Empty)
                dv = ExecuteQuery("SELECT TOP 1 * FROM " + Table);
            else if (strSelect == "")
                dv = ExecuteQuery("SELECT TOP 1 * FROM " + Table + " WHERE " + strWhere);
            else
                dv = ExecuteQuery("SELECT TOP 1 " + strSelect + " FROM " + Table + " WHERE " + strWhere);

            if (dv.Table.Rows.Count > 0)
            {
                DataRow objRow = dv.Table.Rows[0];

                PropertyInfo[] DTOTypeProperties = DTOtype.GetProperties();

                foreach (PropertyInfo property in DTOTypeProperties)
                {
                    property_attributes = property.GetCustomAttributes(typeof(ColumnAttribute), true);

                    if (property_attributes != null && property_attributes.Length == 1)
                    {

                        // Check if the attribute has a database field name      
                        propertyAttr = (ColumnAttribute)property_attributes[0];

                        //if (propertyAttr != null && propertyAttr.IsPrimaryKey)
                        //    KeyField = propertyAttr.Name;

                        if (propertyAttr != null & !objRow.IsNull(propertyAttr.Name))
                        {

                            switch (propertyAttr.DbType.ToUpper().Trim().Replace("  ", " "))
                            {
                                case "TEXT":
                                case "TEXT NOT NULL":
                                case "VARCHAR":
                                case "VARCHAR NOT NULL":
                                case "VARBINARY":
                                case "VARBINARY NOT NULL":
                                case "CHAR NOT NULL":
                                case "CHAR":
                                case "LONGTEXT":
                                case "LONGTEXT NOT NULL":

                                    property.SetValue(objDTO, Convert.ToString(objRow[propertyAttr.Name]), null);
                                    break;
                                case "INT":
                                case "TINYINT":
                                case "INT NOT NULL":
                                case "TINYINT NOT NULL":

                                    property.SetValue(objDTO, Convert.ToInt32(objRow[propertyAttr.Name]), null);
                                    break;
                                case "FLOAT":
                                case "FLOAT NOT NULL":
                                case "DECIMAL":
                                case "DECIMAL NOT NULL":
                                    property.SetValue(objDTO, Convert.ToDecimal(objRow[propertyAttr.Name]), null);
                                    break;
                                case "DATE":
                                case "DATETIME":
                                case "DATE NOT NULL":
                                case "DATETIME NOT NULL":
                                    property.SetValue(objDTO, Convert.ToDateTime(objRow[propertyAttr.Name]), null);
                                    break;
                                default:
                                    break;
                            }

                        }

                    }
                }
            }

            return objDTO;
        }

        public object FillDTOBySql(object objDTO, String sql)
        {
            String Table = "";

            ColumnAttribute propertyAttr;
            TableAttribute classAttr;
            object[] property_attributes;
            object[] class_attributes;

            Type DTOtype = objDTO.GetType();

            class_attributes = DTOtype.GetCustomAttributes(typeof(TableAttribute), true);
            classAttr = (TableAttribute)class_attributes[0];
            Table = classAttr.Name;

            DataView dv = new DataView();
            
            dv = ExecuteQuery(sql);
           

            if (dv.Table.Rows.Count > 0)
            {
                DataRow objRow = dv.Table.Rows[0];

                PropertyInfo[] DTOTypeProperties = DTOtype.GetProperties();

                foreach (PropertyInfo property in DTOTypeProperties)
                {
                    property_attributes = property.GetCustomAttributes(typeof(ColumnAttribute), true);

                    if (property_attributes != null && property_attributes.Length == 1)
                    {

                        // Check if the attribute has a database field name      
                        propertyAttr = (ColumnAttribute)property_attributes[0];

                        //if (propertyAttr != null && propertyAttr.IsPrimaryKey)
                        //    KeyField = propertyAttr.Name;

                        if (propertyAttr != null & !objRow.IsNull(propertyAttr.Name))
                        {

                            switch (propertyAttr.DbType.ToUpper().Trim().Replace("  ", " "))
                            {
                                case "TEXT":
                                case "TEXT NOT NULL":
                                case "VARCHAR":
                                case "VARCHAR NOT NULL":
                                case "VARBINARY":
                                case "VARBINARY NOT NULL":
                                case "CHAR NOT NULL":
                                case "CHAR":
                                case "LONGTEXT":
                                case "LONGTEXT NOT NULL":

                                    property.SetValue(objDTO, Convert.ToString(objRow[propertyAttr.Name]), null);
                                    break;
                                case "INT":
                                case "TINYINT":
                                case "INT NOT NULL":
                                case "TINYINT NOT NULL":

                                    property.SetValue(objDTO, Convert.ToInt32(objRow[propertyAttr.Name]), null);
                                    break;
                                case "FLOAT":
                                case "FLOAT NOT NULL":
                                case "DECIMAL":
                                case "DECIMAL NOT NULL":
                                    property.SetValue(objDTO, Convert.ToDecimal(objRow[propertyAttr.Name]), null);
                                    break;
                                case "DATE":
                                case "DATETIME":
                                case "DATE NOT NULL":
                                case "DATETIME NOT NULL":
                                    property.SetValue(objDTO, Convert.ToDateTime(objRow[propertyAttr.Name]), null);
                                    break;
                                default:
                                    break;
                            }

                        }

                    }
                }
            }

            return objDTO;
        }

        public int Delete(String strWhere)
        {
            int rowaffected = -1;
            DBHelper.Reset();
            DBHelper.SQLFrom = Table;
            if (strWhere != "")
                DBHelper.SQLWhere = strWhere;
            try
            {
                rowaffected = DBHelper.ExecuteDelete();
            }
            catch (Exception ex)
            {
                rowaffected = -1;
            }

            return rowaffected;
        }

        public int Delete(String strTable, String strWhere)
        {
            DBHelper.Reset();
            DBHelper.SQLFrom = strTable;
            if (strWhere != "")
                DBHelper.SQLWhere = strWhere;
            return DBHelper.ExecuteDelete();
        }

        public int Update(object objDTO, String[] DTOProperties)
        {
            String strFrom = "";
            String strSet = "";
            String strWhere = "";

            ColumnAttribute propertyAttr;
            TableAttribute classAttr;
            object[] property_attributes;
            object[] class_attributes;

            Type DTOtype = objDTO.GetType();


            //DTOProperties = DTOProperties.Concat(new String[] { "RUDUser" }).ToArray<String>();

            class_attributes = DTOtype.GetCustomAttributes(typeof(TableAttribute), true);
            classAttr = (TableAttribute)class_attributes[0];
            strFrom = classAttr.Name;

            PropertyInfo[] DTOTypeProperties = DTOtype.GetProperties();

            foreach (PropertyInfo property in DTOTypeProperties)
            {
                property_attributes = property.GetCustomAttributes(typeof(ColumnAttribute), true);

                if (property_attributes != null && property_attributes.Length == 1)
                {

                    // Check if the attribute has a database field name      
                    propertyAttr = (ColumnAttribute)property_attributes[0];

                    if (propertyAttr != null && propertyAttr.IsPrimaryKey)
                        strWhere = propertyAttr.Name + "=" + EscapeSpecialCharacter(Convert.ToString(property.GetValue(objDTO, null)));

                    if (propertyAttr != null & !propertyAttr.IsPrimaryKey & IsUpdateProperty(DTOProperties, property.Name))
                    {

                        switch (propertyAttr.DbType.ToUpper().Trim().Replace("  ", " "))
                        {
                            case "VARCHAR":
                            case "VARCHAR NOT NULL":
                            case "VARBINARY":
                            case "VARBINARY NOT NULL":
                            case "CHAR NOT NULL":
                            case "CHAR":
                            case "LONGTEXT":
                            case "LONGTEXT NOT NULL":
                            case "TEXT":
                            case "TEXT NOT NULL":


                                if (property.GetValue(objDTO, null) != null)
                                {
                                    strSet = strSet + propertyAttr.Name + "='" + EscapeSpecialCharacter(Convert.ToString(property.GetValue(objDTO, null))) + "',";
                                }
                                break;
                            case "INT":
                            case "TINYINT":
                                if ((int?)(property.GetValue(objDTO, null)) != null)
                                {
                                    strSet = strSet + propertyAttr.Name + "=" + Convert.ToInt32(property.GetValue(objDTO, null)) + ",";
                                }
                                break;
                            case "DECIMAL":
                                if ((decimal?)(property.GetValue(objDTO, null)) != null)
                                {
                                    strSet = strSet + propertyAttr.Name + "=" + Convert.ToDecimal(property.GetValue(objDTO, null)) + ",";
                                }
                                break;
                            case "FLOAT":
                                try
                                {
                                    if ((float?)(property.GetValue(objDTO, null)) != null)
                                    {
                                        strSet = strSet + propertyAttr.Name + "=" + Convert.ToDecimal(property.GetValue(objDTO, null)) + ",";
                                    }
                                }
                                catch (Exception e)
                                {
                                    if ((decimal?)(property.GetValue(objDTO, null)) != null)
                                    {
                                        strSet = strSet + propertyAttr.Name + "=" + Convert.ToDecimal(property.GetValue(objDTO, null)) + ",";
                                    }
                                }
                                break;
                            case "INT NOT NULL":
                            case "TINYINT NOT NULL":
                                strSet = strSet + propertyAttr.Name + "=" + Convert.ToInt32(property.GetValue(objDTO, null)) + ",";
                                break;
                            case "DECIMAL NOT NULL":
                            case "FLOAT NOT NULL":
                                strSet = strSet + propertyAttr.Name + "=" + Convert.ToDecimal(property.GetValue(objDTO, null)) + ",";
                                break;


                            case "DATE":
                            case "DATETIME":
                                if (Convert.ToDateTime(property.GetValue(objDTO, null)) != null)
                                {
                                    strSet = strSet + propertyAttr.Name + "='" + FormatDate(Convert.ToDateTime(property.GetValue(objDTO, null))) + "',";
                                }
                                break;
                            case "DATE NOT NULL":
                            case "DATETIME NOT NULL":

                                strSet = strSet + propertyAttr.Name + "='" + FormatDate(Convert.ToDateTime(property.GetValue(objDTO, null))) + "',";
                                break;
                            default:
                                break;
                        }

                    }

                }
            }

            char[] strCommas = new char[] { ',' };
            strSet = strSet.TrimEnd(strCommas);

            return ExecuteUpdate(strFrom, strSet, strWhere);
        }

        public int Insert(object objDTO)
        {
            String Table = "";
            String KeyField = "";
            String strInsertFields = "";
            String strInsertValues = "";

            ColumnAttribute propertyAttr;
            TableAttribute classAttr;
            object[] property_attributes;
            object[] class_attributes;

            Type DTOtype = objDTO.GetType();

            class_attributes = DTOtype.GetCustomAttributes(typeof(TableAttribute), true);
            classAttr = (TableAttribute)class_attributes[0];
            Table = classAttr.Name;

            PropertyInfo[] DTOTypeProperties = DTOtype.GetProperties();

            foreach (PropertyInfo property in DTOTypeProperties)
            {
                property_attributes = property.GetCustomAttributes(typeof(ColumnAttribute), true);

                if (property_attributes != null && property_attributes.Length == 1)
                {

                    // Check if the attribute has a database field name      
                    propertyAttr = (ColumnAttribute)property_attributes[0];

                    if (propertyAttr != null && propertyAttr.IsPrimaryKey)
                        KeyField = propertyAttr.Name;

                    if (propertyAttr != null & !propertyAttr.IsPrimaryKey)
                    {

                        switch (propertyAttr.DbType.ToUpper().Trim().Replace("  ", " "))
                        {
                            case "LONGTEXT":
                            case "LONGTEXT NOT NULL":
                            case "TEXT":
                            case "TEXT NOT NULL":
                            case "VARCHAR":
                            case "VARCHAR NOT NULL":
                            case "VARBINARY":
                            case "VARBINARY NOT NULL":
                            case "CHAR NOT NULL":
                            case "CHAR":
                                if (property.GetValue(objDTO, null) != null)
                                {
                                    strInsertFields = strInsertFields + propertyAttr.Name + ",";
                                    strInsertValues = strInsertValues + "'" + EscapeSpecialCharacter(Convert.ToString(property.GetValue(objDTO, null))) + "',";
                                }
                                break;
                            case "INT":
                            case "TINYINT":
                                if ((int?)(property.GetValue(objDTO, null)) != null)
                                {
                                    strInsertFields = strInsertFields + propertyAttr.Name + ",";
                                    strInsertValues = strInsertValues + Convert.ToInt32(property.GetValue(objDTO, null)) + ",";
                                }
                                break;
                            case "INT NOT NULL":
                            case "TINYINT NOT NULL":
                                strInsertFields = strInsertFields + propertyAttr.Name + ",";
                                strInsertValues = strInsertValues + Convert.ToInt32(property.GetValue(objDTO, null)) + ",";
                                break;
                            case "DECIMAL":
                                if ((decimal?)(property.GetValue(objDTO, null)) != null)
                                {
                                    strInsertFields = strInsertFields + propertyAttr.Name + ",";
                                    strInsertValues = strInsertValues + Convert.ToDecimal(property.GetValue(objDTO, null)) + ",";
                                }
                                break;
                            case "FLOAT":
                                try
                                {
                                    if ((float?)(property.GetValue(objDTO, null)) != null)
                                    {
                                        strInsertFields = strInsertFields + propertyAttr.Name + ",";
                                        strInsertValues = strInsertValues + Convert.ToDecimal(property.GetValue(objDTO, null)) + ",";
                                    }
                                }
                                catch (Exception e)
                                {
                                    if ((decimal?)(property.GetValue(objDTO, null)) != null)
                                    {
                                        strInsertFields = strInsertFields + propertyAttr.Name + ",";
                                        strInsertValues = strInsertValues + Convert.ToDecimal(property.GetValue(objDTO, null)) + ",";
                                    }
                                }
                                break;
                            case "DECIMAL NOT NULL":
                            case "FLOAT NOT NULL":
                                strInsertFields = strInsertFields + propertyAttr.Name + ",";
                                strInsertValues = strInsertValues + Convert.ToDecimal(property.GetValue(objDTO, null)) + ",";

                                break;
                            case "DATE":
                            case "DATETIME":
                                if ((DateTime?)(property.GetValue(objDTO, null)) != null)
                                {
                                    strInsertFields = strInsertFields + propertyAttr.Name + ",";
                                    strInsertValues = strInsertValues + "'" + FormatDate(Convert.ToDateTime(property.GetValue(objDTO, null))) + "',";
                                }
                                break;
                            case "DATE NOT NULL":
                            case "DATETIME NOT NULL":
                                if (Convert.ToDateTime(property.GetValue(objDTO, null)) != null)
                                {
                                    strInsertFields = strInsertFields + propertyAttr.Name + ",";
                                    strInsertValues = strInsertValues + "'" + FormatDate(Convert.ToDateTime(property.GetValue(objDTO, null))) + "',";
                                }
                                break;
                            default:
                                break;
                        }

                    }

                }
            }

            char[] strCommas = new char[] { ',' };
            strInsertFields = strInsertFields.TrimEnd(strCommas);
            strInsertValues = strInsertValues.TrimEnd(strCommas);

            return ExecuteInsert(Table, strInsertFields, strInsertValues, KeyField);
        }

        public String EscapeSpecialCharacter(String strFieldValue)
        {
            return strFieldValue.Replace("'", "''");

        }
        
        public void BeginTransaction()
        {
            DBHelper.BeginTransaction();
        }

        public void CommitTransaction()
        {
            DBHelper.Commit();
        }

        public void RollBackTransaction()
        {
            DBHelper.RollBack();
        }

        public int SPInsertUpdate(String ProcName, object objDTO, String[] DTOProperties, String Type = "INSERT")
        {

            ArrayList paramField = new ArrayList();
            ArrayList paramValue = new ArrayList();
            ColumnAttribute propertyAttr;
            TableAttribute classAttr;
            object[] property_attributes;
            object[] class_attributes;

            Type DTOtype = objDTO.GetType();

            class_attributes = DTOtype.GetCustomAttributes(typeof(TableAttribute), true);
            classAttr = (TableAttribute)class_attributes[0];

            PropertyInfo[] DTOTypeProperties = DTOtype.GetProperties();

            foreach (PropertyInfo property in DTOTypeProperties)
            {
                property_attributes = property.GetCustomAttributes(typeof(ColumnAttribute), true);

                if (property_attributes != null && property_attributes.Length == 1)
                {

                    // Check if the attribute has a database field name      
                    propertyAttr = (ColumnAttribute)property_attributes[0];

                    if (propertyAttr != null && propertyAttr.IsPrimaryKey)
                    {
                        if (Type != "INSERT")
                        {
                            paramField.Add("@" + propertyAttr.Name);
                            paramValue.Add(Convert.ToInt32(property.GetValue(objDTO, null)));
                        }
                    }

                    if (propertyAttr != null & !propertyAttr.IsPrimaryKey & IsUpdateProperty(DTOProperties, property.Name))
                    {
                        switch (propertyAttr.DbType.ToUpper().Trim().Replace("  ", " "))
                        {
                            case "VARCHAR":
                            case "VARCHAR NOT NULL":
                            case "VARBINARY":
                            case "VARBINARY NOT NULL":
                            case "CHAR NOT NULL":
                            case "CHAR":
                            case "LONGTEXT":
                            case "LONGTEXT NOT NULL":
                            case "TEXT":
                            case "TEXT NOT NULL":
                                if (property.GetValue(objDTO, null) != null)
                                {
                                    paramField.Add("@" + propertyAttr.Name);
                                    paramValue.Add(EscapeSpecialCharacter(Convert.ToString(property.GetValue(objDTO, null))));

                                }
                                else
                                {
                                    paramField.Add("@" + propertyAttr.Name);
                                    paramValue.Add(null);
                                }

                                break;
                            case "INT":
                            case "TINYINT":
                                if ((int?)(property.GetValue(objDTO, null)) != null)
                                {
                                    paramField.Add("@" + propertyAttr.Name);
                                    paramValue.Add(Convert.ToInt32(property.GetValue(objDTO, null)));
                                }
                                else
                                {
                                    paramField.Add("@" + propertyAttr.Name);
                                    paramValue.Add(null);
                                }
                                break;
                            case "DECIMAL":
                                if ((decimal?)(property.GetValue(objDTO, null)) != null)
                                {
                                    paramField.Add("@" + propertyAttr.Name);
                                    paramValue.Add(Convert.ToDecimal(property.GetValue(objDTO, null)));
                                }
                                else
                                {
                                    paramField.Add("@" + propertyAttr.Name);
                                    paramValue.Add(null);
                                }
                                break;
                            case "FLOAT":
                                try
                                {
                                    if ((float?)(property.GetValue(objDTO, null)) != null)
                                    {
                                        paramField.Add("@" + propertyAttr.Name);
                                        paramValue.Add(Convert.ToDecimal(property.GetValue(objDTO, null)));
                                    }
                                    else
                                    {
                                        paramField.Add("@" + propertyAttr.Name);
                                        paramValue.Add(null);
                                    }
                                }
                                catch (Exception e)
                                {
                                    if ((decimal?)(property.GetValue(objDTO, null)) != null)
                                    {
                                        paramField.Add("@" + propertyAttr.Name);
                                        paramValue.Add(Convert.ToDecimal(property.GetValue(objDTO, null)));
                                    }
                                    else
                                    {
                                        paramField.Add("@" + propertyAttr.Name);
                                        paramValue.Add(null);
                                    }
                                }
                                break;
                            case "INT NOT NULL":
                            case "TINYINT NOT NULL":
                                paramField.Add("@" + propertyAttr.Name);
                                paramValue.Add(Convert.ToInt32(property.GetValue(objDTO, null)));
                                break;
                            case "DECIMAL NOT NULL":
                            case "FLOAT NOT NULL":
                                paramField.Add("@" + propertyAttr.Name);
                                paramValue.Add(Convert.ToDecimal(property.GetValue(objDTO, null)));
                                break;


                            case "DATE":
                            case "DATETIME":
                                if (Convert.ToDateTime(property.GetValue(objDTO, null)) != null)
                                {
                                    paramField.Add("@" + propertyAttr.Name);
                                    paramValue.Add(FormatDate(Convert.ToDateTime(property.GetValue(objDTO, null))));
                                }
                                else
                                {
                                    paramField.Add("@" + propertyAttr.Name);
                                    paramValue.Add(null);
                                }
                                break;
                            case "DATE NOT NULL":
                            case "DATETIME NOT NULL":
                                paramField.Add("@" + propertyAttr.Name);
                                paramValue.Add(FormatDate(Convert.ToDateTime(property.GetValue(objDTO, null))));
                                break;
                            default:
                                break;
                        }

                    }

                }
            }


            return DBHelper.ExecuteInsertUpdateStoredProc(ProcName, paramField, paramValue);
        }

        public int ExecuteDeleteStoredProc(String ProcName, String KeyID)
        {
            ArrayList paramField = new ArrayList();
            ArrayList paramValue = new ArrayList();

            paramField.Add("@" + KeyField);
            paramValue.Add(KeyID);

            return DBHelper.ExecuteInsertUpdateStoredProc(ProcName, paramField, paramValue);
        }

        public object FillDTO(object objDTO, String ProcName, ArrayList paramField, ArrayList paramValue)
        {
            String Table = "";

            ColumnAttribute propertyAttr;
            TableAttribute classAttr;
            object[] property_attributes;
            object[] class_attributes;

            Type DTOtype = objDTO.GetType();

            class_attributes = DTOtype.GetCustomAttributes(typeof(TableAttribute), true);
            classAttr = (TableAttribute)class_attributes[0];
            Table = classAttr.Name;

            DataView dv = new DataView();

            dv = DBHelper.ExecuteStoredProc(ProcName, paramField, paramValue);

            if (dv.Table.Rows.Count > 0)
            {
                DataRow objRow = dv.Table.Rows[0];

                PropertyInfo[] DTOTypeProperties = DTOtype.GetProperties();

                foreach (PropertyInfo property in DTOTypeProperties)
                {
                    property_attributes = property.GetCustomAttributes(typeof(ColumnAttribute), true);

                    if (property_attributes != null && property_attributes.Length == 1)
                    {

                        // Check if the attribute has a database field name      
                        propertyAttr = (ColumnAttribute)property_attributes[0];

                        //if (propertyAttr != null && propertyAttr.IsPrimaryKey)
                        //    KeyField = propertyAttr.Name;

                        if (propertyAttr != null & !objRow.IsNull(propertyAttr.Name))
                        {

                            switch (propertyAttr.DbType.ToUpper().Trim().Replace("  ", " "))
                            {
                                case "TEXT":
                                case "TEXT NOT NULL":
                                case "VARCHAR":
                                case "VARCHAR NOT NULL":
                                case "VARBINARY":
                                case "VARBINARY NOT NULL":
                                case "CHAR NOT NULL":
                                case "CHAR":
                                case "LONGTEXT":
                                case "LONGTEXT NOT NULL":

                                    property.SetValue(objDTO, Convert.ToString(objRow[propertyAttr.Name]), null);
                                    break;
                                case "INT":
                                case "TINYINT":
                                case "INT NOT NULL":
                                case "TINYINT NOT NULL":

                                    property.SetValue(objDTO, Convert.ToInt32(objRow[propertyAttr.Name]), null);
                                    break;
                                case "FLOAT":
                                case "FLOAT NOT NULL":
                                case "DECIMAL":
                                case "DECIMAL NOT NULL":
                                    property.SetValue(objDTO, Convert.ToDecimal(objRow[propertyAttr.Name]), null);
                                    break;
                                case "DATE":
                                case "DATETIME":
                                case "DATE NOT NULL":
                                case "DATETIME NOT NULL":
                                    property.SetValue(objDTO, Convert.ToDateTime(objRow[propertyAttr.Name]), null);
                                    break;
                                default:
                                    break;
                            }

                        }

                    }
                }
            }

            return objDTO;
        }

        
    }
}
