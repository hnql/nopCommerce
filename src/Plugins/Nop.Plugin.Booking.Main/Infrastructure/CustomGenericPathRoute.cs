using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework.Mvc.Routing;
using Nop.Web.Infrastructure;

namespace Nop.Plugin.Booking.Main.Infrastructure
{
    class CustomGenericPathRoute : BaseRouteProvider, IRouteProvider
    {
        public int Priority
        {
            get { return 3; }
        }

        public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapControllerRoute(name: "BlogPostListHomeAsync",
                pattern: $"blogpostlisthomeasync",
                defaults: new { controller = "BlogCustomController", action = "ListHomeAsync" });
        }
    }
}
