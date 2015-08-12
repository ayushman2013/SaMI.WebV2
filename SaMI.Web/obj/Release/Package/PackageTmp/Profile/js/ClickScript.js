function ResetClick() {

    $(function () {

        //Accept numbers only
        $("#ctl00_MainContent_txtWard").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }
        });
        $("#ctl00_MainContent_txtWardTemp").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }
        });

        $("#ctl00_MainContent_txtSelfEmploymentIncome").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }
        });
        $("#ctl00_MainContent_txtAgricultureIncome").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }
        });
        $("#ctl00_MainContent_txtWageIncome").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }
        });
        $("#ctl00_MainContent_txtOtherIncome").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }
        });
        $("#ctl00_MainContent_txtFamilyWageIncome").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }
        });
        $("#ctl00_MainContent_txtFamilyAgricultureIncome").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }
        });
        $("#ctl00_MainContent_txtFamilySalaryIncome").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }
        });
        $("#ctl00_MainContent_txtFamilyForeignIncome").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }
        });
        $("#ctl00_MainContent_txtFamilyBusinessIncome").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }
        });
        $("#ctl00_MainContent_txtFamilyOtherIncome").keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }
        });

        $("#ctl00_MainContent_txtRegistrationDate").datepicker();
        $("#ctl00_MainContent_txtDateofRefferal").datepicker();
        $("#ctl00_MainContent_txtCaseFollowUpDate").datepicker();
        $("#ctl00_MainContent_txtFollowUpDate").datepicker();
        $("#ctl00_MainContent_txtCaseRegisteredDate").datepicker();
        $("#ctl00_MainContent_txtTrainingStartDate").datepicker();
        $("#ctl00_MainContent_txtEmploymentStartDate").datepicker();
        $("#ctl00_MainContent_txtTrainingRegistrationDate").datepicker();
        $("#ctl00_MainContent_txtReferralDate").datepicker();
        $("#ctl00_MainContent_txtMigratedDate").datepicker();
        $("#ctl00_MainContent_txtDateOfFollowUp").datepicker();


        $("input#ctl00_MainContent_rbFemale").click(function () {
            $('input:radio[id=ctl00_MainContent_rbDiscriminated]').prop('checked', true);
        });

        //Job Offer Yes No
        $("input#ctl00_MainContent_rbJobOfferYes").click(function () {
            $("#ctl00_MainContent_ddlJobOfferSource").removeAttr("disabled");
            $("#ctl00_MainContent_ddlJobOfferedType").removeAttr("disabled");
            $("#ctl00_MainContent_ddlWorkType").attr("disabled", "disabled");

        });
        $("input#ctl00_MainContent_rbJobOfferNo").click(function () {
            $("#ctl00_MainContent_ddlJobOfferSource").attr("disabled", "disabled");
            $("#ctl00_MainContent_ddlJobOfferedType").attr("disabled", "disabled");
            $("#ctl00_MainContent_ddlWorkType").removeAttr("disabled");
        });

        //Made Payment Yes No
        $("input#ctl00_MainContent_rbMadePaymentYes").click(function () {
            $("#ctl00_MainContent_txtMadePaymentAmount").removeAttr("disabled");
            $("#ctl00_MainContent_txtReceiptPaymentAmount").removeAttr("disabled");
            $("#ctl00_MainContent_rblPaymentReceiptYes").removeAttr("disabled");
            $("#ctl00_MainContent_rblPaymentReceiptNo").removeAttr("disabled");

            $("#ctl00_MainContent_chkNothingYet").attr("disabled", "disabled");
            $("#ctl00_MainContent_txtAskedPaymentAmount").attr("disabled", "disabled");

        });
        $("input#ctl00_MainContent_rbMadePaymentNo").click(function () {
            $("#ctl00_MainContent_txtMadePaymentAmount").attr("disabled", "disabled");
            $("#ctl00_MainContent_txtReceiptPaymentAmount").attr("disabled", "disabled");
            $("#ctl00_MainContent_rblPaymentReceiptYes").attr("disabled", "disabled");
            $("#ctl00_MainContent_rblPaymentReceiptNo").attr("disabled", "disabled");

            $("#ctl00_MainContent_chkNothingYet").removeAttr("disabled");
            $("#ctl00_MainContent_txtAskedPaymentAmount").removeAttr("disabled");
        });

        //Payment Receipt Yes No
        $("input#ctl00_MainContent_rblPaymentReceiptYes").click(function () {
            $("#ctl00_MainContent_txtReceiptPaymentAmount").removeAttr("disabled");

        });
        $("input#ctl00_MainContent_rblPaymentReceiptNo").click(function () {
            $("#ctl00_MainContent_txtReceiptPaymentAmount").attr("disabled", "disabled");
        });

        //Payment Receipt Yes No
        $("input#ctl00_MainContent_chkNothingYet").click(function () {
            if (!$("#ctl00_MainContent_chkNothingYet").is(':checked'))
                $("#ctl00_MainContent_txtAskedPaymentAmount").removeAttr("disabled");
            else
                $("#ctl00_MainContent_txtAskedPaymentAmount").attr("disabled", "disabled");

        });


        //Previous Foreign Experience


        $("input#ctl00_MainContent_rbPrevFEExperienceYes").click(function () {
            $("#ctl00_MainContent_ddlCountry").removeAttr("disabled");
            $("#ctl00_MainContent_ddlJobType").removeAttr("disabled");
            $("#ctl00_MainContent_ddlStayDuration").removeAttr("disabled");



        });
        $("input#ctl00_MainContent_rbPrevFEExperienceNo").click(function () {
            $("#ctl00_MainContent_ddlCountry").attr("disabled", "disabled");
            $("#ctl00_MainContent_ddlJobType").attr("disabled", "disabled");
            $("#ctl00_MainContent_ddlStayDuration").attr("disabled", "disabled");
        });

        $("input#ctl00_MainContent_rbAdditionalInfoYes").click(function () {
            var CHK = document.getElementById("ctl00_MainContent_cblAdditionalDocument");
            var checkbox = CHK.getElementsByTagName("input");
            //for (var i = 0; i < checkbox.length; i++){
            //checkbox[i].attr("disabled", "disabled"); 

        });
        $("input#ctl00_MainContent_rbAdditionalInfoNo").click(function () {
            //$("#ctl00_MainContent_ddlFollowUp").attr("disabled", "disabled");
        });

        $("#ctl00_MainContent_rbFurtherFollowUpYes").click(function () {
            $("#ctl00_MainContent_ddlFurtherFollowUp").removeAttr("disabled");

        });
        $("#ctl00_MainContent_rbFurtherFollowUpNo").click(function () {
            $("#ctl00_MainContent_ddlFurtherFollowUp").attr("disabled", "disabled");
        });


        $("input#ctl00_MainContent_rbReasonReceipt").click(function () {
            $('input:radio[id=ctl00_MainContent_rbWasTooDifficult]').prop('checked', true);
            $('input:radio[id=ctl00_MainContent_rbReasonForNonCompliance]').prop('checked', true);
            $('input:radio[id=ctl00_MainContent_rbCompliedPartly]').prop('checked', true);
            ///
            $('input:radio[id=ctl00_MainContent_rbReasonForNonCompliance]').prop('checked', true);
            $('input:radio[id=ctl00_MainContent_rbCompliedPartly]').prop('checked', true);

        });
        $("input#ctl00_MainContent_rbOther").click(function () {
            $('input:radio[id=ctl00_MainContent_rbWasTooDifficult]').prop('checked', true);
            $('input:radio[id=ctl00_MainContent_rbReasonForNonCompliance]').prop('checked', true);
            $('input:radio[id=ctl00_MainContent_rbCompliedPartly]').prop('checked', true);
        });
        $("input#ctl00_MainContent_rbWasTooDifficult").click(function () {
            $('input:radio[id=ctl00_MainContent_rbReasonForNonCompliance]').prop('checked', true);
            $('input:radio[id=ctl00_MainContent_rbCompliedPartly]').prop('checked', true);
        });


        $("input#ctl00_MainContent_rbReasonRecommendation").click(function () {
            $('input:radio[id=ctl00_MainContent_rbReasonForNonCompliance]').prop('checked', true);
            $('input:radio[id=ctl00_MainContent_rbCompliedPartly]').prop('checked', true);

        });
        $("input#ctl00_MainContent_rbReasonFamilyMember").click(function () {

            $('input:radio[id=ctl00_MainContent_rbReasonForNonCompliance]').prop('checked', true);
            $('input:radio[id=ctl00_MainContent_rbCompliedPartly]').prop('checked', true);
        });

        $("input#ctl00_MainContent_rbDidNotComply").click(function () {
            $('input:radio[id=ctl00_MainContent_rbCompliedPartly]').prop('checked', true);
        });
        $("input#ctl00_MainContent_rbReasonForNonCompliance").click(function () {
            $('input:radio[id=ctl00_MainContent_rbCompliedPartly]').prop('checked', true);
        });


        $("input#ctl00_MainContent_rbComplied").click(function () {
            $('input:radio[id=ctl00_MainContent_rbDidNotComply]').prop('checked', false);
            $('input:radio[id=ctl00_MainContent_rbReasonForNonCompliance]').prop('checked', false);
            $('input:radio[id=ctl00_MainContent_rbWasTooDifficult]').prop('checked', false);
            $('input:radio[id=ctl00_MainContent_rbReasonRecommendation]').prop('checked', false);
            $('input:radio[id=ctl00_MainContent_rbReasonReceipt]').prop('checked', false);
            $('input:radio[id=ctl00_MainContent_rbOther]').prop('checked', false);
            $('input:radio[id=ctl00_MainContent_rbReasonFamilyMember]').prop('checked', false);
        });
        $("input#ctl00_MainContent_rbDidNotComply").click(function () {
            $('input:radio[id=ctl00_MainContent_rbWasTooDifficult]').prop('checked', false);
            $('input:radio[id=ctl00_MainContent_rbReasonRecommendation]').prop('checked', false);
            $('input:radio[id=ctl00_MainContent_rbReasonReceipt]').prop('checked', false);
            $('input:radio[id=ctl00_MainContent_rbOther]').prop('checked', false);
            $('input:radio[id=ctl00_MainContent_rbReasonFamilyMember]').prop('checked', false);
        });
        $("input#ctl00_MainContent_rbReasonRecommendation").click(function () {
            $('input:radio[id=ctl00_MainContent_rbReasonReceipt]').prop('checked', false);
            $('input:radio[id=ctl00_MainContent_rbOther]').prop('checked', false);
        });

        $("input#ctl00_MainContent_rbReasonFamilyMember").click(function () {
            $('input:radio[id=ctl00_MainContent_rbReasonReceipt]').prop('checked', false);
            $('input:radio[id=ctl00_MainContent_rbOther]').prop('checked', false);
        });


        //Other Member
        $("input#ctl00_MainContent_rbSendMoneyYes").click(function () {
            $("#ctl00_MainContent_ddlMoneyRange").removeAttr("disabled");

        });
        $("input#ctl00_MainContent_rbSendMoneyNo").click(function () {
            $("#ctl00_MainContent_ddlMoneyRange").attr("disabled", "disabled");
        });
        $("input#ctl00_MainContent_rbProblemFacedYes").click(function () {
            $("#ctl00_MainContent_ddlProblemType").removeAttr("disabled");

        });
        $("input#ctl00_MainContent_rbProblemFacedNo").click(function () {
            $("#ctl00_MainContent_ddlProblemType").attr("disabled", "disabled");
        });


        //Employment Skill
        $("input#ctl00_MainContent_chkUnEmployment").click(function () {
            if ($("#ctl00_MainContent_chkUnEmployment").is(':checked')) {

                $("#ctl00_MainContent_txtSelfEmploymentIncome").attr("disabled", "disabled");
                $("#ctl00_MainContent_txtAgricultureIncome").attr("disabled", "disabled");
                $("#ctl00_MainContent_txtWageIncome").attr("disabled", "disabled");
                $("#ctl00_MainContent_txtOtherIncome").attr("disabled", "disabled");
            }
            else {

                $("#ctl00_MainContent_txtSelfEmploymentIncome").removeAttr("disabled");
                $("#ctl00_MainContent_txtAgricultureIncome").removeAttr("disabled");
                $("#ctl00_MainContent_txtWageIncome").removeAttr("disabled");
                $("#ctl00_MainContent_txtOtherIncome").removeAttr("disabled");
            }

        });
        $("input#ctl00_MainContent_rbHavePreviousTrainingYes").click(function () {

            $("#ctl00_MainContent_txtPreTrainingName").removeAttr("disabled");
            $("#ctl00_MainContent_txtPreTrainingYear").removeAttr("disabled");
            $("#ctl00_MainContent_txtPreTrainingInstituteName").removeAttr("disabled");
            $("#ctl00_MainContent_txtPreTrainingPeriod").removeAttr("disabled");

        });
        $("input#ctl00_MainContent_rbHavePreviousTrainingNo").click(function () {
            $("#ctl00_MainContent_txtPreTrainingName").attr("disabled", "disabled");
            $("#ctl00_MainContent_txtPreTrainingYear").attr("disabled", "disabled");
            $("#ctl00_MainContent_txtPreTrainingInstituteName").attr("disabled", "disabled");
            $("#ctl00_MainContent_txtPreTrainingPeriod").attr("disabled", "disabled");

        });

        $("input#ctl00_MainContent_rbCompensationYes").click(function () {
            $("#ctl00_MainContent_txtCompensationAmount").removeAttr("disabled");

        });
        $("input#ctl00_MainContent_rbCompensationNo").click(function () {
            $("#ctl00_MainContent_txtCompensationAmount").attr("disabled", "disabled");

        });

        //Case Documentation
        $("input#ctl00_MainContent_rbRefferToYes").click(function () {
            $("#ctl00_MainContent_ddlRefferToYes").removeAttr("disabled");
            $("#ctl00_MainContent_ddlRefferToNo").attr("disabled", "disabled");

        });
        $("input#ctl00_MainContent_rbRefferToNo").click(function () {
            $("#ctl00_MainContent_ddlRefferToNo").removeAttr("disabled");
            $("#ctl00_MainContent_ddlRefferToYes").attr("disabled", "disabled");

        });

        //Phone follow up
        $("input#ctl00_MainContent_rbtnLeftFEYes").click(function () {
            $("#panelLeftFEYes").show();
            $("#panelLeftFENo").hide();
            $("#panelMigratedAfterTraining").hide();
            $("#ctl00_MainContent_rbtnMigratedAfterTrainingYes").prop('checked', '');
            $("#ctl00_MainContent_rbtnMigratedAfterTrainingNo").prop('checked', '');
        });

        $("input#ctl00_MainContent_rbtnLeftFENo").click(function () {
            $("#panelLeftFEYes").hide();
            $("#panelLeftFENo").show();
            $("#panelMigratedAfterTraining").hide();
            $("#ctl00_MainContent_rbtnMigratedAfterTrainingYes").prop('checked', '');
            $("#ctl00_MainContent_rbtnMigratedAfterTrainingNo").prop('checked', '');

            
        });

        $("input#ctl00_MainContent_rbtnMigratedAfterTrainingYes").click(function () {
            $("#panelMigratedAfterTraining").show();
        });
        $("input#ctl00_MainContent_rbtnMigratedAfterTrainingNo").click(function () {
            $("#panelMigratedAfterTraining").show();
        });

        $("#ctl00_MainContent_ddlCurrentStatus").change(function () {
            var currentStatus = $("#ctl00_MainContent_ddlCurrentStatus option:selected").val();
            if (currentStatus == "Other")
                $("#ctl00_MainContent_txtCurrentStatus").show();
            else
                $("#ctl00_MainContent_txtCurrentStatus").hide();
        });

    });

}

