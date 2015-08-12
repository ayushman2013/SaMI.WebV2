function ReturnConfirmation(message) {
    if (confirm(message)) {
        /*$('.delete_link').colorbox({
            onClosed: function () { window.location.reload(true); }
        });*/
        return true;
    }
    else {
        return false;
    }
}