﻿
    var myCenter = new google.maps.LatLng(50.243114, 25.085982);
    function initialize() {

        var mapOptions =
    {
        center: new google.maps.LatLng(50.243114, 25.085982),
        zoom: 8,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);
    var marker = new google.maps.Marker({
        position: myCenter,
        title: 'Збільшити'
    });

    marker.setMap(map);
    google.maps.event.addListener(marker, 'click', function () {
        map.setZoom(12);
        map.setCenter(marker.getPosition());
    });
}
google.maps.event.addDomListener(window, 'load', initialize);