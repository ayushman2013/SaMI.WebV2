using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.EducationalStat
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadEducationalStatus();
            }

        }

        void loadEducationalStatus()
        {
            DataView dv = EducationalStatusBO.GetAll();
            gvEducationalStatus.DataSource = dv;
            gvEducationalStatus.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EducationalStatus objEducationalStatus = new EducationalStatus();
            objEducationalStatus.EducationalStatusDesc = txtEducationalStatusDesc.Text;
            objEducationalStatus.Status = 1;

            if (!string.IsNullOrEmpty(hfEducationalStatusID.Value.ToString()))
            {
                objEducationalStatus.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objEducationalStatus.UpdatedDate = DateTime.Now;
                objEducationalStatus.EducationalStatusID = Convert.ToInt32(hfEducationalStatusID.Value);
                objEducationalStatus.EducationalStatusDesc = txtEducationalStatusDesc.Text;
                EducationalStatusBO.UpdateEducationalStatus(objEducationalStatus);

            }
            else
            {
                objEducationalStatus.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objEducationalStatus.CreatedDate = DateTime.Now;
                EducationalStatusBO.InsertEduationalStatus(objEducationalStatus);
            }

            txtEducationalStatusDesc.Text = string.Empty;
            hfEducationalStatusID.Value = string.Empty;
            loadEducationalStatus();

        }

        protected void gvEducationalStatus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfEducationalStatusID.Value = e.CommandArgument.ToString();
            EducationalStatus objEducationalStatus = new EducationalStatus();

            if (e.CommandName.Equals("cmdEdit"))
            {
               objEducationalStatus = EducationalStatusBO.GetEducationalStatus(Convert.ToInt32(e.CommandArgument));
                txtEducationalStatusDesc.Text = objEducationalStatus.EducationalStatusDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int EducationalStatusID = Convert.ToInt32(e.CommandArgument);
                objEducationalStatus.EducationalStatusID = EducationalStatusID;
                objEducationalStatus.Status = 0;
                EducationalStatusBO.DeleteEducationalStatus(objEducationalStatus);
                loadEducationalStatus();
            }
        }
    }
}