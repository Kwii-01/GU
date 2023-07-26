using System;
using System.Collections;
using System.Collections.Generic;


using UnityEngine;

using Firebase;
using Firebase.Analytics;

namespace SCS {
    [DefaultExecutionOrder(-15)]
    public class Analytics : SCBehaviour {
        protected void Awake() {
            SCManager.Analytics = this;
            FirebaseManager.onFirebaseLoaded += this.OnFirebaseLoaded;
        }
        #region DEFAULT LOGGERS
        public void UserLogin() {
            this.LogEvent(FirebaseAnalytics.EventLogin);
        }

        public void LevelStart(int level) {
            this.LogEvent(FirebaseAnalytics.EventLevelStart, FirebaseAnalytics.ParameterLevel, level);
        }

        public void LevelEnd(int level) {
            this.LogEvent(FirebaseAnalytics.EventLevelEnd, FirebaseAnalytics.ParameterLevel, level);
        }

        public void LevelLost(int level) {
            this.LogEvent("LevelLost", FirebaseAnalytics.ParameterLevel, level);
            this.LevelEnd(level);
        }

        public void LevelWon(int level) {
            this.LogEvent("LevelWin", FirebaseAnalytics.ParameterLevel, level);
            this.LevelEnd(level);
        }
        #endregion

        #region LOGGERS
        public void LogEvent(string name, string parameterName, string parameterValue) {
            FirebaseAnalytics.LogEvent(name, parameterName, parameterValue);
        }

        public void LogEvent(string name, string parameterName, double parameterValue) {
            FirebaseAnalytics.LogEvent(name, parameterName, parameterValue);
        }

        public void LogEvent(string name, string parameterName, int parameterValue) {
            FirebaseAnalytics.LogEvent(name, parameterName, parameterValue);
        }

        public void LogEvent(string name, string parameterName, long parameterValue) {
            FirebaseAnalytics.LogEvent(name, parameterName, parameterValue);
        }
        public void LogEvent(string name) {
            FirebaseAnalytics.LogEvent(name);
        }

        public void LogEvent(string name, params Parameter[] parameters) {
            FirebaseAnalytics.LogEvent(name, parameters);
        }
        #endregion

        private void OnFirebaseLoaded() {
            this.UserLogin();
        }
    }
}