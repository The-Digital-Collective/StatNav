// ensure all ajax requests are set with a unique id to prevent browser caching
$.ajaxSetup({ cache: false });

pathArray = location.href.split('/');
protocol = pathArray[0];
host = pathArray[2];

if (host.indexOf('localhost') >= 0) {
    url = protocol + '//' + host + '/';
} else {
    url = protocol + '//' + host + '/PALHub/';
}

$(document).ajaxError(function (event, jqXHR, settings, exception) {
    if (jqXHR.status == 401) {  //Unathorised
        window.location.replace(url + "Account/Login?timeout");
    }
});