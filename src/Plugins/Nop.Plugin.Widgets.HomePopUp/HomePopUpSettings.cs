using System;
using Nop.Core.Configuration;

namespace Nop.Plugin.Widgets.HomePopUp
{
    class HomePopUpSettings : ISettings
    {
        public int Picture { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public bool Position { get; set; }
        public bool ShowDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
