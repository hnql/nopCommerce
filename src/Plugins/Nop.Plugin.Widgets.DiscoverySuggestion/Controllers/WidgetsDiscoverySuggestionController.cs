using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.DiscoverySuggestion.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.DiscoverySuggestion.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    [AutoValidateAntiforgeryToken]
    public class WidgetsDiscoverySuggestionController : BasePluginController
    {
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;

        public WidgetsDiscoverySuggestionController(ILocalizationService localizationService,
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

        [HttpGet]
        public async Task<IActionResult> Configure()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var settings = await _settingService.LoadSettingAsync<DiscoverySuggestionSettings>(storeScope);
            var model = new ConfigurationModel
            {
                Headline = settings.Headline,
                Description = settings.Description,

                Picture1Id = settings.Picture1Id,
                Header1 = settings.Header1,
                Title1 = settings.Title1,
                Link1 = settings.Link1,
                AltText1 = settings.AltText1,

                Picture2Id = settings.Picture2Id,
                Title2 = settings.Title2,
                Header2 = settings.Header2,
                Link2 = settings.Link2,
                AltText2 = settings.AltText2,

                Picture3Id = settings.Picture3Id,
                Title3 = settings.Title3,
                Header3 = settings.Header3,
                Link3 = settings.Link3,
                AltText3 = settings.AltText3,

                Picture4Id = settings.Picture4Id,
                Title4 = settings.Title4,
                Header4 = settings.Header4,
                Link4 = settings.Link4,
                AltText4 = settings.AltText4,

                Picture5Id = settings.Picture5Id,
                Title5 = settings.Title5,
                Header5 = settings.Header5,
                Link5 = settings.Link5,
                AltText5 = settings.AltText5,

                Picture6Id = settings.Picture6Id,
                Title6 = settings.Title6,
                Header6 = settings.Header6,
                Link6 = settings.Link6,
                AltText6 = settings.AltText6,

                Picture7Id = settings.Picture7Id,
                Title7 = settings.Title7,
                Header7 = settings.Header7,
                Link7 = settings.Link7,
                AltText7 = settings.AltText7,

                Picture8Id = settings.Picture8Id,
                Title8 = settings.Title8,
                Header8 = settings.Header8,
                Link8 = settings.Link8,
                AltText8 = settings.AltText8,

                ActiveStoreScopeConfiguration = storeScope
            };

            if (storeScope > 0)
            {
                model.Headline_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Headline, storeScope);
                model.Description_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Description, storeScope);

                model.Picture1Id_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Picture1Id, storeScope);
                model.Title1_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Title1, storeScope);
                model.Header1_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Header1, storeScope);
                model.Link1_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Link1, storeScope);
                model.AltText1_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.AltText1, storeScope);

                model.Picture2Id_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Picture2Id, storeScope);
                model.Title2_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Title2, storeScope);
                model.Header2_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Header2, storeScope);
                model.Link2_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Link2, storeScope);
                model.AltText2_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.AltText2, storeScope);

                model.Picture3Id_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Picture3Id, storeScope);
                model.Title3_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Title3, storeScope);
                model.Header3_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Header3, storeScope);
                model.Link3_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Link3, storeScope);
                model.AltText3_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.AltText3, storeScope);

                model.Picture4Id_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Picture4Id, storeScope);
                model.Title4_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Title4, storeScope);
                model.Header4_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Header4, storeScope);
                model.Link4_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Link4, storeScope);
                model.AltText4_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.AltText4, storeScope);

                model.Picture5Id_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Picture5Id, storeScope);
                model.Title5_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Title5, storeScope);
                model.Header5_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Header5, storeScope);
                model.Link5_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Link5, storeScope);
                model.AltText5_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.AltText5, storeScope);

                model.Picture6Id_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Picture6Id, storeScope);
                model.Title6_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Title6, storeScope);
                model.Header6_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Header6, storeScope);
                model.Link6_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Link6, storeScope);
                model.AltText6_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.AltText6, storeScope);

                model.Picture7Id_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Picture7Id, storeScope);
                model.Title7_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Title7, storeScope);
                model.Header7_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Header7, storeScope);
                model.Link7_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Link7, storeScope);
                model.AltText7_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.AltText7, storeScope);

                model.Picture8Id_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Picture8Id, storeScope);
                model.Title8_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Title8, storeScope);
                model.Header8_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Header8, storeScope);
                model.Link8_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Link8, storeScope);
                model.AltText8_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.AltText8, storeScope);
            }

            return View("~/Plugins/Nop.Plugin.Widgets.DiscoverySuggestion/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var settings = await _settingService.LoadSettingAsync<DiscoverySuggestionSettings>(storeScope);

            //get previous picture identifiers
            var previousPictureIds = new[]
            {
                settings.Picture1Id,
                settings.Picture2Id,
                settings.Picture3Id,
                settings.Picture4Id,
                settings.Picture5Id,
                settings.Picture6Id,
                settings.Picture7Id,
                settings.Picture8Id
            };

            settings.Headline = model.Headline;
            settings.Description = model.Description;

            settings.Picture1Id = model.Picture1Id;
            settings.Title1 = model.Title1;
            settings.Header1 = model.Header1;
            settings.Link1 = model.Link1;
            settings.AltText1 = model.AltText1;
            settings.Picture2Id = model.Picture2Id;
            settings.Title2 = model.Title2;
            settings.Header2 = model.Header2;
            settings.Link2 = model.Link2;
            settings.AltText2 = model.AltText2;
            settings.Picture3Id = model.Picture3Id;
            settings.Title3 = model.Title3;
            settings.Header3 = model.Header3;
            settings.Link3 = model.Link3;
            settings.AltText3 = model.AltText3;
            settings.Picture4Id = model.Picture4Id;
            settings.Title4 = model.Title4;
            settings.Header4 = model.Header4;
            settings.Link4 = model.Link4;
            settings.AltText4 = model.AltText4;
            settings.Picture5Id = model.Picture5Id;
            settings.Title5 = model.Title5;
            settings.Header5 = model.Header5;
            settings.Link5 = model.Link5;
            settings.AltText5 = model.AltText5;
            settings.Picture6Id = model.Picture6Id;
            settings.Title6 = model.Title6;
            settings.Header6 = model.Header6;
            settings.Link6 = model.Link6;
            settings.AltText6 = model.AltText6;
            settings.Picture7Id = model.Picture7Id;
            settings.Title7 = model.Title7;
            settings.Header7 = model.Header7;
            settings.Link7 = model.Link7;
            settings.AltText7 = model.AltText7;
            settings.Picture8Id = model.Picture8Id;
            settings.Title8 = model.Title8;
            settings.Header8 = model.Header8;
            settings.Link8 = model.Link8;
            settings.AltText8 = model.AltText8;

            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Headline, model.Headline_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Description, model.Description_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Picture1Id, model.Picture1Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Title1, model.Title1_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Header1, model.Header1_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Link1, model.Link1_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.AltText1, model.AltText1_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Picture2Id, model.Picture2Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Title2, model.Title2_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Header2, model.Header2_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Link2, model.Link2_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.AltText2, model.AltText2_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Picture3Id, model.Picture3Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Title3, model.Title3_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Header3, model.Header3_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Link3, model.Link3_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.AltText3, model.AltText3_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Picture4Id, model.Picture4Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Title4, model.Title4_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Header4, model.Header4_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Link4, model.Link4_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.AltText4, model.AltText4_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Picture5Id, model.Picture5Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Title5, model.Title5_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Header5, model.Header5_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Link5, model.Link5_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.AltText5, model.AltText5_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Picture6Id, model.Picture6Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Title6, model.Title6_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Header6, model.Header6_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Link6, model.Link6_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.AltText6, model.AltText6_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Picture7Id, model.Picture7Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Title7, model.Title7_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Header7, model.Header7_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Link7, model.Link7_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.AltText7, model.AltText7_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Picture8Id, model.Picture8Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Title8, model.Title8_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Header8, model.Header8_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Link8, model.Link8_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.AltText8, model.AltText8_OverrideForStore, storeScope, false);

            await _settingService.ClearCacheAsync();

            var currentPictureIds = new[]
            {
                settings.Picture1Id,
                settings.Picture2Id,
                settings.Picture3Id,
                settings.Picture4Id,
                settings.Picture5Id,
                settings.Picture6Id,
                settings.Picture7Id,
                settings.Picture8Id
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
