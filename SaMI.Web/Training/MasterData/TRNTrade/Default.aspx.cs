using System;
using System.Web.UI.WebControls;
using System.Data;
using SaMI.DTO;
using SaMI.Business;

namespace SaMI.Web.Training.MasterData.TRNTrade
{
    public partial class Default : System.Web.UI.Page
    {
        public string valueIn = "in";
        public int collapse = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTrade();
        }

        private void LoadTrade()
        {
            DataView dvTrade = new TRNTradeBO().SelectAllTradeName();
            gvTrade.DataSource = dvTrade;
            gvTrade.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DTO.TRNTrade objTrade = new DTO.TRNTrade();

            if (lblID.Text != string.Empty)
            {
                objTrade.TradeID = Convert.ToInt32(lblID.Text);
                objTrade.TradeName = txtTradeName.Text;
                objTrade.ModifiedBy = 1;
                objTrade.Status = 1;
                int result = new TRNTradeBO().UpdateTradeName(objTrade);
                if (result > 0)
                {
                    Clear();
                    collapse = 1;
                    btnSave.Text = "Save";
                    LoadTrade();
                }

            }
            else
            {
                objTrade.TradeName = txtTradeName.Text;
                objTrade.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objTrade.Status = 1;
                int result = new TRNTradeBO().InsertTradeName(objTrade);
                if (result > 0)
                {
                    Clear();
                    collapse = 1;
                    LoadTrade();
                }
            }

        }

        private void Clear()
        {
            txtTradeName.Text = string.Empty;
            lblID.Text = string.Empty;
        }

        protected void gvTrade_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int TradeId = Convert.ToInt32(e.CommandArgument);
            string cmdName = e.CommandName;
            if (cmdName.Equals("cmdDelete"))
            {
                // Perform Delete Operation
                DTO.TRNTrade objTrade = new DTO.TRNTrade();
                objTrade.TradeID = TradeId;
                objTrade.ModifiedBy = 1;
                objTrade.Status = 0;

                int result = new TRNTradeBO().DeleteTradeName(objTrade);
                LoadTrade();
            }

            if (cmdName.Equals("cmdEdit"))
            {
                // Show data to TextBoxes and controls
                DataView dvRecord = new TRNTradeBO().SelectTradeNameByID(TradeId);
                if (dvRecord.Count > 0)
                {
                    lblID.Text = dvRecord.Table.Rows[0]["TRNTradeID"].ToString();
                    txtTradeName.Text = dvRecord.Table.Rows[0]["TradeName"].ToString();
                    collapse = 0;
                    btnSave.Text = "Update";
                }

            }
        }
    }
}