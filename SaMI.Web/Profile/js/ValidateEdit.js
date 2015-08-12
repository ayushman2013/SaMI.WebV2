
function ValidateForeignEmployment() {

    var validation = true;
    var message = '<ul>';


    if ($('#ctl00_MainContent_ddlDecisionStatus').val() == '0') {
        validation = false;
        message += "<li>Please select Decision.</li>";
    }

    if ($('#ctl00_MainContent_ddlPassportStatus').val() == '0') {
        validation = false;
        message += "<li>Please select Passport Status.</li>";
    }

    if (!$("#ctl00_MainContent_rbJobOfferYes").is(':checked') && !$("#ctl00_MainContent_rbJobOfferNo").is(':checked')) {
        validation = false;
        message += "<li>Please choose Do you have job offer?.</li>";
    }
    else if ($("#ctl00_MainContent_rbJobOfferYes").is(':checked')) {
        if ($('#ctl00_MainContent_ddlJobOfferSource').val() == '0') {
            validation = false;
            message += "<li>Please select Job Offer from whom?</li>";
        }
        if ($('#ctl00_MainContent_ddlJobOfferedType').val() == '0') {
            validation = false;
            message += "<li>Please select Job Offered type.</li>";
        }
    } else {
        if ($('#ctl00_MainContent_ddlWorkType').val() == '0') {
            validation = false;
            message += "<li>Please select For what type of Work?</li>";
        }
    }

    /*if ($('#ctl00_MainContent_ddlICKnowledge').val() == '0') {
        validation = false;
        message += "<li>Please select Know about IC.</li>";
    }*/





    if (!$("#ctl00_MainContent_rbMadePaymentYes").is(':checked') && !$("#ctl00_MainContent_rbMadePaymentNo").is(':checked')) {
        validation = false;
        message += "<li>Please choose Have you made any payments?.</li>";
    }
    else if ($("#ctl00_MainContent_rbMadePaymentYes").is(':checked')) {
        if ($('#ctl00_MainContent_txtMadePaymentAmount').val() == '') {
            validation = false;
            message += "<li>How much did you paid? is empty.</li>";
        }
        if (!$("#ctl00_MainContent_rblPaymentReceiptYes").is(':checked') && !$("#ctl00_MainContent_rblPaymentReceiptNo").is(':checked')) {
            validation = false;
            message += "<li>Please choose Did you received receipt?</li>";
        }
        else if ($("#ctl00_MainContent_rblPaymentReceiptYes").is(':checked')) {
            if ($('#ctl00_MainContent_txtReceiptPaymentAmount').val() == '') {
                validation = false;
                message += "<li>How much was Payment Receipt Amount? is empty.</li>";
            }
        }

    }
    else {
        if (!$("#ctl00_MainContent_chkNothingYet").is(':checked')) {
            if ($('#ctl00_MainContent_txtAskedPaymentAmount').val() == '') {
                validation = false;
                message += "<li>How much amount being asked for? is empty.</li>";
            }
        }

    }

   
    if (!validation) {
        message += "</ul>";
        $('#modal-body-text').html(message);
        $('#validationModal').modal('show');
        return false;
    }
    
    return validation;
}


function ValidateOptionalInfo() {

    var validation = true;
    var message = '<ul>';

    if (!$("#ctl00_MainContent_rbHaveQualificationYes").is(':checked') && !$("#ctl00_MainContent_rbHaveQualificationNo").is(':checked')) {
        validation = false;
        message += "<li>Please choose Do you have any experience or training in the job you plan to go?</li>";
    }

    if (!validation) {
        message += "</ul>";
        $('#modal-body-text').html(message);
        $('#validationModal').modal('show');
        return false;
    }

    return validation;
}

function ValidatePerviousForeignExperience(){
        var validation = true;
        var message = '<ul>';

//        if ($('#ctl00_MainContent_ddlCountry').val() == '0') {
//            validation = false;
//            //message += "<li>Please select Which Country?</li>";
//        }
//        if ($('#ctl00_MainContent_ddlJobType').val() == '0') {
//            validation = false;
//           // message += "<li>Please select Job Type.</li>";
//        }
//        if ($('#ctl00_MainContent_ddlStayDuration').val() == '0') {
//            validation = false;
//            //message += "<li>Please select how much time did you stay.</li>";
//        }

        if (!validation) {
            message += "</ul>";
            $('#modal-body-text').html(message);
            $('#validationModal').modal('show');
            return false;
        }

        return validation;
}

