using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;
using System;

namespace Nop.Plugin.Widgets.DiscoverySuggestion.Models
{
    public record PublicInfoModel : BaseNopModel
    {
        public string Headline { get; set; }
        public string Description { get; set; }

        public string Picture1Url { get; set; }
        public string Title1 { get; set; }
        public string Header1 { get; set; }
        public string Link1 { get; set; }
        public string AltText1 { get; set; }

        public string Picture2Url { get; set; }
        public string Title2 { get; set; }
        public string Header2 {get; set;}
        public string Link2 { get; set; }
        public string AltText2 { get; set; }

        public string Picture3Url { get; set; }
        public string Title3 { get; set; }
        public string Header3 {get; set;}
        public string Link3 { get; set; }
        public string AltText3 { get; set; }

        public string Picture4Url { get; set; }
        public string Title4 { get; set; }
        public string Header4 {get; set;}
        public string Link4 { get; set; }
        public string AltText4 { get; set; }

        public string Picture5Url { get; set; }
        public string Title5 { get; set; }
        public string Header5 {get; set;}
        public string Link5 { get; set; }
        public string AltText5 { get; set; }

        public string Picture6Url { get; set; }
        public string Title6 { get; set; }
        public string Header6 {get; set;}
        public string Link6 { get; set; }
        public string AltText6 { get; set; }


        public string Picture7Url { get; set; }
        public string Title7 { get; set; }
        public string Header7 {get; set;}
        public string Link7 { get; set; }
        public string AltText7 { get; set; }

        public string Picture8Url { get; set; }
        public string Title8 { get; set; }
        public string Header8 {get; set;}
        public string Link8 { get; set; }
        public string AltText8 { get; set; }
    }
}
