using GoogleMobileAds.Api;
using UnityEngine;
using Zenject;

namespace Code.GoogleAds
{
    public class InterAd : IInitializable
    {
        private const string InterstitialUnitId = "ca-app-pub-3940256099942544/1033173712";

        private InterstitialAd _interstitialAd;

        public void Initialize()
            => LoadAd();

        private void LoadAd()
        {
            if (_interstitialAd != null)
            {
                _interstitialAd.Destroy();
            }

            var adRequest = new AdRequest();

            InterstitialAd.Load(InterstitialUnitId, adRequest, (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null)
                {
                    Debug.LogError($"Interstitial ad failed to load: {error}");
                    return;
                }

                _interstitialAd = ad;
                RegisterEventHandlers();
            });
        }

        public void ShowAd()
        {
            if (_interstitialAd != null && _interstitialAd.CanShowAd())
            {
                _interstitialAd.Show();
            }
        }

        private void RegisterEventHandlers()
            => _interstitialAd.OnAdFullScreenContentClosed += () => { LoadAd(); };
    }
}