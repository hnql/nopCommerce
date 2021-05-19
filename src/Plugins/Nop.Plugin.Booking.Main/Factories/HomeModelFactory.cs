using System.Threading.Tasks;
using Nop.Plugin.Booking.Main.Models;

namespace Nop.Plugin.Booking.Main.Factories
{
    public partial class HomeModelFactory: IHomeModelFactory
    {
        public virtual Task<BannerModel> PrepareBannerModelAsync()
        {
            var model = new BannerModel();
            return Task.FromResult(model);
        }

        public virtual Task<PlaceSuggestionModel> PreparePlaceSuggestionModelAsync()
        {
            var model = new PlaceSuggestionModel();
            return Task.FromResult(model);
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
