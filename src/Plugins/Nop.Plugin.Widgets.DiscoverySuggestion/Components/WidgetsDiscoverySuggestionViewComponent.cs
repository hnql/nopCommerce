using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Plugin.Widgets.DiscoverySuggestion.Infrastructure.Cache;
using Nop.Plugin.Widgets.DiscoverySuggestion.Models;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.DiscoverySuggestion.Components
{
    [ViewComponent(Name = "WidgetsDiscoverySuggestion")]
    public class WidgetsDiscoverySuggestionViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ISettingService _settingService;
        private readonly IPictureService _pictureService;
        private readonly IWebHelper _webHelper;

        public WidgetsDiscoverySuggestionViewComponent(IStoreContext storeContext,
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
            var settings = await _settingService.LoadSettingAsync<DiscoverySuggestionSettings>((await _storeContext.GetCurrentStoreAsync()).Id);

            var model = new PublicInfoModel
            {
                Headline=settings.Headline,
                Description=settings.Description,

                Picture1Url = await GetPictureUrlAsync(settings.Picture1Id),
                Header1 = settings.Header1,
                Title1 = settings.Title1,
                Link1 = settings.Link1,
                AltText1 = settings.AltText1,

                Picture2Url = await GetPictureUrlAsync(settings.Picture2Id),
                Title2 = settings.Title2,
                Header2 = settings.Header2,
                Link2 = settings.Link2,
                AltText2 = settings.AltText2,

                Picture3Url = await GetPictureUrlAsync(settings.Picture3Id),
                Title3 = settings.Title3,
                Header3 = settings.Header3,
                Link3 = settings.Link3,
                AltText3 = settings.AltText3,

                Picture4Url = await GetPictureUrlAsync(settings.Picture4Id),
                Title4 = settings.Title4,
                Header4 = settings.Header4,
                Link4 = settings.Link4,
                AltText4 = settings.AltText4,

                Picture5Url = await GetPictureUrlAsync(settings.Picture5Id),
                Title5 = settings.Title5,
                Header5 = settings.Header5,
                Link5 = settings.Link5,
                AltText5 = settings.AltText5,

                Picture6Url = await GetPictureUrlAsync(settings.Picture6Id),
                Title6 = settings.Title6,
                Header6 = settings.Header6,
                Link6 = settings.Link6,
                AltText6 = settings.AltText6,

                Picture7Url = await GetPictureUrlAsync(settings.Picture7Id),
                Title7 = settings.Title7,
                Header7 = settings.Header7,
                Link7 = settings.Link7,
                AltText7 = settings.AltText7,

                Picture8Url = await GetPictureUrlAsync(settings.Picture8Id),
                Title8 = settings.Title8,
                Header8 = settings.Header8,
                Link8 = settings.Link8,
                AltText8 = settings.AltText8
            };

            if (string.IsNullOrEmpty(model.Picture1Url) && string.IsNullOrEmpty(model.Picture2Url) &&
                string.IsNullOrEmpty(model.Picture3Url) && string.IsNullOrEmpty(model.Picture4Url) &&
                string.IsNullOrEmpty(model.Picture5Url) && string.IsNullOrEmpty(model.Picture6Url) &&
                string.IsNullOrEmpty(model.Picture7Url) && string.IsNullOrEmpty(model.Picture8Url))
                //no pictures uploaded
                return Content("");

            return View("~/Plugins/Nop.Plugin.Widgets.DiscoverySuggestion/Views/PublicInfo.cshtml", model);
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
