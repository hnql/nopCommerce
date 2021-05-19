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
    public partial class TestModelFactory: ITestModelFactory
    {
        public virtual Task<TestComponentModel> PrepareFeaturedLocationsProductsAsync()
        {
            var model = new TestComponentModel();

            return Task.FromResult(model);
        }
    }
}
