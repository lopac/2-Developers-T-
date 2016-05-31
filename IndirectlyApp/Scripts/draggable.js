$(function() {
 
    $("#img_rnd")
       .resizable({ ghost: true });
    $("#rnd").draggable({ containment: "#containment-wrapper", scroll: false });
   



    $("#click").click(function(){
      var p = $("#item1");
      
        //  alert(p.offsetLeft, p.offsetTop);
        alert(JSON.stringify(p.position()));
    });


    var starawidth = $("#containment-wrapper").width();
    $(window).resize(function (e) {
        if (e.target != window) {
            return;
        }
        
        var containerWidth = $("#containment-wrapper").width();
        var widthz = $("#img_rnd").width();
        $("#img_rnd").css("width", (widthz * (containerWidth/starawidth)) + 2);
        $(".ui-wrapper").css("width",( widthz * (containerWidth / starawidth)) + 2);
        var positiony = $("#rnd").position().left;
        $("#rnd").css("left", positiony * (containerWidth / starawidth));
        starawidth = $("#containment-wrapper").width();
    });
  });