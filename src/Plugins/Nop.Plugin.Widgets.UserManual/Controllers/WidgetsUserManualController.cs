using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.UserManual.Models;
using Nop.Services.Configuration;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.UserManual.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    [AutoValidateAntiforgeryToken]
    public class WidgetsUserManualController : BasePluginController
    {
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly IStateProvinceService _stateProvinceService;

        public WidgetsUserManualController(
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

        public async Task<IActionResult> Configure()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var userManualSettings = await _settingService.LoadSettingAsync<UserManualSettings>(storeScope);

            var model = new ConfigurationModel
            {
                Picture1Id = userManualSettings.Picture1Id,
                Text1 = userManualSettings.Text1,
                Link1 = userManualSettings.Link1,

                Picture2Id = userManualSettings.Picture2Id,
                Text2 = userManualSettings.Text2,
                Link2 = userManualSettings.Link2,

                Picture3Id = userManualSettings.Picture3Id,
                Text3 = userManualSettings.Text3,
                Link3 = userManualSettings.Link3,

                Picture4Id = userManualSettings.Picture4Id,
                Text4 = userManualSettings.Text4,
                Link4 = userManualSettings.Link4,

                Picture5Id = userManualSettings.Picture5Id,
                Text5 = userManualSettings.Text5,
                Link5 = userManualSettings.Link5,

                Picture6Id = userManualSettings.Picture6Id,
                Text6 = userManualSettings.Text6,
                Link6 = userManualSettings.Link6,

                Picture7Id = userManualSettings.Picture7Id,
                Text7 = userManualSettings.Text7,
                Link7 = userManualSettings.Link7,

                Picture8Id = userManualSettings.Picture8Id,
                Text8 = userManualSettings.Text8,
                Link8 = userManualSettings.Link8,

                Picture9Id = userManualSettings.Picture9Id,
                Text9 = userManualSettings.Text9,
                Link9 = userManualSettings.Link9,

                Picture10Id = userManualSettings.Picture5Id,
                Text10 = userManualSettings.Text5,
                Link10 = userManualSettings.Link5,

                ActiveStoreScopeConfiguration = storeScope
            };

            if (storeScope > 0)
            {
                model.Picture1Id_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Picture1Id, storeScope);
                model.Text1_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Text1, storeScope);
                model.Link1_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Link1, storeScope);

                model.Picture2Id_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Picture2Id, storeScope);
                model.Text2_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Text2, storeScope);
                model.Link2_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Link2, storeScope);

                model.Picture3Id_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Picture3Id, storeScope);
                model.Text3_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Text3, storeScope);
                model.Link3_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Link3, storeScope);

                model.Picture4Id_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Picture4Id, storeScope);
                model.Text4_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Text4, storeScope);
                model.Link4_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Link4, storeScope);

                model.Picture5Id_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Picture5Id, storeScope);
                model.Text5_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Text5, storeScope);
                model.Link5_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Link5, storeScope);

                model.Picture6Id_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Picture6Id, storeScope);
                model.Text6_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Text6, storeScope);
                model.Link6_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Link6, storeScope);

                model.Picture7Id_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Picture7Id, storeScope);
                model.Text7_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Text7, storeScope);
                model.Link7_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Link7, storeScope);

                model.Picture8Id_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Picture8Id, storeScope);
                model.Text8_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Text8, storeScope);
                model.Link8_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Link8, storeScope);

                model.Picture9Id_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Picture9Id, storeScope);
                model.Text9_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Text9, storeScope);
                model.Link9_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Link9, storeScope);

                model.Picture10Id_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Picture10Id, storeScope);
                model.Text10_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Text10, storeScope);
                model.Link10_OverrideForStore = await _settingService.SettingExistsAsync(userManualSettings, x => x.Link10, storeScope);
            }

            return View("~/Plugins/Widgets.UserManual/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var userManualSettings = await _settingService.LoadSettingAsync<UserManualSettings>(storeScope);

            //get previous picture identifiers
            var previousPictureIds = new[] 
            {
                userManualSettings.Picture1Id,
                userManualSettings.Picture2Id,
                userManualSettings.Picture3Id,
                userManualSettings.Picture4Id,
                userManualSettings.Picture5Id,
                userManualSettings.Picture6Id,
                userManualSettings.Picture7Id,
                userManualSettings.Picture8Id,
                userManualSettings.Picture9Id,
                userManualSettings.Picture10Id
            };

            userManualSettings.Picture1Id = model.Picture1Id;
            userManualSettings.Text1 = model.Text1;
            userManualSettings.Link1 = model.Link1;

            userManualSettings.Picture2Id = model.Picture2Id;
            userManualSettings.Text2 = model.Text2;
            userManualSettings.Link2 = model.Link2;

            userManualSettings.Picture3Id = model.Picture3Id;
            userManualSettings.Text3 = model.Text3;
            userManualSettings.Link3 = model.Link3;

            userManualSettings.Picture4Id = model.Picture4Id;
            userManualSettings.Text4 = model.Text4;
            userManualSettings.Link4 = model.Link4;

            userManualSettings.Picture5Id = model.Picture5Id;
            userManualSettings.Text5 = model.Text5;
            userManualSettings.Link5 = model.Link5;

            userManualSettings.Picture6Id = model.Picture6Id;
            userManualSettings.Text6 = model.Text6;
            userManualSettings.Link6 = model.Link6;

            userManualSettings.Picture7Id = model.Picture7Id;
            userManualSettings.Text7 = model.Text7;
            userManualSettings.Link7 = model.Link7;

            userManualSettings.Picture8Id = model.Picture8Id;
            userManualSettings.Text8 = model.Text8;
            userManualSettings.Link8 = model.Link8;

            userManualSettings.Picture9Id = model.Picture9Id;
            userManualSettings.Text9 = model.Text9;
            userManualSettings.Link9 = model.Link9;

            userManualSettings.Picture10Id = model.Picture10Id;
            userManualSettings.Text10 = model.Text10;
            userManualSettings.Link10 = model.Link10;

            /* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Picture1Id, model.Picture1Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Text1, model.Text1_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Link1, model.Link1_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Picture2Id, model.Picture2Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Text2, model.Text2_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Link2, model.Link2_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Picture3Id, model.Picture3Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Text3, model.Text3_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Link3, model.Link3_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Picture4Id, model.Picture4Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Text4, model.Text4_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Link4, model.Link4_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Picture5Id, model.Picture5Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Text5, model.Text5_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Link5, model.Link5_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Picture6Id, model.Picture6Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Text6, model.Text6_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Link6, model.Link6_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Picture7Id, model.Picture7Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Text7, model.Text7_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Link7, model.Link7_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Picture8Id, model.Picture8Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Text8, model.Text8_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Link8, model.Link8_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Picture9Id, model.Picture9Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Text9, model.Text9_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Link9, model.Link9_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Picture10Id, model.Picture10Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Text10, model.Text10_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(userManualSettings, x => x.Link10, model.Link10_OverrideForStore, storeScope, false);

            //now clear settings cache
            await _settingService.ClearCacheAsync();
            
            //get current picture identifiers
            var currentPictureIds = new[]
            {
                userManualSettings.Picture1Id,
                userManualSettings.Picture2Id,
                userManualSettings.Picture3Id,
                userManualSettings.Picture4Id,
                userManualSettings.Picture5Id,
                userManualSettings.Picture6Id,
                userManualSettings.Picture7Id,
                userManualSettings.Picture8Id,
                userManualSettings.Picture9Id,
                userManualSettings.Picture10Id
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