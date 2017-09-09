$("#SaveWeek").click(function () {
	$.ajax({
		url: '/PoolAdministration/WeekCreate',
		data: {
			Number: document.getElementById("Number").value,
			Name: document.getElementById("Name").value,
			SeasonId: document.getElementById("SeasonId").value
		},
		type: 'POST'
	}).done(function (result) {
		//console.log(result);
		OnComplete(result);
	}).fail(function (result) {
		OnError(result);
	});
});

$("#updWeek").click(function () {
    $.ajax({
        url: '/PoolAdministration/WeekEdit',
        data: {
            Number: document.getElementById("Number").value,
            Name: document.getElementById("Name").value,
            SeasonId: document.getElementById("SeasonId").value,
            WeekId: document.getElementById("WeekId").value
        },
        type: 'POST'
    }).done(function (result) {
        //console.log(result);
        OnCompleteRedirect(result);
    }).fail(function (result) {
        OnError(result);
    });
});