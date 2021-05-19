using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.ImportSampleData
{
    /// <summary>
    /// Rename this file and change to the correct type
    /// </summary>
    public class ImportSampleDataPlugin : BasePlugin, IWidgetPlugin
    {
        public bool HideInWidgetList => false;
        private readonly IWebHelper _webHelper;

        public ImportSampleDataPlugin(IWebHelper webHelper)
        {
            _webHelper = webHelper;
        }
        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "";
        }
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/MultiLevelMenu/Configure";
        }
        public Task<IList<string>> GetWidgetZonesAsync()
        {
            throw new System.NotImplementedException();
        }
        public override async Task InstallAsync()
        {
            await base.InstallAsync();
        }
        public override async Task UninstallAsync()
        {
            await base.UninstallAsync();
        }
    }
}
