$(document).ready(function(){
    $(".form-label").text('Yetki İsmi');
    $("#modalLabel").text('Yetki İsmini Düzenle');
    $("#saveButton").click(updateYetki);
    getYetkiler();
})

$('#Isim').change(function () {
    validateForm();
});


function getYetkiler(){
    $.ajax({
        url: "/Yetki/GetYetkiler",
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=UTF-8",
        success: function (response) {
            var object = '';
            $('#tbody').empty();
            $.each(response, function(index, item){
                object+='<tr>';
                object+='<td width="40%">'+item.yetkiIsim+'</td>';
                object+='<td width="40%"><a href="/YetkiGrup?yetkiId='+item.Id+'">Yetkinin bağlı olduğu gruplar</a></td>';
                object+='<td width="20%" class="text-center"><a href="#" class="btn btn-primary" onclick="getYetki('+item.id+')">Düzenle</a></td>';
                object+='</tr>';
                $('#tbody').html(object);
    
            });
        },
        error: function (response) {
            var object = '';
            object+='<tr>';
            object+='<td width="80%">'+response.responseText+'</td>';
            object+='<td width="10%"></td>';
            object+='<td width="10%" class="text-center"><a href="#" class="btn btn-primary" onclick="getYetkiler()">Tekrar Dene</a></td>';
            object+='</tr>';
            $('#tbody').html(object);
        }
    });
}

function getYetki(yetkiId){

    $.ajax({
        url: "/Yetki/GetYetki?yetkiId="+yetkiId,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=UTF-8",
        success: function (response) {
            $('#myModal').modal('show');
            $('#Isim').val(response.yetkiIsim);
            $('#Id').val(response.id);
        },
        error: function (response) {
            $('#Isim').css("border-color","Red");
            $('#Isim').val(response.responseText);
        }
    });
  
}

function updateYetki(){
   
    var result = validateForm();
    if(result==false){
        return false;
    }
    var formData = new Object();
    formData.id= $('#Id').val();
    formData.yetkiIsim= $('#Isim').val();

    $.ajax({
        url: "/Yetki/UpdateYetki",
        data:formData,
        type: "POST",
        success: function (response) {
           hideForm();
           getYetkiler();
        },
        error: function (response) {
            $('#Isim').css("border-color","Red");
            $('#Isim').val(response.responseText);
        }
    });
}
