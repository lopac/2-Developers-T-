$(function () {

    var oldWrapperWidth = $("#wrapper").width();


    var items = $(".item");
    var itemsImg = $(".item-img");



    $.each(items, function () {
        $(this).draggable({ containment: "#wrapper", scroll: false });
    });


    $.each(itemsImg, function (index, item) {
        $(this).resizable({
            ghost: true,
            aspectRatio: item.width / item.height,


        });
    });



    $("#click")
        .click(function () {
            var p = $("#item");
            alert(JSON.stringify(p.position()));
        });


    //ON  Window resize
    $(window).resize(function (event) {

        if (event.target !== window) {
            return;
        }

        //<summary>
        // parent of itemsImg is ui-draggable
        // parent of parent is item
        //</summary>

        var newWrapperWidth = $("#wrapper").width();


        $.each(itemsImg, function () {
            var itemImgWidth = $(this).width();

            var itemY = $(this).parent().parent().position().left;

            $(this).css("width", (itemImgWidth * (newWrapperWidth / oldWrapperWidth)));
            $(this).css("height", "auto");

            $(this).parent().css("width", (itemImgWidth * (newWrapperWidth / oldWrapperWidth)));
            $(this).parent().css("height", "auto");
            $(this).parent().parent().css("left", itemY * (newWrapperWidth / oldWrapperWidth));
        });




        oldWrapperWidth = $("#wrapper").width();
    });

});
