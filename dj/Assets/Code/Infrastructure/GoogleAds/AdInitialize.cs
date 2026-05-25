using GoogleMobileAds.Api;
using UnityEngine;

namespace Code.Infrastructure.GoogleAds
{
    public class AdInitialize : MonoBehaviour
    {
        private void Awake() 
            => MobileAds.Initialize(initStatus => { });
    }
}