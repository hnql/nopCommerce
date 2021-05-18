using System;
using System.Collections.Generic;
using Nop.Core.Domain.Media;
using Nop.Web.Framework.Models;

namespace Nop.Web.Models.Catalog
{
    /// <summary>
    /// Represents a price range model
    /// </summary>
    public partial record DiscoveryModel : BaseNopModel
    {
        public struct Discovery
        {
            public string HrefHeader;
            public string HrefTitle;
            public string ImagePath;
            public string Header;
            public string Title;
        }

        #region Properties


        public IList<Discovery> Discoveries { get; set; }

        #endregion

        public DiscoveryModel() {
            Discoveries = new List<Discovery>();
            Discoveries.Add(new Discovery
            { 
                HrefHeader = "homestay", 
                HrefTitle = "?p=22945",
                ImagePath = "resort-hang-sang-o-Viet-Nam-4-1024x650.jpg",
                Header = "Thông tin homestay",
                Title = "5 resort hạng sang ở Việt Nam xuất hiện trên tạp chí du lịch Anh"
            });
            Discoveries.Add(new Discovery
            {
                HrefHeader = "homestay",
                HrefTitle = "?p=22936",
                ImagePath = "du-lich-can-tho-8-824x1024.jpg",
                Header = "Thông tin homestay",
                Title = "Du lịch Cần Thơ nhất định phải ghé thăm những địa điểm này"
            });
            Discoveries.Add(new Discovery
            {
                HrefHeader = "du-lich-ho-chi-minh",
                HrefTitle = "?p=22905",
                ImagePath = "tuan-le-toi-yeu-banh-my-sai-gon-3.jpg",
                Header = "TP. Hồ Chí Minh",
                Title = "Tuần lễ “Tôi yêu bánh mì Sài Gòn” chính thức diễn ra từ ngày 24/3"
            });
            Discoveries.Add(new Discovery
            {
                HrefHeader = "homestay",
                HrefTitle = "?p=22846",
                ImagePath = "so-thu-zoodoo-da-lat-7.jpg",
                Header = "Thông tin homestay",
                Title = "Trải nghiệm thú vị ở sở thú Zoodoo Đà Lạt"
            });
            Discoveries.Add(new Discovery
            {
                HrefHeader = "du-lich-hoi-an",
                HrefTitle = "?p=22841",
                ImagePath = "hoi-an-lap-chot-quan-ly-du-khach-deo-khau-trang-4-1024x657.jpg",
                Header = "Hội An",
                Title = "Hội An sẽ lập chốt quản lý du khách đeo khẩu trang khi vào thành phố"
            });
            Discoveries.Add(new Discovery
            {
                HrefHeader = "homestay",
                HrefTitle = "?p=22835",
                ImagePath = "cach-ly-tai-khach-san-o-viet-nam-3.jpg",
                Header = "Thông tin homestay",
                Title = "Mức phí cách ly tại khách sạn, resort ở Việt Nam cho du khách có nhu cầu"
            });
            Discoveries.Add(new Discovery
            {
                HrefHeader = "homestay",
                HrefTitle = "?p=22798",
                ImagePath = "thu-do-ha-noi-4.png",
                Header = "Thông tin homestay",
                Title = "Thủ đô Hà Nội nằm trong danh sách những thành phố đẹp nhất thế giới"
            });
            Discoveries.Add(new Discovery
            {
                HrefHeader = "homestay",
                HrefTitle = "?p=22703",
                ImagePath = "cach-dat-phong-tai-da-lat-2.jpg",
                Header = "Thông tin homestay",
                Title = "Cách đặt phòng tại Đà Lạt cho chuyến du lịch tiết kiệm nhất"
            });
            Discoveries.Add(new Discovery
            {
                HrefHeader = "homestay",
                HrefTitle = "?p=22697",
                ImagePath = "lap-ke-hoach-tai-chinh-cho-chuyen-du-lich-3.jpg",
                Header = "Thông tin homestay",
                Title = "Cách lập kế hoạch tài chính cho chuyến du lịch hoàn hảo"
            });
        }
    }
}
