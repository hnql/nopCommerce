using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Common;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Vendors;
using Nop.Data;
using Nop.Plugin.Booking.Main.Models;
using Nop.Services.Vendors;

namespace Nop.Plugin.Booking.Main.Services
{
    public partial class PlaceSuggestionService: IPlaceSuggestionService
    {

        #region Fields

        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<StateProvince> _stateProvinceRepository;
        private readonly IRepository<Vendor> _vendorRepository;
        private readonly IRepository<Product> _productRepository;

        #endregion

        #region Ctor

        public PlaceSuggestionService(IRepository<Address> addressRepository,
            IRepository<StateProvince> stateProvinceRepository,
            IRepository<Vendor> vendorRepository,
            IRepository<Product> productRepository)
        {
            _addressRepository = addressRepository;
            _stateProvinceRepository = stateProvinceRepository;
            _vendorRepository = vendorRepository;
            _productRepository = productRepository;
        }

        #endregion

        public virtual async Task<IList<PlaceSuggestionModel>> GetPlaceSuggestionAsync()
        {
            var models = new List<PlaceSuggestionModel>();
            var locations = await (from v in _vendorRepository.Table
                                   from p in _productRepository.Table.Where(p => p.VendorId == v.Id).DefaultIfEmpty()
                                   from a in _addressRepository.Table.Where(a => a.Id == v.AddressId).DefaultIfEmpty()
                                   from sp in _stateProvinceRepository.Table.Where(sp => sp.Id == a.StateProvinceId).DefaultIfEmpty()
                                   where !v.Deleted && v.Active
                                   group new { sp, p } by new { sp.Name } into g
                                   select new { Name = g.Key.Name, ProductCount = g.Count(g => !string.IsNullOrEmpty(g.p.Id.ToString())) }
                                   ).Distinct().ToListAsync();


            foreach (var location in locations)
            {
                var model = new PlaceSuggestionModel();
                model.Name = location.Name;
                model.Available = (int)location.ProductCount;
                models.Add(model);
            }

            return models;
        }
    }
}
