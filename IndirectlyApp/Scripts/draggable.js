$(function() {
    $( "#item1" ).draggable({ containment: "#containment-wrapper", scroll: false });

    $("#click").click(function(){
      var p = $("#item1");
      
        //  alert(p.offsetLeft, p.offsetTop);
        alert(JSON.stringify(p.position()));
    });

  });