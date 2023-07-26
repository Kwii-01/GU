using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

namespace SCS {
    [DefaultExecutionOrder(-5)]
    public class Game : Singleton<Game> {
        private Player _player;
        private Cam _cam;
        private Map _map;
        private DataManager _datamanager;
        private LevelManager _levelManager;
        private SoundManager _soundManager;
        private VibrationManager _vibrationManager;

        public static Player player {
            get => Instance._player; set => Instance._player = value;
        }
        public static Cam cam {
            get => Instance._cam; set => Instance._cam = value;
        }
        public static Map map {
            get => Instance._map; set => Instance._map = value;
        }
        public static DataManager datamanager {
            get => Instance._datamanager; set => Instance._datamanager = value;
        }
        public static LevelManager levelManager {
            get => Instance._levelManager; set => Instance._levelManager = value;
        }
        public static SoundManager soundManager {
            get => Instance._soundManager; set => Instance._soundManager = value;
        }
        public static VibrationManager vibrationManager {
            get => Instance._vibrationManager; set => Instance._vibrationManager = value;
        }

        public enum State {
            None,
            Home,
            Playing,
            Win,
            Lose
        }

        private State _state;
        private UnityEvent<State> _onStateChanged = new UnityEvent<State>();
        public static UnityEvent<State> onStateChanged => Instance._onStateChanged;
        public static State state {
            get => Instance._state;
            set {
                Instance._state = value;
                Instance._onStateChanged.Invoke(value);
            }
        }

        private void Start() {
            this._state = State.Home;
        }

        public void Win() {
            if (this._state != State.Lose) {
                state = State.Win;
            }
        }

        public void Lose() {
            if (this._state != State.Win) {
                state = State.Lose;
            }
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.W)) {
                state = State.Win;
            }
            if (Input.GetKeyDown(KeyCode.L)) {
                state = State.Lose;
            }
        }
    }
}