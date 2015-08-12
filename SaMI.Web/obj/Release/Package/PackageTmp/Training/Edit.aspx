<%@ Page Title="" Language="C#" MasterPageFile="~/Trainings.Master" AutoEventWireup="true"
    CodeBehind="Edit.aspx.cs" Inherits="SaMI.Web.Training.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Training/css/bootstrap-select.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/Training/js/bootstrap-select.js"> </script>
    <script type="text/javascript" src="/Training/js/ClickScript.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            ResetClick();

            $('#ctl00_TrainingBody_txtTrainingRegistrationDate').datepicker();          
            $('#ctl00_TrainingBody_txtDepartureDate').datepicker();
            $('#ctl00_TrainingBody_txtReturnDate').datepicker();

            $('#ctl00_TrainingBody_ddlTraineeCheckList').on('change', function () {
                var str = "";
                $("#ctl00_TrainingBody_ddlTraineeCheckList :selected").each(function () {
                    str += $(this).val() + ",";
                });

                $("#<%=hfTraineeCheckList.ClientID%>").val(str);

            });

            $('#ctl00_TrainingBody_ddlSpecialCase').on('change', function () {
                var str = "";
                $("#ctl00_TrainingBody_ddlSpecialCase :selected").each(function () {
                    str += $(this).val() + ",";
                });
                $('#<%= hfSpecialCase.ClientID%>').val(str);

            });

            var string = $("#ctl00_TrainingBody_hfTraineeCheckList").val();
            var myarr = string.split(",");
            var i = 0;
            $('#ctl00_TrainingBody_ddlTraineeCheckList option').each(function () {
                $('#ctl00_TrainingBody_ddlTraineeCheckList option[value=' + myarr[i] + ']').attr('selected', true);
                i++;
            });

            var specialcase = $("#ctl00_TrainingBody_hfSpecialCase").val();
            var specialcasearr = specialcase.split(",");
            j = 0;
            $('#ctl00_TrainingBody_ddlSpecialCase option').each(function () {
                $('#ctl00_TrainingBody_ddlSpecialCase option[value=' + specialcasearr[j] + ']').attr('selected', true);
                j++
            });



        });
    </script>
    <script type="text/javascript">
        function ShowpImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#ctl00_TrainingBody_ImgPrv').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
    <script type="text/javascript" language="javascript">
        function validatenumerics(key) {
            //getting key code of pressed key
            var keycode = (key.which) ? key.which : key.keyCode;
            //comparing pressed keycodes

            if (keycode > 31 && (keycode < 48 || keycode > 57)) {
                alert(" You can enter only characters 0 to 9 ");
                return false;
            }
            else return true;


        }</script>
    <script type="text/javascript" src="/Training/js/ValidateAdd.js"></script>
    <script src="/Training/js/jquery.maskedinput.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TrainingBody" runat="server">
    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!--Heading-->
    <div class="col-md-12">
        <h3>Edit Trainee Profile
            <asp:Button ID="btnSave" CssClass="btn btn-default" runat="server" Text="Save" OnClick="btnSave_Click"
                OnClientClick="return ValidateTraineeProfile();" />
             <asp:Button ID="btnClose" CssClass="btn btn-default" runat="server" Text="Close" OnClick="btnClose_Click" />
        </h3>
    </div>
    <div class="col-md-6">
    </div>
    <div class="col-md-12">
        <!--Personal Information-->
        <asp:UpdatePanel ID="UpdatePanelPersonalInfo" runat="server">
            <ContentTemplate>
                <div class="col-md-4 padding padding-first">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Personal Information</h3>
                        </div>
                        <div class="panel-body">
                            <table>
                                <tr>
                                    <td>
                                        <label>
                                            First Name*</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Last Name*</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Sex*</label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                                            <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                                            <asp:ListItem Text="Other" Value="O"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Marital Status*</label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlMaritalStatus" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Married" Value="M"></asp:ListItem>
                                            <asp:ListItem Text="Unmarried" Value="U"></asp:ListItem>
                                            <asp:ListItem Text="Divorced" Value="D"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                        </label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDateOfBirthAD" runat="server" Visible="false" CssClass="form-control input-sm"
                                            placeholder="MM/DD/YYYY"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Date of Birth (BS)*</label>
                                    </td>
                                    <td>

                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDateOfBirthBS"
                                            ErrorMessage="Format: YYYY/MM/DD (Eg. 2047/06/10)" ValidationExpression="^(20)\d\d[ /.](0[1-9]|1[012])[ /.](0[1-9]|[12][0-9]|3[01])$"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txtDateOfBirthBS" runat="server" CssClass="form-control input-sm"
                                            placeholder="YYYY/MM/DD"></asp:TextBox>



                                        <asp:Button ID="btnCalculate" runat="server" OnClick="btnCalculate_Click" Text="C" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Age</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAge" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Qualification*</label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlQualification" runat="server" CssClass="form-control input-sm"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Cast/Ethnicity*</label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCastEthinicity" runat="server" CssClass="form-control input-sm" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlCastEthinicity_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rbValidRegions" runat="server" RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <!--Contact Information-->
        <asp:UpdatePanel ID="UpdatePanelContactInfo" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="col-md-4">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Contact Information</h3>
                        </div>
                        <div class="panel-body">
                            <table>
                                <tr>
                                    <td>
                                        <label>
                                            District*</label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlDistrict" AutoPostBack="true" runat="server" CssClass="form-control input-sm"
                                            OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            VDC*</label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlVDC" runat="server" CssClass="form-control input-sm" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Tole</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTol" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Ward No*</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtWardNumber" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Phone Number*
                                        </label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPhoneNumberHouse" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Mobile</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Fathers Name*</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFathersName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Contact Number</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFathersContactNumber" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Contact Person</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtContactPerson" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Telephone Number</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtContactPersonContactTelephone" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <!--Other Information-->
        <div class="col-md-4 padding padding-last">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Other Information</h3>
                </div>
                <div class="panel-body">
                    <table>
                        <tr>
                            <td>
                                <label>
                                    Citizenship No*</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCitizenshipNumber" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Citizenship Issued Distict*</label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanelOtherInfo" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCitizenshipIssuedDistict" runat="server" CssClass="form-control input-sm"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Passport No</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassportNumber" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Special Case</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSpecialCase" runat="server" CssClass="selectpicker" multiple="multiple"
                                    data-selected-text-format="count">
                                    <asp:ListItem Value="1" Text="Purba Janamukti Sena"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Antarik Bistapit"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Ekal Woman"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:HiddenField ID="hfSpecialCase" runat="server"></asp:HiddenField>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    How did get information about training?*</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlInformationSource" runat="server" CssClass="selectpicker"
                                    data-live-search="true">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Referred By*</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtReferredBy" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-12">
        <!--Employment & Income Details-->
        <asp:UpdatePanel ID="UpdatePanelEmpIncomeDetail" runat="server">
            <ContentTemplate>
                <div class="col-md-4 padding padding-first">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Employment & Income Details:</h3>
                        </div>
                        <div class="panel-body">
                            <table>
                                <tr>
                                    <td>
                                        <label>
                                            Family Member*</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFamilyMember" runat="server" CssClass="form-control input-sm"
                                            onkeypress="return validatenumerics(event);">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="chkUnEmployment" runat="server" Text="Unemployed" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Self-employment Rs</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSelfEmploymentIncome" runat="server" CssClass="form-control input-sm"
                                            onkeypress="return validatenumerics(event);"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Agriculture Rs</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAgricultureIncome" runat="server" CssClass="form-control input-sm"
                                            onkeypress="return validatenumerics(event);"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Wages Rs</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtWageIncome" runat="server" CssClass="form-control input-sm" onkeypress="return validatenumerics(event);"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Foreign Employment Rs</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtForeignIncome" runat="server" CssClass="form-control input-sm"
                                            onkeypress="return validatenumerics(event);"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Others Rs</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOtherIncome" runat="server" CssClass="form-control input-sm"
                                            onkeypress="return validatenumerics(event);"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <label>
                                            Feeding duration from your own land agriculture products*</label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddlFeedDurationTypeID" runat="server" CssClass=" col-lg-12 form-control input-sm">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <!--Current Abroad Information-->
        <asp:UpdatePanel ID="UpdatePanelAbroadInfo" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="col-md-4 padding padding-last padding-first">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Abroad Information</h3>
                        </div>
                        <div class="panel-body">
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <label>
                                            Are you going abroad?
                                        </label>
                                        <asp:RadioButton ID="rdoAbroadYes" Text="Yes" Checked="False" GroupName="AbroadRecord"
                                            runat="server" />
                                        <asp:RadioButton ID="rdoAbroadNo" Text="No" Checked="False" GroupName="AbroadRecord"
                                            runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Country*</label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="selectpicker" data-live-search="true">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Departure Date*</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDepartureDate" runat="server" CssClass="date_input form-control input-sm"
                                            placeholder="MM/DD/YYYY"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Recruitment Agency*</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPastRecruitmentAgency" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Name of Company*</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCompany" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Employment Type*</label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlEmploymentType" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Employment Status*</label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlEmploymentStatus" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <label>
                                            EmploymentPeriod*</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmploymentPeriod" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Monthly Salary</label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Nepali Currency*</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMonthlySalary" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Foreign Currency</label>
                                    </td>

                                    <td>
                                        <asp:TextBox ID="txtForeignCurrency" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                        </label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtReturnDate" runat="server" Visible="false" CssClass="form-control input-sm" placeholder="MM/DD/YYYY"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Check List*</label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlTraineeCheckList" runat="server" CssClass="selectpicker"
                                            multiple="multiple" data-selected-text-format="count">
                                        </asp:DropDownList>
                                        <br />
                                        <asp:HiddenField ID="hfTraineeCheckList" runat="server"></asp:HiddenField>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <!--Previous Training Information-->
        <div class="col-md-4 padding padding-last" style="margin-top: -80px">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Previous Training Information</h3>
                </div>
                <div class="panel-body">
                    <table>
                        <tr>
                            <td colspan="2">
                                <label>
                                    Have you took training before?</label>
                                <asp:RadioButton ID="rbHavePreviousTrainingYes" Text="Yes" GroupName="training-before"
                                    runat="server" />
                                <asp:RadioButton ID="rbHavePreviousTrainingNo" Text="No" GroupName="training-before"
                                    runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Training Name*</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTrainingName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Training Year*</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTrainingYear" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Institute Name*</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTrainingInstituteName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Training Duration*</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTrainingDuration" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>

        <!--Previous Abroad Information-->
        <div class="col-md-4 padding padding-last">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Have the trainee gone Overseas previously?
                         <asp:RadioButton ID="rbCurrentCountryYes" Text="Yes" GroupName="CurrentAbroad"
                             runat="server" />
                        <asp:RadioButton ID="rbCurrentCountryNo" Text="No" GroupName="CurrentAbroad"
                            runat="server" />

                    </h3>
                </div>
                <div class="panel-body">
                    <table>
                        <tr>
                            <td>
                                <label>
                                    Country*</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlWhichCountry" runat="server" CssClass="selectpicker" data-live-search="true">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Working Period</label>
                            </td>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Years:</label>
                            </td>

                            <td>
                                <asp:TextBox ID="txtWorkingYears" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Months:</label>
                            </td>

                            <td>
                                <asp:TextBox ID="txtWorkingMonths" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Occupation:</label>
                            </td>

                            <td>
                                <asp:TextBox ID="txtOccupation" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Monthly Salary:</label>
                            </td>

                            <td>
                                <asp:TextBox ID="txtPreviousMonthlySalary" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Return Date:</label>
                            </td>

                            <td>
                                <asp:TextBox ID="txtPreviousReturnDate" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <!-- Are You Going Abroad? -->

        <div class="col-md-4 padding padding-last">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Photo</h3>
                </div>
                <div class="panel-body">
                    <table>
                        <tr>
                            <td>
                                <label>
                                    Photo:</label>
                            </td>
                            <td>
                                <asp:Image ID="ImgPrv" Style="margin-top: -18px;" Height="80px" Width="80px" runat="server" /><br />
                            </td>
                            <td>
                                <asp:FileUpload ID="fuPhoto" runat="server" CssClass="form-control input-sm" onchange="ShowpImagePreview(this);" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="validationModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" id="H3">Please correct the error(s) below:</h4>
                </div>
                <div class="modal-body">
                    <div id="modal-body-text" style="color: Red; font-weight: bold;">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        Close</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
    </div>
    <script type="text/javascript">

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);

        function BeginRequestHandler(sender, args) {
            ResetClick();
            $('#ctl00_TrainingBody_txtDateOfBirthAD').datepicker({ dateFormat: 'yy-mm-dd', changeYear: true });
            //$('#ctl00_TrainingBody_txtDateOfBirthBS').nepaliDatePicker({ dateFormat: 'yy-mm-dd' });
        }

        function EndRequestHandler(sender, args) {

            ResetClick();
            $('#ctl00_TrainingBody_txtDateOfBirthAD').datepicker({ dateFormat: 'yy-mm-dd', changeYear: true });
            // $('#ctl00_TrainingBody_txtDateOfBirthBS').nepaliDatePicker({ dateFormat: 'yy-mm-dd' });

        }
    </script>
</asp:Content>