function ValidateServices() {

    var validation = true;
    var message = '<ul>';

    if ($('#ctl00_MainContent_txtVisitTimes').val() == '') {
        validation = false;
        message += "<li>How many times has the visitor come to the center? is empty.</li>";
    }

    if ($('#ctl00_MainContent_ddlServiceProvided').val() == '0') {
        validation = false;
        message += "<li>Please select Services provided .</li>";
    }

    if (!$("#ctl00_MainContent_rdYes").is(':checked') && !$("#ctl00_MainContent_rbNo").is(':checked')) {
        validation = false;
        message += "<li>Please choose Follow-up required by IC?</li>";
    }
    else if ($("#ctl00_MainContent_rdYes").is(':checked'))
    {
        if ($('#ctl00_MainContent_ddlFollowUp').val() == '0') {
            validation = false;
            message += "<li>Please select Follow-up.</li>";
        }
    }

    if ($('#ctl00_MainContent_ddlICRecommendation').val() == '0') {
        validation = false;
        message += "<li>Please select Recommendations provided by IC .</li>";
    }

    if (!$("#ctl00_MainContent_rbAdditionalInfoYes").is(':checked') && !$("#ctl00_MainContent_rbAdditionalInfoNo").is(':checked')) {
        validation = false;
        message += "<li>Please choose During follow-up, clarification and additional information was provided?</li>";
    }
    else if ($("#ctl00_MainContent_rbAdditionalInfoYes").is(':checked')) {

    }

    if (!$("#ctl00_MainContent_rbFurtherFollowUpYes").is(':checked') && !$("#ctl00_MainContent_rbFurtherFollowUpNo").is(':checked')) {
        validation = false;
        message += "<li>Please choose Further follow up.</li>";
    }
    else if ($("#ctl00_MainContent_rbFurtherFollowUpYes").is(':checked')) {
        if ($('#ctl00_MainContent_ddlFurtherFollowUp').val() == '0') {
            validation = false;
            message += "<li>Please select Follow up duration.</li>";
        }
    }


    if (!validation) {
        message += "</ul>";
        $('#modal-body-text').html(message);
        $('#validationModal').modal('show');
        return false;
    }

    return validation;
}

function ValidateCaseRefferal() {

    var validation = true;
    var message = '<ul>';

    
    if (!$("#ctl00_MainContent_rbRefferToYes").is(':checked') && !$("#ctl00_MainContent_rbRefferToNo").is(':checked')) {
        validation = false;
        message += "<li>Please choose Referral Yes/No?</li>";
    }
    else if ($("#ctl00_MainContent_rbRefferToYes").is(':checked')) {
        if ($('#ctl00_MainContent_ddlRefferToYes').val() == '0') {
            validation = false;
            message += "<li>Please select Refferal To option.</li>";
        }
    }
    else if ($('#ctl00_MainContent_ddlRefferToNo').val() == '0') {
        message += "<li>Please select Not Refferal To reason.</li>";
        
    }

    if ($('#ctl00_MainContent_txtDateofRefferal').val() == '') {
        validation = false;
        message += "<li>Date of referral is empty.</li>";
    }

    if ($('#ctl00_MainContent_ddlRefferalStatus').val() == '0') {
        validation = false;
        message += "<li>Please select Referral organization is updating you on the status.</li>";
    }

    if (!$("#ctl00_MainContent_rblDifficultyFaceYes").is(':checked') && !$("#ctl00_MainContent_tblDifficultyFaceNo").is(':checked')) {
        validation = false;
        message += "<li>Please choose Difficulties faced with this case Yes/No?</li>";
    }
    else if ($("#ctl00_MainContent_rblDifficultyFaceYes").is(':checked')) {
        if ($('#ctl00_MainContent_txtDifficultyFaceReason').val() == '') {
            validation = false;
            message += "<li>Difficulty faced reason is empty.</li>";
        }
    }
    
    if (!validation) {
        message += "</ul>";
        $('#modal-body-text').html(message);
        $('#validationModal').modal('show');
        return false;
    }

    return validation;
}

