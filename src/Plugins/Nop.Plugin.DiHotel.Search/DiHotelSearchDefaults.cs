using Nop.Core;

namespace Nop.Plugin.DiHotel.Search
{
    /// <summary>
    /// Represents plugin constants
    /// </summary>
    public static class DiHotelSearchDefaults
    {
        /// <summary>
        /// Gets a name of the view component to embed tracking script on pages
        /// </summary>
        public const string TRACKING_VIEW_COMPONENT_NAME = "WidgetsDiHotelSearch";

        /// <summary>
        /// Gets a plugin system name
        /// </summary>
        public static string SystemName => "DiHotel.Search";

        /// <summary>
        /// Gets a plugin partner name
        /// </summary>
        public static string PartnerName => "NOPCOMMERCE";

        /// <summary>
        /// Gets a user agent used to request Sendinblue services
        /// </summary>
        public static string UserAgent => $"nopCommerce-{NopVersion.CURRENT_VERSION}";

        public static string SearchRoute => "DiHotelProductSearch";
    }
}