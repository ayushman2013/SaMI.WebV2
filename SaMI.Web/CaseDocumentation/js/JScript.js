

function ValidateCaseProfile() {
    var validation = true;
    var message = '<ul>';

    if ($('#ctl00_MainContent_txtFirstName').val() == '') {
        validation = false;
        message += "<li>First Name is empty.</li>";
    }

    if ($('#ctl00_MainContent_txtLastName').val() == '') {
        validation = false;
        message += "<li>Last Name is empty.</li>";
    }

    if ($('#ctl00_MainContent_ddlDistrict').val() == '0') {
        validation = false;
        message += "<li>Please select District.</li>";
    }

    if ($('#ctl00_MainContent_ddlVDC').val() == '0') {
        validation = false;
        message += "<li>Please select VDC.</li>";
    }

    if (!validation) {
        message += "</ul>";
        $('#modal-body-text').html(message);
        $('#validationModal').modal('show');
        return false;
    }
    return true;

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

    if ($('#ctl00_MainContent_ddlCaseStatusType').val() == '0') {
        validation = false;
        message += "<li>Please select Status.</li>";
    }

    if ($('#ctl00_MainContent_rbCompensationYes').is(':checked')) {
        if ($('#ctl00_MainContent_txtCompensationAmount').val() == '') {
            validation = false;
            message += "<li>Compensation Amount is empty.</li>";
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


    function AddCaseFollowUp() {
        if (ValidateCaseFollowUp()) {
            $('#casefollowup').modal('hide')
            return true;
        }
        else
            return false;

    }

    function AddOtherCase() {
        if (ValidateOtherCase()) {
            $('#casedocumentationothercases').modal('hide')
            return true;
        }
        else
            return false;
    }

    function AddCaseReferralHistory() {

        if (ValidateCaseReferralHistory()) {
            $('#casereferrals').modal('hide')
            return true;
        }
        else return false;
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

