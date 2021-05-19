using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Plugin.Booking.DB.Services;
using Nop.Plugin.Booking.Main.Models;

namespace Nop.Plugin.Booking.Main.Factories
{
    public partial class HomeModelFactory: IHomeModelFactory
    {
        #region Fields
        private readonly ILocationCategoryService _locationCategoryService;
        private readonly ILocationService _locationService;
        #endregion

        public HomeModelFactory(
            ILocationCategoryService locationCategoryService,
            ILocationService locationService)
        {
            _locationCategoryService = locationCategoryService;
            _locationService = locationService;
        }

        public virtual Task<BannerModel> PrepareBannerModelAsync()
        {
            var model = new BannerModel();
            return Task.FromResult(model);
        }

        public virtual async Task<IList<PlaceSuggestionModel>> PreparePlaceSuggestionModelAsync()
        {
            var models = new List<PlaceSuggestionModel>();

            var locations = await _locationService.GetLocationsAsync();

            foreach (var location in locations)
            {
                var model = new PlaceSuggestionModel();
                model.Name = location.Name;
                models.Add(model);
            }

            return models;
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
