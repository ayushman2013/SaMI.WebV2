using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DataAccess;
using SaMI.DTO;

namespace SaMI.Business
{
   public class TRNDepartureChecklistBO
    {
       //public static DataView GetDepartureCheckListByEmploymentID(int EmploymentID)
       //{
       //    return new TRNDepartureChecklistDAO().SelectDepartureCheckListByEmploymentID(EmploymentID);
       //}

       public static List<int> GetDepartureCheckListByEmploymentID(int EmploymentID)
       {
           List<int> lstCheckList = new List<int>();
           DataView dv = new TRNDepartureChecklistDAO().SelectDepartureCheckListByEmploymentID(EmploymentID);

           if (dv.Count > 0)
           {
               //String CheckList = dv.Table.Rows[0]["CheckListID"].ToString();
               //if (!string.IsNullOrEmpty(CheckList))
               //{
               //    string[] Lists = CheckList.Split(',');
               //    foreach (string list in Lists)
               //    {
               //        if (list != string.Empty)
               //            lstCheckList.Add(Convert.ToInt32(list));
               //    }
               //}
               int i = 0;
               foreach (DataRowView drv in dv)
               {
                   
                   lstCheckList.Add(Convert.ToInt32(dv.Table.Rows[i]["CheckListID"]));
                   i++;
               }

           }

           return lstCheckList;
       }

       public int DeleteDepartureList(int EmploymentID, int CheckListID)
       {
           return new TRNDepartureChecklistDAO().DeleteDepartureList(EmploymentID, CheckListID);
       }

       public static int Delete(int DepartureCheckListID)
       {
           return new TRNDepartureChecklistDAO().Delete("ID=" + DepartureCheckListID);
       }
    }
}
