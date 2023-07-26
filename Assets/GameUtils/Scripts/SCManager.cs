using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace SCS {
    [DefaultExecutionOrder(-20)]
    public class SCManager : Singleton<SCManager> {
        [SerializeField] private ConfigSO _configSO;
        public static ConfigSO config => Instance._configSO;

        private AdsManager _adsManager;
        private Analytics _analytics;

        public static AdsManager AdsManager {
            get => Instance._adsManager; set => Instance._adsManager = value;
        }
        public static Analytics Analytics {
            get => Instance._analytics; set => Instance._analytics = value;
        }

        protected override void Awake() {
            base.Awake();
            DontDestroyOnLoad(this.gameObject);
        }
    }
}