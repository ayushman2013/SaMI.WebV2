using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using SaMI.Utilities;

namespace SaMI.DBTools
{
    public class MSSqlHelper
    {
        #region members
		private string strConnectionString;
		private string strSQLSelect="";
		private string strSQLFrom="";
		private string strSQLWhere="1=1";
		private string strSQLOrderBy="";
		private string strSQLHaving="";
		private string strSQLGroupBy="";
		private string strSQLSet="";
		private string strSQLInsertFields="";
		private string strSQLInsertValues="";
        
		//private ArrayList arlSQLTransaction = new ArrayList();	
		private DataSet dsData=new DataSet();
		
		#endregion


		#region properties
		
        public string KeyField { get; set; }
        public string KeyValue { get; set; }
		public string ConnectionString
		{
			get{return strConnectionString;}
			set{strConnectionString=value;}
		}
		
		public string SQLSelect
		{
			get{return strSQLSelect;}
			set{strSQLSelect=value;}
		}

		public string SQLFrom
		{
			get{return strSQLFrom;}
			set{strSQLFrom=value;}
		}

		public string SQLWhere
		{
			get{return strSQLWhere;}
			set{strSQLWhere=value;}
		}
		public string SQLOrderBy
		{
			get{return strSQLOrderBy;}
			set{strSQLOrderBy=value;}
		}
		public string SQLHaving
		{
			get{return strSQLHaving;}
			set{strSQLHaving=value;}
		}
		public string SQLGroupBy
		{
			get{return strSQLGroupBy;}
			set{strSQLGroupBy=value;}
		}
		public string SQLSet
		{
			get{return strSQLSet;}
			set{strSQLSet=value;}
		}
		public string SQLInsertFields
		{
			get{return strSQLInsertFields;}
			set{strSQLInsertFields=value;}
		}
		public string SQLInsertValues
		{
			get{return strSQLInsertValues;}
			set{strSQLInsertValues=value;}
		}
		public DataSet Data
		{
			get{return dsData;}
			set{dsData=value;}
		}
		/*public ArrayList SQLTransaction
		{
			get{return arlSQLTransaction;}
			set{arlSQLTransaction=value;}
		}*/

        public bool TransactionMode { get; set; }
        public SqlConnection Con { get; set; }
        public SqlCommand Cmd { get; set; }
        public SqlTransaction Tran { get; set; }
        public SqlDataAdapter DA { get; set; }

		#endregion	

		#region methods


        public MSSqlHelper(string strConnString)
        {
            ConnectionString = strConnString;
        }

        public MSSqlHelper()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        }

        #region Transaction 

        public void InitializeTransaction()
        {
            TransactionMode = true;
            Con = new SqlConnection(ConnectionString);
            Con.Open();
            Cmd = new SqlCommand();
            Cmd.Connection = Con;            
            DA = new SqlDataAdapter();
        }

        public void BeginTransaction()
        {
            InitializeTransaction();
            Tran = Con.BeginTransaction(IsolationLevel.ReadCommitted);
            Cmd.Transaction = Tran;
        }

        public void RollBack()
        {
            Tran.Rollback();
            Tran.Dispose();
            Tran = null;
            Cmd.Dispose();
            Cmd = null;
            Con.Close();
            Con.Dispose();
            Con = null;
            DA.Dispose();
            DA = null;
            TransactionMode = false;
            
        }

      

        public void Commit()
        {
            Tran.Commit();
            Tran.Dispose();
            Tran = null;
            Cmd.Dispose();
            Cmd = null;
            Con.Close();
            Con.Dispose();
            Con = null;
            DA.Dispose();
            DA = null;
            TransactionMode = false;
            
        }

        #endregion

        public void Reset()
		{
			SQLFrom		= "";
			SQLWhere		= "";
			SQLSelect		= "";
			SQLOrderBy		= "";
			SQLGroupBy		= "";
			SQLHaving		= "";
			SQLSet			= "";
			SQLInsertFields = "";
			SQLInsertValues	= "";
            
		}

