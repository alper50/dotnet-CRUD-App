$(document).ready(function(){
    var kullaniciId= $("#hiddenValue").val();
    $("#leftTitle").text('Bağlı Olan Gruplar');
    $("#rightTitle").text('Tüm Gruplar');
    getKullaniciWithGruplar(kullaniciId);
})

function getKullaniciWithGruplar(kullaniciId){
    $.ajax({
        url: "/KullaniciGrup/GetKullaniciWithGruplar?kullaniciId="+kullaniciId,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=UTF-8",
        success: function (response) {
            $('#leftList').empty();
            $('#rightList').empty();
            $.each(response, function(index, item){
                var listItem = '<li><a href="#" onclick="changeKullaniciGrup('+item.grupId+','+item.kullaniciyaAitmi+','+item.kullaniciId+')">'+item.grupIsim+'</a></li>';
                
                if (item.kullaniciyaAitmi) {
                    $('#leftList').append(listItem);
                } else {
                    $('#rightList').append(listItem);
                }
            });
        },
        error: function (response) {
            var object = '<p>'+response.responseText+'</p>';
            object+= '<button class="btn btn-danger" onclick="getKullaniciWithGruplar('+kullaniciId+')">Tekrar Dene</button>';
            $('#errorDiv').html(object);
        }
    });
}

function changeKullaniciGrup(grupId, kullaniciyaAitmi,kullaniciId){
    $.ajax({
        url: "/KullaniciGrup/ChangeKullaniciGrup?grupId="+grupId+"&kullaniciyaAitmi="+kullaniciyaAitmi+"&kullaniciId="+kullaniciId,
        type: "POST",
        success: function (response) {
            getKullaniciWithGruplar(kullaniciId);
        },
        error: function (response) {
            alert('hata'+response.responseText);
        }
    });
}