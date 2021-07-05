using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Plugin.Widgets.UserManual.Infrastructure.Cache;
using Nop.Plugin.Widgets.UserManual.Models;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.UserManual.Components
{
    [ViewComponent(Name = "WidgetsUserManual")]
    public class WidgetsUserManualViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ISettingService _settingService;
        private readonly IPictureService _pictureService;
        private readonly IWebHelper _webHelper;

        public WidgetsUserManualViewComponent(
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
            var userManualSettings = await _settingService.LoadSettingAsync<UserManualSettings>((await _storeContext.GetCurrentStoreAsync()).Id);

            var model = new PublicInfoModel
            {
                Picture1Url = await GetPictureUrlAsync(userManualSettings.Picture1Id),
                Text1 = userManualSettings.Text1,
                Link1 = userManualSettings.Link1,

                Picture2Url = await GetPictureUrlAsync(userManualSettings.Picture2Id),
                Text2 = userManualSettings.Text2,
                Link2 = userManualSettings.Link2,

                Picture3Url = await GetPictureUrlAsync(userManualSettings.Picture3Id),
                Text3 = userManualSettings.Text3,
                Link3 = userManualSettings.Link3,

                Picture4Url = await GetPictureUrlAsync(userManualSettings.Picture4Id),
                Text4 = userManualSettings.Text4,
                Link4 = userManualSettings.Link4,

                Picture5Url = await GetPictureUrlAsync(userManualSettings.Picture5Id),
                Text5 = userManualSettings.Text5,
                Link5 = userManualSettings.Link5,

                Picture6Url = await GetPictureUrlAsync(userManualSettings.Picture6Id),
                Text6 = userManualSettings.Text6,
                Link6 = userManualSettings.Link6,

                Picture7Url = await GetPictureUrlAsync(userManualSettings.Picture7Id),
                Text7 = userManualSettings.Text7,
                Link7 = userManualSettings.Link7,

                Picture8Url = await GetPictureUrlAsync(userManualSettings.Picture8Id),
                Text8 = userManualSettings.Text8,
                Link8 = userManualSettings.Link8,

                Picture9Url = await GetPictureUrlAsync(userManualSettings.Picture9Id),
                Text9 = userManualSettings.Text9,
                Link9 = userManualSettings.Link9,

                Picture10Url = await GetPictureUrlAsync(userManualSettings.Picture10Id),
                Text10 = userManualSettings.Text10,
                Link10 = userManualSettings.Link10
            };

            if (string.IsNullOrEmpty(model.Picture1Url) && string.IsNullOrEmpty(model.Picture2Url) &&
                string.IsNullOrEmpty(model.Picture3Url) && string.IsNullOrEmpty(model.Picture4Url) &&
                string.IsNullOrEmpty(model.Picture5Url) && string.IsNullOrEmpty(model.Picture6Url) &&
                string.IsNullOrEmpty(model.Picture7Url) && string.IsNullOrEmpty(model.Picture8Url) &&
                string.IsNullOrEmpty(model.Picture9Url) && string.IsNullOrEmpty(model.Picture10Url))
                //no pictures uploaded
                return Content("");

            return View("~/Plugins/Widgets.UserManual/Views/PublicInfo.cshtml", model);
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
