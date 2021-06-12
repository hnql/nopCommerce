using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.HomePopUp.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.HomePopUp.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    [AutoValidateAntiforgeryToken]
    public class WidgetsHomePopUpController : BasePluginController
    {
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;

        public WidgetsHomePopUpController(ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IPictureService pictureService,
            ISettingService settingService,
            IStoreContext storeContext)
        {
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _pictureService = pictureService;
            _settingService = settingService;
            _storeContext = storeContext;
        }

        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        public async Task<IActionResult> Configure()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var homePopUpSettings = await _settingService.LoadSettingAsync<HomePopUpSettings>(storeScope);
            var model = new ConfigurationModel
            {
                Picture = homePopUpSettings.Picture,
                Text = homePopUpSettings.Text,
                Link = homePopUpSettings.Link,
                Position = homePopUpSettings.Position,
                FromDate = homePopUpSettings.FromDate,
                ToDate = homePopUpSettings.ToDate,
                ActiveStoreScopeConfiguration = storeScope
            };

            if (storeScope > 0)
            {
                model.Picture_OverrideForStore = await _settingService.SettingExistsAsync(homePopUpSettings, x => x.Picture, storeScope);
                model.Text_OverrideForStore = await _settingService.SettingExistsAsync(homePopUpSettings, x => x.Text, storeScope);
                model.Link_OverrideForStore = await _settingService.SettingExistsAsync(homePopUpSettings, x => x.Link, storeScope);
                model.Position_OverrideForStore = await _settingService.SettingExistsAsync(homePopUpSettings, x => x.Position, storeScope);
                model.FromDate_OverrideForStore = await _settingService.SettingExistsAsync(homePopUpSettings, x => x.FromDate, storeScope);
                model.ToDate_OverrideForStore = await _settingService.SettingExistsAsync(homePopUpSettings, x => x.ToDate, storeScope);
            }

            return View("~/Plugins/Nop.Plugin.Widgets.HomePopUp/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var homePopUpSettings = await _settingService.LoadSettingAsync<HomePopUpSettings>(storeScope);

            //get previous picture identifiers
            var previousPictureId = homePopUpSettings.Picture;

            homePopUpSettings.Picture = model.Picture;
            homePopUpSettings.Text = model.Text;
            homePopUpSettings.Link = model.Link;
            homePopUpSettings.Position = model.Position;
            homePopUpSettings.FromDate = model.FromDate;
            homePopUpSettings.ToDate = model.ToDate;

            /* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
            await _settingService.SaveSettingOverridablePerStoreAsync(homePopUpSettings, x => x.Picture, model.Picture_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(homePopUpSettings, x => x.Text, model.Text_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(homePopUpSettings, x => x.Link, model.Link_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(homePopUpSettings, x => x.Position, model.Position_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(homePopUpSettings, x => x.FromDate, model.FromDate_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(homePopUpSettings, x => x.ToDate, model.ToDate_OverrideForStore, storeScope, false);

            //now clear settings cache
            await _settingService.ClearCacheAsync();

            //get current picture identifiers
            var currentPictureId = homePopUpSettings.Picture;

            //delete an old picture (if deleted or updated)
            if (currentPictureId != previousPictureId)
            {
                var previousPicture = await _pictureService.GetPictureByIdAsync(previousPictureId);
                if (previousPicture != null)
                    await _pictureService.DeletePictureAsync(previousPicture);
            }

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));

            return await Configure();
        }
    }
}
