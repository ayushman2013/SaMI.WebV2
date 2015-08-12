using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.PaymentRange
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                loadPaymentRanges();
        }

        void loadPaymentRanges()
        {
            DataView dv = PaymentRangesBO.GetAll();
            gvPaymentRange.DataSource = dv;
            gvPaymentRange.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            PaymentRanges objPaymentRanges = new PaymentRanges();
            objPaymentRanges.PaymentRangeDesc = txtPaymentRangeDesc.Text;
            objPaymentRanges.Status = 1;

            if (!string.IsNullOrEmpty(hfPaymentRangeID.Value.ToString()))
            {
                objPaymentRanges.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objPaymentRanges.UpdatedDate = DateTime.Now;
                objPaymentRanges.PaymentRangeID = Convert.ToInt32(hfPaymentRangeID.Value);
                objPaymentRanges.PaymentRangeDesc = txtPaymentRangeDesc.Text;
                PaymentRangesBO.UpdatePaymentRanges(objPaymentRanges);
            }
            else
            {
                objPaymentRanges.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objPaymentRanges.CreatedDate = DateTime.Now;
                PaymentRangesBO.InsertPaymentRanges(objPaymentRanges);
            }

            txtPaymentRangeDesc.Text = string.Empty;
            loadPaymentRanges();
        }

        protected void gvPaymentRange_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfPaymentRangeID.Value = e.CommandArgument.ToString();
            PaymentRanges objPaymentRanges = new PaymentRanges();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objPaymentRanges = PaymentRangesBO.GetPaymentRanges(Convert.ToInt32(e.CommandArgument));
                txtPaymentRangeDesc.Text = objPaymentRanges.PaymentRangeDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int PaymentRangeID = Convert.ToInt32(e.CommandArgument);
                objPaymentRanges.PaymentRangeID = PaymentRangeID;
                objPaymentRanges.Status = 0;
                PaymentRangesBO.DeletePaymentRanges(objPaymentRanges);
                loadPaymentRanges();
            }
        }
    }
}