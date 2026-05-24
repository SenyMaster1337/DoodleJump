using Code.GoogleAds;

namespace Code.Services.GoogleAdsShowers
{
    public class GoogleAdsShowerService : IGoogleAdsShowerService
    {
        private const int ShowInterstitialInterval = 3;

        private readonly InterAd _interAd;

        private int _callCount;

        public GoogleAdsShowerService(InterAd interAd)
        {
            _interAd = interAd;
        }

        public void ShowInterAd()
        {
            _callCount++;

            if (_callCount >= ShowInterstitialInterval)
            {
                _interAd.ShowAd();
                _callCount = 0;
            }
        }
    }
}