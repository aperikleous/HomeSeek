    $(".shop-price").ionRangeSlider({
        keyboard: true,
		prefix: "$"
    });
	//   show hide------------------
    $(".show-cart").on("click", function() {
        $(".cart-overlay").fadeIn(400);
        $(".cart-modal").animate({
            right: 0
        }, 400);
        return false;
    });
    $(".cart-overlay , .close-cart").on("click", function() {
        $(".cart-overlay").fadeOut(400);
        $(".cart-modal").animate({
            right: "-350px"
        }, 400);
        return false;
    });