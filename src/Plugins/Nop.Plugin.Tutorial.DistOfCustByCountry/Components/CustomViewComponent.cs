using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using System;

namespace Nop.Plugin.Tutorial.DistOfCustByCountry.Components
{
    [ViewComponent(Name = "TutorialDistOfCustByCountry")]
    public class CustomViewComponent : NopViewComponent
    {
        public CustomViewComponent()
        {

        }

        public IViewComponentResult Invoke(int productId)
        {
            return View("~/Plugins/Nop.Plugin.Tutorial.DistOfCustByCountry/Views/Configure.cshtml");
        }
    }
}
