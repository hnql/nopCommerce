using Nop.Core;
using Nop.Core.Infrastructure;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nop.Plugin.Tutorial.DistOfCustByCountry
{
    /// <summary>
    /// Rename this file and change to the correct type
    /// </summary>
    public class DistOfCustByCountryPlugin : BasePlugin
    {
        private readonly ILocalizationService _localizationService;
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;
        private readonly INopFileProvider _fileProvider;

        public DistOfCustByCountryPlugin(ILocalizationService localizationService,
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


        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/DistOfCustByCountryPlugin/Configure";// ten Controller
        }

        public override async Task InstallAsync()
        {
            //Code you want to run while installing the plugin goes here.
            await base.InstallAsync();
        }

        public override async Task UninstallAsync()
        {
          
            await base.UninstallAsync();
        }
    }
}
