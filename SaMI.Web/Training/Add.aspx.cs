using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaMI.Business;
using SaMI.DTO;
using System.IO;
using System.Data;
using System.Web.Services;

namespace SaMI.Web.Training
{
    public partial class Add : System.Web.UI.Page
    {
        public int EventID = 0;
        public int SamiProfileID = 0;
        DropDownList ddlEvent = new DropDownList();
        public List<int> list = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["ICCID"]))
            {
                SamiProfileID = Convert.ToInt32(Request.QueryString["ICCID"]);

                Label lblEvent = new Label();
                lblEvent.ID = "lblEvent";
                lblEvent.Text = "Event";
                lblEvent.Width = 60;
                lblEvent.CssClass = "col-md-12 form-control";
                lblEvent.BorderStyle = BorderStyle.None;
                pnlEvent.Controls.Add(lblEvent);


                ddlEvent.ID = "ddlEvent";
                ddlEvent.CssClass = "form-control";
                ddlEvent.Height = 35;
                ddlEvent.Width = 200;
                ddlEvent.Style["margin-bottom"] = "15px";

                ddlEvent.DataSource = TRNTrainingEventBO.GetAllTrainingEvent();
                ddlEvent.DataValueField = "ID";
                ddlEvent.DataTextField = "EventID";
                ddlEvent.DataBind();

                pnlEvent.Controls.Add(ddlEvent);
                pnlEvent.Visible = true;
            }

            if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
                EventID = Convert.ToInt32(Request.QueryString["ID"]);

            if (!Page.IsPostBack)
            {
                LoadTraineeOptions();
                LoadReferredProfile(SamiProfileID);
                //Data();
            }
        }

        void LoadGeoBasedEthnicity()
        {
            rbValidRegions.DataSource = EthnicityBO.SelectGeoBasedEthnicity();
            rbValidRegions.DataValueField = "GeoBasedEthnicityID";
            rbValidRegions.DataTextField = "GeoBasedEthnicityDesc";
            rbValidRegions.DataBind();
        }

        protected void ddlCastEthinicity_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGeoBasedEthnicity();
            if (!string.IsNullOrEmpty(ddlCastEthinicity.SelectedValue))
            {
                LoadValidRegions(Convert.ToInt32(ddlCastEthinicity.SelectedValue));
            }
        }

        void LoadValidRegions(int EthnicityID)
        {
            List<int> lstValidRegions = EthnicityBO.SelectValidRegionForEthnicity(EthnicityID);

            if (lstValidRegions.Count > 0)
            {

                for (int j = 0; j < rbValidRegions.Items.Count; j++)
                {

                    if (lstValidRegions.Exists(delegate(int region) { return region == Convert.ToInt32(rbValidRegions.Items[j].Value); }))
                    {
                    }
                    else
                        list.Add(j);

                }
                foreach (int a in list)
                {
                    rbValidRegions.Items[a].Attributes.Add("hidden", "hidden");
                }

            }
            else
            {
                for (int j = 0; j < rbValidRegions.Items.Count; j++)
                {
                    rbValidRegions.Items[j].Attributes.Add("hidden", "hidden");
                }
            }
        }

        private void LoadReferredProfile(int SamiProfileID)
        {
            if (SamiProfileID > 0)
            {
                DataView dvReferredProfile = TRNRecruitmentListBO.GetReferredProfile(SamiProfileID);

                txtFirstName.Text = dvReferredProfile.Table.Rows[0]["FirstName"].ToString();
                txtLastName.Text = dvReferredProfile.Table.Rows[0]["LastName"].ToString();
                ddlGender.Text = dvReferredProfile.Table.Rows[0]["Gender"].ToString();
                ddlMaritalStatus.Text = dvReferredProfile.Table.Rows[0]["MaritalStatusDesc"].ToString();
                ddlCastEthinicity.SelectedValue = dvReferredProfile.Table.Rows[0]["EthnicityID"].ToString();
                ddlDistrict.SelectedValue = dvReferredProfile.Table.Rows[0]["DistrictID"].ToString();
                txtWardNumber.Text = dvReferredProfile.Table.Rows[0]["Ward"].ToString();
                txtMobile.Text = dvReferredProfile.Table.Rows[0]["VisitorPhone"].ToString();
                txtFathersContactNumber.Text = dvReferredProfile.Table.Rows[0]["FamilyMemberPhone"].ToString();
            }

        }

        void LoadTraineeOptions()
        {
            ddlCountry.DataSource = CountriesBO.GetAll(true);
            ddlCountry.DataValueField = "CountryID";
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataBind();

            ddlWhichCountry.DataSource = CountriesBO.GetAll(true);
            ddlWhichCountry.DataValueField = "CountryID";
            ddlWhichCountry.DataTextField = "CountryName";
            ddlWhichCountry.DataBind();

            ddlDistrict.DataSource = DistrictBO.GetAll(true);
            ddlDistrict.DataValueField = "DistrictID";
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataBind();

            ddlFeedDurationTypeID.DataSource = FeedDurationTypeBO.GetAll(true);
            ddlFeedDurationTypeID.DataValueField = "FeedDurationTypeID";
            ddlFeedDurationTypeID.DataTextField = "FeedDurationTypeDesc";
            ddlFeedDurationTypeID.DataBind();

            ddlDistrict.DataSource = DistrictBO.GetAll(true);
            ddlDistrict.DataValueField = "DistrictID";
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataBind();

            if (!string.IsNullOrEmpty(ddlDistrict.SelectedValue))
            {
                ddlVDC.DataSource = VDCBO.GetAllByDistrictID(Convert.ToInt32(ddlDistrict.SelectedValue), true);
                ddlVDC.DataValueField = "VDCID";
                ddlVDC.DataTextField = "VDCName";
                ddlVDC.DataBind();
            }

            ddlQualification.DataSource = new TRNEducationLevelBO().GetAllEducationLevel(true);
            ddlQualification.DataValueField = "ID";
            ddlQualification.DataTextField = "EducationLevel";
            ddlQualification.DataBind();

            ddlInformationSource.DataSource = new TRNInformaitonSourceBO().GetAllInformationSource(true);
            ddlInformationSource.DataValueField = "ID";
            ddlInformationSource.DataTextField = "InformationSource";
            ddlInformationSource.DataBind();

            ddlCastEthinicity.DataSource = new TRNEthnicityBO().GetAllEthnicity(true);
            ddlCastEthinicity.DataValueField = "EthnicityID";
            ddlCastEthinicity.DataTextField = "EthnicityName";
            ddlCastEthinicity.DataBind();

            ddlCitizenshipIssuedDistict.DataSource = DistrictBO.GetAll(true);
            ddlCitizenshipIssuedDistict.DataValueField = "DistrictID";
            ddlCitizenshipIssuedDistict.DataTextField = "DistrictName";
            ddlCitizenshipIssuedDistict.DataBind();

            ddlEmploymentType.DataSource = new TRNEmploymentTypeBO().GetAllEmploymentType(true);
            ddlEmploymentType.DataValueField = "ID";
            ddlEmploymentType.DataTextField = "EmploymentType";
            ddlEmploymentType.DataBind();

            ddlEmploymentStatus.DataSource = new TRNEmploymentStatusBO().GetAllEmploymentStatus(true);
            ddlEmploymentStatus.DataValueField = "ID";
            ddlEmploymentStatus.DataTextField = "EmploymentStatus";
            ddlEmploymentStatus.DataBind();

            ddlTraineeCheckList.DataSource = new TRNCheckListBO().GetAllCheckList(false);
            ddlTraineeCheckList.DataTextField = "Checklist";
            ddlTraineeCheckList.DataValueField = "ID";
            ddlTraineeCheckList.DataBind();

            if (rdoAbroadYes.Checked)
            {
                txtDepartureDate.Text = "";
                txtPastRecruitmentAgency.Text = "";
                txtCompany.Text = "";
                ddlEmploymentType.SelectedValue = "";
                ddlEmploymentStatus.SelectedValue = "";
                //txtJobDoneMonth.Text = "";
                //txtJobDoneYear.Text = "";
                txtMonthlySalary.Text = "";
                txtForeignCurrency.Text = "";
                txtReturnDate.Text = "";
            }
        }

        [WebMethod]
        public static String ADToBS(string date)
        {
            NepaliToEnglishConversion convert = new NepaliToEnglishConversion();
            Dictionary<string, string> enDate = convert.eng_to_nep(date);
            return enDate["year"].ToString() + "-" + enDate["month"].ToString() + "-" + enDate["date"].ToString();


        }


        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlDistrict.SelectedValue))
            {
                if (Convert.ToInt32(ddlDistrict.SelectedValue) > 0)
                {
                    int districtID = Convert.ToInt32(ddlDistrict.SelectedValue);
                    ddlVDC.DataSource = VDCBO.GetAllByDistrictID(districtID, true);
                    ddlVDC.DataValueField = "VDCID";
                    ddlVDC.DataTextField = "VDCName";
                    ddlVDC.DataBind();
                }
            }
        }

       

        TRNTrainee MapTrainee()
        {
            TRNTrainee objTrainee = new TRNTrainee();
            if (!String.IsNullOrEmpty(ddlQualification.SelectedValue.ToString()))
                objTrainee.EducationLevelID = Convert.ToInt32(ddlQualification.SelectedValue);
            if (!String.IsNullOrEmpty(ddlInformationSource.SelectedValue.ToString()))
                objTrainee.InformationSourceID = Convert.ToInt32(ddlInformationSource.SelectedValue);

            if (!String.IsNullOrEmpty(ddlVDC.SelectedValue.ToString()))
                objTrainee.VDCID = Convert.ToInt32(ddlVDC.SelectedValue);
            if (!String.IsNullOrEmpty(ddlDistrict.SelectedValue.ToString()))
                objTrainee.DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
            if (!String.IsNullOrEmpty(ddlCastEthinicity.SelectedValue.ToString()))
                objTrainee.EthnicityID = Convert.ToInt32(ddlCastEthinicity.SelectedValue);

            string ValidRegions = string.Empty;

            for (int j = 0; j < rbValidRegions.Items.Count; j++)
            {
                if (rbValidRegions.Items[j].Selected == true)
                {
                    if (j == 0)
                        ValidRegions = rbValidRegions.Items[j].Value;
                    else
                        ValidRegions = ValidRegions + "," + rbValidRegions.Items[j].Value;
                }
            }

            objTrainee.ValidRegions = ValidRegions;

            if (!String.IsNullOrEmpty(ddlCitizenshipIssuedDistict.SelectedValue.ToString()))
                objTrainee.CitizenshipIssueDistictID = Convert.ToInt32(ddlCitizenshipIssuedDistict.SelectedValue);
            objTrainee.FirstName = txtFirstName.Text;
            objTrainee.LastName = txtLastName.Text;
            objTrainee.Gender = ddlGender.SelectedValue;
            objTrainee.MaritalStatus = ddlMaritalStatus.SelectedValue;
            objTrainee.DateOfBirthAD = txtDateOfBirthAD.Text;
            objTrainee.DateOfBirthBS = txtDateOfBirthBS.Text;


            objTrainee.CurrentAge = txtAge.Text;



            objTrainee.SpecialCase = hfSpecialCase.Value;

            objTrainee.Tole = txtTol.Text;
            objTrainee.WardNumber = txtWardNumber.Text;
            objTrainee.PhoneNumber = txtPhoneNumberHouse.Text;
            objTrainee.MobileNumber = txtMobile.Text;
            objTrainee.CitizenshipNumber = txtCitizenshipNumber.Text;
            objTrainee.PassportNumber = txtPassportNumber.Text;
            objTrainee.FatherName = txtFathersName.Text;
            objTrainee.FatherTelephone = txtFathersContactNumber.Text;
            objTrainee.ContactPerson = txtContactPerson.Text;
            objTrainee.ContactPersonTelephone = txtContactPersonContactTelephone.Text;
            if (chkUnEmployment.Checked)
            {
                objTrainee.Unemployment = 1;
                objTrainee.SelfEmployment = 0;
            }
            else
            {
                objTrainee.Unemployment = 0;
            }

            if (!String.IsNullOrEmpty(txtSelfEmploymentIncome.Text))
                objTrainee.SelfEmployment = Convert.ToDecimal(txtSelfEmploymentIncome.Text);
            if (!String.IsNullOrEmpty(txtWageIncome.Text))
                objTrainee.Wage = Convert.ToDecimal(txtWageIncome.Text);
            if (!String.IsNullOrEmpty(txtAgricultureIncome.Text))
                objTrainee.Agriculture = Convert.ToDecimal(txtAgricultureIncome.Text);
            if (!String.IsNullOrEmpty(txtForeignIncome.Text))
                objTrainee.ForeignEmploymentIncome = Convert.ToDecimal(txtForeignIncome.Text);
            if (!String.IsNullOrEmpty(txtOtherIncome.Text))
                objTrainee.Other = Convert.ToDecimal(txtOtherIncome.Text);
            if (!String.IsNullOrEmpty(txtFamilyMember.Text))
                objTrainee.NoOfFamilyMember = Convert.ToInt32(txtFamilyMember.Text);
            if (!String.IsNullOrEmpty(ddlFeedDurationTypeID.SelectedValue.ToString()))
                objTrainee.FeedDurationTypeID = Convert.ToInt32(ddlFeedDurationTypeID.SelectedValue);

            //if (!String.IsNullOrEmpty(txtTrainingRegistrationDate.Text))
            //    objTrainee.RegisteredDate = Convert.ToDateTime(txtTrainingRegistrationDate.Text);

            objTrainee.CreatedBy = UserAuthentication.GetUserId(this.Page);
            string path = "~/Training/Photos/";
            objTrainee.Photo = UploadImage(fuPhoto, path);
            objTrainee.Status = 1;
            objTrainee.ReferredBy = txtReferredBy.Text;

            if (SamiProfileID > 0)
            {
                if (!String.IsNullOrEmpty(ddlEvent.SelectedValue.ToString()))
                    objTrainee.EventID = Convert.ToInt32(ddlEvent.SelectedValue);
            }
            else
            {
                objTrainee.EventID = EventID;
            }

            return objTrainee;
        }

        protected String UploadImage(FileUpload fileupload, string ImageSavedPath)
        {
            FileUpload fu = fileupload;
            string imagepath = "";
            if (fileupload.HasFile)
            {
                int fileSize = fileupload.PostedFile.ContentLength;

                string filepath = Server.MapPath(ImageSavedPath);
                String fileExtension = System.IO.Path.GetExtension(fu.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        try
                        {
                            string s_newfilename = DateTime.Now.Year.ToString() +
                                DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() +
                                DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + fileExtension;
                            fu.PostedFile.SaveAs(filepath + s_newfilename);

                            imagepath = ImageSavedPath + s_newfilename;

                        }
                        catch (Exception ex)
                        {
                            return "No";
                        }

                    }

                }

            }
            return imagepath;

        }

        TRNCurrentEmployment MapCurrentEmployment()
        {
            TRNCurrentEmployment objCurrentEmployment = new TRNCurrentEmployment();

            if (rbCurrentCountryYes.Checked)
            {

                objCurrentEmployment.CountryID = Convert.ToInt32(ddlWhichCountry.SelectedValue);
                objCurrentEmployment.WorkingYear = txtWorkingYears.Text;
                objCurrentEmployment.WorkingMonth = txtWorkingMonths.Text;
                objCurrentEmployment.Occupation = txtOccupation.Text;
                objCurrentEmployment.MonthlySalary = txtPreviousMonthlySalary.Text;
                objCurrentEmployment.ReturnDate = txtPreviousReturnDate.Text;
            }
            else
            {
                objCurrentEmployment.CountryID = 0;
                objCurrentEmployment.WorkingYear = "";
                objCurrentEmployment.WorkingMonth = "";
                objCurrentEmployment.Occupation = "";
                objCurrentEmployment.MonthlySalary = "";
                objCurrentEmployment.ReturnDate = "";
            }

            objCurrentEmployment.CreatedBy = UserAuthentication.GetUserId(this.Page);
            objCurrentEmployment.CreatedDate = DateTime.Now;
            return objCurrentEmployment;
        }

        TRNEmployment MapEmployment()
        {
            TRNEmployment objEmployment = new TRNEmployment();

            #region Past Abroad Information
            if (rdoAbroadYes.Checked)
            {
                if (!String.IsNullOrEmpty(ddlCountry.SelectedValue.ToString()))
                    objEmployment.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
                if (!String.IsNullOrEmpty(txtDepartureDate.Text))
                    objEmployment.DepartureDate = Convert.ToDateTime(txtDepartureDate.Text);
                objEmployment.Organization = txtCompany.Text;
                objEmployment.RecruitmentAgency = txtPastRecruitmentAgency.Text;
                if (!String.IsNullOrEmpty(ddlEmploymentType.SelectedValue.ToString()))
                    objEmployment.EmploymentTypeID = Convert.ToInt32(ddlEmploymentType.SelectedValue);
                if (!String.IsNullOrEmpty(ddlEmploymentStatus.SelectedValue.ToString()))
                    objEmployment.EmploymentStatusID = Convert.ToInt32(ddlEmploymentStatus.SelectedValue);

                
                objEmployment.EmploymentPeriod = txtEmploymentPeriod.Text;

                if (!String.IsNullOrEmpty(txtMonthlySalary.Text))
                    objEmployment.Salary = txtMonthlySalary.Text.ToString();
                if (!String.IsNullOrEmpty(txtForeignCurrency.Text))
                    objEmployment.Currency = txtForeignCurrency.Text;

                if (!String.IsNullOrEmpty(txtReturnDate.Text))
                    objEmployment.ReturnDate = Convert.ToDateTime(txtReturnDate.Text);
            }
            else
            {
                objEmployment.CountryID = 0;
                objEmployment.RecruitmentAgency = "";
                objEmployment.Organization = "";
                objEmployment.EmploymentTypeID = 0;
                objEmployment.EmploymentStatusID = 0;
            }
            objEmployment.CreatedBy = UserAuthentication.GetUserId(this.Page);
            objEmployment.CreatedDate = DateTime.Now;
            objEmployment.Status = 1;

            #endregion
            return objEmployment;
        }

        TRNPreviousTraining MapPreviousTraining()
        {
            TRNPreviousTraining objPreviousTraining = new TRNPreviousTraining();

            if (rbHavePreviousTrainingYes.Checked)
            {
                objPreviousTraining.Name = txtTrainingName.Text;
                objPreviousTraining.Year = txtTrainingYear.Text;
                objPreviousTraining.Institute = txtTrainingInstituteName.Text;
                objPreviousTraining.Duration = txtTrainingDuration.Text;
            }
            else
            {
                objPreviousTraining.Name = "";
                objPreviousTraining.Year = "";
                objPreviousTraining.Institute = "";
                objPreviousTraining.Duration = "";
            }

            return objPreviousTraining;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TRNDepartureCheckList objDepartureCheckList = new TRNDepartureCheckList();
            List<TRNDepartureCheckList> lstDeparture = new List<TRNDepartureCheckList>();
            List<int> checkList = new List<int>();

            string departureList = hfTraineeCheckList.Value;
            string[] list = departureList.Split(',');


            foreach (string item in list)
            {
                if (item != string.Empty)
                {
                    checkList.Add(Convert.ToInt32(item));
                }
            }

            //Insert TRNTrainee, TRNEmployment, TRNPreviousTraining, TRNDepartureCheckList
            int result = new TRNTraineeBO().InsertTrainee(MapTrainee(), MapCurrentEmployment(), MapEmployment(), MapPreviousTraining(), checkList);

            if (result > 0)
            {
                Clear();
            }
            else
            {
                Response.Write("Profile not saved successfully.");
            }
        }

        private void Clear()
        {

            ddlQualification.SelectedValue = "0";
            ddlInformationSource.SelectedValue = "0";
            ddlVDC.SelectedValue = "0";
            ddlDistrict.SelectedValue = "0";
            ddlCastEthinicity.SelectedValue = "0";
            ddlCitizenshipIssuedDistict.SelectedValue = "0";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            ddlGender.SelectedValue = "0";
            ddlMaritalStatus.SelectedValue = "0";
            txtDateOfBirthAD.Text = "";
            txtDateOfBirthBS.Text = "";
            txtAge.Text = "";
            hfSpecialCase.Value = "";
            txtTol.Text = "";
            txtWardNumber.Text = "";
            txtPhoneNumberHouse.Text = "";
            txtMobile.Text = "";
            txtCitizenshipNumber.Text = "";
            txtPassportNumber.Text = "";
            txtFathersName.Text = "";
            txtFathersContactNumber.Text = "";
            txtContactPerson.Text = "";
            txtContactPersonContactTelephone.Text = "";
            chkUnEmployment.Checked = false;
            txtSelfEmploymentIncome.Text = "";
            txtWageIncome.Text = "";
            txtAgricultureIncome.Text = "";
            txtForeignIncome.Text = "";
            txtOtherIncome.Text = "";
            txtFamilyMember.Text = "";
            ddlFeedDurationTypeID.SelectedValue = "0";
            txtReferredBy.Text = "";        
            ddlEvent.SelectedValue = "0";
            

        }

        public void Data()
        {
            //ddlTrainingAgency.SelectedValue = "2";
            ddlQualification.SelectedValue = "1";
            ddlInformationSource.SelectedValue = "1";

            ddlDistrict.SelectedValue = "3";
            ddlCastEthinicity.SelectedValue = "1";
            ddlFeedDurationTypeID.SelectedValue = "1";
            ddlCitizenshipIssuedDistict.SelectedValue = "1";
            ddlGender.SelectedValue = "1";
            ddlMaritalStatus.SelectedValue = "1";

            txtFirstName.Text = "a";
            txtLastName.Text = "a";
            //txtDateOfBirthAD.Text = "08/26/2014";
            //txtDateOfBirthBS.Text = "08/26/2014";
            txtAge.Text = "1";
            //lblSpecialCase.Text = "a";
            txtTol.Text = "1";
            txtWardNumber.Text = "1";
            txtPhoneNumberHouse.Text = "1";

            txtMobile.Text = "1";
            txtCitizenshipNumber.Text = "1";
            txtPassportNumber.Text = "1";
            txtFathersName.Text = "1";
            txtFathersContactNumber.Text = "1";
            txtContactPerson.Text = "1";
            txtContactPersonContactTelephone.Text = "1";

            chkUnEmployment.Text = "Unemployed";
            txtSelfEmploymentIncome.Text = "1";
            txtWageIncome.Text = "1";
            txtAgricultureIncome.Text = "1";
            txtForeignIncome.Text = "1";
            txtOtherIncome.Text = "1";
            txtFamilyMember.Text = "1";

            txtCompany.Text = "2";
            ddlEmploymentType.SelectedValue = "2";
            ddlEmploymentStatus.SelectedValue = "2";
            txtPastRecruitmentAgency.Text = "2";

            txtMonthlySalary.Text = "1";
            txtDepartureDate.Text = "08/26/2014";
            txtReturnDate.Text = "08/26/2014";

            txtTrainingName.Text = "1";
            txtTrainingYear.Text = "1";
            txtTrainingInstituteName.Text = "1";
            txtTrainingDuration.Text = "1 months";


        }

        protected void chkUnEmployment_checkedChanged(object sender, EventArgs e)
        {

        }
        
        public  void GetAge(String date)
        {
            if (date.Length == 10)
            {
                NepaliToEnglishConversion convert = new NepaliToEnglishConversion();
                Dictionary<string, string> enDate = convert.nep_to_eng(date);
                //return enDate["year"].ToString() + "-" + enDate["month"].ToString() + "-" + enDate["date"].ToString();
                string dateAD = enDate["year"].ToString() + "/" + enDate["month"].ToString() + "/" + enDate["date"].ToString();


                String[] dateofBirths = dateAD.Split('/');

                int yy = DateTime.Now.Year;
                int mm = DateTime.Now.Month;
                int dd = DateTime.Now.Day;

                int yyyy = Convert.ToInt32(dateofBirths[0]);
                int mmmm = Convert.ToInt32(dateofBirths[1]);
                int dddd = Convert.ToInt32(dateofBirths[2]);

                int year = yy - yyyy;
                int month = mm - mmmm;
                int day = dd - dddd;

                if (day >= 30)
                    month++;

                if (month >= 12)
                    year++;

                txtAge.Text = year.ToString();


            }
            else
                txtAge.Text = "";
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            GetAge(txtDateOfBirthBS.Text);
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Training/TRNEvent/");
        }

    }
}