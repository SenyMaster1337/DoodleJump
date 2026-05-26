using Code.Infrastructure.Services.GoogleAdsShowers;

namespace Code.Infrastructure.Services.Setups.Ads
{
    public class AdsSetup : IAdsSetup
    {
        private readonly IGoogleAdsShowerService _adsService;

        public AdsSetup(IGoogleAdsShowerService adsService)
        {
            _adsService = adsService;
        }

        public void Init()
            => _adsService.ShowInterAd();
    }
}