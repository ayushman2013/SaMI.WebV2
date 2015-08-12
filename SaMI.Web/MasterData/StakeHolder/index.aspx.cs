using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.StakeHolder
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                loadStakeHolder();
        }

        void loadStakeHolder()
        {
            DataView dv = StakeholderBO.GetAll();
            gvStakeHolder.DataSource = dv;
            gvStakeHolder.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            StakeHolders objStakeHolders = new StakeHolders();
            objStakeHolders.StakeHolderName = txtStakeHolderName.Text;

            if (!string.IsNullOrEmpty(hfStakeHolderID.Value.ToString()))
            {
                objStakeHolders.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objStakeHolders.UpdatedDate = DateTime.Now;
                objStakeHolders.StakeHolderID = Convert.ToInt32(hfStakeHolderID.Value);
                objStakeHolders.StakeHolderName = txtStakeHolderName.Text;
                StakeholderBO.UpdateStakeHolders(objStakeHolders);

            }
            else
            {
                objStakeHolders.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objStakeHolders.CreatedDate = DateTime.Now;
                StakeholderBO.InsertStakeHolders(objStakeHolders);
            }
            
            txtStakeHolderName.Text = string.Empty;
            hfStakeHolderID.Value = string.Empty;
            loadStakeHolder();
        }

        protected void gvStakeHolder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfStakeHolderID.Value = e.CommandArgument.ToString();

            if (e.CommandName.Equals("cmdEdit"))
            {
                StakeHolders objStakeHolders = StakeholderBO.GetStakeHolders(Convert.ToInt32(e.CommandArgument));
                txtStakeHolderName.Text = objStakeHolders.StakeHolderName;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int StakeHolderID = Convert.ToInt32(e.CommandArgument);
                StakeholderBO.Delete(StakeHolderID);
                loadStakeHolder();
            }
        }
    }
}