using Nop.Web.Framework.Models;

namespace Nop.Plugin.Booking.Main.Models
{
    /// <summary>
    /// Represents a price range model
    /// </summary>
    public partial record DestinationModel : BaseNopModel 
    {

        public string VendorType { get; set; }
        public string PictureUrl { get; set; }
        public string StateProvince { get; set; }
        public string Excerpt { get; set; }

        public DestinationModel()
        {
            PictureUrl = "";
            StateProvince = "";
            VendorType = "";
            Excerpt = "";
        }
    }
}
