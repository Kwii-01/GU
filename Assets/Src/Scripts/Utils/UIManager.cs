using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace SCS {
    [DefaultExecutionOrder(-4)]
    public class UIManager : Singleton<UIManager> {
        public MenuHome menuHome;
        public MenuGame menuGame;
        public MenuLose menuLose;
        public MenuWin MenuWin;

        protected override void Awake() {
            base.Awake();
            Game.onStateChanged.AddListener(this.OnGameStateChanged);
        }

        private void OnGameStateChanged(Game.State state) {
            this.HideAll();
            if (state == Game.State.Home) {
                this.menuHome.Display();
            } else if (state == Game.State.Playing) {
                this.menuGame.Display();
            } else if (state == Game.State.Lose) {
                this.menuLose.Display();
            } else {
                this.MenuWin.Display();
            }
        }

        private void HideAll() {
            this.menuHome.Hide();
            this.menuGame.Hide();
            this.menuLose.Hide();
            this.MenuWin.Hide();
        }
    }
}