function ShowModel(id) {
    alert('show');
    $('#employment').modal('show');
    return true;
}

function PFEClickScript() {
    $(function () {
        //            $("#ctl00_MainContent_rbPrevFEExperienceNo").prop('checked', 'checked');
        //$('#PreviousFEExperience').modal('hide');

        $("input#ctl00_MainContent_rbPrevFEExperienceYes").click(function () {
            $('#PreviousFEExperience').modal('show');
        });

        $("input#ctl00_MainContent_rbPrevFEExperienceNo").click(function () {
            $('#PreviousFEExperience').modal('hide');
        });

        $("#ctl00_MainContent_btnAddPFEExperience").click(function () {
            $("#ctl00_MainContent_gvPFE").attr("visible", "visible");
        });

        $('#PreviousFEExperience [data-dismiss="modal"]').on('click', function () {
            $('#ctl00_MainContent_rbPrevFEExperienceYes').prop('checked', '');
            $('#ctl00_MainContent_rbPrevFEExperienceNo').prop('checked', '');
        });

        $('#ctl00_MainContent_btnAddPFEExperience').on('click', function () {
            $('#ctl00_MainContent_rbPrevFEExperienceYes').prop('checked', '');
            $('#ctl00_MainContent_rbPrevFEExperienceNo').prop('checked', '');
        });
    });
}

