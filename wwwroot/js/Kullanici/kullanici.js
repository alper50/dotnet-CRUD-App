$(document).ready(function(){
    $(".form-label").text('Kullanıcı İsmi');
    $("#modalLabel").text('Kullanıcı İsmini Düzenle');
    $("#saveButton").click(updateKullanici)
    getKullanicilar();
})

$('#Isim').change(function () {
    validateForm();
});

function getKullanicilar(){
    $.ajax({
        url: "/Kullanici/GetKullanicilar",
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=UTF-8",
        success: function (response) {
            var object = '';
            $('#tbody').empty();
            $.each(response, function(index, item){
                object+='<tr>';
                object+='<td width="40%">'+item.kullaniciIsim+'</td>';
                object+='<td width="40%"><a href="/KullaniciGrup?kullaniciId='+item.id+'">Kullanıcının bağlı olduğu gruplar</a></td>';
                object+='<td width="20%" class="text-center"><a href="#" class="btn btn-primary" onclick="getKullanici('+item.id+')">Düzenle</a></td>';
                object+='</tr>';
                $('#tbody').html(object);
    
            });
        },
        error: function (response) {
            var object = '';
            object+='<tr>';
            object+='<td width="80%">'+response.responseText+'</td>';
            object+='<td width="10%"></td>';
            object+='<td width="10%" class="text-center"><a href="#" class="btn btn-primary" onclick="getKullanicilar()">Tekrar Dene</a></td>';
            object+='</tr>';
            $('#tbody').html(object);
        }
    });
}

function getKullanici(kullaniciId){

    $.ajax({
        url: "/Kullanici/GetKullanici?kullaniciId="+kullaniciId,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=UTF-8",
        success: function (response) {
            $('#myModal').modal('show');
            $('#Isim').val(response.kullaniciIsim);
            $('#Id').val(response.id);
        },
        error: function (response) {
            $('#Isim').css("border-color","Red");
            $('#Isim').val(response.responseText);
        }
    });
  
}

function updateKullanici(){
   
    var result = validateForm();
    if(result==false){
        return false;
    }
    var formData = new Object();
    formData.id= $('#Id').val();
    formData.kullaniciIsim= $('#Isim').val();

    $.ajax({
        url: "/Kullanici/UpdateKullanici",
        data:formData,
        type: "POST",
        success: function (response) {
           hideForm();
           getKullanicilar();
        },
        error: function (response) {
            $('#Isim').css("border-color","Red");
            $('#Isim').val(response.responseText);
        }
    });
}