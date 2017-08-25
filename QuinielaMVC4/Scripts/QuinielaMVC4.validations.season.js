$(function () {
    $('.RemoveLink').click(function () {
        var teamToDelete = $(this).attr("data-idTeam");
        var seasonToDeleteFrom = $(this).attr("data-idSeason");
        if (teamToDelete != '') {
            if (seasonToDeleteFrom != '') {
                $.post("/PoolAdministration/SeasonDeleteTeam", {
                    "teamId": teamToDelete,
                    "seasonId": seasonToDeleteFrom
                }, function (data) {
                    //OnSuccess(JSON.parse(data));
                    var json = $.parseJSON(data);
                    var res = json.data;
                        BootstrapDialog.show({
                            type: BootstrapDialog.TYPE_SUCCESS,
                            title: 'Éxito',
                            message: res.Message
                        });
                });
            }
        }
    });
});