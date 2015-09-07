﻿$(document).ready(function () {
 function slideShow() {
    var displayToggled = false;
    var current1 = $('.slide:visible');
    var nextSlide = current1.next('.slide');
    var hideoptions = {
        "direction": "left",
        "mode": "hide"
    };
    var showoptions = {
        "direction": "right",
        "mode": "show"
    };
    if (current1.is(':last-child')) {
        current1.effect("slide", hideoptions, 1000);
        $("#firstSlide").effect("slide", showoptions, 1000);
    }
    else {
        current1.effect("slide", hideoptions, 1000);
        nextSlide.effect("slide", showoptions, 1000);
    }
};
setInterval(slideShow, 3000);
slideShow();​
});