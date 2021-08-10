using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Infrastructure;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.HomePopUp
{
    class HomePopUpPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ILocalizationService _localizationService;
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;
        private readonly INopFileProvider _fileProvider;

        public HomePopUpPlugin(ILocalizationService localizationService,
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
            return Task.FromResult<IList<string>>(new List<string> { PublicWidgetZones.HomepageTop });
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/WidgetsHomePopUp/Configure";
        }

        /// <summary>
        /// Gets a name of a view component for displaying widget
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <returns>View component name</returns>
        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsHomePopUp";
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task InstallAsync()
        {
            //pictures
            var sampleImagesPath = _fileProvider.MapPath("~/Plugins/Nop.Plugin.Widgets.HomePopUp/Contents/SampleImages/");

            //settings
            var settings = new HomePopUpSettings
            {
                Picture = (await _pictureService.InsertPictureAsync(await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "icon.webp")), MimeTypes.ImagePJpeg, "icon")).Id,
                Text = "Đăng ký nhận ưu đãi chỗ ở tốt nhất hiện nay tại Dibooking",
                Link = _webHelper.GetStoreLocation(false),
                Position=true,
                FromDate=DateTime.Now,
                ToDate= DateTime.Now
            };
            await _settingService.SaveSettingAsync(settings);

            await _localizationService.AddLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Plugins.Widgets.HomePopUp.Configure"] = "Configure",
                ["Plugins.Widgets.HomePopUp.Picture"] = "Picture",
                ["Plugins.Widgets.HomePopUp.Picture.Hint"] = "Upload picture.",
                ["Plugins.Widgets.HomePopUp.Text"] = "Text",
                ["Plugins.Widgets.HomePopUp.Text.Hint"] = "Please enter text",
                ["Plugins.Widgets.HomePopUp.Link"] = "URL",
                ["Plugins.Widgets.HomePopUp.Link.Hint"] = "Enter URL. If you don't want the button to be hidden, leave the link empty",
                ["Plugins.Widgets.HomePopUp.Position"] = "Position",
                ["Plugins.Widgets.HomePopUp.Position.Hint"] = "The modal can be on top or in the middle of the page. If unchecked, the modal will be on top.",
                ["Plugins.Widgets.HomePopUp.ShowDate"] = "Show date",
                ["Plugins.Widgets.HomePopUp.ShowDate.Hint"] = "Check the box if you want dates to be rendered",
                ["Plugins.Widgets.HomePopUp.FromDate"] = "From date",
                ["Plugins.Widgets.HomePopUp.FromDate.Hint"] = "",
                ["Plugins.Widgets.HomePopUp.ToDate"] = "To date",
                ["Plugins.Widgets.HomePopUp.ToDate.Hint"] = ""
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
            await _settingService.DeleteSettingAsync<HomePopUpSettings>();

            //locales
            await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.HomePopUp");

            await base.UninstallAsync();
        }

        /// <summary>
        /// Gets a value indicating whether to hide this plugin on the widget list page in the admin area
        /// </summary>
        public bool HideInWidgetList => false;
    }
}
