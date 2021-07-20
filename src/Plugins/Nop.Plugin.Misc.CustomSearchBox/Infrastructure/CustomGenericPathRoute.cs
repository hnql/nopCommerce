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
            //get language pattern
            //it's not needed to use language pattern in AJAX requests and for actions returning the result directly (e.g. file to download),
            //use it only for URLs of pages that the user can go to
            var lang = GetLanguageRoutePattern();

            //product search
            endpointRouteBuilder.MapControllerRoute(name: "ProductSearch",
                pattern: $"{lang}/search/",
                defaults: new { controller = "CatalogCustom", action = "SearchByDate" });

            //autocomplete search term (AJAX)
            endpointRouteBuilder.MapControllerRoute(name: "ProductSearchAutoComplete",
                pattern: $"catalog/searchtermautocomplete",
                defaults: new { controller = "CatalogCustom", action = "SearchTermAutoComplete" });
        }
    }
}
