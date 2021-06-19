using System;
using Nop.Core.Domain.Catalog;


namespace Nop.Core.Domain.Common
{
    public class ProductWithLocationModel : Product
    {
        /// <summary>
        /// Gets or sets the location's name
        /// </summary>
        public string LocationName { get; set; }
    }
}
