using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Booking.Main.Factories;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Misc.TDA.Booking.Components
{
    [ViewComponent(Name = "Banner")]
    public class BannerViewComponent : NopViewComponent
    {
        private readonly IHomeModelFactory _homeModelFactory;

        public BannerViewComponent(IHomeModelFactory homeModelFactory)
        {
            _homeModelFactory = homeModelFactory;
        }

        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _homeModelFactory.PrepareBannerModelAsync();
            return View(model);
        }
    }
}
