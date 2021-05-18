using System;
using System.Collections.Generic;
using Nop.Core.Domain.Media;
using Nop.Web.Framework.Models;

namespace Nop.Web.Models.Catalog
{
    /// <summary>
    /// Represents a price range model
    /// </summary>
    public partial record PromotionModel : BaseNopModel
    {
        public struct Promotion
        {
            public int Id;
            public string ImagePath;
        }

        #region Properties


        public IList<Promotion> Promotions { get; set; }

        #endregion

        public PromotionModel() {
            Promotions = new List<Promotion>();
            Promotions.Add(new Promotion { Id = 44203, ImagePath = "event_6_1619804014.jpg" });
            Promotions.Add(new Promotion { Id = 44219, ImagePath = "event_1_1619803807.jpg" });
            Promotions.Add(new Promotion { Id = 44191, ImagePath = "event_1_1614658965.jpg" });
            Promotions.Add(new Promotion { Id = 44087, ImagePath = "event_1_1596604498.jpg" });
        }
    }
}
