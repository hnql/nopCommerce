using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;
using Nop.Plugin.Booking.Main.Models;

namespace Nop.Plugin.Widgets.Location.Models
{
    public record ConfigurationModel : BaseNopModel
    {
        #region Ctor

        public ConfigurationModel()
        {
            AvailableStateProvinces1 = new List<SelectListItem>();
            AvailableStateProvinces2 = new List<SelectListItem>();
            AvailableStateProvinces3 = new List<SelectListItem>();
            AvailableStateProvinces4 = new List<SelectListItem>();
            AvailableStateProvinces5 = new List<SelectListItem>();
            AvailableStateProvinces6 = new List<SelectListItem>();
            AvailableStateProvinces7 = new List<SelectListItem>();
            AvailableStateProvinces8 = new List<SelectListItem>();
            AvailableStateProvinces9 = new List<SelectListItem>();
            AvailableStateProvinces10 = new List<SelectListItem>();
        }

        #endregion

        public int ActiveStoreScopeConfiguration { get; set; }
        

        [NopResourceDisplayName("Plugins.Widgets.Location.Picture")]
        [UIHint("Picture")]
        public int Picture1Id { get; set; }
        public bool Picture1Id_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.Text")]
        public string Text1 { get; set; }
        public bool Text1_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.Link")]
        public string Link1 { get; set; }
        public bool Link1_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.AltText")]
        public string AltText1 { get; set; }
        public bool AltText1_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.StateProvince")]
        public int StateProvinceId1 { get; set; }
        public bool StateProvinceId1_OverrideForStore { get; set; }

        public List<SelectListItem> AvailableStateProvinces1 { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.Location.Picture")]
        [UIHint("Picture")]
        public int Picture2Id { get; set; }
        public bool Picture2Id_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.Text")]
        public string Text2 { get; set; }
        public bool Text2_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.Link")]
        public string Link2 { get; set; }
        public bool Link2_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.AltText")]
        public string AltText2 { get; set; }
        public bool AltText2_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.StateProvince")]
        public int StateProvinceId2 { get; set; }
        public bool StateProvinceId2_OverrideForStore { get; set; }

        public List<SelectListItem> AvailableStateProvinces2 { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.Location.Picture")]
        [UIHint("Picture")]
        public int Picture3Id { get; set; }
        public bool Picture3Id_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.Text")]
        public string Text3 { get; set; }
        public bool Text3_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.Link")]
        public string Link3 { get; set; }
        public bool Link3_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.AltText")]
        public string AltText3 { get; set; }
        public bool AltText3_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.StateProvince")]
        public int StateProvinceId3 { get; set; }
        public bool StateProvinceId3_OverrideForStore { get; set; }

        public List<SelectListItem> AvailableStateProvinces3 { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.Location.Picture")]
        [UIHint("Picture")]
        public int Picture4Id { get; set; }
        public bool Picture4Id_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.Text")]
        public string Text4 { get; set; }
        public bool Text4_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.Link")]
        public string Link4 { get; set; }
        public bool Link4_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.AltText")]
        public string AltText4 { get; set; }
        public bool AltText4_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.StateProvince")]
        public int StateProvinceId4 { get; set; }
        public bool StateProvinceId4_OverrideForStore { get; set; }

        public List<SelectListItem> AvailableStateProvinces4 { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.Location.Picture")]
        [UIHint("Picture")]
        public int Picture5Id { get; set; }
        public bool Picture5Id_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.Text")]
        public string Text5 { get; set; }
        public bool Text5_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.Link")]
        public string Link5 { get; set; }
        public bool Link5_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.AltText")]
        public string AltText5 { get; set; }
        public bool AltText5_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.StateProvince")]
        public int StateProvinceId5 { get; set; }
        public bool StateProvinceId5_OverrideForStore { get; set; }

        public List<SelectListItem> AvailableStateProvinces5 { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.Location.Picture")]
        [UIHint("Picture")]
        public int Picture6Id { get; set; }
        public bool Picture6Id_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.Text")]
        public string Text6 { get; set; }
        public bool Text6_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.Link")]
        public string Link6 { get; set; }
        public bool Link6_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.AltText")]
        public string AltText6 { get; set; }
        public bool AltText6_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.StateProvince")]
        public int StateProvinceId6 { get; set; }
        public bool StateProvinceId6_OverrideForStore { get; set; }

        public List<SelectListItem> AvailableStateProvinces6 { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.Location.Picture")]
        [UIHint("Picture")]
        public int Picture7Id { get; set; }
        public bool Picture7Id_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.Text")]
        public string Text7 { get; set; }
        public bool Text7_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.Link")]
        public string Link7 { get; set; }
        public bool Link7_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.AltText")]
        public string AltText7 { get; set; }
        public bool AltText7_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.StateProvince")]
        public int StateProvinceId7 { get; set; }
        public bool StateProvinceId7_OverrideForStore { get; set; }

        public List<SelectListItem> AvailableStateProvinces7 { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.Location.Picture")]
        [UIHint("Picture")]
        public int Picture8Id { get; set; }
        public bool Picture8Id_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.Text")]
        public string Text8 { get; set; }
        public bool Text8_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.Link")]
        public string Link8 { get; set; }
        public bool Link8_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.AltText")]
        public string AltText8 { get; set; }
        public bool AltText8_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.StateProvince")]
        public int StateProvinceId8 { get; set; }
        public bool StateProvinceId8_OverrideForStore { get; set; }

        public List<SelectListItem> AvailableStateProvinces8 { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.Location.Picture")]
        [UIHint("Picture")]
        public int Picture9Id { get; set; }
        public bool Picture9Id_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.Text")]
        public string Text9 { get; set; }
        public bool Text9_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.Link")]
        public string Link9 { get; set; }
        public bool Link9_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.AltText")]
        public string AltText9 { get; set; }
        public bool AltText9_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.StateProvince")]
        public int StateProvinceId9 { get; set; }
        public bool StateProvinceId9_OverrideForStore { get; set; }

        public List<SelectListItem> AvailableStateProvinces9 { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.Location.Picture")]
        [UIHint("Picture")]
        public int Picture10Id { get; set; }
        public bool Picture10Id_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.Text")]
        public string Text10 { get; set; }
        public bool Text10_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.Link")]
        public string Link10 { get; set; }
        public bool Link10_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.AltText")]
        public string AltText10 { get; set; }
        public bool AltText10_OverrideForStore { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.Location.StateProvince")]
        public int StateProvinceId10 { get; set; }
        public bool StateProvinceId10_OverrideForStore { get; set; }

        public List<SelectListItem> AvailableStateProvinces10 { get; set; }
    }
}