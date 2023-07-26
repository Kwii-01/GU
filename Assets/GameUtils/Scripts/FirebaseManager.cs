using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Firebase;
using Firebase.Analytics;

namespace SCS {
    [DefaultExecutionOrder(-20)]
    public class FirebaseManager : SCBehaviour {
        private FirebaseApp _app;
        public static Action onFirebaseLoaded;
        public static bool loaded { get; private set; } = false;

        protected void Awake() {
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
                this._app = FirebaseApp.DefaultInstance;
                FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
                loaded = true;
                if (onFirebaseLoaded != null) {
                    onFirebaseLoaded.Invoke();
                }
            });
        }
    }
}