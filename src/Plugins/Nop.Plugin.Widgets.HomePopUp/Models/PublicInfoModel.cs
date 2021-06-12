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
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}