$(".select2").css("width", "100%");
//Control Tab
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
//end

//Drop Zone Logic
var imguids = "";
$("#myId").dropzone({
    url: "/R2Smaple/UploadFile",
    success: function (file, response) {
        imguids += response + ";";
    }
});

$("#root").submit(function () {
    $("#ids").val(imguids);

    var today = new Date();
    var spliter = today.toString("HH:MM tt").split(" ");
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();

    $("#DateRiminder").val(mm + "/" + dd + "/" + yyyy + " " + spliter[4]);

    $("#DateOfBegin").val(mm + "/" + dd + "/" + yyyy + " " + "00:00:00");

});
//end

//Google Map Logic
var pos;
var geocoder;
var infowindowc;
var isloaded = false;
var map;
var markerstotal = [];
var markers = [];

function cleramarkers() {
    for (var i = 0; i < markerstotal.length; i++) {
        markerstotal[i].setMap(null);
    }

    for (var n = 0; n < markers.length; n++) {
        markers[n].setMap(null);
    }
}

function getlog() {

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };
            cleramarkers();
            var marker = new google.maps.Marker({
                position: pos,
                map: map,
                title: 'موقع العقار',
                draggable: true
            });

            google.maps.event.addListener(marker, "dragend", function (e) {
                var lat, lng, address;
                geocoder.geocode({ 'latLng': marker.getPosition() }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        lat = marker.getPosition().lat();
                        lng = marker.getPosition().lng();
                        address = results[0].formatted_address;
                        $("#Latute").val(lat);
                        $("#Longtute").val(lng);
                    }
                });
            });
            markerstotal.push(marker);
            map.setCenter(pos);

        }, function () {

            handleLocationError(true, infoWindow, map.getCenter());
        }, {
            enableHighAccuracy: false,
            timeout: 30000,
            maximumAge: 30000
        });
    } else {
        // Browser doesn't support Geolocation
        handleLocationError(false, infoWindow, map.getCenter());
    }
    // End of get Current Locations
}

function mapwork() {

    var mapProp = {
        center: new google.maps.LatLng(51.508742, -0.120850),
        zoom: 18
    };

    map = new google.maps.Map(document.getElementById("maptest"), mapProp);
    var myLatLng = { lat: Number($("#Latute").val()), lng: Number($("#Longtute").val()) };
    cleramarkers();
    var marker3 = new google.maps.Marker({
        position: myLatLng,
        map: map,
        title: 'موقع العقار',
        draggable: true
    });

    google.maps.event.addListener(marker3, "dragend", function (e) {
        var lat, lng, address;
        geocoder.geocode({ 'latLng': marker3.getPosition() }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {

                lat = marker3.getPosition().lat();
                lng = marker3.getPosition().lng();
                address = results[0].formatted_address;

                $("#Latute").val(lat);
                $("#Longtute").val(lng);
            }
        });
    });
    markerstotal.push(marker3);

    map.addListener('center_changed', function () {
        var obj = map.getCenter();
        $("#Latute").val(obj.lat());
        $("#Longtute").val(obj.lng());

    });


    geocoder = new google.maps.Geocoder;
    infowindowc = new google.maps.InfoWindow;

    var input = document.getElementById('pac-input');
    var searchBox = new google.maps.places.SearchBox(input);

    map.addListener('bounds_changed',
        function () {
            searchBox.setBounds(map.getBounds());
        });


    // Listen for the event fired when the user selects a prediction and retrieve
    // more details for that place.
    searchBox.addListener('places_changed',
        function () {
            var places = searchBox.getPlaces();

            if (places.length == 0) {
                return;
            }

            // Clear out the old markers.
            markers.forEach(function (marker) {
                marker.setMap(null);
            });
            markers = [];

            // For each place, get the icon, name and location.
            var bounds = new google.maps.LatLngBounds();
            places.forEach(function (place) {
                if (!place.geometry) {
                    console.log("Returned place contains no geometry");
                    return;
                }

                cleramarkers();
                var marker2 = new google.maps.Marker({
                    map: map,
                    title: place.name,
                    position: place.geometry.location,
                    draggable: true
                });
                markers.push(marker2);


                google.maps.event.addListener(marker2, "dragend", function (e) {
                    var lat, lng, address;
                    geocoder.geocode({ 'latLng': marker2.getPosition() }, function (results, status) {
                        if (status == google.maps.GeocoderStatus.OK) {

                            lat = marker2.getPosition().lat();
                            lng = marker2.getPosition().lng();
                            address = results[0].formatted_address;
                            $("#Latute").val(lat);
                            $("#Longtute").val(lng);
                        }
                    });
                });
                if (place.geometry.viewport) {
                    // Only geocodes have viewport.
                    bounds.union(place.geometry.viewport);
                } else {
                    bounds.extend(place.geometry.location);
                }
            });
            map.fitBounds(bounds);
        });


}

