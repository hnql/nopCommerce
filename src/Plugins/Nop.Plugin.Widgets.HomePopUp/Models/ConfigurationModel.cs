using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;
using System;

namespace Nop.Plugin.Widgets.HomePopUp.Models
{
    public record ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.HomePopUp.Picture")]
        [UIHint("Picture")]
        public int Picture { get; set; }
        public bool Picture_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.HomePopUp.Text")]
        public string Text { get; set; }
        public bool Text_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.HomePopUp.Link")]
        public string Link { get; set; }
        public bool Link_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.HomePopUp.Position")]
        public bool Position { get; set; }
        public bool Position_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.HomePopUp.ShowDate")]
        public bool ShowDate { get; set; }
        public bool ShowDate_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.HomePopUp.FromDate")]
        public DateTime FromDate { get; set; }
        public bool FromDate_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.HomePopUp.ToDate")]
        public DateTime ToDate { get; set; }
        public bool ToDate_OverrideForStore { get; set; }

    }
}
