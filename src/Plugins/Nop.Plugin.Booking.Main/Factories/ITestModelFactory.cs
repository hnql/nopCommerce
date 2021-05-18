using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Vendors;
using Nop.Plugin.Booking.Main.Models;

namespace Nop.Plugin.Booking.Main.Factories
{
    public partial interface ITestModelFactory
    {
        Task<TestComponentModel> PrepareFeaturedLocationsProductsAsync();
    }
}
