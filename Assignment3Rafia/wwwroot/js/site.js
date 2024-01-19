$(document).ready(function () {
    // Setting up our jQuery UI datepicker for all datetime input fields:
    $('input[type="datetime"]').datepicker({
        dateFormat: 'm/d/yy',
        changeMonth: true,
        changeYear: true,
        yearRange: '-60:+100'
    });
});