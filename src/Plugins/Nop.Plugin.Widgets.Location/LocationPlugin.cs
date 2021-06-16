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

namespace Nop.Plugin.Widgets.Location
{
    /// <summary>
    /// PLugin
    /// </summary>
    public class LocationPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ILocalizationService _localizationService;
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;
        private readonly INopFileProvider _fileProvider;
        private readonly IStateProvinceService _stateProvinceService;

        public LocationPlugin(
            ILocalizationService localizationService,
            IPictureService pictureService,
            ISettingService settingService,
            IWebHelper webHelper,
            INopFileProvider fileProvider,
            IStateProvinceService stateProvinceService)
        {
            _localizationService = localizationService;
            _pictureService = pictureService;
            _settingService = settingService;
            _webHelper = webHelper;
            _fileProvider = fileProvider;
            _stateProvinceService = stateProvinceService;
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
            return Task.FromResult<IList<string>>(new List<string> { PublicWidgetZones.HomepageLocation });
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/WidgetsLocation/Configure";
        }

        /// <summary>
        /// Gets a name of a view component for displaying widget
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <returns>View component name</returns>
        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsLocation";
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task InstallAsync()
        {
            //pictures
            var sampleImagesPath = _fileProvider.MapPath("~/Plugins/Widgets.Location/Content/nivoslider/sample-images/");

            var stateProvince = await _stateProvinceService.GetStateProvinceByAbbreviationAsync("HN", 242);

            //settings
            var settings = new LocationSettings
            {
                Picture1Id = (await _pictureService.InsertPictureAsync(await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "banner1.jpg")), MimeTypes.ImagePJpeg, "banner_1")).Id,
                Text1 = "",
                Link1 = _webHelper.GetStoreLocation(false),
                StateProvinceId1 = stateProvince.Id,

                Picture2Id = (await _pictureService.InsertPictureAsync(await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "banner2.jpg")), MimeTypes.ImagePJpeg, "banner_2")).Id,
                Text2 = "",
                Link2 = _webHelper.GetStoreLocation(false),
                StateProvinceId2 = stateProvince.Id,

                StateProvinceId3 = stateProvince.Id,
                StateProvinceId4 = stateProvince.Id,
                StateProvinceId5 = stateProvince.Id,
                StateProvinceId6 = stateProvince.Id,
                StateProvinceId7 = stateProvince.Id,
                StateProvinceId8 = stateProvince.Id,
                StateProvinceId9 = stateProvince.Id,
                StateProvinceId10 = stateProvince.Id

                //Picture3Id = _pictureService.InsertPicture(File.ReadAllBytes(_fileProvider.Combine(sampleImagesPath,"banner3.jpg")), MimeTypes.ImagePJpeg, "banner_3").Id,
                //Text3 = "",
                //Link3 = _webHelper.GetStoreLocation(false),
            };
            await _settingService.SaveSettingAsync(settings);

            await _localizationService.AddLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Plugins.Widgets.Location.Picture1"] = "Picture 1",
                ["Plugins.Widgets.Location.Picture2"] = "Picture 2",
                ["Plugins.Widgets.Location.Picture3"] = "Picture 3",
                ["Plugins.Widgets.Location.Picture4"] = "Picture 4",
                ["Plugins.Widgets.Location.Picture5"] = "Picture 5",
                ["Plugins.Widgets.Location.Picture6"] = "Picture 6",
                ["Plugins.Widgets.Location.Picture7"] = "Picture 7",
                ["Plugins.Widgets.Location.Picture8"] = "Picture 8",
                ["Plugins.Widgets.Location.Picture9"] = "Picture 9",
                ["Plugins.Widgets.Location.Picture10"] = "Picture 10",
                ["Plugins.Widgets.Location.Picture"] = "Picture",
                ["Plugins.Widgets.Location.Picture.Hint"] = "Upload picture.",
                ["Plugins.Widgets.Location.Text"] = "Comment",
                ["Plugins.Widgets.Location.Text.Hint"] = "Enter comment for picture. Leave empty if you don't want to display any text.",
                ["Plugins.Widgets.Location.Link"] = "URL",
                ["Plugins.Widgets.Location.Link.Hint"] = "Enter URL. Leave empty if you don't want this picture to be clickable.",
                ["Plugins.Widgets.Location.AltText"] = "Image alternate text",
                ["Plugins.Widgets.Location.AltText.Hint"] = "Enter alternate text that will be added to image.",
                ["Plugins.Widgets.Location.StateProvince"] = "State Province",
                ["Plugins.Widgets.Location.StateProvince.Hint"] = "State Province."
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
            await _settingService.DeleteSettingAsync<LocationSettings>();

            //locales
            await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.Location");

            await base.UninstallAsync();
        }

        /// <summary>
        /// Gets a value indicating whether to hide this plugin on the widget list page in the admin area
        /// </summary>
        public bool HideInWidgetList => false;
    }
}