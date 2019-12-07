$(function () {

    function updateReviews() {
        $.ajax({
            headers: { "Content-Type": "application/json" },
            url: "../../api/product/" + $("#forProduct").val()+"/review",
            type: 'post',
            success: function (response, textStatus, jqXhr) {
                console.log("Updating");
                var output = '';
                for (let i = 0; i < response.length; i++) {
                    output += '<div class="container border border-primary"><br>';
                    output += "<h5>" + response[i].postedOn + "</h5>"
                        + "<h3>" + response[i].title;
                    for (let j = 0; j < response[i].rating; j++)
                    {
                        output += '<i class="fas fa-star rating-star"></i>';
                    }
                    output += "</h3>" + '<p>' + response[i].body + '</p>';
                    output += '</div><br/>';
                }
                $("#reviews").html(output);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                //toast("Error", "Please try again later.");
                console.log("The following error occured: " + jqXHR.status, errorThrown);
            }
        });
    }

    updateReviews();

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
        console.log($("#rating-value").val());
        updateStarIcons();  //Sets Star Values to correct state
    });

    //Call AddRating API When SubmitButton Clicked
    $('#addReview').on('click', function () {
        if ($('#User').data('customer').toLowerCase() == "true") {
            $.ajax({
                headers: { "Content-Type": "application/json" },
                url: "../../api/addReview",
                type: 'post',
                data: JSON.stringify({
                    "rating": $("#rating-value").val(),
                    "forProduct": $("#forProduct").val(),
                    "postedBy": $('#User').data('email'),
                    "title": $("#title").val(),
                    "body": $('#body').val()
                }),
                success: function (response, textStatus, jqXhr) {
                    updateReviews();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    toast("Error", "Please try again later.");
                    console.log("The following error occured: " + jqXHR.status, errorThrown);
                }
            });
            $("#rating-value").val(0);
            updateStarIcons();
            $("#title").val("");
            $('#body').val("");

        } else {
            toast("Access Denied", "You must be signed in as a customer to access the cart.");
            updateReviews();
        }

    });

    function toast(header, message) {
        $('#toast_header').html(header);
        $('#toast_body').html(message);
        $('#cart_toast').toast({ delay: 2500 }).toast('show');
    }
    
});