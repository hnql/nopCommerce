using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Booking.Main.Factories;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Misc.TDA.Booking.Components
{
    public class UserManualViewComponent : NopViewComponent
    {
        private readonly IHomeModelFactory _homeModelFactory;

        public UserManualViewComponent(IHomeModelFactory homeModelFactory)
        {
            _homeModelFactory = homeModelFactory;
        }

        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _homeModelFactory.PrepareUserManualModelAsync();
            return View(model);
        }
    }
}
