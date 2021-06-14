using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Directory;
using Nop.Plugin.Booking.Main.Services;
using Nop.Plugin.Widgets.Location.Infrastructure.Cache;
using Nop.Plugin.Widgets.Location.Models;
using Nop.Services.Configuration;
using Nop.Services.Directory;
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
        private readonly IStateProvinceService _stateProvinceService;
        private readonly IPlaceSuggestionService _placeSuggestionService;

        public WidgetsLocationViewComponent(
            IStoreContext storeContext, 
            IStaticCacheManager staticCacheManager, 
            ISettingService settingService, 
            IPictureService pictureService,
            IWebHelper webHelper,
            IPlaceSuggestionService placeSuggestionService,
            IStateProvinceService stateProvinceService)
        {
            _storeContext = storeContext;
            _staticCacheManager = staticCacheManager;
            _settingService = settingService;
            _pictureService = pictureService;
            _webHelper = webHelper;
            _stateProvinceService = stateProvinceService;
            _placeSuggestionService = placeSuggestionService;
        }

        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
        {
            var locationSettings = await _settingService.LoadSettingAsync<LocationSettings>((await _storeContext.GetCurrentStoreAsync()).Id);

            var stateProvinces = new List<StateProvince> {
                await _stateProvinceService.GetStateProvinceByIdAsync(locationSettings.StateProvinceId1),
                await _stateProvinceService.GetStateProvinceByIdAsync(locationSettings.StateProvinceId2),
                await _stateProvinceService.GetStateProvinceByIdAsync(locationSettings.StateProvinceId3),
                await _stateProvinceService.GetStateProvinceByIdAsync(locationSettings.StateProvinceId4),
                await _stateProvinceService.GetStateProvinceByIdAsync(locationSettings.StateProvinceId5),
                await _stateProvinceService.GetStateProvinceByIdAsync(locationSettings.StateProvinceId6),
                await _stateProvinceService.GetStateProvinceByIdAsync(locationSettings.StateProvinceId7),
                await _stateProvinceService.GetStateProvinceByIdAsync(locationSettings.StateProvinceId8),
                await _stateProvinceService.GetStateProvinceByIdAsync(locationSettings.StateProvinceId9),
                await _stateProvinceService.GetStateProvinceByIdAsync(locationSettings.StateProvinceId10)
            };

            var placeSuggestions = await _placeSuggestionService.GetPlaceSuggestionAsync();
            int[] available = new int[10];
            for (var i = 0; i < 10; i++)
            {
                available[i] = 0;
            }

            if (placeSuggestions.Count > 0)
            {
                for (var i = 0; i < 10; i++)
                {
                    var placeSuggestion1 = placeSuggestions.Where(pl => pl.Name.Equals(stateProvinces[i].Name)).FirstOrDefault();
                    available[i] = placeSuggestion1 != null ? placeSuggestion1.Available : 0;
                }
            }

            var model = new PublicInfoModel
            {
                Picture1Url = await GetPictureUrlAsync(locationSettings.Picture1Id),
                Text1 = locationSettings.Text1,
                Link1 = locationSettings.Link1,
                AltText1 = locationSettings.AltText1,
                StateProvince1 = stateProvinces[0].Name,
                Available1 = available[0],

                Picture2Url = await GetPictureUrlAsync(locationSettings.Picture2Id),
                Text2 = locationSettings.Text2,
                Link2 = locationSettings.Link2,
                AltText2 = locationSettings.AltText2,
                StateProvince2 = stateProvinces[1].Name,
                Available2 = available[1],

                Picture3Url = await GetPictureUrlAsync(locationSettings.Picture3Id),
                Text3 = locationSettings.Text3,
                Link3 = locationSettings.Link3,
                AltText3 = locationSettings.AltText3,
                StateProvince3 = stateProvinces[2].Name,
                Available3 = available[2],

                Picture4Url = await GetPictureUrlAsync(locationSettings.Picture4Id),
                Text4 = locationSettings.Text4,
                Link4 = locationSettings.Link4,
                AltText4 = locationSettings.AltText4,
                StateProvince4 = stateProvinces[3].Name,
                Available4 = available[3],

                Picture5Url = await GetPictureUrlAsync(locationSettings.Picture5Id),
                Text5 = locationSettings.Text5,
                Link5 = locationSettings.Link5,
                AltText5 = locationSettings.AltText5,
                StateProvince5 = stateProvinces[4].Name,
                Available5 = available[4],

                Picture6Url = await GetPictureUrlAsync(locationSettings.Picture6Id),
                Text6 = locationSettings.Text6,
                Link6 = locationSettings.Link6,
                AltText6 = locationSettings.AltText6,
                StateProvince6 = stateProvinces[5].Name,
                Available6 = available[5],

                Picture7Url = await GetPictureUrlAsync(locationSettings.Picture7Id),
                Text7 = locationSettings.Text7,
                Link7 = locationSettings.Link7,
                AltText7 = locationSettings.AltText7,
                StateProvince7 = stateProvinces[6].Name,
                Available7 = available[6],

                Picture8Url = await GetPictureUrlAsync(locationSettings.Picture8Id),
                Text8 = locationSettings.Text8,
                Link8 = locationSettings.Link8,
                AltText8 = locationSettings.AltText8,
                StateProvince8 = stateProvinces[7].Name,
                Available8 = available[7],

                Picture9Url = await GetPictureUrlAsync(locationSettings.Picture9Id),
                Text9 = locationSettings.Text9,
                Link9 = locationSettings.Link9,
                AltText9 = locationSettings.AltText9,
                StateProvince9 = stateProvinces[8].Name,
                Available9 = available[8],

                Picture10Url = await GetPictureUrlAsync(locationSettings.Picture10Id),
                Text10 = locationSettings.Text10,
                Link10 = locationSettings.Link10,
                AltText10 = locationSettings.AltText10,
                StateProvince10 = stateProvinces[9].Name,
                Available10 = available[9],
            };

            if (string.IsNullOrEmpty(model.Picture1Url) && string.IsNullOrEmpty(model.Picture2Url) &&
                string.IsNullOrEmpty(model.Picture3Url) && string.IsNullOrEmpty(model.Picture4Url) &&
                string.IsNullOrEmpty(model.Picture5Url) && string.IsNullOrEmpty(model.Picture6Url) &&
                string.IsNullOrEmpty(model.Picture7Url) && string.IsNullOrEmpty(model.Picture8Url) &&
                string.IsNullOrEmpty(model.Picture9Url) && string.IsNullOrEmpty(model.Picture10Url))
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
