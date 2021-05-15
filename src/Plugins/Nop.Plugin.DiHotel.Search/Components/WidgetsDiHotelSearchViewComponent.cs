using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Customers;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.DiHotel.Search.Components
{
    /// <summary>
    /// Represents view component to embed tracking script on pages
    /// </summary>
    [ViewComponent(Name = DiHotelSearchDefaults.TRACKING_VIEW_COMPONENT_NAME)]
    public class WidgetsDiHotelSearchViewComponent : NopViewComponent
    {
        #region Fields

        private readonly ICustomerService _customerService;
        private readonly IWorkContext _workContext;
        private readonly DiHotelSearchSettings _diHotelSearchSettings;

        #endregion

        #region Ctor

        public WidgetsDiHotelSearchViewComponent(ICustomerService customerService,
            IWorkContext workContext,
            DiHotelSearchSettings diHotelSearchSettings)
        {
            _customerService = customerService;
            _workContext = workContext;
            _diHotelSearchSettings = diHotelSearchSettings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoke view component
        /// </summary>
        /// <param name="widgetZone">Widget zone name</param>
        /// <param name="additionalData">Additional data</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the view component result
        /// </returns>
        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
        {
            var trackingScript = string.Empty;

            return await Task.FromResult(View("~/Plugins/DiHotel.Search/Views/PublicInfo.cshtml", trackingScript));
        }

        #endregion
    }
}