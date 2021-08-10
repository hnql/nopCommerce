using System;
using System.Collections.Generic;
using Nop.Core.Domain.Media;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Booking.Main.Models
{
    /// <summary>
    /// Represents a price range model
    /// </summary>
    public partial record IntroductionModel : BaseNopModel
    {

        #region Properties
        public string Title;
        public string Description;
        public string Header;
        public string Excerpt;

        #endregion

        public IntroductionModel() {
            Title = "Introduction about DiBooking";
            Description = "Introduction about DiBooking";
            Header = "TÌM KIẾM CHỖ Ở GIÁ TỐT NHẤT";
            Excerpt = "DiBooking hiện là nền tảng đặt phòng trực tuyến #1 Việt Nam. Đồng hành cùng chúng tôi, bạn có những chuyến đi mang đầy trải nghiệm. Với DiBooking, việc đặt chỗ ở, biệt thự nghỉ dưỡng, khách sạn, nhà riêng, chung cư... trở nên nhanh chóng, thuận tiện và dễ dàng.";
        }
    }
}
