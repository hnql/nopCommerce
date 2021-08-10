using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using System;

namespace Nop.Plugin.Widgets.DiemDiem.Components
{
    [ViewComponent(Name = "DiemDiem")]
    public class CustomViewComponent : NopViewComponent
    {
        public CustomViewComponent()
        {

        }

        public IViewComponentResult Invoke()
        {
            return View("~/Plugins/Nop.Plugin.Widgets.DiemDiem/Views/PublicInfo.cshtml");
        }
    }
}
