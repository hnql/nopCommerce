$(".promotion-slider div").slice(2, 3).slick({
  arrows: true,
  infinite: false,
  slidesToShow: 3,
  slidesToScroll: 1,
  responsive: [
    {
      breakpoint: 1024,
      settings: {
        slidesToShow: 2
      }
    }
  ]
});