using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.Country
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadCountries();
            }
        }

        void loadCountries()
        {
            DataView dv = CountriesBO.GetAll();
            gvCountry.DataSource = dv;
            gvCountry.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Saving Process..
            Countries objCountries = new Countries();
            objCountries.CountryName = txtCountyName.Text;
            objCountries.CountryCode = txtCountryCode.Text;
            objCountries.CountryGroup = txtCountryGroup.Text;

            if (!string.IsNullOrEmpty(hfCountryID.Value.ToString()))
            {
                objCountries.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objCountries.UpdatedDate = DateTime.Now;
                objCountries.CountryID = Convert.ToInt32(hfCountryID.Value);
                objCountries.CountryName = txtCountyName.Text;
                objCountries.CountryCode = txtCountryCode.Text;
                objCountries.CountryGroup = txtCountryGroup.Text;
                CountriesBO.UpdateCountries(objCountries);

            }
            else
            {
                objCountries.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objCountries.CreatedDate = DateTime.Now;
                CountriesBO.InsertCountries(objCountries);
            }


            txtCountyName.Text = string.Empty;
            txtCountryCode.Text = string.Empty;
            txtCountryGroup.Text = string.Empty;

            hfCountryID.Value = string.Empty;
            loadCountries();
        }

        protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfCountryID.Value = e.CommandArgument.ToString();

            if (e.CommandName.Equals("cmdEdit"))
            {
                Countries objCountry = CountriesBO.GetCountry(Convert.ToInt32(e.CommandArgument));
                txtCountyName.Text = objCountry.CountryName;
                txtCountryGroup.Text = objCountry.CountryGroup;
                txtCountryCode.Text = objCountry.CountryCode;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int CountryID = Convert.ToInt32(e.CommandArgument);

                CountriesBO.Delete(CountryID);
                loadCountries();
            }
        }
    }
}