
//ControlTab For Edit
function getstattab1() {

    if ($("#nex1").prop('checked')) {
        $(".l0").removeClass('active').addClass('completed');
        $("#tab2-1").removeClass('active');
        $("#tab2-2").addClass('active');
        $(".l1").addClass('active');
    }
}

function getstattab2() {
    if ($("#nex2").prop('checked')) {
        $(".l1").removeClass('active').addClass('completed');
        $("#tab2-2").removeClass('active');
        //same
        $("#tab2-3").addClass('active');
        $(".l2").addClass('active');
    }
}

function getstattab3() {
    if ($("#nex3").prop('checked')) {
        $(".l2").removeClass('active').addClass('completed');
        $("#tab2-3").removeClass('active');
        //same
        $("#tab2-4").addClass('active');
        $(".l3").addClass('active');
    }
}

function getstattab4() {
    if ($("#nex4").prop('checked')) {
        $(".l3").removeClass('active').addClass('completed');

    }
}

function getstattab5() {
    if ($("#nex5").prop('checked')) {
        $(".l4").removeClass('active').addClass('completed');

    }
}

$("#root").ready(function () {
    getstattab1();
    getstattab2();
    getstattab3();
    getstattab4();
    getstattab5();
});
//End

//Contorl Tab In Clint
$("#nex1").change(function () {
    if (this.checked) {

        $(".l0").removeClass('active').addClass('completed');

    } else {

        $(".l0").removeClass('completed').addClass('active');

    }
});

$("#nex2").change(function () {
    if (this.checked) {

        $(".l1").removeClass('active').addClass('completed');

    } else {

        $(".l1").removeClass('completed').addClass('active');

    }
});
$("#nex3").change(function () {
    if (this.checked) {

        $(".l2").removeClass('active').addClass('completed');

    } else {

        $(".l2").removeClass('completed').addClass('active');

    }
});
$("#nex4").change(function () {
    if (this.checked) {

        $(".l3").removeClass('active').addClass('completed');

    } else {

        $(".l3").removeClass('completed').addClass('active');

    }
});
$("#nex5").change(function () {
    if (this.checked) {

        $(".l4").removeClass('active').addClass('completed');

    } else {

        $(".l4").removeClass('completed').addClass('active');

    }
});
//End

//DropZone Logic
var imguids = "";

var ob = $("#myId").dropzone({
    url: "/Treatments/UploadFile",
    success: function (file, response) {
        imguids += response + ";";
    },
    addRemoveLinks: true,
    removedfile: function (file) {

        $.get("http://" + "@Context.Request.Host.ToString()" + "/Treatments/RemoveFile?name=" + file.id,
            function () {
                alert("تم حذف الملف بنجاح!");
            });
        var _ref;
        return (_ref = file.previewElement) != null ? _ref.parentNode.removeChild(file.previewElement) : void 0;
    }
});

var files = $("#imgs").text().split(';');

var hostname = $("#hosname").text();

for (var i = 0; i < files.length - 1; i++) {
    var filepath = "";
    var mockFile = { name: 'ملف', size: 13450, id: files[i] };
    ob[0].dropzone.emit("addedfile", mockFile);
    ob[0].dropzone.emit("thumbnail", mockFile, hostname + files[i] + ".jpg");
    ob[0].dropzone.emit("complete", mockFile);
}

$("#root").submit(function () {
    $("#ids").val(imguids);
});
//End



$("#is").click(function () {

    map.setCenter({ lat: Number($("#Latute").val()), lng: Number($("#Longtute").val()) });
    var myLatLng = { lat: Number($("#Latute").val()), lng: Number($("#Longtute").val()) };
    var marker = new google.maps.Marker({
        position: myLatLng,
        map: map,
        title: 'موقع العقار'
    });

    //  var obj = map.getCenter();
    //lng() lat()

});

//End
// multiple input 
$("#MeterPriceEarh").focusout(function () {
    var value = $("#AreaEarth").val() * $("#MeterPriceEarh").val();
    $("#TotalEarh").val(value);
});

$("#MeterPriceQabo").focusout(function () {
    var value = $("#AreaQabo").val() * $("#MeterPriceEarh").val();
    $("#TotalQabo").val(value);
});

$("#MeterPriceDorEarth").focusout(function () {
    var value = $("#AreaDorEarth").val() * $("#MeterPriceDorEarth").val();
    $("#TotalDorerath").val(value);
});

$("#MeterPriceFirstDoor").focusout(function () {
    var value = $("#AreaFirstDoor").val() * $("#MeterPriceFirstDoor").val();
    $("#TotalFirstDoor").val(value);
});

$("#MeterPriceReptDoor").focusout(function () {
    var value = $("#AreareptDoor").val() * $("#MeterPriceReptDoor").val();
    $("#TotalReptDoor").val(value);
});

$("#MeterPriceApendexErth").focusout(function () {
    var value = $("#AreaApnedxEarth").val() * $("#MeterPriceApendexErth").val();
    $("#TotalApendxEarth").val(value);
});

