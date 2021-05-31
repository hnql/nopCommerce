using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Booking.DB.Factories;
using Nop.Web.Framework.Components;
using System;
using System.Threading.Tasks;

namespace Nop.Plugin.Booking.DB.Components
{
    public class SelectedCurrencyLanguageViewComponent : NopViewComponent
    {
        private readonly ICustomCommonModelFactory _customCommonModelFactory;

        public SelectedCurrencyLanguageViewComponent(ICustomCommonModelFactory customCommonModelFactory)
        {
            _customCommonModelFactory = customCommonModelFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _customCommonModelFactory.PrepareSelectedCurrencyLanguageModelAsync();
            if (model.SelectedCurrency == "" || model.SelectedLanguageCulture == "")
            {
                return Content("");
            }

            return View(model);
        }
    }
}
