using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;
using System.Linq;

namespace Nop.Plugin.Booking.Main.Infrastructure
{
    public class ViewLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            if (context.AreaName == "Admin")
            {
                viewLocations = new[] {
                    $"/Plugins/Nop.Plugin.Booking.Main/Areas/Admin/Views/{{1}}/{{0}}.cshtml",
                    $"/Plugins/Nop.Plugin.Booking.Main/Areas/Admin/Views/Shared/{{0}}.cshtml"
                }.Concat(viewLocations);
            }
            else
            {
                viewLocations = new[] {
                    $"/Plugins/Booking.Main/Views/{{1}}/{{0}}.cshtml",
                    $"/Plugins/Booking.Main/Views/Shared/{{0}}.cshtml"
                }.Concat(viewLocations);
            }

            return viewLocations;
        }
    }
}
