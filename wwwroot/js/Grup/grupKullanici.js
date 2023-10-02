$(document).ready(function(){
    var grupId= $("#hiddenValue").val();
    $("#leftTitle").text('Bağlı Olan Kullanıcılar');
    $("#rightTitle").text('Tüm Kullanıcılar');
    getGrupWithKullanicilar(grupId);
})

function getGrupWithKullanicilar(grupId){
    $.ajax({
        url: "/GrupKullanici/GetGrupWithKullanicilar?grupId="+grupId,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=UTF-8",
        success: function (response) {
            $('#leftList').empty();
            $('#rightList').empty();
            $.each(response, function(index, item){
                var listItem = '<li><a href="#" onclick="changeGrupKullanici('+item.grupId+','+item.grubaAitmi+','+item.kullaniciId+')">'+item.kullaniciIsim+'</a></li>';
                
                if (item.grubaAitmi) {
                    $('#leftList').append(listItem);
                } else {
                    $('#rightList').append(listItem);
                }
            });
        },
        error: function (response) {
            var object = '<p>'+response.responseText+'</p>';
            object+= '<button class="btn btn-danger" onclick="getGrupWithKullanicilar('+grupId+')">Tekrar Dene</button>';
            $('#errorDiv').html(object);
        }
    });
}

function changeGrupKullanici(grupId, grubaAitmi,kullaniciId){
    $.ajax({
        url: "/GrupKullanici/ChangeGrupKullanici?grupId="+grupId+"&grubaAitmi="+grubaAitmi+"&kullaniciId="+kullaniciId,
        type: "POST",
        success: function (response) {
            getGrupWithKullanicilar(grupId);
        },
        error: function (response) {
            alert('hata'+response.responseText);
        }
    });
}