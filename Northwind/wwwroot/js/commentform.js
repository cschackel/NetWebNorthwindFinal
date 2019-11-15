$(function () {

    //Controlls Hover Over Star Fill-in Look
    $(".rating-star").hover(function () {  //Hover On
        let starValue = $(this).data("value");  //Hovered On Star Number 1-5
        $(".rating-star").each(function (i) {
            if ($(this).data("value") <= starValue) {  //If Star Value is below or is hovered over star
                $(this).addClass("fas");  //Add solid class
                $(this).removeClass("far"); //Remove Outline
            } else {

            }
        });
    }, function () {  //Hover Off
            updateStarIcons();  //Set Stars to current value
    });

    //Updates the stars to reflect current state
    function updateStarIcons() {
        let actualValue = $("#rating-value").val();  // Get actual star value
        $(".rating-star").each(function (i) {
            if ($(this).data("value") > actualValue) {  //If StarValue is above rating
                $(this).addClass("far");  //Add outline
                $(this).removeClass("fas"); //Remove Solid
            } else {

            }
        });
    }

    //Set rating value based on clicked star
    $(".rating-star").on("click", function () {
        $("#rating-value").val($(this).data("value"));  //Set rating value to clicked value
        updateStarIcons();  //Sets Star Values to correct state
    });
    
});