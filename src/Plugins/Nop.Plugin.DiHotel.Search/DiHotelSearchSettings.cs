using Nop.Core.Configuration;

namespace Nop.Plugin.DiHotel.Search
{
    /// <summary>
    /// Represents settings of manual payment plugin
    /// </summary>
    public class DiHotelSearchSettings : ISettings
    {
        /// <summary>
        /// Gets or sets enable flag
        /// </summary>
        public bool Enabled { get; set; }
    }
}
