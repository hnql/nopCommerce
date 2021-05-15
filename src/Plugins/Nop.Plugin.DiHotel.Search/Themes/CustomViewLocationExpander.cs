using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Nop.Plugin.DiHotel.Search.Themes
{
    public class CustomViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            if (context.AreaName == null && context.ControllerName == "Home" && context.ViewName == "Components/SearchBox/Default")
            {
                viewLocations = new string[] {
                    $"/Plugins/DiHotel.Search/Views/{{0}}.cshtml",
                    $"/Plugins/DiHotel.Search/Views/Shared/{{0}}.cshtml"
                }.Concat(viewLocations);
            }

            return viewLocations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }
    }
}
