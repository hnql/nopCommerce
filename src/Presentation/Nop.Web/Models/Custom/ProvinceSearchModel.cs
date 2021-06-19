using Nop.Web.Framework.Models;

namespace Nop.Web.Models.Custom
{
    public partial record ProvinceSearchModel : BaseNopModel
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int AvaiableLocation { get; set; }
    }
}
