using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Web.Framework.Models;

namespace Nop.Web.Models.Catalog
{
    public partial record TestComponentModel: BaseNopModel
    {
        public string[] Products = { "Product 1", "Product 2" };
    }
}
