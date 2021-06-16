
$(document).ready(function () {
  // Location
  $(".location-slider").slick({
    arrows: true,
    infinite: false,
    slidesToShow: 5,
    slidesToScroll: 1,
    responsive: [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 2,
        }
      }
    ]
  });
});