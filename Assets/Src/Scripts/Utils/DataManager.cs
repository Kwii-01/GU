using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

namespace SCS {
    [DefaultExecutionOrder(-4)]
    public class DataManager : SCBehaviour {
        private static readonly string LEVEL = "LEVEL";
        public UnityEvent onSave { get; private set; } = new UnityEvent();

        protected void Awake() {
            Game.datamanager = this;
        }

        private void OnApplicationQuit() {
            this.onSave.Invoke();
        }

        private void OnApplicationPause(bool pauseStatus) {
            if (pauseStatus) {
                this.onSave.Invoke();
            }
        }

        public void NextLevel() {
            this.SetLevel(this.GetLevel() + 1);
        }

        public void PrevLevel() {
            this.SetLevel(Mathf.Max(this.GetLevel() - 1, 0));
        }

        public int GetLevel() {
            return PlayerPrefs.GetInt(LEVEL, 0);
        }

        private void SetLevel(int level) {
            PlayerPrefs.SetInt(LEVEL, level);
        }

    }
}