function ShowReport(selected) {

    if (selected == '')
        document.location.href = "Index.aspx";
    else if (selected == 'cases')
        document.location.href = "CaseReports.aspx";
    else if (selected == 'trainings')
        document.location.href = "TrainingReports.aspx";
    else if (selected == 'employments')
        document.location.href = "EmploymentReports.aspx";

}

function GetSelected(select) {
    $("#type_of_report").val(select);
}

function ValidateDateInput() {
    
    var validation = true;
    var message = '<ul>';
        
    if ($('#ctl00_MainContent_txtFromDate').val() == '' && $('#ctl00_MainContent_txtToDate').val() == '') {
        validation = false;
        message += "<li>Please provide at least From: Date.</li>";

    }
    else if ($('#ctl00_MainContent_txtFromDate').val() == '' && $('#ctl00_MainContent_txtToDate').val() != '') {
        validation = false;
        message += "<li>Please provide From: Date.</li>";

    }
    else if (!checkDateDifference($('#ctl00_MainContent_txtFromDate').val(), $('#ctl00_MainContent_txtToDate').val())) {
        validation = false;
        message += "<li>FROM DATE must be Less than OR Eqaul to TO DATE.</li>";
    }

    if (!validation) {
        message += "</ul>";
        $('#modal-body-text').html(message);
        $('#validationModal').modal('show');
        return false;
    }
    
    return validation;

}

function checkDateDifference(startDate, endDate) {
    startDate = $.datepicker.parseDate('mm/dd/yy', startDate);
    endDate = $.datepicker.parseDate('mm/dd/yy', endDate);

    var difference = (endDate - startDate) / (86400000);

    if (difference < 0) {

        return false;
    }
    return true;

}
