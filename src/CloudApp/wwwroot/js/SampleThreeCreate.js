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



$("#FlagForAqarType").click(function () {

    $("#flagid").val($(this).data('id'));
    $("#idofselect").val($(this).data('se'));
    $('#mymodal').modal('show');

});

$("#CityFlage").click(function () {

    $("#flagid").val($(this).data('id'));
    $("#idofselect").val($(this).data('se'));
    $('#mymodal').modal('show');

});

$("#GadaFlage").click(function () {

    $("#flagid").val($(this).data('id'));
    $("#idofselect").val($(this).data('se'));
    $('#mymodal').modal('show');

});

$('#s1').datepicker({
    keyboardNavigation: false,
    forceParse: false,
    todayHighlight: true
});

$('#s2').datepicker({
    keyboardNavigation: false,
    forceParse: false,
    todayHighlight: true
});