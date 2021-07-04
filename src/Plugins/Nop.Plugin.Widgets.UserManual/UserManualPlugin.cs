using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Directory;
using Nop.Core.Infrastructure;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.UserManual
{
    /// <summary>
    /// PLugin
    /// </summary>
    public class UserManualPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ILocalizationService _localizationService;
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;
        private readonly INopFileProvider _fileProvider;

        public UserManualPlugin(
            ILocalizationService localizationService,
            IPictureService pictureService,
            ISettingService settingService,
            IWebHelper webHelper,
            INopFileProvider fileProvider)
        {
            _localizationService = localizationService;
            _pictureService = pictureService;
            _settingService = settingService;
            _webHelper = webHelper;
            _fileProvider = fileProvider;
        }

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the widget zones
        /// </returns>
        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(new List<string> { PublicWidgetZones.HomepageUserManual });
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/WidgetsUserManual/Configure";
        }

        /// <summary>
        /// Gets a name of a view component for displaying widget
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <returns>View component name</returns>
        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsUserManual";
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task InstallAsync()
        {
            //pictures
            var sampleImagesPath = _fileProvider.MapPath("~/Plugins/Widgets.UserManual/Content/nivoslider/sample-images/");

            //settings
            var settings = new UserManualSettings
            {
                Picture1Id = (await _pictureService.InsertPictureAsync(await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "booking_guide.jpg")), MimeTypes.ImagePJpeg, "booking_guide")).Id,
                Text1 = "",
                Link1 = _webHelper.GetStoreLocation(false),

                Picture2Id = (await _pictureService.InsertPictureAsync(await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "voucher_using.jpg")), MimeTypes.ImagePJpeg, "voucher_using")).Id,
                Text2 = "",
                Link2 = _webHelper.GetStoreLocation(false)
            };
            await _settingService.SaveSettingAsync(settings);

            await _localizationService.AddLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Plugins.Widgets.UserManual.Picture1"] = "Picture 1",
                ["Plugins.Widgets.UserManual.Picture2"] = "Picture 2",
                ["Plugins.Widgets.UserManual.Picture3"] = "Picture 3",
                ["Plugins.Widgets.UserManual.Picture4"] = "Picture 4",
                ["Plugins.Widgets.UserManual.Picture5"] = "Picture 5",
                ["Plugins.Widgets.UserManual.Picture6"] = "Picture 6",
                ["Plugins.Widgets.UserManual.Picture7"] = "Picture 7",
                ["Plugins.Widgets.UserManual.Picture8"] = "Picture 8",
                ["Plugins.Widgets.UserManual.Picture9"] = "Picture 9",
                ["Plugins.Widgets.UserManual.Picture10"] = "Picture 10",
                ["Plugins.Widgets.UserManual.Picture"] = "Picture",
                ["Plugins.Widgets.UserManual.Picture.Hint"] = "Upload picture.",
                ["Plugins.Widgets.UserManual.Text"] = "Comment",
                ["Plugins.Widgets.UserManual.Text.Hint"] = "Enter comment for picture. Leave empty if you don't want to display any text.",
                ["Plugins.Widgets.UserManual.Link"] = "URL",
                ["Plugins.Widgets.UserManual.Link.Hint"] = "Enter URL. Leave empty if you don't want this picture to be clickable.",
            });

            await base.InstallAsync();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task UninstallAsync()
        {
            //settings
            await _settingService.DeleteSettingAsync<UserManualSettings>();

            //locales
            await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.UserManual");

            await base.UninstallAsync();
        }

        /// <summary>
        /// Gets a value indicating whether to hide this plugin on the widget list page in the admin area
        /// </summary>
        public bool HideInWidgetList => false;
    }
}