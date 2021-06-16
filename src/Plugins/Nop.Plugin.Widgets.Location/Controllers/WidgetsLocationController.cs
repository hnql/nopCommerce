using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core;
using Nop.Core.Domain.Directory;
using Nop.Plugin.Booking.Main.Models;
using Nop.Plugin.Booking.Main.Services;
using Nop.Plugin.Widgets.Location.Models;
using Nop.Services.Configuration;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.Location.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    [AutoValidateAntiforgeryToken]
    public class WidgetsLocationController : BasePluginController
    {
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly IStateProvinceService _stateProvinceService;

        public WidgetsLocationController(
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService, 
            IPictureService pictureService,
            ISettingService settingService,
            IStoreContext storeContext,
            IStateProvinceService stateProvinceService)
        {
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _pictureService = pictureService;
            _settingService = settingService;
            _storeContext = storeContext;
            _stateProvinceService = stateProvinceService;
        }

        private List<SelectListItem> GetAvailableStateProvinces(List<StateProvince> stateProvinces, int stateProvinceId)
        {
            var availableStateProvinces = new List<SelectListItem>();

            //prepare available state province
            foreach (var stateProvince in stateProvinces)
            {
                if (stateProvince.Id == stateProvinceId)
                {
                    availableStateProvinces.Add(new SelectListItem(stateProvince.Name, stateProvince.Id.ToString(), true));
                }
                else
                {
                    availableStateProvinces.Add(new SelectListItem(stateProvince.Name, stateProvince.Id.ToString(), false));
                }
            }

            return availableStateProvinces;
        }

        public async Task<IActionResult> Configure()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();
            const int vietNamCountryId = 242;

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var locationSettings = await _settingService.LoadSettingAsync<LocationSettings>(storeScope);
            var stateProvinces = await _stateProvinceService.GetStateProvincesByCountryIdAsync(vietNamCountryId);
            var availableStateProvinces = new List<List<SelectListItem>> {
                GetAvailableStateProvinces(stateProvinces.ToList(), locationSettings.StateProvinceId1),
                GetAvailableStateProvinces(stateProvinces.ToList(), locationSettings.StateProvinceId2),
                GetAvailableStateProvinces(stateProvinces.ToList(), locationSettings.StateProvinceId3),
                GetAvailableStateProvinces(stateProvinces.ToList(), locationSettings.StateProvinceId4),
                GetAvailableStateProvinces(stateProvinces.ToList(), locationSettings.StateProvinceId5),
                GetAvailableStateProvinces(stateProvinces.ToList(), locationSettings.StateProvinceId6),
                GetAvailableStateProvinces(stateProvinces.ToList(), locationSettings.StateProvinceId7),
                GetAvailableStateProvinces(stateProvinces.ToList(), locationSettings.StateProvinceId8),
                GetAvailableStateProvinces(stateProvinces.ToList(), locationSettings.StateProvinceId9),
                GetAvailableStateProvinces(stateProvinces.ToList(), locationSettings.StateProvinceId10)
            };

            var model = new ConfigurationModel
            {
                Picture1Id = locationSettings.Picture1Id,
                Text1 = locationSettings.Text1,
                Link1 = locationSettings.Link1,
                AltText1 = locationSettings.AltText1,
                StateProvinceId1 = locationSettings.StateProvinceId1,
                AvailableStateProvinces1 = availableStateProvinces[0],

                Picture2Id = locationSettings.Picture2Id,
                Text2 = locationSettings.Text2,
                Link2 = locationSettings.Link2,
                AltText2 = locationSettings.AltText2,
                StateProvinceId2 = locationSettings.StateProvinceId2,
                AvailableStateProvinces2 = availableStateProvinces[1],

                Picture3Id = locationSettings.Picture3Id,
                Text3 = locationSettings.Text3,
                Link3 = locationSettings.Link3,
                AltText3 = locationSettings.AltText3,
                StateProvinceId3 = locationSettings.StateProvinceId3,
                AvailableStateProvinces3 = availableStateProvinces[2],

                Picture4Id = locationSettings.Picture4Id,
                Text4 = locationSettings.Text4,
                Link4 = locationSettings.Link4,
                AltText4 = locationSettings.AltText4,
                StateProvinceId4 = locationSettings.StateProvinceId4,
                AvailableStateProvinces4 = availableStateProvinces[3],

                Picture5Id = locationSettings.Picture5Id,
                Text5 = locationSettings.Text5,
                Link5 = locationSettings.Link5,
                AltText5 = locationSettings.AltText5,
                StateProvinceId5 = locationSettings.StateProvinceId5,
                AvailableStateProvinces5 = availableStateProvinces[4],

                Picture6Id = locationSettings.Picture6Id,
                Text6 = locationSettings.Text6,
                Link6 = locationSettings.Link6,
                AltText6 = locationSettings.AltText6,
                StateProvinceId6 = locationSettings.StateProvinceId6,
                AvailableStateProvinces6 = availableStateProvinces[5],

                Picture7Id = locationSettings.Picture7Id,
                Text7 = locationSettings.Text7,
                Link7 = locationSettings.Link7,
                AltText7 = locationSettings.AltText7,
                StateProvinceId7 = locationSettings.StateProvinceId7,
                AvailableStateProvinces7 = availableStateProvinces[6],

                Picture8Id = locationSettings.Picture8Id,
                Text8 = locationSettings.Text8,
                Link8 = locationSettings.Link8,
                AltText8 = locationSettings.AltText8,
                StateProvinceId8 = locationSettings.StateProvinceId8,
                AvailableStateProvinces8 = availableStateProvinces[7],

                Picture9Id = locationSettings.Picture9Id,
                Text9 = locationSettings.Text9,
                Link9 = locationSettings.Link9,
                AltText9 = locationSettings.AltText9,
                StateProvinceId9 = locationSettings.StateProvinceId9,
                AvailableStateProvinces9 = availableStateProvinces[8],

                Picture10Id = locationSettings.Picture5Id,
                Text10 = locationSettings.Text5,
                Link10 = locationSettings.Link5,
                AltText10 = locationSettings.AltText5,
                StateProvinceId10 = locationSettings.StateProvinceId10,
                AvailableStateProvinces10 = availableStateProvinces[9],

                ActiveStoreScopeConfiguration = storeScope
            };

            if (storeScope > 0)
            {
                model.Picture1Id_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Picture1Id, storeScope);
                model.Text1_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Text1, storeScope);
                model.Link1_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Link1, storeScope);
                model.AltText1_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.AltText1, storeScope);
                model.StateProvinceId1_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.StateProvinceId1, storeScope);

                model.Picture2Id_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Picture2Id, storeScope);
                model.Text2_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Text2, storeScope);
                model.Link2_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Link2, storeScope);
                model.AltText2_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.AltText2, storeScope);
                model.StateProvinceId2_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.StateProvinceId2, storeScope);

                model.Picture3Id_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Picture3Id, storeScope);
                model.Text3_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Text3, storeScope);
                model.Link3_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Link3, storeScope);
                model.AltText3_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.AltText3, storeScope);
                model.StateProvinceId3_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.StateProvinceId3, storeScope);

                model.Picture4Id_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Picture4Id, storeScope);
                model.Text4_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Text4, storeScope);
                model.Link4_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Link4, storeScope);
                model.AltText4_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.AltText4, storeScope);
                model.StateProvinceId4_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.StateProvinceId4, storeScope);

                model.Picture5Id_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Picture5Id, storeScope);
                model.Text5_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Text5, storeScope);
                model.Link5_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Link5, storeScope);
                model.AltText5_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.AltText5, storeScope);
                model.StateProvinceId5_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.StateProvinceId5, storeScope);

                model.Picture6Id_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Picture6Id, storeScope);
                model.Text6_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Text6, storeScope);
                model.Link6_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Link6, storeScope);
                model.AltText6_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.AltText6, storeScope);
                model.StateProvinceId6_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.StateProvinceId6, storeScope);

                model.Picture7Id_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Picture7Id, storeScope);
                model.Text7_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Text7, storeScope);
                model.Link7_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Link7, storeScope);
                model.AltText7_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.AltText7, storeScope);
                model.StateProvinceId7_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.StateProvinceId7, storeScope);

                model.Picture8Id_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Picture8Id, storeScope);
                model.Text8_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Text8, storeScope);
                model.Link8_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Link8, storeScope);
                model.AltText8_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.AltText8, storeScope);
                model.StateProvinceId8_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.StateProvinceId8, storeScope);

                model.Picture9Id_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Picture9Id, storeScope);
                model.Text9_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Text9, storeScope);
                model.Link9_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Link9, storeScope);
                model.AltText9_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.AltText9, storeScope);
                model.StateProvinceId9_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.StateProvinceId9, storeScope);

                model.Picture10Id_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Picture10Id, storeScope);
                model.Text10_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Text10, storeScope);
                model.Link10_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.Link10, storeScope);
                model.AltText10_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.AltText10, storeScope);
                model.StateProvinceId10_OverrideForStore = await _settingService.SettingExistsAsync(locationSettings, x => x.StateProvinceId10, storeScope);
            }

            return View("~/Plugins/Widgets.Location/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var locationSettings = await _settingService.LoadSettingAsync<LocationSettings>(storeScope);

            //get previous picture identifiers
            var previousPictureIds = new[] 
            {
                locationSettings.Picture1Id,
                locationSettings.Picture2Id,
                locationSettings.Picture3Id,
                locationSettings.Picture4Id,
                locationSettings.Picture5Id,
                locationSettings.Picture6Id,
                locationSettings.Picture7Id,
                locationSettings.Picture8Id,
                locationSettings.Picture9Id,
                locationSettings.Picture10Id
            };

            locationSettings.Picture1Id = model.Picture1Id;
            locationSettings.Text1 = model.Text1;
            locationSettings.Link1 = model.Link1;
            locationSettings.AltText1 = model.AltText1;
            locationSettings.StateProvinceId1 = model.StateProvinceId1;

            locationSettings.Picture2Id = model.Picture2Id;
            locationSettings.Text2 = model.Text2;
            locationSettings.Link2 = model.Link2;
            locationSettings.AltText2 = model.AltText2;
            locationSettings.StateProvinceId2 = model.StateProvinceId2;

            locationSettings.Picture3Id = model.Picture3Id;
            locationSettings.Text3 = model.Text3;
            locationSettings.Link3 = model.Link3;
            locationSettings.AltText3 = model.AltText3;
            locationSettings.StateProvinceId3 = model.StateProvinceId3;

            locationSettings.Picture4Id = model.Picture4Id;
            locationSettings.Text4 = model.Text4;
            locationSettings.Link4 = model.Link4;
            locationSettings.AltText4 = model.AltText4;
            locationSettings.StateProvinceId4 = model.StateProvinceId4;

            locationSettings.Picture5Id = model.Picture5Id;
            locationSettings.Text5 = model.Text5;
            locationSettings.Link5 = model.Link5;
            locationSettings.AltText5 = model.AltText5;
            locationSettings.StateProvinceId5 = model.StateProvinceId5;

            locationSettings.Picture6Id = model.Picture6Id;
            locationSettings.Text6 = model.Text6;
            locationSettings.Link6 = model.Link6;
            locationSettings.AltText6 = model.AltText6;
            locationSettings.StateProvinceId6 = model.StateProvinceId6;

            locationSettings.Picture7Id = model.Picture7Id;
            locationSettings.Text7 = model.Text7;
            locationSettings.Link7 = model.Link7;
            locationSettings.AltText7 = model.AltText7;
            locationSettings.StateProvinceId7 = model.StateProvinceId7;

            locationSettings.Picture8Id = model.Picture8Id;
            locationSettings.Text8 = model.Text8;
            locationSettings.Link8 = model.Link8;
            locationSettings.AltText8 = model.AltText8;
            locationSettings.StateProvinceId8 = model.StateProvinceId8;

            locationSettings.Picture9Id = model.Picture9Id;
            locationSettings.Text9 = model.Text9;
            locationSettings.Link9 = model.Link9;
            locationSettings.AltText9 = model.AltText9;
            locationSettings.StateProvinceId9 = model.StateProvinceId9;

            locationSettings.Picture10Id = model.Picture10Id;
            locationSettings.Text10 = model.Text10;
            locationSettings.Link10 = model.Link10;
            locationSettings.AltText10 = model.AltText10;
            locationSettings.StateProvinceId10 = model.StateProvinceId10;

            /* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.Picture1Id, model.Picture1Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.Text1, model.Text1_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.Link1, model.Link1_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.AltText1, model.AltText1_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.StateProvinceId1, model.StateProvinceId1_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.Picture2Id, model.Picture2Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.Text2, model.Text2_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.Link2, model.Link2_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.AltText2, model.AltText2_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.StateProvinceId2, model.StateProvinceId2_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.Picture3Id, model.Picture3Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.Text3, model.Text3_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.Link3, model.Link3_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.AltText3, model.AltText3_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.StateProvinceId3, model.StateProvinceId3_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.Picture4Id, model.Picture4Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.Text4, model.Text4_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.Link4, model.Link4_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.AltText4, model.AltText4_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.StateProvinceId4, model.StateProvinceId4_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.Picture5Id, model.Picture5Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.Text5, model.Text5_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.Link5, model.Link5_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.AltText5, model.AltText5_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(locationSettings, x => x.StateProvinceId5, model.StateProvinceId5_OverrideForStore, storeScope, false);

            //now clear settings cache
            await _settingService.ClearCacheAsync();
            
            //get current picture identifiers
            var currentPictureIds = new[]
            {
                locationSettings.Picture1Id,
                locationSettings.Picture2Id,
                locationSettings.Picture3Id,
                locationSettings.Picture4Id,
                locationSettings.Picture5Id,
                locationSettings.Picture6Id,
                locationSettings.Picture7Id,
                locationSettings.Picture8Id,
                locationSettings.Picture9Id,
                locationSettings.Picture10Id
            };

            //delete an old picture (if deleted or updated)
            foreach (var pictureId in previousPictureIds.Except(currentPictureIds))
            { 
                var previousPicture = await _pictureService.GetPictureByIdAsync(pictureId);
                if (previousPicture != null)
                    await _pictureService.DeletePictureAsync(previousPicture);
            }

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));
            
            return await Configure();
        }
    }
}