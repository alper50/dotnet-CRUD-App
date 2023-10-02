$(document).ready(function(){
    var grupId= $("#hiddenValue").val();
    $("#leftTitle").text('Sahip Olunan Yetkiler');
    $("#rightTitle").text('Tüm Yetkiler');
    getGrupWithYetkiler(grupId);
})

function getGrupWithYetkiler(grupId){
    $.ajax({
        url: "/GrupYetki/GetGrupWithYetkiler?grupId="+grupId,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=UTF-8",
        success: function (response) {
            $('#leftList').empty();
            $('#rightList').empty();
            $.each(response, function(index, item){
                var listItem = '<li><a href="#" onclick="changeGrupYetki('+item.grupId+','+item.grubaAitmi+','+item.yetkiId+')">'+item.yetkiIsim+'</a></li>';
                
                if (item.grubaAitmi) {
                    $('#leftList').append(listItem);
                } else {
                    $('#rightList').append(listItem);
                }
            });
        },
        error: function (response) {
            var object = '<p>'+response.responseText+'</p>';
            object+= '<button class="btn btn-danger" onclick="getGrupWithYetkiler('+grupId+')">Tekrar Dene</button>';
            $('#errorDiv').html(object);
        }
    });
}

function changeGrupYetki(grupId, grubaAitmi,yetkiId){
    $.ajax({
        url: "/GrupYetki/ChangeGrupYetki?grupId="+grupId+"&grubaAitmi="+grubaAitmi+"&yetkiId="+yetkiId,
        type: "POST",
        success: function (response) {
            getGrupWithYetkiler(grupId);
        },
        error: function (response) {
            alert('hata'+response.responseText);
        }
    });
}