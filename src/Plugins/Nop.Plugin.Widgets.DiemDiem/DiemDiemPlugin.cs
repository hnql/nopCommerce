﻿using Nop.Core;
using Nop.Core.Infrastructure;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.DiemDiem
{
    /// <summary>
    /// Rename this file and change to the correct type
    /// </summary>
    public class DiemDiemlugin :BasePlugin, IWidgetPlugin
    {
        private readonly ILocalizationService _localizationService;
    private readonly IPictureService _pictureService;
    private readonly ISettingService _settingService;
    private readonly IWebHelper _webHelper;
    private readonly INopFileProvider _fileProvider;

    public DiemDiemlugin(ILocalizationService localizationService,
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
        return _webHelper.GetStoreLocation() + "Admin/DiemDiem/Configure";
    }

    /// <summary>
    /// Gets a name of a view component for displaying widget
    /// </summary>
    /// <param name="widgetZone">Name of the widget zone</param>
    /// <returns>View component name</returns>
    public string GetWidgetViewComponentName(string widgetZone)
    {
        return "DiemDiem";
    }

    /// <summary>
    /// Install plugin
    /// </summary>
    /// <returns>A task that represents the asynchronous operation</returns>
    public override async Task InstallAsync()
    {
      

        await base.InstallAsync();
    }

    /// <summary>
    /// Uninstall plugin
    /// </summary>
    /// <returns>A task that represents the asynchronous operation</returns>
    public override async Task UninstallAsync()
    {
        await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.DiemDiem");

        await base.UninstallAsync();
    }

    /// <summary>
    /// Gets a value indicating whether to hide this plugin on the widget list page in the admin area
    /// </summary>
    public bool HideInWidgetList => false;
}
}
