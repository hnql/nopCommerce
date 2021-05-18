using System;
using System.Collections.Generic;
using Nop.Core.Domain.Media;
using Nop.Web.Framework.Models;

namespace Nop.Web.Models.Catalog
{
    /// <summary>
    /// Represents a price range model
    /// </summary>
    public partial record BannerModel : BaseNopModel
    {

        public IList<string> ImagePaths;

        public BannerModel() {
            ImagePaths = new List<string>();
            ImagePaths.Add("banner_slide_1.png");
            ImagePaths.Add("banner_slide_2.png");
            ImagePaths.Add("banner_slide_3.png");
        }
    }
}
