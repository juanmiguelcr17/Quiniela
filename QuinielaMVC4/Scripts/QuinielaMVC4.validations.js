function OnSuccess(data) {
    var json = $.parseJSON(data.responseText);
    var res = json.data;
    if (res.MessageType == 1)
    {
        BootstrapDialog.show({
            type: BootstrapDialog.TYPE_SUCCESS,
            title: 'Éxito',
            message: res.Message
        });
    }
    if (res.MessageType == 2)
    {
        BootstrapDialog.show({
            type: BootstrapDialog.TYPE_WARNING,
            title: 'Atención',
            message: res.Message
        });
    }
    if (res.MessageType == 3) {
        BootstrapDialog.show({
            type: BootstrapDialog.TYPE_DANGER,
            title: 'Error',
            message: res.Message
        });
    }
    return false;
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