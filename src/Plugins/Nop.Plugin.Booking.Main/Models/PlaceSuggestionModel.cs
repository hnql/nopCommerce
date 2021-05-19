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
        #region Properties

        public string Name { get; set; }

        public string ImageName { get; set; }

        public int Available { get; set; }

        #endregion

        public PlaceSuggestionModel()
        {
            ImageName = "location_1_1559734709.png";
            Available = 2915;
        }
    }
}
