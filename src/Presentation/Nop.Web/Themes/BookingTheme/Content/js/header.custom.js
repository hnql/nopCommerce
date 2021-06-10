$(document).ready(function () {
  $('[data-action="popover"]').popover({
    content: function () {
      return $(this).next().html();
    },
    html: true,
    trigger: "hover"
  });
  $('[data-action="popover"]').on('show.bs.popover', function () {
    $(this).next().addClass('popover--opened');
  });
  $('[data-action="popover"]').on('hidden.bs.popover', function () {
    if ($(this).next().length === 0) {
      $(this).next().removeClass('popover--opened');
    }
  });
  $('[data-action="popover"]').on('click', function () {
    $(this).next().next().toggleClass('popover--opened');
  });
  $('.popover').mouseleave(function () {
    $(this).removeClass('popover--opened');
  });

  $('.menu-mobile--open').click(function () {
    $(this).next().toggleClass('menu--opened');
  });

  $('.menu-mobile--close').click(function () {
    $(this).parents('.menu').removeClass('menu--opened');
  });

  // Search by Date
  $('#trigger-date-range').daterangepicker();
  $('#trigger-date-range').on('apply.daterangepicker', function (ev, picker) {
    $(this).text(picker.startDate.format('MMMM D') + ' - ' + picker.endDate.format('MMMM D'));
  });

  $('#trigger-date-range').on('cancel.daterangepicker', function (ev, picker) {
    $(this).text('Ngày');
  });
});