function ValidateOtherMigrant() {

    var validation = true;
    var message = '<ul>';

    if ($('#ctl00_MainContent_ddlFamilyMember').val() == '0') {
        validation = false;
        message += "<li>Please select Family Member.</li>";
    }
    if ($('#ctl00_MainContent_ddlFamilyMemberCountry').val() == '0') {
        validation = false;
        message += "<li>Please select Country.</li>";
    }


    if (!$("#ctl00_MainContent_rbSameCountryYes").is(':checked') && !$("#ctl00_MainContent_rbSameCountryNo").is(':checked')) {
        validation = false;
        message += "<li>Where Visitor want to go (Same Country)?</li>";
    }

    if (!$("#ctl00_MainContent_rbSendMoneyYes").is(':checked') && !$("#ctl00_MainContent_rbSendMoneyNo").is(':checked')) {
        validation = false;
        message += "<li>Please choose Sending Money Yes/No?</li>";
    }
    else if ($("#ctl00_MainContent_rbSendMoneyYes").is(':checked')) {
        if ($('#ctl00_MainContent_ddlMoneyRange').val() == '0') {
            validation = false;
            message += "<li>Please select sending money range.</li>";
        }
    }

    if (!$("#ctl00_MainContent_rbDocumentLeftYes").is(':checked') && !$("#ctl00_MainContent_rbDocumentLeftNo").is(':checked')) {
        validation = false;
        message += "<li>Please choose Documents Left Yes/No?</li>";
    }
    else if ($("#ctl00_MainContent_rbDocumentLeftYes").is(':checked')) {
        
    }

    if (!$("#ctl00_MainContent_rbProblemFacedYes").is(':checked') && !$("#ctl00_MainContent_rbProblemFacedNo").is(':checked')) {
        validation = false;
        message += "<li>Please choose Does she/he face any problems, Yes/No?</li>";
    }
    else if ($("#ctl00_MainContent_rbProblemFacedYes").is(':checked')) {
        if ($('#ctl00_MainContent_ddlProblemType').val() == '0') {
            validation = false;
            message += "<li>Please select faced problem type.</li>";
        }
    }

    if (!validation) {
        message += "</ul>";
        $('#modal-body-text').html(message);
        $('#validationModal').modal('show');
        return false;
    }

    return validation;
}

function ValidateOtherFollowUp() {

    var validation = true;
    var message = '<ul>';

    if ($('#ctl00_MainContent_txtFollowUpDate').val() == '') {
        validation = false;
        message += "<li>Date is empty.</li>";
    }


    if (!$("#ctl00_MainContent_rbComplied").is(':checked') && !$("#ctl00_MainContent_rbCompliedPartly").is(':checked')) {

        if ($('#ctl00_MainContent_ddlNonFollowup').val() == '0') {
            validation = false;
            message += "<li>Please select Follow-up was not possible, because:<br/> OR choose Followup was possible : Complied/Complied Partly?.</li>";
        }
    }
    else if ($("#ctl00_MainContent_rbCompliedPartly").is(':checked')) {
        if (!$("#ctl00_MainContent_rbDidNotComply").is(':checked') && !$("#ctl00_MainContent_rbReasonForNonCompliance").is(':checked')) {
            validation = false;
            message += "<li>Please choose Did not comply OR Reason of non-compliance.</li>";
        }
        else if ($("#ctl00_MainContent_rbReasonForNonCompliance").is(':checked')) {
            if (!$("#ctl00_MainContent_rbReasonRecommendation").is(':checked') && !$("#ctl00_MainContent_rbWasTooDifficult").is(':checked') && !$("#ctl00_MainContent_rbReasonFamilyMember").is(':checked')) {
                validation = false;
                message += "<li>Please choose one of a Reason of non-compliance.</li>";
            }
            else if ($("#ctl00_MainContent_rbWasTooDifficult").is(':checked')) {
                 if (!$("#ctl00_MainContent_rbReasonReceipt").is(':checked') && !$("#ctl00_MainContent_rbOther").is(':checked')) {
                    validation = false;
                    message += "<li>Please choose one of a Was too difficult to do.</li>";
                }
            }
            
        }
    }
    

    
    if (!validation) {
        message += "</ul>";
        $('#modal-body-text').html(message);
        $('#validationModal').modal('show');
        return false;
    }

    return validation;
}

