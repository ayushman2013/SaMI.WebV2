using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class EthnicityBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new EthnicityDAO().SelectAll(Select);

        }

        public static int InsertEthnicity(Ethnicity objEthnicity)
        {
            return new EthnicityDAO().InsertEthnicity(objEthnicity);
        }
        public static Ethnicity GetEthnicity(int EthnicityID)
        {
            Ethnicity objEthnicity = new Ethnicity();
            return (Ethnicity)(new EthnicityDAO().FillDTO(objEthnicity, "EthnicityID=" + EthnicityID));
        }
        public static int UpdateEthnicity(Ethnicity objEthnicity)
        {
            return new EthnicityDAO().UpdateEthnicity(objEthnicity);
        }

        public static int Delete(int EthnicityID)
        {
            return new EthnicityDAO().Delete("EthnicityID=" + EthnicityID);
        }

        public static int DeleteEthnicity(Ethnicity objEthnicity)
        {
            return new EthnicityDAO().DeleteEthnicity(objEthnicity);
        }

        public static DataView SelectGeoBasedEthnicity()
        {
            return new EthnicityDAO().SelectGeoBasedEthnicity();
        }

        public static List<int> SelectValidRegions(int EthnicityID, int SaMiProfileID)
        {
            List<int> lstValidRegions = new List<int>();
            DataView dv = new EthnicityDAO().SelectValidRegions(EthnicityID, SaMiProfileID);

            if (dv.Count > 0)
            {
                String validRegions = dv.Table.Rows[0]["ValidRegions"].ToString();
                if (!string.IsNullOrEmpty(validRegions))
                {
                    string[] regions = validRegions.Split(',');
                    foreach (string region in regions)
                    {
                        if (region != string.Empty)
                            lstValidRegions.Add(Convert.ToInt32(region));
                    }
                }

            }

            return lstValidRegions;
        }

        public static List<int> SelectValidRegionsForTrainee(int EthnicityID, int TraineeID)
        {
            List<int> lstValidRegions = new List<int>();
            DataView dv = new EthnicityDAO().SelectValidRegionsForTrainee(EthnicityID, TraineeID);

            if (dv.Count > 0)
            {
                String validRegions = dv.Table.Rows[0]["ValidRegions"].ToString();
                if (!string.IsNullOrEmpty(validRegions))
                {
                    string[] regions = validRegions.Split(',');
                    foreach (string region in regions)
                    {
                        if (region != string.Empty)
                            lstValidRegions.Add(Convert.ToInt32(region));
                    }
                }

            }

            return lstValidRegions;
        }

        public static List<int> SelectValidRegionForEthnicity(int EthnicityID)
        {
            List<int> lstValidRegions = new List<int>();
            DataView dv = new EthnicityDAO().SelectValidRegionForEthnicity(EthnicityID);

            if (dv.Count > 0)
            {
                String validRegions = dv.Table.Rows[0]["ValidRegions"].ToString();
                if (!string.IsNullOrEmpty(validRegions))
                {
                    string[] regions = validRegions.Split(',');
                    foreach (string region in regions)
                    {
                        if (region != string.Empty)
                            lstValidRegions.Add(Convert.ToInt32(region));
                    }
                }

            }

            return lstValidRegions;
        }

        public static DataView SelectRegionsForDropdown(List<int> lstValidRegions, String option)
        {
            return new EthnicityDAO().SelectRegionsForDropdown(lstValidRegions, option);
        }

        public static DataView GetEthnicityIDForSync()
        {
            return new EthnicityDAO().SelectEthnicityIDForSync();
        }
    }
}
