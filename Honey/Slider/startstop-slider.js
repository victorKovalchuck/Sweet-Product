// SET THIS VARIABLE FOR DELAY, 1000 = 1 SECOND
var delayLength = 5000;
var counter = 2;
var sliderIntervalID = null;
var resize = false;
var justClick = true;
var panelWidth = null;
var numPanels = null;
var tooFar = null;


function doMove(panelWidth, tooFar, numPanels) {
    var leftValue = $("#mover").css("left");
    var $slide1H = $("#slide-" + counter + " p");    
   
    counter = counter + 1;
    if (counter > numPanels) {
        counter = 1;
    }
    var height = $slide1H.css("height");
    height = parseFloat(height, 10);
    height = height + 90;
	// Fix for IE
	if (leftValue == "auto") { leftValue = 0; };
	
	var movement = parseFloat(leftValue, 10) - panelWidth;

	if (movement <= tooFar || resize == true) {
	    resize = false;	   
		$(".slide img").animate({
			"top": -600
		}, function() {
			$("#mover").animate({
				"left": 0
			}, function() {
				$(".slide img").animate({
				    "top": height
				});
			});
		});
	}
	else {
		$(".slide img").animate({
			"top": -600
		}, function() {
			$("#mover").animate({
				"left": movement
			}, function() {
				$(".slide img").animate({
				    "top": height
				});
			});
		});
	}
}

$(document).ready(function () {
    if (sliderIntervalID != null) {
        clearInterval(sliderIntervalID);
    }
    SetSliderData();
    SliderEngine();
    SliderClick();

    $(window).resize(function () {
        if (sliderIntervalID != null) {
            clearInterval(sliderIntervalID);
        }
        resize = true;
        counter = 1;
        SetSliderData();
        SliderEngine();
    });
});


function SetSliderData() {

    var $slide1 = $("#slide-1");
    panelWidth = $slide1.css("width");
    var panelPaddingLeft = $slide1.css("paddingLeft");
    var panelPaddingRight = $slide1.css("paddingRight");

    panelWidth = parseFloat(panelWidth, 10);
    panelPaddingLeft = parseFloat(panelPaddingLeft, 10);
    panelPaddingRight = parseFloat(panelPaddingRight, 10);

    panelWidth = panelWidth + panelPaddingLeft + panelPaddingRight;

    numPanels = $(".slide").length;
    tooFar = -(panelWidth * numPanels);
    var totalMoverwidth = numPanels * panelWidth;
    $("#mover").css("width", "2400%");
}

function SliderEngine() {
       
    if (sliderIntervalID != null) {
        clearInterval(sliderIntervalID);
        $(".slide p").css("font-weight", "normal");
        justClick = true;
    }
    sliderIntervalID = setInterval(function () {
        doMove(panelWidth, tooFar, numPanels);
    }, delayLength);

}

function SliderClick() {
    $("#page-wrap").click(function () {
        if (sliderIntervalID != null) {
            clearInterval(sliderIntervalID);
        }
        if (justClick == true) {
            $(".slide p").css("font-weight", "bolder");
            justClick = false;
        }
        else {
            $(".slide p").css("font-weight", "normal");
            sliderIntervalID = setInterval(function () {
                doMove(panelWidth, tooFar, numPanels);
            }, delayLength);
            justClick = true;
        }
    });
}