function ValidateOtherCase() {

    var validation = true;
    var message = '<ul>';

    if ($('#ctl00_MainContent_ddlTypeOfCase').val() == '0') {
        validation = false;
        message += "<li>Please select Case Type.</li>";
    }
    if ($('#ctl00_MainContent_txtCaseNumber').val() == '') {
        validation = false;
        message += "<li>Case Number is empty.</li>";
    }
    if ($('#ctl00_MainContent_txtNameOfOpponent').val() == '') {
        validation = false;
        message += "<li>Name of opponent is empty.</li>";
    }
    if ($('#ctl00_MainContent_txtCaseDesc').val() == '') {
        validation = false;
        message += "<li>Problem faced description is empty.</li>";
    }
    if ($('#ctl00_MainContent_txtCaseRegisteredDate').val() == '') {
        validation = false;
        message += "<li>Case registered date is empty.</li>";
    }
    /*
    if ($('#ctl00_MainContent_ddlCaseRegistrar').val() == '0') {
        validation = false;
        message += "<li>Please select Case registered at.</li>";
    }
    if ($('#ctl00_MainContent_txtResponsibleStaff').val() == '') {
        validation = false;
        message += "<li>Responsible staff is empty.</li>";
    }
    */
    if ($('#ctl00_MainContent_ddlCaseStatusType').val() == '0') {
        validation = false;
        message += "<li>Please select Status.</li>";
    }
    
    if (!validation) {
        message += "</ul>";
        $('#modal-body-text').html(message);
        $('#validationModal').modal('show');
        return false;
    }

    return validation;
}

function ValidateCaseFollowUp() {

    var validation = true;
    var message = '<ul>';

    if ($('#ctl00_MainContent_txtCaseFollowUpDate').val() == '') {
        validation = false;
        message += "<li>Date is empty.</li>";
    }
    if ($('#ctl00_MainContent_ddlFollowupCaseType').val() == '0') {
        validation = false;
        message += "<li>Please select Case Type.</li>";
    }
    /*if ($('#ctl00_MainContent_ddlStackeHolder').val() == '0') {
        validation = false;
        message += "<li>Please select stake holder.</li>";
    }*/
    if ($('#ctl00_MainContent_txtCaseFollowUpDesc').val() == '') {
        validation = false;
        message += "<li>Description is Empty.</li>";
    }

    if (!validation) {
        message += "</ul>";
        $('#modal-body-text').html(message);
        $('#validationModal').modal('show');
        return false;
    }

    return validation;
}


function ValidateSkill() {

    var validation = true;
    var message = '<ul>';

    if ($('#ctl00_MainContent_txtTrainingRegistrationDate').val() == '') {
        validation = false;
        message += "<li>Registration Date is empty.</li>";
    }

    if (!$("#ctl00_MainContent_chkUnEmployment").is(':checked')) {
        if ($('#ctl00_MainContent_txtSelfEmploymentIncome').val() == ''
            && $('#ctl00_MainContent_txtAgricultureIncome').val() == ''
            && $('#ctl00_MainContent_txtWageIncome').val() == ''
            && $('#ctl00_MainContent_txtOtherIncome').val() == '') {
            validation = false;
            message += "<li>Please provide at least one personal monthly income.</li>";
        }

    }

    if ($('#ctl00_MainContent_txtFamilyWageIncome').val() == ''
            && $('#ctl00_MainContent_txtFamilyAgricultureIncome').val() == ''
            && $('#ctl00_MainContent_txtFamilySalaryIncome').val() == ''
            && $('#ctl00_MainContent_txtFamilyForeignIncome').val() == ''
            && $('#ctl00_MainContent_txtFamilyBusinessIncome').val() == ''
            && $('#ctl00_MainContent_txtFamilyOtherIncome').val() == '') {
            validation = false;
            message += "<li>Please provide at lease one yearly income of family.</li>";
    }

    if ($('#ctl00_MainContent_ddlFeedDurationTypeID').val() == '0') {
        validation = false;
        message += "<li>Please select Feeding duration from your own land agriculture products.</li>";
    }

    if ($('#ctl00_MainContent_txtTrainingSubject').val() == '') {
        validation = false;
        message += "<li>Subject of training is empty.</li>";
    }

    if ($('#ctl00_MainContent_ddlTrainingDistrict').val() == '0') {
        validation = false;
        message += "<li>Please select District.</li>";
    }
    if ($('#ctl00_MainContent_ddlTrainingVDC').val() == '0') {
        validation = false;
        message += "<li>Please select VDC.</li>";
    }

    if ($('#ctl00_MainContent_txtTrainingWardNumber').val() == '') {
        validation = false;
        message += "<li>Ward number is empty.</li>";
    }

    if ($('#ctl00_MainContent_txtTrainingStartDate').val() == '') {
        validation = false;
        message += "<li>Training start date is empty.</li>";
    }
    if ($('#ctl00_MainContent_ddlTrainingReasonType').val() == '0') {
        validation = false;
        message += "<li>Please select Reason for interested in Training.</li>";
    }
    if ($('#ctl00_MainContent_ddlKnowAboutTraining').val() == '0') {
        validation = false;
        message += "<li>Please select How did get information about training?</li>";
    }

    if (!$("#ctl00_MainContent_rbHavePreviousTrainingYes").is(':checked') && !$("#ctl00_MainContent_rbHavePreviousTrainingNo").is(':checked')) {
        validation = false;
        message += "<li>Please select Have you took training before? Yes/No.</li>";
    }
    else if ($("#ctl00_MainContent_rbHavePreviousTrainingYes").is(':checked')) {
        if ($('#ctl00_MainContent_txtPreTrainingName').val() == '') {
            validation = false;
            message += "<li>Previous Training name is empty.</li>";
        }
        if ($('#ctl00_MainContent_txtPreTrainingYear').val() == '') {
            validation = false;
            message += "<li>Previous Training period is empty.</li>";
        }
        if ($('#ctl00_MainContent_txtPreTrainingInstituteName').val() == '') {
            validation = false;
            message += "<li>Previous Training Institute name is empty.</li>";
        }
        if ($('#ctl00_MainContent_txtPreTrainingPeriod').val() == '') {
            validation = false;
            message += "<li>Previous Training period is empty.</li>";
        }
    }

   

    if (!validation) {
        message += "</ul>";
        $('#modal-body-text').html(message);
        $('#validationModal').modal('show');
        return false;
    }

    return validation;
}



