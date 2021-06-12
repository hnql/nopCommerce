using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Plugin.Widgets.HomePopUp.Infrastructure.Cache;
using Nop.Plugin.Widgets.HomePopUp.Models;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.HomePopUp.Components
{
    [ViewComponent(Name = "WidgetsHomePopUp")]
    public class HomePopUpViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ISettingService _settingService;
        private readonly IPictureService _pictureService;
        private readonly IWebHelper _webHelper;

        public HomePopUpViewComponent(IStoreContext storeContext,
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
            var bookingHomeBannerSettings = await _settingService.LoadSettingAsync<HomePopUpSettings>((await _storeContext.GetCurrentStoreAsync()).Id);

            var model = new PublicInfoModel
            {
                PictureUrl = await GetPictureUrlAsync(bookingHomeBannerSettings.Picture),
                Text = bookingHomeBannerSettings.Text,
                Link = bookingHomeBannerSettings.Link,
                Position = bookingHomeBannerSettings.Position,
                FromDate = bookingHomeBannerSettings.FromDate,
                ToDate = bookingHomeBannerSettings.ToDate,
            };

            if (string.IsNullOrEmpty(model.Text))
                //no input text
                return Content("");

            return View("~/Plugins/Nop.Plugin.Widgets.HomePopUp/Views/PublicInfo.cshtml", model);
        }

        /// <returns>A task that represents the asynchronous operation</returns>
        protected async Task<string> GetPictureUrlAsync(int picture)
        {
            var cacheKey = _staticCacheManager.PrepareKeyForDefaultCache(ModelCacheEventConsumer.PICTURE_URL_MODEL_KEY,
                picture, _webHelper.IsCurrentConnectionSecured() ? Uri.UriSchemeHttps : Uri.UriSchemeHttp);

            return await _staticCacheManager.GetAsync(cacheKey, async () =>
            {
                //little hack here. nulls aren't cacheable so set it to ""
                var url = await _pictureService.GetPictureUrlAsync(picture, showDefaultPicture: false) ?? "";
                return url;
            });
        }
    }
}
