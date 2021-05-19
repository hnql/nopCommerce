using System.Threading.Tasks;
using Nop.Plugin.Booking.Main.Models;

namespace Nop.Plugin.Booking.Main.Factories
{
    public partial interface IHomeModelFactory
    {
        Task<BannerModel> PrepareBannerModelAsync();

        Task<PlaceSuggestionModel> PreparePlaceSuggestionModelAsync();

        Task<PromotionModel> PreparePromotionModelAsync();

        Task<DestinationModel> PrepareDestinationModelAsync();

        Task<DiscoveryModel> PrepareDiscoveryModelAsync();

        Task<UserManualModel> PrepareUserManualModelAsync();

        Task<IntroductionModel> PrepareIntroductionModelAsync();
    }
}
