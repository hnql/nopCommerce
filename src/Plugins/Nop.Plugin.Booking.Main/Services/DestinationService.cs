using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Vendors;
using Nop.Data;
using Nop.Plugin.Booking.Main.Models;
using Nop.Services.Media;
using Nop.Services.Vendors;
using Nop.Web.Areas.Admin.Factories;

namespace Nop.Plugin.Booking.Main.Services
{
    public partial class DestinationService : IDestinationService
    {

        #region Fields

        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<StateProvince> _stateProvinceRepository;
        private readonly IRepository<Vendor> _vendorRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Picture> _pictureRepository;
        private readonly IPictureService _pictureService;
        private readonly IVendorModelFactory _vendorModelFactory;
        private readonly IVendorService _vendorService;

        #endregion

        #region Ctor

        public DestinationService(IRepository<Address> addressRepository,
            IRepository<StateProvince> stateProvinceRepository,
            IRepository<Vendor> vendorRepository,
            IRepository<Product> productRepository,
            IRepository<Picture> pictureRepository,
            IPictureService pictureService,
            IVendorModelFactory vendorModelFactory,
            IVendorService vendorService)
        {
            _addressRepository = addressRepository;
            _stateProvinceRepository = stateProvinceRepository;
            _vendorRepository = vendorRepository;
            _productRepository = productRepository;
            _pictureRepository = pictureRepository;
            _pictureService = pictureService;
            _vendorModelFactory = vendorModelFactory;
            _vendorService = vendorService;
        }

        #endregion

        public virtual async Task<IList<DestinationModel>> GetDestinationAsync()
        {
            var models = new List<DestinationModel>();
            var destinations = await (from v in _vendorRepository.Table
                                   from a in _addressRepository.Table.Where(a => a.Id == v.AddressId).DefaultIfEmpty()
                                   from sp in _stateProvinceRepository.Table.Where(sp => sp.Id == a.StateProvinceId).DefaultIfEmpty()
                                   where !v.Deleted && v.Active
                                   group new { sp, v } by new { sp.Name, v.Id, v.PictureId, v.Description } into g
                                   select new { StateProvince = g.Key.Name, PictureId = g.Key.PictureId, Description = g.Key.Description, VendorId = g.Key.Id }
                                   ).Distinct().ToListAsync();


            foreach (var destination in destinations)
            {
                var vendor = await _vendorService.GetVendorByIdAsync(destination.VendorId);
                var vendorModel = await _vendorModelFactory.PrepareVendorModelAsync(null, vendor);
                var typeAttribute = vendorModel.VendorAttributes.Where(va => va.Id == 1).FirstOrDefault();
                var typeValue = typeAttribute.Values.Where(ta => ta.IsPreSelected).FirstOrDefault().Name;

                var model = new DestinationModel
                {
                    StateProvince = destination.StateProvince,
                    PictureUrl = await _pictureService.GetPictureUrlAsync(destination.PictureId, showDefaultPicture: false) ?? "",
                    Excerpt = destination.Description,
                    VendorType = typeValue
                };

                models.Add(model);
            }

            return models;
        }
    }
}
