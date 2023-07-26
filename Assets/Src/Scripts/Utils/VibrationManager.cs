using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace SCS {
    public class VibrationManager : SCBehaviour {
        protected void Awake() {
            Game.vibrationManager = this;
        }
    }
}