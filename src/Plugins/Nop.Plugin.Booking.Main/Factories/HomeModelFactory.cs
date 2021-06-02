using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Vendors;
using Nop.Data;
using Nop.Plugin.Booking.DB.Services;
using Nop.Plugin.Booking.Main.Models;
using Nop.Plugin.Booking.Main.Services;
using Nop.Services.Common;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Services.Vendors;
using Nop.Web.Framework.Localization;

namespace Nop.Plugin.Booking.Main.Factories
{
    public partial class HomeModelFactory: IHomeModelFactory
    {
        #region Fields
        private readonly ILocationCategoryService _locationCategoryService;
        private readonly ILocationService _locationService;
        private readonly IVendorService _vendorService;
        private readonly IAddressService _addressService;
        private readonly IStateProvinceService _stateProvinceService;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<Vendor> _vendorRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly IPlaceSuggestionService _customVendorService;

        #endregion

        public HomeModelFactory(
            ILocationCategoryService locationCategoryService,
            ILocationService locationService,
            IVendorService vendorService,
            IAddressService addressService,
            IStateProvinceService stateProvinceService,
            ILocalizationService localizationService,
            IRepository<Vendor> vendorRepository,
            IRepository<Address> addressRepository,
            IPlaceSuggestionService customVendorService)
        {
            _locationCategoryService = locationCategoryService;
            _locationService = locationService;
            _vendorService = vendorService;
            _addressService = addressService;
            _stateProvinceService = stateProvinceService;
            _localizationService = localizationService;
            _vendorRepository = vendorRepository;
            _addressRepository = addressRepository;
            _customVendorService = customVendorService;
        }

        public virtual Task<BannerModel> PrepareBannerModelAsync()
        {
            var model = new BannerModel();
            return Task.FromResult(model);
        }

        public virtual async Task<IList<PlaceSuggestionModel>> PreparePlaceSuggestionModelAsync()
        {
            return await _customVendorService.GetPlaceSuggestionAsync();

            //var vendors = await _vendorService.GetAllVendorsAsync();

            //foreach (var vendor in vendors)
            //{
            //    var addressId = vendor.AddressId;
            //    var vendorAddress = await _addressService.GetAddressByIdAsync(addressId);
            //    if (vendorAddress == null)
            //    {
            //        continue;
            //    }

            //    var stateProvinceId = vendorAddress.StateProvinceId;
            //    if (stateProvinceId == null)
            //    {
            //        continue;
            //    }
            //    var model = new PlaceSuggestionModel();

            //    var stateProvince = await _stateProvinceService.GetStateProvinceByIdAsync((int)stateProvinceId);

            //    var resFormat = await _localizationService.GetResourceAsync(stateProvince.Abbreviation);
            //    if (string.IsNullOrEmpty(resFormat))
            //    {
            //        model.Name = new LocalizedString(stateProvince.Abbreviation).ToString();
            //        models.Add(model);
            //        continue;
            //    }

            //    model.Name = new LocalizedString(resFormat).ToString();
            //    models.Add(model);
            //}

            //return models;
        }

        public virtual Task<PromotionModel> PreparePromotionModelAsync()
        {
            var model = new PromotionModel();
            return Task.FromResult(model);
        }

        public virtual Task<DestinationModel> PrepareDestinationModelAsync()
        {
            var model = new DestinationModel();
            return Task.FromResult(model);
        }

        public virtual Task<DiscoveryModel> PrepareDiscoveryModelAsync()
        {
            var model = new DiscoveryModel();
            return Task.FromResult(model);
        }

        public virtual Task<UserManualModel> PrepareUserManualModelAsync()
        {
            var model = new UserManualModel();
            return Task.FromResult(model);
        }

        public virtual Task<IntroductionModel> PrepareIntroductionModelAsync()
        {
            var model = new IntroductionModel();
            return Task.FromResult(model);
        }
    }
}
