$(document).ready(function () {
	var heading = '.accordion-wrap .heading';

	$(heading).click(function () {
		if (!$(this).parent().hasClass('open')) {
			$(this).parent().addClass('open');
			$(this).next().slideDown('normal');
		} else {
			$(this).parent().removeClass('open');
			$(this).next().slideUp('normal');
		}
	});
});