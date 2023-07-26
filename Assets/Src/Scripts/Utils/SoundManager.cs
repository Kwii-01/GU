using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace SCS {
    public class SoundManager : SCBehaviour {
        protected void Awake() {
            Game.soundManager = this;
        }
    }
}