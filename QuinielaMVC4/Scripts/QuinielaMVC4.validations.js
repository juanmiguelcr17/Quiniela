function OnComplete(data) {
    var json = $.parseJSON(data.responseText);
    var res = json.data;
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
        OnSuccess();
    });
    dialog.open();
}

function OnError(data) {
    var json = $.parseJSON(data.responseText);
    var res = json.data;
    BootstrapDialog.show({
        type: BootstrapDialog.TYPE_DANGER,
        title: 'Error',
        message: res.Message
    });
    return false;
}

function OnSuccess() {
    location.reload();
}
//    if (res.MessageType == 1)
//    {
//        BootstrapDialog.show({
//            type: BootstrapDialog.TYPE_SUCCESS,
//            title: 'Éxito',
//            message: res.Message
//        });
//    }
//    if (res.MessageType == 2)
//    {
//        BootstrapDialog.show({
//            type: BootstrapDialog.TYPE_WARNING,
//            title: 'Atención',
//            message: res.Message
//        });
//    }
//    if (res.MessageType == 3) {
//        BootstrapDialog.show({
//            type: BootstrapDialog.TYPE_DANGER,
//            title: 'Error',
//            message: res.Message
//        });
//    }
//    return false;
//}
