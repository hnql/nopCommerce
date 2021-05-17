using System;
using System.Collections.Generic;
using Nop.Core.Domain.Media;
using Nop.Web.Framework.Models;

namespace Nop.Web.Models.Catalog
{
    /// <summary>
    /// Represents a price range model
    /// </summary>
    public partial record PlaceSuggestionModel : BaseNopModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the "from" price
        /// </summary>
        public IList<Picture> Pictures { get; set; }

        #endregion
    }
}
