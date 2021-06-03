using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Plugin.Widgets.BookingHomeBanner.Infrastructure.Cache;
using Nop.Plugin.Widgets.BookingHomeBanner.Models;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.BookingHomeBanner.Components
{
    [ViewComponent(Name = "WidgetsBookingHomeBanner")]
    public class WidgetsHomeBannerViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ISettingService _settingService;
        private readonly IPictureService _pictureService;
        private readonly IWebHelper _webHelper;

        public WidgetsHomeBannerViewComponent(IStoreContext storeContext, 
            IStaticCacheManager staticCacheManager, 
            ISettingService settingService, 
            IPictureService pictureService,
            IWebHelper webHelper)
        {
            _storeContext = storeContext;
            _staticCacheManager = staticCacheManager;
            _settingService = settingService;
            _pictureService = pictureService;
            _webHelper = webHelper;
        }

        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
        {
            var bookingHomeBannerSettings = await _settingService.LoadSettingAsync<BookingHomeBannerSettings>((await _storeContext.GetCurrentStoreAsync()).Id);

            var model = new PublicInfoModel
            {
                Picture1Url = await GetPictureUrlAsync(bookingHomeBannerSettings.Picture1Id),
                Text1 = bookingHomeBannerSettings.Text1,
                Link1 = bookingHomeBannerSettings.Link1,
                AltText1 = bookingHomeBannerSettings.AltText1,

                Picture2Url = await GetPictureUrlAsync(bookingHomeBannerSettings.Picture2Id),
                Text2 = bookingHomeBannerSettings.Text2,
                Link2 = bookingHomeBannerSettings.Link2,
                AltText2 = bookingHomeBannerSettings.AltText2,

                Picture3Url = await GetPictureUrlAsync(bookingHomeBannerSettings.Picture3Id),
                Text3 = bookingHomeBannerSettings.Text3,
                Link3 = bookingHomeBannerSettings.Link3,
                AltText3 = bookingHomeBannerSettings.AltText3,

                Picture4Url = await GetPictureUrlAsync(bookingHomeBannerSettings.Picture4Id),
                Text4 = bookingHomeBannerSettings.Text4,
                Link4 = bookingHomeBannerSettings.Link4,
                AltText4 = bookingHomeBannerSettings.AltText4,

                Picture5Url = await GetPictureUrlAsync(bookingHomeBannerSettings.Picture5Id),
                Text5 = bookingHomeBannerSettings.Text5,
                Link5 = bookingHomeBannerSettings.Link5,
                AltText5 = bookingHomeBannerSettings.AltText5
            };

            if (string.IsNullOrEmpty(model.Picture1Url) && string.IsNullOrEmpty(model.Picture2Url) &&
                string.IsNullOrEmpty(model.Picture3Url) && string.IsNullOrEmpty(model.Picture4Url) &&
                string.IsNullOrEmpty(model.Picture5Url))
                //no pictures uploaded
                return Content("");

            return View("~/Plugins/Widgets.BookingHomeBanner/Views/PublicInfo.cshtml", model);
        }

        /// <returns>A task that represents the asynchronous operation</returns>
        protected async Task<string> GetPictureUrlAsync(int pictureId)
        {
            var cacheKey = _staticCacheManager.PrepareKeyForDefaultCache(ModelCacheEventConsumer.PICTURE_URL_MODEL_KEY, 
                pictureId, _webHelper.IsCurrentConnectionSecured() ? Uri.UriSchemeHttps : Uri.UriSchemeHttp);

            return await _staticCacheManager.GetAsync(cacheKey, async () =>
            {
                //little hack here. nulls aren't cacheable so set it to ""
                var url = await _pictureService.GetPictureUrlAsync(pictureId, showDefaultPicture: false) ?? "";
                return url;
            });
        }
    }
}
