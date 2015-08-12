using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.AdditionalFollowupsInfo
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadAdditionalFollowupInfo();
            }

        }

        void loadAdditionalFollowupInfo()
        {
            DataView dv = AdditionalFollowUpInfoBO.GetAll();
            gvAdditionalFollowUpInfo.DataSource = dv;
            gvAdditionalFollowUpInfo.DataBind();

        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            AdditionalFollowupInfo objAdditionalFollowupInfo = new AdditionalFollowupInfo();
            objAdditionalFollowupInfo.AdditionalFollowUpInfoDesc = txtAdditionalFollowUpInfoDesc.Text;
            objAdditionalFollowupInfo.Status = 1;

            if (!string.IsNullOrEmpty(hfAdditionalFollowUpInfoID.Value.ToString()))
            {
                objAdditionalFollowupInfo.AdditionalFollowUpInfoID = Convert.ToInt32(hfAdditionalFollowUpInfoID.Value);
                objAdditionalFollowupInfo.AdditionalFollowUpInfoDesc = txtAdditionalFollowUpInfoDesc.Text;
                objAdditionalFollowupInfo.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objAdditionalFollowupInfo.UpdatedDate = DateTime.Now;
                AdditionalFollowUpInfoBO.UpdateAdditionalFollowUpInfo(objAdditionalFollowupInfo);
            }
            else
            {
                objAdditionalFollowupInfo.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objAdditionalFollowupInfo.CreatedDate = DateTime.Now;
                AdditionalFollowUpInfoBO.InsertAddtionalFollowUpInfo(objAdditionalFollowupInfo);
            }

            txtAdditionalFollowUpInfoDesc.Text = string.Empty;
            hfAdditionalFollowUpInfoID.Value = string.Empty;
            loadAdditionalFollowupInfo();
        }

        protected void gvAdditionalFollowUpInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfAdditionalFollowUpInfoID.Value = e.CommandArgument.ToString();
            AdditionalFollowupInfo objAdditionalFollowupInfo = new AdditionalFollowupInfo();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objAdditionalFollowupInfo = AdditionalFollowUpInfoBO.GetAdditionalFollowupInfo(Convert.ToInt32(e.CommandArgument));
                txtAdditionalFollowUpInfoDesc.Text = objAdditionalFollowupInfo.AdditionalFollowUpInfoDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int AdditionalFollowUpInfoID = Convert.ToInt32(e.CommandArgument);
                objAdditionalFollowupInfo.AdditionalFollowUpInfoID = AdditionalFollowUpInfoID;
                objAdditionalFollowupInfo.Status = 0;
                AdditionalFollowUpInfoBO.DeleteAdditionalFollowUpInfo(objAdditionalFollowupInfo);
                loadAdditionalFollowupInfo();
               
            }
        }

        

       
    }
}