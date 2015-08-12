using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.MoneyRange
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                loadMoneyRange();

        }

        void loadMoneyRange()
        {
            DataView dv = MoneyRangesBO.GetAll();
            gvMoneyRange.DataSource = dv;
            gvMoneyRange.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MoneyRanges objMoneyRanges = new MoneyRanges();
            objMoneyRanges.MoneyRangeDesc = txtMoneyRangeDesc.Text;
            objMoneyRanges.Status = 1;

            if (!string.IsNullOrEmpty(hfMoneyRangeID.Value.ToString()))
            {
                objMoneyRanges.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objMoneyRanges.UpdatedDate = DateTime.Now;
                objMoneyRanges.MoneyRangeID = Convert.ToInt32(hfMoneyRangeID.Value);
                objMoneyRanges.MoneyRangeDesc = txtMoneyRangeDesc.Text;
                MoneyRangesBO.UpdateMoneyRanges(objMoneyRanges);
            }
            else
            {
                objMoneyRanges.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objMoneyRanges.CreatedDate = DateTime.Now;
                MoneyRangesBO.InsertMoneyRanges(objMoneyRanges);
            }

            txtMoneyRangeDesc.Text = string.Empty;
            hfMoneyRangeID.Value = string.Empty;
            loadMoneyRange();

        }

        protected void gvMoneyRange_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfMoneyRangeID.Value = e.CommandArgument.ToString();
            MoneyRanges objMoneyRanges = new MoneyRanges();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objMoneyRanges = MoneyRangesBO.GetMoneyRanges(Convert.ToInt32(e.CommandArgument));
                txtMoneyRangeDesc.Text = objMoneyRanges.MoneyRangeDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int MoneyRangeID = Convert.ToInt32(e.CommandArgument);
                objMoneyRanges.MoneyRangeID = MoneyRangeID;
                objMoneyRanges.Status = 0;
                MoneyRangesBO.DeleteMoneyRanges(objMoneyRanges);
                loadMoneyRange();
            }
        }
    }
}