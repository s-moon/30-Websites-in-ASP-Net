$(document).ready(function () {
    $('.maze > img').mouseover(function () {
        var objimg = event.target;
        $(objimg).css('opacity', '1.0');
    })
    $('.maze > img').mouseleave(function () {
        var objimg = event.target;
        $(objimg).css('opacity', '0.0');
    })
}); 