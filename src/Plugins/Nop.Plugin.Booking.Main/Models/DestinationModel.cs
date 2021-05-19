using System;
using System.Collections.Generic;
using Nop.Core.Domain.Media;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Booking.Main.Models
{
    /// <summary>
    /// Represents a price range model
    /// </summary>
    public partial record DestinationModel : BaseNopModel
    {
        public struct Destination
        {
            public string Href;
            public string ImagePath;
            public string Title;
            public string Excerpt;
        }

        #region Properties


        public IList<Destination> Destinations { get; set; }

        #endregion

        public DestinationModel() {
            Destinations = new List<Destination>();
            Destinations.Add(new Destination { 
                Href = "vung-tau-biet-thu-ho-boi-618", 
                ImagePath = "apartment_2_1614588617.jpg",
                Title = "Vũng Tàu Biệt thự hồ bơi",
                Excerpt = "Những căn biệt thự có hồ bơi dành cho kỳ nghỉ của bạn tại Vũng Tàu"
            });
            Destinations.Add(new Destination
            {
                Href = "vi-vu-ngoai-thanh-ha-noi-619",
                ImagePath = "apartment_1_1614588454.jpg",
                Title = "Vi vu ngoại thành Hà Nội",
                Excerpt = "Trải nghiệm không gian thoáng đãng cho chuyến đi ngay gần Hà Nội"
            });
            Destinations.Add(new Destination
            {
                Href = "ha-noi-noi-thanh-lang-man-620",
                ImagePath = "apartment_1_1614660728.jpg",
                Title = "Hà Nội nội thành lãng mạn",
                Excerpt = "Không gian lãng mạn dành cho cặp đôi tại trung tâm Hà Nội"
            });
            Destinations.Add(new Destination
            {
                Href = "sai-gon-can-la-co-ngay-621",
                ImagePath = "apartment_2_1615794965.jpg",
                Title = "Sài Gòn cần là có ngay",
                Excerpt = "Những căn homestay có 01 phòng ngủ tại Sài Gòn có thể đặt nhanh chóng"
            });
            Destinations.Add(new Destination
            {
                Href = "be-boi-bbq-468",
                ImagePath = "apartment_1_1584606781.jpg",
                Title = "Bể bơi & BBQ",
                Excerpt = "Trải nghiệm đẳng cấp tại những căn homestay có bể bơi đẹp và khu vực BBQ ấm cúng."
            });
            Destinations.Add(new Destination
            {
                Href = "sieu-giam-gia-471",
                ImagePath = "apartment_2_1584606872.jpg",
                Title = "Siêu giảm giá!",
                Excerpt = "Top chỗ ở giảm giá đến 50% từ các chủ nhà thân thiện trên Luxstay."
            });
            Destinations.Add(new Destination
            {
                Href = "gan-trung-tam-314",
                ImagePath = "apartment_10_1584602562.jpg",
                Title = "Gần Trung tâm!",
                Excerpt = "Dễ dàng di chuyển khắp nơi với top chỗ ở khu vực trung tâm thành phố Hồ Chí Minh"
            });
        }
    }
}
