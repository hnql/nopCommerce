using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Booking.Main.Factories;
using Nop.Web.Framework.Components;

namespace Nop.Web.Components
{
    public class IntroductionViewComponent : NopViewComponent
    {
        private readonly IHomeModelFactory _homeModelFactory;

        public IntroductionViewComponent(IHomeModelFactory homeModelFactory)
        {
            _homeModelFactory = homeModelFactory;
        }

        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _homeModelFactory.PrepareIntroductionModelAsync();
            return View(model);
        }
    }
}
