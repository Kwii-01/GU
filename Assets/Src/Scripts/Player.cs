using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace SCS {
    [DefaultExecutionOrder(-2)]
    public class Player : SCBehaviour {
        protected void Awake() {
            Game.player = this;
        }
    }
}