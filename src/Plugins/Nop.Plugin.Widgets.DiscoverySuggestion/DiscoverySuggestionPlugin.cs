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

namespace Nop.Plugin.Widgets.DiscoverySuggestion
{
    public class DiscoverySuggestionPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ILocalizationService _localizationService;
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;
        private readonly INopFileProvider _fileProvider;

        public DiscoverySuggestionPlugin(ILocalizationService localizationService,
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
            return Task.FromResult<IList<string>>(new List<string> { PublicWidgetZones.HomepageBeforePoll });
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/WidgetsDiscoverySuggestion/Configure";
        }

        /// <summary>
        /// Gets a name of a view component for displaying widget
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <returns>View component name</returns>
        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsDiscoverySuggestion";
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task InstallAsync()
        {
            //pictures
            var sampleImagesPath = _fileProvider.MapPath("~/Plugins/Nop.Plugin.Widgets.DiscoverySuggestion/Content/SampleImages/");

            //settings
            var settings = new DiscoverySuggestionSettings
            {
                Headline="Gợi ý khám phá",
                Description= "Để mỗi chuyến đi là một hành trình truyền cảm hứng, mỗi căn phòng là một khoảng trời an yên",

                Picture1Id = (await _pictureService.InsertPictureAsync(await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "sample_1.jpg")), MimeTypes.ImagePJpeg, "sample_1")).Id,
                Title1 = "Du lịch Cần Thơ nhất định phải ghé thăm những địa điểm này",
                Header1="THÔNG TIN HOMESTAY",
                Link1 = _webHelper.GetStoreLocation(false),
                AltText1= "Tuần lễ “Tôi yêu bánh mì Sài Gòn” chính thức diễn ra từ ngày 24/3",

                Picture2Id = (await _pictureService.InsertPictureAsync(await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "sample_2.jpg")), MimeTypes.ImagePJpeg, "sample_2")).Id,
                Title2 = "Tuần lễ “Tôi yêu bánh mì Sài Gòn” chính thức diễn ra từ ngày 24/3",
                Header2 = "THÔNG TIN HOMESTAY",
                Link2 = _webHelper.GetStoreLocation(false),
                AltText2 = "Tuần lễ “Tôi yêu bánh mì Sài Gòn” chính thức diễn ra từ ngày 24/3",

                Picture3Id = (await _pictureService.InsertPictureAsync(await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "sample_3.jpg")), MimeTypes.ImagePJpeg, "sample_3")).Id,
                Title3 = "Trải nghiệm thú vị ở sở thú Zoodoo Đà Lạt",
                Header3 = "TP. HỒ CHÍ MINH",
                Link3 = _webHelper.GetStoreLocation(false),
                AltText3 = "Trải nghiệm thú vị ở sở thú Zoodoo Đà Lạt",

                Picture4Id = (await _pictureService.InsertPictureAsync(await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "sample_4.jpg")), MimeTypes.ImagePJpeg, "sample_4")).Id,
                Title4 = "Hội An sẽ lập chốt quản lý du khách đeo khẩu trang khi vào thành phố",
                Header4 = "HỘI AN",
                Link4 = _webHelper.GetStoreLocation(false),
                AltText4 = "Hội An sẽ lập chốt quản lý du khách đeo khẩu trang khi vào thành phố",
            };
            await _settingService.SaveSettingAsync(settings);

            await _localizationService.AddLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Plugins.Widgets.DiscoverySuggestion.Headline"] = "Headline",
                ["Plugins.Widgets.DiscoverySuggestion.Headline.Hint"] = "Enter headline",
                ["Plugins.Widgets.DiscoverySuggestion.Description"] = "Description",
                ["Plugins.Widgets.DiscoverySuggestion.Description.Hint"] = "Enter description",

                ["Plugins.Widgets.DiscoverySuggestion.Picture1"] = "Picture 1",
                ["Plugins.Widgets.DiscoverySuggestion.Picture2"] = "Picture 2",
                ["Plugins.Widgets.DiscoverySuggestion.Picture3"] = "Picture 3",
                ["Plugins.Widgets.DiscoverySuggestion.Picture4"] = "Picture 4",
                ["Plugins.Widgets.DiscoverySuggestion.Picture5"] = "Picture 5",
                ["Plugins.Widgets.DiscoverySuggestion.Picture6"] = "Picture 6",
                ["Plugins.Widgets.DiscoverySuggestion.Picture7"] = "Picture 7",
                ["Plugins.Widgets.DiscoverySuggestion.Picture8"] = "Picture 8",
                ["Plugins.Widgets.DiscoverySuggestion.Picture"] = "Picture",
                ["Plugins.Widgets.DiscoverySuggestion.Picture.Hint"] = "Upload picture.",
                ["Plugins.Widgets.DiscoverySuggestion.Title"] = "Title",
                ["Plugins.Widgets.DiscoverySuggestion.Title.Hint"] = "Enter title for picture. Leave empty if you don't want to display any text.",
                ["Plugins.Widgets.DiscoverySuggestion.Header"] = "Header",
                ["Plugins.Widgets.DiscoverySuggestion.Header.Hint"] = "Enter Header for picture.",
                ["Plugins.Widgets.DiscoverySuggestion.Link"] = "URL",
                ["Plugins.Widgets.DiscoverySuggestion.Link.Hint"] = "Enter URL. Leave empty if you don't want this picture to be clickable.",
                ["Plugins.Widgets.DiscoverySuggestion.AltText"] = "Image alternate text",
                ["Plugins.Widgets.DiscoverySuggestion.AltText.Hint"] = "Enter alternate text that will be added to image."
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
            await _settingService.DeleteSettingAsync<DiscoverySuggestionSettings>();

            //locales
            await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.DiscoverySuggestion");

            await base.UninstallAsync();
        }

        /// <summary>
        /// Gets a value indicating whether to hide this plugin on the widget list page in the admin area
        /// </summary>
        public bool HideInWidgetList => false;
    }
}
