using System;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.HomePopUp.Models
{
    public record PublicInfoModel : BaseNopModel
    {
        public string PictureUrl { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public bool Position { get; set; }
        public bool ShowDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}