$(document).ready(function(){
    var yetkiId = $("#hiddenValue").val();
    $("#leftTitle").text('Yetkinin Bağlı Olduğu Gruplar');
    $("#rightTitle").text('Tüm Gruplar');
    getYetkiWithGruplar(yetkiId);
})

function getYetkiWithGruplar(yetkiId){
    $.ajax({
        url: "/YetkiGrup/GetYetkiWithGruplar?yetkiId="+yetkiId,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=UTF-8",
        success: function (response) {
            $('#leftList').empty();
            $('#rightList').empty();
            $.each(response, function(index, item){
                var listItem = '<li><a href="#" onclick="ChangeYetkiGrup('+item.grupId+','+item.yetkiyeAitmi+','+item.yetkiId+')">'+item.grupIsim+'</a></li>';
                
                if (item.yetkiyeAitmi) {
                    $('#leftList').append(listItem);
                } else {
                    $('#rightList').append(listItem);
                }
            });
        },
        error: function (response) {
            var object = '<p>'+response.responseText+'</p>';
            object+= '<button class="btn btn-danger" onclick="getYetkiWithGruplar('+yetkiId+')">Tekrar Dene</button>';
            $('#errorDiv').html(object);
        }
    });
}

function ChangeYetkiGrup(grupId,yetkiyeAitmi,yetkiId){
    $.ajax({
        url: "/YetkiGrup/ChangeYetkiGrup?grupId="+grupId+"&yetkiyeAitmi="+yetkiyeAitmi+"&yetkiId="+yetkiId,
        type: "POST",
        success: function (response) {
            getYetkiWithGruplar(yetkiId);
        },
        error: function (response) {
            alert('hata'+response.responseText);
        }
    });
}