		public DataSet GetDataSet(string sql)
		{
			DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
			try
			{
				conn.Open();
                da = new SqlDataAdapter(sql, conn);
				da.Fill(ds);
			}
		
			finally
			{
				da.Dispose();
				da = null;
				conn.Close();
				conn.Dispose();
				conn = null;
			}
			return ds;
		}

        public int ExecuteScalar(string sql)
        {
            int newid = -1;
            if (TransactionMode)
            {
                try
                {
                    Cmd.CommandText = sql;
                    newid = (int)Cmd.ExecuteScalar();
                }
                finally { }
                return newid;
            }
            else
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                SqlCommand comm = new SqlCommand();

                try
                {
                    conn.Open();
                    comm.Connection = conn;
                    comm.CommandText = sql;
                    newid = (int)comm.ExecuteScalar();

                }
                finally
                {
                    comm.Dispose();
                    comm = null;
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }
            }
            return newid;
        }

		public int ExecuteNonQuery(string sql)
		{
            int rowsaffected = 0;
            if (TransactionMode)
            {
                try
                {
                    Cmd.CommandText = sql;
                    rowsaffected = Cmd.ExecuteNonQuery();
                }
                finally{}
                return rowsaffected;
            }
            else
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                SqlCommand comm = new SqlCommand();
                
                try
                {
                    conn.Open();
                    comm.Connection = conn;
                    comm.CommandText = sql;
                    rowsaffected = comm.ExecuteNonQuery();

                }
                finally
                {
                    comm.Dispose();
                    comm = null;
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }
            }
			return rowsaffected;
		}

		public DataView ExecuteQuery(string sql)
		{
            DataView retDataView;
            if (TransactionMode)
            {
                Cmd.CommandText = sql;
                DA.SelectCommand = Cmd;
                DataSet ds = new DataSet();
                try { DA.Fill(ds); }
                finally { }
                retDataView= ds.Tables[0].DefaultView;
            }
            else
            {
                DataSet ds = new DataSet();
                SqlConnection conn = new SqlConnection(ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {
                    conn.Open();
                    da = new SqlDataAdapter(sql, conn);
                    da.Fill(ds);

                }
                finally
                {
                    da.Dispose();
                    da = null;
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }
                retDataView=ds.Tables[0].DefaultView;
            }
            return retDataView;
		}

		public DataView ExecuteSelect()
		{			
			if (SQLFrom!="")
			{
				if (SQLSelect == "") SQLSelect="*";
				string Query = "SELECT " + SQLSelect + " FROM " + SQLFrom;
				if (SQLWhere != "")	Query +=" WHERE " + SQLWhere;
				if (SQLOrderBy != "") Query +=" ORDER BY " + SQLOrderBy;
				if (SQLGroupBy != "") Query +=" GROUP BY " + SQLGroupBy;									
				return ExecuteQuery(Query);				
			}			
			return null;	
		}		
		
		public int ExecuteDelete()
		{
			if ((SQLFrom != "") && (SQLWhere != ""))
			{
				string Query = "DELETE FROM " + SQLFrom;
				if (SQLWhere != "") Query += " WHERE " + SQLWhere;
				return ExecuteNonQuery(Query);
			}
			return -1;				
		}

		
		public int ExecuteUpdate()
		{
			if ((SQLFrom != "") && (SQLSet != "") && (SQLWhere != ""))
			{

               // SQLSet = SQLSet + ",rud_date=NOW(),version_no=version_no+1";
                
                
                
                

				string sql = "update " + SQLFrom + " set " + SQLSet;
				if (SQLWhere != "")	sql += " WHERE " + SQLWhere;
				return ExecuteNonQuery(sql);
			}
			return -1;		
		}

		public int ExecuteInsert()
		{
           
			if ((SQLInsertFields != "") && (SQLFrom != "") && (SQLInsertValues != ""))
			{
                //SQLInsertFields = SQLInsertFields + ",rcd_date,rud_date,version_no";
                //SQLInsertValues = SQLInsertValues + ",NOW(),NOW(),1";
				string sql = "insert into " + SQLFrom + "(" + SQLInsertFields + ") values (" + SQLInsertValues + ");SELECT MAX("+KeyField+") FROM " + SQLFrom + ";" ;
				return ExecuteScalar(sql);
			}
			return -1;
		}
		
		public int GetMaxId(string strTableName,string strIdField)
		{
			DataView dv=ExecuteQuery("Select Max(" + strIdField + ") as MaxId from " + strTableName);
			return (int)dv.Table.Rows[0]["MaxId"];
		}

		public int ExcuteTransaction(ArrayList SQLTransaction)
		{
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand comm = new SqlCommand();
			conn.Open();
			SqlTransaction trans=conn.BeginTransaction(IsolationLevel.ReadCommitted);
			int rowsaffected = 0;	
			try
			{	
				comm.Connection = conn;
				comm.Transaction=trans;
				foreach(string sql in SQLTransaction)
				{
					comm.CommandText = sql;
					rowsaffected+=comm.ExecuteNonQuery();
				}
				trans.Commit();
			}
			catch(Exception)
			{
				trans.Rollback();
				rowsaffected=-1;
			}
			finally
			{
				trans.Dispose();
				trans=null;
				comm.Dispose();
				comm=null;
				conn.Close();
				conn.Dispose();
				conn = null;
			}
			return rowsaffected;
		}


        //public void ExecuteStoredProc(String sql)
        //{
           
        //        SqlConnection conn = new SqlConnection(ConnectionString);
        //        SqlCommand comm = new SqlCommand();
        //        comm.CommandType = CommandType.StoredProcedure;

        //        try
        //        {
        //            conn.Open();
        //            comm.Connection = conn;
        //            comm.CommandText = sql;
        //            comm.ExecuteReader();

        //        }
        //        finally
        //        {
        //            comm.Dispose();
        //            comm = null;
        //            conn.Close();
        //            conn.Dispose();
        //            conn = null;
        //        }
            
        //}

      
        // run a stored procedure that takes a parameter
        public DataView ExecuteStoredProc(String ProcName,ArrayList paramField,ArrayList paramValue )
        {


            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand comm = new SqlCommand();
            comm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                conn.Open();
                comm.Connection = conn;
                comm.CommandText = ProcName;
                int i = 0;
                foreach (string parameter in paramField)
                {
                    
                    comm.Parameters.Add(new SqlParameter(parameter, paramValue[i]));
                    i++;
                }
                da.SelectCommand = comm;
                da.Fill(ds);
            }

            finally
            {
                da.Dispose();
                da = null;
                conn.Close();
                conn.Dispose();
                conn = null;
            }
            return ds.Tables[0].DefaultView;
        }

        public Boolean CheckDBConnection()
        {
            Boolean blnRet = false;
            SqlConnection conn = new SqlConnection(ConnectionString);

            try
            {
                conn.Open();
                blnRet = true;
                conn.Close();
            }
            catch (Exception ex)
            {
                blnRet = false;
            }

            return blnRet;
        }

        public int ExecuteInsertUpdateStoredProc(String ProcName, ArrayList paramField, ArrayList paramValue)
        {
            int rowaffected = -1;

            if (TransactionMode)
            {
                try
                {
                    Cmd.CommandText = ProcName;
                    Cmd.CommandType = CommandType.StoredProcedure;
                    int i = 0;
                    foreach (string parameter in paramField)
                    {
                        Cmd.Parameters.Add(new SqlParameter(parameter, paramValue[i]));
                        i++;
                    }
                    rowaffected = Convert.ToInt32(Cmd.ExecuteScalar());
                }
                finally { }
                return rowaffected;
            }
            else
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                SqlCommand comm = new SqlCommand();

                try
                {
                    conn.Open();
                    comm.Connection = conn;
                    comm.CommandText = ProcName;
                    comm.CommandType = CommandType.StoredProcedure;

                    int i = 0;
                    foreach (string parameter in paramField)
                    {
                        comm.Parameters.Add(new SqlParameter(parameter, paramValue[i]));
                        i++;
                    }

                    rowaffected = Convert.ToInt32(comm.ExecuteScalar());

                }
                finally
                {
                    comm.Dispose();
                    comm = null;
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }
            }

            return rowaffected;
        }


		#endregion
    }
}
