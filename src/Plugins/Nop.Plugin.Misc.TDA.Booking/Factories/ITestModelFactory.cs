using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Vendors;
using Nop.Plugin.Misc.TDA.Booking.Models;

namespace Nop.Plugin.Misc.TDA.Booking.Factories
{
    public partial interface ITestModelFactory
    {
        Task<TestComponentModel> PrepareFeaturedLocationsProductsAsync();
    }
}
