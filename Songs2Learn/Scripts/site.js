//$(document).ready(function () {
//    $("#firstGenerateBtn").click(function () {
//        $("#LandingButtonRow").fadeOut("slow", function () {
//            $("#TrackRow").removeClass("hidden");
//        });
//    });
//});


function songPlay() {
    var audio = document.getElementById("tracksample");
    if ($("#album").hasClass("rotate") && $("#album").hasClass("vinyl")) {
        $("#album").removeClass("rotate");
        $("#album").removeClass("vinyl");
        audio.pause();
        audio.currentTime = 0;
    }
    else {
        $("#album").addClass("vinyl");
        $("#album").addClass("rotate");
        audio.play();
        audio.addEventListener("ended", function () {
            $("#album").removeClass("rotate");
            $("#album").removeClass("vinyl");
        });
    }
}
