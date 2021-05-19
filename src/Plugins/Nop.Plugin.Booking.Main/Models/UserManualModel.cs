using System;
using System.Collections.Generic;
using Nop.Core.Domain.Media;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Booking.Main.Models
{
    /// <summary>
    /// Represents a price range model
    /// </summary>
    public partial record UserManualModel : BaseNopModel
    {
        public struct UserManual
        {
            public string Href;
            public string ImagePath;
        }

        #region Properties


        public IList<UserManual> UserManuals { get; set; }

        #endregion

        public UserManualModel() {
            UserManuals = new List<UserManual>();
            UserManuals.Add(new UserManual
            { 
                Href = "dat-phong-tren-luxstay.html", 
                ImagePath = "theme_3_1583838065.jpg"
            });
            UserManuals.Add(new UserManual
            {
                Href = "huong-dan-su-dung-ma-khuyen-mai.html",
                ImagePath = "theme_4_1583838088.jpg"
            });
            UserManuals.Add(new UserManual
            {
                Href = "huong-dan-thanh-toan-truc-tuyen.html",
                ImagePath = "theme_10_1583894021.jpg"
            });
            UserManuals.Add(new UserManual
            {
                Href = "huong-dan-thanh-toan-chuyen-khoan-ngan-hang.html",
                ImagePath = "theme_2_1583837926.jpg"
            });
            UserManuals.Add(new UserManual
            {
                Href = "/",
                ImagePath = "theme_1_1584074526.jpg"
            });
        }
    }
}