function ValidateEmployment() {

    var validation = true;
    var message = '<ul>';

    if ($('#ctl00_MainContent_txtEmploymentCompanyName').val() == '') {
        validation = false;
        message += "<li>Company name is empty.</li>";
    }
    if ($('#ctl00_MainContent_ddlEmploymentCountry').val() == '0') {
        validation = false;
        message += "<li>Please select Country.</li>";
    }
    if ($('#ctl00_MainContent_txtEmploymentStartDate').val() == '') {
        validation = false;
        message += "<li>Employment Start Date is empty.</li>";
    }
    if ($('#ctl00_MainContent_ddlEmploymentWorkType').val() == '0') {
        validation = false;
        message += "<li>Please select Type of work.</li>";
    }
    if ($('#ctl00_MainContent_ddlEmploymentIncomeRange').val() == '0') {
        validation = false;
        message += "<li>Please select Income range.</li>";
    }

    if (!validation) {
        message += "</ul>";
        $('#modal-body-text').html(message);
        $('#validationModal').modal('show');
        return false;
    }

    return validation;
}

function CheckService() {
    if ($('#ctl00_MainContent_hfServiceProvidedPerSaMIID').val() == '') {
        $('#modal-body-text').html('Service provided detail not added yet.');
        $('#validationModal').modal('show');
    }
    else
        $('#followupservices').modal('show');
}


