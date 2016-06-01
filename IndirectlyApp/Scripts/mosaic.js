$(function () {
  
    var string = {
        empty: ""
    };

    $("span[data-isliked]")
        .each(function() {

            $(this)
                .on("click",
                    function() {

                        likeOrUnlike(this.id, $(this).attr("data-isliked"));
                    });
        });

    $(".user-comment").on('keydown', function (e) {
        e.stopPropagation();
        if (e.which !== 13) {
            return;
        }
        
        e.Handled = true;

        var comment = { mosaicId: $(this).attr("data-mosaicid"), body: $(this).val()};


        $.ajax({
            url: '/Mosaic/CreateComment',
            type: "POST",
            contentType: 'application/json',
            data: JSON.stringify(comment),
            async: true,
            processData: false,
            cache: false,
            success: function (data) {
                alert(data.Body);
                console.log(user);

                $(".user-comment").val('');

                var newComment = document.createElement("strong");

                newComment.innerHTML = user.Data.Username;

                $("#commentsContainer" + "[data-mosaicid='0']").append("<strong>usr</strong>").append("test").append("<br/>");

                $("#commentsContainer" + "[data-mosaicid='" + user.Data.MosaicId + "']").append("<strong>" + user.Data.Username + "</strong>").append(" " + user.Data.Body).append("<br/>");


            },
            error: function (xhr) {
                
            }
        });
    });

});


function likeOrUnlike(id, isLiked) {

    if (isLiked === "True") {
        unlike(id);
    } else {
        like(id);
    }
}

function like(id) {
  
    $("span#" + id).css({ 'color': 'red' }).attr("data-isliked", "True");

    $.ajax({
        url: '/Mosaic/Like',

        type: "POST",
        contentType: 'application/json',
        data: JSON.stringify({ id: id }),
        async: true,
        processData: false,
        cache: false,
        success: function(data) {
            $("span#" + id).css({ 'color': 'red' }).attr("data-isliked", "True");
        },
        error: function(xhr) {
            $("span#" + id).css({ 'color': '#E5E5E5' }).attr("data-isliked", "False");
        }
    });

}

function unlike(id) {

    $("span#" + id).css({ 'color': '#E5E5E5' }).attr("data-isliked", "False");

    $.ajax({
        url: '/Mosaic/Unlike',

        type: "POST",
        contentType: 'application/json',
        data: JSON.stringify({ id: id }),
        async: true,
        processData: false,
        cache: false,
        success: function(data) {
            $("span#" + id).css({ 'color': '#E5E5E5' }).attr("data-isliked", "False");
        },
        error: function(xhr) {
            $("span#" + id).css({ 'color': 'red' }).attr("data-isliked", "True");
        }
    });

}