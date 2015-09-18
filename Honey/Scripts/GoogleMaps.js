
var myCenter = new google.maps.LatLng(48.504130, 32.226578);
    function initialize() {       
        var mapOptions =
    {
        center: new google.maps.LatLng(48.504130, 32.226578),
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