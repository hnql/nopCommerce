using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Plugin.Widgets.Location.Infrastructure.Cache;
using Nop.Plugin.Widgets.Location.Models;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.Location.Components
{
    [ViewComponent(Name = "WidgetsLocation")]
    public class WidgetsLocationViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ISettingService _settingService;
        private readonly IPictureService _pictureService;
        private readonly IWebHelper _webHelper;

        public WidgetsLocationViewComponent(
            IStoreContext storeContext, 
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
            var locationSettings = await _settingService.LoadSettingAsync<LocationSettings>((await _storeContext.GetCurrentStoreAsync()).Id);

            var model = new PublicInfoModel
            {
                Picture1Url = await GetPictureUrlAsync(locationSettings.Picture1Id),
                Text1 = locationSettings.Text1,
                Link1 = locationSettings.Link1,
                AltText1 = locationSettings.AltText1,

                Picture2Url = await GetPictureUrlAsync(locationSettings.Picture2Id),
                Text2 = locationSettings.Text2,
                Link2 = locationSettings.Link2,
                AltText2 = locationSettings.AltText2,

                Picture3Url = await GetPictureUrlAsync(locationSettings.Picture3Id),
                Text3 = locationSettings.Text3,
                Link3 = locationSettings.Link3,
                AltText3 = locationSettings.AltText3,

                Picture4Url = await GetPictureUrlAsync(locationSettings.Picture4Id),
                Text4 = locationSettings.Text4,
                Link4 = locationSettings.Link4,
                AltText4 = locationSettings.AltText4,

                Picture5Url = await GetPictureUrlAsync(locationSettings.Picture5Id),
                Text5 = locationSettings.Text5,
                Link5 = locationSettings.Link5,
                AltText5 = locationSettings.AltText5
            };

            if (string.IsNullOrEmpty(model.Picture1Url) && string.IsNullOrEmpty(model.Picture2Url) &&
                string.IsNullOrEmpty(model.Picture3Url) && string.IsNullOrEmpty(model.Picture4Url) &&
                string.IsNullOrEmpty(model.Picture5Url))
                //no pictures uploaded
                return Content("");

            return View("~/Plugins/Widgets.Location/Views/PublicInfo.cshtml", model);
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
