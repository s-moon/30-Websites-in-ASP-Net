$(document).ready(function () {
    var colors = ["#00FFFF", "#CCFFFF", "#CCFF66", "#99FF00", "#FFFF00", "#FFFF99", "#00FF00", "#FF6666"];
    var rand = Math.floor(Math.random() * colors.length);
    $('body').css("background-color", colors[rand]);
});