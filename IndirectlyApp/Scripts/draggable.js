$(function() {
    $( "#item1" ).draggable({ containment: "#containment-wrapper", scroll: false });

    $("#click").click(function(){
      var p = $("#item1");
      
        //  alert(p.offsetLeft, p.offsetTop);
        alert(JSON.stringify(p.position()));
    });
    $(window).resize(function () {
        
        var containerWidth = $("#containment-wrapper").width();
        //var width = 224;
        //var height = 289;
        //alert(container);
        //var slika1 = ;
        var leftx = 100;
        var top = 100;
        $("#item1").css("width", 224 * (containerWidth / 500));
        $("#item1").css("height", "auto");
        $("#item1").css("left", 100 * (containerWidth / 500));
        //$("#item1").css("height", 100 * 500);
    });
  });