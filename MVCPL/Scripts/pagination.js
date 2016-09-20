function OnSuccess(data) {
    var href = $("#nonActive").attr('href');
    window.history.pushState({}, "", href);
}