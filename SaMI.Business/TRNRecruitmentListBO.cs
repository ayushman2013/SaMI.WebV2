using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
   public class TRNRecruitmentListBO
    {

       public static int InsertRecruitmentList(TRNRecruitmentList objRecruitmentList)
        {
            return new TRNRecruitmentListDAO().InsertRecruitmentList(objRecruitmentList);
        }

       public static int UpdateRecruitmentList(TRNRecruitmentList objRecruitmentList)
        {
            return new TRNRecruitmentListDAO().UpdateRecruitmentList(objRecruitmentList);
        }

        public static DataView GetAll()
        {
            return new TRNRecruitmentListDAO().SelectAll();
        }

        public static DataView GetRecruitmentList(string strName)
        {
            return new TRNRecruitmentListDAO().SelectRecruitmentList(strName);
        }

        public static DataView CountRecruitmentList(string strName)
        {
            return new TRNRecruitmentListDAO().CountRecruitmentList(strName);
        }

        public static DataView GetStatus(int SaMIProfileID)
        {
            return new TRNRecruitmentListDAO().GetStatus(SaMIProfileID);
        }

        public static int DeleteRecruitmentList(int SaMIProfileID)
        {
            return new TRNRecruitmentListDAO().DeleteRecruitmentList(SaMIProfileID);
        }

        public static DataView GetReferredProfile(int SaMIProfileID)
        {
            return new TRNRecruitmentListDAO().SelectReferredProfile(SaMIProfileID);
        }

        public static DataView GetTRNRecruitmentListIDForSync(String CreatedBy)
        {
            return new TRNRecruitmentListDAO().GetTRNRecruitmentListIDForSync(CreatedBy);
        }

        public static TRNRecruitmentList GetTRNRecruitmentList(int RecruitmentID)
        {
            TRNRecruitmentList objRecruitment = new TRNRecruitmentList();
            return (TRNRecruitmentList)(new TRNRecruitmentListDAO().FillDTO(objRecruitment, "RecruitmentID=" + RecruitmentID));
        }


    }
}
