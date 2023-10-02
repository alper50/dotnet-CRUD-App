window.hideForm = function(){
    $('#myModal').modal('hide');
}

window.validateForm=function(){
    var isValid = true;
    if($('#Isim').val().trim()==""){
        $('#Isim').css("border-color","Red");
        isValid = false;
        return isValid;
    }
    else{
        $('#Isim').css("border-color","lightgrey");
        return isValid;
    }
}
