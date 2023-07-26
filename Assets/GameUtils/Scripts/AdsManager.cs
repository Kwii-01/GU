using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using GoogleMobileAds.Api;
namespace SCS {
    [DefaultExecutionOrder(-15)]
    public class AdsManager : SCBehaviour {
        private BannerView _bannerView;
        private InterstitialAd _interstitialAd;
        private RewardedAd _rewardedAd;
        private float _interstitialTimer;

        private void Awake() {
            SCManager.AdsManager = this;
            MobileAds.RaiseAdEventsOnUnityMainThread = true;
            this.CreateBannerView();
            MobileAds.Initialize(this.OnInit);
        }

        private void Update() {
            if (this._interstitialTimer > 0f) {
                this._interstitialTimer -= Time.deltaTime;
            }
        }

        private void OnInit(InitializationStatus status) {
            this.LoadBannerAd();
            this.LoadInterstitialAd();
            this.LoadRewardedAd();
        }


        public void ShowInterstitial(Action onComplete) {
            if (this._interstitialTimer <= 0f) {
                if (this._interstitialAd != null && this._interstitialAd.CanShowAd()) {
                    Debug.Log("Showing interstitial ad.");
                    this.RegisterReloadHandler(this._interstitialAd, onComplete);
                    this._interstitialAd.Show();
                } else {
                    Debug.LogError("Interstitial ad is not ready yet.");
                    onComplete.Invoke();
                }
            } else {
                onComplete.Invoke();
            }
        }

        public void ShowRewardedAd(Action<bool> onComplete) {
            if (this._rewardedAd != null && this._rewardedAd.CanShowAd()) {
                this.RegisterEventHandlers(this._rewardedAd);
                this.RegisterReloadHandler(this._rewardedAd);
                this._rewardedAd.Show((Reward reward) => {
                    onComplete.Invoke(true);
                });
            }
        }
        private void RegisterEventHandlers(RewardedAd ad) {
            // Raised when an impression is recorded for an ad.
            ad.OnAdImpressionRecorded += () => {
                Debug.Log("Rewarded ad recorded an impression.");
            };
            // Raised when a click is recorded for an ad.
            ad.OnAdClicked += () => {
                Debug.Log("Rewarded ad was clicked.");
            };
        }

        private void RegisterReloadHandler(InterstitialAd ad, Action onComplete) {
            ad.OnAdFullScreenContentClosed += () => {
                Debug.Log("Interstitial Ad full screen content closed.");
                this._interstitialTimer = SCManager.config.InterstitialInterval;
                this.LoadInterstitialAd();
                onComplete.Invoke();
            };
            ad.OnAdFullScreenContentFailed += (AdError error) => {
                Debug.LogError("Interstitial ad failed to open full screen content " + "with error : " + error);
                this.LoadInterstitialAd();
            };
        }

        private void RegisterReloadHandler(RewardedAd ad) {
            // Raised when the ad closed full screen content.
            ad.OnAdFullScreenContentClosed += () => {
                Debug.Log("Rewarded Ad full screen content closed.");
                this.LoadRewardedAd();
            };
            ad.OnAdFullScreenContentFailed += (AdError error) => {
                Debug.LogError("Rewarded ad failed to open full screen content " + "with error : " + error);
                this.LoadRewardedAd();
            };
        }



        private void CreateBannerView() {
            Debug.Log("Creating banner view");
            AdSize size = AdSize.GetPortraitAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);
            this._bannerView = new BannerView(SCManager.config.GetBannerAdUnitId(), size, AdPosition.Bottom);
        }

        private void LoadBannerAd() {
            AdRequest adRequest = new AdRequest();
            adRequest.Keywords.Add("unity-admob-sample");

            // send the request to load the ad.
            Debug.Log("Loading banner ad.");
            this._bannerView.LoadAd(adRequest);
        }

        private void LoadInterstitialAd() {
            if (this._interstitialAd != null) {
                this._interstitialAd.Destroy();
                this._interstitialAd = null;
            }

            var adRequest = new AdRequest();
            adRequest.Keywords.Add("unity-admob-sample");

            // send the request to load the ad.
            InterstitialAd.Load(SCManager.config.GetInterstitialAdUnitId(), adRequest,
                (InterstitialAd ad, LoadAdError error) => {
                    if (error != null || ad == null) {
                        Debug.LogError("interstitial ad failed to load an ad " + "with error : " + error);
                        return;
                    }
                    Debug.Log("Interstitial ad loaded with response : " + ad.GetResponseInfo());
                    this._interstitialAd = ad;
                });
        }

        public void LoadRewardedAd() {
            // Clean up the old ad before loading a new one.
            if (this._rewardedAd != null) {
                this._rewardedAd.Destroy();
                this._rewardedAd = null;
            }

            Debug.Log("Loading the rewarded ad.");

            // create our request used to load the ad.
            var adRequest = new AdRequest();
            adRequest.Keywords.Add("unity-admob-sample");

            // send the request to load the ad.
            RewardedAd.Load(SCManager.config.GetRewardAdUnitId(), adRequest,
                (RewardedAd ad, LoadAdError error) => {
                    if (error != null || ad == null) {
                        Debug.LogError("Rewarded ad failed to load an ad " + "with error : " + error);
                        return;
                    }
                    Debug.Log("Rewarded ad loaded with response : " + ad.GetResponseInfo());
                    this._rewardedAd = ad;
                });
        }


    }
}