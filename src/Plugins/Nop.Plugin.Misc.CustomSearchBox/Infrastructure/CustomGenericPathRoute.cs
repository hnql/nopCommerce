using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework.Mvc.Routing;
using Nop.Web.Infrastructure;

namespace Nop.Plugin.Misc.CustomSearchBox.Infrastructure
{
    class CustomGenericPathRoute : BaseRouteProvider, IRouteProvider
    {
        public int Priority
        {
            //get { return int.MaxValue; }
            get { return 2; }
        }

        public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
        {
            //autocomplete search term (AJAX)
            endpointRouteBuilder.MapControllerRoute(name: "ProductSearchAutoComplete",
                pattern: $"catalog/searchtermautocomplete",
                defaults: new { controller = "CatalogCustom", action = "SearchTermAutoComplete" });
        }
    }
}
