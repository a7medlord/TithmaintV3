$(".select2").css("width", "100%");

$("#root").submit(function () {
    
    var today = new Date();
    var spliter = today.toString("HH:MM tt").split(" ");
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();

    $("#DateRiminder").val(mm + "/" + dd + "/" + yyyy + " " + spliter[4]);

    $("#DateOfBegin").val(mm + "/" + dd + "/" + yyyy + " " + "00:00:00");
});
//end

$("#cityflag").click(function () {
    $("#flagid").val($(this).data('id'));
    $("#idofselect").val($(this).data('se'));
    $('#mymodal').modal('show');
});

$("#Gadaflag").click(function () {

    $("#flagid").val($(this).data('id'));
    $("#idofselect").val($(this).data('se'));
    $('#mymodal').modal('show');

});

$("#TbulidFlag").click(function () {

    $("#flagid").val($(this).data('id'));
    $("#idofselect").val($(this).data('se'));
    $('#mymodal').modal('show');

});
