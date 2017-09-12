$(document).ready(function () {
    $('#save').click(function () {
        var data = new FormData();
        var file = $('form input[type=file]')[0].files[0];
        data.append('file', file);
        $.ajax({
            //Obtener la url de una cookie
            url: 'http://localhost:7555/QuinielaAPI/API/Resources',
            processData: false,
            contentType: false,
            data: data,
            type: 'POST'
        }).done(function (result) {
            NextStep(result);
        }).fail(function (a, b, c) {
            console.log(a, b, c);
        });
    });
});

//function Upload () {
//        var data = new FormData();
//        var file = $('form input[type=file]')[0].files[0];
//        data.append('file', file);
//        $.ajax({
//            url: 'http://localhost:7555/QuinielaAPI/API/Resources',
//            processData: false,
//            contentType: false,
//            data: data,
//            type: 'POST'
//        }).done(function (result) {
//            NextStep(result);
//        }).fail(function (a, b, c) {
//            console.log(a, b, c);
//        });
//    }
function NextStep(data) {
    document.getElementById("shieldUrl").value = data.Path + '/' + data.Name;
    $.ajax({
        url: '/PoolAdministration/TeamCreateNew',
        data: {
            ShortName: document.getElementById("ShortName").value,
            Name: document.getElementById("Name").value,
            Abbreviation: document.getElementById("Abbreviation").value,
            Shield: document.getElementById("shieldUrl").value,
            Stadium: document.getElementById("Stadium").value,
            City: document.getElementById("City").value,
            State: document.getElementById("State").value,
            Country: document.getElementById("Country").value
        },
        type: 'POST'
    }).done(function (result) {
        //console.log(result);
        OnCompleteTeam(result);
    }).fail(function (result) {
        OnError(result);
    });
}
function OnCompleteTeam(data) {
    var res = data.data;
    var _message = "";
    var _type = "";
    var _title = "";
    if (res.MessageType == 1) {
        _type = BootstrapDialog.TYPE_SUCCESS;
        _title = 'Éxito';
        _message = res.Message;
    }
    if (res.MessageType == 2) {
        _type = BootstrapDialog.TYPE_WARNING;
        _title = 'Atención';
        _message = res.Message;
    }
    if (res.MessageType == 3) {
        _type = BootstrapDialog.TYPE_DANGER;
        _title = 'Error';
        _message = res.Message;
    }
    var dialog = new BootstrapDialog({
        message: _message,
        type: _type,
        title: _title,
        buttons: [{
            id: 'btn-res',
            label: 'Aceptar'
        }]
    });
    dialog.realize();
    var btnres = dialog.getButton('btn-res');
    btnres.click(function (event) {
        OnSuccessTeam();
    });
    dialog.open();
}
function OnSuccessTeam() {
    window.location.reload();
}

$('#Save').click(function () {
    $.ajax({
        url: '/PoolAdministration/GameCreate',
        data: {
            LocalId: document.getElementById("LocalId").value,
            VisitorId: document.getElementById("VisitorId").value,
            Date: document.getElementById("Date").value,
            weekId: document.getElementById("WeekId").value
        },
        type: 'POST'
    }).done(function (result) {
        OnCompleteTeam(result);
    }).fail(function (result) {
        onError(result);
    });
});