function ValidateCaseReferralHistory() {
    
    var validation = true;
    var message = '<ul>';

    if ($('#ctl00_MainContent_txtReferralDate').val() == '') {
        validation = false;
        message += "<li>Referral Date is Empty.</li>";
    }

    if ($('#ctl00_MainContent_ddlReferralCaseType').val() == '0') {
        validation = false;
        message += "<li>Please select Case Type.</li>";
    }
    if ($('#ctl00_MainContent_ddlPerviousPartner').val() == '0') {
        validation = false;
        message += "<li>Please select Current Partner.</li>";
    }
    
    if ($('#ctl00_MainContent_ddlNewPartner').val() == '0') {
        validation = false;
        message += "<li>Please select New Partner.</li>";
    }

    if ($('#ctl00_MainContent_ddlPerviousPartner').val() != '0' && $('#ctl00_MainContent_ddlNewPartner').val() != '0') {
        if ($('#ctl00_MainContent_ddlPerviousPartner').val() == $('#ctl00_MainContent_ddlNewPartner').val()) {
            validation = false;
            message += "<li>Current Partner & New Partner can not be same.</li>";
        }
    }

    if (!validation) {
        message += "</ul>";
        $('#modal-body-text').html(message);
        $('#validationModal').modal('show');
        return false;
    }

    return validation;
}



    function ValidatePhoneFollowUp() {
    var validation = true;
    var message = '<ul>';

    if (!$("#ctl00_MainContent_rbtnLeftFEYes").is(':checked') && !$("#ctl00_MainContent_rbtnLeftFENo").is(':checked')) {
        validation = false;
        message += "<li>Select Left For Foreign Employment Status.</li>";
    }

    if ($("#ctl00_MainContent_rbtnLeftFEYes").is(':checked')) {
        if ($("#ctl00_MainContent_txtContractNumber").val() == '') {
            validation = false;
            message += "<li>Enter Contract Number.</li>";
        }
        if ($("#ctl00_MainContent_txtMigratedCountry").val() == '') {
            validation = false;
            message += "<li>Enter Migrated Country.</li>";
        }
        if ($("#ctl00_MainContent_txtMigratedDate").val() == '') {
            validation = false;
            message += "<li>Enter Migrated Date.</li>";
        }
        if (!$("#ctl00_MainContent_rbtnMigratedAfterTrainingYes").is(':checked') && !$("#ctl00_MainContent_rbtnMigratedAfterTrainingNo").is(':checked')) {
            validation = false;
            message += "<li>Select migration after training.</li>";
        }
        if ($("#ctl00_MainContent_rbtnMigratedAfterTrainingYes").is(':checked')) {
            if ($("#ctl00_MainContent_txtManpowerAgent").val() == '') {
                validation = false;
                message += "<li>Enter Name of Manpower or Agent.</li>";
            }
            if ($("#ctl00_MainContent_txtAmountPaidforFE").val() == '') {
                validation = false;
                message += "<li>Enter Paid Amount for Foreign Employment.</li>";
            }
            if (!$("#ctl00_MainContent_chkSourceOfInvestment_0").is(':checked') && !$("#ctl00_MainContent_chkSourceOfInvestment_1").is(':checked') && !$("#ctl00_MainContent_chkSourceOfInvestment_2").is(':checked')) {
                validation = false;
                message += "<li>Select Source of Investment.</li>";
            }

            if (!$("#ctl00_MainContent_rbtnReceiptFromManpowerYes").is(':checked') && !$("#ctl00_MainContent_rbtnReceiptFromManpowerNo").is(':checked')) {
                validation = false;
                message += "<li>Select Receipt Received From Manpower.</li>";
            }
            if (!$("#ctl00_MainContent_rbtnLeftDocumentYes").is(':checked') && !$("#ctl00_MainContent_rbtnLeftDocumentNo").is(':checked')) {
                validation = false;
                message += "<li>Select Left Document Before Departure.</li>";
            }
            if (!$("#ctl00_MainContent_rbtnWorkAggreementYes").is(':checked') && !$("#ctl00_MainContent_rbtnWorkAggreementNo").is(':checked')) {
                validation = false;
                message += "<li>Work As Per Agreement?</li>";
            }
            if (!$("#ctl00_MainContent_rbtnSalaryAgreementYes").is(':checked') && !$("#ctl00_MainContent_rbtnSalaryAgreementNo").is(':checked')) {
                validation = false;
                message += "<li>Salary As Per Agreement?</li>";
            }
        }
    }

    if ($("#ctl00_MainContent_rbtnLeftFENo").is(':checked')) {
        if ($("#ctl00_MainContent_ddlCurrentStatus option:selected").val() == 'Select') {
            validation = false;
            message += "<li>Select current status of visitor.</li>";
        }
        else if ($("#ctl00_MainContent_ddlCurrentStatus option:selected").val() == 'Other') {
            if ($("#ctl00_MainContent_txtCurrentStatus").val() == '') {
                validation = false;
                message += "<li>Enter current status of visitor.</li>";
            }
        }
    }
    if (!validation) {
        message += "</ul>";
        $('#modal-body-text').html(message);
        $('#validationModal').modal('show');
        return false;
    }

    return validation;
}

function ValidatePhoneFollowUpInfo() {
    var validation = true;
    var message = '<ul>';

    if ($("#ctl00_MainContent_txtNameOfInformants").val() == '') {
        validation = false;
        message += "<li>Enter Name of Informants.</li>";
    }
    if ($("#ctl00_MainContent_txtRelationMigrant").val() == '') {
        validation = false;
        message += "<li>Enter Relation with Migrant.</li>";
    }
    if ($("#ctl00_MainContent_txtDateOfFollowUp").val() == '') {
        validation = false;
        message += "<li>Enter Date of Follow Up.</li>";
    }
       
    if (!validation) {
        message += "</ul>";
        $('#modal-body-text').html(message);
        $('#validationModal').modal('show');
        return false;
    }

    return validation;
}