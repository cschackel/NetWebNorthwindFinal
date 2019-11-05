$(function () {

    var toastSound = new Audio('/media/toast-sound.mp3');

    $(".code").on("click", function (e) {
        e.preventDefault();
        //alert($(this).data("product"));

        toastSound.pause();
        toastSound.currentTime = 0;
        toastSound.play();

        $("#product").html($(this).data("product"));
        $("#code").html($(this).data("code"));
        $('#toast').toast({ autohide: false }).toast('show');
    });
});