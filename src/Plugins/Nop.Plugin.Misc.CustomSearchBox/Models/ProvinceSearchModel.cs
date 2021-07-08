using Nop.Web.Framework.Models;

namespace Nop.Plugin.Misc.CustomSearchBox.Models
{
    public partial record ProvinceSearchModel : BaseNopModel
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int AvaiableLocation { get; set; }
    }
}
