$("input#ctl00_MainContent_rbFemale").click(function () {
    $("#ctl00_MainContent_rbDiscriminated").attr("checked", "checked");
});

function ValidateGeneranlInfo() {
    var validation = true;
    var message = '<ul>';
    //alert('flow');
    if ($('#ctl00_MainContent_txtRegistrationDate').val() == '') {
        validation = false;
        message += "<li>Registraton Date is empty.</li>";
    }

    if ($('#ctl00_MainContent_ddlDistrict').val() == '0') {
        validation = false;
        message += "<li>Please select District.</li>";
    }
    
    if (!$("#ctl00_MainContent_rbMale").is(':checked') && !$("#ctl00_MainContent_rbFemale").is(':checked')){
        validation = false;
        message += "<li>Please choose Gender.</li>";
    }

   
    if ($('#ctl00_MainContent_txtFirstName').val() == '') {
        validation = false;
        message += "<li>First Name is empty.</li>";
    }

    if ($('#ctl00_MainContent_txtLastName').val() == '') {
        validation = false;
        message += "<li>Last Name is empty.</li>";
    }

    if ($('#ctl00_MainContent_ddlAgeGroup').val() == '0') {
        validation = false;
        message += "<li>Please select Age Group.</li>";
    }

    if ($('#ctl00_MainContent_ddlEthnicity').val() == null || $('#ctl00_MainContent_ddlEthnicity').val() == '0') {
        validation = false;
        message += "<li>Please select Ethnicity</li>";
    }

    if ($('#ctl00_MainContent_ddlAddressDistrict').val() == '0') {
        validation = false;
        message += "<li>Please select Address District.</li>";
    }   

    if ($('#ctl00_MainContent_ddlVDC').val() == '0') {
        validation = false;
        message += "<li>Please select VDC.</li>";
    }    

    if ($('#ctl00_MainContent_txtWard').val() == '') {
        validation = false;
        message += "<li>Ward is empty.</li>";
    }
  
    if ($('#ctl00_MainContent_ddlEducationalStatus').val() == '0') {
        validation = false;
        message += "<li>Please select Educational Status.</li>";
    }

    if ($('#ctl00_MainContent_ddlMaritalStatus').val() == '0') {
        validation = false;
        message += "<li>Please select Marital Status.</li>";
    }

    if ($('#ctl00_MainContent_ddlICKnowledge').val() == '0') {
        validation = false;
        message += "<li>Please select How do you Know about IC.</li>";
    }

    if ($('#ctl00_MainContent_ddlFrequencyOfVisit').val() == '0') {
        validation = false;
        message += "<li>Please select how many times did you go.</li>";
    }
    if ($('#ctl00_MainContent_ddlReasonOfVisit').val() == '0') {
        validation = false;
        message += "<li>Please select Visit Reason.</li>";
    }


    /*Validate Previous Employment Experience*/

//    if (!$("#ctl00_MainContent_rbPrevFEExperienceYes").is(':checked') && !$("#ctl00_MainContent_rbPrevFEExperienceNo").is(':checked')) {
//        validation = false;
//        message += "<li>Do you have previous foreign experience?</li>";
//    }

//    if ($("#ctl00_MainContent_rbPrevFEExperienceYes").is(':checked')) {
//        if ($('#ctl00_MainContent_ddlCountry').val() == '0') {
//            validation = false;
//            message += "<li>Please select country.</li>";
//        }

//        if ($('#ctl00_MainContent_ddlJobType').val() == '0') {
//            validation = false;
//            message += "<li>Please select job type.</li>";
//        }

//        if ($('#ctl00_MainContent_ddlStayDuration').val() == '0') {
//            validation = false;
//            message += "<li>Please select stay duration.</li>";
//        }
//        
//    }

//    if ($('#ctl00_MainContent_ddlCountry').val() == '0') {
//        validation = false;
//        message += "<li>Please select Which Country?</li>";
//    }
//    if ($('#ctl00_MainContent_ddlJobType').val() == '0') {
//        validation = false;
//        message += "<li>Please select Job Type.</li>";
//    }
//    if ($('#ctl00_MainContent_ddlStayDuration').val() == '0') {
//        validation = false;
//        message += "<li>Please select how much time did you stay.</li>";
//    }
   
    if (!validation) {
        message += "</ul>";
        $('#modal-body-text').html(message);
        $('#validationModal').modal('show');
        return false;
    }
   
//   return true;
    return validation;
   // alert('test')
}

function AddPreviousFEExperience() {
    if (ValidatePreviousFEExperience()) {
        $('#PreviousFEExperience').modal('hide')
        return true;
    }
    else return false;
}

function ValidatePreviousFEExperience() {
    var validation = true;
    var message = '<ul>';

    if ($('#ctl00_MainContent_ddlCountry').val() == '0') {
        validation = false;
        message += "<li>Please select country.</li>";
    }

    if ($('#ctl00_MainContent_ddlJobType').val() == '0') {
        validation = false;
        message += "<li>Please select job type.</li>";
    }

    if ($('#ctl00_MainContent_ddlStayDuration').val() == '0') {
        validation = false;
        message += "<li>Please select stay duration.</li>";
    }

    if (!validation) {
        message += "</ul>";
        $('#modal-body-text').html(message);
        $('#validationModal').modal('show');
        return false;
    }

    return validation;
}
