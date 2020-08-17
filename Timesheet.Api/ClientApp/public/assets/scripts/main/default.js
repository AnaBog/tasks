$(document).ready(function () {

	//user menu
	$('.user li').mouseover(function () {
		$(this).children('.user-menu').show();
		$(this).children('.invisible').show();
	}).mouseout(function () {
		$(this).children('.user-menu').hide();
		$(this).children('.invisible').hide();
	});

	//mobile menu
	 $('.mobile-menu .menu-btn').click(function () {
		$('.mobile-menu ul').slideToggle();
	});

	//datepicker 
	if ($('.datepicker').length) {
		$('.datepicker').datepicker();
	}

	//fancybox 
	if ($('.new-member-popup').length) {
		$('.new-member-popup').fancybox();
	}

	// var headerHeight = $('header').height(),
	// 	footerHeight = $('footer').outerHeight(true);
	// $(window).resize(function () {
	// 	contentHeight();
	// });
	// contentHeight();
	// function contentHeight() {
	// 	$('.container > .wrapper').height($(window).height() - headerHeight - footerHeight);
	// }

});

