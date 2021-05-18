using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Booking.Main.Factories;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Booking.Main.Components
{
    [ViewComponent(Name = BookingMainDefaults.TRACKING_VIEW_COMPONENT_NAME)]
    public class TestComponent : NopViewComponent
    {
        private readonly ITestModelFactory _testModelFactory;

        public TestComponent(ITestModelFactory testModelFactory)
        {
            _testModelFactory = testModelFactory;
        }

        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _testModelFactory.PrepareFeaturedLocationsProductsAsync();
            return View(model);
        }
    }
}
