"use strict"; // Start of use strict

// 7. google map
function gMap() {
    if ($('.google-map').length) {
        $('.google-map').each(function() {
            // getting options from html
            var Self = $(this);
            var mapName = Self.attr('id');
            var mapLat = Self.data('map-lat');
            var mapLng = Self.data('map-lng');
            var iconPath = Self.data('icon-path');
            var mapZoom = Self.data('map-zoom');
            var mapTitle = Self.data('map-title');
            var markers = Self.data('markers');



            // defined default style
            var styles = [{
                "featureType": "landscape",
                "elementType": "labels",
                "stylers": [{
                    "visibility": "off"
                }]
            }, {
                "featureType": "transit",
                "elementType": "labels",
                "stylers": [{
                    "visibility": "off"
                }]
            }, {
                "featureType": "poi",
                "elementType": "labels",
                "stylers": [{
                    "visibility": "off"
                }]
            }, {
                "featureType": "water",
                "elementType": "labels",
                "stylers": [{
                    "visibility": "off"
                }]
            }, {
                "featureType": "road",
                "elementType": "labels.icon",
                "stylers": [{
                    "visibility": "off"
                }]
            }, {
                "stylers": [{
                    "hue": "#00aaff"
                }, {
                    "saturation": -100
                }, {
                    "gamma": 2.15
                }, {
                    "lightness": 12
                }]
            }, {
                "featureType": "road",
                "elementType": "labels.text.fill",
                "stylers": [{
                    "visibility": "on"
                }, {
                    "lightness": 24
                }]
            }, {
                "featureType": "road",
                "elementType": "geometry",
                "stylers": [{
                    "lightness": 57
                }]
            }];

            // if zoom not defined the zoom value will be 15;
            if (!mapZoom) {
                var mapZoom = 14;
            };
            // init map
            var map;
            map = new GMaps({
                div: '#' + mapName,
                scrollwheel: false,
                lat: mapLat,
                lng: mapLng,
                styles: styles,
                zoom: mapZoom
            });
            // if icon path setted then show marker
            if (iconPath) {
                $.each(markers, function(index, value) {
                    var index = value;
                    var html;
                    if (index[2]) {
                        html = index[2];
                    };
                    if (!index[3]) {
                        index[3] = iconPath;
                    };

                    map.addMarker({
                        icon: index[3],
                        lat: index[0],
                        lng: index[1],
                        infoWindow: {
                            content: html
                        }
                    });

                });
            }
        });
    };
}


// instance of fuction while Document ready event   
jQuery(document).on('ready', function() {
    (function($) {
        gMap();
    })(jQuery);
});