function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(browserHasGeolocation
        ? 'Error: الخدمه فشلت في جلب الموقع'
        : 'Error: Your browser doesn\'t support geolocation.');
}

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

$("#LastTaqeem").focusin(function () {
    var areatotal = parseInt($("#AreaEarth").val()) +
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

    var metertotal = parseInt($("#MeterPriceEarh").val()) +
        parseInt($("#MeterPriceQabo").val()) +
        parseInt($("#MeterPriceDorEarth").val()) +
        parseInt($("#MeterPriceFirstDoor").val()) +
        parseInt($("#MeterPriceReptDoor").val()) +
        parseInt($("#MeterPriceApendexErth").val()) +
        parseInt($("#MeterPriceapendxup").val()) +
        parseInt($("#MeterPriceAsawr").val()) +
        parseInt($("#MeterPricegarden").val()) +
        parseInt($("#MeterPriceswiminpoo").val()) +
        parseInt($("#MeterPriceCars").val()) +
        parseInt($("#MeterPriceothers").val());

    var total = areatotal * metertotal;
    $("#LastTaqeem").val(total);
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
                    minlength: 3,
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

$("#FlagForSaprateType").click(function () {

    $("#flagid").val($(this).data('id'));
    $("#idofselect").val($(this).data('se'));
    $('#mymodal').modal('show');

});


$("#FlagFprInterfcaesNorth").click(function () {

    $("#flagid").val($(this).data('id'));
    $("#idofselect").val($(this).data('se'));
    $('#mymodal').modal('show');

});

$("#FlagForInterfcaesSouth").click(function () {

    $("#flagid").val($(this).data('id'));
    $("#idofselect").val($(this).data('se'));
    $('#mymodal').modal('show');

});

$("#FlagForInterfcaesEast").click(function () {

    $("#flagid").val($(this).data('id'));
    $("#idofselect").val($(this).data('se'));
    $('#mymodal').modal('show');

});

$("#FlagFOrInterfcaesWest").click(function () {

    $("#flagid").val($(this).data('id'));
    $("#idofselect").val($(this).data('se'));
    $('#mymodal').modal('show');

});

$("#FlagForXtrenalDoor").click(function () {

    $("#flagid").val($(this).data('id'));
    $("#idofselect").val($(this).data('se'));
    $('#mymodal').modal('show');

});

$("#FlagForInnerDoor").click(function () {

    $("#flagid").val($(this).data('id'));
    $("#idofselect").val($(this).data('se'));
    $('#mymodal').modal('show');

});

$("#FlagForAhwash").click(function () {

    $("#flagid").val($(this).data('id'));
    $("#idofselect").val($(this).data('se'));
    $('#mymodal').modal('show');

});

$("#FlagForRescptions").click(function () {

    $("#flagid").val($(this).data('id'));
    $("#idofselect").val($(this).data('se'));
    $('#mymodal').modal('show');

});


$("#FlagForInner").click(function () {

    $("#flagid").val($(this).data('id'));
    $("#idofselect").val($(this).data('se'));
    $('#mymodal').modal('show');

});

$("#FlagForRooms").click(function () {

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