using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Random = UnityEngine.Random;

namespace SCS {
    public class LevelManager : SCBehaviour {
        public LevelSO levels;
        protected void Awake() {
            Game.levelManager = this;
            Game.onStateChanged.AddListener(this.OnStateChanged);
        }

        private void OnStateChanged(Game.State state) {
            if (state == Game.State.Win) {
                SCManager.Analytics.LevelWon(Game.datamanager.GetLevel());
                Game.datamanager.NextLevel();
            } else if (state == Game.State.Lose) {
                SCManager.Analytics.LevelLost(Game.datamanager.GetLevel());
            } else if (state == Game.State.Home) {
                this.Reset();
            } else if (state == Game.State.Playing) {
                SCManager.Analytics.LevelStart(Game.datamanager.GetLevel());
            }
        }

        private void Reset() {
            if (Game.map != null) {
                Destroy(Game.map.gameObject);
            }
            Game.map = this.GetLevel();
        }

        private Map GetLevel() {
            int level = Game.datamanager.GetLevel();
            if (level >= this.levels.maps.Length) {
                Map[] maps = this.levels.maps.Except(this.levels.excludeFromRepeat).ToArray();
                return Instantiate(maps[Random.Range(0, maps.Length)], Game.Instance.transform);
            }
            return Instantiate(this.levels.maps[level], Game.Instance.transform);
        }


    }
}