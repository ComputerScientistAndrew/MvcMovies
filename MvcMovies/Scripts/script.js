

$(document).ready(function () {
    $('#divProcessing').hide();
});

$('.addRemoveBtn').click(function (e) {
    var btn = $(this);
    var movieId = btn.attr('id');
    var movieVal = btn.attr('value') == "False" ? 0 : 1;
    $.ajax({
        url: '/Movies/AddRemove',
        dataType: "html",
        data: { id: movieId, val: movieVal },
        type: "POST",
        success: function (data) {
            console.log(data);
            if (data == 2) {
                window.location.replace("http://localhost:26037/Account/Login");
            }
            else if (data == 0) {
                btn.attr('value', 'False');
                btn.html('Add to Watchlist');
            }
            else if (data == 1) {
                btn.attr('value', 'True');
                btn.html('Remove from Watchlist');
            }
        }
    });
});

$('.removeBtn').click(function (e) {
    var btn = $(this);
    var movieId = btn.attr('id');
    console.log(movieId);
    $.ajax({
        url: '/Watchlist/Remove',
        dataType: "html",
        data: { id: movieId },
        type: "POST",
        success: function () {
            location.reload();
        },
        error: function () {
            alert("Something went wrong when trying to remove the video.  Try again later." +
            "  If this keeps occuring, please contact support.  Thank you.");
        }               
        
    });
});

function GetMovieDetails(MovieId) {
    
    $('#movieInfo_content').dialog({
        dialogClass: 'moviedetail_dialog',
        width: 500,
        modal: true,
        clickOutside: true,
        open: function (event, ui) {
            $.ajax({
                url: "/Movies/GetMovieInfo",
                dataType: "html",
                data: { MovieId: MovieId },
                type: "GET",
                error: function (xhr, status, error) {
                    var err = eval("(" + xhr.responseText + ")");
                    toastr.error(err.message);
                },
                success: function (data) {
                    $('#MovieDetails').html(data);
                    $("#divProcessing").hide();

                },
                beforeSend: function () {
                    $("#divProcessing").show();
                }
            });
            
        },
        close: function (event, ui) { $('#movieInfo_content').dialog("destroy"); $('#MovieDetails').html(""); $(this).btn.attr},
    });
}
$('.btn').mouseup(function () { this.blur() });