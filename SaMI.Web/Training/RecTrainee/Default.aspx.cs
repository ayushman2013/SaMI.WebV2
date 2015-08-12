using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaMI.Business;
using SaMI.DTO;
using SaMI.Web;
using System.Data;

namespace SaMI.Web.Training.RecTrainee
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadRecruitmentList();
            LoadDataCount();
        }

        private void LoadDataCount()
        {
            DataView dv = TRNRecruitmentListBO.CountRecruitmentList(txtSearchText.Text);
            int count = Convert.ToInt32(dv[0]["DataCount"].ToString());
            lblDataCount.Text = count.ToString();
        }

        private void LoadRecruitmentList()
        {
            gvRecruitmentList.DataSource = TRNRecruitmentListBO.GetRecruitmentList(txtSearchText.Text);
            gvRecruitmentList.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRecruitmentList();
        }

        protected void gvRecruitmentList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRecruitmentList.PageIndex = e.NewPageIndex;
            LoadRecruitmentList();
            Session["pageNumber"] = e.NewPageIndex;
        }
    }
}