$(function() {
 
    $("#item1-img")
       .resizable({ ghost: true });
    $("#item1").draggable({ containment: "#containment-wrapper", scroll: true });
   



    $("#click").click(function(){
      var p = $("#item1");
      
        //  alert(p.offsetLeft, p.offsetTop);
        alert(JSON.stringify(p.position()));
    });



    $(window).resize(function () {
        
        var containerWidth = $("#containment-wrapper").width();
      

        var leftx = 100;
        var top = 100;
        //$("#item1-img").css("width", 224 * (containerWidth / 500));
        //$("#item1-img").css("height", "auto");
        //$("#item1-img").css("left", 100 * (containerWidth / 500));
     

        $("#item1").css("width", 224 * (containerWidth / 500));
        $("#item1").css("height", "auto");
        $("#item1").css("left", 100 * (containerWidth / 500));
    });
  });