function PhoneFollowUpClickScript() {
    $(function () {
        $("input#ctl00_MainContent_btnAdd").click(function (e) {
            $("#ctl00_MainContent_txtNameOfInformants").val('');
            $("#ctl00_MainContent_txtRelationMigrant").val('');
            $("#ctl00_MainContent_txtDateOfFollowUp").val('');
            $("#ctl00_MainContent_txtRemarks").val('');
            e.preventDefault();
            
            $('#PhoneFollowUpInfo').modal('show');
            
        });

        //function func() {
        //    alert("success");
        //}
    });

   
}

function Func() {
    console.warn("success");
    $("#panelMigratedAfterTraining").hide();
    $("#panelLeftFENo").hide();
    $("#panelLeftFEYes").hide();
    $("#ctl00_MainContent_txtCurrentStatus").hide();
    if ($("#ctl00_MainContent_rbtnLeftFEYes").is(':checked')) {
        $("#panelLeftFEYes").show();
        $("#panelLeftFENo").hide();
        if ($("#ctl00_MainContent_rbtnMigratedAfterTrainingYes").is(':checked')) {
            $("#panelMigratedAfterTraining").show();
        };
        if ($("#ctl00_MainContent_rbtnMigratedAfterTrainingNo").is(':checked')) {
            $("#panelMigratedAfterTraining").show();
        };
        
    }
    if ($("#ctl00_MainContent_rbtnLeftFENo").is(':checked')) {
        $("#panelLeftFEYes").hide();
        $("#panelLeftFENo").show();
        if ($("#ctl00_MainContent_ddlCurrentStatus option:selected").val() == 'Other') {
            $("#ctl00_MainContent_txtCurrentStatus").show();
        };
    }
    //if ($("#ctl00_MainContent_rbtnMigratedAfterTrainingYes").is(':checked')) {
    //    $("#panelMigratedAfterTraining").show();
    //};
    //if ($("#ctl00_MainContent_rbtnMigratedAfterTrainingNo").is(':checked')) {
    //    $("#panelMigratedAfterTraining").hide();
    //};

    //if ($("#ctl00_MainContent_ddlCurrentStatus option:selected").val() == 'Other') {
    //    $("#ctl00_MainContent_txtCurrentStatus").show();
    //};

    $("#ctl00_MainContent_btnSavePhoneFollowUp").show();
    $("#ctl00_MainContent_btnSaveSkills").hide();
    $("#ctl00_MainContent_btnSave").hide();
    $("#ctl00_MainContent_btnSaveForeignEmployment").hide();
    $("#ctl00_MainContent_btnSaveOptionalInformation").hide();
    $("#ctl00_MainContent_btnSaveCaseDocumentation").hide();
    $("#ctl00_MainContent_btnSaveServices").hide();

    return false;
}

$(document).ready(function () {
    $("#panelLeftFEYes").hide();
    $("#panelLeftFENo").hide();
    $("#panelMigratedAfterTraining").hide();
    $("#ctl00_MainContent_txtCurrentStatus").hide();

        if ($("#ctl00_MainContent_rbtnLeftFEYes").is(':checked')) {
            $("#panelLeftFEYes").show();
            $("#panelLeftFENo").hide();
        }

        if ($("#ctl00_MainContent_rbtnLeftFENo").is(':checked')) {
            $("#panelLeftFEYes").hide();
            $("#panelLeftFENo").show();
        }

        if ($("#ctl00_MainContent_rbtnMigratedAfterTrainingYes").is(':checked')) {
            $("#panelMigratedAfterTraining").show();
        };
        if ($("#ctl00_MainContent_rbtnMigratedAfterTrainingNo").is(':checked')) {
            $("#panelMigratedAfterTraining").show();
        };

        if ($("#ctl00_MainContent_ddlCurrentStatus option:selected").val() == 'Other') {
            $("#ctl00_MainContent_txtCurrentStatus").show();
        };
});