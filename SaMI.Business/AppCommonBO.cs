using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.Utilities;
using System.Data;
using SaMI.DataAccess;
using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;


namespace SaMI.Business
{
    public class AppCommonBO
    {
        private static String _DateDisplayFormat = "yyyy-MM-dd";

        public static String DateDisplayFormat { get { return _DateDisplayFormat; } }

        public static String FormatDate(DateTime? strDate)
        {
            if (strDate != null)
                return ((DateTime)strDate).ToString(DateDisplayFormat);
            else
                return null;
        }

        public static DateTime GetCurrentDate()
        {
            DataView dv = new BaseDAO().GetServerDate();
            return Convert.ToDateTime(dv.Table.Rows[0]["datetime"].ToString());
        }


        public static String GetClientIP()
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            return addr[addr.Length - 1].ToString();
        }


        public static string EncodeUserPassword(string originalPassword)
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes);
        }

        public static string Encode(string originalPassword)
        {
            return CryptoEngine.Encrypt(originalPassword);
        }

        public static string Decode(string encodedPassword)
        {
            return CryptoEngine.Decrypt(encodedPassword);
        }

        public static Boolean CheckDBAccessSet()
        {
            Boolean blnRet = false;
            RegistryEdit objRegistryEdit = new RegistryEdit("TEC.FHIOL");
            if (objRegistryEdit.Read("s") != null && objRegistryEdit.Read("s") != "" &&
                objRegistryEdit.Read("d") != null && objRegistryEdit.Read("d") != "" &&
                objRegistryEdit.Read("u") != null && objRegistryEdit.Read("u") != "" &&
                objRegistryEdit.Read("p") != null && objRegistryEdit.Read("p") != "")
                blnRet = true;
            return blnRet;

        }

        public static Boolean CheckDBAccess()
        {
            Boolean blnRet = false;
            RegistryEdit objRegistryEdit = new RegistryEdit("TEC.FHIOL");

            String DBServer = objRegistryEdit.Read("cam_s");
            String DBName = objRegistryEdit.Read("cam_d");
            String DBUser = objRegistryEdit.Read("cam_u");
            String DBPassword = objRegistryEdit.Read("cam_p");

            if (CheckDBConnection(CryptoEngine.Decrypt(DBServer), CryptoEngine.Decrypt(DBName), CryptoEngine.Decrypt(DBUser), CryptoEngine.Decrypt(DBPassword)))
                blnRet = true;
            return blnRet;
        }

        public static Boolean CheckDBConnection(String DBServer, String DBName, String DBUser, String DBPassword)
        {
            Boolean blnRet = false;

            //String ConnectionString = "server=" + DBServer + ";user id=" + DBUser + ";password=" + DBPassword + ";persist security info=True;database=" + DBName;
            //blnRet = new BaseDAO(ConnectionString).CheckDBConnection();

            return blnRet;
        }

        public static Boolean SetDBAccess(String DBServer, String DBName, String DBUser, String DBPassword)
        {
            Boolean blnRet = false;
            RegistryEdit objRegistryEdit = new RegistryEdit("Campus");
            if (objRegistryEdit.Write("cam_s", CryptoEngine.Encrypt(DBServer)))
                if (objRegistryEdit.Write("cam_d", CryptoEngine.Encrypt(DBName)))
                    if (objRegistryEdit.Write("cam_u", CryptoEngine.Encrypt(DBUser)))
                        if (objRegistryEdit.Write("cam_p", CryptoEngine.Encrypt(DBPassword)))
                            blnRet = true;
            return blnRet;
        }

        public static Boolean IsInteger(string input)
        {
            bool blnRet = false;
            try
            {
                int retVal = Convert.ToInt32(input);
            }
            catch (Exception ex)
            {
                blnRet = false;
            }
            return blnRet;
        }

        public static int GetOptionValue(String Value, String Key, String Field, String Table)
        {
            int val = 0;

            DataView dv = new BaseDAO().Select(Field + " AS VAL ", Table, Key + " = '" + Value + "'");
            if (dv.Count > 0)
                return Convert.ToInt32(dv.Table.Rows[0]["VAL"]);

            return val;
        }
    }
}
