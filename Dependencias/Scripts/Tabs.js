$("#tab-1").click(function () {
    $("#content-1").removeClass("none");
    $("#content-2").addClass("none");
    $("#content-3").addClass("none");
});

$("#tab-2").click(function () {
    $("#tab-1").removeClass("none");
    $("#content-2").removeClass("none");
    $("#content-1").addClass("none");
    $("#content-3").addClass("none");
});

$("#tab-3").click(function () {
    $("#content-3").removeClass("none");
    $("#content-2").addClass("none");
    $("#content-1").addClass("none");
});
