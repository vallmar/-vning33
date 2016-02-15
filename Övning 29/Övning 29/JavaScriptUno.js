$(document).ready(function () {
    
    var index = $('#ContentPlaceHolderMain_listBoxContacts').val();

    if (index==null) 
    $('#viewContact').hide();
    else
        $('#viewContact').show();

    (function displayContact(){
        $('#txtBoxFirstnameUserControl').val = $('#ContentPlaceHolderMain_listBoxContacts').val();
    })

})

