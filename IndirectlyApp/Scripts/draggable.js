$(function() {
    $( "#item1" ).draggable({ containment: "#containment-wrapper", scroll: false });

    $("#click").click(function(){
      var p = $("#item1");
      
        //  alert(p.offsetLeft, p.offsetTop);
        alert(JSON.stringify(p.position()));
    });
    $(window).resize(function () {
        
        var containerWidth = $("#containment-wrapper").width();

        //alert(container);
        //var slika1 = ;
        $("#item1").css("width", $("#item1").width() * (containerWidth / 500));
    });
  });