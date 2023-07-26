using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using GoogleMobileAds.Ump;
using GoogleMobileAds.Ump.Api;
namespace SCS {
    public class UmpManager : SCBehaviour {
        private ConsentForm _consentForm;
        private void Awake() {
            ConsentRequestParameters request = new ConsentRequestParameters { TagForUnderAgeOfConsent = false };
#if UNITY_EDITOR == false
            if (SCManager.config.modeDevelopper) {
                ConsentInformation.Reset();
                request.ConsentDebugSettings = new ConsentDebugSettings { DebugGeography = DebugGeography.EEA, TestDeviceHashedIds = new List<string> { "TEST-DEVICE-HASHED-ID" } };
            }
#endif
            ConsentInformation.Update(request, this.OnConsentInfoUpdated);

        }

        private void OnConsentInfoUpdated(FormError error) {
            if (error != null) {
                Debug.LogError(error);
                return;
            }
            // If the error is null, the consent information state was updated.
            // You are now ready to check if a form is available.
            if (ConsentInformation.IsConsentFormAvailable()) {
                this.LoadConsentForm();
            }

        }

        private void LoadConsentForm() {
            ConsentForm.Load(this.OnLoadConsentForm);
        }

        private void OnLoadConsentForm(ConsentForm consentForm, FormError error) {
            if (error != null) {
                Debug.LogError(error);
                return;
            }
            this._consentForm = consentForm;

            if (ConsentInformation.ConsentStatus == ConsentStatus.Required) {
                this._consentForm.Show(OnShowForm);
            }
        }

        private void OnShowForm(FormError error) {
            if (error != null) {
                Debug.LogError(error);
                return;
            }
            this.LoadConsentForm();
        }



    }
}