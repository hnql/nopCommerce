using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;
using System;

namespace Nop.Plugin.Widgets.DiscoverySuggestion.Models
{
    public record ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Headline")]
        public string Headline { get; set; }
        public bool Headline_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Description")]
        public string Description { get; set; }
        public bool Description_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Picture")]
        [UIHint("Picture")]
        public int Picture1Id { get; set; }
        public bool Picture1Id_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Title")]
        public string Title1 { get; set; }
        public bool Title1_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Header")]
        public string Header1 { get; set; }
        public bool Header1_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Link")]
        public string Link1 { get; set; }
        public bool Link1_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.AltText")]
        public string AltText1 { get; set; }
        public bool AltText1_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Picture")]
        [UIHint("Picture")]
        public int Picture2Id { get; set; }
        public bool Picture2Id_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Title")]
        public string Title2 { get; set; }
        public bool Title2_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Header")]
        public string Header2 { get; set; }
        public bool Header2_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Link")]
        public string Link2 { get; set; }
        public bool Link2_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.AltText")]
        public string AltText2 { get; set; }
        public bool AltText2_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Picture")]
        [UIHint("Picture")]
        public int Picture3Id { get; set; }
        public bool Picture3Id_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Title")]
        public string Title3 { get; set; }
        public bool Title3_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Header")]
        public string Header3 { get; set; }
        public bool Header3_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Link")]
        public string Link3 { get; set; }
        public bool Link3_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.AltText")]
        public string AltText3 { get; set; }
        public bool AltText3_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Picture")]
        [UIHint("Picture")]
        public int Picture4Id { get; set; }
        public bool Picture4Id_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Title")]
        public string Title4 { get; set; }
        public bool Title4_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Header")]
        public string Header4 { get; set; }
        public bool Header4_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Link")]
        public string Link4 { get; set; }
        public bool Link4_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.AltText")]
        public string AltText4 { get; set; }
        public bool AltText4_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Picture")]
        [UIHint("Picture")]
        public int Picture5Id { get; set; }
        public bool Picture5Id_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Title")]
        public string Title5 { get; set; }
        public bool Title5_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Header")]
        public string Header5 { get; set; }
        public bool Header5_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Link")]
        public string Link5 { get; set; }
        public bool Link5_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.AltText")]
        public string AltText5 { get; set; }
        public bool AltText5_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Picture")]
        [UIHint("Picture")]
        public int Picture6Id { get; set; }
        public bool Picture6Id_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Title")]
        public string Title6 { get; set; }
        public bool Title6_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Header")]
        public string Header6 { get; set; }
        public bool Header6_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Link")]
        public string Link6 { get; set; }
        public bool Link6_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.AltText")]
        public string AltText6 { get; set; }
        public bool AltText6_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Picture")]
        [UIHint("Picture")]
        public int Picture7Id { get; set; }
        public bool Picture7Id_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Title")]
        public string Title7 { get; set; }
        public bool Title7_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Header")]
        public string Header7 { get; set; }
        public bool Header7_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Link")]
        public string Link7 { get; set; }
        public bool Link7_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.AltText")]
        public string AltText7 { get; set; }
        public bool AltText7_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Picture")]
        [UIHint("Picture")]
        public int Picture8Id { get; set; }
        public bool Picture8Id_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Title")]
        public string Title8 { get; set; }
        public bool Title8_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Header")]
        public string Header8 { get; set; }
        public bool Header8_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.Link")]
        public string Link8 { get; set; }
        public bool Link8_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.DiscoverySuggestion.AltText")]
        public string AltText8 { get; set; }
        public bool AltText8_OverrideForStore { get; set; }
    }
}
