using System;
using System.Collections.Generic;
using Nop.Core.Domain.Media;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Booking.Main.Models
{
    /// <summary>
    /// Represents a price range model
    /// </summary>
    public partial record PlaceSuggestionModel : BaseNopModel
    {
        public struct PlaceSuggestion
        {
            public string AltAttribute;
            public string TitleAttribute;
            public string ImagePath;
        }

        #region Properties

        /// <summary>
        /// Gets or sets the "from" price
        /// </summary>
        public IList<PlaceSuggestion> PlaceSuggestions { get; set; }

        #endregion

        public PlaceSuggestionModel()
        {
            PlaceSuggestions = new List<PlaceSuggestion>();
            PlaceSuggestions.Add(new PlaceSuggestion
            {
                AltAttribute = "ha-noi",
                TitleAttribute = "Ha Noi",
                ImagePath = "location_1_1559734709.png"
            });
            PlaceSuggestions.Add(new PlaceSuggestion
            {
                AltAttribute = "ho-chi-minh",
                TitleAttribute = "TP. Ho Chi Minh",
                ImagePath = "location_5_1559735011.png"
            });
            PlaceSuggestions.Add(new PlaceSuggestion
            {
                AltAttribute = "vung-tau",
                TitleAttribute = "Vung Tau",
                ImagePath = "location_10_1559303118.png"
            });
            PlaceSuggestions.Add(new PlaceSuggestion
            {
                AltAttribute = "da-lat",
                TitleAttribute = "Da Lat",
                ImagePath = "location_4_1559786177.png"
            });
            PlaceSuggestions.Add(new PlaceSuggestion
            {
                AltAttribute = "da-nang",
                TitleAttribute = "Da Nang",
                ImagePath = "location_16_1559303173.png"
            });
            PlaceSuggestions.Add(new PlaceSuggestion
            {
                AltAttribute = "nha-trang",
                TitleAttribute = "Nha Trang",
                ImagePath = "location_1_1559373089.png"
            });
            PlaceSuggestions.Add(new PlaceSuggestion
            {
                AltAttribute = "quang-ninh",
                TitleAttribute = "Quang Ninh",
                ImagePath = "location_5_1559786196.png"
            });
            PlaceSuggestions.Add(new PlaceSuggestion
            {
                AltAttribute = "hoi-an",
                TitleAttribute = "Hoi An",
                ImagePath = "location_6_1559786202.png"
            });
        }
    }
}
