using GoogleMobileAds.Api;
using UnityEngine;

namespace Code.GoogleAds
{
    public class AdInitialize : MonoBehaviour
    {
        private void Awake() 
            => MobileAds.Initialize(initStatus => { });
    }
}