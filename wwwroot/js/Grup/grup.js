$(document).ready(function(){
    getGruplar();
    $(".form-label").text('Grup İsmi');
    $("#modalLabel").text('Grup İsmini Düzenle');
    $("#saveButton").click(updateGrup)
})

$('#Isim').change(function () {
    validateForm();
});

function getGruplar(){
    $.ajax({
        url: "/Grup/GetGruplar",
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=UTF-8",
        success: function (response) {
            var object = '';
            $('#tbody').empty();
            $.each(response, function(index, item){
                object+='<tr>';
                object+='<td width="30%">'+item.grupIsim+'</td>';
                object+='<td width="30%"><a href="/GrupYetki?grupId='+item.id+'">Grubun Yetkilerini Göster</a></td>';
                object+='<td width="30%"><a href="/GrupKullanici?grupId='+item.id+'">Bağlı Kullanıcıları Göster</a></td>';
                object+='<td width="10%" class="text-center"><a href="#" class="btn btn-primary" onclick="getGrup('+item.id+')">Düzenle</a></td>';
                object+='</tr>';
                $('#tbody').html(object);
    
            });
        },
        error: function (response) {
            var object = '';
            object+='<tr>';
            object+='<td width="80%">'+response.responseText+'</td>';
            object+='<td width="10%"></td>';
            object+='<td width="10%" class="text-center"><a href="#" class="btn btn-primary" onclick="getGruplar()">Tekrar Dene</a></td>';
            object+='</tr>';
            $('#tbody').html(object);
        }
    });
}

function getGrup(grupId){

    $.ajax({
        url: "/Grup/GetGrup?grupId="+grupId,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=UTF-8",
        success: function (response) {
            $('#myModal').modal('show');
            $('#Isim').val(response.grupIsim);
            $('#Id').val(response.id);
        },
        error: function (response) {
            $('#Isim').css("border-color","Red");
            $('#Isim').val(response.responseText);
        }
    });
  
}


function updateGrup(){
   
    var result = validateForm();
    if(result==false){
        return false;
    }
    var formData = new Object();
    formData.id= $('#Id').val();
    formData.grupIsim= $('#Isim').val();

    $.ajax({
        url: "/Grup/UpdateGrup",
        data:formData,
        type: "POST",
        success: function (response) {
           hideForm();
           getGruplar();
        },
        error: function (response) {
            $('#Isim').css("border-color","Red");
            $('#Isim').val(response.responseText);
        }
    });
}