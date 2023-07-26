using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace SCS {
    [CreateAssetMenu(menuName = "SCS/Config")]
    public class ConfigSO : ScriptableObject {
        public bool modeDevelopper;

        [Header("Ads")]
        [Space(5)]
        public float InterstitialInterval = 20f;
        public string InsterstitialANDAdUnitId;
        public string InsterstitialIOSAdUnitId;
        [Space(10)]
        public string BannerANDAdUnitId;
        public string BannerIOSAdUnitId;
        [Space(10)]
        public string RewardANDAdUnitId;
        public string RewardIOSAdUnitId;


        public string GetInterstitialAdUnitId() {
#if UNITY_EDITOR
#if UNITY_ANDROID
            return "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
            return "ca-app-pub-3940256099942544/4411468910";
#else
            return "unused";
#endif
#else
#if UNITY_ANDROID
            if (this.testMode) {
                return "ca-app-pub-3940256099942544/1033173712";
            }
            return this.InsterstitialANDAdUnitId;
#elif UNITY_IPHONE
            if (this.testMode) {
                return "ca-app-pub-3940256099942544/4411468910";
            }
            return this.InsterstitialIOSAdUnitId;
#else
            return "unused";
#endif
#endif
        }

        public string GetBannerAdUnitId() {
#if UNITY_EDITOR
#if UNITY_ANDROID
            return "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            return "ca-app-pub-3940256099942544/2934735716";
#else
            return "unused";
#endif
#else
#if UNITY_ANDROID
            if (this.testMode) {
                return "ca-app-pub-3940256099942544/6300978111";
            }
            return this.BannerANDAdUnitId;
#elif UNITY_IPHONE
            if (this.testMode) {
                return "ca-app-pub-3940256099942544/2934735716";
            }
            return this.BannerIOSAdUnitId;
#else
            return "unused";
#endif
#endif
        }

        public string GetRewardAdUnitId() {
#if UNITY_EDITOR
#if UNITY_ANDROID
            return "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
            return "ca-app-pub-3940256099942544/1712485313";
#else
            return "unused";
#endif
#else
#if UNITY_ANDROID
            if (this.testMode) {
                return "ca-app-pub-3940256099942544/5224354917";
            }
            return this.RewardANDAdUnitId;
#elif UNITY_IPHONE
            if (this.testMode) {
                return "ca-app-pub-3940256099942544/1712485313";
            }
            return this.RewardIOSAdUnitId;
#else
            return "unused";
#endif
#endif
        }
    }
}