$("#MeterPriceapendxup").focusout(function () {
    var value = $("#AreaApendxup").val() * $("#MeterPriceapendxup").val();
    $("#Totalapendxup").val(value);
});

$("#MeterPriceAsawr").focusout(function () {
    var value = $("#AreaSwar").val() * $("#MeterPriceAsawr").val();
    $("#TotalAswar").val(value);
});

$("#MeterPricegarden").focusout(function () {
    var value = $("#Areagarden").val() * $("#MeterPricegarden").val();
    $("#Totalgarden").val(value);
});

$("#MeterPriceswiminpoo").focusout(function () {
    var value = $("#AreaSwimingpool").val() * $("#MeterPriceswiminpoo").val();
    $("#Totalswimingpool").val(value);
});

$("#MeterPriceCars").focusout(function () {
    var value = $("#AreaCars").val() * $("#MeterPriceCars").val();
    $("#TotalCars").val(value);
});

$("#MeterPriceothers").focusout(function () {
    var value = $("#AreaOthers").val() * $("#MeterPriceothers").val();
    $("#Totalothers").val(value);
});

$("#Musteh").focusin(function () {

    var totalMusteh = parseInt($("#AreaEarth").val()) +
        parseInt($("#AreaQabo").val()) +
        parseInt($("#AreaDorEarth").val()) +
        parseInt($("#AreaFirstDoor").val()) +
        parseInt($("#AreareptDoor").val()) +
        parseInt($("#AreaApnedxEarth").val()) +
        parseInt($("#AreaApendxup").val()) +
        parseInt($("#AreaSwar").val()) +
        parseInt($("#Areagarden").val()) +
        parseInt($("#AreaSwimingpool").val()) +
        parseInt($("#AreaCars").val()) +
        parseInt($("#AreaOthers").val());

    $("#Musteh").val(totalMusteh);
});

$("#TotalBulding").focusout(function () {
    $("#TotalPriceNumber").val(parseInt($("#TotalForEarcth").val()) + parseInt($("#TotalBulding").val()));
});

if ($.isFunction($.fn.bootstrapWizard)) {
    $('#rootwizard').bootstrapWizard({
        tabClass: 'wizard-steps',
        onTabShow: function ($tab, $navigation, index) {
            $tab.prevAll().addClass('completed');
            $tab.nextAll().removeClass('completed');
            $tab.removeClass('completed');
        }

    });

    $(".validate-form-wizard").each(function (i, formwizard) {
        var $this = $(formwizard);
        var $progress = $this.find(".steps-progress div");

        var $validator = $this.validate({
            rules: {
                username: {
                    required: true,
                    minlength: 3
                },
                password: {
                    required: true,
                    minlength: 3
                },
                confirmpassword: {
                    required: true,
                    minlength: 3
                },
                email: {
                    required: true,
                    email: true,
                    minlength: 3
                }
            }
        });
        // Validation
        var checkValidaion = function (tab, navigation, index) {
            if ($this.hasClass('validate')) {
                var $valid = $this.valid();
                if (!$valid) {
                    $validator.focusInvalid();
                    return false;
                }
            }

            return true;
        };

        $this.bootstrapWizard({
            tabClass: 'wizard-steps',
            onNext: checkValidaion,
            onTabClick: checkValidaion,
            onTabShow: function ($tab, $navigation, index) {

                switch (index) {
                case 0:
                    if ($("#nex1").prop('checked')) {
                        $tab.removeClass('active').addClass('completed');

                    } else {
                        $tab.removeClass('completed').addClass('active');
                    }
                    break;
                case 1:
                   
                    if (!isloaded) {
                        mapwork();
                        isloaded = true;
                    }
                    if ($("#nex2").prop('checked')) {
                        $tab.removeClass('active').addClass('completed');

                    } else {
                        $tab.removeClass('completed').addClass('active');
                    }
                    break;
                case 2:
                    if ($("#nex3").prop('checked')) {
                        $tab.removeClass('active').addClass('completed');

                    } else {
                        $tab.removeClass('completed').addClass('active');
                    }
                    break;
                case 3:
                    if ($("#nex4").prop('checked')) {
                        $tab.removeClass('active').addClass('completed');

                    } else {
                        $tab.removeClass('completed').addClass('active');
                    }
                    break;
                case 4:
                    if ($("#nex5").prop('checked')) {
                        $tab.removeClass('active').addClass('completed');

                    } else {
                        $tab.removeClass('completed').addClass('active');
                    }
                default:

                }




                //$tab.removeClass('completed');
                //$tab.prevAll().addClass('completed');
                //$tab.nextAll().removeClass('completed');
            }
        });
    });
}




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

//Tthmeen

$("#GenlocFlag").click(function () {

    $("#flagid").val($(this).data('id'));
    $("#idofselect").val($(this).data('se'));
    $('#mymodal').modal('show');

});